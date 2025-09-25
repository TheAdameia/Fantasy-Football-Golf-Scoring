import { useMemo, useContext } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { MatchupRevealContext } from "./MatchupRevealContext"
import "./matchups.css"


export const MatchupPlayerCard = ({ rp, slot, displayWeekPoints }) => {
    const { allScores } = useAppContext()
    const { revealedPositions } = useContext(MatchupRevealContext)

    
    const playerScore = useMemo(() => {
        if (!allScores) {
            return
        }
        return (
            allScores.find(
                s => s.playerId === rp.playerId && s.seasonWeek === displayWeekPoints.week
            ) || { points: 0, playerId: rp.playerId, seasonWeek: displayWeekPoints.week }
        )
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

   if (slot && rp && playerScore) {
    return (
        <tr className="player-table-row">
            <td className={revealedPositions?.includes(rp.rosterPosition) ? "fade-in-stats" : ""}>
                {revealedPositions?.includes(rp.rosterPosition) ?
                    [
                        playerScore.yardsPassing && `${playerScore.yardsPassing} passing yards`,
                        playerScore.touchdownsPassing && `${playerScore.touchdownsPassing} passing touchdowns`,
                        playerScore.interceptions && `${playerScore.interceptions} interceptions`,
                        playerScore.receptions && `${playerScore.receptions} receptions`,
                        playerScore.yardsReceiving && `${playerScore.yardsReceiving} receiving yards`,
                        playerScore.touchdownsReceiving && `${playerScore.touchdownsReceiving} receiving touchdowns`,
                        playerScore.yardsRushing && `${playerScore.yardsRushing} rushing yards`,
                        playerScore.touchdownsRushing && `${playerScore.touchdownsRushing} rushing touchdowns`,
                        playerScore.fumblesLost && `${playerScore.fumblesLost} fumbles lost`,
                        playerScore.twoExtraPoints && `${playerScore.twoExtraPoints} two extra points`,
                        playerScore.fieldGoalsMade && `${playerScore.fieldGoalsMade} field goals made`,
                        playerScore.extraPointMade && `${playerScore.extraPointMade} extra points made`,
                        playerScore.sacks && `${playerScore.sacks} sacks`,
                        playerScore.interceptionDefense && `${playerScore.interceptionDefense} interceptions`,
                        playerScore.defenseFumbleRecovery && `${playerScore.defenseFumbleRecovery} fumble recoveries`,
                        playerScore.safety && `${playerScore.safety} safety`,
                        playerScore.touchdownsDefense && `${playerScore.touchdownsDefense} defense touchdowns`,
                        playerScore.touchdownsReturn && `${playerScore.touchdownsReturn} return touchdowns`,
                        playerScore.blockedKicks && `${playerScore.blockedKicks} blocked kicks`,
                        playerScore.isDefense && `${playerScore.pointsAgainst} points against`
                    ]
                    .filter(Boolean)
                    .join(", ")
                : ""} 
            </td>
            <td>
                {rp.rosterPosition}
            </td>
            <td>
                {rp.player.playerFullName}
            </td>
            <td>
                {playerTeamFiltered.team.teamName}
            </td>
            <td>
                {playerStatusFiltered.status.statusType}
            </td>
            <td className={revealedPositions?.includes(rp.rosterPosition) ? "fade-in" : ""}>
                {revealedPositions?.includes(rp.rosterPosition) ? playerScore.points.toFixed(2) : 0}
            </td>
        </tr>
    )
   } else if (slot == false && rp && playerScore) {
    return (
        <tr className="player-table-row">
            <td className={revealedPositions?.includes(rp.rosterPosition) ? "fade-in" : ""}>
                {revealedPositions?.includes(rp.rosterPosition) ? playerScore.points.toFixed(2) : 0}
            </td>
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
            <td className={revealedPositions?.includes(rp.rosterPosition) ? "fade-in-stats" : ""}>
                {revealedPositions?.includes(rp.rosterPosition) ?
                    [
                        playerScore.yardsPassing && `${playerScore.yardsPassing} passing yards`,
                        playerScore.touchdownsPassing && `${playerScore.touchdownsPassing} passing touchdowns`,
                        playerScore.interceptions && `${playerScore.interceptions} interceptions`,
                        playerScore.receptions && `${playerScore.receptions} receptions`,
                        playerScore.yardsReceiving && `${playerScore.yardsReceiving} receiving yards`,
                        playerScore.touchdownsReceiving && `${playerScore.touchdownsReceiving} receiving touchdowns`,
                        playerScore.yardsRushing && `${playerScore.yardsRushing} rushing yards`,
                        playerScore.touchdownsRushing && `${playerScore.touchdownsRushing} rushing touchdowns`,
                        playerScore.fumblesLost && `${playerScore.fumblesLost} fumbles lost`,
                        playerScore.twoExtraPoints && `${playerScore.twoExtraPoints} two extra points`,
                        playerScore.fieldGoalsMade && `${playerScore.fieldGoalsMade} field goals made`,
                        playerScore.extraPointMade && `${playerScore.extraPointMade} extra points made`,
                        playerScore.sacks && `${playerScore.sacks} sacks`,
                        playerScore.interceptionDefense && `${playerScore.interceptionDefense} interceptions`,
                        playerScore.defenseFumbleRecovery && `${playerScore.defenseFumbleRecovery} fumble recoveries`,
                        playerScore.safety && `${playerScore.safety} safety`,
                        playerScore.touchdownsDefense && `${playerScore.touchdownsDefense} defense touchdowns`,
                        playerScore.touchdownsReturn && `${playerScore.touchdownsReturn} return touchdowns`,
                        playerScore.blockedKicks && `${playerScore.blockedKicks} blocked kicks`,
                        playerScore.isDefense && `${playerScore.pointsAgainst} points against`
                    ]
                    .filter(Boolean)
                    .join(", ")
                : ""} 
            </td>
        </tr>
    )
   } else {
    return (
        <div>
            loading...
        </div>
    )
   }
}