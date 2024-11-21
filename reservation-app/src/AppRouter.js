import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./pages/Home.js";
import Login from "./pages/Login";
import RegisterUser from "./pages/RegisterUser";
import RegisterServiceProvider from "./pages/RegisterServiceProvider";
import UserDashboard from "./pages/UserDashboard";
import ServiceProviderDashboard from "./pages/ServiceProviderDashboard.js";

function AppRouter() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/login" element={<Login />} />
                <Route path="/register/user" element={<RegisterUser />} />
                <Route path="/register/service-provider" element={<RegisterServiceProvider />} />
                <Route path="/dashboard/user" element={<UserDashboard />} />
                <Route path="/dashboard/service-provider" element={<ServiceProviderDashboard />} />
            </Routes>
        </Router>
    );
}

export default AppRouter;