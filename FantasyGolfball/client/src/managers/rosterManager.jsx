const _apiUrl = "/api/roster"

export const GetByUserAndLeague = (userId, leagueId) => {
    return fetch(_apiUrl + `?userId=${userId}&leagueId=${leagueId}`)
        .then((res) => res.json())
}