using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodHidingOrShadowingEx
{
    public class BaseLogger
    {
        // Normal method in the base class
        public void Log()
        {
            Console.WriteLine("BaseLogger Log Method call");
        }
    }

    public class FileLogger : BaseLogger
    {
        // Hides the base class Log method using 'new'
        public new void Log()
        {
            Console.WriteLine("FileLogger Log Method call");
        }
    }
}
