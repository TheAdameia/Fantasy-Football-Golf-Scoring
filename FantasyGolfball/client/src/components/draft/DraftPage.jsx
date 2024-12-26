import { createContext, useEffect, useState } from "react"
import { DraftPlayerList } from "./DraftPlayerList"
import { HubConnectionBuilder } from "@microsoft/signalr"
import { mockDraftState } from "./mockDraftState"
import { DraftSelectedPlayerView } from "./DraftSelectedPlayerView"
import { DraftUserOrder } from "./DraftUserOrder"

export const DraftContext = createContext()

export const DraftPage = () => {
    const [connection, setConnection] = useState(null)
    const [draftState, setDraftState] = useState(mockDraftState)
    const [currentTurn, setCurrentTurn] = useState(null)
    const [selectedPlayer, setSelectedPlayer] = useState(null)
    // const leagueId = 1 // replace with dynamic somehow - also contained in mockDraftState
    

    useEffect(() => {
        // uncomment when ready to use real data
        // const connect = async () => {
        //     const newConnection = new HubConnectionBuilder()
        //         .withUrl("/draftHub")
        //         .build()
        

        //     newConnection.on("TurnUpdated", (userId) => {
        //         console.log("User turn:", userId)
        //         setCurrentTurn(userId)
        //     })

        //     newConnection.on("Error", (error) => {
        //         console.error("Error:", error)
        //     })

        //     try {
        //         await newConnection.start()
        //         console.log("Connected to draft hub")

        //         // join draft group
        //         await newConnection.invoke("JoinDraft", leagueId)
        //         setConnection(newConnection)
        //     } catch (error) {
        //         console.error("Connection failed:", error)
        //     }
        // }
        // connect()

        // // cleanup on unmount
        // return () => {
        //     if (connection) {
        //         connection.stop()
        //     }
        // }
    }, []) // runs only on mount


    return (
        <DraftContext.Provider value={{ draftState, currentTurn, connection}}>
            <div>
                <div>Left side boxes
                    <div>Top left box - timer, turn indicator, next auto draft</div>
                    <DraftUserOrder />
                </div>
                <div>Right side boxes
                    <div>Player selection queue</div>
                    <div>My team display</div>
                    <div>Chat</div>
                </div>
                <div>Center box
                    <DraftSelectedPlayerView selectedPlayer={selectedPlayer}/>
                    <DraftPlayerList setSelectedPlayer={setSelectedPlayer}/>
                </div>
            </div>
        </DraftContext.Provider>
    )
}