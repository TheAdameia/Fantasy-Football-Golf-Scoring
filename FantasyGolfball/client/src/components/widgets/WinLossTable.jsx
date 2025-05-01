import { Table } from "reactstrap"
import "./widgets.css"


export const WinLossTable = ({selectedLeague, matchups}) => {


    function getWinLoss(matchups, userId) {
        let wins = 0;
        let losses = 0;
      
        for (const matchup of matchups) {
          const isUserInMatchup = matchup.matchupUsers.some(mu => mu.userProfileId === userId);
          if (!isUserInMatchup || matchup.winnerId === null) continue;
      
          if (matchup.winnerId === userId) {
            wins++;
          } else {
            losses++;
          }
        }
      
        return { wins, losses };
      }
      

    if (selectedLeague?.leagueUsers && matchups) {
        return (
            <div className="widgets-table-container">
                <div>Win/Loss</div>
                <Table>
                    <thead>
                        <tr>
                            <th>User</th>
                            <th>W</th>
                            <th>L</th>
                        </tr>
                    </thead>
                    <tbody>
                        {selectedLeague.leagueUsers.map((lu) => {
                            let WinLoss = getWinLoss(matchups, lu.userProfileId)
                            return (
                                <tr key={lu.userProfileId}>
                                    <td>{lu.userProfile.userName}</td>
                                    <td>{WinLoss.wins}</td>
                                    <td>{WinLoss.losses}</td>
                                </tr>
                            )
                        })}
                    </tbody>
                </Table>
            </div>
        )
    }
}