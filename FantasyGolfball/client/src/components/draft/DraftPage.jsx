import { createContext, useEffect, useState } from "react"
import { DraftPlayerList } from "./DraftPlayerList"
import { HubConnectionBuilder } from "@microsoft/signalr"
import { mockDraftState } from "./mockDraftState"
import { DraftSelectedPlayerView } from "./DraftSelectedPlayerView"
import { DraftUserOrder } from "./DraftUserOrder"
import "./DraftLayout.css"
import Chat from "../../clientHubs/exampleClientHub"
import { DraftTimer } from "./DraftTimer"
import { DraftPlayerQueue } from "./DraftPlayerQueue"
import { DraftAutoQueue } from "./DraftAutoQueue"

export const DraftContext = createContext()

export const DraftPage = () => {
    const [connection, setConnection] = useState(null)
    const [draftState, setDraftState] = useState(mockDraftState)
    const [currentTurn, setCurrentTurn] = useState(null)
    const [selectedPlayer, setSelectedPlayer] = useState(null)
    const [queuedPlayers, setQueuedPlayers] = useState([])
    // const leagueId = 1 // replace with dynamic somehow - also contained in mockDraftState
    

    // handle dequeueing a player
    const deQueuePlayer = (removePlayer) => {
        let listCopy = [...queuedPlayers]
        listCopy = listCopy.filter(player => player.playerId !== removePlayer.playerId)
        setQueuedPlayers(listCopy)
    }

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
            <div className="draft-container">
                <div className="left-side">
                    <DraftTimer />
                    <DraftAutoQueue queuedPlayers={queuedPlayers} />
                    <DraftUserOrder />
                </div>
                <div className="right-side">
                    <DraftPlayerQueue 
                        queuedPlayers={queuedPlayers}
                        deQueuePlayer={deQueuePlayer}
                    />
                    <div>My team display</div>
                    <Chat />
                </div>
                <div className="center-box">
                    <DraftSelectedPlayerView 
                        selectedPlayer={selectedPlayer} 
                        setSelectedPlayer={setSelectedPlayer}
                        queuedPlayers={queuedPlayers}
                        setQueuedPlayers={setQueuedPlayers}
                    />
                    <DraftPlayerList setSelectedPlayer={setSelectedPlayer}/>
                </div>
            </div>
        </DraftContext.Provider>
    )
}