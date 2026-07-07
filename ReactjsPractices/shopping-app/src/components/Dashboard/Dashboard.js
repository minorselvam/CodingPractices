import React, { useEffect, useState } from "react"; 
// React core library
// useState → manages local state (orders, loading)
// useEffect → performs side effects (API calls after render)

import { Link } from "react-router-dom"; 
// React Router → Link component for navigation

import axios from "axios"; 
// Axios → HTTP client for making API requests

function Dashboard() {
    const [orders, setOrders] = useState([]); 
    // useState → initializes 'orders' as empty array, updates with API response

    const [loading, setLoading] = useState(true); 
    // useState → tracks loading state (true until API finishes)

    // useEffect → runs after component mounts (first render)
    useEffect(() => {
        axios.get("/api/v1/orders/all") 
        // Axios GET request → fetches orders from backend API
        .then((response) => setOrders(response.data)) 
        // .then → updates 'orders' state with API response
        .catch(error => console.error("Error in fetching orders")) 
        // .catch → handles errors gracefully
        .finally(() => setLoading(false)); 
        // .finally → stops loading spinner regardless of success/failure
    }, []); 
    // [] dependency array → ensures effect runs only once (on mount)

    return (
        <div style={{ padding: "20px" }}>
            {/* Link → navigates to /order route */}
            <Link to="/order">
                <button style={{ marginBottom: "20px" }}>Place a new order</button>
            </Link>

            {/* Conditional rendering → shows different UI based on state */}
            {
                loading ? (
                    <p>Loading orders....</p> 
                    // If loading → show loading message
                ) : orders.length === 0 ? (
                    <p>No orders found. Please place a new order.</p> 
                    // If no orders → show empty state message
                ) : (
                    <table>
                        <thead>
                            <tr>
                                <th>Customer Name</th>
                                <th>Order Amount</th>
                            </tr>
                        </thead>
                        <tbody>
                            {orders.map(order => (
                                <tr key={order.id}>
                                    <td>{order.customerName}</td>
                                    {/* .map → iterates orders array, renders rows dynamically */}
                                    <td>{order.amount}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                )
            }
        </div>
    );
}

export default Dashboard; 
// Export default → makes Dashboard reusable in App.js

/* 
🔹 Key Takeaways

:

useState
    A Hook that lets you add state to functional components.
    Returns a stateful value and a function to update it.
    Example: const [count, setCount] = useState(0);

useEffect
    A Hook that lets you perform side effects in function components.
    Side effects include data fetching, subscriptions, or manually changing the DOM.
    Runs after the component renders, and can clean up when the component unmounts.

Axios (not part of React docs, but widely used)
    A promise-based HTTP client for the browser and Node.js.
    Simplifies making API requests and handling responses compared to fetch.
    Promise .then/.catch/.finally (JavaScript feature, not React-specific)
    .then() → runs when the promise resolves successfully.
    .catch() → runs when the promise rejects (error).
    .finally() → runs after either success or failure, useful for cleanup.

React Router Link
    A component that lets you navigate between routes without reloading the page.
    Replaces <a> tags in React apps for client-side navigation.
    Example: <Link to="/about">About</Link>

Conditional Rendering (React docs: Rendering Elements)
    In React, you can conditionally render components based on state or props.
    Uses JavaScript operators like if, &&, or ? :.
    Example: {isLoggedIn ? <LogoutButton /> : <LoginButton />}

Array .map() (JavaScript feature, used in React rendering)
    Creates a new array by applying a function to each element.
    In React, commonly used to render lists of elements.
    Example: {items.map(item => <li key={item.id}>{item.name}</li>)}

Export default (JavaScript ES6 feature)
    Allows you to export a single value or component from a file.
    Makes it easy to import without curly braces.

    Example:
        export default Dashboard;
        import Dashboard from './Dashboard';
*/