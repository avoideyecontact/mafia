import React,{useLayoutEffect} from 'react';
import MainSubheader from "../Modules/MainPage/MainSubheader";
import CounterModule from "../Modules/MainPage/CounterModule/CounterModule";
import BloodTrailSection from "../Modules/MainPage/BloodTrailSection";
import OurFamilies from '../Modules/MainPage/OurFamilies';

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
        </>
    );
};

export default MainPage;