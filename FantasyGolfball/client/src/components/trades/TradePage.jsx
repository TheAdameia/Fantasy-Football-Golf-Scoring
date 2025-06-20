import { useNavigate } from "react-router-dom"
import { useAppContext } from "../../contexts/AppContext"
import { TradeCard } from "./TradeCard"
import { Spinner } from "reactstrap"
import "./trade.css"
import { useEffect } from "react"

export const TradePage = () => {
    const { activeTrades, getAndSetTrades } = useAppContext()
    const navigate = useNavigate()
    // display a notification icon on the navbar IF any unresolved trades


    // safeguards I need to have in for trade:
    // Can't make more than one trade offer using your same player ✓
    // Can't accept more than one trade offer in exchange for the same one of your player ✓
    // Can't drop a player in a trade offer ✓ (frontend only)
    // Decide if you would rather push trades to next week or delete them ✓

    useEffect(() => {
        getAndSetTrades()
    }, [])

    if (activeTrades) {
        if (activeTrades.length == 0) {
            return (
                <div>
                    <div className="trade-announcer">No proposed trades!</div>
                    <button onClick={() => navigate("/create-trade")}>Create a Trade</button>
                </div>
            )
        }


         return (
            <div className="trade-page-container">
                <button onClick={() => navigate("/create-trade")} className="trade-announcer">Create a Trade</button>
                {activeTrades.map((trade) => {
                    return (
                        <TradeCard trade={trade} key={trade.tradeId}/>
                    )
                })}
            </div>
        )
    } else {
        return ( <Spinner />)
    }
}