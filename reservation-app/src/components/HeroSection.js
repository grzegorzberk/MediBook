import React from 'react';
import { Link } from 'react-router-dom';
import './HeroSection.css';

const HeroSection = () => {
  return (
    <section className="hero">
      <div className="hero-content">
        <h1>Rezerwuj usługi medyczne online</h1>
        <p>Wygodne i szybkie rozwiązanie dla Twojego zdrowia.</p>
        <div className="hero-buttons">
          <Link to="/register/user" className="btn btn-primary">Zarejestruj się jako klient</Link>
          <Link to="/register/service-provider" className="btn btn-secondary">Dołącz jako lekarz</Link>
        </div>
      </div>
    </section>
  );
};

export default HeroSection;