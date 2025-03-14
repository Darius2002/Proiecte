import React from 'react';
import { useNavigate } from 'react-router-dom';
import '../styles/Home.css';

const Home = () => {
    const navigate = useNavigate();

    return (
        <div className="home-container">
            <div className="content">
                <h1>Bine ai venit!</h1>
                <p>Autentifică-te sau creează un cont pentru a continua.</p>
                <button className="register-btn" onClick={() => navigate('/register')}>
                    Creează cont
                </button>
                <button className="login-btn" onClick={() => navigate('/login')}>
                    Autentificare
                </button>
            </div>
        </div>
    );
};

export default Home;
