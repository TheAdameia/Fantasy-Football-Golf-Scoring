import "./matchups.css"
import { SavedMatchupRosterCard } from "./SavedMatchupRosterCard"

export const SavedMatchupCard = ({ matchup }) => {
    

    return (
            <div className="parent-container">
                {matchup.winnerId ? <div>#{matchup.winnerId} {winner?.userProfile?.userName} wins!</div> : <></>}
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
        )
}