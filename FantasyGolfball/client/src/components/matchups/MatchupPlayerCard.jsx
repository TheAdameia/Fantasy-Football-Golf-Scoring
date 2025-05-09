import { useMemo } from "react"
import { useAppContext } from "../../contexts/AppContext"


export const MatchupPlayerCard = ({ rp, slot, displayWeekPoints }) => {
    const { allScores, selectedLeague } = useAppContext()

    const playerScore = useMemo(() => {
        return allScores.find(s => s.playerId == rp.playerId && s.seasonWeek == displayWeekPoints.week)
    }, [allScores, displayWeekPoints.week, rp.playerId])

    const playerTeamFiltered = useMemo(() => {
        return rp.player.playerTeams
            .filter(pt => pt.teamStartWeek <= displayWeekPoints.week)
            .sort((a, b) => b.teamStartWeek - a.teamStartWeek)[0] || null
    }, [displayWeekPoints.week, rp.player.playerTeams])

    const playerStatusFiltered = useMemo(() => {
        return rp.player.playerStatuses
            .filter(ps => ps.statusStartWeek <= displayWeekPoints.week)
            .sort((a, b) => b.statusStartWeek - a.statusStartWeek)[0] || null
    }, [displayWeekPoints.week, rp.player.playerStatuses])

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
                {playerTeamFiltered.team.teamName}
            </td>
            <td>
                {playerStatusFiltered.status.statusType}
            </td>
            {displayWeekPoints.display && selectedLeague.currentWeek ? <td>{playerScore.points}</td>:<td>0</td>}
        </tr>
    )
   } else if (slot == false && rp) {
    return (
        <tr>
            {displayWeekPoints.display && selectedLeague.currentWeek ? <td>{playerScore.points}</td>:<td>0</td>}
            <td>
                {playerStatusFiltered.status.statusType}
            </td>
            <td>
                {playerTeamFiltered.team.teamName}
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