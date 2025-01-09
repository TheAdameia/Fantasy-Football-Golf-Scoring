import { createContext, useEffect, useState } from "react"
import { DraftPlayerList } from "./DraftPlayerList"
import { HubConnectionBuilder } from "@microsoft/signalr"
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
    const [draftState, setDraftState] = useState()
    const [currentTurn, setCurrentTurn] = useState(null)
    const [selectedPlayer, setSelectedPlayer] = useState(null)
    const [queuedPlayers, setQueuedPlayers] = useState([])
    const leagueId = 1 // just always assume it's 1 for testing, fix it later
    

    // handle dequeueing a player
    const deQueuePlayer = (removePlayer) => {
        let listCopy = [...queuedPlayers]
        listCopy = listCopy.filter(player => player.playerId !== removePlayer.playerId)
        setQueuedPlayers(listCopy)
    }

    useEffect(() => {
        const connect = async () => {
            const newConnection = new HubConnectionBuilder()
                .withUrl("https://localhost:5001/draftHub") // Backend URL
                .withAutomaticReconnect()
                .build();
    
            newConnection.on("DraftStateUpdated", (updatedDraftState) => {
                console.log("Draft State Updated:", updatedDraftState);
                setDraftState(updatedDraftState);
            });
    
            newConnection.on("TurnUpdated", (userId) => {
                console.log("User turn:", userId);
                setCurrentTurn(userId);
            });
    
            newConnection.on("Error", (error) => {
                console.error("Error from SignalR Hub:", error);
            });
    
            try {
                await newConnection.start();
                console.log("Connected to draft hub");
    
                const leagueId = 1; // Replace with dynamic value if needed
                await newConnection.invoke("JoinDraft", leagueId)
                    .catch(error => {
                        console.error("Error during JoinDraft invocation:", error);
                        alert("Error while joining the draft.");
                    });
    
                setConnection(newConnection);
            } catch (error) {
                console.error("Connection failed:", error);
                alert("Connection failed: " + error.message);
            }
        };
    
        connect();
    
        return () => {
            if (connection) {
                connection.stop().catch(error => console.error("Error stopping connection:", error));
            }
        };
    }, [connection]);
    
    


    return (
        <DraftContext.Provider value={{ draftState, currentTurn, connection}}>
            <div className="draft-container">
                <div className="left-side">
                    <DraftTimer />
                    {/* <DraftAutoQueue /> */}
                    {/* <DraftUserOrder /> */}
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