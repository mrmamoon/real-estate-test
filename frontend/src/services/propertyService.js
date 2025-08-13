import api from './api';

export const getProperties = (params = {}) => {
    return api.get('/properties', { params });
};

export const getPropertyDetails = (id) => {
    return api.get(`/properties/${id}`);
};