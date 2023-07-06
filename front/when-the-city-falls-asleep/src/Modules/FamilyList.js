import React from "react";
import FamilyItem from "./FamilyItem";
import axios from "axios";
import Skeleton from "./Skeleton";

const FamilyList = () => {
    const [familiesList, setFamiliesList] = React.useState([{},{},{},{}]);
    const [contentLoaded,setContentLoaded] = React.useState(false)
    const baseURL="https://localhost:7117/Home/GetAllMafiaFamilies"

    React.useEffect(() => {
        axios.get(baseURL).then((response) => {
            setFamiliesList(Array.from(response.data));
            console.log(response.data);
            setContentLoaded(true)
        })
    },[]);
    return (
        <ul className="family__list">
            {
                familiesList.map((family)=>{
                    console.log(family === {})
                    return contentLoaded?<FamilyItem key={family.Id} name={family.Name} imageURL={family.ImageUrl} descrition={family.Description}/>:<Skeleton/>
                })

            }


        </ul>
    );

}

export default FamilyList