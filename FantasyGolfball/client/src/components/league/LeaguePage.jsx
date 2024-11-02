import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import { GetAllLeagues } from "../../managers/leagueManager"
import { LeagueCard } from "./LeagueCard"


export const LeaguePage = () => {
    const [leagues, setLeagues] = useState()
    const navigate = useNavigate()

    const getAndSetLeagues = () => {
        GetAllLeagues().then(setLeagues)
    }

    const handleCreate = () => {
        navigate(`/league/create`)
    }

    useEffect(() => {
        getAndSetLeagues()
    }, [])

    return (
        <div>            
            <button
                onClick={() => handleCreate}
            >Create a league!</button>
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