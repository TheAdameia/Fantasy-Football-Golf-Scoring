const _apiUrl = "/api/trade"

export const PostTrade = (NewTrade) => {
    return fetch(_apiUrl, {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(NewTrade)
    })
}

export const GetTradesByLeagueAndUser = (rosterId, leagueId) => {
    return fetch(_apiUrl + `?rosterId=${rosterId}&leagueId=${leagueId}`)
        .then((res) => res.json())
}