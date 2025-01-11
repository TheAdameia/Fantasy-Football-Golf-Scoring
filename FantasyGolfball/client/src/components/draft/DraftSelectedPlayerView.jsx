import { useContext } from "react";
import "./DraftLayout.css"
import { useAppContext } from "../../contexts/AppContext";
import { DraftContext } from "./DraftPage";

export const DraftSelectedPlayerView = ({ selectedPlayer, setSelectedPlayer, setQueuedPlayers, queuedPlayers }) => {
    const { draftState, connection, currentTurn } = useContext(DraftContext)
    const { loggedInUser} = useAppContext()
    // drills in state value for selected player, if null displays an empty stat box.
    // if more granular stats are added to the data this should be remade to display those


    // handle drafting a player
    const handleDraftPlayer = async (playerId) => {
        console.log(loggedInUser.id)
        console.log(currentTurn)
        if (connection && currentTurn === loggedInUser.id) {
            try {
                const leagueId = 1; // Replace with dynamic leagueId if needed
                await connection.invoke("SelectPlayer", leagueId, loggedInUser.userId, playerId);
            } catch (error) {
                console.error("Error selecting player:", error);
            }
        } else {
            console.warn("It's not your turn!");
        }
    };
    

    const handleAddPlayerQueue = (addedPlayer) => {
        // Ensures queuedPlayers is an array and copies
        let listCopy = Array.isArray(queuedPlayers) ? [...queuedPlayers] : []
        
        // Exits if player is already queued
        if (listCopy.some(player => player.playerId === addedPlayer.playerId)) {
            return
        }
    
        listCopy.push(addedPlayer)
        setQueuedPlayers(listCopy)
    };
    

    if (selectedPlayer == null) {
        return (
            <div className="selected-player-view-grid">
                <div className="top-row">
                    <div>None Selected</div>
                </div>
                <div className="bottom-row">
                    <div>Position</div>
                    <div>Team (NYI)</div>
                    <div>Bye Week (NYI)</div>
                    <div>Last season total</div>
                    <div>Projected points</div>
                </div>
            </div>
        )
    }

    return (
        <div className="selected-player-view-grid">
            <div className="top-row">
                <div>{selectedPlayer.playerFirstName} {selectedPlayer.playerLastName}</div>
                <button onClick={() => handleAddPlayerQueue(selectedPlayer)} className="button-yellow">Enqueue Player</button>
                <button onClick={() => handleDraftPlayer(selectedPlayer)} className="button-green">Draft Player</button>
                {selectedPlayer ? <button onClick={() => setSelectedPlayer(null)}>Clear View</button> : <div></div>}
            </div>
            <div className="bottom-row">
                <div>{selectedPlayer.position.positionShort}</div>
                <div>Team (NYI)</div>
                <div>Bye Week (NYI)</div>
                <div>Last season total</div>
                <div>Projected points</div>
            </div>
        </div>
    )
}