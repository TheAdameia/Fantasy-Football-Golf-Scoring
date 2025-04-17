const _apiUrl = "/api/matchup"

export const GetMatchupsByLeagueAndUser = (leagueId, userId) => {
    return fetch(`${_apiUrl}/by-league-and-user?leagueId=${leagueId}&userId=${userId}`)
        .then((res) => res.json())
}