import React, {useEffect,useState} from 'react';
import OptionsModal from "./OptionsModal";
import OptionsSelectorMember from "./OptionsSelectorMember";
import axios from "axios";
import OptionsMemberModal from "./OptionsMemberModal";

const OptionsSelectorFamilies = (props) => {
    const resURL="https://localhost:7117/Home/GetAllMembersByMafiaFamilyId"
    // const [searchValue,setSearchValue] = useState()
    const [visibility,setVisibility] = useState("closed")
    const [members,setMembers] = useState([{}])
    // useEffect(()=>{
    //    axios.get(baseURL + setSearchValue?"?name=" + searchValue:"").then((response) => {
    //        setResponse(response.data);
    //    }).catch((e)=>{
    //        console.log(e)
    //    });
    //},[searchValue,props.currentFamilyId])

    useEffect(()=>{
        console.log(resURL + "?id=" + props.currentFamilyId)
        axios.get(resURL + "?id=" + props.currentFamilyId).then((response) => {
            setMembers(response.data);
        }).catch((e)=>{
            console.log(e)
        });
    },[props.currentFamilyId])
    return (
        <div className="options-selector">
            <div className="options-selector-header">
                <div className="options-selector-title">Список участников семьи</div>
                <input type="text" onChange={(e)=>{
                    
                }}  className="options-selector-search"/>
                <img src="./Img/ButtonAdd.png" alt="button add" onClick={(e)=>{
                    setVisibility("opened")
                }}/>
                <OptionsMemberModal currentFamilyId={props.currentFamilyId}  visibility={visibility} setVisibility={setVisibility}/>
            </div>
            <div className="options-selector-list">
                {
                    members[0].Name?members.map((member)=>{
                        return <OptionsSelectorMember key={member.Id} id={member.Id} name={member.Name}/>
                    }):<p className="options-selector-error">Вы не выбрали семью, или по запросу ничего не найдено</p>
                }

            </div>
            <OptionsModal/>
        </div>
    );
};

export default OptionsSelectorFamilies;