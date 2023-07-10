import React, {useState} from 'react';
import MainPageModalSelector from "../MainPage/MainPageModalSelector";
import axios from "axios";

const OptionsFamilyModal = (props) => {
    const baseURL="/Home/AddMafiaFamily?Name="
    // Сюда URL добавления семьи
    const [familyName,setFamilyName] = useState()
    return (
        <div>
            <div className={"modal-form " + props.visibility}>
                <div className="modal-form__content">
                    <span className="modal-form__close" onClick={(event) => {
                        props.setVisibility(props.visibility === "closed" ? "opened" : "closed")
                    }}>
                    </span>
                    <h3>НАЗОВИ СВОЮ СЕМЬЮ</h3>
                    <p>А с остальным порешаем как-нибудь потом</p>
                    <form action="#"
                          onSubmit={(e) => {
                              e.preventDefault()
                              axios.post(baseURL + familyName).catch((e)=>{
                                  console.log(e)
                              })
                            }
                          }>
                        <input type="text" placeholder="Введите имя огранизации" value={familyName} required
                               onChange={(e) => {
                                   e.preventDefault()
                                   setFamilyName(e.target.value)
                               }}/>

                        <button className="modal-form-button" type="submit">Отправить
                        </button>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default OptionsFamilyModal;