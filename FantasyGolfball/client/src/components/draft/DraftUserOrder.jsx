import { useContext } from "react"
import { DraftContext } from "./DraftPage"


export const DraftUserOrder = () => {
    const { draftState } = useContext(DraftContext)
    // the number of rounds is equal to the roster size which will eventually be included in draftState

    // a more serious rethink will be necessary once real data is being used. This will not function (possibly at all) when that is ported, but I don't have a good enough understanding of the data at the time to make this work.

    return (
        <ol>
            {draftState.userTurnOrder.map((u) => {
                return (
                    <li key={u.userId}>{u.name}</li>
                )
            })}
        </ol>
    )
}