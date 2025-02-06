import { useAppContext } from "../../contexts/AppContext"


export const DraftTeamDisplay = () => {
    const { roster } = useAppContext()

   
    if (!roster || !roster.rosterPlayers || roster.rosterPlayers.length == 0) {
        return (
            <div>No players drafted yet</div>
        )
    }

    return (
        <div>
            {roster.rosterPlayers.map((rp) => {
                return (
                    <div key={rp.player.playerId}>
                        <div>{rp.player.position.positionShort}</div>
                        <div>{rp.player.playerFirstName} {rp.player.playerLastName}</div>
                    </div>
                )
            })}
        </div>
    )
}