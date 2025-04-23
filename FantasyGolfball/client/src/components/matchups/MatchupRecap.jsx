import { Table } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"

export const MatchupRecap = ({ weekId }) => {
    const { matchups } = useAppContext()

    // const testObjects = [
    //     {
    //         matchupUserSavedPlayerId: 1,
    //         playerId: 1,
    //         scoringId: 1,
    //         rosterPlayerPosition: "QB1",
    //         player: {
    //             playerId: 1,
    //             playerFullName: "Joe Blow"
    //         },
    //         scoring: {
    //             scoringId: 1,
    //             points: 2
    //         }
    //     },
    //     {
    //         matchupUserSavedPlayerId: 1,
    //         playerId: 1,
    //         scoringId: 1,
    //         rosterPlayerPosition: "QB1",
    //         player: {
    //             playerId: 1,
    //             playerFullName: "Joe Blow"
    //         },
    //         scoring: {
    //             scoringId: 1,
    //             points: 2
    //         }
    //     },

    // ]

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