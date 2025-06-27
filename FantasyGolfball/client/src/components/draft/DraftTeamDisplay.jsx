import { Label, Input } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"


export const DraftTeamDisplay = ({ confirmCheck, setConfirmCheck }) => {
    const { roster } = useAppContext()

   
    if (!roster || !roster.rosterPlayers || roster.rosterPlayers.length == 0) {
        return (
            <div>No players drafted yet</div>
        )
    }

    return (
        <div>
            <Label>Ask for confirmation?</Label>
            <Input
                type="checkbox"
                checked={confirmCheck}
                onChange={() => {
                    const copy = confirmCheck
                    setConfirmCheck(!copy)
                }}
            >

            </Input>
        <div className="draft-selectedPlayers-container">
            {roster.rosterPlayers.map((rp) => {
                return (
                    <div key={rp.player.playerId} className="draft-selectedPlayers-playerContainer">
                        <div className="draft-selectedPlayers-position">{rp.player.position.positionShort}</div>
                        <div>{rp.player.playerFirstName} {rp.player.playerLastName}</div>
                    </div>
                )
            })}
        </div>
        </div>
    )
}