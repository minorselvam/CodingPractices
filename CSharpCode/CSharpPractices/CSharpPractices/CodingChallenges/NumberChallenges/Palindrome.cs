using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices.CodingChallenges.NumberChallenges
{
    /*
     * Challenge Details - From the given number identify the smallest and largest palindrome number.
     * For Ex - input number = 63464; Smallest Palindrome Number = 46364; Largest Palindrome Number = 64346
     * For Ex - input number = 426624; Smallest Palindrome Number = 246642; Largest Palindrome Number = 642246
     * For Ex - input number = 43245: Result should be invalid number.
     * 
    */


    public static class Palindrome
    {
        //Identify the given number is coming under the rule of palindrom rule.

        //Rule for Palindrome if the given number total digit count is odd.
        // 63464 - Total digit count is 5.
        // Pair the same number like 66, 44
        // Unpair number should be only one


        //Rule for Palindrome if the given number total digit count is even.
        // 426624 - Total digit count is 6.
        // Pair the same numbers like 66, 44 and 22

        //6346458 ==> 66 3 44 5 8
        int inputNumber = 6346458;
       
         
    }
}
