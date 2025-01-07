

export const DraftPlayerQueue = ({ queuedPlayers, deQueuePlayer }) => {

    // I would really like this to be a draggable list but it might be wise to leave that for later

    // handle dequeueing a player? It would have to be a DraftPage function probably

    if (queuedPlayers == []) {
        return (
            <div>empty layout</div>
        )
    }
    // does this need to be a react element for this to work? Apparently not
    return (
        <div className="queue-container">
            {queuedPlayers.map((player) => {
                return (
                    <div key={player.playerId} className="queue-player">
                        <div className="queue-player-name">{player.playerFirstName} {player.playerLastName}</div>
                        <div className="queue-player-role">{player.position.positionShort}</div>
                        <div className="queue-player-role">Team</div>
                    </div>
                )
            })}
        </div>
    )
}