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

    // I don't know whether to change this in the front end or the backend to fix state issues.

    let pickCount = 1

    if (draftState?.draftOrder) {
        return (
            <ol>
            {draftState.draftOrder.map((u, index) => {
                const showRoundHeader = index % roundIndicator == 0

                const roundHeader = showRoundHeader ? (
                        <div key={`round-${index}`}>
                            Round {Math.floor(index / roundIndicator) + 1}
                        </div>
                    ) : null

                const userLine = (
                    <div key={u.userId}>
                        {pickCount++}. Name
                    </div>
                )

                return (
                    <React.Fragment key={u.userId}>
                        {roundHeader}
                        {userLine}
                    </React.Fragment>
                )
            })}
            </ol>
        )
    }
        
    
}