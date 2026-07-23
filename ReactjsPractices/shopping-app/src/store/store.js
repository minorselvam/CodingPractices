// src/store/store.js
import { configureStore } from "@reduxjs/toolkit";
import productsReducer from "./productsSlice"; 
// Import the reducer function from productsSlice.js
// Remember: we export productsSlice.reducer, not the whole slice object.
// The store needs a reducer function to know how to update state.

/**
 * Redux store = central state container.
 * configureStore() is a helper from Redux Toolkit that:
 *   - Combines all slice reducers
 *   - Adds useful middleware (like thunk for async actions)
 *   - Enables Redux DevTools automatically
 */
const store = configureStore({
  reducer: {
    // Each key here represents a "slice" of state.
    // The "products" slice of state will be managed by productsReducer.
    products: productsReducer
  }
});

export default store; 
// Export the store so we can provide it to <Provider> in App.js
