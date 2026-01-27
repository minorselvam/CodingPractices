using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices.CodingChallenges.SortingChallenges
{
    public static class SortingChallenges
    {
        /* 
        //Assemble a given number of students in tri angle shape. 
        //If the given number is 8. We should find how may rows we can form in triangle shape
        

        //output below
        * ----> 1st row ---> 1 student
        ** ----> 2nd row ---> 2 student
        *** ----> 3rd row ---> 3 student
        ----------> for 4th row we need 4 students.

        //Total students we used = student counts of row1 + row2 + row3  = 1+2+3 =6;
        // Remaining students = Input value - Total students we used = 8 - 6 = 2
        //To form the 4th row we need 4 students. But we have only 2 students remianing. 
        //So we can form only 3 rows if the input value is 8.
        */

        public static int TriangleAssemble(int inputVal)
        {
            int totalUsedCount = 0;
            int countPerRow = 1;
            int remainingCount = 0;
            int rowCount = 0;

            do
            {
                totalUsedCount = totalUsedCount + countPerRow; // Total used count
                if (totalUsedCount > inputVal)
                {
                    remainingCount = inputVal- totalUsedCount;
                    if (remainingCount < countPerRow)
                    {
                        break;
                    }
                }

                countPerRow = countPerRow + 1; // Count for each row
                rowCount++;
            }
            while (totalUsedCount <= inputVal);

            return rowCount;

            //int n = (int)((Math.Sqrt(8 * (long)inputVal + 1) - 1) / 2);
            //return n;
        }
    }
}
