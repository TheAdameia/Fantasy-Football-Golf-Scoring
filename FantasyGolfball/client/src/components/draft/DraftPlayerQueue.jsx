

export const DraftPlayerQueue = ({ queuedPlayers }) => {

    // I would really like this to be a draggable list but it might be wise to leave that for later

    // handle dequeueing a player? It would have to be a DraftPage function probably

    if (queuedPlayers == []) {
        return (
            <div>empty layout</div>
        )
    }
    // does this need to be a react element for this to work?
    return (
        <div>
            {queuedPlayers.map((player) => {
                return (
                    <div key={player.playerId}>{player.playerFirstName} {player.playerLastName}</div>
                )
            })}
        </div>
    )
}