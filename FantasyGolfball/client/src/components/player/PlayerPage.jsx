import { useEffect, useState } from "react"
import { Table } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"
import { SearchBar } from "../SearchBar"
import { PlayerCard } from "./PlayerCard"

export const PlayerPage = () => {
    const [filteredPlayers, setFilteredPlayers] = useState()
    const [searchTerm, setSearchTerm] = useState("")
    const [positionFilter, setPositionFilter] = useState("Any")
    const [playerSlice, setPlayerSlice] = useState({sliceStart: 0, sliceEnd: 24})
    const { players, selectedLeague } = useAppContext()

    const handlePositionChange = (event) => {
        setPositionFilter(event.target.value)
    }

    const handleSliceChange = (taco) => {
        let tempPlayerSlice = {...playerSlice}
        if (tempPlayerSlice.sliceEnd > filteredPlayers.length && taco == true) {
            return
        }
        if (taco == true)
        {
            tempPlayerSlice.sliceStart += 25
            tempPlayerSlice.sliceEnd += 25
            setPlayerSlice(tempPlayerSlice)
        } else {
            if (tempPlayerSlice.sliceStart > 0) {
                tempPlayerSlice.sliceStart -= 25
                tempPlayerSlice.sliceEnd -= 25
                setPlayerSlice(tempPlayerSlice)
            }
        }
    }
    
    useEffect(() => {
        if (players){
            const foundPlayers = players.filter(player => 
                player.playerFullName.toLowerCase().includes(searchTerm.toLowerCase()) 
            )

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
            <div>The player list will become available when you have joined a League and completed a Draft.</div>
        )
    }

    if (!selectedLeague?.isDraftComplete) {
        return <div>Draft must be complete to view Player List.</div>;
    }

    return (
        <div>
            <h2>Player List</h2>
            <div className="playerpage-options-container">
                <div>
                    <SearchBar setSearchTerm={setSearchTerm}/>
                </div>
                <div>
                    <label className="playerpage-label">Position</label>
                    <select name="position" id="position" onChange={handlePositionChange}>
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
                    <label className="playerpage-label">Stats</label>
                    <select name="stats" id="stats">
                        <option value="This week">This Week</option>
                        <option value="Season Total">Season Total</option>
                        <option value="Season Average">Season Average</option>
                    </select>
                </div>
                {/* <div>Checkboxes: include my team, include other team
                    <input type="checkbox" id="my-team" name="Include my team"/>
                    <input type="checkbox" id="other-teams" name="Include other teams"/>
                </div> */}
            </div>
            <div>
                <label className="playerpage-label">Players {playerSlice.sliceStart} - {playerSlice.sliceEnd}</label>
                <button
                    className="button-view"
                    onClick={() => handleSliceChange(false)}
                >Previous</button>
                <button
                    className="button-view"
                    onClick={() => handleSliceChange(true)}
                >Next</button>
            </div>
            <Table>
                <thead>
                    <tr>
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
                            Week {selectedLeague?.currentWeek != null ? selectedLeague.currentWeek : "Preseason"} Points
                        </th>
                        <th>
                            Season Total Points
                        </th>
                        <th>
                            Actions
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {filteredPlayers && filteredPlayers.length > 0
                        ? filteredPlayers.slice(playerSlice.sliceStart, playerSlice.sliceEnd).map(player => 
                                <PlayerCard 
                                    player={player}
                                    key={`player-${player.playerId}`}
                                    isPreseason={selectedLeague?.currentWeek == null}
                                />
                    ) : (
                    <tr>
                        <td>No players found</td>
                    </tr> 
                    )}
                </tbody>
            </Table>
        </div>
    )
}