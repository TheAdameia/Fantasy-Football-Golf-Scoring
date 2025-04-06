

export const DraftPlayerQueue = ({ queuedPlayers, deQueuePlayer }) => {

    // I would really like this to be a draggable list but it might be wise to leave that for later

    if (queuedPlayers == []) {
        return (
            <div>empty layout</div>
        )
    }
    
    return (
        <ol className="queue-container">
            {queuedPlayers.map((player) => {
                return (
                    <li key={player.playerId} className="queue-player">
                        <div className="queue-player-role">{player.position.positionShort}</div>
                        <div className="queue-player-name">{player.playerFullName}</div>
                        <div className="queue-player-role">Team</div>
                        <button className="queue-dequeue" onClick={() => deQueuePlayer(player)}>X</button>
                    </li>
                )
            })}
        </ol>
    )
}