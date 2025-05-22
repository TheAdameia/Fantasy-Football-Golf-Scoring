import { RosterCard } from "./RosterCard"
import { useAppContext } from "../../contexts/AppContext"
import { Button } from "reactstrap"
import { useNavigate } from "react-router-dom"


export const RosterPage = () => {
    const { loggedInUser } = useAppContext()
    const navigate = useNavigate()

    return (
        <div>
            <div>
                <h2>{loggedInUser.userName}'s team</h2>
                <div>
                    <Button onClick={() => navigate(`/create-trade`)}>Create a trade</Button>
                </div>
            </div>
            <RosterCard/>
        </div>
    )
}