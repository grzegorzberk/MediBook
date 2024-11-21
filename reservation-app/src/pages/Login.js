import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Header from "../components/Header";
import "../components/Auth.css";

const Login = () => {
  const [formData, setFormData] = useState({ Email: "", Password: "" });
  const [serverMessage, setServerMessage] = useState("");
  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch("api/users/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        credentials: "include",
        body: JSON.stringify(formData),
      });

      const data = await response.json();

      if (!response.ok) {
        setServerMessage(data.message || "Logowanie nie powiodło się.");
        return;
      }

      if (data.role === "User") {
        navigate("/dashboard/user");
      } else if (data.role === "ServiceProvider") {
        navigate("/dashboard/service-provider");
      }
    } catch (error) {
      setServerMessage("Wystąpił błąd. Spróbuj ponownie.");
    }
  };

  return (
    <>
        <Header />
        <div className="auth-container">
        <h2>Logowanie</h2>
        <form onSubmit={handleSubmit}>
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
            <button type="submit">Zaloguj się</button>
        </form>
        {serverMessage && <p className="error-message">{serverMessage}</p>}
        <p>
            Nie masz konta? <a href="/register/user">Zarejestruj się tutaj</a>.
        </p>
        </div>
    </>
  );
};

export default Login;