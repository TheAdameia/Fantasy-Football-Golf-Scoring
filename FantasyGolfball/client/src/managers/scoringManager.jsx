const _apiUrl = "/api/scoring"

export const GetByPlayer = (playerid) => {
    return fetch(_apiUrl + `/by-player?playerId=${playerid}`)
        .then((res) => res.json())
}

export const GetAllScores = () => {
    return fetch(_apiUrl)
    .then((res) => res.json())
}