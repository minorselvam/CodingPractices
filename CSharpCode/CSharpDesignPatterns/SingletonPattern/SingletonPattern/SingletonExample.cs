using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class SingletonExample
    {
        private static readonly SingletonExample instance = new SingletonExample(); //storing static reference to the single instance

        private SingletonExample() //Private constructor which will restrice the object creation of this class
        {

        }

        public static SingletonExample Instance //public static property to provide the instance
        { 
            get { 
                return instance; 
            } 
        }

        public void PrintDetails()
        {
            Console.WriteLine("test message");
        }
    }
}
