import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { searchProducts } from "../../store/productsSlice";

/**
 * ProductSearch → search bar component.
 * useDispatch() gives us the store’s dispatch function.
 * We store it in const dispatch so we can call it easily.
 * dispatch() can only send Redux actions (like searchProducts),
 * not arbitrary functions.
 */
function ProductSearch() {
  const [searchTerm, setSearchTerm] = useState("");
  const dispatch = useDispatch(); // hook → gives dispatch function

  const handleSearch = () => {
    /**
     * Dispatch means "send this action to the Redux store".
     * Even though searchProducts() is defined in productsSlice.js,
     * we imported it here. Dispatch runs the thunk, which calls the API,
     * then updates Redux state. Dashboard re-renders automatically.
     */
    dispatch(searchProducts(searchTerm));
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
