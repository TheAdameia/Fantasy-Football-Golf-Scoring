import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"


export const PostSeasonPlayerDisplay = ({user, index, playerId}) => {
    const { players } = useAppContext()
    const [player, setPlayer] = useState()

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
                <td>User {user}</td>
                <td>{player.playerFullName}</td>
            </tr>
        )
    }
   
}