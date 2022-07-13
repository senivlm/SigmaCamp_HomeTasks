using System;
using System.Collections.Generic;

namespace SigmaCamp_HomeTask12_3
{
    internal class PolishInvertor
    {
        public string InputExpr { get; private set; }
        public string PostfixExpr { get; private set; }
        private Dictionary<string, Function> _functions;
        public PolishInvertor()
        {
            _functions = new Dictionary<string, Function>()
            {
                {"(", new Function("(", 0, 0, null) }
            };
        }
        public PolishInvertor(string inputExpr):this()
        {
            InputExpr = inputExpr;
        }
        public PolishInvertor(string inputExpr, List<Function> functions) : this(inputExpr)
        {
            foreach (Function function in functions)
            {
                _functions.Add(function.Sign, function);
            }
        }
        public void AddFunction(Function function)
        {
            _functions.Add(function.Sign, function);
        }
        public Dictionary<string, Function> GetOperatorPriorityDict()
        {
            return _functions;
        }
        public string ReadLexeme(string expr, LexemeType type, ref int pointer)
        {
            string lexeme = string.Empty;
            for (; pointer < expr.Length; pointer++)
            {
                char c = expr[pointer];
                if (char.IsDigit(c) && type == LexemeType.Number || c == '.' || c == ',')
                    lexeme += c;
                else if(!char.IsDigit(c) && c != '(' && c!=')' && type == LexemeType.Function)
                {
                    lexeme += c;
                    lexeme = lexeme.Replace(" ", "");
                    if (_functions.ContainsKey(lexeme)) break;
                }
                else
                {
                    pointer--;
                    break;
                }
            }
            return lexeme;
        }

        public string GetPostfixExpr()
        {
            string postfixExpr = string.Empty;
            Stack<string> operators = new Stack<string>();
            for (int i = 0; i < InputExpr.Length; i++)
            {
                char c = InputExpr[i];
                if (char.IsDigit(c))
                {
                    postfixExpr += ReadLexeme(InputExpr, LexemeType.Number, ref i) + " ";
                }
                else if (c == '(')
                {
                    operators.Push(char.ConvertFromUtf32(c));
                }
                else if (c == ')')
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                        postfixExpr += operators.Pop();
                    operators.Pop();
                }
                else
                {
                    string function = ReadLexeme(InputExpr, LexemeType.Function, ref i);
                    if (_functions.ContainsKey(function))
                    {
                        while (operators.Count > 0 && (_functions[operators.Peek()].Priority >= _functions[function].Priority))
                            postfixExpr += operators.Pop();
                        operators.Push(function);
                    }
                }
            }
            foreach (string function in operators)
                postfixExpr += function;
            return postfixExpr;
        }
    }
}
