import { Form, FormGroup, Input, Label } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"
import { useState } from "react"
import { PostLeague } from "../../managers/leagueManager"
import { useNavigate } from "react-router-dom"


export const LeagueForm = () => {
    const { loggedInUser } = useAppContext()
    const [leagueObject, setLeagueObject] = useState({
        creatorId: loggedInUser.id,
        leagueName: "",
        playerLimit: 0,
        randomizedDraftOrder: true,
        usersVetoTrades: false,
        requiredFullToStart: true
    })
    const navigate = useNavigate()

    // waiver wire is a big undertaking, hold off until after first closed testing iteration

    const handleSubmit = (event) => {
        event.preventDefault()
        const newLeague = {...leagueObject}
        if (newLeague.leagueName != "" && newLeague.playerLimit != 0) {
            PostLeague(newLeague).then(() => {
                navigate("/league")
            })
        }
    }
    
    return (
        <div>
            <Form>
                <FormGroup>
                    <Label>League Name</Label>
                    <Input
                        type="text"
                        value={leagueObject.leagueName}
                        onChange={(e) => {
                            const objectCopy = {...leagueObject}
                            objectCopy.leagueName = e.target.value
                            setLeagueObject(objectCopy)
                        }}></Input>
                    <Label>Number of players</Label>
                    <Input
                        type="select"
                        onChange={(e) => {
                            const objectCopy = {...leagueObject}
                            objectCopy.playerLimit = Number(e.target.value)
                            setLeagueObject(objectCopy)
                        }}
                    >
                        <option value={2}>2</option>
                        <option value={4}>4</option>
                        <option value={6}>6</option>
                        <option value={8}>8</option>
                        <option value={10}>10</option>
                    </Input>
                    <Label>Let players veto trades</Label>
                    <Input
                        type="checkbox"
                        checked={leagueObject.usersVetoTrades}
                        onChange={() => {
                            const objectCopy = {...leagueObject}
                            objectCopy.usersVetoTrades = !leagueObject.usersVetoTrades
                            setLeagueObject(objectCopy)
                        }}></Input>
                    <Label>Randomized Draft Order</Label>
                    <Input
                        type="checkbox"
                        checked={leagueObject.randomizedDraftOrder}
                        onChange={() => {
                            const objectCopy = {...leagueObject}
                            objectCopy.randomizedDraftOrder = !leagueObject.randomizedDraftOrder
                            setLeagueObject(objectCopy)
                        }}
                    ></Input>
                    <Label>Require league to be full to start</Label>
                    <Input
                        type="checkbox"
                        checked={leagueObject.requiredFullToStart}
                        onChange={() => {
                            const objectCopy = {...leagueObject}
                            objectCopy.requiredFullToStart = !leagueObject.requiredFullToStart
                            setLeagueObject(objectCopy)
                        }}
                    ></Input>
                </FormGroup>
                <button
                    onClick={handleSubmit}
                >Create League</button>
            </Form>
        </div>
    )
}