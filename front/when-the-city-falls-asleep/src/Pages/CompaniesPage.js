import React from 'react';
import CompaniesSubheader from "../Modules/CompaniesPage/CompaniesSubheader";
import CompaniesCards from "../Modules/CompaniesPage/CompaniesCards";
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