import "./DraftLayout.css"

export const DraftAutoQueue = ({ queuedPlayers }) => {


    if (queuedPlayers[0]) {
        // logic that uses the autodraft list if queuedplayers doesn't have anything
        // now that I think about it, the queue really needs to be a server side thing
        let player = queuedPlayers[0]

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

    return (
        <div></div>
    )

    
}