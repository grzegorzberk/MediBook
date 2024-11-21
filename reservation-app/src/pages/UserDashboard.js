import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

const UserDashboard = () => {
  const [user, setUser] = useState(null);
  const [error, setError] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    const fetchProfile = async () => {
      try {
        const response = await fetch("/api/users/profile", {
          method: "GET",
          credentials: "include", // Przesyła ciasteczka
        });

        if (!response.ok) {
          throw new Error("Failed to fetch profile");
        }

        const userData = await response.json();
        setUser(userData);
      } catch (err) {
        setError(err.message);
        console.error(err.message);
        // Przekieruj na stronę logowania, jeśli użytkownik nie jest autoryzowany
        navigate("/login");
      }
    };

    fetchProfile();
  }, [navigate]);

  if (error) {
    return <div>Error: {error}</div>;
  }

  if (!user) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h1>Witaj, {user.name}</h1>
      <p>Rola: {user.role}</p>
    </div>
  );
};

export default UserDashboard;