import { useContext } from "react"
import { DraftContext } from "./DraftPage"


export const DraftTeamDisplay = () => {
    const { draftState } = useContext(DraftContext)

    // if the roster for this user has at least one player in it, display those players; otherwise display no players

    return (
        <div>No players drafted yet</div>
    )
}