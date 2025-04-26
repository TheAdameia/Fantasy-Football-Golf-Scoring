import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import { GetLeaguesWithVacancies } from "../../managers/leagueManager"
import { LeagueCard } from "./LeagueCard"
import "./League.css"
import { SearchBar } from "../SearchBar"


export const LeaguePage = () => {
    const [leagues, setLeagues] = useState()
    const [searchTerm, setSearchTerm] = useState("")
    const [filteredLeagues, setFilteredLeagues] = useState()
    const navigate = useNavigate()

    const getAndSetLeagues = () => {
        GetLeaguesWithVacancies().then(setLeagues)
    }

    const handleCreate = () => {
        navigate(`/league/create`)
    }

    useEffect(() => {
        getAndSetLeagues()
    }, [])

    useEffect(() => {
        if (leagues) {
            const foundLeagues = leagues.filter(l => l.leagueName.toLowerCase().includes(searchTerm.toLowerCase()))
            setFilteredLeagues(foundLeagues)
        }
    }, [leagues, searchTerm])

    return (
        <div>
            <h2 className="leagues-h2">Leagues looking for players</h2>
            <div className="leagues-widgets-container">
                <div className="leagues-widget">
                    <div>Search:</div>
                    <SearchBar setSearchTerm={setSearchTerm} />
                </div>
                <button
                    className="leagues-widget"
                    onClick={() => handleCreate()}
                >Create a league!</button>
            </div>            
            <div className="leagues-container">
                {filteredLeagues ? filteredLeagues.map((league) => {
                    return (
                        <LeagueCard
                            league={league}
                            getAndSetLeagues={getAndSetLeagues}
                            key={`league-${league.leagueId}`}
                        />
                    )
                }) : <div>No leagues found</div>}
            </div>
        </div>
    )
}