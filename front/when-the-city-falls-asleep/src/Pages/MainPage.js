import React,{useLayoutEffect} from 'react';
import MainSubheader from "../Modules/MainSubheader";
import CounterModule from "../Modules/CounterModule";
import BloodTrailSection from "../Modules/BloodTrailSection";

const MainPage = () => {
    useLayoutEffect(() => {
        window.scrollTo(0, 0)
    });
    return (
        <>
            <MainSubheader/>
            <CounterModule/>
            <BloodTrailSection/>
        </>
    );
};

export default MainPage;