const _apiUrl = "/api/rosterplayer"

export const AddRosterPlayer = (rosterPlayer) => {
    return fetch(_apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json"},
        body: JSON.stringify(rosterPlayer)
    })
}

export const DeleteRosterPlayer = (id, leagueId) => {
    return fetch(`${_apiUrl}/delete?rosterPlayerId=${id}&leagueId=${leagueId}`, {
        method: "DELETE",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(id)
    })
}

export const ChangeRosterPlayerPosition = (rosterPlayerId, position, leagueId) => {
    return fetch(`${_apiUrl}/roster-position?rosterPlayerId=${rosterPlayerId}&position=${position}&leagueId=${leagueId}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json"}
    })
}