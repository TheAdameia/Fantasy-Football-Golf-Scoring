import React, { createContext, useState, useContext, useEffect } from 'react'
import { tryGetLoggedInUser } from '../managers/authManager'
import { GetByUserAndLeague } from '../managers/rosterManager'
import { GetAllPlayers } from '../managers/playerManager'

const AppContext = createContext()

export const AppProvider = ({ children }) => {
  const [loggedInUser, setLoggedInUser] = useState()
  const [userLeagues, setUserLeagues] = useState()
  const [selectedLeague, setSelectedLeague] = useState(null)
  const [roster, setRoster] = useState()
  const [players, setPlayers] = useState()


  // add state for determining week here
  const globalWeek = 1

  const getAndSetLeagues = () => {
    if (loggedInUser) {
      fetch(`/api/league/by-user/${loggedInUser.id}`)
        .then((res) => res.json())
        .then((data) => {
          setUserLeagues(data)

        // check localStorage for previously selected league
        const storedLeagueId = localStorage.getItem("selectedLeagueId");

        // set selected league from localStorage if valid, otherwise first league
        const initialLeague = data.find(l => l.id === parseInt(storedLeagueId)) || data[0];
        setSelectedLeague(initialLeague);
        }) // I hate writing out calls somewhere that's not a manager, but importing context to a manager caused initialization issues
    }
  }

  const getAndSetRoster = () => {
    if (loggedInUser != null)
    {
      let leagueId = 5 // I will need to actually get this value instead of assuming it
    let userId = loggedInUser.id
    GetByUserAndLeague(userId, leagueId).then(setRoster)
    }
  }

  const getAndSetPlayers = () => {
    GetAllPlayers().then(setPlayers)
  }

  useEffect(() => {
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user)
    })
  }, [])

  useEffect(() => {
    getAndSetLeagues()
  }, [loggedInUser])

  useEffect(() => {
    getAndSetRoster()
  }, [loggedInUser])

  useEffect(() => {
    getAndSetPlayers()
  }, [])


  return (
    <AppContext.Provider value={{ 
      loggedInUser, 
      setLoggedInUser, 
      globalWeek, 
      roster, 
      players,
      getAndSetRoster,
      setSelectedLeague,
      userLeagues,
      setUserLeagues,
      selectedLeague }}>
      {children}
    </AppContext.Provider>
  )
}

export const useAppContext = () => useContext(AppContext)
