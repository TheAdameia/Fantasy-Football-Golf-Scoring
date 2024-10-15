const _apiUrl = "/api/player"

export const GetAllPlayers = () => {
    return fetch(_apiUrl)
        .then((res) => res.json())
}