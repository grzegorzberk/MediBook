import React, { useState, useContext } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../AuthContext";

const Login = () => {
    const [credentials, setCredentials] = useState({
        Email: "",
        Password: "",
    });
    const [serverMessage, setServerMessage] = useState("");
    const { setUser } = useContext(AuthContext);
    const navigate = useNavigate();

    const handleChange = (e) => {
        const { name, value } = e.target;
        setCredentials({
            ...credentials,
            [name]: value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch("http://localhost:5113/api/users/login", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                credentials: "include", // Pozwala na przesyłanie ciasteczek
                body: JSON.stringify(credentials),
            });

            const data = await response.json();

            if (!response.ok) {
                console.error("Error response from server:", data);
                setServerMessage(data.message || "Logowanie nie powiodło się.");
                return;
            }

            setUser(data); // Przechowaj informacje o użytkowniku w kontekście
            setServerMessage("Logowanie zakończone sukcesem!");

            // Przekieruj użytkownika na odpowiednią stronę
            if (data.role === "User") {
                navigate("/dashboard/user");
            } else if (data.role === "ServiceProvider") {
                navigate("/dashboard/service-provider");
            }
        } catch (error) {
            console.error("Error:", error);
            setServerMessage("Wystąpił błąd. Spróbuj ponownie.");
        }
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <h2>Logowanie</h2>
                <input
                    type="email"
                    name="Email"
                    placeholder="Email"
                    value={credentials.Email}
                    onChange={handleChange}
                    required
                />
                <input
                    type="password"
                    name="Password"
                    placeholder="Hasło"
                    value={credentials.Password}
                    onChange={handleChange}
                    required
                />
                <button type="submit">Zaloguj się</button>
            </form>
            {serverMessage && <p>{serverMessage}</p>}
        </div>
    );
};

export default Login;