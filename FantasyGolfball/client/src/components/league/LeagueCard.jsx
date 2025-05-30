import { Button } from "reactstrap"
import { JoinLeague } from "../../managers/leagueManager"
import { useAppContext } from "../../contexts/AppContext"
import "./League.css"
import { useNavigate } from "react-router-dom"
import { useState } from "react"


export const LeagueCard = ({ league, getAndSetLeagues }) => {
    const { loggedInUser, setSelectedLeague } = useAppContext()
    let openSlots = (league.playerLimit - league.leagueUsers.length)
    const navigate = useNavigate()
    const [isCollapsed, setIsCollapsed] = useState(false)

    const handleJoin = async (event) => {
        event.preventDefault()
        let leagueId = league.leagueId
        let userId = loggedInUser.id
        let userPassword = ""

        if (league.leagueUsers.some(u => u.userProfileId == userId)) {
            window.alert("Already joined that league!")
            return
        }
        

        if (league.requiresPassword) {
            userPassword = window.prompt("Enter the password for this League:")
            if (userPassword == null) {
                return
            }
        } 
        
        try {
            await JoinLeague(leagueId, userId, userPassword)
            await    getAndSetLeagues()
            setSelectedLeague(league)
            navigate("/")
        } catch (error) {
            window.alert("League password incorrect or other error joining.")
            console.error("JoinLeague error:", error)
        }
        
    }

    return (
        <div className="league-card">
            <h4
                onClick={() => setIsCollapsed(!isCollapsed)} 
            >{league.leagueName}{isCollapsed ? " ▼" : " ▲"}</h4>
            {!isCollapsed && (
                <>
                    <div>Users joined so far:</div>
                    {league.leagueUsers.map((lu) => {
                        return (
                            <div key={lu.leagueUserId}>
                                <div>
                                    {lu.userProfile.userName}
                                </div>
                            </div>
                        )
                    })}
                    <div>{openSlots} Open Slots</div>
                    <div className="rules-card">
                        <div>League rules:</div>
                        <div>Player Limit: {league.playerLimit}</div>
                        {league.randomizedDraftOrder ? <div>Randomized Draft Order</div> : <div>Draft Order Not Randomized</div>}
                        {league.usersVetoTrades ? <div>Users can veto trades</div> : <div>Users cannot veto trades</div>}
                        {league.requiredFullToStart ? <div>League must be full to start</div> : <div>League does not need to be full to start</div>}
                    </div>
                    <Button
                        onClick={handleJoin}
                    >Join this league!</Button>
                </>
            )}
        </div>
    )
}