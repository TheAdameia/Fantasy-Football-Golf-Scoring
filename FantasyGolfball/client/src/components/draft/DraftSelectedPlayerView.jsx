

export const DraftSelectedPlayerView = ({ selectedPlayer }) => {
    // drills in state value for selected player, if null displays an empty stat box.
    // if more granular stats are added to the data this should be remade to display those


    // handle drafting a player
    // handle enqueueing a player

    if (selectedPlayer == null) { //revise to use empty stat display after CSS implemented
        return (
            <div>blank</div>
        )
    }

    return (
        <div>
            <div>
                <div>{selectedPlayer.playerFirstName} {selectedPlayer.playerLastName}</div>
                <div>{selectedPlayer.position.positionShort}</div>
                <div>Team (NYI)</div>
                <div>Bye Week (NYI)</div>
            </div>
            <div>
                <div>Last season total</div>
                <div>Projected points</div>
                <button onClick={() => console.log("quack!")}>Enqueue Player</button>
                <button onClick={() => console.log("quackerooski!")}>Draft Player</button>
            </div>
        </div>
    )
}