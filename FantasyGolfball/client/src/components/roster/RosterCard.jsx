import { Table } from "reactstrap"
import { RosterPlayerCard } from "./RosterPlayerCard"
import { useAppContext } from "../../contexts/AppContext";


export const RosterCard = ({ scores }) => {
    const { roster } = useAppContext()
    
    if (!roster || !Array.isArray(roster.rosterPlayers)) {
        return <div>No roster data available</div>;
    }

    // I have to wonder if there's a computationally more efficient way to pass scores that sorts them first here.
    
    return (
        <div>
            <h4>Stuff goes here. Make it longer so it doesn't look odd</h4>
            <Table>
                <thead>
                    <tr>
                        <th>
                            pos ddown
                        </th>
                        <th>
                            Active
                        </th>
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
                        <th>
                            drop
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {roster.rosterPlayers.map((rp) => {
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