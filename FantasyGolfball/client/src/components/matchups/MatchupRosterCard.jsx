import { Table } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"
import { MatchupPlayerCard } from "./MatchupPlayerCard"
import { BlankPlayerCard } from "./BlankPlayerCard"
import { useMemo } from "react"


export const MatchupRosterCard = ({ slot, opponentRoster, displayWeekPoints}) => {
    const { roster, allScores, selectedLeague } = useAppContext()

    const calculateTotalPoints = (rosterPlayers) => {
        return rosterPlayers.reduce((total, rp) => {
            if (rp.rosterPosition != "bench" ) {
                const playerScore = allScores.find(s => s.playerId == rp.playerId && s.seasonWeek == displayWeekPoints.week)
            return total + (playerScore ? playerScore.points : 0)
            }
            return total
        }, 0)
    }

    const userTotalPoints = useMemo(() => 
                                slot && roster ? 
                                calculateTotalPoints(roster.rosterPlayers) 
                                : 0, [roster, allScores, displayWeekPoints.week])
    const opponentTotalPoints = useMemo(() => 
                                !slot && opponentRoster ? 
                                calculateTotalPoints(opponentRoster.rosterPlayers) 
                                : 0, [opponentRoster, allScores, displayWeekPoints.week])

    
    if (slot == true && roster) {
        return ( //position, name, team, injury status, points
            <div>
                <h5>{displayWeekPoints.display && selectedLeague.season.currentWeek ? userTotalPoints.toFixed(2) : "0"}</h5>
                <Table striped>
                    <thead>
                        <tr>
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
                        {roster.rosterPlayers.some((rp) => rp.rosterPosition === "QB1") ? ( roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "QB1")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="QB1"/>
                        )}
                        {roster.rosterPlayers.some((rp) => rp.rosterPosition === "WR1") ? ( roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "WR1")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="WR1"/>
                        )}
                        {roster.rosterPlayers.some((rp) => rp.rosterPosition === "WR2") ? ( roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "WR2")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="WR2"/>
                        )}
                        {roster.rosterPlayers.some((rp) => rp.rosterPosition === "RB1") ? ( roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "RB1")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="RB1"/>
                        )}
                        {roster.rosterPlayers.some((rp) => rp.rosterPosition === "RB2") ? ( roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "RB2")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="RB2"/>
                        )}
                        {roster.rosterPlayers.some((rp) => rp.rosterPosition === "TE1") ? ( roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "TE1")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="TE1"/>
                        )}
                        {roster.rosterPlayers.some((rp) => rp.rosterPosition === "FLEX") ? ( roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "FLEX")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="FLEX"/>
                        )}
                        {roster.rosterPlayers.some((rp) => rp.rosterPosition === "K") ? ( roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "K")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="K"/>
                        )}
                        {roster.rosterPlayers.some((rp) => rp.rosterPosition === "DEF") ? ( roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "DEF")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="DEF"/>
                        )}
                    </tbody>
                </Table>
            </div>
        )
    } else if (slot == false && opponentRoster) {
        return (
            <div>
                <h5>{displayWeekPoints.display && selectedLeague.season.currentWeek ? opponentTotalPoints.toFixed(2) : "0"}</h5>
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
                        </tr>
                    </thead>
                    <tbody>
                        {opponentRoster.rosterPlayers.some((rp) => rp.rosterPosition === "QB1") ? ( opponentRoster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "QB1")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="QB1"/>
                        )}
                        {opponentRoster.rosterPlayers.some((rp) => rp.rosterPosition === "WR1") ? ( opponentRoster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "WR1")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="WR1"/>
                        )}
                        {opponentRoster.rosterPlayers.some((rp) => rp.rosterPosition === "WR2") ? ( opponentRoster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "WR2")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="WR2"/>
                        )}
                        {opponentRoster.rosterPlayers.some((rp) => rp.rosterPosition === "RB1") ? ( opponentRoster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "RB1")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="RB1"/>
                        )}
                        {opponentRoster.rosterPlayers.some((rp) => rp.rosterPosition === "RB2") ? ( opponentRoster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "RB2")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="RB2"/>
                        )}
                        {opponentRoster.rosterPlayers.some((rp) => rp.rosterPosition === "TE1") ? ( opponentRoster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "TE1")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="TE1"/>
                        )}
                        {opponentRoster.rosterPlayers.some((rp) => rp.rosterPosition === "FLEX") ? ( opponentRoster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "FLEX")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="FLEX"/>
                        )}
                        {opponentRoster.rosterPlayers.some((rp) => rp.rosterPosition === "K") ? ( opponentRoster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "K")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="K"/>
                        )}
                        {opponentRoster.rosterPlayers.some((rp) => rp.rosterPosition === "DEF") ? ( opponentRoster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "DEF")
                            .map((rp) => (
                                <MatchupPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    slot={slot}
                                    displayWeekPoints={displayWeekPoints}
                                ></MatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="DEF"/>
                        )}
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