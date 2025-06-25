export const getRevealTimes = (selectedLeague) => {
    if (!selectedLeague || selectedLeague.currentWeek == null) {
        return null
    }

    const advancement = selectedLeague.advancement
    const seasonStart = new Date(selectedLeague.seasonStartDate)
    const week = selectedLeague.currentWeek

    const revealSequence = ["DEF", "K", "FLEX", "TE1", "RB2", "WR2", "RB1", "WR1", "QB1"]

    let nextWeekTime
    switch (advancement) {
        case 0:
            nextWeekTime = new Date(seasonStart.getTime() + 7 * 24 * 60 * 60 * 1000 * week)
            break
        case 1:
            nextWeekTime = new Date(seasonStart.getTime() + 24 * 60 * 60 * 1000 * week)
            break
        case 2:
            nextWeekTime = new Date(seasonStart.getTime() + 60 * 60 * 1000 * week)
            break
        default:
            return null
    }

    let totalRevealDuration
    switch (advancement) {
        case 0:
            totalRevealDuration = 8 * 60 * 60 * 1000 // 8 hours
            break
        case 1:
            totalRevealDuration = 60 * 60 * 1000 // 1 hour
            break
        case 2:
            totalRevealDuration = 10 * 60 * 1000 // 10 minutes
            break
        default:
            totalRevealDuration = 30 * 60 * 1000
            break
    }

    const revealStartTime = new Date(nextWeekTime.getTime() - totalRevealDuration)
    const revealInterval = totalRevealDuration / revealSequence.length

    return {
        revealStartTime,
        nextWeekTime,
        totalRevealDuration,
        revealInterval,
        revealSequence
    }
}
