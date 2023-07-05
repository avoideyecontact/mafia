import React, {useState} from 'react';
import CompaniesModal from "./CompaniesModal";

const CompaniesCard = (props) => {
    const [visibility,setVisibility] = useState("closed")
    return (
        <div className="companies-cards-card">
            <img  className="card-image" src="../../public/Img/ChildGarden.png" alt=""/>
            <div className="card-main">
                <div className="card-main-title">
                    {props.name}
                </div>
                <div className="card-main-subtitle">
                    {props.description}
                </div>
                <button className="card-button" onClick={(event)=>{
                    setVisibility(visibility === "closed"?"opened":"closed")
                    console.log(visibility)
                }}>
                    Подробнее...
                </button>
                <CompaniesModal visibility={visibility} setVisibility={setVisibility} name={props.name} income={props.income} collectorId={props.collectorId}/>
            </div>
        </div>
    );
};

export default CompaniesCard;