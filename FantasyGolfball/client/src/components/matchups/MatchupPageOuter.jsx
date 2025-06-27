import { MatchupPage } from "./MatchupPage"
import { MatchupRevealProvider } from "./MatchupRevealContext"


export const MatchupPageOuter = () => {
    return (
        <MatchupRevealProvider>
            <MatchupPage />
        </MatchupRevealProvider>
    )
}