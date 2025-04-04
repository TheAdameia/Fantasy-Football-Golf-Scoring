import { useMemo } from "react"
import { useAppContext } from "../../contexts/AppContext"


export const MatchupPlayerCard = ({ rp, slot, displayWeekPoints }) => {
    const { allScores } = useAppContext()

    const playerScore = useMemo(() => {
        return allScores.find(s => s.playerId == rp.playerId && s.seasonWeek == displayWeekPoints.week)
    }, [allScores, displayWeekPoints.week, rp.playerId])

   if (slot && rp) {
    return (
        <tr>
            <th>
                {rp.rosterPosition}
            </th>
            <td>
                {rp.player.playerFirstName} {rp.player.playerLastName}
            </td>
            <td>
                -
            </td>
            <td>
                -
            </td>
            {displayWeekPoints.display ? <td>{playerScore.points}</td>:<td>0</td>}
        </tr>
    )
   } else if (slot == false && rp) {
    return (
        <tr>
            {displayWeekPoints.display ? <td>{playerScore.points}</td>:<td>0</td>}
            <td>
                -
            </td>
            <td>
                -
            </td>
            <td>
                {rp.player.playerFullName}
            </td>
            <td>
                {rp.rosterPosition}
            </td>
        </tr>
    )
   } else {
    <div>
        loading...
    </div>
   }
}