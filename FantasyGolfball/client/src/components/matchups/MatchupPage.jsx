import { useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { MatchupCard } from "./MatchupCard"


export const MatchupPage = () => {
    const { matchups, selectedLeague } = useAppContext()
    const [week, setWeek] = useState(selectedLeague.season.currentWeek)
    
    


    const handleWeekChange = (arg) => {
        if (arg == true && (week + 1) > 4) {
            return
        } else if (arg) {
            let newWeek = week + 1
            setWeek(newWeek)
            return 
        } else if (!arg && (week - 1) < 1) {
            return
        } else if (!arg) {
            let newWeek = week - 1
            setWeek(newWeek)
            return
        } else {
            window.alert("Something went wrong. Please try again.")
        }
    }

    if (matchups != null)
    {
        return (
            <div>
                <div>
                <button
                    className="week-buttons"
                    onClick={() => handleWeekChange(false)}
                >Previous</button>
                <label className="week-label">Week {week}</label>
                <button
                    className="week-buttons"
                    onClick={() => handleWeekChange(true)}
                >Next</button>
                </div>
            
                <div>
                    {matchups
                    .filter((matchup) => matchup.weekId === week)
                    .map((matchup) => {
                        return (
                            <MatchupCard
                                matchup={matchup}
                                key={matchup.matchupId}
                            />
                        )
                    })}
                </div>
            </div>
        )
    }
    
    return (
        <div>Quack!</div>
    )
}