import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { MatchupCard } from "./MatchupCard"
import { SavedMatchupCard } from "./SavedMatchupCard"
import "./matchups.css"

export const MatchupPage = () => {
    const { matchups, selectedLeague, loggedInUser } = useAppContext()
    const getInitialWeek = () => {
        const currentWeek = selectedLeague?.season?.currentWeek ?? 1
        return Math.min(currentWeek, 4)
    }
    const [week, setWeek] = useState(getInitialWeek)
    const [filteredMatchups, setFilteredMatchups] = useState()

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

    useEffect(() => {
        const currentWeek = selectedLeague?.season?.currentWeek ?? 1
        const clampedWeek = Math.min(currentWeek, 4)
        setWeek(clampedWeek)
    }, [selectedLeague?.season?.currentWeek])

    useEffect(() => {
        if (matchups) {
            let newMatchups = matchups.filter(m => m.matchupUsers.some(mu => mu.userProfileId == loggedInUser.id))
            setFilteredMatchups(newMatchups)
        }
    }, [loggedInUser.id, matchups])

    if (selectedLeague?.season?.currentWeek != week) {
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
                    {filteredMatchups ? filteredMatchups
                    .filter((matchup) => matchup.weekId === week)
                    .map((matchup) => {
                        return (
                            <SavedMatchupCard
                                matchup={matchup}
                                key={matchup.matchupId}
                            />
                        )
                    }) : <></>}
                </div>
            </div>
        )
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
                                week={week}
                            />
                        )
                    })}
                </div>
            </div>
        )
    }
    
    return (
        <div>To view matchups, you must join a League and complete a Draft.</div>
    )
}