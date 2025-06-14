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
        if (!selectedLeague || selectedLeague.currentWeek === 0 || !loggedInUser) {
            return
        }

        const connect = async () => {
            const newConnection = new HubConnectionBuilder()
                .withUrl(`${getSignalRUrl()}?leagueId=${selectedLeague.leagueId}&userId=${loggedInUser.id}`)
                .withAutomaticReconnect()
                .build()

            newConnection.on("ReceiveScoreReveal", (userId, rosterPosition, revealData) => {
                console.log("Reveal received:", rosterPosition, revealData)
                setRevealedPositions(prev => [...new Set([...prev, rosterPosition])])
            })

            try {
                await newConnection.start()
                console.log("Connected to ScoreRevealHub")

                // If you have a JoinGroup method in your hub
                await newConnection.invoke("JoinMatchupChannel", selectedLeague.leagueId, loggedInUser.id)
                    .catch(err => console.error("JoinMatchupChannel failed", err))

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

    return (
        <MatchupRevealContext.Provider value={{ revealedPositions }}>
            {children}
        </MatchupRevealContext.Provider>
    )
}
