

export const RosterPlayerCard = ({ rp, scores }) => {
    let playerScore = 0;

    for (scores in scores){
        if (score.Includes(rp.player.playerId))
        {
            playerScore = score.points
        }
    }

    return (
        <tr>
            <th scope="row">
                {rp.player.position.positionShort}
            </th>
            <td>
                {rp.player.playerFirstName + " " + rp.player.playerLastName}
            </td>
            <td>
                Week 
            </td>
            <td>
                {playerScore}
            </td>
        </tr>
    )
}