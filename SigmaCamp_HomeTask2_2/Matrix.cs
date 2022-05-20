using System;

namespace SigmaCamp_HomeTask2_2
{
    internal class Matrix
    {
        static int rows, cols;
        static void Main(string[] args)
        {
            int[,] matrix;
            Console.Write("Input number of rows for matrix: ");
            if (int.TryParse(Console.ReadLine(), out rows))
            {
                Console.Write("Input number of columns for matrix: ");
                if (int.TryParse(Console.ReadLine(), out cols))
                {
                    if (rows != cols)
                    {
                        matrix = new int[rows, cols];
                        VerticalSnake(ref matrix);
                        DisplayMatrix(matrix);
                    }
                    else
                    {
                        matrix = new int[rows, cols];
                        DiagSnake(ref matrix);
                        DisplayMatrix(matrix);
                        Console.WriteLine();
                        SpiralMatrix(matrix);
                        DisplayMatrix(matrix);
                    }
                }
            }
        }
        static void VerticalSnake(ref int[,] matrix)
        {
            int filler = 1;
            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, j] = filler;
                    filler++;
                }
            }
        }
        static void DiagSnake(ref int[,] matrix)
        {
            int filler = 1;
            int start;
            int end;

            //заповнення до побічної діагоналі включно
            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0)
                {
                    end = 0;
                    start = i;
                }
                else
                {
                    start = 0;
                    end = i;
                }
                for (int j = 0; j < i + 1; j++)
                {
                    matrix[start, end] = filler;
                    if (i % 2 == 1)
                    {
                        start++;
                        end--;
                    }
                    else
                    {
                        start--;
                        end++;
                    }
                    filler++;
                }
            }

            //заповнення після побічної діагоналі
            int count = 0;
            for (int i = 0; i < cols - 1; i++)
            {
                if (i % 2 == 0)
                {
                    start = rows - 1;
                    end = rows - 1 - i;
                }
                else
                {
                    start = rows - 1 - i;
                    end = rows - 1;
                }
                for (int j = 0; j < i + 1; j++)
                {
                    matrix[end, start] = matrix.Length - count;
                    if (i % 2 == 1)
                    {
                        start++;
                        end--;
                    }
                    else
                    {
                        start--;
                        end++;
                    }
                    count++;
                }
            }
        }
        static void SpiralMatrix(int[,] matrix)
        {
            int filler = 1;
            int c1 = 0, c2 = rows - 1;
            while (filler <= rows * cols)
            {
                //Заповнення вниз
                for (int j = c1; j <= c2; j++)
                    matrix[j, c1] = filler++;
                //Заповнення вправо
                for (int i = c1 + 1; i <= c2; i++)
                    matrix[c2, i] = filler++;
                //Заповнення вгору
                for (int j = c2 - 1; j >= c1; j--)
                    matrix[j, c2] = filler++;
                //Заповнення вліво
                for (int i = c2 - 1; i >= c1 + 1; i--)
                    matrix[c1, i] = filler++;
                c1++;
                c2--;
            }
        }
        static void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
