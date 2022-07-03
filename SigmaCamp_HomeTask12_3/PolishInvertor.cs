using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask12_3
{
    internal class PolishInvertor
    {
        public string InputExpr { get; private set; }
        public string PostfixExpr { get; private set; }
        private Dictionary<char, int> _operationPriorityDict;
        public PolishInvertor(string inputExpr)
        {
            InputExpr = inputExpr;
            _operationPriorityDict = new Dictionary<char, int>()
            {
                {'(',0 },
                {'+',1 },
                {'-',1 },
                {'*',2 },
                {'/',2 },
                {'^',3 },
                {'s',3 },
                { 'c',3}
            };
            PostfixExpr = GetPostfixExpr(inputExpr);
        }
        public Dictionary<char, int> GetOperatorPriorityDict()
        {
            return _operationPriorityDict;
        }
        public string ReadNumber(string expr, ref int pointer)
        {
            string num = string.Empty;
            for (; pointer < expr.Length; pointer++)
            {
                char c = expr[pointer];
                if (char.IsDigit(c) || c == '.')
                    num += c;
                else
                {
                    pointer--;
                    break;
                }
            }
            return num;
        }
        public string GetPostfixExpr(string expr)
        {
            string postfixExpr = string.Empty;
            Stack<char> operators = new Stack<char>();
            for (int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];
                if (char.IsDigit(c))
                {
                    postfixExpr += ReadNumber(expr, ref i) + " ";
                }
                else if (c == '(')
                {
                    operators.Push(c);
                }
                else if (c == ')')
                {
                    while (operators.Count > 0 && operators.Peek() != '(')
                        postfixExpr += operators.Pop();
                    operators.Pop();
                    if (operators.Peek() == 's')
                    {
                        postfixExpr += "sin";
                        operators.Pop();
                    }
                    if (operators.Peek() == 'c')
                    {
                        postfixExpr += "cos";
                        operators.Pop();
                    }
                }
                else if (_operationPriorityDict.ContainsKey(c))
                {
                    char op = c;
                    if ((c == 'c' && expr[++i] == 'o' && expr[++i] == 's') || (c == 's' && expr[++i] == 'i' && expr[++i] == 'n'))
                    {
                        operators.Push(op);
                        continue;
                    }
                    while (operators.Count > 0 && (_operationPriorityDict[operators.Peek()] >= _operationPriorityDict[op]))
                        postfixExpr += operators.Pop();
                    operators.Push(op);
                }
            }
            foreach (char op in operators)
                postfixExpr += op;
            return postfixExpr;
        }
    }
}
