import { useAppContext } from "../../contexts/AppContext"
import { MatchupRosterCard } from "./MatchupRosterCard"


export const MatchupCard = ({ matchup }) => {
    const { loggedInUser, selectedLeague } = useAppContext()
    const opponent = matchup.matchupUsers.find((user) => user.userProfileId !== loggedInUser.id)
    const opponentLeagueUser = selectedLeague.leagueUsers.find((lu) => lu.userProfileId === opponent.userProfileId)
    const opponentRoster = opponentLeagueUser.roster
    
      
    return (
        <div>
            <div>
                <div>User's team #{loggedInUser.id}
                    <MatchupRosterCard slot={true}/>
                </div>
                <div>Opponent's team #{opponent.userProfileId}
                    <MatchupRosterCard slot={false} opponentRoster={opponentRoster}/>
                </div>
            </div>
        </div>
    )
}