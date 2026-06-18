using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices.CodingChallenges.HackerRank.DiagonalDifference
{
    public static class DiagonalDifference
    {
        public static int CalculateDiagonalDifference(List<List<int>> arr)
        {
            int result = 0;
            //int leftToRightDiagnalSum = arr[0][0] + arr[1][1] + arr[2][2];
            //int rightToLeftDiagnalSum = arr[2][0] + arr[1][1] + arr[0][2];

            int leftToRightDiagnalSum = 0;
            int rightToLeftDiagnalSum = 0;

            for (int iCtr = 0; iCtr <= arr.Count - 1; iCtr++)
            {
                leftToRightDiagnalSum = leftToRightDiagnalSum + arr[iCtr][iCtr];
            }

            for (int iCtr = arr.Count - 1; iCtr >= 0; iCtr--)
            {
                rightToLeftDiagnalSum = rightToLeftDiagnalSum + arr[iCtr][arr.Count - 1 - iCtr];
            }

            result = Math.Abs(leftToRightDiagnalSum - rightToLeftDiagnalSum);
            return result;
        }
    }
}
