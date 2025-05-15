import { useAppContext } from "../../contexts/AppContext"


export const TradeCard = () => {
    const { selectedLeague, roster, loggedInUser } = useAppContext()


    return (
        <div>
            <div>Trade Page</div>
            <div>
                <div>
                    <div>you</div>
                    <div>What you're offering</div>
                </div>
                <div>
                    <div>other person</div>
                    <div>what you're getting</div>
                </div>
            </div>
            <div>propose trade/accept trade</div>
            <div>make a counteroffer (PUT)</div>
            <div>withdraw trade</div>
        </div>
    )
}