import { RosterCard } from "./RosterCard"
import { useAppContext } from "../../contexts/AppContext"
import { Button } from "reactstrap"


export const RosterPage = () => {
    const { loggedInUser } = useAppContext()

    return (
        <div>
            <div>
                <h2>{loggedInUser.userName}'s team</h2>
                <div>
                    <Button>Create a trade</Button>
                </div>
            </div>
            <RosterCard/>
        </div>
    )
}