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
        if (!selectedLeague || selectedLeague.currentWeek === 0 || !loggedInUser) {
            return
        }

        const connect = async () => {
            const newConnection = new HubConnectionBuilder()
                .withUrl(`${getSignalRUrl()}?leagueId=${selectedLeague.leagueId}&userId=${loggedInUser.id}`)
                .withAutomaticReconnect()
                .build()

            newConnection.on("ReceiveScoreReveal", (rosterPosition) => {
                console.log("Reveal received:", rosterPosition)
                setRevealedPositions(prev => {
                    const updated = [...new Set([...prev, rosterPosition])]
                    const key = `revealed-${selectedLeague?.leagueId}-${selectedLeague?.currentWeek}`
                    localStorage.setItem(key, JSON.stringify(updated)) // persists reveals in local storage
                    return updated
                })
            })

            try {
                await newConnection.start()
                console.log("Connected to ScoreRevealHub")

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
    }, [selectedLeague, loggedInUser])


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
