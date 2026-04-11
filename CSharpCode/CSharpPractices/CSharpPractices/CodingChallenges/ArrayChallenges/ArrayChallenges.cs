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
            result = list1.Intersect(list2).ToList();
            return result;
        }

        public static string FindMostFreqElementsInAnIntegerArrayUsingArray(int[] inputArr)
        {
            string result = string.Empty;

            // {1, 2, 3, 4, 3, 6, 2, 1, 5, 6, 8, 9, 1, 6, 2, 6}

            // 1. Sort by descending in input arr ===> inputArr
            // 2. Get Distinct values of input arr and store the values in ===> distinctValuesArr
            int[] distinctValuesArr = inputArr.OrderDescending().Distinct().ToArray();

            // 3. Intialize the new array to store the values of each distinct element and it's occurances count ===> outputArr
            int[] outputArr = new int[distinctValuesArr.Length];

            // 4. Iterate input arr with distinct values arr and get the cout of occurences in each distinct item and store into the outputArr
            int iCtr = 0;
            int tempElementOccurenceCount = 0;
            foreach (int tempValue in distinctValuesArr)
            {
                tempElementOccurenceCount = inputArr.Where(num => num.Equals(tempValue)).Count();

                outputArr[iCtr] = tempElementOccurenceCount;
                iCtr = iCtr + 1;
            }

            // 5. Get the maximum number from the outputArr and it's position value also
            int maxValueofOutputArr = outputArr.Max();
            int postionOfMaxValueofOutputArr = Array.IndexOf(outputArr, maxValueofOutputArr);
            int elementValueInInputArr = distinctValuesArr[postionOfMaxValueofOutputArr];
            result = "The element " + elementValueInInputArr + " occurs " + maxValueofOutputArr + " times in the given array ";
            return result;
        }


        public static string FindMostFreqElementsInAnIntegerArrayUsingDictionary(int[] inputArr)
        {
            string result = string.Empty;
            var frequencyMap = new SortedDictionary<int, int>();
            inputArr = inputArr.OrderBy(n => n).ToArray();

            foreach(int num in inputArr)
            {
                if(frequencyMap.ContainsKey(num))
                {
                    frequencyMap[num] = frequencyMap[num] + 1;
                }
                else
                {
                    frequencyMap[num] = 1;
                }
            }

            var maxKeyValuePair = frequencyMap.MaxBy(n => n.Value);
            result = "The element " + maxKeyValuePair.Key + " occurs " + maxKeyValuePair.Value + " times in the given array ";
            return result;
        }
    }
}
