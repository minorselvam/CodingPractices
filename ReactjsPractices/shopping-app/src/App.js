import './App.css';
import React from 'react';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Order from './components/order/order';
import Payment from './components/payment/payment';
import Shipping from './components/shipping/shipping';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Order/>} />
        <Route path="/payment" element={<Payment/>} />
        <Route path="/shipping" element={<Shipping/>} />
      </Routes>
    </Router>
  );
}

export default App;
