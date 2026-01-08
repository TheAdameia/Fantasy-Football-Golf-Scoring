import { Table } from "reactstrap"
import { BlankPlayerCard } from "./BlankPlayerCard"
import { SavedMatchupPlayerCard } from "./SavedMatchupPlayerCard"
import { useMemo } from "react"


export const SavedMatchupRosterCard = ({ matchupUser, slot, week }) => {
    const positions = ["QB1", "WR1", "WR2", "RB1", "RB2", "TE1", "FLEX", "K", "DEF"]

    const getTotalPoints = (matchupUser) => {
        return matchupUser.matchupUserSavedPlayers
        ?.filter((musp) => musp.rosterPlayerPosition?.toLowerCase() != "bench")
        .reduce((total, musp) => {
            return total + (musp.scoring?.points ?? 0)
        }, 0) ?? 0
    }

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

                // checks for fallback ID
                if (musp.scoring.scoringId == 1) {
                    if (musp.player.position.positionId == 1) {
                        playerPenalty += 15
                    } else {
                        playerPenalty += 10
                    }
                }

                totalPoints += musp.scoring.points

                // a spelling error generated much annoyance when testing the switch block
                // Penalizes 0 score IF NOT stats (difference between 2 - 2 = 0 and just 0)
                if (playerPenalty == 0 && musp.scoring.points == 0) {
                    switch (musp.player.position.positionId) {
                        case 1: // QB
                            if (musp.scoring.yardsPassing == 0 &&
                                musp.scoring.yardsRushing == 0 &&
                                musp.scoring.attemptsPassing == 0 &&
                                musp.scoring.attemptsRushing == 0 &&
                                musp.scoring.fumbleLost == 0 &&
                                musp.scoring.interceptions == 0) {
                                    playerPenalty += 15
                                }
                            break
                        case 2: // WR
                        case 3: // RB
                        case 4: // TE
                            if (musp.scoring.yardsReceiving == 0 &&
                                musp.scoring.yardsRushing == 0 &&
                                musp.scoring.targets == 0 &&
                                musp.scoring.attemptsRushing == 0 &&
                                musp.scoring.receptions == 0 &&
                                musp.scoring.fumbleLost == 0) {
                                    playerPenalty += 10
                                }
                            break
                        case 5: // K
                            if (musp.scoring.fieldGoalAttempts == 0 &&
                                musp.scoring.fieldGoalsMade == 0 &&
                                musp.scoring.extraPointAttempts == 0 &&
                                musp.scoring.extraPointMade == 0) {
                                    playerPenalty += 10
                            }
                            break
                        case 6: // DEF
                            break
                        default:
                            console.log("default player case")
                            break
                        }
                    }
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