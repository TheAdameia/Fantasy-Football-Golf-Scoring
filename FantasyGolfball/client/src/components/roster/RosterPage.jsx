import { useEffect, useState } from "react"
import { RosterCard } from "./RosterCard"
import { GetByUserAndLeague } from "../../managers/rosterManager"
import { useAppContext } from "../../contexts/AppContext"


export const RosterPage = () => {
    const [roster, setRoster] = useState([])
    const { loggedInUser } = useAppContext()
    // I will need to get scores. What's the most efficient way to do that? Week and players?
    // Is there some kind of global state I can use for week?

    const getAndSetRoster = () => {
        let leagueId = 1 // I will need to actually get this value instead of assuming it
        let userId = loggedInUser.id
        GetByUserAndLeague(leagueId, userId).then(setRoster)
    }

    useEffect(() => {
        getAndSetRoster()
    }, [])

    return (
        <div>
            <h2>User team</h2>
            <div>Add, drop, create trade buttons go here</div>
            <div>Select other rosters goes to the side</div>
            <RosterCard roster={roster}/>
        </div>
    )
}