import React from 'react';
import OptionsSubheader from "../Modules/OptionsPage/OptionsSubheader";
import OptionsSelector from "../Modules/OptionsPage/OptionsSelector";

const OptionsPage = () => {
    return (
        <div>
            <OptionsSubheader/>
            <OptionsSelector/>
            <OptionsSelector/>
        </div>
    );
};

export default OptionsPage;