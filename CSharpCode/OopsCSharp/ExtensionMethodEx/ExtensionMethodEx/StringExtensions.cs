using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodEx
{
    public static class StringExtensions
    {
        public static int WordCount(this string str)
        {
            if(string.IsNullOrEmpty(str)) return 0;

            return str.Split(' ', StringSplitOptions.RemoveEmptyEntries).Count();
        }
    }
}

/*
Why the WordCount Method Looks Like It Has a Parameter?
    When we define an extension method:
        public static int WordCount(this string str)


        The keyword this before string str tells the compiler:
        “This method extends the string type.”

        That means the first parameter (str) is not passed explicitly when you call the method. 
        Instead, the instance you call it on becomes the argument.

How It Works Internally (this code is in Program.cs)
    When you write:
        string sentence = "C# extension methods are very useful";
        int count = sentence.WordCount();
    
    The compiler translates it behind the scenes into:
        int count = StringExtensions.WordCount(sentence);

 So yes, the parameter is being passed — but it’s passed implicitly as the object you’re calling the method on.
*/

/*
🔹 Visualizing the Flow
        Think of it like this:
        You have an object: "Hello World".
        You call: "Hello World".WordCount().
        Compiler rewrites it to: StringExtensions.WordCount("Hello World").
        Inside the method (WordCount), "Hello World" is received as the str parameter. 
*/

/*
    🔹 Real-World Analogy
        It’s like saying:

        Normal static method:  
        Math.Abs(-5) → you pass -5 explicitly.

        Extension method:  
        (-5).Abs() → looks like the method belongs to the integer, but internally it’s still calling Math.Abs(-5). 
*/
