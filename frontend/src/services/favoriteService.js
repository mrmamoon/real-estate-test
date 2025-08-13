import api from './api';

export const addFavorite = (propertyId) => {
    return api.post(`/favorites/${propertyId}`);
};

export const getFavorites = () => {
    return api.get('/favorites');
};

export const removeFavorite = (propertyId) => {
    return api.delete(`/favorites/${propertyId}`);
};