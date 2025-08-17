const _apiUrl = "/api/dataimport"


// removal of headers, json deliberate as this is a CSV send
export const ImportPlayerData = (seasonId, formData) => {
    return fetch(_apiUrl + `/players?seasonId=${seasonId}`, {
        method: "POST",
        body: formData
    })
}

export const ImportScoringData = (seasonId, formData) => {
    return fetch(_apiUrl + `/scoring?seasonId=${seasonId}`, {
        method: "POST",
        body: formData
    })
}

export const ImportDefenseData = (seasonId, formData) => {
    return fetch(_apiUrl + `/defense?seasonId=${seasonId}`, {
        method: "POST",
        body: formData
    })
}