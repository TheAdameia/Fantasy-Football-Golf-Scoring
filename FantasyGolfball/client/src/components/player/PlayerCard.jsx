import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { GetByPlayer } from "../../managers/scoringManager"
import { AddRosterPlayer, DeleteRosterPlayer } from "../../managers/rosterPlayerManager"

export const PlayerCard = ({ player }) => {
    const [scores, setScores] = useState()
    const [weekScore, setWeekScore] = useState()
    const [seasonTotal, setSeasonTotal] = useState()
    const [playerRosterCondition, setPlayerRosterCondition] = useState(<div></div>)
    const { globalWeek, roster, getAndSetRoster, selectedLeague, loggedInUser } = useAppContext()

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

    useEffect(() => {
        if (selectedLeague && selectedLeague.leagueUsers.some(lu => lu.userProfileId !== loggedInUser.id 
            && lu.roster.rosterPlayers.some(rp => rp.playerId === player.playerId))) {
                setPlayerRosterCondition(<div>Taken</div>) // on another team
        } else if (roster && roster.rosterPlayers.some(rp => rp.player.playerId === player.playerId)) {
            setPlayerRosterCondition(<button onClick={() => HandleDropPlayer()}>-</button>) // on your team
        } else if (roster && !roster.rosterPlayers.some(rp => rp.player.playerId === player.playerId) ){
            setPlayerRosterCondition(<button onClick={() => HandleAddPlayer(roster.rosterId, player.playerId)}>+</button>) // available
        }
    }, [roster])

    if (!roster || !selectedLeague) {
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
                {playerRosterCondition}
            </td>
        </tr>
    ) 
}