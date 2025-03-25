import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { MatchupRosterCard } from "./MatchupRosterCard"
import "./matchups.css"


export const MatchupCard = ({ matchup }) => {
    const { loggedInUser, selectedLeague } = useAppContext()
    const [winner, setWinner] = useState()
    const opponent = matchup.matchupUsers.find((user) => user.userProfileId !== loggedInUser.id)
    const opponentLeagueUser = selectedLeague.leagueUsers.find((lu) => lu.userProfileId === opponent.userProfileId)
    const opponentRoster = opponentLeagueUser.roster

    const checkWinner = () => {
        if (matchup.winnerId) {
            let taco = selectedLeague.leagueUsers.find((lu) => lu.userProfileId == matchup.winnerId)
            setWinner(taco)
        }
    }

    useEffect(() => {
        checkWinner()
    }, [])

    return (
        <div className="parent-container">
            {matchup.winnerId ? <div>#{matchup.winnerId} {winner} wins!</div> : <></>}
            <div className="matchup-container">
                <div>{loggedInUser.userName}'s team
                    <MatchupRosterCard slot={true}/>
                </div>
                <div className="vertical-divider"></div>
                <div>{opponentLeagueUser.userProfile.userName}'s team
                    <MatchupRosterCard slot={false} opponentRoster={opponentRoster}/>
                </div>
            </div>
        </div>
    )
}