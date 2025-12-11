

export const BlankPlayerCard = ({ slot, position}) => {

    if (slot) {
        return (
            <tr>
                <td>
                    
                </td>
                <td>
                    {position}
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
                <td>

                </td>
            </tr>
        )
    }
}