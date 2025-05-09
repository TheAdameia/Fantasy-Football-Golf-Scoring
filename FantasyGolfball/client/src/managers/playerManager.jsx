const _apiUrl = "/api/player"

export const GetAllPlayers = (leagueId) => {
    return fetch(_apiUrl + `/by-league?leagueId=${leagueId}`)
        .then((res) => res.json())
}