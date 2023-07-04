import React from 'react';
import CompaniesSubheader from "../Modules/CompaniesSubheader";
import CompaniesCards from "../Modules/CompaniesCards";

const CompaniesPage = () => {
    return (
        <div className="companies-page">
            <CompaniesSubheader/>
            <CompaniesCards/>
        </div>
    );
};

export default CompaniesPage;