function OrderStatus({orderID, paymentAmount, isShipped, onStatusUpdate}) {
    // Functional component named OrderStatus
    // Props: orderID, paymentAmount, isShipped are passed from parent

    if(!isShipped) return null;
    // Conditional rendering: if isShipped is false, render nothing

    // Child defines a function that calls parent’s callback
    const notifyParent = () => {
        const message = `Order ${orderID} has been shipped with payment ${paymentAmount}`;
        console.log("Child sending message:", message);
        onStatusUpdate(message); // child → parent notification
    };

    return (
        <div>
            Order {orderID} has been shipped <br/>
            Payment Amount: {paymentAmount}   <br/>
             {/* Trigger callback when button is clicked */}
            <button onClick={notifyParent}>Notify Parent</button>
        </div>
    );
    // JSX: displays orderID and paymentAmount only when isShipped is true
}

export default OrderStatus;
// Export component so it can be imported and used in other files


/*
    📝 Key Takeaway - Props
        Props are used to pass data (orderID, paymentAmount, isShipped) from parent to child.
        Conditional rendering (if (!isShipped) return null) ensures UI only shows when the condition is met.
        This component is reusable: it can be plugged into any parent and will only display shipment info when appropriate.

    📝 Key Takeaway - child to parent communication using callback
        Parent (Order) uses useState to hold dynamic data (statusMessage).
        Parent defines a callback function (handleStatusUpdate) that updates this state.
        Child (OrderStatus) receives the callback as a prop and calls it when an event occurs.
        This pattern allows child → parent communication, with useState acting as the storage and reflection mechanism for updates.

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

            useState
            Q: What does useState return?
            A: An array with two elements: the current state value and a function to update it.
            📍 Used in Order → useState("")

            Callback Functions
            Q: How does a child notify its parent in React?
            A: By calling a function passed down as a prop (callback).
            📍 Used in OrderStatus → onStatusUpdate(message)

            Props
            Q: How is the callback function passed to the child?
            A: As a prop (<OrderStatus onStatusUpdate={handleStatusUpdate} />).
            📍 Seen in Order.js

            Event Handling
            Q: How is the callback triggered in the child?
            A: By attaching it to an event handler (e.g., onClick={notifyParent}).
            📍 Seen in OrderStatus → button onClick
*/