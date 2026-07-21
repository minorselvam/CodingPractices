import './App.css'; 
// Import CSS for styling

import React from 'react'; 
// Core React library

import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'; 
// React Router components: Router, Routes, Route

import Dashboard from './components/Dashboard/Dashboard';
// Import Dashboard component

import Order from './components/Order/Order'; 
// Import Order component

import Payment from './components/Payment/Payment'; 
// Import Payment component

import Shipping from './components/Shipping/Shipping'; 
// Import Shipping component

import Customer from './components/Customer/Customer';

function App() {
  return (
    <Router>
      {/* Router provides navigation context */}
      <Routes>
        {/* Default route loads Dashboard */}
        <Route path="/" element={<Dashboard/>}/>

        {/* Routes container holds all route definitions */}
        <Route path="/order" element={<Order />} />
        <Route path="/payment" element={<Payment />} />
        <Route path="/shipping" element={<Shipping />} />
        <Route path="/customer" element={<Customer/>}/>
      </Routes>
    </Router>
  );
}

export default App; 
// Export App component


/*
  📝 Key Takeaway
        React Router is used for navigation (Router, Routes, Route).
        Each Route maps a URL path to a component (Order, Payment, Shipping).
        Wrapping the app in <Router> enables navigation across components.
        This modular design makes the app scalable and easy to maintain.

  🎤 Interview Q&A (with technical term references)
        React Router
        Q: What is the purpose of BrowserRouter?
        A: Provides routing context to the app, enabling navigation.
        📍 Used in Router

        Q: Difference between Routes and Route?
        A: Routes is a container for route definitions, while Route maps a path to a component.
        📍 Used in Routes and Route

        Component Imports
        Q: Why use PascalCase for component names?
        A: React treats uppercase names as components, lowercase as HTML tags.
        📍 Seen in Order, Payment, Shipping

        Props vs State
        Q: How do props differ from state?
        A: Props are read-only values passed from parent to child; state is local and mutable.
        📍 Props concept applies when passing data into Order, Payment, Shipping

        Navigation State
        Q: How can you pass data between routes?
        A: By using the state prop in <Link> and accessing it via useLocation().
        📍 Not shown in App.js, but used in Order.js / Payment.js / Shipping.js

        Best Practices
        Q: How should components be organized?
        A: Each component in its own folder with related files (JS, CSS, tests).
        📍 Demonstrated in import paths (./components/Order/Order etc.)
*/