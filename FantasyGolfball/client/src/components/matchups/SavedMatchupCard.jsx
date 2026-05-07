import "./matchups.css"
import { SavedMatchupRosterCard } from "./SavedMatchupRosterCard"
import { useAppContext } from "../../contexts/AppContext"
import { useEffect } from "react"

export const SavedMatchupCard = ({ matchup }) => {
    const { selectedLeague, getAndSetMatchups } = useAppContext()
    const seasonStart = new Date(selectedLeague?.seasonStartDate)
    let winner = selectedLeague.leagueUsers.find((lu) => lu.userProfileId == matchup.winnerId)


    // this is designed to force a refresh when going from preseason to week 1
    // I know it works with hard refreshes but I'm not sure if it will work with getAndSet
    useEffect(() => {
        // fires when timer hits zero
        if (!selectedLeague?.currentWeek) {
            const now = new Date()
            const timeUntilStart = seasonStart - now

            if (timeUntilStart > 0) {
                const timeout = setTimeout(() => {
                    window.location.reload()
                }, timeUntilStart)

                return () => clearTimeout(timeout)
            } else {
                window.location.reload()
            }
        }
    }, [selectedLeague, seasonStart])

    // this is designed to cause a refresh when viewing a stale page, but I'm not sure how to work it
    // what I really want is for it to refresh ONLY IF there's new data available, but I don't have a
    // real elegant way to do that. I could hack together something that compares times and Now and
    // league advancement, but that would be writing like 80 lines of code when the user has no real
    // reason to look at future matchups.
    useEffect(() => {
        if (!selectedLeague.isLeagueFinished && matchup.winnerId == null) {
            const timeout = setTimeout(() => {
                window.location.reload()
            }, 10000)

            return () => clearTimeout(timeout)
        }
    }, [matchup.winnerId, selectedLeague.isLeagueFinished])

    return (
        <div>
            {matchup.winnerId ? <div className="matchup-winner-announcer"> {winner?.userProfile?.userName} wins!</div> : <div>Coming soon!</div>}
            {!selectedLeague.currentWeek ? <div>Preseason. Active rosters to be revealed on Season start at {seasonStart.toLocaleString('en-US')}</div> : <></>}
            <div className="parent-container">
                <div className="matchup-container">
                    <div className="matchup-roster-card-container">{matchup.matchupUsers[0].userProfileDTO.userName}'s team 
                        <SavedMatchupRosterCard matchupUser={matchup.matchupUsers[0]} week={matchup.weekId} slot={true}/>
                    </div>
                    <div className="vertical-divider"></div>
                    <div className="matchup-roster-card-container">{matchup.matchupUsers[1].userProfileDTO.userName}'s team 
                        <SavedMatchupRosterCard matchupUser={matchup.matchupUsers[1]} week={matchup.weekId} slot={false}/>
                    </div>
                </div>
            </div>
        </div>
    )
}