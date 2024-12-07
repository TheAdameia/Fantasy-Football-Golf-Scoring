import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { SearchBar } from "../SearchBar"
import { Table } from "reactstrap"
import { DraftPlayerCard } from "./DraftPlayerCard"


export const DraftPlayerList = () => {
    const { players } = useAppContext()
    // const { scores } = useAppContext() // I don't have this set up yet
    const [remainingPlayers, setRemainingPlayers] = useState() // for determining draft eligibility
    const [filteredPlayers, setFilteredPlayers] = useState() // for display
    // using a scroll for the playerlist instead of the slice used in PlayerPage should reduce state overhead
    const [searchTerm, setSearchTerm] = useState("")
    const [positionFilter, setPositionFilter] = useState("Any")


    const handlePlayerDraft = () => {
        // deep copy of remainingPlayers, remove selected player, setRemainingPlayers
        // this will really need to be handled by signalR because state is impermanent
        // remainingPlayers must be set initially but the useEffect should take care of that
    }
    
    const handlePositionChange = (event) => {
        setPositionFilter(event.target.value)
    }

    useEffect(() => {
        setRemainingPlayers(players)
        // I don't feel very good about this one because a refresh could bork the whole system. Need something to check if players are already drafted somehow. Maybe storing this as state isn't a good idea?
    }, [players])

    useEffect(() => {
        if (remainingPlayers){
            const foundPlayers = remainingPlayers.filter(player => 
                player.playerLastName.toLowerCase().includes(searchTerm.toLowerCase()) || 
                player.playerFirstName.toLowerCase().includes(searchTerm.toLowerCase())
            ) // inherits name search issue from PlayerPage

            switch(positionFilter) {
                case "Any":
                    setFilteredPlayers(foundPlayers)
                    break
                case "QB":
                    setFilteredPlayers(foundPlayers.filter(p => p.position.positionShort == "QB"))
                    break
                case "WR":
                    setFilteredPlayers(foundPlayers.filter(p => p.position.positionShort == "WR"))
                    break
                case "RB":
                    setFilteredPlayers(foundPlayers.filter(p => p.position.positionShort == "RB"))
                    break
                case "TE":
                    setFilteredPlayers(foundPlayers.filter(p => p.position.positionShort == "TE"))
                    break
                case "K":
                    setFilteredPlayers(foundPlayers.filter(p => p.position.positionShort == "K"))
                    break
                case "DEF":
                    setFilteredPlayers(foundPlayers.filter(p => p.position.positionShort == "DEF"))
                    break
            }
        } 
    }, [searchTerm, players, positionFilter, remainingPlayers])

    if (!players) {
        return (
            <div>Loading...</div>
        )
    }

    return (
        <div>
            <h2>Player List</h2>
            <div>
                <div>Search bar (name)</div>
                <SearchBar setSearchTerm={setSearchTerm}/>
                <div>
                    <label>Position</label>
                    <select name="position" id="position" onChange={handlePositionChange}>
                        <option value="Any">Any</option>
                        <option value="QB">QB</option>
                        <option value="WR">WR</option>
                        <option value="RB">RB</option>
                        <option value="TE">TE</option>
                        <option value="K">K</option>
                        <option value="DEF">DEF</option>
                    </select>
                    <label>Stats</label>
                    <select name="stats" id="stats">
                        <option value="This week">This Week</option>
                        <option value="Season Total">Season Total</option>
                        <option value="Season Average">Season Average</option>
                    </select>
                </div>
            </div>
            <Table>
                <thead>
                    <tr>
                        <th>
                            Rank
                        </th>
                        <th>
                            Player
                        </th>
                        <th>
                            Position
                        </th>
                        <th>
                            Status
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {filteredPlayers ? filteredPlayers.map((player) => {
                        return (
                            <DraftPlayerCard
                                player={player}
                                key={`player-${player.playerId}`}
                            />
                        )
                    }) : <div>Loading...</div>}
                </tbody>
            </Table>
        </div>
    )
}