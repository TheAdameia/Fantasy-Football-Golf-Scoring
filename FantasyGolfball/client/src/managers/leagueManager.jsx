const _apiUrl = "/api/league"

export const GetAllLeagues = () => {
    return fetch(_apiUrl)
        .then((res) => res.json())
}

export const PostLeague = (newLeague) => {
    return fetch(_apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json"},
        body: JSON.stringify(newLeague)
    })
}

export const GetLeaguesWithVacancies = () => {
    return fetch(_apiUrl + `/not-full-leagues`)
        .then((res) => res.json())
}