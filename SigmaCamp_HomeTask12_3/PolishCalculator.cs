using System;
using System.Collections.Generic;

namespace SigmaCamp_HomeTask12_3
{
    internal class PolishCalculator
    {
        static public double? Calc(PolishInvertor invertor)
        {
            string expr = invertor.GetPostfixExpr();
            Stack<double?> locals = new();
            int counter = 0;

            for (int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];

                if (Char.IsDigit(c))
                {
                    string number = invertor.ReadLexeme(expr, LexemeType.Number, ref i);
                    locals.Push(Convert.ToDouble(number));
                }
                else
                {
                    string function = invertor.ReadLexeme(expr, LexemeType.Function, ref i);
                    if (invertor.GetOperatorPriorityDict().ContainsKey(function))
                    {
                        Function currentFunction = invertor.GetOperatorPriorityDict()[function];
                        counter += 1;
                        if (currentFunction.NumOfOperators == 1)
                        {
                            double? last = locals.Count > 0 ? locals.Pop() : 0;
                            locals.Push(currentFunction.Calculate(last));
                            Console.WriteLine($"{counter}) {currentFunction.Sign}({last}) = {locals.Peek()}");
                            continue;
                        }
                        double? second = locals.Count > 0 ? locals.Pop() : 0,
                        first = locals.Count > 0 ? locals.Pop() : 0;
                        locals.Push(currentFunction.Calculate(first, second));
                        Console.WriteLine($"{counter}) {first} {currentFunction.Sign} {second} = {locals.Peek()}");
                    }
                }
            }
            return locals.Pop();
        }
    }
}
