import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

/**
 * Thunk = async function that lets Redux handle side effects (like API calls).
 * Here we define searchProducts. The first string "products/searchProducts"
 * is the action type prefix. Redux Toolkit uses it to generate 3 lifecycle actions:
 *   - "products/searchProducts/pending"   → request started
 *   - "products/searchProducts/fulfilled" → request succeeded
 *   - "products/searchProducts/rejected"  → request failed
 * These are mandatory because Redux needs to know how to track async state.
 */
export const searchProducts = createAsyncThunk(
  "products/searchProducts",   // action type prefix (namespace + action)
  async (searchTerm, { rejectWithValue }) => { // rejectWithValue lets us send custom error
    try {
      const response = await axios.get(
        `/api/Products/SearchProducts?name=${searchTerm}`
      );
      return response.data;      // returned data becomes Redux state
    } catch (error) {
      // Catch network/server errors and pass them to rejected case
      return rejectWithValue(error.response?.data || error.message);
    }
  }
);

/**
 * Another thunk → fetch all products for Dashboard default view.
 * Same lifecycle: pending → fulfilled → rejected.
 */
export const fetchAllProducts = createAsyncThunk(
  "products/fetchAllProducts",
  async (_, { rejectWithValue }) => {
    try {
    //   const API_URL = process.env.REACT_APP_API_URL;
      const response = await axios.get(`/api/Products/GetAllProducts`);
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response?.data || error.message);
    }
  }
);

// Slice definition → manages product state
const productsSlice = createSlice({
  name: "products",
  initialState: {
    items: [],      // product list
    loading: false, // loading flag
    error: null     // error message
  },
  reducers: {},     // synchronous reducers (none yet)
  /**
   * extraReducers → used to handle actions generated outside this slice,
   * like async thunks (pending, fulfilled, rejected).
   * Without extraReducers, we couldn’t respond to thunk lifecycle actions.
   */
  extraReducers: (builder) => {
    builder
      // Search products lifecycle
      .addCase(searchProducts.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(searchProducts.fulfilled, (state, action) => {
        state.loading = false;
        state.items = action.payload; // update with search results
      })
      .addCase(searchProducts.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload; // error from try/catch
      })
      // Fetch all products lifecycle
      .addCase(fetchAllProducts.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(fetchAllProducts.fulfilled, (state, action) => {
        state.loading = false;
        state.items = action.payload; // update with all products
      })
      .addCase(fetchAllProducts.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload;
      });
  }
});

/**
 * export default productsSlice.reducer;
 * We export ONLY the reducer function here, not the whole slice object.
 * The store needs a reducer function to know how to update state.
 * If we exported productsSlice itself, Redux would throw an error.
 */
export default productsSlice.reducer;