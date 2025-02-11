import { useEffect, useState } from "react"
import { RosterCard } from "./RosterCard"
import { useAppContext } from "../../contexts/AppContext"
import { GetByWeekAndPlayers } from "../../managers/scoringManager"
import { Button } from "reactstrap"
import { LeagueDropdownSwap } from "../league/LeagueDropdownSwap"


export const RosterPage = () => {
    const [scores, setScores] = useState([])
    const { roster, globalWeek, loggedInUser } = useAppContext()

    const getAndSetScores = () => {
        const rosterPlayers = roster?.rosterPlayers || []

        const playerIds = rosterPlayers.map(p => p.playerId)
        const playerIdsString = playerIds.join(',')
       
        if (playerIds.length > 0) {
            GetByWeekAndPlayers(globalWeek, playerIdsString).then(setScores)
        }
    }

    useEffect(() => {
        getAndSetScores()
    }, [roster])

    return (
        <div>
            <div>
                <LeagueDropdownSwap/>
            </div>
            <h2>{loggedInUser.userName}'s team</h2>
            <div>create trade button goes here
                <Button>Create a trade</Button>
            </div>
            <RosterCard scores={scores}/>
        </div>
    )
}