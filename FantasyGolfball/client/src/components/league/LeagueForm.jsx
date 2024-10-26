import { Form, FormGroup, Input, Label } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"


export const LeagueForm = () => {
    const { loggedInUser } = useAppContext()

    return (
        <div>
            <Form>
                <FormGroup>
                    <Label>League Name</Label>
                    <Input></Input>
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