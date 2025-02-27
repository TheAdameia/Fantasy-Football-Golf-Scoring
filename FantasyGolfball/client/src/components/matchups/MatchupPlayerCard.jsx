

export const MatchupPlayerCard = ({ rp, slot }) => {

   if (slot && rp) {
    return (
        <tr>
            <th>
                {rp.rosterPosition}
            </th>
            <td>
                {rp.player.playerFirstName} {rp.player.playerLastName}
            </td>
            <td>
                -
            </td>
            <td>
                -
            </td>
            <td>
                0
            </td>
        </tr>
    )
   } else if (slot == false && rp) {
    return (
        <tr>
            <th>
                0
            </th>
            <td>
                -
            </td>
            <td>
                -
            </td>
            <td>
                {rp.player.playerFirstName} {rp.player.playerLastName}
            </td>
            <td>
                {rp.rosterPosition}
            </td>
        </tr>
    )
   } else {
    <div>
        loading...
    </div>
   }
}