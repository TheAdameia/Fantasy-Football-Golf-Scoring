const _apiUrl = "/api/scoring"

export const GetByWeekAndPlayers = (weekId, playerIds) => {
    return fetch(_apiUrl + `/by-week-and-players?weekId=${weekId}&playerIds=${playerIds}`)
        .then((res) => res.json())
}

export const GetByPlayer = (playerid) => {
    return fetch(_apiUrl + `/by-player?playerId=${playerid}`)
        .then((res) => res.json())
}