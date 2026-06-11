import React from "react";
import { Link } from 'react-router-dom';

function Shipping() {
    return (
        <div>
            <h2>Shipping Component</h2>
            <Link to="/">Go to Order Component</Link>
        </div>        
    )
}

export default Shipping;