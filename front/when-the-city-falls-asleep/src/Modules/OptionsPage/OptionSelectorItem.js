import axios from 'axios';
import React, {useState} from 'react';

const OptionSelectorItem = (props) => {
    const baseURL = "/Home/DeleteOrganizationById?id="
    function handleDelete(){
        axios.delete(baseURL + props.id).catch((e)=>{
            console.log(e)
        })
    }
    return (
        <div className="options-selector-list-item">
            <p className="options-selector-list-item-title">{props.name}</p>
            <span className="options-selector-list-item-close" onClick={handleDelete}></span>
        </div>
    );
};

export default OptionSelectorItem;