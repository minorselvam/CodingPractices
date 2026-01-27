using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices
{
    //How to Use All Derived Methods with Same Name from Class and the multiple interfaces.
    //This can be achived by calling the interface methods by explicitly.
    //For this we need to cast the interface to call the specific interfae mehtods
    //Suppose you have:

    public class ClassA
    {
        public void Method1FromClassA()
        {
            Console.WriteLine("test from Class A");
        }
    }

    interface IinterfaceA {
        void method1();
    }

    interface IinterfaceB
    {
        void method1();
    }


    public class ClassB:ClassA, IinterfaceA, IinterfaceB
    {
        public new void Method1FromClassA()
        {
            Console.WriteLine("test from Class A from Class B");
        }

        // Implement InterfaceA.Method1 explicitly
        void IinterfaceA.method1()
        {
            Console.WriteLine("test from InterfaceA");
        }

        //// Implement InterfaceB.Method1 explicitly
        void IinterfaceB.method1()
        {
            Console.WriteLine("test from InterfaceB");
        }
    }

    //Question is How to Call Each Method. You can access each version of Method1 like this:
}
