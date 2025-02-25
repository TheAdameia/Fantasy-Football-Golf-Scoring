import { useAppContext } from "../../contexts/AppContext"
import { MatchupRosterCard } from "./MatchupRosterCard"
import "./matchups.css"


export const MatchupCard = ({ matchup }) => {
    const { loggedInUser, selectedLeague } = useAppContext()
    const opponent = matchup.matchupUsers.find((user) => user.userProfileId !== loggedInUser.id)
    const opponentLeagueUser = selectedLeague.leagueUsers.find((lu) => lu.userProfileId === opponent.userProfileId)
    const opponentRoster = opponentLeagueUser.roster
    // console.log(opponentLeagueUser)
    
      
    return (
        <div className="matchup-container">
            {/* <div>{loggedInUser.userName}'s team
                <MatchupRosterCard slot={true}/>
            </div> */}
            <div>{opponent.userProfileId}'s team
                <MatchupRosterCard slot={false} opponentRoster={opponentRoster}/>
            </div>
        </div>
    )
}