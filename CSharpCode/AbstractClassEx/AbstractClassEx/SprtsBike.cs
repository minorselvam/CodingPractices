using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassEx
{
    public class SprtsBike: MotorBike
    {
        public override void Brake()
        {
            Console.WriteLine("Sports bike brake with disc brakes");
        }
    }
}
