import { Form, FormGroup, Input, Label } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"
import { useState } from "react"
import { PostLeague } from "../../managers/leagueManager"
import { useNavigate } from "react-router-dom"
import "./League.css"


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
        maxRosterSize: 15,
        realSeason: false,
        draftStartTime: "",
        seasonStartDate: "",
        advancement: "Weekly",
        joinPassword: "",
        requiresPassword: false
    })
    const navigate = useNavigate()

    const toLocalInputValue = (utcString) => {
        if (!utcString) return ""
        const date = new Date(utcString)
        const local = new Date(date.getTime() - date.getTimezoneOffset() * 60000)
        return local.toISOString().slice(0, 16)
    }

    const roundToNearestHour = (date) => {
        const rounded = new Date(date)
        if (rounded.getMinutes() >= 30) {
            rounded.setHours(rounded.getHours() + 1)
        }
        rounded.setMinutes(0, 0, 0)
        return rounded
    }

    const handleDateChange = (key) => (e) => {
        const localDate = new Date(e.target.value)
        const roundedDate = roundToNearestHour(localDate)
        const utcDateString = roundedDate.toISOString()

        setLeagueObject((prev) => ({
            ...prev,
            [key]: utcDateString
        }))
    }

    const handleSubmit = (event) => {
        event.preventDefault()
        const newLeague = { ...leagueObject }

        if (!newLeague.realSeason && (!newLeague.seasonStartDate || !newLeague.draftStartTime)) {
            window.alert("Times for Season start date and Draft start time must be set")
            return
        }

        if (newLeague.realSeason && !newLeague.draftStartTime) {
            window.alert("Draft start time must be set")
            return
        }

        if (newLeague.leagueName !== "") {
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
                    <div>
                        <Label className="leagues-widget">League Name:</Label>
                        <Input
                            type="text"
                            value={leagueObject.leagueName}
                            onChange={(e) => {
                                const objectCopy = { ...leagueObject }
                                objectCopy.leagueName = e.target.value
                                setLeagueObject(objectCopy)
                            }}>
                        </Input>
                    </div>

                    <div className="leagues-widgets-container">
                        <Label className="leagues-widget">Join Password (optional):</Label>
                        <Input 
                            type="checkbox"
                            checked={leagueObject.requiresPassword}
                            onChange={() => {
                                const objectCopy = { ...leagueObject}
                                objectCopy.requiresPassword = !leagueObject.requiresPassword
                                setLeagueObject(objectCopy)
                            }}
                        ></Input>
                    </div>
                    
                    {leagueObject.requiresPassword ? 
                    <Input
                        type="text"
                        value={leagueObject.joinPassword}
                        onChange={(e) => {
                            const objectCopy = { ...leagueObject}
                            objectCopy.joinPassword = e.target.value
                            setLeagueObject(objectCopy)
                        }}
                    ></Input>
                    : <></>}

                    <div>
                        <Label>Number of Players:</Label>
                        <Input
                            type="select"
                            onChange={(e) => {
                                const objectCopy = { ...leagueObject }
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
                    </div>

                    <div className="leagues-widgets-container">
                        <Label className="leagues-widget">Allow trade vetoes:</Label>
                        <Input
                            disabled
                            type="checkbox"
                            checked={leagueObject.usersVetoTrades}
                            onChange={() => {
                                const objectCopy = { ...leagueObject }
                                objectCopy.usersVetoTrades = !leagueObject.usersVetoTrades
                                setLeagueObject(objectCopy)
                            }}
                        ></Input>
                    </div>

                    <div className="leagues-widgets-container">
                        <Label className="leagues-widget">Randomized Draft Order:</Label>
                        <Input
                            disabled
                            type="checkbox"
                            checked={leagueObject.randomizedDraftOrder}
                            onChange={() => {
                                const objectCopy = { ...leagueObject }
                                objectCopy.randomizedDraftOrder = !leagueObject.randomizedDraftOrder
                                setLeagueObject(objectCopy)
                            }}
                        ></Input>
                    </div>

                    <div className="leagues-widgets-container">
                        <Label className="leagues-widget">Require league to be full to start:</Label>
                        <Input
                            disabled
                            type="checkbox"
                            checked={leagueObject.requiredFullToStart}
                            onChange={() => {
                                const objectCopy = { ...leagueObject }
                                objectCopy.requiredFullToStart = !leagueObject.requiredFullToStart
                                setLeagueObject(objectCopy)
                            }}
                        ></Input>
                    </div>

                    <div>
                        <Label>Maximum Roster Size:</Label>
                        <Input
                            disabled
                            type="select"
                            onChange={(e) => {
                                const objectCopy = { ...leagueObject }
                                objectCopy.maxRosterSize = Number(e.target.value)
                                setLeagueObject(objectCopy)
                            }}
                        >
                            <option value={15}>15 (Recommended)</option>
                        </Input>
                    </div>

                    <div>
                        <Label>Draft Start Time (Rounds to nearest hour):</Label>
                        <Input
                            type="datetime-local"
                            value={toLocalInputValue(leagueObject.draftStartTime)}
                            onChange={handleDateChange("draftStartTime")}
                        />
                    </div>

                    <div className="leagues-widgets-container">
                        <Label className="leagues-widget">Create Custom Season?</Label>
                        <Input
                            disabled
                            type="checkbox"
                            checked={!leagueObject.realSeason}
                            onChange={() => {
                                const objectCopy = { ...leagueObject }
                                objectCopy.realSeason = !leagueObject.realSeason
                                setLeagueObject(objectCopy)
                            }}
                        ></Input>
                    </div>
                </FormGroup>

                {!leagueObject.realSeason ? (
                    <FormGroup>
                        <div>
                            <Label>Season Year:</Label>
                            <Input
                                disabled
                                type="select"
                                onChange={(e) => {
                                    const objectCopy = { ...leagueObject }
                                    objectCopy.seasonYear = Number(e.target.value)
                                    setLeagueObject(objectCopy)
                                }}
                            >
                                <option value={2025}>Current Season</option>
                            </Input>
                        </div>

                        <div>
                            <Label>Season Starts On:</Label>
                            <Input
                                type="datetime-local"
                                value={toLocalInputValue(leagueObject.seasonStartDate)}
                                onChange={handleDateChange("seasonStartDate")}
                            />
                        </div>

                        <div>
                            <Label>A week of Season time advances...</Label>
                            <Input
                                type="select"
                                onChange={(e) => {
                                    const objectCopy = { ...leagueObject }
                                    objectCopy.advancement = String(e.target.value)
                                    setLeagueObject(objectCopy)
                                }}
                            >
                                <option value={"Weekly"}>Every Week (default)</option>
                                <option value={"Daily"}>Every Day</option>
                                <option value={"Hourly"}>Every Hour</option>
                            </Input>
                        </div>
                    </FormGroup>
                ) : null}

                <button onClick={handleSubmit}>Create League</button>
            </Form>
        </div>
    )
}
