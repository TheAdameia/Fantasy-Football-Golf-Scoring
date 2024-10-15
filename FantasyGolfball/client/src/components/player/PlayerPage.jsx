import { useEffect, useState } from "react"
import { Table } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"
import { SearchBar } from "../SearchBar"
import { GetAllPlayers } from "../../managers/playerManager"
import { PlayerCard } from "./PlayerCard"


export const PlayerPage = () => {
    const [players, setPlayers] = useState()
    // const [filteredPlayers, setFilteredPlayers] = useState()
    const [searchTerm, setSearchTerm] = useState()
    const [displayNumber, setDisplayNumber] = useState(25)
    const { globalWeek } = useAppContext()

    const getAndSetPlayers = () => {
        GetAllPlayers().then(setPlayers)
    }

    useEffect(() => {
        getAndSetPlayers()
    }, [])

    // useEffect(() => {
    //     const foundPlayers = players.filter(eventObject => eventObject.description.toLowerCase().includes(searchTerm.toLowerCase()))
    //     setFilteredPlayers(foundPlayers)
    // }, [searchTerm, players])

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
                <div>Dropdowns: position, stats</div>
                <div>Checkboxes: include my team, include other team</div>
            </div>
            <div>Bwaaaaak</div>
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
                    {players.slice(0, 24).map((player) => {
                        return (
                            <PlayerCard 
                                player={player}
                                key={`player-${player.playerId}`}
                            />
                        )
                    })}
                </tbody>
            </Table>
        </div>
    )
}