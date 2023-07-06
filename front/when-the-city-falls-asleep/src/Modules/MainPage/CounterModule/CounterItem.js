import React from 'react';

const CounterItem = (props) => {
    return (
        <div className="counter-module-item">
            <div className="counter-item-counter">
                {props.counter}
            </div>
            <img className="counter-item-icon" src={props.img} alt=""/>
            <div className="counter-item-subtitle">
                {props.subtitle}
            </div>
        </div>
    );
};

export default CounterItem;