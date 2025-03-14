import { Table } from "reactstrap"
import { RosterPlayerCard } from "./RosterPlayerCard"
import { useAppContext } from "../../contexts/AppContext";
import "./Roster.css"


export const RosterCard = ({ scores }) => {
    const { roster } = useAppContext()
    
    if (!roster || !Array.isArray(roster.rosterPlayers)) {
        return <div>No roster data available</div>;
    }

    return (
        <div>
            <Table>
                <thead>
                    <tr>
                        <th>
                            pos ddown
                        </th>
                        <th>
                            Activity
                        </th>
                        <th>
                            Status
                        </th>
                        <th>
                            Pos
                        </th>
                        <th>
                            Team
                        </th>
                        <th>
                            Player
                        </th>
                        <th>
                            Bye Week
                        </th>
                        <th>
                            Points
                        </th>
                        <th>
                            drop
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {roster.rosterPlayers
                        .filter((rp) => rp.rosterPosition === "QB1")
                        .map((rp) => {
                            return (
                                <RosterPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    scores={scores}
                                ></RosterPlayerCard>
                            )
                    })}
                    {roster.rosterPlayers
                        .filter((rp) => rp.rosterPosition === "WR1")
                        .map((rp) => {
                            return (
                                <RosterPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    scores={scores}
                                ></RosterPlayerCard>
                            )
                    })}
                    {roster.rosterPlayers
                        .filter((rp) => rp.rosterPosition === "WR2")
                        .map((rp) => {
                            return (
                                <RosterPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    scores={scores}
                                ></RosterPlayerCard>
                            )
                    })}
                    {roster.rosterPlayers
                        .filter((rp) => rp.rosterPosition === "RB1")
                        .map((rp) => {
                            return (
                                <RosterPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    scores={scores}
                                ></RosterPlayerCard>
                            )
                    })}
                    {roster.rosterPlayers
                        .filter((rp) => rp.rosterPosition === "RB2")
                        .map((rp) => {
                            return (
                                <RosterPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    scores={scores}
                                ></RosterPlayerCard>
                            )
                    })}
                    {roster.rosterPlayers
                        .filter((rp) => rp.rosterPosition === "TE1")
                        .map((rp) => {
                            return (
                                <RosterPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    scores={scores}
                                ></RosterPlayerCard>
                            )
                    })}
                    {roster.rosterPlayers
                        .filter((rp) => rp.rosterPosition === "FLEX")
                        .map((rp) => {
                            return (
                                <RosterPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    scores={scores}
                                ></RosterPlayerCard>
                            )
                    })}
                    {roster.rosterPlayers
                        .filter((rp) => rp.rosterPosition === "K")
                        .map((rp) => {
                            return (
                                <RosterPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    scores={scores}
                                ></RosterPlayerCard>
                            )
                    })}
                    {roster.rosterPlayers
                        .filter((rp) => rp.rosterPosition === "DEF")
                        .map((rp) => {
                            return (
                                <RosterPlayerCard
                                    rp={rp}
                                    key={`rp-${rp.rosterPlayerId}`}
                                    scores={scores}
                                ></RosterPlayerCard>
                            )
                    })}
                </tbody>
                <tbody className="table-divider">
                    {roster.rosterPlayers
                        .filter((rp) => rp.rosterPosition === "bench")
                        .map((rp) => { // change to map only RP that are benched
                        return (
                            <RosterPlayerCard
                                rp={rp}
                                key={`rp-${rp.rosterPlayerId}`}
                                scores={scores}
                            ></RosterPlayerCard>
                        )
                    })}
                </tbody>
            </Table>
        </div>
    )
}