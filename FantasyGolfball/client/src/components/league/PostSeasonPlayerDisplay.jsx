import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { CheckPenalty } from "../widgets/CheckPenalty"


export const PostSeasonPlayerDisplay = ({user, index, playerId}) => {
    const { selectedLeague, players, allScores } = useAppContext()
    const [player, setPlayer] = useState()
    const [filteredScores, setFilteredSCores] = useState()
    const [totalWithPenalties, setTotalWithPenalties] = useState()
    const [numberOfPenalties, SetNumberOfPenalties] = useState(0)
    const drafter = selectedLeague.leagueUsers.find(lu => lu.userProfileId == user)

    const GetTotalWithPenalties = () => {
        let totalPoints = 0
        let penaltyCount = 0

        for (const score of filteredScores) {
            const penalty = CheckPenalty(player, score)
            totalPoints += score.points
            totalPoints += penalty
            if (penalty > 0) {
                penaltyCount++
            }
        }

        // accounts for weeks with no Scoring
        if (filteredScores.length < selectedLeague.season.seasonWeeks) {
            const numberOfMissingScore = selectedLeague.season.seasonWeeks - filteredScores.length
            const additionalPenalty = (numberOfMissingScore) * 15
            totalPoints += additionalPenalty
            penaltyCount += numberOfMissingScore
        }

        const averageTotal = (totalPoints/selectedLeague.season.seasonWeeks)
        setTotalWithPenalties(averageTotal)
        SetNumberOfPenalties(penaltyCount)
    }


    useEffect(() => {
        if (players && playerId) {
            const foundPlayer = players.find(p => p.playerId == playerId)
            setPlayer(foundPlayer)
        }
    }, [playerId, players])

    useEffect(() => {
        if (allScores) {
            const filterScore = allScores.filter(s => s.playerId == playerId)
            setFilteredSCores(filterScore)
        }
    }, [allScores, playerId])

    useEffect(() => {
        if (filteredScores && player) {
            GetTotalWithPenalties()
        }
    }, [filteredScores, player])

    if (player && filteredScores && totalWithPenalties) {
        return (
            <tr>
                <td># {index + 1}</td>
                <td>{drafter.userProfile.userName}</td>
                <td>{player.playerFullName}, {player.position.positionShort}, {player.playerTeams[0].team.teamName}</td>
                <td>{totalWithPenalties.toFixed(2)}, {numberOfPenalties}</td>
            </tr>
        )
    }
   
}