using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassExForPaymentProcess
{
    /*
        📖 Rules of Abstract Classes & Methods
            Abstract class → Declared with abstract, cannot be instantiated, may contain abstract + normal methods.
            Abstract method → No body, must be overridden, enforces contract.
            Derived class → Implements abstract methods using override.
            Client code → Uses abstract reference → derived object → polymorphism.

            🔑 Abstract vs Virtual — Major Differences
            ----------------------------------------------------------------------------------------------------------------------
            Feature	                Abstract	                    Virtual
            ----------------------------------------------------------------------------------------------------------------------
            Implementation	        No body (only signature).	    Has a default implementation.
            Override Requirement	Derived classes must override.	Derived classes may override.
            Class Requirement	    Only inside abstract classes.	Can be inside abstract or non-abstract classes.
            Purpose	                Enforces contract → 
                                    “You must define this.”	        Provides flexibility → “Here’s a default, override if needed.”
            Polymorphism	        Mandatory polymorphism.	        Optional polymorphism.
            ----------------------------------------------------------------------------------------------------------------------

        🚀 Quick Recall Trick
            Abstract = Rulebook 📘 (no body, must override).
            Virtual = Default behavior ⚙️ (has body, may override).
            Think A-D-C → Abstract → Derived → Client.


          Abstract vs Interface
          ----------------------------------------------------------------------
          🧩 Abstraction (Abstract Classes)
            Abstract class is declared with abstract keyword.
            Can contain abstract methods (no body) and normal methods (with body).
            Can also have fields, properties, and constructors.
            Supports runtime polymorphism — derived classes must override abstract methods.
            Use case: When you want to enforce a contract and share base functionality.
            Example: PaymentProcessor with ProcessPayment() (abstract) and PrintMessage() (shared normal method).

        🧩 Interfaces
            Interface is declared with interface keyword.
            Contains only method signatures (until C# 8, which added default implementations).
            Cannot have fields or constructors.
            A class can implement multiple interfaces (multiple inheritance of contracts).
            Use case: When you want pure contracts with no shared implementation.
            Example: IPaymentProcessor with only ProcessPayment() defined.
     */
}
