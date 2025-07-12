const _apiUrl = "/api/dataimport"


// removal of headers, json deliberate as this is a CSV send
export const ImportPlayerData = (seasonId, formData) => {
    return fetch(_apiUrl + `/players?seasonId=${seasonId}`, {
        method: "POST",
        body: formData
    })
}