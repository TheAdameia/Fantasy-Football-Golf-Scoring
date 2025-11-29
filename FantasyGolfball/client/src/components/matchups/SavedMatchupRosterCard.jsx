import { Table } from "reactstrap"
import { BlankPlayerCard } from "./BlankPlayerCard"
import { SavedMatchupPlayerCard } from "./SavedMatchupPlayerCard"


export const SavedMatchupRosterCard = ({ matchupUser, slot, week }) => {
    const positions = ["QB1", "WR1", "WR2", "RB1", "RB2", "TE1", "FLEX", "K", "DEF"]

    const getTotalPoints = (matchupUser) => {
        return matchupUser.matchupUserSavedPlayers
        ?.filter((musp) => musp.rosterPlayerPosition?.toLowerCase() != "bench")
        .reduce((total, musp) => {
            return total + (musp.scoring?.points ?? 0)
        }, 0) ?? 0
    }

    if (slot == true && matchupUser) {
        return ( //position, name, team, injury status, points
            <div>
                <h5>{getTotalPoints(matchupUser).toFixed(2)}</h5>
                <Table striped>
                    <thead>
                        <tr>
                            <th>
                                stats
                            </th>
                            <th>
                                position
                            </th>
                            <th>
                                name
                            </th>
                            <th>
                                team
                            </th>
                            <th>
                                status
                            </th>
                            <th>
                                points
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {positions.map((pos) => {
                            const playerAtPos = matchupUser.matchupUserSavedPlayers.filter((musp) => musp.rosterPlayerPosition == pos)

                            return playerAtPos.length > 0 ? (
                                playerAtPos.map(pap => (
                                    <SavedMatchupPlayerCard
                                        musp={pap}
                                        key={pap.matchupUserSavedPlayerId}
                                        slot={slot}
                                        week={week}
                                    />
                                ))
                            ) : (
                                <BlankPlayerCard slot={slot} position={pos} key={`blank-${pos}`}/>
                            )
                        })}
                    </tbody>
                </Table>
            </div>
        )
    } else if (slot == false && matchupUser) {
        return (
            <div>
                <h5>{getTotalPoints(matchupUser).toFixed(2)}</h5>
                <Table striped>
                    <thead>
                        <tr>
                            <th>
                                points
                            </th>
                            <th>
                                status
                            </th>
                            <th>
                                team
                            </th>
                            <th>
                                name
                            </th>
                            <th>
                                position
                            </th>
                            <th>
                                stats
                            </th>
                        </tr>
                    </thead>

                    <tbody>
                        {positions.map((pos) => {
                            const playerAtPos = matchupUser.matchupUserSavedPlayers.filter((musp) => musp.rosterPlayerPosition == pos)

                            return playerAtPos.length > 0 ? (
                                playerAtPos.map(pap => (
                                    <SavedMatchupPlayerCard
                                        musp={pap}
                                        key={pap.matchupUserSavedPlayerId}
                                        slot={slot}
                                        week={week}
                                    />
                                ))
                            ) : (
                                <BlankPlayerCard slot={slot} position={pos} key={`blank-${pos}`}/>
                            )
                        })}
                    </tbody>
                </Table>
            </div>
        )
    } else {
        return (
            <div>loading...</div>
        )
    }
}