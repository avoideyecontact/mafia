import React from 'react';
import CompaniesCard from "./CompaniesCard";
import axios from "axios";


const CompaniesCards = () => {
    const [companiesList, setCompaniesList] = React.useState([{},{}]);
    const baseURL="https://localhost:7117/Home/GetAllOrganizations"

    React.useEffect(() => {
        axios.get(baseURL).then((response) => {
            setCompaniesList(Array.from(response.data));
            console.log(response.data);
        })
    },[]);
    return (
        <div className="companies-cards">
            {
                companiesList.map((company)=>{
                    return <CompaniesCard key={company.Id} companyType={company.OrganizationTypeId} name={company.Name} description={company.Description} income={company.Income} collectorId={company.CollectorId} />
                })
            }
            <CompaniesCard/>
        </div>
    );
};

export default CompaniesCards;