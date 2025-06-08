import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { MatchupRosterCard } from "./MatchupRosterCard"
import "./matchups.css"


export const MatchupCard = ({ matchup, week }) => {
    const { loggedInUser, selectedLeague } = useAppContext()
    const opponent = matchup.matchupUsers.find((user) => user.userProfileId !== loggedInUser.id)
    const opponentLeagueUser = selectedLeague.leagueUsers.find((lu) => lu.userProfileId === opponent.userProfileId)
    const opponentRoster = opponentLeagueUser.roster
    const [displayWeekPoints, setDisplayWeekPoints] = useState({
        week: week,
        display: false
    })
    
    useEffect(() => {
        if (matchup) {
            if (matchup.winnerId != 0 && matchup.winnerId != null) {
                let newDisplay = {...displayWeekPoints}
                newDisplay.display = true
                setDisplayWeekPoints(newDisplay)
            }
        }
    }, [matchup])

    
    if (!matchup) {
        return (
            <div>Error: Invalid</div>
        )
    }

    return (
        <div className="parent-container">
            <div className="matchup-container">
                <div>{loggedInUser.userName}'s team
                    <MatchupRosterCard slot={true} displayWeekPoints={displayWeekPoints}/>
                </div>
                <div className="vertical-divider"></div>
                <div>{opponentLeagueUser.userProfile.userName}'s team
                    <MatchupRosterCard slot={false} opponentRoster={opponentRoster} displayWeekPoints={displayWeekPoints}/>
                </div>
            </div>
        </div>
    )
}