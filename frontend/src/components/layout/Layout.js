import React from 'react';
import Navbar from './Navbar';

// Make sure you're exporting as default
const Layout = ({ children }) => {
    return (
        <div>
            <Navbar />
            <main>{children}</main>
        </div>
    );
};

// Add this export statement
export default Layout;