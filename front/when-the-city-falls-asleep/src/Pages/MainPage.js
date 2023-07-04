import React from 'react';
import MainSubheader from "../Modules/MainSubheader";
import CounterModule from "../Modules/CounterModule";
import BloodTrailSection from "../Modules/BloodTrailSection";

const MainPage = () => {
    return (
        <>
            <MainSubheader/>
            <CounterModule/>
            <BloodTrailSection/>
        </>
    );
};

export default MainPage;