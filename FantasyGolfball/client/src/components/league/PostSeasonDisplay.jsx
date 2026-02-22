import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { GetHistoricalDraftState } from "../../managers/historicalManager"
import { Table } from "reactstrap"
import { PostSeasonPlayerDisplay } from "./PostSeasonPlayerDisplay"


export const PostSeasonDisplay = () => {
    const { selectedLeague } = useAppContext()
    const [historicalDraftState, setHistoricalDraftState] = useState()

    const GetAndSetHistoricalDraftState = () => {
        GetHistoricalDraftState(selectedLeague.leagueId).then(setHistoricalDraftState)
    }

    const pickCounts = {}

    useEffect(() => {
        if (selectedLeague) {
            GetAndSetHistoricalDraftState()
        }
    }, [selectedLeague])

    
    // I will need to include IsLeagueFinished in the export DTO so it can be checked

    if (historicalDraftState) {
        return (
            <div>
                <Table>
                    <thead>
                        <tr>
                            <th></th>
                            <th>Team</th>
                            <th>Pick</th>
                            <th>Average Points (All games, with penalties)</th>
                            <th>Average Points (Valid Games)</th>
                        </tr>
                    </thead>
                    <tbody>
                        {historicalDraftState.permanentDraftOrder.map((user, index) => {
                            // initializes for users
                            if (!pickCounts[user]) {
                                pickCounts[user] = 0
                            }

                            // "find X pick of Y user, count[y][x]"
                            const rosterIndex = pickCounts[user]
                            const playerId = historicalDraftState.userRosters[user][rosterIndex]

                            // increase user's count
                            pickCounts[user]++

                            return (
                                <PostSeasonPlayerDisplay
                                    key={index}
                                    user={user}
                                    index={index}
                                    playerId={playerId}
                                />
                            )
                        }
                            
                        )}
                    </tbody>
                </Table>
                {/* <div>Biggest blowout? draft grade?</div> */}
            </div>
        )
    } else if (selectedLeague && selectedLeague.isLeagueFinished == false) {
        <div>Come back when the season ends!</div>
    } else {
        <div>Loading...</div>
    }
    
}