import React from "react";
import { Link, useLocation } from 'react-router-dom';
// Link: for navigation
// useLocation: hook to access current route info including state

function Payment() {
    const location = useLocation(); // Get current location object
    console.log(location.state); // Debug: check what state is actually received
    const { orderID } = location.state || {}; 
    // Extract orderId from location.state (data passed from Order component).
    // If state is undefined, fallback to empty object to avoid errors.

    //Create one object with all the values
    const orderData = {orderID, paymentAmount:495}

    return (
        <div>
            <h2>Payment for Order {orderID}</h2>
             {/* Passing multiple values separately 
                <Link to="/Shipping" state={{orderID:orderID, paymentAmount:495}}>Go to Shipping</Link> 
             */}

            {/* Passing multiple values in single object */}
            <Link to="/Shipping" state={orderData}>Go to Shipping</Link> 
        </div>
    )
}

export default Payment;