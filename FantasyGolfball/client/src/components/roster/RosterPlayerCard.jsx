import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { DeleteRosterPlayer } from "../../managers/rosterPlayerManager"
import { RosterPositionDropdown } from "./RosterPositionDropdown"


export const RosterPlayerCard = ({ rp }) => {
    const  { getAndSetRoster, allScores, selectedLeague, getAndSetPlayers } = useAppContext()
    const [weekScore, setWeekScore] = useState()
    const [seasonTotal, setSeasonTotal] = useState() // might want to fit this in later


    const HandleDropPlayer = (rosterPlayerId) => {
        DeleteRosterPlayer(rosterPlayerId).then(() => {
            getAndSetRoster(),
            getAndSetPlayers()
        })
    }

    const ConfirmDrop = (rosterPlayerId) => {
        const confirmed = window.confirm(`Are you sure you want to drop ${rp.player.playerFullName}?`)
        if (confirmed) {
            HandleDropPlayer(rosterPlayerId)
        } else {
            return
        }
    }

    useEffect(() => {
            if (selectedLeague.season.currentWeek == null) {
                setWeekScore(0)
            }
            if (allScores) {
                const playerScores = allScores.filter(s => s.playerId == rp.player.playerId)
                let thisWeekScore = playerScores.find(s => s.seasonWeek == selectedLeague.season.currentWeek)
                setWeekScore(thisWeekScore)
    
                let total = playerScores.reduce((sum, s) => sum + s.points, 0)
                let fixedTotal = total.toFixed(1)
                setSeasonTotal(fixedTotal)
            }
        }, [allScores, rp, selectedLeague])
    

    return (
        <tr>
            <th scope="row">
                <RosterPositionDropdown
                    rp={rp}>

                </RosterPositionDropdown>
            </th>
            <td>
                {rp.rosterPosition}
            </td>
            <td>
                {rp.player.status.statusType}
            </td>
            <td>
                {rp.player.position.positionShort}
            </td>
            <td>
                -
            </td>
            <td>
                {rp.player.playerFullName}
            </td>
            <td>
                Week 
            </td>
            <td>
                {weekScore ? weekScore.points : "-"}
            </td>
            <td>
                <button onClick={() => ConfirmDrop(rp.rosterPlayerId)}>-</button>
            </td>
        </tr>
    )
}