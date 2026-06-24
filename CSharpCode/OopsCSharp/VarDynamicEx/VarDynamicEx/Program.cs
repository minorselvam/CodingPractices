namespace VarDynamicEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!!!. Welcome to the string VS var VS Dynamic example.");

            // string is a strongly typed reference type.
            // Once declared as string, it can only hold string values.
            // Trying to assign an integer (98) will cause a compile-time error 
            // because the compiler enforces type safety.
            string stringInput = "test";
            // stringInput = 98; // ❌ Compile-time error

            // var is compiler-determined typing.
            // At compile time, the compiler sees 23 and determines varInput as int.
            // After that, varInput is locked as int. 
            // Trying to assign a string later will cause a compile-time error.
            var varInput = 23;
            // varInput = "var input type changing here"; // ❌ Compile-time error

            // dynamic is resolved at runtime.
            // You can assign different types to the same variable.
            // But beware: if you call a method that doesn’t exist on the runtime type,
            // you’ll get a runtime exception instead of a compile-time error.
            dynamic dynamicInput = 45;
            dynamicInput = "dynamic input changing here"; // ✅ Works fine
            Console.WriteLine(dynamicInput.ToUpper());    // ✅ Works at runtime
        }
    }
}

/*

🔹 Unified Comparison Table
---------------------------------------------------------------------------------------------------------------------------------------
Keyword/Type	Type Resolution	    Can Change Type Later?	    Error Type	        Can Assign null?	Why
---------------------------------------------------------------------------------------------------------------------------------------
string	        Explicitly declared	        ❌ No	            Compile-time error	        ✅ Yes	    Reference type, can point to nothing
var	            Determined at compile time	❌ No	            Compile-time error	        ❌ No	    Compiler cannot determine type from null
dynamic	        Resolved at runtime	        ✅ Yes	            Runtime error if misused	✅ Yes	    Runtime type resolution allows null 
*/
