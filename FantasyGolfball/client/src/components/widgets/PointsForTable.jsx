import { Table } from "reactstrap";
import "./widgets.css"

export const PointsForTable = ({ matchups, selectedLeague }) => {

    function sumPointsForUser(matchups, userId) {
        return matchups.reduce((total, matchup) => {
          const user = matchup.matchupUsers.find(mu => mu.userProfileId === userId);
          if (!user) return total;
      
          const points = user.matchupUserSavedPlayers
          .filter((player) => player.rosterPlayerPosition?.toLowerCase() != "bench")
          .reduce((sum, player) => {
            return sum + (player.scoring?.points || 0);
          }, 0);
      
          return total + points;
        }, 0);
      }

      if (selectedLeague?.leagueUsers && matchups) {
        return (
            <div className="widgets-table-container">
                <div>Points For</div>
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
                                    <td>{sumPointsForUser(matchups, lu.userProfileId).toFixed(2)}</td>
                                </tr>
                            )
                        })}
                    </tbody>
                </Table>
            </div>
        )
    }
}