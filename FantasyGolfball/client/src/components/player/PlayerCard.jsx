import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { GetByPlayer } from "../../managers/scoringManager"

export const PlayerCard = ({ player }) => {
    const [scores, setScores] = useState()
    const [weekScore, setWeekScore] = useState()
    const [seasonTotal, setSeasonTotal] = useState()
    const { globalWeek, roster } = useAppContext()

    const getAndSetScores = () => {
        GetByPlayer(player.playerId).then(setScores)
    }

    useEffect(() => {
        getAndSetScores()
    }, [player])

    useEffect(() => {
        if (scores != null){
            const thisWeekScore = scores.find(s => s.seasonWeek == globalWeek)
            setWeekScore(thisWeekScore)

            let total = scores.reduce((sum, s) => sum + s.points, 0)
            let fixedTotal = total.toFixed(1)
            setSeasonTotal(fixedTotal)
        }
    }, [scores])

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
                {player.status.statusType}
            </td>
            <td>
                NYI
            </td>
            <td>
                {weekScore ? weekScore.points : 0}
            </td>
            <td>
                {seasonTotal ? seasonTotal : 0}
            </td>
            <td>
                Add/drop button goes here
                {/* {roster.includes(player) ? <button>-</button> : <div></div>} */}
            </td>
        </tr>
    )
}