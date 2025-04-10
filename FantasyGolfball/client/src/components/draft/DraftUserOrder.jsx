import React, { useContext, useEffect, useState } from "react"
import { DraftContext } from "./DraftPage"
import { useAppContext } from "../../contexts/AppContext"


export const DraftUserOrder = () => {
    const { draftState } = useContext(DraftContext)
    const { selectedLeague } = useAppContext()
    const [ roundIndicator, setRoundIndicator] = useState(selectedLeague?.playerLimit ?? 8)

    useEffect(() => {
        if (selectedLeague?.playerLimit) {
            setRoundIndicator(selectedLeague.playerLimit)
        }
    }, [selectedLeague?.playerLimit])

    const indexByUser = (permanentDraftOrder, userId, currentIndex) => {
        // counts how many times this user has appeared up to this point
        return permanentDraftOrder.slice(0, currentIndex + 1).filter(id => id === userId).length - 1
    }
    

    if (draftState?.permanentDraftOrder) {
        return (
            <div className="draft-DraftUserOrder-container">
            {draftState.permanentDraftOrder.map((u, index) => {
                const showRoundHeader = index % roundIndicator == 0

                const roundHeader = showRoundHeader ? (
                        <div key={`round-${index}`} className="draft-DraftUserOrder-round">
                            Round {Math.floor(index / roundIndicator) + 1}
                        </div>
                    ) : null

                const pickNumber = index + 1
                const playerPick = draftState.userRosters[u]?.[indexByUser(draftState.permanentDraftOrder, u, index)] ?? "-"
                const playerPickObject = draftState.permanentPlayers.filter(p => p.playerId == playerPick)
                const drafter = selectedLeague.leagueUsers.filter(lu => lu.userProfileId == u)

                const userLine = (
                    <div key={`${u}-${pickNumber}`}>
                        {pickNumber}. {drafter[0]?.userProfile?.userName}, 
                        {
                            playerPickObject?.[0]
                                ? ` ${playerPickObject[0]?.position?.positionShort} ${playerPickObject[0]?.playerFullName}`
                                : "-"
                        }
                    </div>
                )

                return (
                    <React.Fragment key={`${u}-${pickNumber}`}>
                        {roundHeader}
                        {userLine}
                    </React.Fragment>
                )
            })}
            </div>
        )
    }
        
    
}