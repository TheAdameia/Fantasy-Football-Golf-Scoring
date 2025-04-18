import { Table } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"

export const MatchupRecap = ({ weekId }) => {
    const { matchups } = useAppContext()

    // take all the matchups, filter to a certain week, display them
    //

    return (
        <div>
            <div>Week {weekId} Matchups</div>
            {matchups ? matchups
            .filter((matchup) => matchup.weekId === weekId)
            .map((matchup) => {
                return (
                    <div key={matchup.matchupId} className="matchup">
                        <div>
                            <div>{matchup.matchupUsers[0].userProfileDTO.userName}</div>
                            <div>vs.</div>
                            <div>{matchup.matchupUsers[1].userProfileDTO.userName}</div>
                        </div>
                        <Table>

                        </Table>
                    </div>
                )
            }) : <div></div>}
        </div>
    )
}