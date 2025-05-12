const _apiUrl = "/api/historical"

export const GetHistoricalDraftState = (leagueId) => {
    return fetch(_apiUrl + `/HistoricalDraftState?leagueId=${leagueId}`)
        .then((res) => res.json())
}