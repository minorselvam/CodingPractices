import React from "react";
import { Link } from 'react-router-dom';

function Order() {
    return (
        <div>
            <h2>Order Component</h2>
            <Link to="/payment">Go to Payment</Link>
        </div>
    );
}

export default Order;