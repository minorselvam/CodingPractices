import React, { useState } from "react";
import axios from "axios";

function ProductSearch() {
  const API_URL = process.env.REACT_APP_API_URL;
  const [searchTerm, setSearchTerm] = useState("");

  const handleSearch = async () => {
    try {
      const response = await axios.get(`/api/Products/SearchProducts?name=${searchTerm}`);
      console.log("Search Results:", response.data);
      // Next step: dispatch to Redux so Dashboard updates
    } catch (error) {
      console.error("Error fetching products.", error);
    }
  };

  return (
    <div>
      <input
        type="text"
        placeholder="Enter product name"
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
        style={{ marginRight: "10px", padding: "5px", width: "250px" }}
      />
      <button onClick={handleSearch}>Search</button>
    </div>
  );
}

export default ProductSearch;
