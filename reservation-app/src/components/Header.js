import React from 'react';
import { Link } from 'react-router-dom';
import './Header.css';

const Header = () => {
  return (
    <header className="header">
      <div className="logo">
        <Link to="/">MedBooking</Link>
      </div>
      <nav className="nav">
        <ul>
          <li><Link to="/">Strona główna</Link></li>
          <li><Link to="/login">Logowanie</Link></li>
          <li><Link to="/register/user">Rejestracja klienta</Link></li>
          <li><Link to="/register/service-provider">Rejestracja lekarza</Link></li>
        </ul>
      </nav>
    </header>
  );
};

export default Header;