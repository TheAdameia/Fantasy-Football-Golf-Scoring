import { useContext } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { Spinner } from "reactstrap";
import NavBar from "./components/NavBar";
import ApplicationViews from "./components/ApplicationViews";
import { useAppContext } from "./contexts/AppContext";

function App() {
  // Consume context state instead of using local state
  const { loggedInUser, setLoggedInUser } = useAppContext();

  // Wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return <Spinner />;
  }

  return (
    <>
      <NavBar/>
      <ApplicationViews
      />
    </>
  );
}

export default App;
