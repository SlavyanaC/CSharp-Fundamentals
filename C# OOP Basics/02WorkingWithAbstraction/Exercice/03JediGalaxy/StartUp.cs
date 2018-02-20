using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int x, y;
        int[,] matrix;

        InitializeMatrix(out x, out y, out matrix);

        FillMatrixWithValues(x, y, matrix);

        string command = Console.ReadLine();
        long sum = 0;

        while (command != "Let the Force be with you")
        {
            int[] ivoS = ReadIvosCoords(command);
            int[] evil = ReadEvilCoords();

            DestroyStars(matrix, evil);
            sum = CollectStars(matrix, sum, ivoS);

            command = Console.ReadLine();
        }

        Console.WriteLine(sum);
    }

    private static long CollectStars(int[,] matrix, long sum, int[] ivoS)
    {
        int ivoX = ivoS[0];
        int ivoY = ivoS[1];

        while (ivoX >= 0 && ivoY < matrix.GetLength(1))
        {
            if (ivoX >= 0 && ivoX < matrix.GetLength(0) && ivoY >= 0 && ivoY < matrix.GetLength(1))
            {
                sum += matrix[ivoX, ivoY];
            }

            ivoY++;
            ivoX--;
        }

        return sum;
    }

    private static void DestroyStars(int[,] matrix, int[] evil)
    {
        int evilX = evil[0];
        int evilY = evil[1];

        while (evilX >= 0 && evilY >= 0)
        {
            if (evilX >= 0 && evilX < matrix.GetLength(0) && evilY >= 0 && evilY < matrix.GetLength(1))
            {
                matrix[evilX, evilY] = 0;
            }
            evilX--;
            evilY--;
        }
    }

    private static int[] ReadIvosCoords(string command)
    {
        return command
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
    }

    private static int[] ReadEvilCoords()
    {
        return Console.ReadLine()
                        .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
    }

    private static void FillMatrixWithValues(int x, int y, int[,] matrix)
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

    private static void InitializeMatrix(out int x, out int y, out int[,] matrix)
    {
        int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        x = dimestions[0];
        y = dimestions[1];
        matrix = new int[x, y];
    }
}