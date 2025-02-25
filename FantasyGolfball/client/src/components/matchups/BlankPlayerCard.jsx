

export const BlankPlayerCard = ({ slot, position}) => {
    // this also needs slot returns

    // drill the key to display what kind of empty position?

    if (slot) {
        return (
            <tr>
                <th>
                    {position}
                </th>
                <td>
                    -
                </td>
                <td>
                    -
                </td>
                <td>
                    -
                </td>
                <td>
                    -
                </td>
            </tr>
        )
    } else {
        return (
            <tr>
                <th>

                </th>
                <td>

                </td>
                <td>

                </td>
                <td>

                </td>
                <td>
                    {position}
                </td>
            </tr>
        )
    }
}