using System;

namespace SigmaCamp_HomeTask2_2
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
                    Matrix myMatrix = new Matrix(rows, cols);
                    myMatrix.FillVertSnake();
                    Console.WriteLine(myMatrix);
                    Console.WriteLine();
                    //myMatrix.FillDiagSnake();
                    //Console.WriteLine(myMatrix);
                    myMatrix.FillSpirally();
                    Console.WriteLine(myMatrix);
                }
            }
        }
    }
}
