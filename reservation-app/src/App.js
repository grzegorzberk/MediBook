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

export default App;