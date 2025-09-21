import { Table } from "reactstrap"
import { BlankPlayerCard } from "./BlankPlayerCard"
import { SavedMatchupPlayerCard } from "./SavedMatchupPlayerCard"


export const SavedMatchupRosterCard = ({ matchupUser, slot, week }) => {


    
    const getTotalPoints = (matchupUser) => {
        return matchupUser.matchupUserSavedPlayers
        ?.filter((musp) => musp.rosterPlayerPosition?.toLowerCase() != "bench")
        .reduce((total, musp) => {
            return total + (musp.scoring?.points ?? 0)
        }, 0) ?? 0
    }

    // return (<div>bubkis</div>)

    if (slot == true) {
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
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "QB1") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "QB1")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="QB1"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "WR1") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "WR1")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="WR1"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "WR2") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "WR2")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="WR2"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "RB1") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "RB1")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="RB1"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "RB2") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "RB2")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="RB2"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "TE1") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "TE1")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="TE1"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "FLEX") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "FLEX")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="FLEX"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "K") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "K")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="K"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "DEF") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "DEF")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="DEF"/>
                        )}
                    </tbody>
                </Table>
            </div>
        )
    } else if (slot == false) {
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
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "QB1") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "QB1")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="QB1"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "WR1") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "WR1")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="WR1"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "WR2") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "WR2")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="WR2"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "RB1") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "RB1")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="RB1"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "RB2") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "RB2")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="RB2"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "TE1") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "TE1")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="TE1"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "FLEX") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "FLEX")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="FLEX"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "K") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "K")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
                            ))
                        ) : (
                            <BlankPlayerCard slot={slot} position="K"/>
                        )}
                        {matchupUser.matchupUserSavedPlayers.some((musp) => musp.rosterPlayerPosition === "DEF") ? ( matchupUser.matchupUserSavedPlayers
                            .filter((musp) => musp.rosterPlayerPosition === "DEF")
                            .map((musp) => (
                                <SavedMatchupPlayerCard
                                    musp={musp}
                                    key={`musp-${musp.playerId}`}
                                    slot={slot}
                                    week={week}
                                ></SavedMatchupPlayerCard>
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