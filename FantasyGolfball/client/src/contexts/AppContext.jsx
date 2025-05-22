import React, { createContext, useState, useContext, useEffect } from 'react'
import { tryGetLoggedInUser } from '../managers/authManager'
import { GetAllPlayers } from '../managers/playerManager'
import { GetMatchupsByLeague } from '../managers/matchupManager'
import { GetAllScores } from '../managers/scoringManager'
import { GetByUserAndLeague } from '../managers/rosterManager'
import { GetTradesByLeagueAndUser } from '../managers/tradeManager'

const AppContext = createContext()

export const AppProvider = ({ children }) => {
  const [loggedInUser, setLoggedInUser] = useState()
  const [userLeagues, setUserLeagues] = useState()
  const [selectedLeague, setSelectedLeague] = useState(null)
  const [roster, setRoster] = useState()
  const [players, setPlayers] = useState()
  const [matchups, setMatchups] = useState(null)
  const [allScores, setAllScores] = useState()
  const [activeTrades, setActiveTrades] = useState()

  const getAndSetAllScores = () => {
    if (loggedInUser && selectedLeague) {
      GetAllScores(selectedLeague.seasonId).then(setAllScores)
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
        GetMatchupsByLeague(selectedLeague.leagueId, loggedInUser.id).then(setMatchups)
      }
    }
  }


  const getAndSetRoster = () => {
    if (loggedInUser != null && selectedLeague) {
      let userId = loggedInUser.id
      GetByUserAndLeague(userId, selectedLeague.leagueId).then(setRoster)
    }
  }

  const getAndSetPlayers = () => {
    if (loggedInUser != null && selectedLeague) {
      GetAllPlayers(selectedLeague.leagueId).then(setPlayers)
    }
  }

  const getAndSetTrades = () => {
    if (loggedInUser != null && selectedLeague && roster) {
      GetTradesByLeagueAndUser(roster.rosterId, selectedLeague.leagueId).then(setActiveTrades)
    }
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
    if (loggedInUser && selectedLeague) {
      getAndSetPlayers()
    }
  }, [loggedInUser, selectedLeague])

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
  }, [loggedInUser, selectedLeague])

  useEffect(() => {
    if (loggedInUser != null && selectedLeague && roster) {
      getAndSetTrades()
    }
  }, [loggedInUser, roster, selectedLeague])
  
  return (
    <AppContext.Provider value={{ 
      loggedInUser, 
      setLoggedInUser,
      roster, 
      players,
      getAndSetRoster,
      getAndSetPlayers,
      setSelectedLeague,
      userLeagues,
      setUserLeagues,
      selectedLeague,
      matchups,
      allScores,
      activeTrades }}>
      {children}
    </AppContext.Provider>
  )
}

export const useAppContext = () => useContext(AppContext)
