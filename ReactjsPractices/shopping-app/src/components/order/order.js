import React from "react";
import { Link, useLocation } from 'react-router-dom'; 
// Link: used for navigation between routes
// useLocation: hook to access current route info including state

import OrderStatus from "./OrderStatus"; 
// Import child component to display order status

function Order() {
    const location = useLocation(); 
    // Access the current location object (includes state passed via navigation)

    const {orderID, paymentAmount, isShipped} = location.state || {}; 
    // Destructure values from location.state safely (fallback to {} if undefined)

    return (
        <div>            
            <h2>Order Component</h2>

            {/* Link navigates to /payment route and passes orderID in state */}
            <Link to="/payment" state={{orderID:123}}>
                Go to Payment
            </Link>

            {/* Pass props to child component for conditional rendering */}
            <OrderStatus 
                orderID={orderID} 
                paymentAmount={paymentAmount} 
                isShipped={isShipped} 
            />
        </div>
    );
}

export default Order;
// Export Order component so it can be used in App.js


/*
    📝 Key Takeaway
        useLocation retrieves data passed via navigation state.
        Link with state allows passing values between routes.
        Props are used to pass data from parent (Order) to child (OrderStatus).
        This structure separates concerns: Order handles navigation, while OrderStatus handles display logic.

    🎤 Interview Q&A (with technical term references)
        React Router state
        Q: How do you pass data between routes in React Router?
        A: By using the state prop in <Link> and accessing it via useLocation().
        📍 Used in Link and useLocation

        Props
        Q: How are props used in React?
        A: Props allow parent components to pass data to child components. They are read‑only inside the child.
        📍 Used in OrderStatus component call

        Component Composition
        Q: Why split logic into parent and child components?
        A: It improves reusability and readability. The parent manages data flow, while the child focuses on presentation.
        📍 Seen in Order (parent) and OrderStatus (child)

        Conditional Rendering
        Q: How do you conditionally render elements in React?
        A: By using logical checks (if, &&, ternary). In this case, the child component itself handles conditional rendering.
        📍 Implemented inside OrderStatus
*/