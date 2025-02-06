const _apiUrl = "/api/rosterplayer"

export const AddRosterPlayer = (rosterPlayer) => {
    return fetch(_apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json"},
        body: JSON.stringify(rosterPlayer)
    })
}

export const DeleteRosterPlayer = (id) => {
    return fetch(`${_apiUrl}/${id}`, {
        method: "DELETE",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(id)
    })
}