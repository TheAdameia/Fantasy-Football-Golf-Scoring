import { useAppContext } from "../contexts/AppContext"
import "./MainPage.css"


export const MainPage = () => {
    const { selectedLeague, matchups } = useAppContext()

    if (!selectedLeague) {
        return (
            <div>No leagues joined!</div>
        )
    }
    return (
        <div className="mainpage-main-container">
            <h1>Testing, attention please!</h1>
            <div className="mainpage-league-container">
                <h4>{selectedLeague.leagueName}</h4>
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