using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask12_3
{
    internal class PolishCalculator
    {
        static private double Execute(char op, double first, double second = 0) => op switch
        {
            '+' => first + second, 
            '-' => first - second, 
            '*' => first * second, 
            '/' => first / second, 
            '^' => Math.Pow(first, second),
            's' => Math.Sin(first),
            'c' => Math.Cos(first),
            _ => 0 
        };
        static public double Calc(PolishInvertor invertor)
        {
            string expr = invertor.PostfixExpr;
            Stack<double> locals = new();
            int counter = 0;

            for (int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];

                if (Char.IsDigit(c))
                {
                    string number = invertor.ReadNumber(expr, ref i);
                    locals.Push(Convert.ToDouble(number));
                }
                else if (invertor.GetOperatorPriorityDict().ContainsKey(c))
                {
                    counter += 1;
                    if (c == 's' && expr[++i] == 'i' && expr[++i] == 'n')
                    {
                        double last = locals.Count > 0 ? locals.Pop() : 0;
                        locals.Push(Execute(c, last));
                        Console.WriteLine($"{counter}) sin({last}) = {locals.Peek()}");
                        continue;
                    }
                    if (c == 'c' && expr[++i] == 'o' && expr[++i] == 's')
                    {
                        double last = locals.Count > 0 ? locals.Pop() : 0;
                        locals.Push(Execute(c, last));
                        Console.WriteLine($"{counter}) cos({last}) = {locals.Peek()}");
                        continue;
                    }
                    double second = locals.Count > 0 ? locals.Pop() : 0,
                    first = locals.Count > 0 ? locals.Pop() : 0;
                    locals.Push(Execute(c, first, second));
                    Console.WriteLine($"{counter}) {first} {c} {second} = {locals.Peek()}");
                }
            }
            return locals.Pop();
        }
    }
}
