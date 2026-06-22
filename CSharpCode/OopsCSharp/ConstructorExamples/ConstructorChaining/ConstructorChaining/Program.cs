namespace ConstructorChaining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!!!!. Welcome to the Constructor Chaining Example...");

            Consultant objConst = new Consultant("Selvam");
        }
    }
}

/*
    Execution Order
        new Consultant("Selvam") is called.
        CLR sees Consultant(string name) → notices : base(name).

        Passes "Selvam" to Employee(string empName).
        → Prints: Employee class called for the employee Selvam.

        Returns to Consultant(string name) body.
        → Prints: Consultant class called for the employee Selvam. 

    🔹 Definition of Constructor Chaining
        Constructor chaining is the process of calling one constructor from another, either within the same class (this(...)) or 
        from a derived class to its base class (base(...)).

        Within same class → this(...) helps reuse initialization logic.

        Across inheritance → base(...) ensures the base class is properly initialized before the derived class runs.


    ----------------------------------------------------------------------------------------------------------------------------------------
    🔹 All Cases of Constructor Chaining
    ----------------------------------------------------------------------------------------------------------------------------------------
    Case	    Base Class Constructors	                        Derived Class Behavior	                    Is : base(...) Required?
    Case 1	    None (compiler auto-generates parameterless)	Derived constructor runs, 
                                                                base auto-called	                        ❌ Not required
    Case 2	    Parameterless only	                            Base auto-called before derived	            ❌ Not required (optional : base())
    Case 3	    Parameterized only	                            Derived must chain with arguments	        ✅ Required
    Case 4	    Both parameterless + parameterized	            Defaults to parameterless unless 
                                                                explicitly chained	                        ❌ Not required (unless you want parameterized)



*/
