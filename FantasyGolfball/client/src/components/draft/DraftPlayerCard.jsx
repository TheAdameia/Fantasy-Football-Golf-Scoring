import { useAppContext } from "../../contexts/AppContext"


export const DraftPlayerCard = ({ player }) => {
    // need to source data for previous season scores, if applicable
    const { loggedInUser } = useAppContext()

    // handle adding a player to the queue
    // handle drafting a player, with error handling for wrong turn

    return (
        <tr>
            <th>
                Rank
            </th>
            <td>
                {player.playerFirstName} {player.playerLastName}
            </td>
            <td>
                {player.position.positionShort}
            </td>
            <td>
                {player.status.statusType}
            </td>
            <td>
                Add to queue and draft buttons go here
            </td>
        </tr>
    )
}