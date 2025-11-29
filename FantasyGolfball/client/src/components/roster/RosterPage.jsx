import { RosterCard } from "./RosterCard"
import { useAppContext } from "../../contexts/AppContext"
import { Button } from "reactstrap"
import { useNavigate } from "react-router-dom"
import { useEffect, useState } from "react"
import { StatsWindow } from "../widgets/StatsWindow"


export const RosterPage = () => {
    const { loggedInUser, selectedLeague } = useAppContext()
    const navigate = useNavigate()
    const [timeUntilReveals, setTimeUntilReveals] = useState("")
    const [rosterLock, setRosterLock] = useState(false)
    const [selectedPlayerForStats, setSelectedPlayerForStats] = useState(null);


    useEffect(() => {
        if (!selectedLeague || selectedLeague.currentWeek < 1 || !selectedLeague.seasonStartDate) return

        const seasonStart = new Date(selectedLeague.seasonStartDate)
        let msPerWeek, totalRevealDuration

        switch (selectedLeague.advancement) {
            case 0: // Weekly
                msPerWeek = 1000 * 60 * 60 * 24 * 7
                totalRevealDuration = 1000 * 60 * 60 * 8
                break
            case 1: // Daily
                msPerWeek = 1000 * 60 * 60 * 24
                totalRevealDuration = 1000 * 60 * 60
                break
            case 2: // Hourly
                msPerWeek = 1000 * 60 * 60
                totalRevealDuration = 1000 * 60 * 10
                break
            case 3: // Turbo
                msPerWeek = 1000 * 60 * 15
                totalRevealDuration = 1000 * 60 * 5
                break
            default:
                return
        }

        const nextWeekTime = new Date(seasonStart.getTime() + selectedLeague.currentWeek * msPerWeek)
        const revealStartTime = new Date(nextWeekTime.getTime() - totalRevealDuration)

        const updateRevealStatus = () => {
            const now = new Date().getTime()
            const start = revealStartTime.getTime()
            const end = nextWeekTime.getTime()

            if (now >= start && now <= end) {
                setRosterLock(true)
                setTimeUntilReveals("Roster is locked during reveals.")
            } else if (now < start) {
                setRosterLock(false)
                const diff = start - now

                const days = Math.floor(diff / (1000 * 60 * 60 * 24))
                const hours = Math.floor((diff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60))
                const minutes = Math.floor((diff % (1000 * 60 * 60)) / (1000 * 60))
                const seconds = Math.floor((diff % (1000 * 60)) / 1000)

                let formatted = ""
                if (days > 0) formatted += `${days}d `
                if (hours > 0 || days > 0) formatted += `${hours}h `
                if (minutes > 0 || hours > 0 || days > 0) formatted += `${minutes}m `
                formatted += `${seconds}s`

                setTimeUntilReveals(`Roster locks in: ${formatted}`)
            } else {
                setRosterLock(false)
                setTimeUntilReveals("Reveals completed.")
            }
        }

        updateRevealStatus()
        const interval = setInterval(updateRevealStatus, 1000)

        return () => clearInterval(interval)
    }, [selectedLeague])

    return (
        <div>
            <div>
                <h2>{loggedInUser.userName}'s team</h2>
                {!selectedLeague?.isLeagueFinished && (
                    <h5>{timeUntilReveals}</h5>
                )}
                <div>
                    <Button onClick={() => navigate(`/create-trade`)}>Create a trade</Button>
                </div>
            </div>
            <RosterCard rosterLock={rosterLock} setSelectedPlayerForStats={setSelectedPlayerForStats}/>
            {selectedPlayerForStats && (
                <StatsWindow
                    player={selectedPlayerForStats}
                    rosterLock={rosterLock}
                    onClose={() => setSelectedPlayerForStats(null)}
                />
            )}
        </div>
    )
}