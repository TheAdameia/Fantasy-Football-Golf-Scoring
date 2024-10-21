import { useEffect, useState } from "react"
import { Table } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"
import { SearchBar } from "../SearchBar"
import { GetAllPlayers } from "../../managers/playerManager"
import { PlayerCard } from "./PlayerCard"


export const PlayerPage = () => {
    const [players, setPlayers] = useState()
    const [filteredPlayers, setFilteredPlayers] = useState()
    const [searchTerm, setSearchTerm] = useState("")
    const [positionFilter, setPositionFilter] = useState("Any")
    const { globalWeek } = useAppContext()

    const getAndSetPlayers = () => {
        GetAllPlayers().then(setPlayers)
    }
    
    const handlePositionChange = (event) => {
        setPositionFilter(event.target.value)
    }

    useEffect(() => {
        getAndSetPlayers()
    }, [])

    useEffect(() => {
        if (players){
            const foundPlayers = players.filter(player => 
                player.playerLastName.toLowerCase().includes(searchTerm.toLowerCase()) || 
                player.playerFirstName.toLowerCase().includes(searchTerm.toLowerCase())
            ) // I realize that if you type a full name in this won't work. I will have to adjust the full name to be a calculated property later.

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
    }, [searchTerm, players, positionFilter])

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
                    Dropdowns: position, stats
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
                <div>Checkboxes: include my team, include other team
                    <input type="checkbox" id="my-team" name="Include my team"/>
                    <input type="checkbox" id="other-teams" name="Include other teams"/>
                </div>
            </div>
            <Table>
                <thead>
                    <tr>
                        <th>
                            #
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
                        <th>
                            Roster Status
                        </th>
                        <th>
                            Week {globalWeek} Points
                        </th>
                        <th>
                            Season Total Points
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {filteredPlayers ? filteredPlayers.slice(0, 24).map((player) => {
                        return (
                            <PlayerCard 
                                player={player}
                                key={`player-${player.playerId}`}
                            />
                        )
                    }) : <tr></tr>}
                </tbody>
            </Table>
        </div>
    )
}