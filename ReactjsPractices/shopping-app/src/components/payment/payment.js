import React from "react";
import { Link, useLocation } from 'react-router-dom';
// Link: used for navigation between routes
// useLocation: hook to access current route info including state

function Payment() {
    const location = useLocation(); 
    // Access the current location object (includes state passed via navigation)

    console.log(location.state); 
    // Debugging: check what state was passed from Order

    const { orderID } = location.state || {}; 
    // Safely destructure orderID from location.state (fallback to {} if undefined)

    // Create one object with multiple values
    const orderData = { orderID, paymentAmount: 495 };

    return (
        <div>
            <h2>Payment for Order {orderID}</h2>

            {/* Passing multiple values in a single object */}
            <Link to="/Shipping" state={orderData}>
                Go to Shipping
            </Link> 
        </div>
    );
}

export default Payment;
// Export Payment component so it can be used in App.js


/*
    📝 Key Takeaway
        useLocation is used to read data passed via navigation state.
        Link with state allows passing objects between routes.
        Grouping values into one object (orderData) makes data passing cleaner and easier to extend.
        Debugging with console.log(location.state) helps verify what data is received.

    🎤 Interview Q&A (with technical term references)
        React Router state
        Q: How do you pass data between routes in React Router?
        A: Use the state prop in <Link> and access it via useLocation().
        📍 Used in Link and useLocation

        Object handling
        Q: Why group values into one object instead of passing separately?
        A: It keeps related data together, makes props cleaner, and simplifies extending with new fields.
        📍 Used in orderData

        Debugging
        Q: Why use console.log(location.state) in React Router flows?
        A: To verify what data was passed between components during navigation.
        📍 Used in console.log(location.state)

        Props vs State
        Q: How does passing an object via state differ from props?
        A: Props are passed parent → child directly, while state in React Router is passed across routes during navigation.
        📍 Concept applied in orderData object
*/