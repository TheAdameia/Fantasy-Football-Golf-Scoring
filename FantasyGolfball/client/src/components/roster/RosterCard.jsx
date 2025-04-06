import { Table } from "reactstrap"
import { RosterPlayerCard } from "./RosterPlayerCard"
import { useAppContext } from "../../contexts/AppContext";
import "./Roster.css"
import { BlankPlayerCard } from "../matchups/BlankPlayerCard";
import { BlankRosterPlayerCard } from "./BlankRosterPlayerCard";


export const RosterCard = () => {
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
                            Select
                        </th>
                        <th>
                            Position
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
                    {roster.rosterPlayers.some((rp) => rp.rosterPosition === "QB1") ?
                        roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "QB1")
                            .map((rp) => {
                                return (
                                    <RosterPlayerCard
                                        rp={rp}
                                        key={`rp-${rp.rosterPlayerId}`}
                                    ></RosterPlayerCard>
                                )
                        }) : 
                        <BlankRosterPlayerCard position={"QB1"}/>
                    }
                    {roster.rosterPlayers.some((rp) => rp.rosterPosition === "WR1") ?
                        roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "WR1")
                            .map((rp) => {
                                return (
                                    <RosterPlayerCard
                                        rp={rp}
                                        key={`rp-${rp.rosterPlayerId}`}
                                    ></RosterPlayerCard>
                                )
                        }) : 
                        <BlankRosterPlayerCard position={"WR1"}/>
                    }
                    {roster.rosterPlayers.some((rp) => rp.rosterPosition === "WR2") ?
                        roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "WR2")
                            .map((rp) => {
                                return (
                                    <RosterPlayerCard
                                        rp={rp}
                                        key={`rp-${rp.rosterPlayerId}`}
                                    ></RosterPlayerCard>
                                )
                        }) : 
                        <BlankRosterPlayerCard position={"WR2"}/>
                    }
                    {roster.rosterPlayers.some((rp) => rp.rosterPosition === "RB1") ?
                        roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "RB1")
                            .map((rp) => {
                                return (
                                    <RosterPlayerCard
                                        rp={rp}
                                        key={`rp-${rp.rosterPlayerId}`}
                                    ></RosterPlayerCard>
                                )
                        }) : 
                        <BlankRosterPlayerCard position={"RB1"}/>
                    }
                    {roster.rosterPlayers.some((rp) => rp.rosterPosition === "RB2") ?
                        roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "RB2")
                            .map((rp) => {
                                return (
                                    <RosterPlayerCard
                                        rp={rp}
                                        key={`rp-${rp.rosterPlayerId}`}
                                    ></RosterPlayerCard>
                                )
                        }) : 
                        <BlankRosterPlayerCard position={"RB2"}/>
                    }
                    {roster.rosterPlayers.some((rp) => rp.rosterPosition === "TE1") ?
                        roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "TE1")
                            .map((rp) => {
                                return (
                                    <RosterPlayerCard
                                        rp={rp}
                                        key={`rp-${rp.rosterPlayerId}`}
                                    ></RosterPlayerCard>
                                )
                        }) : 
                        <BlankRosterPlayerCard position={"TE1"}/>
                    }
                    {roster.rosterPlayers.some((rp) => rp.rosterPosition === "FLEX") ?
                        roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "FLEX")
                            .map((rp) => {
                                return (
                                    <RosterPlayerCard
                                        rp={rp}
                                        key={`rp-${rp.rosterPlayerId}`}
                                    ></RosterPlayerCard>
                                )
                        }) : 
                        <BlankRosterPlayerCard position={"FLEX"}/>
                    }
                    {roster.rosterPlayers.some((rp) => rp.rosterPosition === "K") ?
                        roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "K")
                            .map((rp) => {
                                return (
                                    <RosterPlayerCard
                                        rp={rp}
                                        key={`rp-${rp.rosterPlayerId}`}
                                    ></RosterPlayerCard>
                                )
                        }) : 
                        <BlankRosterPlayerCard position={"K"}/>
                    }
                    {roster.rosterPlayers.some((rp) => rp.rosterPosition === "DEF") ?
                        roster.rosterPlayers
                            .filter((rp) => rp.rosterPosition === "DEF")
                            .map((rp) => {
                                return (
                                    <RosterPlayerCard
                                        rp={rp}
                                        key={`rp-${rp.rosterPlayerId}`}
                                    ></RosterPlayerCard>
                                )
                        }) : 
                        <BlankRosterPlayerCard position={"DEF"}/>
                    }
                </tbody>
                <tbody className="table-divider">
                    {roster.rosterPlayers
                        .filter((rp) => rp.rosterPosition === "bench")
                        .map((rp) => {
                        return (
                            <RosterPlayerCard
                                rp={rp}
                                key={`rp-${rp.rosterPlayerId}`}
                            ></RosterPlayerCard>
                        )
                    })}
                </tbody>
            </Table>
        </div>
    )
}