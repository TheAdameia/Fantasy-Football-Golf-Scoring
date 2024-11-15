import { Button } from "reactstrap"
import { JoinLeague } from "../../managers/leagueManager"
import { useNavigate } from "react-router-dom"
import { useAppContext } from "../../contexts/AppContext"


export const LeagueCard = ({ league }) => {
    const navigate = useNavigate()
    const { loggedInUser } = useAppContext()

    const handleJoin = (event) => {
        event.preventDefault()
        let leagueId = league.leagueId
        let userId = loggedInUser.id
        JoinLeague(leagueId, userId).then(() => {
            navigate("/league")
        })
    }

    return (
        <div>
            <div>{league.leagueName}</div>
            <h4>Users joined so far:</h4>
            {league.leagueUsers.map((lu) => {
                return (
                    <div key={lu.leagueUserId}>
                        <div>
                            {lu.userProfile.userName}
                        </div>
                    </div>
                )
            })}
            <div>League rules:</div>
            <div>Player Limit {league.playerLimit}, Randomized Draft {league.randomizedDraftOrder}, Veto Trades {league.usersVetoTrades}, Must be full to start {league.requiredFullToStart}</div>
            <Button
                onClick={handleJoin}
            >Join this league!</Button>
        </div>
    )
}