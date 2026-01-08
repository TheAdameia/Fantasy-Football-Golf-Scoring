
export const FormatStats = (playerScore) => {
  const stats = [
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
  ].filter(Boolean);

  return stats.length > 0 ? stats.join(", ") : "PENALTY";
}