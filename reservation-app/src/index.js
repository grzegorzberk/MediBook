
import React from "react";
import ReactDOM from "react-dom";
import AppRouter from "./AppRouter";
import { AuthProvider } from "./AuthContext"; // Upewnij się, że ścieżka jest poprawna

ReactDOM.render(
    <React.StrictMode>
        <AuthProvider>
            <AppRouter />
        </AuthProvider>
    </React.StrictMode>,
    document.getElementById("root")
);