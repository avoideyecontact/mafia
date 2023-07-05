import React from 'react';
import MainSubheader from "../Modules/MainSubheader";
import CounterModule from "../Modules/CounterModule";
import BloodTrailSection from "../Modules/BloodTrailSection";
import OurFamilies from '../Modules/OurFamilies';

const MainPage = () => {
    return (
        <>
            <MainSubheader/>
            <CounterModule/>
            <BloodTrailSection/>
            <OurFamilies/>
        </>
    );
};

export default MainPage;