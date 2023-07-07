import React,{useLayoutEffect} from 'react';
import MainSubheader from "../Modules/MainPage/MainSubheader";
import CounterModule from "../Modules/MainPage/CounterModule/CounterModule";
import BloodTrailSection from "../Modules/MainPage/BloodTrailSection";
import OurFamilies from '../Modules/MainPage/OurFamilies';
import Game from '../Modules/Game';

const MainPage = () => {
    useLayoutEffect(() => {
        window.scrollTo(0, 0)
    });
    return (
        <>
            <MainSubheader/>
            <CounterModule/>
            <BloodTrailSection/>
            <OurFamilies/>
            <Game/>
        </>
    );
};

export default MainPage;