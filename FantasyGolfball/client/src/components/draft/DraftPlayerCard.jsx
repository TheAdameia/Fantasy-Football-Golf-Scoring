import { useContext } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { DraftContext } from "./DraftPage"


export const DraftPlayerCard = ({ player, setSelectedPlayer, confirmCheck }) => {
    // need to source data for previous season scores, if applicable
    const { loggedInUser, selectedLeague, getAndSetRoster } = useAppContext()
    const { connection, currentTurn } = useContext(DraftContext)


    // handle drafting a player
    const handleDraftPlayer = async (playerId) => {
        if (selectedLeague.isDraftComplete) {
            window.alert("The draft has been completed!")
        }

        if (connection && currentTurn === loggedInUser.id && selectedLeague.isDraftComplete == false) {
            try {
                await connection.invoke("SelectPlayer", selectedLeague.leagueId, loggedInUser.id, playerId, selectedLeague.maxRosterSize)
                getAndSetRoster()
            } catch (error) {
                console.error("Error selecting player:", error)
            }
        } else {
            console.warn("It's not your turn!")
        }
    }

    const ConfirmDraft = (playerId) => {
        if (confirmCheck) {
            handleDraftPlayer(playerId)
        }
        
        const confirmed = window.confirm(`Draft ${player.playerFullName}?`)
        if (confirmed) {
           handleDraftPlayer(playerId)
        } else {
            return
        }
    }

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
                
            </td>
            <td>
                NYI
            </td>
            <td>
                <button onClick={() => setSelectedPlayer(player)}>View</button>
            </td>
            <td>
                <button onClick={() => ConfirmDraft(player.playerId)}>Draft</button>
            </td>
        </tr>
    )
}