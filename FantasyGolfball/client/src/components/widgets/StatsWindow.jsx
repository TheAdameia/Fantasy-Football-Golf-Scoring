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
    const [scoringArray, setScoringArray] = useState()
    const [seasonTotal, setSeasonTotal] = useState()
    const [statKeys, setStatKeys] = useState(null)
    const formatHeader = key =>
        key.replace(/([A-Z])/g, " $1").replace(/^./, c => c.toUpperCase())

    
    useEffect(() => {
        if (allScores == null) {
            return
        }
        const playerScores = allScores.filter(s => s.playerId == player.playerId)
        // season total
        const total = playerScores
            .filter(s => s.seasonWeek <= selectedLeague.currentWeek || (s.seasonWeek === selectedLeague.currentWeek && rosterLock))
            .reduce((sum, s) => sum + s.points, 0)

        setSeasonTotal(total.toFixed(2))

        const array = playerScores.filter(s => s.seasonWeek <= selectedLeague.currentWeek || (s.seasonWeek === selectedLeague.currentWeek && rosterLock))
        setScoringArray(array)

    }, [allScores, selectedLeague?.currentWeek, player])

    useEffect(() => {
        // the idea is that this will dynamically display relevant stats, based on whether
        // any of the key value pairs have a non-trivial value.
        if (scoringArray) {
            const excludedKeys = ["scoringId", "playerId", "player", "seasonId", "seasonWeek", "isDefense", "points"]

            const keys = Object.keys(scoringArray[0]).filter(
                key => !excludedKeys.includes(key)
            )

            const visibleStats = keys.filter(k =>
                scoringArray.some(s => s[k] != 0 && s[k] != null)
            )

            setStatKeys(visibleStats)
        }
    },[scoringArray])

    // I'll also have to handle bye weeks intelligently. Perhaps I could insert them into the map somehow?
    // a better way might be to have a int++ weeks loop until it increments to the selectedLeague season week maximum.

    if (scoringArray == null || statKeys == null) {
        return (
            <div>loading...</div>
        )
    }

    if (scoringArray && statKeys) {
        return (
            <div className="modal-overlay">
                <div className="modal-content">
                    <button onClick={onClose}>Close</button>
                    <div>
                        <div>{player.playerFullName}, {player.position.positionShort}, {player.playerTeams[0].team.teamName}. {selectedLeague.season.seasonYear} Season Total: {seasonTotal}</div>
                        <Table>
                            <thead>
                                <tr>
                                    <th>
                                        Week
                                    </th>
                                    {statKeys.map(key => (
                                        <th key={key}>{formatHeader(key)}</th>
                                    ))}
                                    <th>Points</th>
                                </tr>
                            </thead>
                            <tbody>
                                {scoringArray.map((scoring, index) => (
                                    <tr key={index}>
                                        <td>{scoring.seasonWeek}</td>
                                        {statKeys.map(key => (
                                            <td key={key}>{scoring[key] || "-"}</td>
                                        ))}
                                        <td>{scoring.points.toFixed(2)}</td>
                                    </tr>
                                ))}
                            </tbody>
                        </Table>
                    </div>
                </div>
            </div>
        )
    } 
}