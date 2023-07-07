import React, {useState} from 'react';

const MainPageModal = (props) => {
    const [organizationName,setOrganizationName] = useState()
    const [income,setIncome] = useState()
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
                    <form action="https://echo.htmlacademy.ru/">
                        <input type="text" placeholder={organizationName} required onChange={(e)=>{
                            e.preventDefault()
                            setOrganizationName(e.target.value)
                        }}/>
                        <input type="text" placeholder={income} required onChange={(e)=>{
                            e.preventDefault()
                            setIncome(e.target.value)
                        }}/>
                        <input type="text" required/>
                        <button type="submit">Отправить</button>
                    </form>
                </div>
            </div>
        </>
    );
};

export default MainPageModal;