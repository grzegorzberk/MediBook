import React from 'react';
import { Link } from 'react-router-dom';
import './Footer.css';

const Footer = () => {
  return (
    <footer className="footer">
      <div className="footer-links">
        <Link to="/contact">Kontakt</Link>
        <Link to="/about">O nas</Link>
        <Link to="/privacy">Polityka prywatności</Link>
      </div>
      <p>© {new Date().getFullYear()} MedBooking. Wszelkie prawa zastrzeżone.</p>
    </footer>
  );
};

export default Footer;