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
    const [showMyTeam, setShowMyTeam] = useState(false)
    const [showOtherTeam, setShowOtherTeam] = useState(false)
    const [rosterLock, setRosterLock] = useState(false)
    const { players, selectedLeague, loggedInUser } = useAppContext()

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
        if (!selectedLeague || selectedLeague.currentWeek < 1 || !selectedLeague.seasonStartDate) return

        const seasonStart = new Date(selectedLeague.seasonStartDate)
        let msPerWeek, totalRevealDuration

        switch (selectedLeague.advancement) {
            case 0: // Weekly
                msPerWeek = 1000 * 60 * 60 * 24 * 7
                totalRevealDuration = 1000 * 60 * 60 * 8
                break
            case 1: // Daily
                msPerWeek = 1000 * 60 * 60 * 24
                totalRevealDuration = 1000 * 60 * 60
                break
            case 2: // Hourly
                msPerWeek = 1000 * 60 * 60
                totalRevealDuration = 1000 * 60 * 10
                break
            case 3: // Turbo
                msPerWeek = 1000 * 60 * 15
                totalRevealDuration = 1000 * 60 * 5
                break
            default:
                return
        }

        const nextWeekTime = new Date(seasonStart.getTime() + selectedLeague.currentWeek * msPerWeek)
        const revealStartTime = new Date(nextWeekTime.getTime() - totalRevealDuration)

        const checkRevealStatus = () => {
            const now = new Date().getTime()
            setRosterLock(now >= revealStartTime.getTime() && now <= nextWeekTime.getTime())
        }

        checkRevealStatus()
        const interval = setInterval(checkRevealStatus, 1000)
        return () => clearInterval(interval)
    }, [selectedLeague])
    
    useEffect(() => {
        if (players && selectedLeague){
            // first: filter by search
            let foundPlayers = players.filter(player => 
                player.playerFullName.toLowerCase().includes(searchTerm.toLowerCase()) 
            )

            // second: filter by position
            switch(positionFilter) {
                case "QB":
                    foundPlayers = (foundPlayers.filter(p => p.position.positionShort == "QB"))
                    break
                case "WR":
                    foundPlayers = (foundPlayers.filter(p => p.position.positionShort == "WR"))
                    break
                case "RB":
                    foundPlayers = (foundPlayers.filter(p => p.position.positionShort == "RB"))
                    break
                case "TE":
                    foundPlayers = (foundPlayers.filter(p => p.position.positionShort == "TE"))
                    break
                case "K":
                    foundPlayers = (foundPlayers.filter(p => p.position.positionShort == "K"))
                    break
                case "DEF":
                    foundPlayers = (foundPlayers.filter(p => p.position.positionShort == "DEF"))
                    break
            }

            // third: filter by roster
            foundPlayers = foundPlayers.filter(p => {
                const ownerRoster = selectedLeague.leagueUsers.find(lu =>
                    lu.roster.rosterPlayers.some(rp => rp.playerId === p.playerId)
                )

                const isUserPlayer = ownerRoster?.userProfileId === loggedInUser.id

                if (isUserPlayer && !showMyTeam) {
                    return false
                }
                if (!isUserPlayer && !showOtherTeam && ownerRoster) {
                    return false
                }

                return true
            })

            // final
            setFilteredPlayers(foundPlayers)
        } 
    }, [searchTerm, players, positionFilter, showMyTeam, showOtherTeam, loggedInUser, selectedLeague])

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
                    <select name="stats" id="stats" disabled>
                        <option value="This week">This Week</option>
                        <option value="Season Total">Season Total</option>
                        <option value="Season Average">Season Average</option>
                    </select>
                </div>
                <div> 
                    <div>Include My Team</div>
                    <input 
                        type="checkbox" 
                        id="my-team" 
                        name="Include my team"
                        checked={showMyTeam}
                        onChange={() => {setShowMyTeam(!showMyTeam)}}
                    />
                </div>
                <div>
                    <div>Include Other Teams</div>
                    <input 
                        type="checkbox" 
                        id="other-teams" 
                        name="Include other teams"
                        checked={showOtherTeam}
                        onChange={() => {setShowOtherTeam(!showOtherTeam)}}
                    />
                </div>
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
                                    rosterLock={rosterLock}
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