import React from 'react';
import MainPageSelectorItem from "./MainPageSelectorItem";

const MainPageModalSelector = (props) => {
    const test = [{name:"Магнит",id:1},{name:"Магнит",id:2},{name:"Магнит",id:3},{name:"Магнит",id:4},{name:"Магнит",id:5},{name:"Магнит",id:6},{name:"Магнит",id:7}]
    return (
        <div className={"main-page-selector top-positioned " + props.visibility }>
            {
                test.map((item)=>{
                    return <MainPageSelectorItem key={item.id}
                                                 id={item.id}
                                                 name={item.name}
                                                 currentCompnay={props.currentCompany}
                                                 setCurrentCompany={props.setCurrentCompany}
                                                 visibility={props.visibility}
                                                 setVisibility={props.setVisibility}
                    />
                })
            }
        </div>
    );
};

export default MainPageModalSelector;