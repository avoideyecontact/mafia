import React from "react";
import FamilyItem from "./FamilyItem";
import axios from "axios";

const FamilyList = () => {
    const [familiesList, setFamiliesList] = React.useState(null);
    const baseURL="https://localhost:7117/Home/GetAllMafiaFamilies"
    React.useEffect(() => {
        axios.get(baseURL).then((response) => {
            setFamiliesList(response.data);
            console.log(response.data);
        })
    });
    return (
        <ul className="family__list">
            {
                familiesList.map((family)=>{
                    return <FamilyItem key={family.Id} name={family.Name} imageURL={family.ImageURL} descrition={family.Description}/>
                })
            }
        </ul>
    );
}

export default FamilyList