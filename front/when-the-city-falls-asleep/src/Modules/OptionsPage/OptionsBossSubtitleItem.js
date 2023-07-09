import React from 'react';

const OptionsBossSubtitleItem = (props) => {
    function clickHandle(e){
        props.setCurrentFamily({name:props.name,id:props.id,income:props.income})
        props.setVisibility("closed")
    }
    return (
            <>
                <div className="main-page-selector-item" onClick={clickHandle}>{props.name}</div>
            </>
    );
};

export default OptionsBossSubtitleItem;