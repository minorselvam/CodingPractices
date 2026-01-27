using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices
{
    public  interface ICalculateHolidays
    {
        int GetHolidays(int holidayCount);
    }

    public class CalculateHolidays : ICalculateHolidays
    {
        public int GetHolidays(int holidayCount)
        {
            return holidayCount;
        }
    }
}
