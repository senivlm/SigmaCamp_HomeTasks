using System;

namespace SigmaCamp_HomeTask12_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(65001);
            string expression = "20/2+(130.23-1)*cos(84-48)+sin(2.44+1.01*0.77)";
            PolishInvertor mather = new(expression);
            //Console.WriteLine(mather.GetPostfixExpr(expression));
            Console.WriteLine("Вхідний вираз: " + mather.InputExpr);
            Console.WriteLine("Постфіксна форма виразу: " + mather.PostfixExpr);
            Console.WriteLine("Дії:");
            Console.WriteLine("Значення виразу: " + PolishCalculator.Calc(mather));
            Console.WriteLine($"Перевірка: {20/2+(130.23-1)*Math.Cos(84-48)+Math.Sin(2.44+1.01*0.77)}");
        }
    }
}
