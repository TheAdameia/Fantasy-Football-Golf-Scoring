import { Table } from "reactstrap"
import { BlankPlayerCard } from "./BlankPlayerCard"
import { SavedMatchupPlayerCard } from "./SavedMatchupPlayerCard"
import { useMemo } from "react"
import { CheckPenalty } from "../widgets/CheckPenalty"


export const SavedMatchupRosterCard = ({ matchupUser, slot, week }) => {
    const positions = ["QB1", "WR1", "WR2", "RB1", "RB2", "TE1", "FLEX", "K", "DEF"]

    const calculateTotalPoints = (matchupUser) => {
        if (!matchupUser) {
            return { totalPoints : 0, penaltyPoints : 0 }
        }

        let penaltyPoints = 0
        let totalPoints = 0

        // check and penalize for missing positions
        const rosterPositions = matchupUser.matchupUserSavedPlayers.map(musp => musp.rosterPlayerPosition)

        const missingPositionCount = positions.filter(pos =>
            !rosterPositions.includes(pos)
        ).length

        if (missingPositionCount != 0) {
            penaltyPoints = penaltyPoints + (15 * missingPositionCount)
        }

        for (const musp of matchupUser.matchupUserSavedPlayers) {
            if (musp.rosterPlayerPosition !== "bench") {
                let playerPenalty = 0

                // penalizes no-scoring/bye weeks

                // checks, penalizes for fallback ID
                if (musp.scoring.scoringId == 1) {
                    if (musp.player.position.positionId == 1) {
                        playerPenalty += 15
                    } else {
                        playerPenalty += 10
                    }
                }

                totalPoints += musp.scoring.points

                // penalizes 0 score IF NOT stats (difference between 2 - 2 = 0 and just 0)
                playerPenalty += CheckPenalty(musp.player, musp.scoring)
                
                // adds the resultant total to the return value
                penaltyPoints += playerPenalty

                }
            }

            return {
                totalPoints: totalPoints,
                penaltyPoints: penaltyPoints
            }
        }
    
    const result = useMemo(() => 
            matchupUser ? calculateTotalPoints(matchupUser) 
            : { totalPoints: 0, penaltyPoints: 0 }, 
            [matchupUser]
        )
    
    

    if (slot == true && matchupUser) {
        return ( //position, name, team, injury status, points
            <div>
                <h5>{result.totalPoints.toFixed(2)} + {result.penaltyPoints}</h5>
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
                <h5>{result.totalPoints.toFixed(2)} + {result.penaltyPoints}</h5>
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