import React from "react";

const Header = () => {
    return (
        <header className="header">
            <div className="header-wrapper center">
                <a href="index.html" className="logo">The city is falling asleep...</a>
                <nav>
                    <a href="#">Главная</a>
                    <a href="#">Компании</a>
                    <a href="#">Семьи</a>
                    <a href="#">Аккаунт</a>
                </nav>
            </div>
        </header>
    );
}

export default Header