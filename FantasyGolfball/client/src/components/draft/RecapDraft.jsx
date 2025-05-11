import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"
import { GetHistoricalDraftState } from "../../managers/historicalManager"


export const RecapDraft = () => {
    const [historicalDraftState, setHistoricalDraftState] = useState()
    const { selectedLeague, players } = useAppContext()

    const GetAndSetHistoricalDraftState = (leagueId) => {
        GetHistoricalDraftState(leagueId).then(setHistoricalDraftState)
    }

    useEffect(() => {
        if (selectedLeague) {
            GetAndSetHistoricalDraftState(selectedLeague.leagueId)
        }
    }, [selectedLeague])

    return (
        <div>bubkis</div>
    )
}