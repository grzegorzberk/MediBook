import React from 'react';
import React from "react";
import ReactDOM from "react-dom";
import AppRouter from "./AppRouter";
import { AuthProvider } from "./AuthContext";
import ProtectedRoute from "./ProtectedRoute";

ReactDOM.render(
    <React.StrictMode>
        <AuthProvider>
            <AppRouter />
        </AuthProvider>
    </React.StrictMode>,
    document.getElementById("root")
);

function AppRouter() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/login" element={<Login />} />
                <Route path="/register/user" element={<RegisterUser />} />
                <Route path="/register/service-provider" element={<RegisterServiceProvider />} />
                <Route
                    path="/dashboard/user"
                    element={
                        <ProtectedRoute role="User">
                            <UserDashboard />
                        </ProtectedRoute>
                    }
                />
                <Route
                    path="/dashboard/service-provider"
                    element={
                        <ProtectedRoute role="ServiceProvider">
                            <ServiceProviderDashboard />
                        </ProtectedRoute>
                    }
                />
                <Route path="/unauthorized" element={<Unauthorized />} />
            </Routes>
        </Router>
    );
}

function App() {
    return (
        <div>
            <h1>Witaj w mojej aplikacji rezerwacyjnej!</h1>
        </div>
    );
}

export default App;