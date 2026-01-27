using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices.CodingChallenges.MatrixTraversal
{
    public static class MatrixTraversal
    {
        /*
            Here's the task: You've been given a 2D array consisting of individual cells, each holding a unique integer value. 
            Your goal is to create a function that will traverse this matrix, starting at the bottom-right cell. 
            From there, you'll travel up to the top of the same column, then move left to the next column, 
           and then continue downward from the top of this new column. After reaching the bottom of the column, 
           you'll again move left and start moving upward. This unique traversal pattern will be performed until 
            all the cells have been visited.

            Consider this small 3x4 matrix as an example: 


                int[,] matrix = {
                    {1, 2, 3, 4},
                    {5, 6, 7, 8},
                    {9, 10, 11, 12}
                };

             Which means it starts with 12 then one row up and take same level column value (8), 
             again one row up and take same level column value (4)===> [12, 8, 4]

            Now take left and travel down with the same column level so ====> [3, 7, 11]

            With the described traversal pattern, your function should return this list: [12, 8, 4, 3, 7, 11, 10, 6, 2, 1, 5, 9].
        */
        public static int[] MatrixZigZagTraversal(int[,] matrix)
        {
            int matrixRows = matrix.GetLength(0);
            int matrixCols = matrix.GetLength(1);

            int row = matrixRows - 1;
            int col = matrixCols - 1;
            int outputArrayLength = matrixRows * matrixCols;
            int[] outputArray = new int[outputArrayLength];

            string travelDirection = "UP";
            int index = 0;

            while (index < outputArrayLength)
            {
                outputArray[index] = matrix[row, col];

                if(travelDirection== "UP")
                {
                    if (row == 0)  //if (row-1<0)
                    {
                        travelDirection = "DOWN";
                        col = col - 1;
                    }
                    else
                    {
                        row = row - 1;
                    }
                }
                else
                {
                    if (row + 1 == matrixRows)  //if (row + 1 == matrixRows) 
                    {
                        travelDirection = "UP";
                        col = col - 1;
                    }
                    else
                    {
                        row = row + 1;
                    }

                }
                index++;
            }

            foreach (int item in outputArray) {
                Console.WriteLine(item + ",");
            }
            return outputArray;
        }


        /*
         Let's explore one more way of traversal. We can leverage the utility of C#'s for loop to traverse a 
         2D matrix in reverse order. This flexibility can also create a sequence that decrements.

         To achieve this, we use a for loop with decrementing indices. Consider our familiar 3x4 matrix:

          int[,] matrix = {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12}
            };

        Using decrementing loops, the reverse traverse pattern would produce this list: {12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1}.
        */
        public static int[] MatrixReverseEachRowFromRightToLeftFromBottomRow(int[,] matrix)
        {
            int matrixRows = matrix.GetLength(0);
            int matrixCols = matrix.GetLength(1);
                        
            int[] outputArray = new int[matrixRows * matrixCols];
            int index = 0;

            for(int rowNum= matrixRows-1; rowNum>= 0; rowNum--)
            {
                for (int colNum = matrixCols-1; colNum >= 0 ; colNum--)
                {
                    outputArray[index] = matrix[rowNum, colNum];
                    index++;
                }
            }

            foreach (int item in outputArray)
            {
                Console.WriteLine(item + ",");
            }
            return outputArray;
        }
    }
}
