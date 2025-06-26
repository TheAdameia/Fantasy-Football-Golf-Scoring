import { useNavigate } from "react-router-dom"
import { useAppContext } from "../contexts/AppContext"
import "./MainPage.css"
import { MatchupRecap } from "./matchups/MatchupRecap"
import { PointsForTable } from "./widgets/PointsForTable"
import { PointsAgainstTable } from "./widgets/PointsAgainstTable"
import { WinLossTable } from "./widgets/WinLossTable"
import { useEffect, useState } from "react"


export const MainPage = () => {
    const { selectedLeague, matchups } = useAppContext()
    const navigate = useNavigate()
    const now = new Date()
    const draftStart = new Date(selectedLeague?.draftStartTime)
    const seasonStart = new Date(selectedLeague?.seasonStartDate)
    const [advancementType, setAdvancementType] = useState(<></>)
    const [timeUntilNextWeek, setTimeUntilNextWeek] = useState("")
    const [timeUntilDraft, setTimeUntilDraft] = useState("")
    const [timeUntilReveals, setTimeUntilReveals] = useState("")


    const enterDraft = () => {
        navigate(`/live-draft`)
    }

    useEffect(() => {
        if (selectedLeague?.advancement)
        switch(selectedLeague.advancement) {
            case 0:
                setAdvancementType(<div>A Season's "Week" advances in a week of real time.</div>)
                return
            case 1:
                setAdvancementType(<div>A Season's "Week" advances in a day of real time.</div>)
                return
            case 2:
                setAdvancementType(<div>A Season's "Week" advances in an hour of real time.</div>)
                return
            case 3:
                setAdvancementType(<div>A Season's "Week" advances in 15 minutes of real time.</div>)
                return
        }
    }, [selectedLeague])

    useEffect(() => {
        if (!selectedLeague || selectedLeague.currentWeek < 1 || !selectedLeague.seasonStartDate) return

        const seasonStart = new Date(selectedLeague.seasonStartDate)
        let msPerWeek

        switch (selectedLeague.advancement) {
            case 0:
                msPerWeek = 1000 * 60 * 60 * 24 * 7
                break
            case 1:
                msPerWeek = 1000 * 60 * 60 * 24
                break
            case 2:
                msPerWeek = 1000 * 60 * 60
                break
            case 3:
                msPerWeek = 1000 * 60 * 15
                break
            default:
                msPerWeek = 0
        }

        if (msPerWeek === 0) return

        const updateCountdown = () => {
            const now = new Date()
            const nextWeekStart = new Date(seasonStart.getTime() + selectedLeague.currentWeek * msPerWeek)
            const diff = nextWeekStart - now

            if (diff <= 0) {
                setTimeUntilNextWeek("Week change in progress...")
                return
            }

            const days = Math.floor(diff / (1000 * 60 * 60 * 24))
            const hours = Math.floor((diff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60))
            const minutes = Math.floor((diff % (1000 * 60 * 60)) / (1000 * 60))
            const seconds = Math.floor((diff % (1000 * 60)) / 1000)

            let formatted = ""
            if (days > 0) formatted += `${days}d `
            if (hours > 0 || days > 0) formatted += `${hours}h `
            if (minutes > 0 || hours > 0 || days > 0) formatted += `${minutes}m `
            formatted += `${seconds}s`

            setTimeUntilNextWeek(formatted)
        }

        updateCountdown() // Initial call
        const interval = setInterval(updateCountdown, 1000) // update every second

        return () => clearInterval(interval)
    }, [selectedLeague])


    useEffect(() => {
        if (!selectedLeague?.draftStartTime) return

        const draftStart = new Date(selectedLeague.draftStartTime)

        const updateDraftCountdown = () => {
            const now = new Date()
            const diff = draftStart - now

            if (diff <= 0) {
                return
            }

            const days = Math.floor(diff / (1000 * 60 * 60 * 24))
            const hours = Math.floor((diff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60))
            const minutes = Math.floor((diff % (1000 * 60 * 60)) / (1000 * 60))
            const seconds = Math.floor((diff % (1000 * 60)) / 1000)

            let formatted = ""
            if (days > 0) formatted += `${days}d `
            if (hours > 0 || days > 0) formatted += `${hours}h `
            if (minutes > 0 || hours > 0 || days > 0) formatted += `${minutes}m `
            formatted += `${seconds}s`

            setTimeUntilDraft(formatted)
        }

        updateDraftCountdown() // initial call
        const interval = setInterval(updateDraftCountdown, 1000)

        return () => clearInterval(interval)
    }, [selectedLeague])

    useEffect(() => {
        if (!selectedLeague || selectedLeague.currentWeek < 1 || !selectedLeague.seasonStartDate) return

        const seasonStart = new Date(selectedLeague.seasonStartDate)
        let msPerWeek, totalRevealDuration

        switch (selectedLeague.advancement) {
            case 0: // Weekly
                msPerWeek = 1000 * 60 * 60 * 24 * 7
                totalRevealDuration = 1000 * 60 * 60 * 8
                break
            case 1: // Daily
                msPerWeek = 1000 * 60 * 60 * 24
                totalRevealDuration = 1000 * 60 * 60
                break
            case 2: // Hourly
                msPerWeek = 1000 * 60 * 60
                totalRevealDuration = 1000 * 60 * 10
                break
            case 3: // Turbo
                msPerWeek = 1000 * 60 * 15
                totalRevealDuration = 1000 * 60 * 5
                break
            default:
                return
        }

        const nextWeekTime = new Date(seasonStart.getTime() + selectedLeague.currentWeek * msPerWeek)
        const revealStartTime = new Date(nextWeekTime.getTime() - totalRevealDuration)

        const updateRevealCountdown = () => {
            const now = new Date()
            const diff = revealStartTime - now

            if (diff <= 0) {
                setTimeUntilReveals("Reveals in progress or completed.")
                return
            }

            const days = Math.floor(diff / (1000 * 60 * 60 * 24))
            const hours = Math.floor((diff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60))
            const minutes = Math.floor((diff % (1000 * 60 * 60)) / (1000 * 60))
            const seconds = Math.floor((diff % (1000 * 60)) / 1000)

            let formatted = ""
            if (days > 0) formatted += `${days}d `
            if (hours > 0 || days > 0) formatted += `${hours}h `
            if (minutes > 0 || hours > 0 || days > 0) formatted += `${minutes}m `
            formatted += `${seconds}s`

            setTimeUntilReveals("Reveals begin and Rosters lock in: " + formatted)
        }

        updateRevealCountdown()
        const interval = setInterval(updateRevealCountdown, 1000)

        return () => clearInterval(interval)
    }, [selectedLeague])


    if (!selectedLeague) {
        return (
            <div>No leagues joined!</div>
        )
    }
    // This one will be the league recap
    if (selectedLeague.isLeagueFinished) {
        return (
            <div className="mainpage-main-container">
                <div className="mainpage-league-container">
                    <h4>{selectedLeague.leagueName}</h4>
                    <h6>Final Rankings:</h6>
                    <div className="mainpage-table-container">
                        <PointsForTable
                            matchups={matchups}
                            selectedLeague={selectedLeague}
                        />
                        <PointsAgainstTable
                            matchups={matchups}
                            selectedLeague={selectedLeague}
                        />
                        <WinLossTable
                            matchups={matchups}
                            selectedLeague={selectedLeague}
                        />
                    </div>
                    <div className="mainpage-matchup-container">
                        <MatchupRecap weekId={1} />
                        <MatchupRecap weekId={2} />
                        <MatchupRecap weekId={3} />
                        <MatchupRecap weekId={4} />
                    </div>
                    <div className="mainpage-rules-container">League Settings 
                        <div>Player Limit: {selectedLeague.playerLimit}</div>
                        {selectedLeague.randomizedDraftOrder ? <div>Randomized Draft Order</div> : <div>Draft Order Not Randomized</div>}
                        {selectedLeague.usersVetoTrades ? <div>Users can veto trades</div> : <div>Users cannot veto trades</div>}
                        {selectedLeague.requiredFullToStart ? <div>League must be full to start</div> : <div>League does not need to be full to start</div>}
                    </div>
                </div>
            </div>
        )
    }

    // this is what people will see most of the time
    return (
        <div className="mainpage-main-container">
            <div className="mainpage-league-container">
                <h4>{selectedLeague.leagueName}</h4>
                {timeUntilDraft && !selectedLeague.isDraftComplete && (
                    <div className="mainpage-timer">
                        Draft starts on {new Date(selectedLeague.draftStartTime).toLocaleString('en-US')}<br />
                        in {timeUntilDraft}
                    </div>
                )}
                {now < seasonStart
                    ? <div>Season begins {seasonStart.toLocaleString('en-US')}</div>
                    : <div></div>}
                {(selectedLeague.playerLimit == selectedLeague.leagueUsers.length) 
                    && !selectedLeague.isDraftComplete
                    && now >= draftStart
                    ? <button onClick={() => enterDraft()}>Enter the draft!</button>
                    : <></>
                }
                {/* A different check will be needed for Leagues that don't need all players to start */}
               
                <div className="mainpage-matchup-container">
                    <div className="mainpage-matchup-weekannouncer">
                        {selectedLeague.currentWeek ? `Week ${selectedLeague.currentWeek} Matchups` : "Preseason"}
                    </div>
                    <div>
                        {matchups ? matchups
                        .filter((matchup) => matchup.weekId === selectedLeague.currentWeek)
                        .map((matchup) => {
                            return (
                                <div key={matchup.matchupId} className="matchup">
                                    {matchup.matchupUsers[0].userProfileDTO.userName} vs. {matchup.matchupUsers[1].userProfileDTO.userName}
                                </div>
                            )
                        }) : <></>}
                    </div>
                    {timeUntilNextWeek && selectedLeague.isDraftComplete &&(
                        <div className="mainpage-timer">Next week begins in: {timeUntilNextWeek}</div>
                    )}
                    {timeUntilReveals && selectedLeague.isDraftComplete && (
                        <div className="mainpage-timer">{timeUntilReveals}</div>
                    )}
                </div>    
                
                <div className="mainpage-matchup-container">
                    <div>{(selectedLeague?.currentWeek - 1) > 0 ? `Week ${selectedLeague.currentWeek - 1} Recap` : "Draft Recap"}</div>
                    {(selectedLeague?.currentWeek - 1) > 0 ? 
                    <MatchupRecap
                        weekId={selectedLeague.currentWeek - 1}
                    /> : <></>}
                </div>
                <h6>League rankings</h6>
                <div className="mainpage-table-container">
                    <PointsForTable
                        matchups={matchups}
                        selectedLeague={selectedLeague}
                    />
                    <PointsAgainstTable
                        matchups={matchups}
                        selectedLeague={selectedLeague}
                    />
                    <WinLossTable
                        matchups={matchups}
                        selectedLeague={selectedLeague}
                    />
                </div>
                
                <div className="mainpage-rules-container">
                    <div className="mainpage-rules-announcer">League Settings</div>
                    <div>Player Limit: {selectedLeague.playerLimit}</div>
                    {selectedLeague.randomizedDraftOrder ? <div>Randomized Draft Order</div> : <div>Draft Order Not Randomized</div>}
                    {selectedLeague.usersVetoTrades ? <div>Users can veto trades</div> : <div>Users cannot veto trades</div>}
                    {selectedLeague.requiredFullToStart ? <div>League must be full to start</div> : <div>League does not need to be full to start</div>}
                    <div>{advancementType}</div>
                </div>
            </div>
        </div>
    )
}