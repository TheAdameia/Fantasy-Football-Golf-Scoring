import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { DeleteRosterPlayer } from "../../managers/rosterPlayerManager"
import { RosterPositionDropdown } from "./RosterPositionDropdown"


export const RosterPlayerCard = ({ rp, rosterLock }) => {
    const  { getAndSetRoster, allScores, selectedLeague, getAndSetPlayers, activeTrades } = useAppContext()
    const [weekScore, setWeekScore] = useState()
    const [seasonTotal, setSeasonTotal] = useState() // might want to fit this in later


    const HandleDropPlayer = (rosterPlayerId) => {
        DeleteRosterPlayer(rosterPlayerId, selectedLeague.leagueId).then(() => {
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
        if (!allScores || selectedLeague?.currentWeek == null) {
            setWeekScore(undefined)
            setSeasonTotal("-")
            return
        }

        const playerScores = allScores.filter(s => s.playerId === rp.player.playerId)

        // current week
        const thisWeekScore = playerScores.find(s => s.seasonWeek === selectedLeague.currentWeek)
        setWeekScore(rosterLock ? thisWeekScore : undefined)

        // season total
        const total = playerScores
            .filter(s => s.seasonWeek < selectedLeague.currentWeek || (s.seasonWeek === selectedLeague.currentWeek && rosterLock))
            .reduce((sum, s) => sum + s.points, 0)

        setSeasonTotal(total.toFixed(1))
    }, [allScores, rp, selectedLeague?.currentWeek, rosterLock])
    

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
                {weekScore ? weekScore.points.toFixed(2) : "-"}
            </td>
            <td>
                {seasonTotal ? seasonTotal : "-" }
            </td>
            <td>
                <button onClick={() => ConfirmDrop(rp.rosterPlayerId)}>-</button>
            </td>
        </tr>
    )
}