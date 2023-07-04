import React from "react";

const FamilyItem = () => {
    return (
        <li className="family__item">
            <img src="../img/item-img.png" alt="" />
            <div className="family__info">
                <h3>Семья Аль-Маскорпоне</h3>
                <p>Однажды женатый человек перешел им дорогу, больше по его пальцам нельзя было сказать женат он или нет...</p>
                <button>Подробнее...</button>
            </div>
        </li>
    );
}

export default FamilyItem