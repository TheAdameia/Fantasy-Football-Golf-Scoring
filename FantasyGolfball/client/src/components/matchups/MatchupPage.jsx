import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { MatchupCard } from "./MatchupCard"
import { SavedMatchupCard } from "./SavedMatchupCard"
import "./matchups.css"
import { getRevealTimes } from "../widgets/GetRevealTimes"

export const MatchupPage = () => {
    const { matchups, selectedLeague, loggedInUser } = useAppContext()
    const getInitialWeek = () => {
        const currentWeek = selectedLeague?.currentWeek ?? 1
        return Math.min(currentWeek, 4)
    }
    const [week, setWeek] = useState(getInitialWeek)
    const [filteredMatchups, setFilteredMatchups] = useState()
    const [revealCountdownText, setRevealCountdownText] = useState("")

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

    const formatTime = (ms) => {
        if (ms <= 0) return "now"
        const totalSeconds = Math.floor(ms / 1000)
        const minutes = Math.floor(totalSeconds / 60)
        const seconds = totalSeconds % 60
        return `${minutes}m ${seconds}s`
    }

    useEffect(() => {
        const currentWeek = selectedLeague?.currentWeek ?? 1
        const clampedWeek = Math.min(currentWeek, 4)
        setWeek(clampedWeek)
    }, [selectedLeague?.currentWeek])

    useEffect(() => {
        if (matchups) {
            let newMatchups = matchups.filter(m => m.matchupUsers.some(mu => mu.userProfileId == loggedInUser.id))
            setFilteredMatchups(newMatchups)
        }
    }, [loggedInUser.id, matchups])

    useEffect(() => {
        const interval = setInterval(() => {
            const times = getRevealTimes(selectedLeague)
            if (!times) return

            const now = new Date().getTime()
            const start = times.revealStartTime.getTime()
            const end = times.nextWeekTime.getTime()

            if (now < start) {
                const diff = start - now
                setRevealCountdownText("Reveals begin in " + formatTime(diff))
            } else if (now >= start && now < end) {
                const revealIndex = Math.floor((now - start) / times.revealInterval)

                if (revealIndex < times.revealSequence.length) {
                    const nextRevealTime = start + (revealIndex + 1) * times.revealInterval
                    const diff = nextRevealTime - now
                    const nextPosition = times.revealSequence[revealIndex + 1]
                    setRevealCountdownText(
                        nextPosition
                            ? `${nextPosition} revealed in ${formatTime(diff)}`
                            : "All positions revealed."
                    )
                } else {
                    setRevealCountdownText("All positions revealed.")
                }
            } else {
                setRevealCountdownText("All positions revealed.")
            }
        }, 1000)

        return () => clearInterval(interval)
    }, [selectedLeague])



    if (selectedLeague?.currentWeek != week && selectedLeague?.currentWeek != 0) {
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
                    <div className="reveal-timer">
                        {revealCountdownText}
                    </div>

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