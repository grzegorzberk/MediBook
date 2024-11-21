import { BrowserRouter as Router, Routes, Route, useLocation } from "react-router-dom";
import { AnimatePresence } from "framer-motion";
import Home from "./pages/Home";
import Login from "./pages/Login";
import RegisterUser from "./pages/RegisterUser";
import RegisterServiceProvider from "./pages/RegisterServiceProvider";
import UserDashboard from "./pages/UserDashboard";
import ServiceProviderDashboard from "./pages/ServiceProviderDashboard";
import AnimatedPage from "./components/AnimatedPage";

function AnimatedRoutes() {
  const location = useLocation();

  return (
    <AnimatePresence mode="wait">
      <Routes location={location} key={location.pathname}>
        <Route
          path="/"
          element={<AnimatedPage><Home /></AnimatedPage>}
        />
        <Route
          path="/login"
          element={<AnimatedPage><Login /></AnimatedPage>}
        />
        <Route
          path="/register/user"
          element={<AnimatedPage><RegisterUser /></AnimatedPage>}
        />
        <Route
          path="/register/service-provider"
          element={<AnimatedPage><RegisterServiceProvider /></AnimatedPage>}
        />
        <Route
          path="/dashboard/user"
          element={<AnimatedPage><UserDashboard /></AnimatedPage>}
        />
        <Route
          path="/dashboard/service-provider"
          element={<AnimatedPage><ServiceProviderDashboard /></AnimatedPage>}
        />
      </Routes>
    </AnimatePresence>
  );
}

function AppRouter() {
  return (
    <Router>
      <AnimatedRoutes />
    </Router>
  );
}

export default AppRouter;