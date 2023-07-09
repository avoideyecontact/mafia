import React,{useLayoutEffect} from 'react';
import MainSubheader from "../Modules/MainPage/MainSubheader";
import CounterModule from "../Modules/MainPage/CounterModule/CounterModule";
import BloodTrailSection from "../Modules/MainPage/BloodTrailSection";
import OurFamilies from '../Modules/MainPage/OurFamilies';
import Tired from '../Modules/Tired';
import Game from '../Modules/MainPage/Game/Game';

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
            <Tired/>
            <Game/>
        </>
    );
};

export default MainPage;