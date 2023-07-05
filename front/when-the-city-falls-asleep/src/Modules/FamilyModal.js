import React from 'react';

const FamilyModal = (props) => {
    return (
        <div className={"modal-form " + props.visibility}>
            <div className="modal-form__content">
                <span className="modal-form__close" onClick={(event)=>{
                    props.setVisibility(props.visibility === "closed"?"opened":"closed")
                    console.log(props.visibility)
                }}></span>
                <h3>{props.name}</h3>
                <br/>
                <p>Cемьи: {props.familyMembers.map((member)=>{
                    return member + ", "
                })}</p>
                <p>Организации: {props.organizations.map((organization)=>{
                    return organization + ", "
                })}</p>
                <p className="modal-income">Годовой доход {props.income} $</p>
            </div>
        </div>
    );
};

export default FamilyModal;