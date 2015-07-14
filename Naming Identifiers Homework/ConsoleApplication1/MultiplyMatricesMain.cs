namespace ConsoleApplication1
{
    using System;

    internal class MultiplyMatricesMain
    {
        private static void Main(string[] args)
        {
            double[,] firstMatrix = { { 1, 3 }, { 5, 7 } };
            double[,] secondMatrix = { { 4, 2 }, { 1, 5 } };
            double[,] result = CalculateMatrixMultiplication(firstMatrix, secondMatrix);

            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int col = 0; col < result.GetLength(1); col++)
                {
                    Console.Write(result[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static double[,] CalculateMatrixMultiplication(double[,] firstMatrix, double[,] secondMatrix)
        {
            int firstMatrixCols = firstMatrix.GetLength(1);
            int secondMatrixRows = secondMatrix.GetLength(0);

            if (firstMatrixCols != secondMatrixRows)
            {
                throw new InvalidOperationException(
                    "First matrix number of columns must be equal to second matrix number of rows!");
            }

            double[,] multipliedMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (int row = 0; row < multipliedMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < multipliedMatrix.GetLength(1); col++)
                {
                    for (int k = 0; k < firstMatrixCols; k++)
                    {
                        multipliedMatrix[row, col] += firstMatrix[row, k] * secondMatrix[k, col];
                    }
                }
            }

            return multipliedMatrix;
        }
    }
}