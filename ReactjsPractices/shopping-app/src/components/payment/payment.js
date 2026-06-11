import React from "react";
import { Link } from 'react-router-dom';

function Payment() {
    return (
        <div>
            <h2>Payment Component</h2>
            <Link to="/shipping">Go to Shipping</Link>
        </div>
    )
}

export default Payment;