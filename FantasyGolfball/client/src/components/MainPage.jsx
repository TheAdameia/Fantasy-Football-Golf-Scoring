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

    const diffMs = draftStart - now
    const diffDays = Math.floor(diffMs / (1000 * 60 * 60 * 24))
    const diffHours = Math.floor((diffMs % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60))
    const diffMinutes = Math.floor((diffMs % (1000 * 60 * 60)) / (1000 * 60))

    const enterDraft = () => {
        console.log(`now: ${now}`)
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
        }
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
            <h1>Testing, attention please!</h1>
            <div className="mainpage-league-container">
                <h4>{selectedLeague.leagueName}</h4>
                {now < draftStart 
                    ? <div>Draft starts on {draftStart.toLocaleString('en-US')}, in {diffDays} days, {diffHours} hours and {diffMinutes} minutes.</div> 
                    : <div></div>
                }
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