import React, {useState} from 'react';
import OptionsSubheader from "../Modules/OptionsPage/OptionsSubheader";
import OptionsSelectorCompanies from "../Modules/OptionsPage/OptionsSelectorCompanies";
import OptionsBossSubtitle from "../Modules/OptionsPage/OptionsBossSubtitle";
import OptionsSelectorMembers from "../Modules/OptionsPage/OptionSelectorMembers";

const OptionsPage = () => {
    const [currentFamily,setCurrentFamily] = useState({name:"Выберете семью",id:-1,income:0})
    return (
        <div>
                <OptionsSubheader/>
                <OptionsBossSubtitle income={currentFamily.income} currentFamilyName={currentFamily.name} setCurrentFamily={setCurrentFamily}/>
                <OptionsSelectorCompanies currentFamilyId={currentFamily.id}/>
                <OptionsSelectorMembers currentFamilyId={currentFamily.id}/>
        </div>
    );
};

export default OptionsPage;