import { Table } from "reactstrap"
import { RosterPlayerCard } from "./RosterPlayerCard"
import { useAppContext } from "../../contexts/AppContext";
import "./Roster.css"
import { BlankRosterPlayerCard } from "./BlankRosterPlayerCard";


export const RosterCard = ({ rosterLock, setSelectedPlayerForStats }) => {
    const { roster, selectedLeague } = useAppContext()
    const positions = ["QB1", "WR1", "WR2", "RB1", "RB2", "TE1", "FLEX", "K", "DEF"]

    
    if (!roster || !Array.isArray(roster.rosterPlayers)) {
        return <div>Roster not created</div>;
    }

    return (
        <div>
            <Table>
                <thead>
                    <tr>
                        <th>
                            Select
                        </th>
                        <th>
                            Status
                        </th>
                        <th>
                            Pos
                        </th>
                        <th>
                            Player
                        </th>
                        <th>
                            Team
                        </th>
                        <th>
                            Bye Week
                        </th>
                        <th>
                            Week {selectedLeague.currentWeek} Points
                        </th>
                        <th>
                            Season Total Points
                        </th>
                        <th>
                            drop
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {positions.map((pos) => {
                        const playerAtPos = roster.rosterPlayers.filter((rp) => rp.rosterPosition == pos)

                        return playerAtPos.length > 0 ? (
                            playerAtPos.map(pap => (
                                <RosterPlayerCard 
                                    rp={pap}
                                    key={`rp-${pap.rosterPlayerId}`}
                                    rosterLock={rosterLock}
                                    setSelectedPlayerForStats={setSelectedPlayerForStats}
                                />
                            ))
                        ) : (
                            <BlankRosterPlayerCard position={pos} key={`blank-${pos}`}/>
                        )
                    })}
                </tbody>
                <tbody className="table-divider">
                    {roster.rosterPlayers
                        .filter((rp) => rp.rosterPosition === "bench")
                        .map((rp) => {
                        return (
                            <RosterPlayerCard
                                rp={rp}
                                key={`rp-${rp.rosterPlayerId}`}
                                rosterLock={rosterLock}
                                setSelectedPlayerForStats={setSelectedPlayerForStats}
                            ></RosterPlayerCard>
                        )
                    })}
                </tbody>
            </Table>
        </div>
    )
}