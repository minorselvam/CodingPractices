/*
    The Strategy Design Pattern is a behavioral design pattern that allows you to define a family of algorithms, 
    encapsulate each one in separate classes, and make them interchangeable at runtime without modifying client code. 
    It’s especially useful for eliminating complex conditional logic and enabling flexible, maintainable systems. 
*/

/*
🔑 Core Idea
    Encapsulation of algorithms: Each algorithm is placed in its own class.
    Interchangeability: Algorithms can be swapped dynamically at runtime.
    Decoupling: The client code doesn’t need to know the details of the algorithm—it only interacts through a common interface.
 */

/*
🧩 Components
    Context  
    Holds a reference to a strategy object and delegates tasks to it. Example: PaymentProcessor.

    Strategy Interface  
    Defines a common contract for all strategies. Example: IPaymentStrategy with processPayment() method.

    Concrete Strategies  
    Implement the interface with specific algorithms. Example: CreditCardStrategy, PayPalStrategy, UPIStrategy.

    Client  
    Chooses which strategy to use and passes it to the context. 
*/

/*
⚙️ How It Works
    Client selects a strategy (e.g., PayPal).
    Context delegates execution to the chosen strategy.
    Strategy executes its algorithm independently.
    Client can switch strategies without altering context or other strategies. 
*/

/*
✅ Advantages
    Flexibility: Easily switch algorithms at runtime.
    Maintainability: Avoids large conditional blocks.
    Extensibility: Add new strategies without modifying existing code.
    Testability: Each strategy can be tested independently. 
*/

/*
⚠️ Disadvantages
    Increased number of classes: Each algorithm requires its own class.
    Client awareness: Client must know which strategy to choose. 
*/

/*
🎯 When to Use
    When multiple algorithms exist for the same task.
    When you want to avoid conditional logic.
    When algorithms may change or expand in the future. 
*/
