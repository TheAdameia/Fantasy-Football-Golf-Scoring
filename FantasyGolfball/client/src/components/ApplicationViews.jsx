import { Route, Routes } from "react-router-dom"
import { AuthorizedRoute } from "./auth/AuthorizedRoute"
import Login from "./auth/Login"
import Register from "./auth/Register"
import { RosterPage } from "./roster/RosterPage"
import { useAppContext } from "../contexts/AppContext"
import { PlayerPage } from "./player/PlayerPage"
import { LeaguePage } from "./league/LeaguePage"
import { LeagueForm } from "./league/LeagueForm"
import Chat from "../clientHubs/exampleClientHub"
import { DraftPage } from "./draft/DraftPage"
import { MainPage } from "./MainPage"
import { FaqPage } from "./rule-faq/FaqPage"
import { RecapDraft } from "./draft/RecapDraft"
import { TradeForm } from "./trades/TradeForm"
import { TradePage } from "./trades/TradePage"
import { MatchupPageOuter } from "./matchups/MatchupPageOuter"


export default function ApplicationViews() {
  const { loggedInUser, setLoggedInUser } = useAppContext()

  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <MainPage />
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
          path="chat"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Chat />
            </AuthorizedRoute>
          }
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
          path="league"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <LeaguePage />
            </AuthorizedRoute>
          }
        />
        <Route 
          path="league/create"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <LeagueForm />
            </AuthorizedRoute>
          }
        />
        <Route
          path="live-draft"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <DraftPage />
            </AuthorizedRoute>
          }
        />
        <Route 
          path="matchups"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <MatchupPageOuter/>
            </AuthorizedRoute>
          }
        />
        <Route
          path="draft-recap"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <RecapDraft />
            </AuthorizedRoute>
          }
        />
        <Route
          path="create-trade"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <TradeForm />
            </AuthorizedRoute>
          }
        />
        <Route 
          path="trades"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <TradePage />
            </AuthorizedRoute>
          }
        />
        <Route 
          path="faq"
          element={
            <FaqPage />
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
