import React, { useContext } from "react";
import { AuthContext } from "../AuthContext";
import { useNavigate } from "react-router-dom";

const UserDashboard = () => {
    const { setUser } = useContext(AuthContext);
    const navigate = useNavigate();

    const handleLogout = async () => {
        try {
            await fetch("http://localhost:5113/api/users/logout", {
                method: "POST",
                credentials: "include",
            });
            setUser(null);
            navigate("/login");
        } catch (error) {
            console.error("Error:", error);
        }
    };

    return (
        <div>
            <h2>Panel Użytkownika</h2>
            {/* Treść panelu */}
            <button onClick={handleLogout}>Wyloguj się</button>
        </div>
    );
};

export default UserDashboard;