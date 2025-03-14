import React from 'react';
import { useNavigate } from 'react-router-dom';
import '../styles/Home.css'; 

const Home = () => {
    const navigate = useNavigate(); 

    const handleLoginClick = () => {
        navigate('/login'); 
    };

    const handleRegisterClick = () => {
        navigate('/register');
    };

    return (
        <div className="home-container">
            <div className="home-content">
                <h1>Bine ai venit pe aplicația noastră!</h1>
                <p>Crează-ți un cont sau autentifică-te pentru a începe.</p>
                <div className="buttons">
                    <button onClick={handleRegisterClick}>Creează cont</button>
                    <button onClick={handleLoginClick}>Autentifică-te</button>
                </div>
            </div>
        </div>
    );
};

export default Home;
