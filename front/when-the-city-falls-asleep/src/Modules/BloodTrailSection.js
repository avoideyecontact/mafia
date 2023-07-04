import React from 'react';
import {Link} from "react-router-dom";

const BloodTrailSection = () => {
    return (
        <div className="blood-trail-section">
            <img className="blood-trail" src="../Img/BloodTrail.png" alt=""/>
            <div className="blood-trail-title"> <Link to="/companies" className="blood-trail-link">САМЫЕ РАЗУМНЫЕ</Link>УЖЕ УБЕРЕГЛИ СЕБЯ</div>
            <div className="blood-trail-subtitle">ПОЗНАКОМЬТЕСЬ С НАСТОЯЩИМИ ВЕРШИТЕЛЯМИ <br/> ПОРЯДКА В НАШЕМ ГОРОДЕ:</div>
        </div>
    );
};

export default BloodTrailSection;