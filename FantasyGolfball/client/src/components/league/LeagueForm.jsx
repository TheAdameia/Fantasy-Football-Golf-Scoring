import { Form, FormGroup, Input, Label } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"
import { useEffect, useState } from "react"
import { PostLeague } from "../../managers/leagueManager"
import { useNavigate } from "react-router-dom"
import "./League.css"
import { GetAllSeasons } from "../../managers/seasonManager"


export const LeagueForm = () => {
    const { loggedInUser, getAndSetLeagues } = useAppContext()
    const [leagueObject, setLeagueObject] = useState({
        creatorId: loggedInUser.id,
        leagueName: "",
        playerLimit: 2,
        randomizedDraftOrder: true,
        usersVetoTrades: false,
        requiredFullToStart: true,
        seasonYear: 2025,
        maxRosterSize: 15,
        draftStartTime: "",
        seasonStartDate: "",
        advancement: "Weekly",
        joinPassword: "",
        requiresPassword: false
    })
    const [seasons, setSeasons] = useState()
    const navigate = useNavigate()

    const toLocalInputValue = (utcString) => {
        if (!utcString) return ""
        const date = new Date(utcString)
        const local = new Date(date.getTime() - date.getTimezoneOffset() * 60000)
        return local.toISOString().slice(0, 16)
    }

    const roundToNearest5Minutes = (date) => {
        const rounded = new Date(date)
        const minutes = rounded.getMinutes()
        const roundedMinutes = Math.round(minutes / 5) * 5 // rounds to 5 minute interval
        rounded.setMinutes(roundedMinutes)
        rounded.setSeconds(0)
        rounded.setMilliseconds(0)
        return rounded
    }


    const handleDateChange = (key) => (e) => {
        const localDate = new Date(e.target.value)
        const roundedDate = roundToNearest5Minutes(localDate)
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
                getAndSetLeagues()
                navigate("/league")
            })
        } else {
            window.alert("League must have a name")
            return
        }
    }

    const getAndSetSeasons = () => {
        GetAllSeasons().then(setSeasons)
    }

    useEffect(() => {
        getAndSetSeasons()
    }, [])

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
                        <Label>Draft Start Time (Rounds to 5 minute interval):</Label>
                        <Input
                            type="datetime-local"
                            value={toLocalInputValue(leagueObject.draftStartTime)}
                            onChange={handleDateChange("draftStartTime")}
                        />
                    </div>

                    <div>
                        <Label>Season Year:</Label>
                        <Input
                            type="select"
                            onChange={(e) => {
                                const objectCopy = { ...leagueObject }
                                objectCopy.seasonYear = Number(e.target.value)
                                setLeagueObject(objectCopy)
                            }}
                        >
                            <option disabled>Random</option>
                            {seasons && seasons.length > 0 
                                ? seasons.map(s => 
                                    <option value={s.seasonYear} key={s.seasonYear}>{s.seasonYear}</option>
                                ) : <option></option>
                            }
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
                            <option value={"Turbo"}>Every 15 Minutes</option>
                        </Input>
                    </div>
                </FormGroup>
                <button onClick={handleSubmit}>Create League</button>
            </Form>
        </div>
    )
}
