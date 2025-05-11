const _apiUrl = "/api/historical"

export const GetHistoricalDraftState = (leagueId) => {
    return fetch(_apiUrl + `historical-DraftState?leagueId=${leagueId}`)
        .then((res) => res.json())
}