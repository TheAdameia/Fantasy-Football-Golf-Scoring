import { useEffect, useState } from "react"
import { RosterCard } from "./RosterCard"
import { useAppContext } from "../../contexts/AppContext"
import { GetByWeekAndPlayers } from "../../managers/scoringManager"
import { Button, ButtonDropdown } from "reactstrap"


export const RosterPage = () => {
    const [scores, setScores] = useState([])
    const { roster, globalWeek } = useAppContext()

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
            <h2>User team</h2>
            <div>create trade button goes here
                <Button>Create a trade</Button>
            </div>
            <div>Select other rosters goes to the side
                <ButtonDropdown>Other Rosters</ButtonDropdown>
            </div>
            <RosterCard scores={scores}/>
        </div>
    )
}