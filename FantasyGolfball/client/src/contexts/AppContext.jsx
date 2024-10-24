import React, { createContext, useState, useContext, useEffect } from 'react';
import { tryGetLoggedInUser } from '../managers/authManager';

const AppContext = createContext();

export const AppProvider = ({ children }) => {
  const [loggedInUser, setLoggedInUser] = useState();
  // add state for determining week here
  const globalWeek = 1;

  useEffect(() => {
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  return (
    <AppContext.Provider value={{ loggedInUser, setLoggedInUser, globalWeek }}>
      {children}
    </AppContext.Provider>
  );
};

export const useAppContext = () => useContext(AppContext);
