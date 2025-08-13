import React, { useState, useEffect } from 'react';
import { Container, Grid, Typography } from '@mui/material';
import PropertyCard from '../components/property/PropertyCard';
// import PropertyFilter from '../components/property/PropertyFilter';
import { getProperties } from '../services/propertyService';

const PropertyList = () => {
    const [properties, setProperties] = useState([]);
    const [filters, setFilters] = useState({
        minPrice: '',
        maxPrice: '',
        minBedrooms: '',
        minBathrooms: '',
        address: ''
    });

    useEffect(() => {
        const fetchProperties = async () => {
            try {
                const response = await getProperties(filters);
                setProperties(response.data);
            } catch (error) {
                console.error('Error fetching properties:', error);
            }
        };

        fetchProperties();
    }, [filters]);

    const handleFilterChange = (newFilters) => {
        setFilters(newFilters);
    };

    return (
        <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
            <Typography variant="h4" gutterBottom>
                Property Listings
            </Typography>

            {/* <PropertyFilter onFilterChange={handleFilterChange} /> */}

            <Grid container spacing={3}>
                {properties.map(property => (
                    <Grid item key={property.id} xs={12} sm={6} md={4}>
                        <PropertyCard property={property} />
                    </Grid>
                ))}
            </Grid>
        </Container>
    );
};

export default PropertyList;