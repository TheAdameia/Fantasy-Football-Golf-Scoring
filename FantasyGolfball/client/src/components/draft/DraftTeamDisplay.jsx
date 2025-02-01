import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"


export const DraftTeamDisplay = () => {
    const { roster } = useAppContext()
    const [rplayers, SetRPlayers] = useState()

    useEffect(() => {
        if (!roster) {
            return
        }
        if (roster.rosterPlayers) {
            SetRPlayers(roster.rosterPlayers)
        }
    }, [roster])

    if (!rplayers) {
        return (
            <div>No players drafted yet</div>
        )
    }

    return (
        <div>
            {rplayers.map((rp) => {
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