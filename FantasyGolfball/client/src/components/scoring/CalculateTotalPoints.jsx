export const CalculateTotalPoints = (userId, allScores, selectedLeague) => {

    const leagueUser = selectedLeague.leagueUsers.filter(lu => lu.userProfileId == userId)
    console.log(leagueUser)
    const rosterPlayers = leagueUser[0].roster.rosterPlayers

    return rosterPlayers.reduce((total, rp) => {
        if (rp.rosterPosition != "bench" ) {
            const playerScore = allScores.find(s => s.playerId == rp.playerId && s.seasonWeek == selectedLeague.season.currentWeek)
        return total + (playerScore ? playerScore.points : 0)
        }
        return total
    }, 0)
}