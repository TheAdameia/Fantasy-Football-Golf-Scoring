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
import { DraftTeamDisplay } from "./DraftTeamDisplay"
import { useAppContext } from "../../contexts/AppContext"

export const DraftContext = createContext()

export const DraftPage = () => {
    const [connection, setConnection] = useState(null)
    const [draftState, setDraftState] = useState()
    const [currentTurn, setCurrentTurn] = useState(null)
    const [selectedPlayer, setSelectedPlayer] = useState(null)
    const [queuedPlayers, setQueuedPlayers] = useState([])
    const [leagueId, setLeagueId] = useState(0)
    const { selectedLeague } = useAppContext()

    // handle dequeueing a player
    const deQueuePlayer = (removePlayer) => {
        let listCopy = [...queuedPlayers]
        listCopy = listCopy.filter(player => player.playerId !== removePlayer.playerId)
        setQueuedPlayers(listCopy)
    }

    useEffect(() => {
        if (selectedLeague != undefined) {
            setLeagueId(selectedLeague.leagueId)
        }
        
    }, [selectedLeague])

    useEffect(() => {
        if (leagueId == 0) {
            return
        }
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
                // stop connection on unmount
                connection.stop().catch(error => console.error("Error stopping connection:", error));
            }
        };
    }, [leagueId]); // only runs once on purpose, ignore the siren song of the "missing dependency"
    
    


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
                    <DraftTeamDisplay />
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