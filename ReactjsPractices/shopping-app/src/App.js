import './App.css';
import React from 'react';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Order from './components/Order/Order';
import Payment from './components/Payment/Payment';
import Shipping from './components/Shipping/Shipping';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Order/>} />
        <Route path="/Payment" element={<Payment/>} />
        <Route path="/Shipping" element={<Shipping/>} />
      </Routes>
    </Router>
  );
}

export default App;
