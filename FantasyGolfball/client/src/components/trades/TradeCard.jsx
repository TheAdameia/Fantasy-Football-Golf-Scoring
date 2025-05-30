import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { TradePlayerCard } from "./TradePlayerCard"
import { Spinner } from "reactstrap"
import "./trade.css"


export const TradeCard = ({ trade }) => {
    const { selectedLeague, roster, loggedInUser } = useAppContext()
    const [creator, setCreator] = useState("")
    const [receiver, setReceiver] = useState("")
    const [isCollapsed, setIsCollapsed] = useState(false)

    useEffect(() => {
       if (selectedLeague && trade) {
        const cUser = selectedLeague.leagueUsers.find(c => c.rosterId == trade.firstPartyRosterId)
        setCreator(cUser)
       } 
    }, [selectedLeague, trade])

    useEffect(() => {
       if (selectedLeague && trade) {
        const rUser = selectedLeague.leagueUsers.find(c => c.rosterId == trade.secondPartyRosterId)
        setReceiver(rUser)
       } 
    }, [selectedLeague, trade])

    if (!creator || !receiver) {
        return <Spinner />;
    }

    return (
        <div className="trade-card-container">
             <div 
                className="trade-announcer" 
                onClick={() => setIsCollapsed(!isCollapsed)} 
                style={{ cursor: "pointer", fontWeight: "bold" }}
            >
                {creator.userProfile.userName}'s proposed trade 
                {isCollapsed ? " ▼" : " ▲"}
            </div>
            {!isCollapsed && (
                <>
                    <div className="trade-form-selects-container">
                    <div className="trade-card-offer">
                        <div>What {creator.userProfile.userName} is offering</div>
                        {trade.tradePlayers
                            .filter(tp => tp.givingRosterId == roster.rosterId)
                            .map((tp) => {
                                return (
                                    <TradePlayerCard key={tp.playerId} playerId={tp.playerId}/>
                                )
                            })}
                        </div>
                        <div>
                            <div>what {receiver.userProfile.userName} is getting</div>
                            {trade.tradePlayers
                                .filter(tp => tp.receivingRosterId == roster.rosterId)
                                .map((tp) => {
                                    return (
                                        <TradePlayerCard key={tp.playerId} playerId={tp.playerId}/>
                                    )
                                })}
                        </div>
                    </div>
                    <div className="trade-buttons-container">
                        {loggedInUser.id === receiver.userProfile.id && !trade.secondPartyAcceptance && (
                            <button className="trade-accept-button">accept trade</button>
                        )}

                        {loggedInUser.id === receiver.userProfile.id && (
                            <button className="trade-modify-button">make a counteroffer (PUT)</button>
                        )}

                        {loggedInUser.id === creator.userProfile.id ? (
                            <button className="trade-withdraw-button">withdraw trade offer</button>
                        ) : (
                            <button className="trade-withdraw-button">reject trade offer</button>
                        )}
                    </div>
                </>
            )}
            
        </div>
    )
}