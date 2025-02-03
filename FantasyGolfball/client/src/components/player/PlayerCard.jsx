import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { GetByPlayer } from "../../managers/scoringManager"
import { AddRosterPlayer, DeleteRosterPlayer } from "../../managers/rosterPlayerManager"

export const PlayerCard = ({ player }) => {
    const [scores, setScores] = useState()
    const [weekScore, setWeekScore] = useState()
    const [seasonTotal, setSeasonTotal] = useState()
    const { globalWeek, roster, getAndSetRoster } = useAppContext()

    const getAndSetScores = () => {
        GetByPlayer(player.playerId).then(setScores)
    }

    const HandleDropPlayer = () => {
        let rosterPlayer = roster.rosterPlayers.find(rp => rp.player.playerId === player.playerId)
        DeleteRosterPlayer(rosterPlayer.rosterPlayerId)
        getAndSetRoster()
    }
        
    const HandleAddPlayer = (rosterId, playerId) => {
        let rosterPlayerPostDTO = {
            "playerId": playerId,
            "rosterId": rosterId,
            "rosterPosition": "bench"
        }
        AddRosterPlayer(rosterPlayerPostDTO)
        getAndSetRoster()
    }

    useEffect(() => {
        getAndSetScores()
    }, [player])

    useEffect(() => {
        if (scores != null){
            const thisWeekScore = scores.find(s => s.seasonWeek == globalWeek)
            setWeekScore(thisWeekScore)

            let total = scores.reduce((sum, s) => sum + s.points, 0)
            let fixedTotal = total.toFixed(1)
            setSeasonTotal(fixedTotal)
        }
    }, [scores])

    if (!roster) {
        return (
            <tr></tr>
        )
    }

    return (
        <tr>
            <th>

            </th>
            <td>
                {player.playerFirstName} {player.playerLastName}
            </td>
            <td>
                {player.position.positionShort}
            </td>
            <td>
                {player.status.statusType}
            </td>
            <td>
                NYI
            </td>
            <td>
                {weekScore ? weekScore.points : 0}
            </td>
            <td>
                {seasonTotal ? seasonTotal : 0}
            </td>
            <td>
                {roster && roster.rosterPlayers.some(rp =>
                    rp.player.playerId === player.playerId) 
                ? <button onClick={() => HandleDropPlayer()}>-</button> : <div></div>}
                {roster && !roster.rosterPlayers.some(rp =>
                    rp.player.playerId === player.playerId) 
                ? <button onClick={() => HandleAddPlayer(roster.rosterId, player.playerId)}>+</button> : <div></div>}
                
            </td>
        </tr>
    )
}