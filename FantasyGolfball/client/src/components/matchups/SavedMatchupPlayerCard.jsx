export const SavedMatchupPlayerCard = ({ musp, slot, week }) => {

    if (slot) {
        return (
            <tr>
                <td>
                    {[
                        musp.scoring.yardsPassing && `${musp.scoring.yardsPassing} passing yards`,
                        musp.scoring.touchdownsPassing && `${musp.scoring.touchdownsPassing} passing touchdowns`,
                        musp.scoring.interceptions && `${musp.scoring.interceptions} interceptions`,
                        musp.scoring.receptions && `${musp.scoring.receptions} receptions`,
                        musp.scoring.yardsReceiving && `${musp.scoring.yardsReceiving} receiving yards`,
                        musp.scoring.touchdownsReceiving && `${musp.scoring.touchdownsReceiving} receiving touchdowns`,
                        musp.scoring.yardsRushing && `${musp.scoring.yardsRushing} rushing yards`,
                        musp.scoring.touchdownsRushing && `${musp.scoring.touchdownsRushing} rushing touchdowns`,
                        musp.scoring.fumblesLost && `${musp.scoring.fumblesLost} fumbles lost`,
                        musp.scoring.twoExtraPoints && `${musp.scoring.twoExtraPoints} two extra points`,
                        musp.scoring.fieldGoalsMade && `${musp.scoring.fieldGoalsMade} field goals made`,
                        musp.scoring.extraPointsMade && `${musp.scoring.extraPointsMade} extra points made`,
                        musp.scoring.sacks && `${musp.scoring.sacks} sacks`,
                        musp.scoring.interceptionDefense && `${musp.scoring.interceptionDefense} interceptions`,
                        musp.scoring.defenseFumbleRecovery && `${musp.scoring.defenseFumbleRecovery} fumble recoveries`,
                        musp.scoring.safety && `${musp.scoring.safety} safety`,
                        musp.scoring.touchdownsDefense && `${musp.scoring.touchdownsDefense} defense touchdowns`,
                        musp.scoring.touchdownsReturn && `${musp.scoring.touchdownsReturn} return touchdowns`,
                        musp.scoring.blockedKicks && `${musp.scoring.blockedKicks} blocked kicks`,
                        musp.scoring.isDefense && `${musp.scoring.pointsAgainst} points against`
                    ]
                    .filter(Boolean)
                    .join(", ")} 
                </td> {/* this array display goes crazy, got to use this again */}
                <td>
                    {musp.rosterPlayerPosition}
                </td>
                <td>
                    {musp.player.playerFullName}
                </td>
                <td>
                    {musp.player.playerTeams[0].team.teamName}
                </td>
                <td>
                    {musp.player.playerStatuses[0].status.statusType}
                </td>
                <td>
                    {musp.scoring.points.toFixed(2)}
                </td>
            </tr>
        )
       } else if (slot == false) {
        return (
            <tr>
                <td>
                    {musp.scoring.points.toFixed(2)}
                </td>
                <td>
                    {musp.player.playerStatuses[0].status.statusType}
                </td>
                <td>
                    {musp.player.playerTeams[0].team.teamName}
                </td>
                <td>
                    {musp.player.playerFullName}
                </td>
                <td>
                    {musp.rosterPlayerPosition}
                </td>
                <td>
                    {[
                        musp.scoring.yardsPassing && `${musp.scoring.yardsPassing} passing yards`,
                        musp.scoring.touchdownsPassing && `${musp.scoring.touchdownsPassing} passing touchdowns`,
                        musp.scoring.interceptions && `${musp.scoring.interceptions} interceptions`,
                        musp.scoring.receptions && `${musp.scoring.receptions} receptions`,
                        musp.scoring.yardsReceiving && `${musp.scoring.yardsReceiving} receiving yards`,
                        musp.scoring.touchdownsReceiving && `${musp.scoring.touchdownsReceiving} receiving touchdowns`,
                        musp.scoring.yardsRushing && `${musp.scoring.yardsRushing} rushing yards`,
                        musp.scoring.touchdownsRushing && `${musp.scoring.touchdownsRushing} rushing touchdowns`,
                        musp.scoring.fumblesLost && `${musp.scoring.fumblesLost} fumbles lost`,
                        musp.scoring.twoExtraPoints && `${musp.scoring.twoExtraPoints} two extra points`,
                        musp.scoring.fieldGoalsMade && `${musp.scoring.fieldGoalsMade} field goals made`,
                        musp.scoring.extraPointsMade && `${musp.scoring.extraPointsMade} extra points made`,
                        musp.scoring.sacks && `${musp.scoring.sacks} sacks`,
                        musp.scoring.interceptionDefense && `${musp.scoring.interceptionDefense} interceptions`,
                        musp.scoring.defenseFumbleRecovery && `${musp.scoring.defenseFumbleRecovery} fumble recoveries`,
                        musp.scoring.safety && `${musp.scoring.safety} safety`,
                        musp.scoring.touchdownsDefense && `${musp.scoring.touchdownsDefense} defense touchdowns`,
                        musp.scoring.touchdownsReturn && `${musp.scoring.touchdownsReturn} return touchdowns`,
                        musp.scoring.blockedKicks && `${musp.scoring.blockedKicks} blocked kicks`,
                        musp.scoring.isDefense && `${musp.scoring.pointsAgainst} points against`
                    ]
                    .filter(Boolean)
                    .join(", ")} 
                </td>
            </tr>
        )
       } else {
        <div>
            loading...
        </div>
       }
}