import { useContext, useEffect, useRef, useState } from "react"
import "./DraftLayout.css"
import { DraftContext } from "./DraftPage"
import { useAppContext } from "../../contexts/AppContext"


export const DraftTimer = () => {
    const initialSeconds = 60
    const [secondsLeft, setSecondsLeft] = useState(initialSeconds)
    const intervalRef = useRef(null)
    const { currentTurn } = useContext(DraftContext)
    const { loggedInUser } = useAppContext()

    const startTimer = () => {
        clearInterval(intervalRef.current)
        setSecondsLeft(initialSeconds)

        intervalRef.current = setInterval(() => {
            setSecondsLeft((prev) => {
                if ( prev <= 1) {
                    clearInterval(intervalRef.current)
                    // fire expiration event 
                    return 0;
                }
                return prev - 1;
            });
        }, 1000);
    }
    
    const resetTimer = () => {
        clearInterval(intervalRef.current)
        setSecondsLeft(initialSeconds)
        startTimer()
    }
    
    useEffect(() => {
        // start timer
        startTimer()

        //cleanup on unmount
        return () => clearInterval(intervalRef.current)
        
    },[])

    // cut the reset button after testing
    return (
        <div>
            <div className="timer-seconds">{secondsLeft}</div>
            <button onClick={resetTimer}>reset timer</button>
            {currentTurn === loggedInUser.id ? <div className="timer-yourTurn">Your Turn to Draft!</div> 
            : <div className="timer-notYourTurn">Not your turn</div>}
        </div>
    )
}