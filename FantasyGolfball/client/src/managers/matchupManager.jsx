const _apiUrl = "/api/matchup"

export const GetMatchupsByLeague = (leagueId) => {
    return fetch(`${_apiUrl}/by-league?leagueId=${leagueId}`)
        .then((res) => res.json())
}