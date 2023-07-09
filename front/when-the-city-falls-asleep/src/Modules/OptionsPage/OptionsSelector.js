import React from 'react';
import OptionsSelectorList from "./OptionsSelectorList";

const OptionsSelector = () => {
    return (
        <div className="options-selector">
            <div className="options-selector-header">
                <div className="options-selector-title">Список компаний</div>
                <input type="text" className="options-selector-search"/>
                <img src="./Img/ButtonAdd.png" alt="button add"/>
            </div>
            <OptionsSelectorList/>
        </div>
    );
};

export default OptionsSelector;