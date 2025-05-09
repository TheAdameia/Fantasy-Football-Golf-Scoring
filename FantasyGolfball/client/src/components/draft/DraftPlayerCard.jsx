import { useAppContext } from "../../contexts/AppContext"


export const DraftPlayerCard = ({ player, setSelectedPlayer }) => {
    // need to source data for previous season scores, if applicable
    const { loggedInUser } = useAppContext()

    return (
        <tr>
            <th>
                
            </th>
            <td>
                {player.playerFirstName} {player.playerLastName}
            </td>
            <td>
                {player.position.positionShort}
            </td>
            <td>
                {player.playerStatuses[0].status.statusType}
            </td>
            <td>
                NYI
            </td>
            <td>
                <button onClick={() => setSelectedPlayer(player)}>View</button>
            </td>
        </tr>
    )
}