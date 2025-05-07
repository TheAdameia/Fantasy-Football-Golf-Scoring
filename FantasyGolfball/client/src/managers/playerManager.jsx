const _apiUrl = "/api/player"

export const GetAllPlayers = (seasonId) => {
    return fetch(_apiUrl + `/by-season?seasonId=${seasonId}`)
        .then((res) => res.json())
}