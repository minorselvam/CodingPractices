import React from "react";
import { Link, useLocation } from 'react-router-dom';
// Link: used for navigation between routes
// useLocation: hook to access current route info including state

function Shipping() {
    const location = useLocation();
    // Access the current location object (includes state passed via navigation)

    const orderData = location.state || {}; 
    // Safely read the object passed via Link (fallback to {} if undefined)

    const updatedOrderData = {
        ...orderData,
        isShipped: true
    };
    // Spread operator: copy existing orderData and add/override isShipped

    console.log("updatedOrderData:", updatedOrderData); 
    // Debugging: log the full object to verify values

    return (
        <div>
            <h2>
              Shipping for the order {updatedOrderData.orderID} 
              and with the payment amount {updatedOrderData.paymentAmount}
            </h2>

            {/* Pass updated object back to Order */}
            <Link to="/" state={updatedOrderData}>
              Back to Order Component
            </Link>
        </div>        
    );
}

export default Shipping;
// Export Shipping component so it can be used in App.js

/*
    📝 Key Takeaway
        useLocation retrieves the state passed from the previous route.
        Link with state allows passing objects between routes.
        Spread operator (...orderData) is used to extend or update objects without mutating the original.
        This component updates the order data (isShipped: true) and passes it back to the parent route.

    🎤 Interview Q&A (with technical term references)
        React Router state
        Q: How do you pass and retrieve data between routes in React Router?
        A: Use the state prop in <Link> and access it via useLocation().
        📍 Used in Link and useLocation

        Spread Operator
        Q: What is the purpose of the spread operator in React?
        A: It copies existing properties into a new object, allowing you to add or override values without mutating the original.
        📍 Used in updatedOrderData

        Debugging
        Q: Why use console.log when working with navigation state?
        A: To verify that the correct data is being passed and updated between components.
        📍 Used in console.log(updatedOrderData)

        Component Export
        Q: Why do we use export default in React components?
        A: It allows the component to be imported in other files without curly braces.
        📍 Used in export default Shipping
*/