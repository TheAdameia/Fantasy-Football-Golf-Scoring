const _apiUrl = "/api/season"

export const PostNewSeason = (seasonYear, seasonWeeks) => {
    return fetch(`${_apiUrl}/post-season?seasonYear=${seasonYear}&seasonWeeks=${seasonWeeks}`, {
        method: "POST"
    })
}