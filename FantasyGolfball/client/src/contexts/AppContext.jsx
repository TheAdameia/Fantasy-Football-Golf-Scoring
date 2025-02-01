import React, { createContext, useState, useContext, useEffect } from 'react'
import { tryGetLoggedInUser } from '../managers/authManager'
import { GetByUserAndLeague } from '../managers/rosterManager'
import { GetAllPlayers } from '../managers/playerManager'

const AppContext = createContext()

export const AppProvider = ({ children }) => {
  const [loggedInUser, setLoggedInUser] = useState()
  const [roster, setRoster] = useState()
  const [players, setPlayers] = useState()


  // add state for determining week here
  const globalWeek = 1

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
    getAndSetRoster()
  }, [loggedInUser])

  useEffect(() => {
    getAndSetPlayers()
  }, [])


  return (
    <AppContext.Provider value={{ loggedInUser, setLoggedInUser, globalWeek, roster, players }}>
      {children}
    </AppContext.Provider>
  )
}

export const useAppContext = () => useContext(AppContext)
