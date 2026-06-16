import React, { useState } from "react";
import { Link, useLocation } from 'react-router-dom'; 
// Link: used for navigation between routes
// useLocation: hook to access current route info including state

import OrderStatus from "./OrderStatus"; 
// Import child component to display order status

function Order() {
    // Access the current location object (includes state passed via navigation)
    const location = useLocation(); 

    // useState: creates a state variable in the parent
    // statusMessage → holds the current message
    // setStatusMessage → function to update the message
    const [statusMessage, setStatusMessage] = useState("");

    // Callback function: child will call this to notify parent
    const handleStatusUpdate = (message) => {
        console.log("Message received in parent:", message);
        setStatusMessage(message); // update parent state with child’s data
    
    }

    // Destructure values from location.state safely (fallback to {} if undefined)
    const {orderID, paymentAmount, isShipped} = location.state || {}; 

    return (
        <div>            
            <h2>Order Component</h2>
            {/* Display the message updated via child callback */}
            <p>{statusMessage}</p>

            {/* Link navigates to /payment route and passes orderID in state */}
            <Link to="/payment" state={{orderID:123}}>
                Go to Payment
            </Link>

            {/* Pass props to child component for conditional rendering */}
            <OrderStatus 
                orderID={orderID} 
                paymentAmount={paymentAmount} 
                isShipped={isShipped} 
                onStatusUpdate={handleStatusUpdate} 
            />
        </div>
    );
}
export default Order;
// Export Order component so it can be used in App.js

/*
    📝 Key Takeaway - Props
        useLocation retrieves data passed via navigation state.
        Link with state allows passing values between routes.
        Props are used to pass data from parent (Order) to child (OrderStatus).
        This structure separates concerns: Order handles navigation, while OrderStatus handles display logic.
    
    📝 Key Takeaway - child to parent communication using callback
        useState in the parent creates a local state (statusMessage) that can be updated dynamically.
        Parent defines a callback function (handleStatusUpdate) that updates this state.
        Child receives the callback as a prop and calls it to notify the parent.
        This pattern allows child → parent communication, with useState acting as the storage and reflection mechanism for updates.

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

        useState
        Q: What does useState return?
        A: An array with two elements: the current state value and a function to update it.
        📍 Used in Order → useState("")

        Callback Functions
        Q: How does a child notify its parent in React?
        A: By calling a function passed down as a prop (callback).
        📍 Used in OrderStatus → onStatusUpdate(message)

        Props
        Q: How is the callback function passed to the child?
        A: As a prop (<OrderStatus onStatusUpdate={handleStatusUpdate} />).
        📍 Seen in Order.js

        Event Handling
        Q: How is the callback triggered in the child?
        A: By attaching it to an event handler (e.g., onClick={notifyParent}).
        📍 Seen in OrderStatus → button onClick
*/