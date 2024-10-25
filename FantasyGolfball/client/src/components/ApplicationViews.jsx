import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { RosterPage } from "./roster/RosterPage";
import { useAppContext } from "../contexts/AppContext";
import { PlayerPage } from "./player/PlayerPage";

const Placeholder = () => {
  return <h1>Testing, attention please!</h1>;
};


export default function ApplicationViews() {
  const { loggedInUser, setLoggedInUser } = useAppContext()

  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Placeholder />
            </AuthorizedRoute>
          }
        />
        <Route 
          path="roster"
          element={
          <AuthorizedRoute loggedInUser={loggedInUser}>
            <RosterPage />
          </AuthorizedRoute>}
        />
        <Route 
          path="player-list"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <PlayerPage />
            </AuthorizedRoute>
          }
        />
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
