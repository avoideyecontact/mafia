import React from 'react';

const CompaniesCard = () => {
    return (
        <div className="companies-cards-card">
            <img  className="card-image" src="../Img/ChildGarden.png" alt=""/>
            <div className="card-main">
                <div className="card-main-title">
                    Детский сад №10
                </div>
                <div className="card-main-subtitle">
                    Ребенок Аль-Маскорпоне однажды пожаловался отцу на манную кашу с комочками, с тех пор кухни там нет...
                </div>
                <button className="card-button">
                    Подробнее...
                </button>
            </div>
        </div>
    );
};

export default CompaniesCard;