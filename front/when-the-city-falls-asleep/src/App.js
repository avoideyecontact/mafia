import './App.scss';
import Header from "./Modules/Header";
import MainSubheader from "./Modules/MainPage/MainSubheader";
import CounterModule from "./Modules/MainPage/CounterModule/CounterModule";
import React from 'react';
import MainPage from "./Pages/MainPage";
import {
    Switch,
    Route,
    Routes,
} from 'react-router-dom';
import CompaniesPage from "./Pages/CompaniesPage";
import FamiliesPage from "./Pages/FamiliesPage";
import OptionsPage from "./Pages/OptionsPage";

function App() {
  return (
    <div className="App">
            <Header/>

            <Routes>
                <Route exact path="/" element={<MainPage/>}/>
                <Route exact path="/companies" element={<CompaniesPage/>}/>
                <Route exact path="/families" element={<FamiliesPage/>}/>
                <Route exact path="/options" element={<OptionsPage/>}/>
            </Routes>


    </div>
  );
}

export default App;
