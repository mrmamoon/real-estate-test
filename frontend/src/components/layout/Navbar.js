import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { AppBar, Toolbar, Button, Typography, IconButton } from '@mui/material';
import { useAuth } from '../../context/AuthContext';
import FavoriteIcon from '@mui/icons-material/Favorite';

const Navbar = () => {
    const { user, logout } = useAuth();
    const navigate = useNavigate();

    const handleLogout = () => {
        logout();
        navigate('/login');
    };

    return (
        <AppBar position="static">
            <Toolbar>
                <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                    <Link to="/" style={{ textDecoration: 'none', color: 'inherit' }}>
                        RealEstate Portal
                    </Link>
                </Typography>

                <Button color="inherit" component={Link} to="/properties">
                    Properties
                </Button>

                {user ? (
                    <>
                        <IconButton color="inherit" component={Link} to="/favorites">
                            <FavoriteIcon />
                        </IconButton>
                        <Button color="inherit" onClick={handleLogout}>
                            Logout
                        </Button>
                    </>
                ) : (
                    <>
                        <Button color="inherit" component={Link} to="/login">
                            Login
                        </Button>
                        <Button color="inherit" component={Link} to="/register">
                            Register
                        </Button>
                    </>
                )}
            </Toolbar>
        </AppBar>
    );
};

export default Navbar;