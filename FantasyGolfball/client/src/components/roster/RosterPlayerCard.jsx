

export const RosterPlayerCard = ({ rp }) => {

    return (
        <tr>
            <th scope="row">
                {rp.player.position.positionShort}
            </th>
            <td>
                {rp.player.playerFirstName + " " + rp.player.playerLastName}
            </td>
            <td>
                Bye NYI
            </td>
            <td>
                uhhhh
            </td>
        </tr>
    )
}