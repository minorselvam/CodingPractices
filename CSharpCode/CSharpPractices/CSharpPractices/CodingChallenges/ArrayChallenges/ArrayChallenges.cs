using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices.CodingChallenges.ArrayChallenges
{
    public static class ArrayChallenges
    {
        //=================Find Max number in a array with using built-in function
        public static int FindMaxNumerInArray(int[] inputArray)
        {
            int result = 0;
            result = inputArray.Max();
            return result;
        }

        //=================Find Max number in a array without using built-in function
        public static int FindMaxNumerInArrayWithOutBuiltInFun(int[] inputArray)
        {
            int maxNumber = 0;
            //result = inputArray.Max();
            for (int iCtr = 0; iCtr < inputArray.Length - 1; iCtr++)
            {
                if (maxNumber < inputArray[iCtr])
                {
                    maxNumber = inputArray[iCtr];
                }
            }
            return maxNumber;
        }

        //=================Find Second Largest Number in an array with using built-in function
        public static int FindSecondLargestNumerInArray(int[] inputArray)
        {
            int result = 0;
            result = inputArray.Distinct().OrderByDescending(x => x).Skip(1).First();
            return result;
        }

        //=================Find Second Largest Number in an array without using built-in function
        //{ 10, 4, 23, 54, 19 };
        public static int FindSecondLargestNumerInArrayWithOutBuiltInFun(int[] inputArray)
        {
            int result = 0;
            //Sort Array By Descending
            int smallerNumber = 0;
            int biggerNumber = 0;
            for (int iCtr = 0; iCtr < inputArray.Length - 1; iCtr++)
            {
                for (int jCtr = 0; jCtr < inputArray.Length - 1; jCtr++)
                {
                    if (inputArray[jCtr] < inputArray[jCtr + 1])
                    {
                        smallerNumber = inputArray[jCtr];
                        biggerNumber = inputArray[jCtr + 1];
                        inputArray[jCtr] = biggerNumber;
                        inputArray[jCtr + 1] = smallerNumber;
                    }
                }
            }
            result = inputArray[1];
            //Take second element from the descending sorted array
            return result;
        }

        //=================Find common elements between two lists
        public static List<int> FindCommonElementsBetweenTwoLists(List<int> list1, List<int> list2)
        {
             List<int> result = new List<int>();
             result=list1.Intersect(list2).ToList();
            return result;
        }
    }
}
