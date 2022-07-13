using System;
using System.Collections.Generic;
namespace SigmaCamp_HomeTask12_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(65001);
            List<Function> functions = new List<Function>()
                {
                    new Function("+", 2, 1, (a,b)=> (double)(a + b)),
                    new Function("-", 2, 1, (a,b)=> (double)(a - b)),
                    new Function("*", 2, 2, (a,b)=> (double)(a * b)),
                    new Function("/", 2, 2, (a,b)=> (double)(a / b)),
                    new Function("^", 2, 3, (a,b)=> Math.Pow((double)a, (double)b)),
                    new Function("sin", 1, 3, (a, b)=> Math.Sin((double)a)),
                    new Function("cos", 1, 3, (a,b)=> Math.Cos((double)a)),
                };
            string expression = "20/2+(130.23-1)*cos(84-48)+sin(2.44+1.01*0.77)";
            PolishInvertor mather = new(expression, functions);
            mather.GetPostfixExpr();
            Console.WriteLine("Вхідний вираз: " + mather.InputExpr + "\n");
            Console.WriteLine("Постфіксна форма виразу: " + mather.GetPostfixExpr() + "\n");
            Console.WriteLine("Дії:");
            Console.WriteLine("Значення виразу: " + PolishCalculator.Calc(mather));
            Console.WriteLine();
            Console.WriteLine($"Перевірка: {20 / 2 + (130.23 - 1) * Math.Cos(84 - 48) + Math.Sin(2.44 + 1.01 * 0.77)}");
        }
    }
}
