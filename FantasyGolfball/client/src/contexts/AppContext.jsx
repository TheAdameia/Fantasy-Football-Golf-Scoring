import React, { createContext, useState, useContext, useEffect } from 'react'
import { tryGetLoggedInUser } from '../managers/authManager'
import { GetByUserAndLeague } from '../managers/rosterManager'
import { GetAllPlayers } from '../managers/playerManager'
import { GetMatchupsByLeagueAndUser } from '../managers/matchupManager'
import { GetAllScores } from '../managers/scoringManager'

const AppContext = createContext()

export const AppProvider = ({ children }) => {
  const [loggedInUser, setLoggedInUser] = useState()
  const [userLeagues, setUserLeagues] = useState()
  const [selectedLeague, setSelectedLeague] = useState(null)
  const [roster, setRoster] = useState()
  const [players, setPlayers] = useState()
  const [matchups, setMatchups] = useState(null)
  const [allScores, setAllScores] = useState()

  const getAndSetAllScores = () => {
    if (loggedInUser) {
      GetAllScores().then(setAllScores)
    }
  }

  const getAndSetLeagues = () => {
    if (loggedInUser) {
      fetch(`/api/league/by-user/${loggedInUser.id}`) // I hate writing out calls somewhere that's not a manager, but importing context to a manager causes initialization issues and the league states need to be set before anything else happens
        .then((res) => res.json())
        .then((data) => {
          setUserLeagues(data)
          
        // check localStorage for previously selected league
        const storedLeagueId = localStorage.getItem("selectedLeagueId");

        // set selected league from localStorage if valid, otherwise first league user is in
        const initialLeague = data.find(l => l.leagueId === parseInt(storedLeagueId)) || data[0];
        setSelectedLeague(initialLeague);
        }) 
    }
  }

  const getAndSetMatchups = () => {
    if (loggedInUser != null && selectedLeague != null) {
      if (selectedLeague.isDraftComplete) {
        GetMatchupsByLeagueAndUser(selectedLeague.leagueId, loggedInUser.userId).then(setMatchups)
      }
    }
  }

  const getAndSetRoster = () => {
    if (loggedInUser != null && selectedLeague)
    {
      let userId = loggedInUser.id
      GetByUserAndLeague(userId, selectedLeague.leagueId).then(setRoster)
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
  }, [loggedInUser, selectedLeague])

  useEffect(() => {
    getAndSetPlayers()
  }, [])

  useEffect(() => {
    if (selectedLeague) {
      localStorage.setItem("selectedLeagueId", selectedLeague.leagueId);
    }
  }, [selectedLeague]);

  useEffect(() => {
    if (selectedLeague) {
      if (selectedLeague.isDraftComplete) {
        getAndSetMatchups()
      }
    }
  }, [selectedLeague])

  useEffect(() => {
    if (loggedInUser) {
      getAndSetAllScores()
    }
  }, [loggedInUser])
  
  return (
    <AppContext.Provider value={{ 
      loggedInUser, 
      setLoggedInUser,
      roster, 
      players,
      getAndSetRoster,
      setSelectedLeague,
      userLeagues,
      setUserLeagues,
      selectedLeague,
      matchups,
      allScores }}>
      {children}
    </AppContext.Provider>
  )
}

export const useAppContext = () => useContext(AppContext)
