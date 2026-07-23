import React from "react";

function Cart() {
  // Later we’ll connect this to Redux
  const cartItems = []; // placeholder

  return (
    <div style={{ fontWeight: "bold", fontSize: "18px" }}>
      🛒 Cart ({cartItems.length})
    </div>
  );
}

export default Cart;
