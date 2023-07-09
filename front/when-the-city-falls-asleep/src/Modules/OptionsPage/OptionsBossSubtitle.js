import React, {useContext, useState} from 'react';
import OptionsBossSubtitleItem from "./OptionsBossSubtitleItem";

const OptionsBossSubtitle = (props) => {
    const families = [{name:"Семья аль капоне",id:1,income:2000},{name:"Семья Борисовых",id:2,income:20200},{name:"Семья Ландышевых",id:3,income:6666},{name:"Семья аль капоне",id:4,income:2000}]
    const [visibility,setVisibility] = useState("closed")
    return (
        <>
            <div className="select-family" onClick={(e)=>{
                setVisibility(visibility === "closed"?"visiblie":"closed")
            }}>{props.currentFamilyName}</div>
            <div className={"main-page-selector options-position " + visibility }>
                {
                    families.map((family)=>{
                        return <OptionsBossSubtitleItem name={family.name}
                                                        id={family.id}
                                                        income={family.income}
                                                        setVisibility={setVisibility}
                                                        setCurrentFamily={props.setCurrentFamily} />
                    })
                }

            </div>
            {
                props.currentFamilyName!=="Выберете семью"?
                <div className="options-boss-subtitle">
                    Её годовой доход составляет: {props.income} $
                </div>:null
            }
            <br/>
            <div className="options-boss-subtitle">
                Или вы хотите добавить новую семью...
            </div>
        </>
    );
};

export default OptionsBossSubtitle;