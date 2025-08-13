import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { AuthProvider } from './context/AuthContext';
import Layout from './components/layout/Layout';
// import Home from './pages/Home';
import PropertyList from './pages/PropertyList';
// import PropertyDetail from './pages/PropertyDetail';
// import Favorites from './pages/Favorites';
import Login from './pages/Login';
// import Register from './pages/Register';

function App() {
  return (
    <AuthProvider>
      <Router>
        <Layout>
          <Routes>
            {/* <Route path="/" element={<Home />} /> */}
            <Route path="/properties" element={<PropertyList />} />
            {/* <Route path="/properties/:id" element={<PropertyDetail />} /> */}
            {/* <Route path="/favorites" element={<Favorites />} /> */}
            <Route path="/login" element={<Login />} />
            {/* <Route path="/register" element={<Register />} /> */}
          </Routes>
        </Layout>
        <ToastContainer position="bottom-right" />
      </Router>
    </AuthProvider>
  );
}

export default App;