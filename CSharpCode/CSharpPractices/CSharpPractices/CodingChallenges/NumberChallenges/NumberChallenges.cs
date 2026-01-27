using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices.CodingChallenges.NumberChallenges
{
    public static class NumberChallenges
    {
        //=================Find the result of the 5 power of 4 without using any in built-in functions and any multiplication in C#
        // Multiply a and b using only addition
        /*
        // For 2 power of 3 ==> 2 * 2 * 2 == 8
        public static int Multiply(int a, int baseNum) // 1,2 :: 2,2 :: 4,2
        {
            int multiplyResult = 0;
            for (int i = 0; i < baseNum; i++)
            {
                multiplyResult += a; 
                // 0+1=1; 1+1=2;
                // 0+2=2; 2+2=4;
                // 0+4=4; 4+4=8;
            }
            return multiplyResult;
        }

        // Raise base to the exponent using only addition
        public static int Power(int baseNum, int exponent)
        {
            int result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result = Multiply(result, baseNum); // 1,2 :: 2,2 :: 4,2
            }
            return result;
        }
        */


        public static int PowerEx(int baseNum, int exponent) //3,4 ==> 3 power 4
        {
            int powerExResult = 1;
            for (int iCtr = 1; iCtr <= exponent; iCtr++)
            {
                powerExResult = AddForPower(powerExResult, baseNum);
            }
            return powerExResult;
        }

        public static int AddForPower(int howManyTimesToAddSameNumber, int baseNum)
        {
            int addForPowerResult = 0;
            for (int iCtr = 1; iCtr <= howManyTimesToAddSameNumber; iCtr++)
            {
                addForPowerResult = addForPowerResult + baseNum;
            }
            return addForPowerResult;
        }

        //Display with each row numbers total sum when it is assembled as trianle row from the given number
        /*
            For Ex input is 4 means
            1st row will have 1. And the sum of the numbers in 1st row is 1
            2nd row will have next two numbers like 2,3 and the sum of the numbers in the 2nd row is 2+3=5
            3nd row will have next three numbers like 4,5,6 and the sum of the numbers in the 3rd row is 4+5+6=15
            4th row will have next four numbers like 7,8,9,10 and the sum of the numbers in the 4th row is 7+8+9+10 = 34

            So the final display should be like below.
            1
            5
            15
            34
        */
        public static string DisplaySumOfNumbersInTriangleAssemble(int inputNumber)
        {
            string result = string.Empty;
            int sumOfEachRow = 0;
            for (int rowNumber = 1; rowNumber <= inputNumber; rowNumber++)
            {
                //int iCtr = 0;
                //do
                //{
                //    sumOfEachRow = rowNumber + iCtr;
                //    iCtr++;
                //}
                //while (iCtr <= rowNumber);

                for (int iCtr = rowNumber; iCtr <= rowNumber; iCtr++)
                {
                    sumOfEachRow = sumOfEachRow + rowNumber;
                }

                result = result + "Sum of row number " + rowNumber + " is " + sumOfEachRow + Environment.NewLine;
                sumOfEachRow = 0;
            }
            return result;
        }
    }
}
