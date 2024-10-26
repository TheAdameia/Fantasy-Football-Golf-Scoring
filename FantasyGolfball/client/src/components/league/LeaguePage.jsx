import { useEffect, useState } from "react"
import { GetAllLeagues } from "../../managers/leagueManager"
import { LeagueCard } from "./LeagueCard"


export const LeaguePage = () => {
    const [leagues, setLeagues] = useState()

    const getAndSetLeagues = () => {
        GetAllLeagues().then(setLeagues)
    }

    useEffect(() => {
        getAndSetLeagues()
    }, [])

    return (
        <div>            
            <button>Create a league!</button>
            <h2>List of Leagues</h2>
            {leagues.map((league) => {
                return (
                    <LeagueCard
                        league={league}
                        key={`league-${league.leagueId}`}
                    />
                )
            })}
        </div>
    )
}