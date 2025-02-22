import { useAppContext } from "../../contexts/AppContext"


export const MatchupCard = ({ matchup }) => {
    const { loggedInUser } = useAppContext()
    const opponent = matchup.matchupUsers.find((user) => user.userProfileId !== loggedInUser.id)

    return (
        <div>
            Quackerooski! Week {matchup.weekId}
            <div>
                <div>User's team #{loggedInUser.id}</div>
                <div>Opponent's team #{opponent.userProfileId}</div>
            </div>
        </div>
    )
}