import React, {useEffect,useState} from 'react';
import OptionsModal from "./OptionsModal";
import OptionsSelectorMember from "./OptionsSelectorMember";
import axios from "axios";
import OptionsMemberModal from "./OptionsMemberModal";

const OptionsSelectorFamilies = (props) => {
    const baseURL=""
    const [response,setResponse] = useState()
    const [searchValue,setSearchValue] = useState()
    const [visibility,setVisibility] = useState("closed")
    const families = [{name:"Семья аль капоне",id:1,income:2000},{name:"Семья Борисовых",id:2,income:20200},{name:"Семья Ландышевых",id:3,income:6666},{name:"Семья аль капоне",id:4,income:2000}]
    useEffect(()=>{
        axios.get(baseURL + setSearchValue?"?name=" + searchValue:"").then((response) => {
            setResponse(response.data);
        }).catch((e)=>{
            console.log(e)
        });
    },[searchValue,props.currentFamilyId])
    return (
        <div className="options-selector">
            <div className="options-selector-header">
                <div className="options-selector-title">Список участников семьи</div>
                <input type="text" value={searchValue} onChange={(e)=>{
                    setSearchValue(e.target.value)
                }}  className="options-selector-search"/>
                <img src="./Img/ButtonAdd.png" alt="button add" onClick={(e)=>{
                    setVisibility("opened")
                }}/>
                <OptionsMemberModal  visibility={visibility} setVisibility={setVisibility}/>
            </div>
            <div className="options-selector-list">
                {
                    families?families.map((family)=>{
                        return <OptionsSelectorMember/>
                    }):<p className="options-selector-error">Вы не выбрали семью, или по запросу ничего не найдено</p>
                }

            </div>
            <OptionsModal/>
        </div>
    );
};

export default OptionsSelectorFamilies;