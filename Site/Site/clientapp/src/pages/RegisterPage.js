import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "../styles/RegisterPage.css";

function RegisterPage() {
    const navigate = useNavigate();
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState("");
    const [successMessage, setSuccessMessage] = useState("");

    const handleSubmit = async (e) => {
        e.preventDefault();

        setIsLoading(true);
        setError("");
        setSuccessMessage("");

        const userData = {
            name,
            email,
            password,
        };

        try {
            const response = await fetch("https://localhost:7008/api/user", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(userData),
            });

            if (!response.ok) {
                const errorData = await response.json();
                throw new Error(errorData.message || "Înregistrarea a eșuat. Vă rugăm încercați din nou.");
            }


            setSuccessMessage("Înregistrarea a fost realizată cu succes!");


            setTimeout(() => navigate("/login"), 2000);

        } catch (err) {

            setError(err.message);
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div className="register-container">
            <div className="register-content">
                <h2>Înregistrare</h2>
                <form onSubmit={handleSubmit}>
                    <input
                        type="text"
                        placeholder="Nume"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required
                    />
                    <input
                        type="email"
                        placeholder="Email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                    <input
                        type="password"
                        placeholder="Parolă"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                        minLength="8"
                        pattern="(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).{8,}"
                        title="Parola trebuie să conțină minim 8 caractere, o literă mare, o literă mică, un număr și un caracter special."
                    />
                    <button type="submit" disabled={isLoading}>
                        {isLoading ? "Se înregistrează..." : "Înregistrează-te"}
                    </button>
                </form>

                
                {error && <p className="error-message">{error}</p>}

               
                {successMessage && <p className="success-message">{successMessage}</p>}

                <p>Ai deja un cont? <span onClick={() => navigate("/login")}>Autentifică-te aici</span></p>
            </div>
        </div>
    );
}

export default RegisterPage;