import { useState } from "react"
import { ImportPlayerData } from "../../managers/importDataManager"
import "./DataImport.css"
import { PostNewSeason } from "../../managers/seasonManager"


export const DataImportPage = () => {
    const [file, setFile] = useState(null)
    const [seasonId, setSeasonId] = useState("")
    const [status, setStatus] = useState("")

    const [seasonYear, setSeasonYear] = useState(0) // REMEMBER TO PARSE INT WHEN YOU SUBMIT THESE
    const [seasonWeeks, setSeasonWeeks] = useState(18)

    const handleFileChange = (e) => {
        setFile(e.target.files[0])
    }

    const handleSeasonIdChange = (e) => {
        setSeasonId(e.target.value)
    }

    const handleUpload = async () => {
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

    const ConfirmSeason = () => {
        const confirmed = window.confirm(`Create Season with year ${seasonYear} and weeks ${seasonWeeks}?`)
        if (confirmed) {
            handleCreateSeason(seasonYear, seasonWeeks)
        } else {
            return
        }
    }

    const handleCreateSeason = (seasonYear, seasonWeeks) => {
        PostNewSeason(seasonYear, seasonWeeks)
    }

    return (
        <div>
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
            <button onClick={handleUpload}>Upload</button>
            {status && <p>{status}</p>}
        </div>
    )
}
