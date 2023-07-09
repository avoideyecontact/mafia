import React from 'react';
import OptionSelectorItem from "./OptionSelectorItem";
import CompaniesModal from "../CompaniesPage/CompaniesModal";
import OptionsModal from "./OptionsModal";

const OptionsSelectorList = () => {
    return (
        <div className="options-selector-list">
            <OptionSelectorItem/>
            <OptionSelectorItem/>
            <OptionSelectorItem/>
            <OptionSelectorItem/>
            <OptionSelectorItem/>
            <OptionSelectorItem/>
            <OptionSelectorItem/>
            <OptionsModal/>
        </div>
    );
};

export default OptionsSelectorList;