import { Button } from "reactstrap"


export const LeagueCard = ({ league }) => {

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
            <div>Player Limit {league.playerLimit} Randomized Draft {league.randomizedDraftOrder} Veto Trades {league.usersVetoTrades} Must be full to start {league.requiredFullToStart}</div>
            <Button>Join this league!</Button>
        </div>
    )
}