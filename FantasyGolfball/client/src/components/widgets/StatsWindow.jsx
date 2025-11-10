// the idea for this module is that there's a button on other pages that
// displays a popup containing all revealed statistical information about
// a player. This way that information can be accessible, but won't clutter
// up the existing pages.

import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"

export const StatsWindow = (player, rosterLock) => {
    const { selectedLeague, allScores } = useAppContext()
    const [weekScore, setWeekScore] = useState()
    const [seasonTotal, setSeasonTotal] = useState()

    // ripped this from PlayerCard, might want to consider making it its own widget
    useEffect(() => {
        if (!allScores || selectedLeague?.currentWeek == null) {
            setWeekScore(undefined)
            setSeasonTotal("-")
            return
        }

        const playerScores = allScores.filter(s => s.playerId == player.playerId)

        // current week score
        const thisWeekScore = playerScores.find(s => s.seasonWeek === selectedLeague.currentWeek)
        setWeekScore(rosterLock ? thisWeekScore : undefined)

        // season total
        const total = playerScores
            .filter(s => s.seasonWeek <= selectedLeague.currentWeek || (s.seasonWeek === selectedLeague.currentWeek && rosterLock))
            .reduce((sum, s) => sum + s.points, 0)

        setSeasonTotal(total.toFixed(1))
        
    }, [allScores, selectedLeague?.currentWeek, player])

    return (
        <div>return a popup? different styles for different positions</div>
    )

}