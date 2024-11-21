import React from 'react';
import './FeaturesSection.css';
import { FaUserMd, FaClock, FaMobileAlt } from 'react-icons/fa';

const FeaturesSection = () => {
  return (
    <section className="features">
      <h2>Nasze funkcje</h2>
      <div className="features-grid">
        <div className="feature-item">
          <FaUserMd size={48} />
          <h3>Szeroki wybór specjalistów</h3>
          <p>Znajdź lekarza idealnego dla Twoich potrzeb.</p>
        </div>
        <div className="feature-item">
          <FaClock size={48} />
          <h3>Rezerwacje 24/7</h3>
          <p>Umów wizytę o dowolnej porze dnia i nocy.</p>
        </div>
        <div className="feature-item">
          <FaMobileAlt size={48} />
          <h3>Mobilny dostęp</h3>
          <p>Rezerwuj wizyty z dowolnego urządzenia.</p>
        </div>
      </div>
    </section>
  );
};

export default FeaturesSection;