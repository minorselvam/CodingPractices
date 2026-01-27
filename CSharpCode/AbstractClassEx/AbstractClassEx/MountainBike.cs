using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassEx
{
    public class MountainBike:MotorBike
    {
        public override void Brake()
        {
            Console.WriteLine("Mountain bike brake with rim brakes");
        }
    }
}
