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
        playerLimit: 2,
        randomizedDraftOrder: true,
        usersVetoTrades: false,
        requiredFullToStart: true,
        seasonId: 1,
        seasonYear: 2025,
        maxRosterSize: 15, // I will need to add an option to change this
        realSeason: true,
        draftStartTime: "",
        seasonStartDate: "",
        advancement: "Weekly"
    })
    const navigate = useNavigate()

    const handleDateChange = (key) => (e) => {
        let selectedDate = new Date(e.target.value)

        selectedDate.setMinutes(0, 0, 0)
        if (selectedDate.getMinutes() >= 30) {
            selectedDate.setHours(selectedDate.getHours() + 1) // rounds to nearest hour
        }

        const formattedDate = selectedDate.toISOString().slice(0, 16) // "YYYY-MM-DDTHH:MM"

        setLeagueObject((prev) => ({
            ...prev,
            [key]: formattedDate
        }))
    }

    const handleSubmit = (event) => {
        event.preventDefault()
        const newLeague = {...leagueObject}

        if (!newLeague.realSeason && (newLeague.seasonStartDate == "" || newLeague.draftStartTime == "")) {
            window.alert("Times for Season start date and Draft start time must be set")
            return
        }

        if (newLeague.realSeason && newLeague.draftStartTime == "") { // it behooves me to handle other cases here also, such as draft time starting after the season starts
            window.alert("Draft start time must be set")
            return
        }

        if (newLeague.leagueName != "") {
            PostLeague(newLeague).then(() => {
                navigate("/league")
            })
        } else {
            window.alert("League must have a name")
            return
        }
    }
    
    return (
        <div>
            <h4>League Creation Form</h4>
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
                    <Label>Maximum Roster Size</Label>
                    <Input
                        type="select"
                        onChange={(e) => {
                            const objectCopy = {...leagueObject}
                            objectCopy.maxRosterSize = Number(e.target.value)
                            setLeagueObject(objectCopy)
                        }}
                    >
                        <option value={15}>15 (Recommended)</option>
                    </Input>
                    <Label>Draft Start Time (Rounds to nearest hour)</Label>
                    <Input
                        type="datetime-local"
                        value={leagueObject.draftStartTime}
                        onChange={handleDateChange("draftStartTime")}
                    />
                    <Label>Create Custom Season?</Label>
                    <Input
                        type="checkbox"
                        checked={!leagueObject.realSeason}
                        onChange={() => {
                            const objectCopy = {...leagueObject}
                            objectCopy.realSeason = !leagueObject.realSeason
                            setLeagueObject(objectCopy)
                        }}
                    ></Input>
                    
                    
                </FormGroup>
                {!leagueObject.realSeason ?
                <FormGroup>
                    <Label>Season Year</Label>
                    <Input
                        type="select"
                        onChange={(e) => {
                            const objectCopy = {...leagueObject}
                            objectCopy.seasonYear = Number(e.target.value)
                            setLeagueObject(objectCopy)
                        }}
                    >
                        <option value={2025}>Current Season</option>
                        {/* other years will go here once that's implemented */}
                    </Input>
                    <Label>Season Start Date</Label>
                    <Input
                        type="datetime-local"
                        value={leagueObject.seasonStartDate}
                        onChange={handleDateChange("seasonStartDate")}
                    />
                    <Label>A week of Season time advances...</Label>
                    <Input
                        type="select"
                        onChange={(e) => {
                            const objectCopy = {...leagueObject}
                            objectCopy.advancement = String(e.target.value)
                            setLeagueObject(objectCopy)
                        }}
                    >
                        <option value={"Weekly"}>Every Week (default)</option>
                        <option value={"Daily"}>Every Day</option>
                    </Input>
                </FormGroup>
                : <></>}
                <button
                    onClick={handleSubmit}
                >Create League</button>
            </Form>
        </div>
    )
}