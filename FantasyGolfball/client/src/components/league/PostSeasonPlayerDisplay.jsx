import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"


export const PostSeasonPlayerDisplay = ({user, index, playerId}) => {
    const { selectedLeague, players, allScores } = useAppContext()
    const [player, setPlayer] = useState()
    const [filteredScores, setFilteredSCores] = useState()
    const [totalWithPenalties, setTotalWithPenalties] = useState()
    const drafter = selectedLeague.leagueUsers.find(lu => lu.userProfileId == user)

    const GetTotalWithPenalties = () => {
        let totalPoints = 0
        for (const score of filteredScores) {
            // insert penalty check here
            totalPoints += score.points
        }

        // accounts for weeks with no Scoring
        if (filteredScores.length() < selectedLeague.season.seasonWeeks) {
            const additionalPenalty = (selectedLeague.season.seasonWeeks - filteredScores.length()) * 15
            totalPoints += additionalPenalty
        }
        setTotalWithPenalties(totalPoints)
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