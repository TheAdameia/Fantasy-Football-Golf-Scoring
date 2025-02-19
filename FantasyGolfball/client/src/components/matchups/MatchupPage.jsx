import { useAppContext } from "../../contexts/AppContext"
import { MatchupCard } from "./MatchupCard"


export const MatchupPage = () => {
    const { matchups } = useAppContext()


    if (matchups != null)
    {
        return (
            <div>
                {matchups.map((matchup) => {
                    return (
                        <MatchupCard
                            matchup={matchup}
                            key={matchup.matchupId}
                        />
                    )
                })}
            </div>
        )
    }
    
    return (
        <div>Quack!</div>
    )
}