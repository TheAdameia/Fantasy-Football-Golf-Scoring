import { useAppContext } from "../../contexts/AppContext"


export const DraftPage = () => {
    const { players } = useAppContext()

    return (
        <div>
            <div>Left side boxes
                <div>Top left box - timer, turn indicator, next auto draft</div>
                <div>Draft round user order</div>
            </div>
            <div>Right side boxes
                <div>Player selection queue</div>
                <div>My team display</div>
                <div>Chat</div>
            </div>
            <div>Center box
                <div>Selected player box</div>
                <div>Player search interface</div>
            </div>
        </div>
    )
}