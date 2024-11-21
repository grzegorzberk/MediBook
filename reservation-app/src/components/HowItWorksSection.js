import React from 'react';
import { FaSignInAlt, FaSearch, FaCalendarCheck } from 'react-icons/fa';
import './HowItWorksSection.css';

const HowItWorksSection = () => {
  return (
    <section className="how-it-works">
      <h2>Jak to działa?</h2>
      <div className="steps">
        <div className="step">
          <FaSignInAlt size={48} />
          <h3>Zarejestruj się lub zaloguj</h3>
          <p>Stwórz konto lub zaloguj się do istniejącego.</p>
        </div>
        <div className="step">
          <FaSearch size={48} />
          <h3>Wyszukaj specjalistę</h3>
          <p>Przeglądaj dostępnych lekarzy i usługi.</p>
        </div>
        <div className="step">
          <FaCalendarCheck size={48} />
          <h3>Zarezerwuj wizytę</h3>
          <p>Wybierz termin i potwierdź rezerwację.</p>
        </div>
      </div>
    </section>
  );
};

export default HowItWorksSection;