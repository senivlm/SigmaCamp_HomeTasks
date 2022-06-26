using System;

namespace SigmaCamp_HomeTask10_2
{
    internal class Program
    {
        static int rows, cols;
        static void Main(string[] args)
        {
            Console.Write("Input number of rows for matrix: ");
            if (int.TryParse(Console.ReadLine(), out rows))
            {
                Console.Write("Input number of columns for matrix: ");
                if (int.TryParse(Console.ReadLine(), out cols))
                {
                    try
                    {
                        Matrix myMatrix = new Matrix(rows, cols);
                        //myMatrix.FillVertSnake();
                        //Console.WriteLine(myMatrix);
                        //Console.WriteLine();
                        myMatrix.FillDiagSnake();
                        Console.WriteLine(myMatrix);
                        Console.Write("Choose direction of output:\n\tHorizontal snake - 1\n\tDiagonal snake - 2\n");
                        int numDirection;
                        if (int.TryParse(Console.ReadLine(), out numDirection))
                        {
                            myMatrix.SetDirection(numDirection);
                        }
                        foreach (var item in myMatrix)
                        {
                            Console.Write(item + " ");
                        }
                        //myMatrix.FillSpirally();
                        //Console.WriteLine(myMatrix);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
