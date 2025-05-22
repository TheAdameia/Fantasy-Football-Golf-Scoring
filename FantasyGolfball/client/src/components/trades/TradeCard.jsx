import { useAppContext } from "../../contexts/AppContext"


export const TradeCard = ({ trade }) => {
    const { selectedLeague, roster, loggedInUser } = useAppContext()


    return (
        <div>
            <div>User's proposed trade</div>
            <div>
                <div>
                    <div>{loggedInUser.userName}</div>
                    <div>What you're offering</div>
                    {trade.tradePlayers
                        .filter(tp => tp.givingRosterId == roster.rosterId)
                        .map((tp) => {
                            return (
                                <div key={tp.tradePlayerId}>
                                    {tp.playerId}
                                </div>
                            )
                        })}
                </div>
                <div>
                    <div>other person</div>
                    <div>what you're getting</div>
                    {trade.tradePlayers
                        .filter(tp => tp.receivingRosterId == roster.rosterId)
                        .map((tp) => {
                            return (
                                <div key={tp.tradePlayerId}>
                                    {tp.playerId}
                                </div>
                            )
                        })}
                </div>
            </div>
            <div>accept trade</div>
            <div>make a counteroffer (PUT)</div>
            <div>withdraw trade</div>
        </div>
    )
}