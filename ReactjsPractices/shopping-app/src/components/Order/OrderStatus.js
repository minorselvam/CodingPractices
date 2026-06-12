
function OrderStatus({orderID, paymentAmount, isShipped}) {
    if(!isShipped) return null;
    return (
        <div>
            Order {orderID} has been shipped <br/>
            Payment Amount: {paymentAmount}    
        </div>
    );
}

export default OrderStatus;