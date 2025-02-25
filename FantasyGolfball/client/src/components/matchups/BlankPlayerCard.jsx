

export const BlankPlayerCard = ({ slot, position}) => {

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
                    -
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
                    {position}
                </td>
            </tr>
        )
    }
}