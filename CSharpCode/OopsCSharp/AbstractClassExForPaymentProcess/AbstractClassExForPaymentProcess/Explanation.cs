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
     */
}
