import { Form, FormGroup, Input, Label } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"
import { useContext, useState } from "react"


export const LeagueForm = () => {
    const { loggedInUser } = useAppContext()
    const [leagueObject, setLeagueObject] = useState({
        name: "",
        playerLimit: 0,

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
                    <Input></Input>
                    <Label>League Name</Label>
                    <Input></Input>
                    <Label>League Name</Label>
                    <Input></Input>
                </FormGroup>
            </Form>
        </div>
    )
}