using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices.CodingChallenges.HackerRank.Triplets
{

    public static class CompareTriplets
    {
        public static List<int> compareTriplets(List<int> a, List<int> b)
        {
            List<int> resultArr = new List<int>();
            int aScore = 0;
            int bScore = 0;

            if (a.Count != b.Count)
            {
                return resultArr;
            }

            for (int iCtr = 0; iCtr <= a.Count() - 1; iCtr++)
            {
                if (a[iCtr] == b[iCtr])
                {
                    continue;
                }

                if (a[iCtr] > b[iCtr])
                {
                    aScore = aScore + 1;
                }
                else
                {
                    bScore = bScore + 1;
                }
            }

            resultArr.Add(aScore);
            resultArr.Add(bScore);

            return resultArr;
        }
    }
}
