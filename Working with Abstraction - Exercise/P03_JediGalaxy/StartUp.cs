using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class StartUp
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];
            PopulateMatrix(x, y, matrix);

            string command = Console.ReadLine();

            long sum = 0;

            while (command != "Let the Force be with you")
            {
                int[] ivoCoordinates = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int[] evilCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilX = evilCoordinates[0];
                int evilY = evilCoordinates[1];

                while (evilX >= 0 && evilY >= 0)
                {
                    if (InsideMatrix(matrix, evilX, evilY))
                    {
                        matrix[evilX, evilY] = 0;
                    }
                    evilX--;
                    evilY--;
                }

                int ivoX = ivoCoordinates[0];
                int ivoY = ivoCoordinates[1];

                while (ivoX >= 0 && ivoY < matrix.GetLength(1))
                {
                    if (InsideMatrix(matrix,ivoX,ivoY))
                    {
                        sum += matrix[ivoX, ivoY];
                    }
                    ivoY++;
                    ivoX--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private static void PopulateMatrix(int x, int y, int[,] matrix)
        {
            int value = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }

        private static bool InsideMatrix(int[,] matrix, int x, int y)
        {
            return x >= 0 && x < matrix.GetLength(0) && y >= 0 &&y < matrix.GetLength(1);
        }
    }
}
