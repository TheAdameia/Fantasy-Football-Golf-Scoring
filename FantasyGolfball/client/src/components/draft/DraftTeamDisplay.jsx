import { useAppContext } from "../../contexts/AppContext"


export const DraftTeamDisplay = () => {
    const { roster } = useAppContext()

   
    if (!roster || !roster.rosterPlayers || roster.rosterPlayers.length == 0) {
        return (
            <div>No players drafted yet</div>
        )
    }

    return (
        <div className="draft-selectedPlayers-container">
            {roster.rosterPlayers.map((rp) => {
                return (
                    <div key={rp.player.playerId} className="draft-selectedPlayers-playerContainer">
                        <div className="draft-selectedPlayers-position">{rp.player.position.positionShort}</div>
                        <div>{rp.player.playerFirstName} {rp.player.playerLastName}</div>
                    </div>
                )
            })}
        </div>
    )
}