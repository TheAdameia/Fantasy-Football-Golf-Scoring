import { useAppContext } from "../../contexts/AppContext"
import { CalculateTotalPoints } from "../scoring/CalculateTotalPoints"


export const MatchupRecap = ({ weekId }) => {
    const { matchups, allScores, selectedLeague } = useAppContext()

    // take all the matchups, filter to a certain week, display them

    return (
        <div>
            {matchups ? matchups
            .filter((matchup) => matchup.weekId === weekId)
            .map((matchup) => {
                return (
                    <div key={matchup.matchupId} className="matchup">
                        {CalculateTotalPoints(matchup.matchupUsers[0].userProfileId, allScores, selectedLeague)} points 
                        {matchup.matchupUsers[0].userProfileDTO.userName} vs. 
                        {matchup.matchupUsers[1].userProfileDTO.userName} 
                        {CalculateTotalPoints(matchup.matchupUsers[1].userProfileId, allScores, selectedLeague)} points
                    </div>
                )
            }) : <div></div>}
        </div>
    )
}