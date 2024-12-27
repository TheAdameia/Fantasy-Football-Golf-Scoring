import "./DraftLayout.css"

export const DraftSelectedPlayerView = ({ selectedPlayer, setSelectedPlayer }) => {
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
        <div className="selected-player-view-grid">
            <div className="top-row">
                <div>{selectedPlayer.playerFirstName} {selectedPlayer.playerLastName}</div>
                <button onClick={() => console.log("quack!")} className="button-yellow">Enqueue Player</button>
                <button onClick={() => console.log("quackerooski!")} className="button-green">Draft Player</button>
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