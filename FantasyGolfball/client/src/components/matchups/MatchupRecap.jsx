import { useAppContext } from "../../contexts/AppContext"
import "./matchups.css"

export const MatchupRecap = ({ weekId }) => {
    const { matchups } = useAppContext()

    const getTotalPoints = (matchupUser) => {
        return matchupUser.matchupUserSavedPlayers
        ?.filter((musp) => musp.rosterPlayerPosition?.toLowerCase() != "bench")
        .reduce((total, musp) => {
            return total + (musp.scoring?.points ?? 0)
        }, 0) ?? 0
    }

    return (
        <div>
            <div className="matchup-recap-announcer">Week {weekId} Matchups</div>
            {matchups ? matchups
            .filter((matchup) => matchup.weekId === weekId)
            .map((matchup) => {
                const mu0Score = getTotalPoints(matchup.matchupUsers[0])
                const mu1Score = getTotalPoints(matchup.matchupUsers[1])
                return (
                    <div 
                        key={matchup.matchupId}
                        className="matchup-recap-container"
                    >
                        <div className="matchup-recap-item">
                        {mu0Score.toFixed(2)} {matchup.matchupUsers[0].userProfileDTO.userName} vs. {matchup.matchupUsers[1].userProfileDTO.userName} {mu1Score.toFixed(2)}</div>
                    </div>
                )
            }) : <div></div>}
        </div>
    )
}