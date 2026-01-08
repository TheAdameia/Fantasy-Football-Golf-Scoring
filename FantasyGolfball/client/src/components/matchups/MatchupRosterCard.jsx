import { Table } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"
import { MatchupPlayerCard } from "./MatchupPlayerCard"
import { BlankPlayerCard } from "./BlankPlayerCard"
import { useMemo, useContext } from "react"
import { MatchupRevealContext } from "./MatchupRevealContext"



export const MatchupRosterCard = ({ slot, opponentRoster, displayWeekPoints}) => {
    const { roster, allScores } = useAppContext()
    const { revealedPositions } = useContext(MatchupRevealContext)
    const positions = ["QB1", "WR1", "WR2", "RB1", "RB2", "TE1", "FLEX", "K", "DEF"]
    const activeRoster  = slot ? roster : opponentRoster


    const calculateTotalPoints = (rosterPlayers) => {
        if (!allScores || !revealedPositions) {
            return { totalPoints: 0, penaltyPoints: 0}
        }

        let penaltyPoints = 0
        let totalPoints = 0

        // check and penalize for missing positions
        const rosterPositions = rosterPlayers.map(rp => rp.rosterPosition)

        const missingPositionCount = positions.filter(pos => 
            !rosterPositions.includes(pos)
        ).length

        if (missingPositionCount != 0) {
            penaltyPoints = penaltyPoints + (15 * missingPositionCount)
        }

        // checks existing players for penalty conditions (no score/bye, no stats)
        for (const rp of rosterPlayers) {
            if (rp.rosterPosition !== "bench" && revealedPositions.includes(rp.rosterPosition)) {
                const playerScore = allScores.find(s => s.playerId == rp.playerId && s.seasonWeek == displayWeekPoints.week)

                let playerPenalty = 0

                // penalizes no-scoring/bye weeks
                if (!playerScore) {
                    if (rp.player.position.positionId == 1) {
                        playerPenalty += 15
                    } else {
                        playerPenalty += 10
                    }
                }

                totalPoints += playerScore ? playerScore.points : 0

                // a spelling error generated much annoyance when testing the switch block
                // Penalizes 0 score IF NOT stats (difference between 2 - 2 = 0 and just 0)
                if (playerPenalty == 0 && playerScore?.points == 0) {
                    switch (rp.player.position.positionId) {
                        case 1: // QB
                            if (playerScore.yardsPassing == 0 &&
                                playerScore.yardsRushing == 0 &&
                                playerScore.attemptsPassing == 0 &&
                                playerScore.attemptsRushing == 0 &&
                                playerScore.fumbleLost == 0 &&
                                playerScore.interceptions == 0) {
                                    playerPenalty += 15
                                }
                            break
                        case 2: // WR
                        case 3: // RB
                        case 4: // TE
                            if (playerScore.yardsReceiving == 0 &&
                                playerScore.yardsRushing == 0 &&
                                playerScore.targets == 0 &&
                                playerScore.attemptsRushing == 0 &&
                                playerScore.receptions == 0 &&
                                playerScore.fumbleLost == 0) {
                                    playerPenalty += 10
                                }
                            break
                        case 5: // K
                            if (playerScore.fieldGoalAttempts == 0 &&
                                playerScore.fieldGoalsMade == 0 &&
                                playerScore.extraPointAttempts == 0 &&
                                playerScore.extraPointMade == 0) {
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
        activeRoster ? calculateTotalPoints(activeRoster.rosterPlayers) 
        : { totalPoints: 0, penaltyPoints: 0 }, 
        [activeRoster, allScores, displayWeekPoints.week, revealedPositions]
    )

    // Don't look at the github history for this component. Yikes.
    if (activeRoster && slot == true) {
        return ( //position, name, team, injury status, points
            <div>
                <h5>
                    {result.totalPoints.toFixed(2)} + {result.penaltyPoints}
                </h5>

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
                            const playerAtPos = activeRoster.rosterPlayers.filter((rp) => rp.rosterPosition == pos)

                            return playerAtPos.length > 0 ? (
                                playerAtPos.map(pap => (
                                    <MatchupPlayerCard
                                        rp={pap}
                                        key={pap.rosterPlayerId}
                                        slot={slot}
                                        displayWeekPoints={displayWeekPoints}
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
    } else if (slot == false) {
        return (
            <div>
                <h5>
                    {result.totalPoints.toFixed(2)} + {result.penaltyPoints}
                </h5>
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
                            const playerAtPos = activeRoster.rosterPlayers.filter((rp) => rp.rosterPosition == pos)

                            return playerAtPos.length > 0 ? (
                                playerAtPos.map(pap => (
                                    <MatchupPlayerCard
                                        rp={pap}
                                        key={pap.rosterPlayerId}
                                        slot={slot}
                                        displayWeekPoints={displayWeekPoints}
                                    />
                                ))
                            ) : (
                                <BlankPlayerCard slot={slot} position={pos} key={`blank-${pos}`}/>
                            )
                        })}
                    </tbody>
                </Table>
            </div>
        )} else {
        return (
            <div>loading...</div>
        )
    }
}