import {Link} from "react-router-dom";

function Header() {
    return (
        <header className="header">
            <div className="header-wrapper center">
                <Link to="/" className="logo">The city is falling asleep...</Link>
                <ul className="menu">
                    <li><Link to="/" className="menu-item">Главная</Link></li>
                    <li><Link to="/companies" className="menu-item">Компании</Link></li>
                    <li><Link to="/families" className="menu-item">Семьи</Link></li>
                    <li><Link to="/account" className="menu-item">Аккаунт</Link></li>
                </ul>
            </div>
        </header>
    );
}

export default Header;