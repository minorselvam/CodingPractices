using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpPractices.CodingChallenges.StringChallenges
{
    public static class StringChallenges
    {
        //==============String related coding challenges=======starts here================
        //=================Anagram
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool IsAnagram(string str1, string str2)
        {
            Anagram objAnagram = new Anagram();
            return objAnagram.isAnagram(str1, str2);
        }

        //=================Reverse a string in all words without changing the word position by using built-in function
        /// <summary>
        /// This is to Reverse a string in all words without changing the word position by using built-in function
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string ReverseStringWithBuiltInFunction(string inputStr)
        {
            // Split the string into words and store into a string array
            string[] wordsArr = inputStr.Split(" ");

            //In each of the item from string array reverse the words
            for (int i = 0; i < wordsArr.Length; i++)
            {
                char[] charsArr = wordsArr[i].ToCharArray();
                Array.Reverse(charsArr);
                wordsArr[i] = new string(charsArr);
            }

            //Join the reversed words with a space 
            return string.Join(" ", wordsArr);
        }

        //=================Reverse a string in all words without changing the word position without using built-in function
        /// <summary>
        /// This is to Reverse a string in all words without changing the word position without using built-in function
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string ReverseStringWithOutBuiltInFunction(string inputStr)
        {
            string[] inputStrArr = inputStr.Split(' ');
            string result = string.Empty;

            for (int iCtr = 0; iCtr <= inputStrArr.Length - 1; iCtr++)
            {
                char[] tempEachWordChrArr = inputStrArr[iCtr].ToCharArray();

                for (int jCtr = tempEachWordChrArr.Length - 1; jCtr >= 0; jCtr--)
                {
                    result = result + tempEachWordChrArr[jCtr];
                }
                result = result + " ";
            }

            return result;
        }

        //=================Reverse words by using built-in function in a given string
        /// <summary>
        /// This is to Reverse words  by using built-in function in a given string
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string ReverseWordsWithBuiltInFunction(string inputStr)
        {
            //input = "hello world example";
            //output = "example world hello";
            string result = string.Join(" ", inputStr.Split(' ').Reverse());
            return result;
        }

        //=================Reverse words without using built-in function in a given string
        /// <summary>
        /// This is to Reverse words without using built-in function in a given string
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string ReverseWordsWithOutBuiltInFunction(string inputStr)
        {
            //input = "hello world example";
            //output = "example world hello";
            string result = string.Empty;
            string[] inputStrArr = inputStr.Split(" ");
            for (int iCtr = inputStrArr.Length - 1; iCtr >= 0; iCtr--)
            {
                if (!string.IsNullOrEmpty(result))
                {
                    result = result + " ";
                }
                result = result + inputStrArr[iCtr];
            }
            ;
            return result;
        }

        //=================Find how many occurrences for each letter from given the sentence
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string TotalOccurrencesForEachLetter(string inputStr)
        {
            inputStr = inputStr.Trim();
            char[] inputStrCharArr = inputStr.ToCharArray();
            int charOccurancesCount = 0;
            string result = string.Empty;
            string checkedString = string.Empty;

            foreach (char tempChar in inputStrCharArr)
            {
                if (!checkedString.Contains(tempChar) && !string.IsNullOrWhiteSpace(Convert.ToString(tempChar)))
                {
                    charOccurancesCount = inputStrCharArr.Where(a => a.Equals(tempChar)).Count();
                    result = result + "The Character " + tempChar + " Occured " + charOccurancesCount + " times" + Environment.NewLine;
                    checkedString = checkedString + tempChar;
                }
            }
            return result;
        }

        //=================Change the given string to number without using the built-in functions
        //Sample input = "657";
        //Sample output = 657;
        public static int ChangeStringToNumber(string inputStr)
        {
            int result = 0;
            try
            {
                //Change the given string to charArray
                char[] inputStrCharArr = inputStr.ToCharArray();

                //Iterate the charArray
                for (int iCtr = 0; iCtr <= inputStrCharArr.Length; iCtr++)
                {
                    result = result * 10 + (inputStrCharArr[iCtr] - '0');
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        //=================Check if a String is a Palindrome
        /// <summary>
        /// This is to Check if a String is a Palindrome
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static bool CheckPalindrome(string inputStr)
        {
            if (inputStr == new string(inputStr.Reverse().ToArray()))
            {
                return true;
            }
            return false;
        }

        public static void PrintStringArrayInIncrementOrder(string[] inputArr)
        {
            int iCtr = 1;
            int jCtr = 0;

            string result = string.Empty;

            foreach (var item in inputArr)
            {
                for (jCtr = 1; jCtr <= iCtr; jCtr++)
                {
                    result = result + item;
                }

                Console.WriteLine(result + Environment.NewLine);
                result = string.Empty;

                iCtr = iCtr + 1;
            }
        }
        //==============String related coding challenges=======ends here==================
    }
}
