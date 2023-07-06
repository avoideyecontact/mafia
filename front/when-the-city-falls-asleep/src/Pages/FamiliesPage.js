import React, {useLayoutEffect} from 'react';
import Family from "../Modules/FamiliesPage/Family";
import FamilyList from "../Modules/FamiliesPage/FamilyList";

const FamiliesPage = () => {
    useLayoutEffect(() => {
        window.scrollTo(0, 0)
    });
    return (
        <>
            <Family/>
            <FamilyList/>
        </>
    );
};

export default FamiliesPage;