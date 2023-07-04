import React from "react";
import "./styles/fonts.css"
import "./styles/normalize.css"
import "./styles/style.css"
import Header from "./components/Header";
import Main from "./components/Main";
import Family from "./components/Family";
import FamilyList from "./components/FamilyList";

function App() {
  return (
    <div className="App">
      <Header/>
      {/* <Main/> */}
      <Family/>
      <FamilyList/>
    </div>
  );
}

export default App;
