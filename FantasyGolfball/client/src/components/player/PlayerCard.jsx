import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { AddRosterPlayer, DeleteRosterPlayer } from "../../managers/rosterPlayerManager"
import "./PlayerPage.css"

export const PlayerCard = ({ player, isPreseason }) => {
    const [weekScore, setWeekScore] = useState()
    const [seasonTotal, setSeasonTotal] = useState()
    const [playerRosterCondition, setPlayerRosterCondition] = useState(<div></div>)
    const { roster, getAndSetRoster, selectedLeague, loggedInUser, allScores, getAndSetPlayers } = useAppContext()

    const HandleDropPlayer = () => {
        let rosterPlayer = roster.rosterPlayers.find(rp => rp.player.playerId === player.playerId)
        DeleteRosterPlayer(rosterPlayer.rosterPlayerId).then(() => {
            getAndSetRoster(),
            getAndSetPlayers()
        })
    }
        
    const HandleAddPlayer = (rosterId, playerId) => {
        let rosterPlayerPostDTO = {
            "playerId": playerId,
            "rosterId": rosterId,
        }
        AddRosterPlayer(rosterPlayerPostDTO).then(() => {
            getAndSetRoster()
        })
    }

    const ConfirmDrop = () => {
        let rosterPlayer = roster.rosterPlayers.find(rp => rp.player.playerId === player.playerId)
        const confirmed = window.confirm(`Are you sure you want to drop ${rosterPlayer.player.playerFullName}?`)
        if (confirmed) {
            HandleDropPlayer()
        } else {
            return
        }
    }

    const ConfirmAdd = (rosterId, playerId) => {
        if (roster.rosterPlayers.length >= selectedLeague.maxRosterSize) {
            console.log(roster.rosterPlayers.length)
            window.alert("You are at the roster size limit!")
            return
        }
        const confirmed = window.confirm(`Are you sure you want to add ${player.playerFullName} to your roster?`)
        if (confirmed) {
            HandleAddPlayer(rosterId, playerId)
        } else {
            return
        }
    }

    useEffect(() => {
        if (!allScores || selectedLeague?.season?.currentWeek == null) {
            setWeekScore(undefined)
            setSeasonTotal("-")
            return
        }

        const playerScores = allScores.filter(s => s.playerId == player.playerId)

        const thisWeekScore = playerScores.find(s => s.seasonWeek === selectedLeague.season.currentWeek)
        setWeekScore(thisWeekScore)

        const total = playerScores.reduce((sum, s) => sum + s.points, 0)
        setSeasonTotal(total.toFixed(1))
        
    }, [allScores, selectedLeague?.season?.currentWeek, player])

    useEffect(() => {
        if (selectedLeague && selectedLeague.leagueUsers.some(lu => lu.userProfileId !== loggedInUser.id 
            && lu.roster.rosterPlayers.some(rp => rp.playerId === player.playerId))) {
                setPlayerRosterCondition(<div>Taken</div>) // on another team
        } else if (roster && roster.rosterPlayers.some(rp => rp.player.playerId === player.playerId)) {
            setPlayerRosterCondition(<button className="button-drop" onClick={() => ConfirmDrop()}>-</button>) // on your team
        } else if (roster && !roster.rosterPlayers.some(rp => rp.player.playerId === player.playerId) ){
            setPlayerRosterCondition(<button className="button-add" onClick={() => ConfirmAdd(roster.rosterId, player.playerId)}>+</button>) // available
        }
    }, [roster, selectedLeague, loggedInUser, player])
    
    if (!roster || !selectedLeague) {
        return (null)
    }
    
    return (
        <tr>
            <td></td>
            <td>{player.playerFullName}</td>
            <td>{player.position.positionShort}</td>
            <td>{player.status.statusType}</td>
            <td>NYI</td>
            <td>{isPreseason ? "-" : weekScore ? weekScore.points : "-"}</td>
            <td>{seasonTotal ?? "-"}</td>
            <td>{playerRosterCondition}</td>
        </tr>
    )
}