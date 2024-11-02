import { Form, FormGroup, Input, Label } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"
import { useContext, useState } from "react"


export const LeagueForm = () => {
    const { loggedInUser } = useAppContext()
    const [leagueObject, setLeagueObject] = useState({
        name: "",
        playerLimit: 0,
        randomizedDraftOrder: true
    })

    // Randomized draft order option (default to yes)
    // waiver wire is a big undertaking, hold off until after first closed testing iteration
    // vetoing trades?
    
    return (
        <div>
            <Form>
                <FormGroup>
                    <Label>League Name</Label>
                    <Input
                        type="text"
                        value={leagueObject.name}
                        onChange={(e) => {
                            const objectCopy = {...leagueObject}
                            objectCopy.name = e.target.value
                            setLeagueObject(objectCopy)
                        }}></Input>
                    <Label>Number of players</Label>
                    <Input
                        type="select"
                        onChange={(e) => {
                            const objectCopy = {...leagueObject}
                            objectCopy.playerLimit = e.target.value
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
                    <Input></Input>
                    <Label>Randomized Draft Order</Label>
                    <Input
                        type="checkbox"
                        onChange={() => {
                            const objectCopy = {...leagueObject}
                            objectCopy.randomizedDraftOrder = !leagueObject.randomizedDraftOrder
                            setLeagueObject(objectCopy)
                        }}
                    ></Input>
                </FormGroup>
                <button>Create League</button>
            </Form>
        </div>
    )
}