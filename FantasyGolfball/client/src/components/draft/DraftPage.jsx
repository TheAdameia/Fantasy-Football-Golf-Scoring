import { DraftPlayerList } from "./DraftPlayerList"


export const DraftPage = () => {

    // now that I have a rough idea of how this is going to be structured in HTML, I can create more discrete tasks based on the features that this page will have.
    // this page will need to sort users into particular SignalR groups based on the league that's entering the draft stage. I don't know how to do that yet.
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
                <DraftPlayerList />
            </div>
        </div>
    )
}