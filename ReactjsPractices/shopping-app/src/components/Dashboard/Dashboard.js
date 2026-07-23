import React, { useEffect, useState } from "react";
import axios from "axios";

function Dashboard() {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios.get("/api/Products/GetAllProducts")
      .then((response) => setProducts(response.data))
      .catch(error => console.error("Error fetching products", error))
      .finally(() => setLoading(false));
  }, []);

  return (
    <div style={{ height: "100%", overflowY: "auto" }}>
      {loading ? (
        <p>Loading products...</p>
      ) : products.length === 0 ? (
        <p>No products found.</p>
      ) : (
        <div style={{ display: "grid", gridTemplateColumns: "repeat(3, 1fr)", gap: "20px" }}>
          {products.map((p) => (
            <div key={p.productId} style={{ border: "1px solid #ccc", padding: "15px", borderRadius: "8px", textAlign: "center" }}>
              <h3>{p.productName}</h3>
              <p>Brand: {p.brand}</p>
              <p>Price: ₹{p.price}</p>
            </div>
          ))}
        </div>
      )}
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