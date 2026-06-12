import React from "react";
import { Link, useLocation } from 'react-router-dom';

function Shipping() {
    const location = useLocation();
    {/* Extracting multiple values separately 
        const {orderID, paymentAmount} = location.state || {};
    */}

    const orderData = location.state || {};
    const updatedOrderData = {
        ...orderData,
        isShipped:true
    };

    console.log("updatedOrderData:" + JSON.stringify(updatedOrderData));

    return (
        <div>
            {/* Passing multiple values separately 
            <h2>Shipping for the order {orderID} and with the payment amount {paymentAmount}</h2>
            <Link to="/" state={{orderID, paymentAmount, isShipped:true}}>Go to Order Component</Link>
            */}

            {/* Pass updated object back to Order */}
            <h2>Shipping for the order {updatedOrderData.orderID} and with the payment amount {updatedOrderData.paymentAmount}</h2>
            <Link to="/" state={updatedOrderData}>Go to Order Component</Link>
        </div>        
    )
}

export default Shipping;