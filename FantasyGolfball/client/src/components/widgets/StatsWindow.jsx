// the idea for this module is that there's a button on other pages that
// displays a popup containing all revealed statistical information about
// a player. This way that information can be accessible, but won't clutter
// up the existing pages.

import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import "./widgets.css"
import { Table } from "reactstrap"

export const StatsWindow = ({player, rosterLock, onClose}) => {
    const { selectedLeague, allScores } = useAppContext()
    const [seasonTotal, setSeasonTotal] = useState()

    useEffect(() => {
        // season total
        const total = playerScores
            .filter(s => s.seasonWeek <= selectedLeague.currentWeek || (s.seasonWeek === selectedLeague.currentWeek && rosterLock))
            .reduce((sum, s) => sum + s.points, 0)

        setSeasonTotal(total.toFixed(1))

    }, [allScores, selectedLeague?.currentWeek, player])

    // create a list of weeks where stats should be displayed using scores from AppContext and filtered using
    // selectedLeague and rosterLock.

    // I'll also have to handle bye weeks intelligently. Perhaps I could insert them into the map somehow?

    if (player.position.positionId != 6 && player.position.positionId != 5) {
        return (
            <div className="modal-overlay">
                <div className="modal-content">
                    <button onClick={onClose}>Close</button>
                    <div>
                        <div>{player.playerFullName}</div>
                        <div>Week # Score</div>
                        <div>Season Total Score</div>
                        <Table>
                            <thead>
                                <tr>
                                    <th>
                                        Week
                                    </th>
                                    <th>
                                        Stat 1
                                    </th>
                                    <th>
                                        Stat 2
                                    </th>
                                    <th>
                                        Stat 3
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                {/* .map the thing out here */}
                            </tbody>
                        </Table>
                    </div>
                </div>
            </div>
        )
    } else if (player.position.positionId == 5) {
        // kickers
        <div className="modal-overlay">
            <div className="modal-content">
                <button onClick={onClose}>Close</button>
                <div>
                    <div>{player.playerFullName}</div>
                    <div>Week # Score</div>
                    <div>Season Total Score</div>
                    <Table>
                        <thead>
                            <tr>
                                <th>
                                    Week
                                </th>
                                <th>
                                    Points
                                </th>
                                <th>
                                    Extra Point Attempts
                                </th>
                                <th>
                                    Extra Points Made
                                </th>
                                <th>
                                    Field Goal Attempts
                                </th>
                                <th>
                                    Field Goals Made
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            {/* .map the thing out here */}
                        </tbody>
                    </Table>
                </div>
            </div>
        </div>
    } else if (player.position.positionId == 6) {
        // Defense
        <div className="modal-overlay">
                <div className="modal-content">
                    <button onClick={onClose}>Close</button>
                    <div>
                        <div>{player.playerFullName}</div>
                        <div>Week # Score</div>
                        <div>Season Total Score</div>
                        <Table>
                            <thead>
                                <tr>
                                    <th>
                                        Week
                                    </th>
                                    <th>
                                        Stat 1
                                    </th>
                                    <th>
                                        Stat 2
                                    </th>
                                    <th>
                                        Stat 3
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                {/* .map the thing out here */}
                            </tbody>
                        </Table>
                    </div>
                </div>
            </div>
    }
}