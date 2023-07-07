import React, {useState} from 'react';
import MainPageModalSelector from "./MainPageModalSelector";
import axios from "axios";

const MainPageModal = (props) => {
    const [organizationName,setOrganizationName] = useState()
    const [income,setIncome] = useState()
    const [visibilityOfSelector,setVisibilityOfSelector] = useState("closed")
    const [currentCompany,setCurrentCompany] = useState({name:"Выберете семью",id:-1})
    function post(e){
        e.preventDefault()
        if(typeof(e.target[0].value) !== typeof("") || e.target[0].value.length > 50 ){
            setOrganizationName("")
            e.target[0].placeholder = "Вы ввели слишком длинное название"
            return
        }
        if(Number(e.target[0].value) !== typeof(1) || Number(e.target[0].value) > 0  && Number(e.target[0].value) < 2**31){
            setIncome("")
            e.target[1].placeholder = "Вы ввели неправильное значение"
            return
        }
        axios.post('/AddOrganization', {
            Name: e.target[0].value,
            Income: e.target[1].value,
            FamilyId:currentCompany.id
            })
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
            });
    }
    return (
        <>
            <div class={"modal-form " + props.visibility}>
                <div class="modal-form__content">
                    <span class="modal-form__close" onClick={(event)=>{
                    props.setVisibility(props.visibility === "closed"?"opened":"closed")
                    }}>
                    </span>
                    <h3>ТЫ СДЕЛАЛ ПРАВИЛЬНЫЙ ВЫБОР, СЫНОК</h3>
                    <p>Оставь нам контакты, чтобы обкашлять пару вопросов</p>
                    <form action="#"
                          onSubmit={(e)=>{
                              post(e)
                          }}
                    >
                        <input type="text" placeholder="Введите имя огранизации" value={organizationName} required onChange={(e)=>{
                            e.preventDefault()
                            setOrganizationName(e.target.value)
                        }}/>
                        <input type="text" placeholder="Введите доход организации" value={income} required onChange={(e)=>{
                            e.preventDefault()
                            setIncome(e.target.value)
                        }}/>
                        <div className="modal-form-chooser" onClick={(event)=>{
                            setVisibilityOfSelector(visibilityOfSelector === "closed"?"visiblie":"closed")
                        }}>{currentCompany.name}</div>
                        <MainPageModalSelector visibility={visibilityOfSelector}
                                               setVisibility={setVisibilityOfSelector}
                                               currentCompany={currentCompany}
                                               setCurrentCompany={setCurrentCompany} />
                        <button className="modal-form-button" type="submit" onClick={(e)=>{
                            console.log(currentCompany)
                        }}>Отправить</button>
                    </form>
                </div>
            </div>
        </>
    );
};

export default MainPageModal;