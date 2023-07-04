import React from "react";
import FamilyItem from "./FamilyItem";


const FamilyList = () => {
    return (
        <ul className="family__list">
            <FamilyItem/>
            <FamilyItem/>
            <FamilyItem/>
        </ul>
    );
}

export default FamilyList