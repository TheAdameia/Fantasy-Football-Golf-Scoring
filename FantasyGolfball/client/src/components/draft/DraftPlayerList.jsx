import { useContext, useEffect, useState } from "react"
import { SearchBar } from "../SearchBar"
import { Table } from "reactstrap"
import { DraftPlayerCard } from "./DraftPlayerCard"
import { DraftContext } from "./DraftPage"
import "./DraftLayout.css"


export const DraftPlayerList = ({ setSelectedPlayer, confirmCheck }) => {
    // get score data from DraftContext (eventually)
    const [filteredPlayers, setFilteredPlayers] = useState() // for display
    // using a scroll for the playerlist instead of the slice used in PlayerPage should reduce state overhead
    const [searchTerm, setSearchTerm] = useState("")
    const [positionFilter, setPositionFilter] = useState("Any")
    const { draftState } = useContext(DraftContext)

    const handlePositionChange = (event) => {
        setPositionFilter(event.target.value)
    }

    useEffect(() => {
        if (draftState && draftState.availablePlayers !== undefined) {
            const foundPlayers = draftState.availablePlayers.filter(player => 
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
    }, [searchTerm, positionFilter, draftState])

    if (!draftState) {
        return (
            <div>Loading...</div>
        )
    }

    return (
        <div className="draft-playerlist-container">
            <h2>Player List</h2>
            <div>
                <div>Search bar (name)</div>
                <SearchBar setSearchTerm={setSearchTerm}/>
                <div className="draft-playerlist-widget-container">
                    <div>
                        <label className="draft-playerlist-widget">Position</label>
                        <select 
                            className="draft-playerlist-widget"
                            name="position" 
                            id="position" 
                            onChange={handlePositionChange}
                        >
                            <option value="Any">Any</option>
                            <option value="QB">QB</option>
                            <option value="WR">WR</option>
                            <option value="RB">RB</option>
                            <option value="TE">TE</option>
                            <option value="K">K</option>
                            <option value="DEF">DEF</option>
                        </select>
                    </div>
                    <div>
                        <label className="draft-playerlist-widget">Stats</label>
                        <select 
                            className="draft-playerlist-widget"
                            name="stats" 
                            id="stats"
                        >
                            <option value="Project Season Average">Projected Season Average</option>
                            <option value="Season Total">Last Season Total</option>
                            <option value="Season Average">Last Season Average</option>
                        </select>
                    </div>
                </div>
            </div>
            <div className="draft-table-container">
                <Table>
                    <thead>
                        <tr>
                            <th>
                                Rank (NYI)
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
                                Team
                            </th>
                            <th>
                                Expected Points
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {filteredPlayers ? filteredPlayers.map((player) => {
                            return (
                                <DraftPlayerCard
                                    player={player}
                                    key={`player-${player.playerId}`}
                                    setSelectedPlayer={setSelectedPlayer}
                                    confirmCheck={confirmCheck}
                                />
                            )
                        }) : <tr>
                                <td>Loading...</td>
                            </tr>}
                    </tbody>
                </Table>
            </div>
        </div>
    )
}