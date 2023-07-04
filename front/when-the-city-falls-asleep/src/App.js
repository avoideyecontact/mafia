import './App.scss';
import Header from "./Modules/Header";
import MainSubheader from "./Modules/MainSubheader";
import CounterModule from "./Modules/CounterModule";
import React from 'react';
import MainPage from "./Pages/MainPage";
import {
    Switch,
    Route,
    Routes,
} from 'react-router-dom';
import CompaniesPage from "./Pages/CompaniesPage";

function App() {
  return (
    <div className="App">
            <Header/>

            <Routes>
                <Route exact path="/" element={<MainPage/>}/>
                <Route exact path="/companies" element={<CompaniesPage/>}/>
            </Routes>


    </div>
  );
}

export default App;
