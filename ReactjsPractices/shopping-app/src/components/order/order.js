import React from "react";
import { Link } from 'react-router-dom'; // Import Link component for navigation

function Order() {
    return (
        <div>            
            <h2>Order Component</h2>
            {/* Link navigates to /payment route and passes orderId in state */}
            <Link to="/payment" state={{orderID:123}}>Go to Payment</Link>
        </div>
    );
}

export default Order;