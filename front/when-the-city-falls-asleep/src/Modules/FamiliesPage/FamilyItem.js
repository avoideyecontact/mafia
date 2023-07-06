import React, {useState} from "react";
import FamilyModal from "./FamilyModal";

const FamilyItem = (props) => {
    const [visibility, setVisibility] = useState("closed");
    return (
        <li className="family__item">
            <img className="family__image" src={props.imageURL} alt="companyImage" />
            <div className="family__info">
                <h3>{props.name}</h3>
                <p>{props.descrition}</p>
                <button className="family__button" onClick={(event)=>{
                    setVisibility(visibility === "closed"?"opened":"closed")
                    console.log(visibility)
                }}>Подробнее...</button>

                {/*<FamilyModal setVisibility={setVisibility} visibility = {visibility} name={props.name} familyMembers={props.familyMembers} income={props.income} organizations={props.organizations}/>*/}
            </div>
        </li>
    );
}

export default FamilyItem