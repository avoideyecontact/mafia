import React from 'react';
import CompaniesCard from "./CompaniesCard";
import axios from "axios";
import Skeleton from "../Skeleton";


const CompaniesCards = () => {
    const [contentLoaded,setContentLoaded] = React.useState(false)
    const [companiesList, setCompaniesList] = React.useState([{},{},{},{}]);
    const baseURL="https://localhost:7117/Home/GetAllOrganizations"

    React.useEffect(() => {
        axios.get(baseURL).then((response) => {
            setCompaniesList(Array.from(response.data));
            console.log(response.data);
            setContentLoaded(true)
        }).catch((e)=>{
            console.log(e)
        })
    },[]);
    return (
        <div className="companies-cards">
            {
                companiesList.map((company)=>{
                    return contentLoaded?<CompaniesCard key={company.Id}
                                          companyType={company.OrganizationTypeId}
                                          name={company.Name}
                                          description={company.Description}
                                          imageURL={company.ImageUrl}
                                          income={company.Income}
                                          collectorId={company.CollectorId} />: <Skeleton></Skeleton>
                })
            }
        </div>
    );
};

export default CompaniesCards;