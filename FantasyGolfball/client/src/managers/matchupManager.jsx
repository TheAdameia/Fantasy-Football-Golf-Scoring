const _apiUrl = "/api/matchup"

export const GetMatchupsByLeagueAndUser = (leagueId, userId) => {
    return fetch(`${_apiUrl}?leagueId=${leagueId}&userId=${userId}`)
        .then((res) => res.json())
}