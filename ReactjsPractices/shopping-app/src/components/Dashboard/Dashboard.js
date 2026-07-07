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
