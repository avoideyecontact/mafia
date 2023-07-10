import React, {useContext, useEffect, useState} from 'react';
import OptionsBossSubtitleItem from "./OptionsBossSubtitleItem";
import OptionsFamilyModal from "./OptionsFamilyModal";
import axios from 'axios';
const OptionsBossSubtitle = (props) => {
    const baseURL = "https://localhost:7117/Home/GetAllMafiaFamilies"
    const calculateURL="https://localhost:7117/Home/CalculateFamilyIncomeByFamilyId"
    const [families,setFamilies] = useState([{}])
    const [income,setIncome] = useState()
    const [visibility,setVisibility] = useState("closed")
    const [familyModalVisibility,setFamilyModalVisibility] = useState("closed")
    useEffect(()=>{
        axios.get(baseURL).then((response) => {
            setFamilies(Array.from(response.data));
            console.log(response.data);
        }).catch((e)=>{
            console.log(e)
        })
    },[visibility])
    useEffect(()=>{
        if (props.id!=-1){
            axios.get(calculateURL + "?id=" + props.currentFamilyId).then((response) => {
                setIncome((response.data));
                console.log(response.data);
            }).catch((e)=>{
                console.log(e)
            })
        }  
    },[props.currentFamilyId])
    return (
        <>
            <div className="select-family" onClick={(e)=>{
                setVisibility(visibility === "closed"?"visiblie":"closed")
            }}>{props.currentFamilyName}</div>
            <div className={"main-page-selector options-position " + visibility }>
                {
                    families.map((family)=>{
                        return <OptionsBossSubtitleItem name={family.Name}
                                                        id={family.Id}
                                                        income={family.Income}
                                                        setVisibility={setVisibility}
                                                        setCurrentFamily={props.setCurrentFamily} />
                    })
                }

            </div>
            {
                props.currentFamilyName!=="Выберете семью"?
                <div className="options-boss-subtitle">
                    Её годовой доход составляет: {income} $
                </div>:null
            }
            <br/>
            <div className="options-boss-subtitle">
                Или вы хотите добавить  <span className="underlined" onClick={()=>{
                setFamilyModalVisibility("opened")
            }}>новую семью</span>...
            </div>
            <OptionsFamilyModal visibility={familyModalVisibility} setVisibility={setFamilyModalVisibility}/>
        </>
    );
};

export default OptionsBossSubtitle;