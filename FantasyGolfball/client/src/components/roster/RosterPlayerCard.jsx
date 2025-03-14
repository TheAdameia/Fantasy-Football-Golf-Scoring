import { useAppContext } from "../../contexts/AppContext"
import { DeleteRosterPlayer } from "../../managers/rosterPlayerManager"
import { RosterPositionDropdown } from "./RosterPositionDropdown"


export const RosterPlayerCard = ({ rp, scores }) => {
    const  { getAndSetRoster } = useAppContext()


    const HandleDropPlayer = (rosterPlayerId) => {
        DeleteRosterPlayer(rosterPlayerId)
    }

    const ConfirmDrop = (rosterPlayerId) => {
        const confirmed = window.confirm(`Are you sure you want to drop ${rp.player.playerFirstName} ${rp.player.playerLastName}?`)
        if (confirmed) {
            HandleDropPlayer(rosterPlayerId)
            getAndSetRoster()
        } else {
            return
        }
    }

    let playerScore = 0;

    if (scores != null) {
        for (const score of scores){
            if (score.playerId == rp.playerId)
            {
                playerScore = score.points
            }
        }
    }
    

    return (
        <tr>
            <th scope="row">
                <RosterPositionDropdown
                    rp={rp}>

                </RosterPositionDropdown>
            </th>
            <td>
                {rp.rosterPosition}
            </td>
            <td>
                {rp.player.status.statusType}
            </td>
            <td>
                {rp.player.position.positionShort}
            </td>
            <td>
                -
            </td>
            <td>
                {rp.player.playerFirstName + " " + rp.player.playerLastName}
            </td>
            <td>
                Week 
            </td>
            <td>
                {playerScore}
            </td>
            <td>
                <button onClick={() => ConfirmDrop(rp.rosterPlayerId)}>-</button>
            </td>
        </tr>
    )
}