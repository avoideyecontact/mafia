import React from 'react';

const CompaniesModal = (props) => {
    return (
        <div className={"modal-form " + props.visibility}>
            <div className="modal-form__content">
                <span className="modal-form__close" onClick={(event)=>{
                    props.setVisibility(props.visibility === "closed"?"opened":"closed")
                    console.log(props.visibility)
                }}></span>
                <h3>{props.name}</h3>
                <br/>
                <p>Принадлежит семье: blank</p>
                <p>Крышует:{props.collectorId}</p>
                <p>Тип организации:{props.companyType}</p>
                <p className="modal-income">Компания приносит своей семье {props.income} $</p>
            </div>
        </div>
    );
};

export default CompaniesModal;