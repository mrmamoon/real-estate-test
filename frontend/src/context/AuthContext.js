import React, { createContext, useState, useEffect, useContext } from 'react';
import { getCurrentUser } from '../services/authService';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const currentUser = getCurrentUser();
        setUser(currentUser);
        setLoading(false);
    }, []);

    const login = (token) => {
        localStorage.setItem('token', token);
        setUser(getCurrentUser());
    };

    const logout = () => {
        localStorage.removeItem('token');
        setUser(null);
    };

    return (
        <AuthContext.Provider value={{ user, login, logout, loading }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => useContext(AuthContext);