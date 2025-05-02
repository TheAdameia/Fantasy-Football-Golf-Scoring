import { useMemo } from "react"
import { useAppContext } from "../../contexts/AppContext"


export const MatchupPlayerCard = ({ rp, slot, displayWeekPoints }) => {
    const { allScores, selectedLeague } = useAppContext()

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
                {rp.player.playerFullName}
            </td>
            <td>
                {rp.player.playerTeams[0].team.teamName}
            </td>
            <td>
                
            </td>
            {displayWeekPoints.display && selectedLeague.currentWeek ? <td>{playerScore.points}</td>:<td>0</td>}
        </tr>
    )
   } else if (slot == false && rp) {
    return (
        <tr>
            {displayWeekPoints.display && selectedLeague.currentWeek ? <td>{playerScore.points}</td>:<td>0</td>}
            <td>
                -
            </td>
            <td>
                {rp.player.playerTeams[0].team.teamName}
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