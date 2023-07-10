import React, {useState} from 'react';
import axios from "axios";

const OptionsMemberModal = (props) => {
    const baseURL="/Home/AddFamilyMember?MafiaFamilyid=&FirstName&SecondName=&Age=&RankId="
    const [memberName,setMemberName] = useState()
    const [memberSurname,setMemberSurname] = useState()
    return (
        <div>
            <div className={"modal-form " + props.visibility}>
                <div className="modal-form__content">
                    <span className="modal-form__close" onClick={(event) => {
                        props.setVisibility(props.visibility === "closed" ? "opened" : "closed")
                    }}>
                    </span>
                    <h3>НАПИШИ ИМЯ МОЛОДОГО БОЙЦА</h3>
                    <p>А мы добавим его в общий список</p>
                    <form action="#"
                          onSubmit={(e) => {
                              e.preventDefault()
                              axios.post(baseURL+
                                  "MafiaFamilyid=" + props.currentFamilyId +
                                  "&FirstName=" + memberName +
                                  "&SecondName=" + memberSurname)
                                  .catch((e)=>{
                                      console.log(e)
                                  })
                          }
                          }>
                        <input type="text" placeholder="Имя участника" value={memberName} required
                               onChange={(e) => {
                                   e.preventDefault()
                                   setMemberName(e.target.value)
                               }}/>
                        <input type="text" placeholder="Имя участника" value={memberSurname} required
                               onChange={(e) => {
                                   e.preventDefault()
                                   setMemberSurname(e.target.value)
                               }}/>

                        <button className="modal-form-button" type="submit">Отправить
                        </button>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default OptionsMemberModal;