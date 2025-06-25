import { createContext, useEffect, useState } from "react"
import { HubConnectionBuilder } from "@microsoft/signalr"
import { useAppContext } from "../../contexts/AppContext"

export const MatchupRevealContext = createContext()

export const MatchupRevealProvider = ({ children }) => {
    const { selectedLeague, loggedInUser } = useAppContext()
    const [connection, setConnection] = useState(null)
    const [revealedPositions, setRevealedPositions] = useState([])

    const getSignalRUrl = () => {
        if (window.location.hostname === "localhost") {
            return "https://localhost:5001/scorerevealhub"
        }
        return "https://fantasygolfball.org/scorerevealhub"
    }

    useEffect(() => {
        const key = `revealed-${selectedLeague?.leagueId}-${selectedLeague?.currentWeek}`

        const saved = localStorage.getItem(key)
        if (saved) {
            setRevealedPositions(JSON.parse(saved))
        }
    }, [selectedLeague])

    useEffect(() => {
        if (!selectedLeague || selectedLeague.currentWeek === 0){
            return
        } 

        const connect = async () => {
            const newConnection = new HubConnectionBuilder()
                .withUrl(`${getSignalRUrl()}?leagueId=${selectedLeague.leagueId}&userId=${loggedInUser.id}`)
                .withAutomaticReconnect()
                .build()

            try {
                await newConnection.start()
                console.log("Connected to ScoreRevealHub")

                // ask backend for already-revealed positions
                const alreadyRevealed = await newConnection.invoke(
                    "GetRevealedPositions",
                    selectedLeague.leagueId,
                    selectedLeague.currentWeek
                )

                console.log("Already revealed from server:", alreadyRevealed)

                const key = `revealed-${selectedLeague.leagueId}-${selectedLeague.currentWeek}`
                localStorage.setItem(key, JSON.stringify(alreadyRevealed))
                setRevealedPositions(alreadyRevealed)

                // set up handler after syncing state
                newConnection.on("ReceiveScoreReveal", (rosterPosition) => {
                    console.log("Reveal received:", rosterPosition)
                    setRevealedPositions(prev => {
                        const updated = [...new Set([...prev, rosterPosition])]
                        localStorage.setItem(key, JSON.stringify(updated))
                        return updated
                    })
                })

                setConnection(newConnection)
            } catch (err) {
                console.error("SignalR connection failed:", err)
            }
        }

        connect()

        return () => {
            if (connection) {
                connection.stop().catch(err => console.error("Failed to stop connection:", err))
            }
        }
    }, [selectedLeague])



    useEffect(() => { // judiciously erases past or future keys for the league
        const allKeys = Object.keys(localStorage)
        const prefix = `revealed-${selectedLeague?.leagueId}-`
        allKeys
            .filter(k => k.startsWith(prefix) && !k.endsWith(`-${selectedLeague?.currentWeek}`))
            .forEach(k => localStorage.removeItem(k))
    }, [selectedLeague])

    return (
        <MatchupRevealContext.Provider value={{ revealedPositions }}>
            {children}
        </MatchupRevealContext.Provider>
    )
}
