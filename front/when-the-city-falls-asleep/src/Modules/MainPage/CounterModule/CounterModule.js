import CounterItem from "./CounterItem";

const CounterModule = (props) => {
    const items = [
        {id:1,counter:"1085",img:"../Img/IconDeath.png",subtitle:"Убийств"},
        {id:2,counter:"3445",img:"../Img/IconSteal.png",subtitle:"Грабежей"},
        {id:3,counter:"6234",img:"../Img/IconGun.png",subtitle:"Стрелок"},
    ]
    return (
        <div className="counter-module">
            <div className="counter-module-title">
                ЖИЗНЬ В НАШЕМ ГОРОДКЕ - НЕПРОСТАЯ
            </div>
            <div className="counter-module-subtitle">
                А особенно, если вы хотите вести свой бизнес, только за сегодня произошло:
            </div>
            <div className="counter-module-items">
                {
                    items.map((item)=>{
                        return <CounterItem key={item.id} counter={item.counter} img={item.img} subtitle={item.subtitle}/>
                    })
                }

            </div>
        </div>
    );
};

export default CounterModule;