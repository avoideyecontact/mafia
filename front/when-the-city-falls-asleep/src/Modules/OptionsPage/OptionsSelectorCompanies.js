import React, {useEffect, useState} from 'react';
import OptionsModal from "./OptionsModal";
import OptionSelectorItem from "./OptionSelectorItem";
import axios from "axios";

const OptionsSelectorCompanies = (props) => {
    //const baseURL="https://localhost:7117/Home/GetAllOrganizationsByMafiaFamilyName"
    const resURL="https://localhost:7117/Home/GetAllOrganizationsByMafiaFamilyId"
    const [response,setResponse] = useState()
    const [searchValue,setSearchValue] = useState()
    const [companies,setCompanies] = useState([{}])
    //useEffect(()=>{
    //    axios.get(baseURL + (setSearchValue.length?"?name=" + searchValue:"")).then((response) => {
    //        setResponse(response.data);
    //    }).catch((e)=>{
    //       console.log(e)
    //    });
    //},[searchValue,props.currentFamilyId])
    useEffect(()=>{
        console.log(resURL + "?id=" + props.currentFamilyId)
        axios.get(resURL + "?id=" + props.currentFamilyId).then((response) => {
                    setCompanies(response.data);
                }).catch((e)=>{
                   console.log(e)
                });
    },[props.currentFamilyId])
    return (
        <div className="options-selector">
            <div className="options-selector-header">
                <div className="options-selector-title">Список компаний</div>
                <input type="text" value={searchValue} onChange={(e)=>{
                    
                }}  className="options-selector-search"/>
            </div>
            <div className="options-selector-list">
            {
                companies[0].Name?companies.map((company)=>{
                    return <OptionSelectorItem key={company.Id} id={company.Id} name={company.Name}/>
                }):<p className="options-selector-error">Вы не выбрали семью, или по запросу ничего не найдено</p>

            }
            </div>
            <OptionsModal/>
        </div>
    );
};

export default OptionsSelectorCompanies;