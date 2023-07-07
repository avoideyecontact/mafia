import { useState } from "react";
import MainPageModal from "./MainPage/MainPageModal";

const Button = () => {
    const [visibility,setVisibility] = useState("closed");
    return (
        <>
            <button className="button" onClick={(event)=>{
                setVisibility(visibility === "closed"?"opened":"closed")
                console.log(visibility)
            }}>
                КРЫШУЙ МЕНЯ
            </button>
            <MainPageModal visibility={visibility} setVisibility={setVisibility}/>
        </>
    );
};

export default Button;