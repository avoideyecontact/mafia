import React, {useState} from 'react';

const OptionSelectorItem = () => {
    const [deleted,setDeleted] = useState(0)
    return (
        <div className="options-selector-list-item">
            <p className="options-selector-list-item-title">Магнит , Годовая прибыль : 2000$</p>
            <span className="options-selector-list-item-close" onClick={(e)=>{
                alert("Я жив")
            }}></span>
        </div>
    );
};

export default OptionSelectorItem;