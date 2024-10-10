import { useEffect, useState } from "react"
import { RosterCard } from "./RosterCard"
import { GetByUserAndLeague } from "../../managers/rosterManager"
import { useAppContext } from "../../contexts/AppContext"
import { GetByWeekAndPlayers } from "../../managers/scoringManager"


export const RosterPage = () => {
    const [roster, setRoster] = useState([])
    const [scores, setScores] = useState([])
    const { loggedInUser, globalWeek } = useAppContext()
    // I will need to get scores. What's the most efficient way to do that? Week and players?

    const getAndSetRoster = () => {
        let leagueId = 1 // I will need to actually get this value instead of assuming it
        let userId = loggedInUser.id
        GetByUserAndLeague(leagueId, userId).then(setRoster)
    }

    const getAndSetScores = () => {
        let playerIds = []
        for (const player of roster) {
            playerIds.push(player.playerId)
        }
        GetByWeekAndPlayers(globalWeek, playerIds).then(setScores)
    }

    useEffect(() => {
        getAndSetRoster()
    }, [])

    useEffect(() => {
        getAndSetScores()
    }, [roster])

    return (
        <div>
            <h2>User team</h2>
            <div>Add, drop, create trade buttons go here</div>
            <div>Select other rosters goes to the side</div>
            <RosterCard roster={roster} scores={scores}/>
        </div>
    )
}