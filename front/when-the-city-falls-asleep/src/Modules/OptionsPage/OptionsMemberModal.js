import React, {useState} from 'react';

const OptionsMemberModal = (props) => {
    const [member,setMember] = useState()
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
                              console.log(e.target[0].value)
                          }
                          }>
                        <input type="text" placeholder="Имя участника" value={member} required
                               onChange={(e) => {
                                   e.preventDefault()
                                   setMember(e.target.value)
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