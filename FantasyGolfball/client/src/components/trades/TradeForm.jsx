import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { Input, Label, Spinner } from "reactstrap"
import { TradePlayerCard } from "./TradePlayerCard"
import "./trade.css"


export const TradeForm = () => {
    const { selectedLeague, roster, loggedInUser } = useAppContext()
    const [tradeOffer, setTradeOffer] = useState({
        leagueId: 0,
        firstPartyRosterId: 0,
        secondPartyRosterId: 0,
        firstPartyOffering: [],
        secondPartyOffering: []
    })
    const [secondPartyRoster, setSecondPartyRoster] = useState()

    useEffect(() => {
        if (roster?.rosterId && selectedLeague) {
            const objectCopy = {...tradeOffer}
            objectCopy.firstPartyRosterId = roster.rosterId
            objectCopy.leagueId = selectedLeague.leagueId
            setTradeOffer(objectCopy)
        }
    }, [roster])

    if (roster && selectedLeague) {
        return (
            <div className="trade-form-container">
                <h4>Create a Trade Offer</h4>
                <div className="trade-form-selects-container">
                    <div className="trade-form-select-box">
                        <div className="trade-form-inputs-box">
                            <Label>Select Your Players:</Label>
                            <Input
                                type="select"
                                onChange={(e) => {
                                    const value = parseInt(e.target.value)
                                    if (isNaN(value)) {
                                        return
                                    }
                                    if (tradeOffer.firstPartyOffering.includes(value)) {
                                        return
                                    }
                                    setTradeOffer(prev => ({
                                        ...prev,
                                        firstPartyOffering: [...prev.firstPartyOffering, value]
                                    }))
                                }}
                            >
                                <option>-</option>
                                {roster.rosterPlayers.map(rp => {
                                    return (
                                        <option key={rp.playerId} value={rp.playerId}>
                                            {rp.player.position.positionShort} {rp.player.playerFullName}, {rp.player.playerTeams[0].team.teamCity} {rp.player.playerTeams[0].team.teamName}, {rp.player.playerStatuses[0].status.statusType}
                                        </option>
                                    )
                                })}
                            </Input>
                        </div>
                        <div className="trade-form-selected-box">
                            {tradeOffer.firstPartyOffering.map(p => {
                                return (
                                    <TradePlayerCard key={p} playerId={p} setTradeOffer={setTradeOffer}/>
                                )
                            })}
                        </div>
                    </div>

                    <div className="trade-form-select-box">
                        <div className="trade-form-inputs-box">
                            <Label>Select the second party:</Label>
                            <Input
                                type="select"
                                onChange={(e) => {
                                    const selectedLeagueUser = selectedLeague.leagueUsers.find(lu => lu.userProfileId == e.target.value)
                                    if (!selectedLeagueUser) {
                                        setTradeOffer(prev => ({
                                            ...prev,
                                            secondPartyRosterId: 0,
                                            secondPartyOffering: []
                                        }))
                                        setSecondPartyRoster(null)
                                        return
                                    }
                                    setSecondPartyRoster(selectedLeagueUser)
                                    setTradeOffer(prev => ({
                                        ...prev,
                                        secondPartyRosterId: selectedLeagueUser.rosterId,
                                        secondPartyOffering: []
                                    }))
                                }}
                            >
                                <option>-</option>
                                {selectedLeague.leagueUsers
                                    .filter(lu => lu.userProfileId != loggedInUser.id)
                                    .map(lu => {
                                    return (
                                        <option key={lu.userProfileId} value={lu.userProfileId}>
                                            {lu.userProfile.userName}
                                        </option>
                                    )
                                })}
                            </Input>
                            <Label>Select second party's players:</Label>
                            <Input
                                type="select"
                                onChange={(e) => {
                                    const value = parseInt(e.target.value)
                                    if (isNaN(value)) {
                                        return
                                    }
                                    if (tradeOffer.secondPartyOffering.includes(value)) {
                                        return
                                    }
                                    setTradeOffer(prev => ({
                                        ...prev,
                                        secondPartyOffering: [...prev.secondPartyOffering, value]
                                    }))
                                }}
                            >
                                <option>-</option>
                                {secondPartyRoster?.roster?.rosterPlayers.map(rp => {
                                    return (
                                        <option key={rp.playerId} value={rp.playerId}>
                                            {rp.player.position.positionShort} {rp.player.playerFullName}, {rp.player.playerTeams[0].team.teamCity} {rp.player.playerTeams[0].team.teamName}, {rp.player.playerStatuses[0].status.statusType}
                                        </option>
                                    )
                                })}
                            </Input>
                        </div>
                        <div className="trade-form-selected-box">
                            {tradeOffer.secondPartyOffering.map(p => {
                                return (
                                    <TradePlayerCard key={p} playerId={p} setTradeOffer={setTradeOffer}/>
                                )
                            })}
                        </div>
                    </div>
                </div>
                <button className="trade-form-finalize-button">Finalize Trade Offer</button>
            </div>
        )
    } else {
        return (
            <Spinner />
        )
    }
}