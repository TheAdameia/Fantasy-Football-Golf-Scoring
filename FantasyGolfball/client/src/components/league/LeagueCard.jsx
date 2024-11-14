import { Button } from "reactstrap"


export const LeagueCard = ({ league }) => {

    return (
        <div>
            <div>{league.leagueName}</div>
            <h4>Users joined so far:</h4>
            {league.leagueUsers.map((lu) => {
                return (
                    <div
                        key={lu.leagueUserId}
                    >{lu.userProfile.userName}</div>
                )
            })}
            <Button>Join this league!</Button>
        </div>
    )
}