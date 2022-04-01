import React from "react";
import "./App.css";
import HeaderBar from "./components/HeaderBar";
import Movies from "./views/Movie/Movies";

function App() {
  return (
    <>
      <HeaderBar />
      <Movies />
    </>
  );
}

export default App;
