import { useEffect, useState } from "react"
import { useAppContext } from "../../contexts/AppContext"


export const DraftPlayerList = () => {
    const { players } = useAppContext()
    // const { scores } = useAppContext() // I don't have this set up yet
    const [remainingPlayers, setRemainingPlayers] = useState() // for determining draft eligibility
    const [fiteredPlayers, setFilteredPlayers] = useState() // for display
    // using a scroll for the playerlist instead of the slice used in PlayerPage should reduce state overhead
    const [searchTerm, setSearchTerm] = useState("") // this will have the same first/last search issue as PlayerPage but that's outside of scope
    const [positionFilter, setPositionFilter] = useState("Any")



    

    const handlePlayerDraft = () => {
        // deep copy of remainingPlayers, remove selected player, setRemainingPlayers
    }
    
    const handlePositionChange = (event) => {
        setPositionFilter(event.target.value)
    }


    useEffect(() => {
        if (players){
            const foundPlayers = players.filter(player => 
                player.playerLastName.toLowerCase().includes(searchTerm.toLowerCase()) || 
                player.playerFirstName.toLowerCase().includes(searchTerm.toLowerCase())
            ) // I realize that if you type a full name in this won't work. I will have to adjust the full name to be a calculated property later.

            switch(positionFilter) {
                case "Any":
                    setFilteredPlayers(foundPlayers)
                    break
                case "QB":
                    setFilteredPlayers(foundPlayers.filter(p => p.position.positionShort == "QB"))
                    break
                case "WR":
                    setFilteredPlayers(foundPlayers.filter(p => p.position.positionShort == "WR"))
                    break
                case "RB":
                    setFilteredPlayers(foundPlayers.filter(p => p.position.positionShort == "RB"))
                    break
                case "TE":
                    setFilteredPlayers(foundPlayers.filter(p => p.position.positionShort == "TE"))
                    break
                case "K":
                    setFilteredPlayers(foundPlayers.filter(p => p.position.positionShort == "K"))
                    break
                case "DEF":
                    setFilteredPlayers(foundPlayers.filter(p => p.position.positionShort == "DEF"))
                    break
            }
        } 
    }, [searchTerm, players, positionFilter])


    return (
        <div></div>
    )
}