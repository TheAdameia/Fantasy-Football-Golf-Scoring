import { Table } from "reactstrap";
import "./widgets.css"

export const PointsAgainstTable = ({ matchups, selectedLeague }) => {

    function sumPointsForOpponents(matchups, userId) {
        return matchups.reduce((total, matchup) => {
            const users = matchup.matchupUsers;
            const userIndex = users.findIndex(mu => mu.userProfileId === userId);
            if (userIndex === -1 || users.length !== 2) return total;

            const opponent = users[1 - userIndex];
            const opponentPoints = opponent.matchupUserSavedPlayers
            .filter((player) => player.rosterPlayerPosition?.toLowerCase() != "bench")
            .reduce((sum, player) => {
            return sum + (player.scoring?.points || 0);
            }, 0);

            return total + opponentPoints;
        }, 0);
    }


    if (selectedLeague?.leagueUsers && matchups) {
        return (
            <div className="widgets-table-container">
                <div>Points Against</div>
                <Table>
                    <thead>
                        <tr>
                            <th>User</th>
                            <th>Total</th>
                        </tr>
                    </thead>
                    <tbody>
                        {selectedLeague.leagueUsers.map((lu) => {
                            return (
                                <tr key={lu.userProfileId}>
                                    <td>{lu.userProfile.userName}</td>
                                    <td>{sumPointsForOpponents(matchups, lu.userProfileId).toFixed(2)}</td>
                                </tr>
                            )
                        })}
                    </tbody>
                </Table>
            </div>
        )
    }
}