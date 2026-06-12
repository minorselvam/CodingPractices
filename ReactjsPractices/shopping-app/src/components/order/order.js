import React from "react";
import { Link, useLocation } from 'react-router-dom'; // Import Link component for navigation
import OrderStatus from "./OrderStatus";

function Order() {
const location = useLocation();
const {orderID, paymentAmount, isShipped} = location.state || {};

    return (
        <div>            
            <h2>Order Component</h2>
            {/* Link navigates to /payment route and passes orderId in state */}
            <Link to="/Payment" state={{orderID:123}}>Go to Payment</Link>
            {isShipped && (
                <OrderStatus
                    orderID={orderID} 
                    paymentAmount={paymentAmount} 
                    isShipped={isShipped}
                />
            )}
        </div>
    );
}

export default Order;