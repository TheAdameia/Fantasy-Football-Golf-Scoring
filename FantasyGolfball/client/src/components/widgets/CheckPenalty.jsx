

export const CheckPenalty = (player, score) => {
    let playerPenalty = 0

    // a spelling error generated much annoyance when testing the switch block

    switch (player.position.positionId) {
        case 1: // QB
            if (score.yardsPassing == 0 &&
                score.yardsRushing == 0 &&
                score.attemptsPassing == 0 &&
                score.attemptsRushing == 0 &&
                score.fumbleLost == 0 &&
                score.interceptions == 0) {
                    playerPenalty += 15
                }
            break
        case 2: // WR
        case 3: // RB
        case 4: // TE
            if (score.yardsReceiving == 0 &&
                score.yardsRushing == 0 &&
                score.targets == 0 &&
                score.attemptsRushing == 0 &&
                score.receptions == 0 &&
                score.fumbleLost == 0) {
                    playerPenalty += 10
                }
            break
        case 5: // K
            if (score.fieldGoalAttempts == 0 &&
                score.fieldGoalsMade == 0 &&
                score.extraPointAttempts == 0 &&
                score.extraPointMade == 0) {
                    playerPenalty += 10
            }
            break
        case 6: // DEF
            break
        default:
            console.log("default player case")
            break
    }

    return playerPenalty
}