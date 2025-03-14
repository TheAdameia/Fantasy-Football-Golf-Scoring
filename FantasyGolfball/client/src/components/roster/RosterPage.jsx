import { useEffect, useState } from "react"
import { RosterCard } from "./RosterCard"
import { useAppContext } from "../../contexts/AppContext"
import { GetByWeekAndPlayers } from "../../managers/scoringManager"
import { Button } from "reactstrap"


export const RosterPage = () => {
    const [scores, setScores] = useState([])
    const { roster, loggedInUser, selectedLeague } = useAppContext()

    const getAndSetScores = () => {
        const rosterPlayers = roster?.rosterPlayers || []

        const playerIds = rosterPlayers.map(p => p.playerId)
        const playerIdsString = playerIds.join(',')
       
        if (playerIds.length > 0) {
            GetByWeekAndPlayers(selectedLeague.season.currentWeek, playerIdsString).then(setScores)
        }
    }

    useEffect(() => {
        getAndSetScores()
    }, [roster])

    return (
        <div>
            <div>
                <h2>{loggedInUser.userName}'s team</h2>
                <div>
                    <Button>Create a trade</Button>
                </div>
            </div>
            <RosterCard scores={scores}/>
        </div>
    )
}