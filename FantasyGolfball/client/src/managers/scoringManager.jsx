const _apiUrl = "/api/scoring"

export const GetByWeekAndPlayers = (weekId, playerIds) => {
    return fetch(_apiUrl + `/by-week-and-players?weekId=${weekId}&playerIds=${playerIds}`)
        .then((res) => res.json())
}