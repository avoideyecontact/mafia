import React, { useRef, useState } from "react";
// import "./styles/App.css"
import "./styles/fonts.css"
import "./styles/normalize.css"
import "./styles/style.css"
import Header from "./components/Header";
import Main from "./components/Main";

function App() {
  return (
    <div className="App">
      <Header/>
      <Main/>
    </div>
  );
}

export default App;
