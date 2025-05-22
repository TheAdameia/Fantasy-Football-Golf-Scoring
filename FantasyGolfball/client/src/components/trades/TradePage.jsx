import { useNavigate } from "react-router-dom"
import { useAppContext } from "../../contexts/AppContext"
import { TradeCard } from "./TradeCard"
import { Spinner } from "reactstrap"

export const TradePage = () => {
    const { activeTrades } = useAppContext()
    const navigate = useNavigate()
    // display a notification icon on the navbar IF any unresolved trades OR both-accepted unresolved trades

    if (activeTrades) {
        if (activeTrades.length == 0) {
            return (
                <div>
                    <div>No proposed trades!</div>
                    <button onClick={() => navigate("/create-trade")}>Create a Trade</button>
                </div>
            )
        }


         return (
            <div>Collapsable list of proposed trades
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