import { useContext } from "react"
import "./DraftLayout.css"
import { DraftContext } from "./DraftPage"

export const DraftAutoQueue = () => {
    const { draftState } = useContext(DraftContext)

    let player = draftState.nextAutoDraftPlayer
    return (
        <div>
            <div>Next Autodrafted Player</div>
            <div className="queue-container">
                
                <div key={player.playerId} className="queue-player">
                    <div className="queue-player-name">{player.playerFirstName} {player.playerLastName}</div>
                    <div className="queue-player-role">{player.position.positionShort}</div>
                    <div className="queue-player-role">Team</div>
                </div>
            </div>
        </div>
    )
    

   

    
}