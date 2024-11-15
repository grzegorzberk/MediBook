import React from "react";
import { Link } from "react-router-dom";

const Home = () => {
    return (
        <div>
            <h1>Welcome to the Reservation App</h1>
            <nav>
                <ul>
                    <li><Link to="/login">Login</Link></li>
                    <li><Link to="/register/user">Register as User</Link></li>
                    <li><Link to="/register/service-provider">Register as Service Provider</Link></li>
                    <li><Link to="/dashboard/user">User Dashboard</Link></li>
                    <li><Link to="/dashboard/service-provider">Service Provider Dashboard</Link></li>
                </ul>
            </nav>
        </div>
    );
};

export default Home;