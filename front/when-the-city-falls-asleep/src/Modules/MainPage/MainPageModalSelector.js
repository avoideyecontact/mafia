import React, { useEffect, useState } from 'react';
import MainPageSelectorItem from "./MainPageSelectorItem";
import axios from 'axios';
const MainPageModalSelector = (props) => {
    const baseURL = "https://localhost:7117/Home/GetAllMafiaFamilies";
    const [test,setTest]= useState([])
    useEffect(()=>{
        axios.get(baseURL).then((response) => {
            setTest(Array.from(response.data));
            console.log(response.data);
        }).catch((e)=>{
            console.log(e)
        })
    },[props.visibility])
    return (
        <div className={"main-page-selector top-positioned " + props.visibility }>
            {
                test.map((item)=>{
                    return <MainPageSelectorItem key={item.Id}
                                                 id={item.Id}
                                                 name={item.Name}
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