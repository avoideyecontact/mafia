import React from "react";

const Main = () => {
    return (
        <main className="main">
            <div className="join">
                <button>КРЫШУЙ МЕНЯ</button>
            </div>
            <div className="stats">
                <div className="stats-wrapper center">
                <h2>ЖИЗНЬ В НАШЕМ ГОРОДКЕ - НЕПРОСТАЯ</h2>
                <p>А особенно, если вы хотите вести свой бизнес, только за сегодня произошло: </p>
                <ul className="stats__list">
                    <li className="stats__item">
                        <span>1085</span>
                        <img src="./img/icon-death.png" alt=""/>
                        <span>Убийств</span>
                    </li>
                    <li className="stats__item">
                        <span>4222</span>
                        <img src="./img/icon-steal.png" alt="" width="219"/>
                        <span>Грабежей</span>
                    </li>
                    <li className="stats__item">
                        <span>9425</span>
                        <img src="./img/icon-guns.png" alt=""/>
                        <span>Стрелок</span>
                    </li>
                </ul>
                </div>
            </div>
            <div className="stats-bottom">
                <div className="stats-bottom__wrapper">
                <h2><span>САМЫЕ РАЗУМНЫЕ</span> УЖЕ УБЕРЕГЛИ СЕБЯ</h2>
                <p>ПОЗНАКОМЬТЕСЬ С НАСТОЯЩИМИ ВЕРШИТЕЛЯМИ<br/>ПОРЯДКА В НАШЕМ ГОРОДЕ:</p>
                </div>
            </div>
        </main>
    );
}

export default Main