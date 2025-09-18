import { useEffect, useState } from "react"
import { ImportDefenseData, ImportPlayerData, ImportScoringData } from "../../managers/importDataManager"
import "./DataImport.css"
import { GetAllSeasons, PostNewSeason } from "../../managers/seasonManager"


export const DataImportPage = () => {
    const [file, setFile] = useState(null)
    const [scoringFile, setScoringFile] = useState(null)
    const [defenseFile, setDefenseFile] = useState(null)
    const [seasonId, setSeasonId] = useState("")
    const [seasonIdScoring, setSeasonIdScoring] = useState("")
    const [seasonIdDefense, setSeasonIdDefense] = useState("")
    const [status, setStatus] = useState("")
    const [scoringStatus, setScoringStatus] = useState()
    const [defenseStatus, setDefenseStatus] = useState()
    const [seasons, setSeasons] = useState()

    const [seasonYear, setSeasonYear] = useState(0)
    const [seasonWeeks, setSeasonWeeks] = useState(18)


    // I could make elegant handlers here, but why would I put in the effort for something
    // that will be used extremely infrequently?
    
    const handleFileChange = (e) => {
        setFile(e.target.files[0])
    }

    const handleScoringFileChange = (e) => {
        setScoringFile(e.target.files[0])
    }

    const handleDefenseFileChange = (e) => {
        setDefenseFile(e.target.files[0])
    }

    const handleSeasonIdChange = (e) => {
        setSeasonId(e.target.value)
    }

    const handleScoringSeasonIdChange = (e) => {
        setSeasonIdScoring(e.target.value)
    }

    const handleDefenseSeasonIdChange = (e) => {
        setSeasonIdDefense(e.target.value)
    }

    const handlePlayerUpload = async () => {
        if (!file || !seasonId) {
            setStatus("Please select a file and enter a season ID.")
            return
        }

        const formData = new FormData()
        formData.append("file", file)

        try {
            const response = await ImportPlayerData(seasonId, formData)
            if (response.ok) {
                const result = await response.json()
                setStatus(result.message || "Upload successful!")
            } else {
                const errorText = await response.text()
                setStatus(`Upload failed: ${errorText}`)
            }
            } catch (error) {
                setStatus(`Upload failed: ${error.message}`)
        }
    }

    const handleScoringUpload = async () => {
        if (!scoringFile || !seasonIdScoring) {
            setStatus("Please select a file and enter a season ID.")
            return
        }

        const formData = new FormData()
        formData.append("file", scoringFile)

        try {
            const response = await ImportScoringData(seasonIdScoring, formData)
            if (response.ok) {
                const result = await response.json()
                setScoringStatus(result.message || "Upload successful!")
            } else {
                const errorText = await response.text()
                setScoringStatus(`Upload failed: ${errorText}`)
            }
            } catch (error) {
                setScoringStatus(`Upload failed: ${error.message}`)
        }
    }

    const handleDefenseUpload = async () => {
        if (!defenseFile || !seasonIdDefense) {
            setStatus("Please select a file and enter a season ID.")
            return
        }

        const formData = new FormData()
        formData.append("file", defenseFile)

        try {
            const response = await ImportDefenseData(seasonIdDefense, formData)
            if (response.ok) {
                const result = await response.json()
                setDefenseStatus(result.message || "Upload successful!")
            } else {
                const errorText = await response.text()
                setDefenseStatus(`Upload failed: ${errorText}`)
            }
            } catch (error) {
                setDefenseStatus(`Upload failed: ${error.message}`)
        }
    }

    const ConfirmSeason = () => {
        const confirmed = window.confirm(`Create Season with year ${seasonYear} and weeks ${seasonWeeks}?`)
        if (confirmed) {
            handleCreateSeason(seasonYear, seasonWeeks)
        } else {
            return
        }
    }

    const handleCreateSeason = (seasonYear, seasonWeeks) => {
        PostNewSeason(seasonYear, seasonWeeks).then(getAndSetSeasons())
    }

    const getAndSetSeasons = () => {
        GetAllSeasons().then(setSeasons)
    }

    useEffect(() => {
        getAndSetSeasons()
    }, [])

    return (
        <div>
            <h4 className="taco"> Season List</h4>
            {seasons ?
            seasons.map(s =>
                <div key={s.seasonId}>
                    Season Year: {s.seasonYear}, SeasonId: {s.seasonId}, Season Weeks: {s.seasonWeeks}
                </div>
            )
            : <></>}
            <h4 className="taco">Create Season by Year, total weeks</h4>
            <div className="taco">
                <label className="taco">Season Year:</label>
                <input
                    type="number"
                    value={seasonYear}
                    onChange={(e) => {
                        let newNumber = e.target.value
                        setSeasonYear(newNumber)
                    }}>
                </input>
            </div>
            <div className="taco">
                <label className="taco">Season Weeks:</label>
                <input
                    type="number"
                    value={seasonWeeks}
                    onChange={(e) => {
                        let newNumber = e.target.value
                        setSeasonWeeks(newNumber)
                    }}>
                </input>
            </div>
            <div className="taco">
                <button onClick={ConfirmSeason}>Create new Season</button>
            </div>
            
                <h2 className="taco">Upload Defense CSV</h2>
                <div className="taco">
                    <label>Defense season ID:</label>
                    <input 
                        type="number"
                        value={seasonIdDefense}
                        onChange={handleDefenseSeasonIdChange}
                    />
                </div>
                <div className="taco">
                    <input type="file" accept=".csv" onChange={handleDefenseFileChange}/>
                </div>
                <button onClick={handleDefenseUpload}>Upload Defense</button>
                {defenseStatus && <p>{defenseStatus}</p>}

            <h2 className="taco">Upload Player CSV</h2>
            <div className="taco">
                <label>Season ID:</label>
                <input
                    type="number"
                    value={seasonId}
                    onChange={handleSeasonIdChange}
                />
            </div>
            <div className="taco">
                <input type="file" accept=".csv" onChange={handleFileChange} />
            </div>
            <button onClick={handlePlayerUpload}>Upload Players</button>
            {status && <p>{status}</p>}


            <h2 className="taco">Upload Scoring CSV (PLAYERS MUST BE DONE FIRST)</h2>
            <div className="taco">
                <label>Scoring Season ID:</label>
                <input
                    type="number"
                    value={seasonIdScoring}
                    onChange={handleScoringSeasonIdChange}
                />
            </div>
            <div className="taco">
                <input type="file" accept=".csv" onChange={handleScoringFileChange} />
            </div>
            <button onClick={handleScoringUpload}>Upload Scoring</button>
            {scoringStatus && <p>{scoringStatus}</p>}

            
            
        </div>
    )
}
