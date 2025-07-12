import { useState } from "react"


export const DataImportPage = () => {
  const [file, setFile] = useState(null)
  const [seasonId, setSeasonId] = useState("")
  const [status, setStatus] = useState("")

  const handleFileChange = (e) => {
    setFile(e.target.files[0])
  };

  const handleSeasonIdChange = (e) => {
    setSeasonId(e.target.value)
  };

  const handleUpload = async () => {
    if (!file || !seasonId) {
      setStatus("Please select a file and enter a season ID.")
      return
    }

    const formData = new FormData()
    formData.append("file", file)

    try {
        // put this in a manager
    //   const response = await fetch(`/api/dataimport/players?seasonId=${seasonId}`, {
    //     method: "POST",
    //     headers: {
    //       // Add Authorization header if needed:
    //       // 'Authorization': `Bearer ${yourToken}`
    //     },
    //     body: formData,
    //   })

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
  };

  return (
    <div>
      <h2>Upload Player CSV</h2>
      <div>
        <label>Season ID:</label>
        <input
          type="number"
          value={seasonId}
          onChange={handleSeasonIdChange}
        />
      </div>
      <div>
        <input type="file" accept=".csv" onChange={handleFileChange} />
      </div>
      <button onClick={handleUpload}>Upload</button>
      {status && <p>{status}</p>}
    </div>
  )
}
