import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import "./trade.css"

export const TradePlayerCard = ({ playerId, setTradeOffer }) => {
    const { players } = useAppContext()
    const [player, SetPlayer] = useState()

    useEffect(() => {
        const thisPlayer = players.filter(p => p.playerId == playerId)
        SetPlayer(thisPlayer[0])
    }, [playerId, players])

    if (player) {
        return (
            <div className="trade-player-card">
                <div className="trade-player-info">
                    {player.position.positionShort} {player.playerFullName}, {player.playerTeams[0].team.teamCity} {player.playerTeams[0].team.teamName}, {player.playerStatuses[0].status.statusType}
                </div>
                <button
                    className="trade-remove-button"
                    onClick={() => {
                        setTradeOffer(prev => ({
                            ...prev,
                            firstPartyOffering: prev.firstPartyOffering.filter(id => id != playerId),
                            secondPartyOffering: prev.secondPartyOffering.filter(id => id != playerId)
                        }))
                    }}
                >
                    x
                </button>
            </div>
        )
    }
    
}