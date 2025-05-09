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

export const JoinLeague = async (leagueId, userId, passwordInput) => {
    const response = await fetch(_apiUrl + `/join-league?leagueId=${leagueId}&userId=${userId}&passwordInput=${passwordInput}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json"}
    })

    if (!response.ok) {
        const errorText = await response.text()
        throw new Error(errorText || "Failed to join League.")
    }
    
    return
}

// export const GetLeaguesByUser = (userId) => {
//     return fetch(_apiUrl + `/by-user?userId=${userId}`)
//         .then((res) => res.json())
// } // unused but has an equivalent in appcontext that wouldn't be good for exporting