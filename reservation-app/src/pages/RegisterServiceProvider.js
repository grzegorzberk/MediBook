import React, { useState } from "react";
import Header from "../components/Header";
import "../components/Auth.css";

const RegisterServiceProvider = () => {
  const [formData, setFormData] = useState({
    Name: "",
    Email: "",
    Password: "",
    Specialization: "",
    LicenseNumber: "",
  });
  const [serverMessage, setServerMessage] = useState("");

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch("http://localhost:5113/api/users/register/service-provider", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(formData),
      });

      const data = await response.json();

      if (!response.ok) {
        setServerMessage(data.message || "Rejestracja nie powiodła się.");
        return;
      }

      setServerMessage("Rejestracja zakończona sukcesem!");
    } catch (error) {
      setServerMessage("Wystąpił błąd. Spróbuj ponownie.");
    }
  };

  return (
    <>
        <Header />
        <div className="auth-container">
        <h2>Rejestracja lekarza</h2>
        <form onSubmit={handleSubmit}>
            <input
            type="text"
            name="Name"
            placeholder="Imię i nazwisko"
            value={formData.Name}
            onChange={handleChange}
            required
            />
            <input
            type="email"
            name="Email"
            placeholder="Email"
            value={formData.Email}
            onChange={handleChange}
            required
            />
            <input
            type="password"
            name="Password"
            placeholder="Hasło"
            value={formData.Password}
            onChange={handleChange}
            required
            />
            <input
            type="text"
            name="Specialization"
            placeholder="Specjalizacja"
            value={formData.Specialization}
            onChange={handleChange}
            required
            />
            <input
            type="text"
            name="LicenseNumber"
            placeholder="Numer licencji"
            value={formData.LicenseNumber}
            onChange={handleChange}
            required
            />
            <button type="submit">Zarejestruj się</button>
        </form>
        {serverMessage && <p className="error-message">{serverMessage}</p>}
        </div>
    </>
  );
};

export default RegisterServiceProvider;