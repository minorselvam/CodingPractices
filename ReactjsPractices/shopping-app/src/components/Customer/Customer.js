import React from "react";
import { useForm } from "react-hook-form";
import axios from "axios";

function Customer() {
const {register, handleSubmit, formState: { errors }} = useForm();
const onSubmit = async (data) => {
    try {
        const response = await axios.post("/api/Customers/CreateCustomer", data);
        alert("Customer Created! Name: " + response.data.customerId)
    } 
    catch (err) {
        console.log(err);
        alert("Failed to create customer");
    }
};
   
return (
    <form onSubmit={handleSubmit(onSubmit)} style={{ padding: "20px" }}>
        <h2>Create Customer</h2>

        {/* Name */}
        <label>
            Name:
            <input
            {...register("name", { required: "Name is required" })}
            placeholder="Name"
            />
        </label>
        <p style={{ color: "red" }}>{errors.name?.message}</p>

        {/* Email */}
        <label>
            Email:
            <input
            {...register("email", {
                required: "Email is required",
                pattern: { value: /^\S+@\S+$/i, message: "Invalid email format" }
            })}
            placeholder="Email"
            />
        </label>
        <p style={{ color: "red" }}>{errors.email?.message}</p>
        
        {/* State */}
        <label>
            State:
            <input {...register("state", {required: "State is required"})} placeholder="State" />
        </label>
        <p style={{ color: "red" }}>{errors.state?.message}</p>
        
        {/* Country */}
        <label>
            Country:
            <input
            {...register("country", { required: "Country is required" })}
            placeholder="Country"
            />
        </label>
        <p style={{ color: "red" }}>{errors.country?.message}</p>

        {/* ZipCode (min 5, max 6 digits) */}
        <label>
            Zip Code:
            <input
            {...register("zipCode", {
                required: "ZipCode is required",
                minLength: { value: 5, message: "ZipCode must be at least 5 digits" },
                maxLength: { value: 6, message: "ZipCode must be at most 6 digits" },
                pattern: { value: /^[0-9]+$/, message: "ZipCode must be numeric" }
            })}
            placeholder="Zip Code"
            />
        </label>
        <p style={{ color: "red" }}>{errors.zipCode?.message}</p>

        {/* Phone (max 12 digits) */}
        <label>
            Phone:
            <input
            {...register("phone", {
                required: "Phone is required",
                maxLength: { value: 12, message: "Phone must be <= 12 digits" },
                pattern: { value: /^[0-9]+$/, message: "Phone must be numeric" }
            })}
            placeholder="Phone"
            />
        </label>
        <p style={{ color: "red" }}>{errors.phone?.message}</p>

        <button type="submit">Save</button>
    </form>
    );
}
export default Customer;


/*
🔹 Key Takeaways from the Code
    Usage of React Hook Form (useForm, register, handleSubmit).
    Integration with Axios to call a .NET Core API endpoint.
    Validation rules (required, pattern, minLength, maxLength).
    Error handling with errors object.
    Accessibility improvements with <label> tags.
    Clean separation of form state management vs. API submission logic.
==========================================================================================================

🔹 Interview Q&A
    Q1: What is useForm in React Hook Form?
    A: useForm is a hook that initializes form handling. It provides helpers like register (to connect inputs), 
       handleSubmit (to process form submission), and errors (to track validation issues).

    Example:
        JSX Code : const { register, handleSubmit, formState: { errors } } = useForm();
-----------------------------------------------------------------------------------------------------------------
    Q2: How does register work in React Hook Form?
    A: register("fieldName") wires an input field to RHF’s internal state. It automatically tracks the value and validation rules, 
       so you don’t need useState for each field.

    Example:
        JSX Code : <input {...register("name", { required: "Name is required" })} />
-----------------------------------------------------------------------------------------------------------------
    Q3: What is RHF’s handleSubmit used for?
    A: RHF’s handleSubmit wraps your onSubmit function. It collects all registered input values, validates them, and passes them as a 
       data object to your submit handler.

    Example:
    JSX Code: <form onSubmit={handleSubmit(onSubmit)}>
-----------------------------------------------------------------------------------------------------------------
    Q4: How do you perform validation using RHF’s register?
    A: You pass validation rules as options to RHF’s register. RHF automatically checks them and populates the errors object if 
       validation fails.

    Example:
    JSX Code

    <input
        {...register("zipCode", {
            required: "ZipCode is required",
            minLength: { value: 5, message: "At least 5 digits" },
            maxLength: { value: 6, message: "At most 6 digits" },
            pattern: { value: /^[0-9]+$/, message: "Must be numeric" }
        })}
        />
        <p>{errors.zipCode?.message}</p>
-----------------------------------------------------------------------------------------------------------------
    Q5: How do you integrate RHF’s form with a backend API?
    A: Use Axios or Fetch inside the onSubmit function to send collected form data to your backend endpoint.

    Example:
    JSX Code: 
    const onSubmit = async (data) => {
        await axios.post("/api/Customers/CreateCustomer", data);
    };
-----------------------------------------------------------------------------------------------------------------
    Q6: How do you handle errors in RHF’s form submission?
    A: Wrap the API call in a try/catch block. Show alerts or error messages when submission fails.

    Example:

    JSX Code: 
    try {
        const response = await axios.post("/api/Customers/CreateCustomer", data);
        alert("Customer Created! ID: " + response.data.customerId);
    } catch (err) {
        alert("Failed to create customer");
    }
-----------------------------------------------------------------------------------------------------------------
    Q7: Why are labels important in RHF’s forms?
    A: Labels improve accessibility and usability. Screen readers announce them, and users clearly see which field they’re filling.

    Example:
    JSX Code:
        <label>
            Email:
            <input {...register("email")} />
        </label>
-----------------------------------------------------------------------------------------------------------------

🔹 Summary
    RHF’s (React Hook Form’s) approach simplifies form state management compared to plain useState.
    RHF’s validation rules are declarative and concise.
    Axios integrates seamlessly with .NET Core endpoints.
    RHF’s error handling and labels improve UX and accessibility.
*/