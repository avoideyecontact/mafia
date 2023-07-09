import React from 'react';
import OptionsModal from "./OptionsModal";
import OptionsSelectorMember from "./OptionsSelectorMember";

const OptionsSelectorFamilies = () => {
    const families = [{name:"Семья аль капоне",id:1,income:2000},{name:"Семья Борисовых",id:2,income:20200},{name:"Семья Ландышевых",id:3,income:6666},{name:"Семья аль капоне",id:4,income:2000}]
    return (
        <div className="options-selector">
            <div className="options-selector-header">
                <div className="options-selector-title">Список участников семьи</div>
                <input type="text" className="options-selector-search"/>
                <img src="./Img/ButtonAdd.png" alt="button add"/>
            </div>
            <div className="options-selector-list">
                {
                    families.map((family)=>{
                        return <OptionsSelectorMember/>
                    })
                }
            </div>
            <OptionsModal/>
        </div>
    );
};

export default OptionsSelectorFamilies;