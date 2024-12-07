import { createContext, useEffect, useState } from "react"
import { DraftPlayerList } from "./DraftPlayerList"
import { HubConnectionBuilder } from "@microsoft/signalr"

export const DraftContext = createContext()

export const DraftPage = () => {
    const [connection, setConnection] = useState(null)
    const [draftState, setDraftState] = useState(null)
    const [currentTurn, setCurrentTurn] = useState(null)
    const leagueId = 1 // replace with dynamic somehow
    // now that I have a rough idea of how this is going to be structured in HTML, I can create more discrete tasks based on the features that this page will have.

    useEffect(() => {
        // initialize signalR connection
        const connect = async () => {
            const newConnection = new HubConnectionBuilder()
                .withUrl("/draftHub")
                .build()
        

            newConnection.on("TurnUpdated", (userId) => {
                console.log("User turn:", userId)
                setCurrentTurn(userId)
            })

            newConnection.on("Error", (error) => {
                console.error("Error:", error)
            })

            try {
                await newConnection.start()
                console.log("Connected to draft hub")

                // join draft group
                await newConnection.invoke("JoinDraft", leagueId)
                setConnection(newConnection)
            } catch (error) {
                console.error("Connection failed:", error)
            }
        }
        connect()

        // cleanup on unmount
        return () => {
            if (connection) {
                connection.stop()
            }
        }
    }, []) // runs only on mount


    return (
        <DraftContext.Provider value={{ draftState, currentTurn, connection}}>
            <div>
                <div>Left side boxes
                    <div>Top left box - timer, turn indicator, next auto draft</div>
                    <div>Draft round user order</div>
                </div>
                <div>Right side boxes
                    <div>Player selection queue</div>
                    <div>My team display</div>
                    <div>Chat</div>
                </div>
                <div>Center box
                    <div>Selected player box</div>
                    <DraftPlayerList />
                </div>
            </div>
        </DraftContext.Provider>
    )
}