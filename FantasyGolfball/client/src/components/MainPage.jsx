import { useNavigate } from "react-router-dom"
import { useAppContext } from "../contexts/AppContext"
import "./MainPage.css"


export const MainPage = () => {
    const { selectedLeague, matchups } = useAppContext()
    const navigate = useNavigate()
    const now = new Date()
    const draftStart = new Date(selectedLeague?.draftStartTime)

    const diffMs = draftStart - now
    const diffDays = Math.floor(diffMs / (1000 * 60 * 60 * 24))
    const diffHours = Math.floor((diffMs % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60))
    const diffMinutes = Math.floor((diffMs % (1000 * 60 * 60)) / (1000 * 60))

    const enterDraft = () => {
        navigate(`/live-draft`)
    }

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
                    <div>Final Rankings:</div>
                    <div className="mainpage-matchup-container">
                        <div>
                            bubkis (placeholder, supposed to show win/loss records and other fun stats)
                        </div>
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
            <aside>View past leagues (NYI)</aside>
            <div className="mainpage-league-container">
                <h4>{selectedLeague.leagueName}</h4>
                {now < draftStart 
                    ? <div>Draft starts on {draftStart.toLocaleString()}, in {diffDays} days, {diffHours} hours and {diffMinutes} minutes.</div> 
                    : <div></div>
                }
                {(selectedLeague.playerLimit == selectedLeague.leagueUsers.length) && !selectedLeague.isDraftComplete 
                    ? <button onClick={() => enterDraft()}>Enter the draft!</button>
                    : <></>
                }
                <div>League rankings</div>
                <div className="mainpage-matchup-container">Week {selectedLeague.season.currentWeek} Matchups
                    <div>
                        {matchups ? matchups
                        .filter((matchup) => matchup.weekId === selectedLeague.season.currentWeek)
                        .map((matchup) => {
                            return (
                                <div key={matchup.matchupId} className="matchup">
                                    User {matchup.matchupUsers[0].userProfileId} vs. User {matchup.matchupUsers[1].userProfileId}
                                </div>
                            )
                        }) : <div></div>}
                    </div>
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