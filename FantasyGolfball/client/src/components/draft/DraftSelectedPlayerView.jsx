import { useContext } from "react";
import "./DraftLayout.css"
import { useAppContext } from "../../contexts/AppContext";
import { DraftContext } from "./DraftPage";

export const DraftSelectedPlayerView = ({ selectedPlayer, setSelectedPlayer, setQueuedPlayers, queuedPlayers }) => {
    const { connection, currentTurn } = useContext(DraftContext)
    const { loggedInUser, selectedLeague, getAndSetRoster } = useAppContext()
    // if more granular stats are added to the data this should be remade to display those


    // handle drafting a player
    const handleDraftPlayer = async (playerId) => {
        if (selectedLeague.isDraftComplete) {
            window.alert("The draft has been completed!")
        }

        if (connection && currentTurn === loggedInUser.id && selectedLeague.isDraftComplete == false) {
            try {
                await connection.invoke("SelectPlayer", selectedLeague.leagueId, loggedInUser.id, playerId, selectedLeague.maxRosterSize)
                setSelectedPlayer(null)
                getAndSetRoster()
            } catch (error) {
                console.error("Error selecting player:", error)
            }
        } else {
            console.warn("It's not your turn!")
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
                <button onClick={() => handleDraftPlayer(selectedPlayer.playerId)} className="button-green">Draft Player</button>
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