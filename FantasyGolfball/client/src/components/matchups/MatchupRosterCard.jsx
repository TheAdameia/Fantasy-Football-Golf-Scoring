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
            return 
        }
        return rosterPlayers.reduce((total, rp) => {
            if (rp.rosterPosition != "bench" && revealedPositions.includes(rp.rosterPosition)) {
                const playerScore = allScores.find(s => s.playerId == rp.playerId && s.seasonWeek == displayWeekPoints.week)
            return total + (playerScore ? playerScore.points : 0)
            }
            return total
        }, 0)
    }

    const userTotalPoints = useMemo(() => 
        activeRoster ? 
        calculateTotalPoints(activeRoster.rosterPlayers) 
        : 0, [activeRoster, allScores, displayWeekPoints.week, revealedPositions]
    )

    // Don't look at the github history for this component. Yikes.
    if (activeRoster && slot == true) {
        return ( //position, name, team, injury status, points
            <div>
                <h5>{userTotalPoints?.toFixed(2)}</h5>
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
                <h5>{userTotalPoints?.toFixed(2)}</h5>
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