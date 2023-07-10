import React, {useEffect, useState} from 'react';
import axios from "axios";

const OptionsSelectorMember = (props) => {
    const delURL="/Home/DeleteFamilyMemberById?id="
    const baseURL=""
    //Сюда URL для удаления
    const [memberCompanies,setMemberCompanies] = useState({})
    useEffect(()=>{
        axios.get(baseURL).then((res)=>{
            setMemberCompanies(res)
        })
    },[])
    function handleClick(){
        axios.delete((delURL + props.id)).catch((e)=>{
            console.log(e)
        })
    }
    return (
        <div className="options-selector-list-item">
            <p className="options-selector-list-item-title">{props.name}, контролирует
                {memberCompanies.map((company)=>{
                    return company.name + ","
                })}
            </p>
            <span className="options-selector-list-item-close" onClick={handleClick}/>
        </div>
    );
};

export default OptionsSelectorMember;