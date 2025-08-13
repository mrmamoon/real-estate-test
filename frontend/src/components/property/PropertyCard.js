import React from 'react';
import { Card, CardMedia, CardContent, Typography, CardActions, Button, IconButton } from '@mui/material';
import FavoriteIcon from '@mui/icons-material/Favorite';
import { Link } from 'react-router-dom';
import { useAuth } from '../../context/AuthContext';
import { addFavorite, removeFavorite } from '../../services/favoriteService';
import { toast } from 'react-toastify';

const PropertyCard = ({ property }) => {
    const { user } = useAuth();
    const [isFavorite, setIsFavorite] = React.useState(false);

    const toggleFavorite = async () => {
        if (!user) {
            toast.info('Please login to save favorites');
            return;
        }

        try {
            if (isFavorite) {
                await removeFavorite(property.id);
                toast.success('Removed from favorites');
            } else {
                await addFavorite(property.id);
                toast.success('Added to favorites');
            }
            setIsFavorite(!isFavorite);
        } catch (error) {
            toast.error('Failed to update favorite');
        }
    };

    return (
        <Card sx={{ maxWidth: 345, height: '100%', display: 'flex', flexDirection: 'column' }}>
            <CardMedia
                component="img"
                height="140"
                image={property.image || 'https://via.placeholder.com/400x300'}
                alt={property.title}
            />
            <CardContent sx={{ flexGrow: 1 }}>
                <Typography gutterBottom variant="h5" component="div">
                    {property.title}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                    {property.address}
                </Typography>
                <Typography variant="h6" sx={{ mt: 1 }}>
                    ${property.price.toLocaleString()}
                </Typography>
                <Typography variant="body2">
                    {property.bedrooms} beds | {property.bathrooms} baths
                </Typography>
            </CardContent>
            <CardActions>
                <Button size="small" component={Link} to={`/properties/${property.id}`}>
                    View Details
                </Button>
                <IconButton aria-label="add to favorites" onClick={toggleFavorite}>
                    <FavoriteIcon color={isFavorite ? 'error' : 'inherit'} />
                </IconButton>
            </CardActions>
        </Card>
    );
};

export default PropertyCard;