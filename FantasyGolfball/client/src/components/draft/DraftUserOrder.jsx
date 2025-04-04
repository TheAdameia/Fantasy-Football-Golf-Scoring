import { useContext, useState } from "react"
import { DraftContext } from "./DraftPage"


export const DraftUserOrder = () => {
    const { draftState, selectedLeague } = useContext(DraftContext)
    // this is just going to be easier to do in the backend. Not to mention state won't be preserved

    // const [rounds, setRounds] = useState()

    // const userOrder = draftState.draftOrder
    // const numberOfRounds = selectedLeague.maxRosterSize

    // const generateRounds = () => {
    //     const result = []

    //     for (let round = 0; round <numberOfRounds; round ++) {
    //         const isEvenRound = round % 2 == 1
    //         const roundOrder = isEvenRound ? [...userOrder].reverse() : userOrder // reverses the draft order every other round
    //     }

        
    // }

    
    
    
    
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