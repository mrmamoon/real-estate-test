import api from './api';

export const register = async (userData) => {
    return api.post('/auth/register', userData);
};

export const login = async (credentials) => {
    return api.post('/auth/login', credentials);
};

export const getCurrentUser = () => {
    const token = localStorage.getItem('token');
    if (!token) return null;

    // Simple token parsing (for demo purposes)
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const payload = JSON.parse(window.atob(base64));

    return {
        id: payload.nameid,
        email: payload.email
    };
};