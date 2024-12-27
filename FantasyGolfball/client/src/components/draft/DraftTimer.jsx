import { useEffect, useRef, useState } from "react"


export const DraftTimer = () => {
    const initialSeconds = 60
    const [secondsLeft, setSecondsLeft] = useState(initialSeconds)
    const intervalRef = useRef(null)

    useEffect(() => {
        // start timer

        //cleanup on unmount
        return () => clearInterval(intervalRef.current)
        
    },[])

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
    // cut the reset button after testing
    return (
        <div>
            <div>{secondsLeft}</div>
            <button onClick={resetTimer}>reset</button>
        </div>
    )
}