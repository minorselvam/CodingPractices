using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassEx
{
    public abstract class MotorBike
    {
        public abstract void Brake();

        public void Start()
        {
            Console.WriteLine("Motorbike is starting");
        }
    }
}
