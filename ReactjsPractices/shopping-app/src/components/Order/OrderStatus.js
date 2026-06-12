function OrderStatus({orderID, paymentAmount, isShipped}) {
    // Functional component named OrderStatus
    // Props: orderID, paymentAmount, isShipped are passed from parent

    if(!isShipped) return null;
    // Conditional rendering: if isShipped is false, render nothing

    return (
        <div>
            Order {orderID} has been shipped <br/>
            Payment Amount: {paymentAmount}    
        </div>
    );
    // JSX: displays orderID and paymentAmount only when isShipped is true
}

export default OrderStatus;
// Export component so it can be imported and used in other files


/*
    📝 Key Takeaway
        Props are used to pass data (orderID, paymentAmount, isShipped) from parent to child.
        Conditional rendering (if (!isShipped) return null) ensures UI only shows when the condition is met.
        This component is reusable: it can be plugged into any parent and will only display shipment info when appropriate.

    🎤 Interview Q&A (with technical term references)
            Props
            Q: How are props used in React?
            A: Props allow parent components to pass data to child components. They are read‑only inside the child.
            📍 Used in OrderStatus({orderID, paymentAmount, isShipped})

            Conditional Rendering
            Q: How do you conditionally render elements in React?
            A: By using JavaScript expressions like if, ternary operators, or logical &&.
            📍 Used in if (!isShipped) return null

            JSX
            Q: What is JSX in React?
            A: JSX is a syntax extension that lets you write HTML‑like code inside JavaScript, which React transforms into elements.
            📍 Used in the return (<div>...</div>)

            Component Export
            Q: Why do we use export default in React components?
            A: It allows the component to be imported in other files without curly braces.
            📍 Used in export default OrderStatus
*/