import { Table } from "reactstrap"
import { RosterPlayerCard } from "./RosterPlayerCard"


export const RosterCard = ({ roster }) => {
    
    if (!roster || !Array.isArray(roster.rosterPlayers)) {
        return <div>No roster data available</div>;
    }
    
    return (
        <div>
            <h4>Stuff goes here. Make it longer so it doesn't look odd</h4>
            <Table>
                <thead>
                    <tr>
                        <th>
                            Pos
                        </th>
                        <th>
                            Player
                        </th>
                        <th>
                            Bye NYI
                        </th>
                        <th>
                            Points
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {roster.rosterPlayers.map((rp) => {
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