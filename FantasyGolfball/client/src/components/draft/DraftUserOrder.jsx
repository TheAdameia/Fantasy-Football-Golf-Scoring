import { useContext } from "react"
import { DraftContext } from "./DraftPage"


export const DraftUserOrder = () => {
    const { draftState } = useContext(DraftContext)
    // given an order of users, generate a snake draft element
    const rosterSize = 3 // the number of rounds is equal to the roster size which will eventually be included in draftState
    // when called for, the top result is sliced
    // the rounds indicator needs to disappear when that round is up

    return (
        <div>

        </div>
    )
}