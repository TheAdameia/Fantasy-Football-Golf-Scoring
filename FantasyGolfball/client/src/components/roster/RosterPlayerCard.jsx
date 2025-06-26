import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { DeleteRosterPlayer } from "../../managers/rosterPlayerManager"
import { RosterPositionDropdown } from "./RosterPositionDropdown"


export const RosterPlayerCard = ({ rp, rosterLock }) => {
    const  { getAndSetRoster, allScores, selectedLeague, getAndSetPlayers, activeTrades } = useAppContext()
    const [weekScore, setWeekScore] = useState()
    const [seasonTotal, setSeasonTotal] = useState() // might want to fit this in later


    const HandleDropPlayer = (rosterPlayerId) => {
        DeleteRosterPlayer(rosterPlayerId).then(() => {
            getAndSetRoster(),
            getAndSetPlayers()
        })
    }

    const ConfirmDrop = (rosterPlayerId) => {
        if (selectedLeague.isLeagueFinished) {
            window.alert("I think you're a bit late for that!")
            return
        } else if (!selectedLeague.isDraftComplete) {
            window.alert("I think you're a bit early for that! How did you get this??")
            return
        } else if (activeTrades.some(at => at.playerId == rp.playerId)) {
            window.alert("Can't drop a player in a trade offer! (Check your trades)")
            return
        } else if (rosterLock == true) {
            window.alert("Can't do that while games are in progress!")
        }
        const confirmed = window.confirm(`Are you sure you want to drop ${rp.player.playerFullName}?`)
        if (confirmed) {
            HandleDropPlayer(rosterPlayerId)
        } else {
            return
        }
    }

    useEffect(() => {
            if (selectedLeague.currentWeek == null) {
                setWeekScore(0)
            }
            if (allScores) {
                const playerScores = allScores.filter(s => s.playerId == rp.player.playerId)
                let thisWeekScore = playerScores.find(s => s.seasonWeek == selectedLeague.currentWeek)
                setWeekScore(thisWeekScore)
    
                let total = playerScores.reduce((sum, s) => sum + s.points, 0)
                let fixedTotal = total.toFixed(1)
                setSeasonTotal(fixedTotal)
            }
        }, [allScores, rp, selectedLeague])
    

    return (
        <tr>
            <th scope="row">
                <RosterPositionDropdown
                    rp={rp}
                    rosterLock={rosterLock}
                >

                </RosterPositionDropdown>
            </th>
            <td>
                {rp.player.playerStatuses[0].status.statusType}
            </td>
            <td>
                {rp.player.position.positionShort}
            </td>
            <td>
                {rp.player.playerFullName}
            </td>
            <td>
                {rp.player.playerTeams[0].team.teamName}
            </td>
            <td>
                {rp.player.playerTeams[0].team.byeWeek}
            </td>
            <td>
                {weekScore ? weekScore.points : "-"}
            </td>
            <td>
                <button onClick={() => ConfirmDrop(rp.rosterPlayerId)}>-</button>
            </td>
        </tr>
    )
}