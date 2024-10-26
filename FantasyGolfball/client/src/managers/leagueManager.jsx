const _apiUrl = "/api/league"

export const GetAllLeagues = () => {
    return fetch(_apiUrl)
        .then((res) => res.json())
}