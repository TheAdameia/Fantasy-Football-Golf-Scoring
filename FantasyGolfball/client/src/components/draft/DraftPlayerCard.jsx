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
        if (!confirmCheck) {
            handleDraftPlayer(playerId)
            return
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
                {player.playerTeams[0].team.abbreviation}
            </td>
            <td>
                <button onClick={() => setSelectedPlayer(player)}>Pin</button>
            </td>
            <td>
                <button onClick={() => ConfirmDraft(player.playerId)}>Draft</button>
            </td>
        </tr>
    )
}