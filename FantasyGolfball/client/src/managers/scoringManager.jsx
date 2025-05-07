const _apiUrl = "/api/scoring"

export const GetByPlayer = (playerid) => {
    return fetch(_apiUrl + `/by-player?playerId=${playerid}`)
        .then((res) => res.json())
}

export const GetAllScores = (seasonId) => {
    return fetch(_apiUrl + `/by-season?seasonId=${seasonId}`)
    .then((res) => res.json())
}