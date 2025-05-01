import { useAppContext } from "../../contexts/AppContext"

export const MatchupRecap = ({ weekId }) => {
    const { matchups } = useAppContext()


    return (
        <div>
            <div>Week {weekId} Matchups</div>
            {matchups ? matchups
            .filter((matchup) => matchup.weekId === weekId)
            .map((matchup) => {
                return (
                    <div key={matchup.matchupId}>
                        <div>
                            <div>{matchup.matchupUsers[0].userProfileDTO.userName}</div>
                            <div>vs.</div>
                            <div>{matchup.matchupUsers[1].userProfileDTO.userName}</div>
                        </div>
                    </div>
                )
            }) : <div></div>}
        </div>
    )
}