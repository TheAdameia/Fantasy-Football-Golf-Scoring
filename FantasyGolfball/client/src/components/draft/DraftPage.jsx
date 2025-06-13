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
import Confetti from "react-confetti"
import { useNavigate } from "react-router-dom"

export const DraftContext = createContext()

export const DraftPage = () => {
    const [connection, setConnection] = useState(null)
    const [draftState, setDraftState] = useState()
    const [currentTurn, setCurrentTurn] = useState(null)
    const [selectedPlayer, setSelectedPlayer] = useState(null)
    const [queuedPlayers, setQueuedPlayers] = useState([])
    const [leagueId, setLeagueId] = useState(0)
    const [draftGraphic, setDraftGraphic] = useState(false)
    const { selectedLeague } = useAppContext()
    const navigate = useNavigate()
    const [confirmCheck, setConfirmCheck] = useState(true)

    // handle dequeueing a player
    const deQueuePlayer = (removePlayer) => {
        let listCopy = [...queuedPlayers]
        listCopy = listCopy.filter(player => player.playerId !== removePlayer.playerId)
        setQueuedPlayers(listCopy)
    }

    // handles differences between test environment and deployment environment
    const getSignalRUrl = () => {
        if (window.location.hostname === "localhost") {
            return "https://localhost:5001/draftHub";
        }
        return "https://fantasygolfball.org/draftHub";
    };
    

    useEffect(() => {
        if (selectedLeague != undefined) {
            setLeagueId(selectedLeague.leagueId)
        }
        
    }, [selectedLeague])

    useEffect(() => {
        if (leagueId == 0 || selectedLeague.isDraftComplete) {
            return
        }

        const draftStart = new Date(selectedLeague?.draftStartTime);
        const now = new Date();
        if (draftStart > now) {
            alert("It's too early to start the draft!");
            navigate("/");
            return;
        }
        
        const connect = async () => {
            
            const newConnection = new HubConnectionBuilder()
                .withUrl(getSignalRUrl()) // Backend URL
                .withAutomaticReconnect()
                .build();
    
            newConnection.on("DraftStateUpdated", (updatedDraftState) => {
                // console.log("Draft State Updated:", updatedDraftState);
                setDraftState(updatedDraftState);
            });
    
            newConnection.on("TurnUpdated", (userId) => {
                console.log("User turn:", userId);
                setCurrentTurn(userId);
            });

            newConnection.on("DraftCompleted", () => {
                console.log("Draft completed!")
                setDraftGraphic(true)

            })
    
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
    
    
    useEffect(() => {
        if (selectedLeague?.isDraftComplete) {
            setDraftGraphic(true)
        }
    }, [selectedLeague]) // already "listening" for this from SignalR, but that won't catch if you're revisiting a draft page.

    return (
        <DraftContext.Provider value={{ draftState, currentTurn, connection}}>
            {draftGraphic && (
                <div className="draft-complete-overlay">
                   <h2>Draft Complete!</h2>
                   <p>The draft is finished. You can now view your roster, matchups, and get ready for the season.</p>
                    <button onClick={() => setDraftGraphic(false)}>Close</button>
                    <button onClick={() => navigate("/roster")}>View Roster</button>
                    <Confetti />
                </div>
            )}
            <div className="draft-container">
                <div className="left-side">
                    <DraftTimer />
                    {/* <DraftAutoQueue /> */}
                    <DraftUserOrder />
                </div>
                <div className="right-side">
                    <DraftPlayerQueue 
                        queuedPlayers={queuedPlayers}
                        deQueuePlayer={deQueuePlayer}
                    />
                    <DraftTeamDisplay 
                        confirmCheck={confirmCheck}
                        setConfirmCheck={setConfirmCheck}
                    />
                    <Chat />
                </div>
                <div className="center-box">
                    <DraftSelectedPlayerView 
                        selectedPlayer={selectedPlayer} 
                        setSelectedPlayer={setSelectedPlayer}
                        queuedPlayers={queuedPlayers}
                        setQueuedPlayers={setQueuedPlayers}
                        leagueId={leagueId}
                        
                    />
                    <DraftPlayerList 
                        setSelectedPlayer={setSelectedPlayer}
                        confirmCheck={confirmCheck}
                    />
                </div>
            </div>
        </DraftContext.Provider>
    )
}