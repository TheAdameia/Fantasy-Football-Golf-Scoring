import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"


export const PostSeasonPlayerDisplay = ({user, index, playerId}) => {
    const { selectedLeague, players } = useAppContext()
    const [player, setPlayer] = useState()
    const drafter = selectedLeague.leagueUsers.find(lu => lu.userProfileId == user)


    useEffect(() => {
        if (players && playerId) {
            const foundPlayer = players.find(p => p.playerId == playerId)
            setPlayer(foundPlayer)
        }
    }, [playerId, players])

    if (player) {
        return (
            <tr>
                <td># {index + 1}</td>
                <td>{drafter.userProfile.userName}</td>
                <td>{player.playerFullName}, {player.position.positionShort}, {player.playerTeams[0].team.teamName}</td>
            </tr>
        )
    }
   
}