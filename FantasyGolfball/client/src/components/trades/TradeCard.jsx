import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { TradePlayerCard } from "./TradePlayerCard"
import { Spinner } from "reactstrap"
import "./trade.css"
import { AcceptTrade, DeleteTrade } from "../../managers/tradeManager"


export const TradeCard = ({ trade }) => {
    const { selectedLeague, roster, loggedInUser, getAndSetTrades, activeTrades } = useAppContext()
    const [creator, setCreator] = useState("")
    const [receiver, setReceiver] = useState("")
    const [isCollapsed, setIsCollapsed] = useState(false)

    const ConfirmAccept = (tradeId) => {
        const confirmed = window.confirm(`Are you sure you want to accept this trade?`)
        if (confirmed) {
            HandleAccept(tradeId)
        } else {
            return
        }
    }

    const HandleAccept = (tradeId) => {
        let validTrade = true
        const activeTradePlayerIds = activeTrades
            .filter(t => t.firstPartyAcceptance && t.secondPartyAcceptance)
            .flatMap(t => t.tradePlayers.map(tp => tp.playerId))
        for (const tp of trade.tradePlayers) {
            if (activeTradePlayerIds.includes(tp.playerId)) {
                validTrade = false
            }
        }

        if (!validTrade) {
            window.alert(`You have already accepted a trade for a player listed in this trade!`)
            return
        }
        
        AcceptTrade(tradeId).then(() => {
            getAndSetTrades()
        })
    }

    const ConfirmReject = (tradeId) => {
        const confirmed = window.confirm(`Are you sure you want to reject this trade?`)
        if (confirmed) {
            HandleRejectTrade(tradeId)
        } else {
            return
        }
    }

    const HandleRejectTrade = (tradeId) => {
        DeleteTrade(tradeId).then(() => {
            getAndSetTrades()
        })
    }

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
                        {trade.firstPartyAcceptance ? <div className="trade-acceptance">Accepted ✓</div>: <div className="trade-acceptance">Not Accepted</div>}
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
                            {trade.secondPartyAcceptance ? <div className="trade-acceptance">Accepted ✓</div>: <div className="trade-acceptance">Not Accepted</div>}
                            {trade.tradePlayers
                                .filter(tp => tp.receivingRosterId == roster.rosterId)
                                .map((tp) => {
                                    return (
                                        <TradePlayerCard key={tp.playerId} playerId={tp.playerId}/>
                                    )
                                })}
                        </div>
                    </div>
                    <div>Trade takes effect in Week {trade.weekActivation} if accepted</div>
                    <div className="trade-buttons-container">
                        {loggedInUser.id === receiver.userProfile.id && !trade.secondPartyAcceptance && (
                            <button className="trade-accept-button" onClick={() => ConfirmAccept(trade.tradeId)}>accept trade</button>
                        )}

                        {loggedInUser.id === receiver.userProfile.id && trade.secondPartyAcceptance === false && (
                            <button className="trade-modify-button">make a counteroffer (NYI)</button>
                        )}

                        {loggedInUser.id === creator.userProfile.id ? (
                            <button className="trade-withdraw-button" onClick={() => ConfirmReject(trade.tradeId)}>withdraw trade offer</button>
                        ) : (
                            <button className="trade-withdraw-button" onClick={() => ConfirmReject(trade.tradeId)}>reject trade offer</button>
                        )}
                    </div>
                </>
            )}
            
        </div>
    )
}