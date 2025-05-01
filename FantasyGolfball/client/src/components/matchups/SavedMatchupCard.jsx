import "./matchups.css"
import { SavedMatchupRosterCard } from "./SavedMatchupRosterCard"
import { useAppContext } from "../../contexts/AppContext"

export const SavedMatchupCard = ({ matchup }) => {
    const { selectedLeague } = useAppContext()
    let winner = selectedLeague.leagueUsers.find((lu) => lu.userProfileId == matchup.winnerId)

    return (
        <div>
            {matchup.winnerId ? <div className="matchup-winner-announcer"> {winner?.userProfile?.userName} wins!</div> : <></>}
            <div className="parent-container">
                <div className="matchup-container">
                    <div>{matchup.matchupUsers[0].userProfileDTO.userName}'s team 
                        <SavedMatchupRosterCard matchupUser={matchup.matchupUsers[0]} slot={true}/>
                    </div>
                    <div className="vertical-divider"></div>
                    <div>{matchup.matchupUsers[1].userProfileDTO.userName}'s team 
                        <SavedMatchupRosterCard matchupUser={matchup.matchupUsers[1]} slot={false}/>
                    </div>
                </div>
            </div>
        </div>
        )
}