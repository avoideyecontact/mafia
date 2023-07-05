import React from 'react';
import CompaniesSubheader from "../Modules/CompaniesSubheader";
import CompaniesCards from "../Modules/CompaniesCards";
import {useLayoutEffect} from "react";

const CompaniesPage = () => {
    useLayoutEffect(() => {
        window.scrollTo(0, 0)
    });
    return (
        <div className="companies-page">
            <CompaniesSubheader/>
            <CompaniesCards/>
        </div>
    );
};

export default CompaniesPage;