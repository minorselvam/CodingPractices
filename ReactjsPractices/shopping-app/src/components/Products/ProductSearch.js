import React, {useState} from "react";
import axios from 'axios';

function ProductSearch() {
    const API_URL = process.env.REACT_APP_API_URL;
    console.log("API_URL:", API_URL);

    const[searchTerm, setSearchTerm] = useState("");
    const[products, setProducts] = useState([]);

    const handleSearch = async () => {
        try {
            const response = await axios.get(`/api/Products/SearchProducts?name=${searchTerm}`);
            setProducts(response.data);
        }
        catch(error) {
            console.error("Error fetching the products.", error);
        }
    };

    return (
        <div style={{ padding: "20px" }}>
            {/* Search bar + button */}
            <input
                type="text"
                placeholder="Enter product name"
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
                style={{ marginRight: "10px", padding: "5px" }}
            />
            <button onClick={handleSearch}>Search</button>

            {/* Grid layout */}
            <div
                style={{
                display: "grid",
                gridTemplateColumns: "repeat(3, 1fr)",
                gap: "20px",
                marginTop: "20px"
                }}
            >
                {products.map((p) => (
                    <div
                        key={p.productId}
                        style={{
                        border: "1px solid #ccc",
                        padding: "15px",
                        borderRadius: "8px",
                        textAlign: "center"
                        }}
                    >
                        <h3>{p.productName}</h3>
                        <p>Brand: {p.brand}</p>
                        <p>Price: ₹{p.price}</p>
                    </div>
                    ))}
            </div>
        </div>
    );
}

export default ProductSearch;