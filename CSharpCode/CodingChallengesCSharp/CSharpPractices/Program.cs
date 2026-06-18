// See https://aka.ms/new-console-template for more information

using CSharpPractices;
using CSharpPractices.CodingChallenges.ArrayChallenges;
using CSharpPractices.CodingChallenges.HackerRank.DiagonalDifference;
using CSharpPractices.CodingChallenges.HackerRank.Triplets;
using CSharpPractices.CodingChallenges.InMemoryCRUDWithThredSafe;
using CSharpPractices.CodingChallenges.MatrixTraversal;
using CSharpPractices.CodingChallenges.NumberChallenges;
using CSharpPractices.CodingChallenges.SortingChallenges;
using CSharpPractices.CodingChallenges.StringChallenges;

class Program
{
    static void Main(string[] args)
    {

        //==============String related coding challenges=======starts here================

        //----------------Anagram
        //bool isAnagram = StringChallenges.IsAnagram("test", "ttseuu");
        //Console.WriteLine("The isAnagram answer is: " + isAnagram);

        //----------------Reverse a string in all words without changing the word position
        //string inputStr = "Hello World";  //Output====> olleH dlroW
        //string reversedResult = StringChallenges.ReverseStringWithBuiltInFunction(inputStr);
        //Console.WriteLine("Reversed the string in all words without changing a word position for the input " + inputStr + ": " + reversedResult);

        //----------------Reverse a string in all words without changing the word position without using built-in function
        //string inputStr = "Senior Engineer";
        //string reversedResult = StringChallenges.ReverseStringWithOutBuiltInFunction(inputStr);
        //Console.WriteLine("Reverse a string in all words without changing the word position without using built-in function for the input " + inputStr + ": " + reversedResult);

        //----------------Reverse words by using built-in function in a given string
        //string inputStr = "Hello World Example"; //Output====> Example World Hello
        //string reversedResult = StringChallenges.ReverseWordsWithBuiltInFunction(inputStr);
        //Console.WriteLine("Reversed words  by using built-in function in a given string " + inputStr + ": " + reversedResult);

        //----------------Reverse words without using built-in function in a given string
        //string inputStr = "Hello World Example";
        //string reversedResult = StringChallenges.ReverseWordsWithOutBuiltInFunction(inputStr);
        //Console.WriteLine("Reverse words without using built-in function in a given string " + inputStr + ": " + reversedResult);

        //----------------Find how many occurrences for each letter from given the sentence
        //string inputStr = "Senior Software Engineer";
        //string reversedResult = StringChallenges.TotalOccurrencesForEachLetter(inputStr);
        //Console.WriteLine("Total Occurrences For Each Letter in a given string " + inputStr + ": " + System.Environment.NewLine + reversedResult);

        //----------------Change the given string to number without using the built-in functions
        //Sample input = "657";
        //Sample output = 657;

        //string inputStr = "657";
        //int outputValue = StringChallenges.ChangeStringToNumber(inputStr);
        //Console.WriteLine("The result after convert the given string to the number for " + inputStr + ": " + outputValue);

        //----------------Check if a String is a Palindrome
        //string inputStr = "657";
        //string inputStr = "madam";
        //Console.WriteLine("The given string " + inputStr + " is Palindrom: " + StringChallenges.CheckPalindrome(inputStr));

        //-----------------Print String Array In an Increment Order
        //input = String Array {'A','B','C','D'}
        //Output should print
        //A
        //BB
        //CCC
        //DDDD

        //string[] inputArr = new string[] { "A", "B", "C", "D" };
        //StringChallenges.PrintStringArrayInIncrementOrder(inputArr);

        //==============String related coding challenges=======ends here==================


        //==============Number related coding challenges=======starts here================
        //----------------TriangleAssemble
        //int inputNum = 8; // 50000; //1001; //71; //8;
        //int result = SortingChallenges.TriangleAssemble(inputNum);
        //Console.WriteLine("Total rows we can form in triangle shape if we give " + inputNum + ":" + result + " rows.");

        //----------------Find the result of the 5 power of 4 without using any in built-in functions and any multiplication in C#
        //int PowerExAnswer = NumberChallenges.PowerEx(3, 4); // 3 * 3 * 3 * 3 = 81         
        //Console.WriteLine("The answer for PowerExAnswer is: " + PowerExAnswer);

        //----------------Display with each row numbers total sum when it is assembled as trianle row from the given number
        //Not completed
        //string result = NumberChallenges.DisplaySumOfNumbersInTriangleAssemble(4);
        //Console.WriteLine(result);


        //----------------Find Denominations
        /*
         You are given an infinite number of coins of different denominations.
        Your task is to determine the minimum number of coins required to make up a given total amount.
        You must also display how many coins of each denomination are used to make up that amount.

        Input:
        Coins: [500, 10, 2000, 100, 20, 50, 5, 1]
        Sum: 3000

        Output:
        Minimum coins required: 3
        2000 x 1
        500 x 2"
        */
        int[] coinsArr = { 500, 10, 2000, 100, 20, 50, 5, 1 };
        int sumAmount = 3527;
        NumberChallenges.FindDenominations(sumAmount, coinsArr);
        //==============Number related coding challenges=======ends here==================


        //==============Array related coding challenges=======starts here==================
        //----------------Find Max number in a array with using built-in function
        //int[] numbers = { 10, 4, 23, 54, 19 };
        //Console.WriteLine("Max Number in the numbers array is :" + ArrayChallenges.FindMaxNumerInArray(numbers));

        //----------------Find Max number in a array without using built-in function
        //int[] numbers = { 10, 4, 23, 54, 19 };
        //Console.WriteLine("Max Number in the numbers array is :" + ArrayChallenges.FindMaxNumerInArrayWithOutBuiltInFun(numbers));

        //----------------Find Second Largest Number in an array with using built-in function
        //int[] numbers = { 10, 4, 23, 54, 19 };
        //Console.WriteLine("secondLargest is: " + ArrayChallenges.FindSecondLargestNumerInArray(numbers));

        //----------------Find Second Largest Number in an array without using built-in function
        //int[] numbers = { 10, 4, 23, 54, 19 };
        //Console.WriteLine("secondLargest is: " + ArrayChallenges.FindSecondLargestNumerInArrayWithOutBuiltInFun(numbers));

        //----------------Find common elements between two lists
        //List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };
        //List<int> list2 = new List<int> { 3, 4, 5, 6, 7 };
        //Console.WriteLine("Common elements between two lists is: " + ArrayChallenges.FindCommonElementsBetweenTwoLists(list1, list2));

        //----------------Given an integer array, return the most frequent elements

        // input = {1, 2, 3, 4, 3, 6, 5, 2, 1, 5, 6, 8, 9, 1, 6, 2, 6, 5, 5, 5, 5}
        // Expected output = The element 5 appears 6 times
        int[] inputArrVal = { 1, 2, 3, 4, 3, 6, 5, 2, 1, 5, 6, 8, 9, 1, 6, 2, 6, 5, 5, 5, 5 };

        //Method-1 ==> Using Array
        //string result = ArrayChallenges.FindMostFreqElementsInAnIntegerArrayUsingArray(inputArrVal);
        //Console.WriteLine(result);

        //Method-2 ==> Using Dictionary
        string result1 = ArrayChallenges.FindMostFreqElementsInAnIntegerArrayUsingDictionary(inputArrVal);
        Console.WriteLine(result1);

        //==============Array related coding challenges=======ends here==================

        //====================HackerRank coding challenges=======starts here==================
        //----------------Compare the Triplets
        //List<int> aliceScoresList = new List<int>();
        //aliceScoresList.Add(1);
        //aliceScoresList.Add(2);
        //aliceScoresList.Add(3);

        //List<int> bobScoresList = new List<int>();
        //bobScoresList.Add(4);
        //bobScoresList.Add(5);
        //bobScoresList.Add(6);
        //Console.WriteLine("Compared Result is : " + CompareTriplets.compareTriplets(aliceScoresList, bobScoresList));

        //----------------Diagnal Difference
        //List<List<int>> arr = [[11, 2, 4], [4, 5, 6], [10, 8, -12]];
        //Console.WriteLine("Diagnal Difference Result is : " + DiagonalDifference.CalculateDiagonalDifference(arr));
        //====================HackerRank coding challenges=======ends here==================


        //=====================Thread safe, In memory cache get, set and remove operations in C#======================================
        // Need to do
        //InMemoryCRUDWithThredSafeSample objInMemory = new InMemoryCRUDWithThredSafeSample();


        //StudentRecord testCreateStu1 = new StudentRecord();
        //testCreateStu1.studentName = "Selvam";
        //objInMemory.CreateRecord(testCreateStu1);

        //StudentRecord testCreateStu2 = new StudentRecord();
        //testCreateStu2.studentName = "Kumar";
        //objInMemory.CreateRecord(testCreateStu2);

        //StudentRecord testUpdateStu1 = new StudentRecord();
        //bool isUpdated = objInMemory.UpdateRecord(2, "Rahman");

        //StudentRecord testDeleteStu1 = new StudentRecord();
        //bool isDeleted = objInMemory.DeleteRecord(2);

        ////objInMemory.DisplayStudentInfoById(1);
        ////objInMemory.DisplayStudentInfoById(13);

        //StudentRecord testCreateStu3 = new StudentRecord();
        //testCreateStu3.studentName = "Mohammed";
        //objInMemory.CreateRecord(testCreateStu3);
        //objInMemory.DisplayAllRecords();

        //==============Matrix Traversal=======starts here================
        //Zig-Zag traverse from bottom right to top left corner
        //int[,] matrix = {
        //                    {1, 2, 3, 4},
        //                    {5, 6, 7, 8},
        //                    {9, 10, 11, 12}
        //            };
        //int[] outputArray = MatrixTraversal.MatrixZigZagTraversal(matrix);


        //Right to left reverse each row from the bottom row
        //int[,] matrix = {
        //        {1, 2, 3, 4},
        //        {5, 6, 7, 8},
        //        {9, 10, 11, 12}
        //    };
        //int[] outputArray = MatrixTraversal.MatrixReverseEachRowFromRightToLeftFromBottomRow(matrix);
        //==============Matrix Traversal=======ends here==================

    }
}
