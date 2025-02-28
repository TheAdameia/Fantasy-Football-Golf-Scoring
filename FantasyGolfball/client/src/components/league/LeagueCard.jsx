import { Button } from "reactstrap"
import { JoinLeague } from "../../managers/leagueManager"
import { useAppContext } from "../../contexts/AppContext"
import "./League.css"


export const LeagueCard = ({ league, getAndSetLeagues }) => {
    const { loggedInUser, setSelectedLeague } = useAppContext()
    let openSlots = (league.playerLimit - league.leagueUsers.length)

    const handleJoin = (event) => {
        event.preventDefault()
        let leagueId = league.leagueId
        let userId = loggedInUser.id

        if (league.leagueUsers.some(u => u.userProfileId == userId)) {
            window.alert("Already joined that league!")
            return
        }
        
        JoinLeague(leagueId, userId).then(() => {
            getAndSetLeagues()
        }).then(setSelectedLeague(league)) // speculative
    }

    return (
        <div className="league-card">
            <h4>{league.leagueName}</h4>
            <div>Users joined so far:</div>
            {league.leagueUsers.map((lu) => {
                return (
                    <div key={lu.leagueUserId}>
                        <div>
                            {lu.userProfile.userName}
                        </div>
                    </div>
                )
            })}
            <div>{openSlots} Open Slots</div>
            <div className="rules-card">
                <div>League rules:</div>
                <div>Player Limit: {league.playerLimit}</div>
                {league.randomizedDraftOrder ? <div>Randomized Draft Order</div> : <div>Draft Order Not Randomized</div>}
                {league.usersVetoTrades ? <div>Users can veto trades</div> : <div>Users cannot veto trades</div>}
                {league.requiredFullToStart ? <div>League must be full to start</div> : <div>League does not need to be full to start</div>}
            </div>
            <Button
                onClick={handleJoin}
            >Join this league!</Button>
        </div>
    )
}