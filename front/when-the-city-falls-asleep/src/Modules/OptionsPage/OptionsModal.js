import React, {useState} from 'react';

const OptionsModal = () => {
    const [handleChange,setHandeChange] = useState()
    return (
        <div>
            <div className="modal-form closed">
                <div className="modal-form__content">
                    <span className="modal-form__close"></span>
                    <h3>ДОБАВЛЕНИЕ ОРГАНИЗАЦИИ</h3>
                    <br/>
                    <form action="#">
                        <input type="text"  required></input>
                        <br/>
                        <input type="text" required></input>
                        <button className="modal-form-button" type="submit">Отправить</button>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default OptionsModal;