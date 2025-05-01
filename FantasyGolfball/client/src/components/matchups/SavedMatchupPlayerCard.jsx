export const SavedMatchupPlayerCard = ({ musp, slot }) => {

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
                    -
                </td>
                <td>
                    -
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
                    -
                </td>
                <td>
                    -
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