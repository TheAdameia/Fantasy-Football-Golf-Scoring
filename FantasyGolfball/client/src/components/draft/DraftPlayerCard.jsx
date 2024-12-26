import { useAppContext } from "../../contexts/AppContext"


export const DraftPlayerCard = ({ player, setSelectedPlayer }) => {
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
                <button onClick={setSelectedPlayer(player)}>View Player</button>
            </td>
        </tr>
    )
}