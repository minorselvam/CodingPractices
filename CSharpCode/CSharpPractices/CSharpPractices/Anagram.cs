using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices
{
    public class Anagram
    {
        public Anagram() { }

        public bool isAnagram(string str1, string str2)
        {
            if (str1.Length!= str2.Length)
            {
                Console.WriteLine("Not Anagram");
                return false;
            }

            char[] str1Arr = str1.ToCharArray();
            Array.Sort(str1Arr);
            str1 = new string(str1Arr);

            char[] str2Arr = str2.ToCharArray();
            Array.Sort(str2Arr);
            str2 = new string(str2Arr);

            if (str1 == str2)
            {
                Console.WriteLine("Yes. It is Anagram");
                return true;
            }
            return false;
        }

    }
}
