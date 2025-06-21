export const SavedMatchupPlayerCard = ({ musp, slot, week }) => {

    if (slot) {
        return (
            <tr>
                <th>
                    {musp.rosterPlayerPosition}
                </th>
                <td>
                    {musp.player.playerFullName}
                </td>
                <td>
                    {musp.player.playerTeams[0].team.teamName}
                </td>
                <td>
                    {musp.player.playerStatuses[0].status.statusType}
                </td>
                <td>
                    {musp.scoring.points}
                </td>
            </tr>
        )
       } else if (slot == false) {
        return (
            <tr>
                <td>
                    {musp.scoring.points}
                </td>
                <td>
                    {musp.player.playerStatuses[0].status.statusType}
                </td>
                <td>
                    {musp.player.playerTeams[0].team.teamName}
                </td>
                <td>
                    {musp.player.playerFullName}
                </td>
                <td>
                    {musp.rosterPlayerPosition}
                </td>
            </tr>
        )
       } else {
        <div>
            loading...
        </div>
       }
}