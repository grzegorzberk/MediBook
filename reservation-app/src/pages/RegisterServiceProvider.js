import React, { useState } from "react";

const RegisterServiceProvider = () => {
    const [formData, setFormData] = useState({
        Name: "",
        Email: "",
        PasswordHash: "",
    });

    const [serverMessage, setServerMessage] = useState("");
    const [isSuccess, setIsSuccess] = useState(false);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch("http://localhost:5113/api/users/register/service-provider", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(formData),
            });

            const data = await response.json();

            if (!response.ok) {
                console.error("Error response from server:", data);
                setServerMessage(data.message || "Rejestracja nie powiodła się.");
                setIsSuccess(false);
                return;
            }

            setServerMessage(data.message || "Rejestracja zakończona sukcesem!");
            setIsSuccess(true);

            setFormData({
                Name: "",
                Email: "",
                PasswordHash: "",
            });
        } catch (error) {
            console.error("Error:", error);
            setServerMessage("Wystąpił błąd. Spróbuj ponownie.");
            setIsSuccess(false);
        }
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <h2>Rejestracja dostawcy usług</h2>
                <input
                    type="text"
                    name="Name"
                    placeholder="Imię"
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
                    name="PasswordHash"
                    placeholder="Hasło"
                    value={formData.PasswordHash}
                    onChange={handleChange}
                    required
                />
                <button type="submit">Zarejestruj</button>
            </form>
            {serverMessage && (
                <p style={{ color: isSuccess ? "green" : "red" }}>{serverMessage}</p>
            )}
        </div>
    );
};

export default RegisterServiceProvider;