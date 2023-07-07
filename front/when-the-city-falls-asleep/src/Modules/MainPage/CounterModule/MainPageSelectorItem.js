import React from 'react';

const MainPageSelectorItem = (props) => {
    function clickHandle(e){
        e.preventDefault()
        props.setCurrentCompany({name:props.name,id:props.id})
        props.setVisibility("closed")
    }
    return (
        <div className="main-page-selector-item" onClick={clickHandle}>
            {
                props.name
            }
        </div>
    );
};

export default MainPageSelectorItem;