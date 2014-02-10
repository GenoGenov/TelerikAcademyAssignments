//* Write a program that calculates the value of given arithmetical expression. 

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07.Calculator
{
    class Calc
    {
        static char[] miniTokens = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-' };
        static string[] functions = { "pow", "sqrt", "ln" };
        static string[] operators = { "+", "-", "*", "/" };
        static string GetMiniToken(ref int index, string str, ref List<string> tokens)
        {
            StringBuilder re = new StringBuilder();

            while (index < str.Length && miniTokens.Contains(str[index]))
            {
                if (str[index] == '-')
                {

                    if (re.Length != 0)
                    {
                        break;
                    }
                    else if (tokens.Count != 0 && !operators.Contains(tokens[tokens.Count - 1]) && tokens[tokens.Count - 1] != ",")
                    {
                        tokens.Add("-");
                        index++;
                        continue;
                    }
                }
                re.Append(str[index]);
                index++;
            }
            return re.ToString();
        }
        public static List<string> GetTokens(string str)
        {
            List<string> result = new List<string>();
            int a;
            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '(': result.Add("("); break;
                    case ')': result.Add(")"); break;
                    case '+': result.Add("+"); break;
                    case '-': if (str[i + 1] == ' ') { result.Add("-"); } break;
                    case '*': result.Add("*"); break;
                    case '/': result.Add("/"); break;
                    case ',': result.Add(","); break;
                    case 'p': result.Add("pow"); i += 2; break;
                    case 'l': result.Add("ln"); i++; break;
                    case 's': result.Add("sqrt"); i += 3; break;
                }
                if (int.TryParse(str[i].ToString(), out a) || (str[i] == '-' && int.TryParse(str[i + 1].ToString(), out a)))
                {
                    result.Add(GetMiniToken(ref i, str, ref result));
                    i--;
                }
            }
            return result;
        }

        public static int Priorities(string op)
        {
            if (op == "*" || op == "/")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static Queue<string> ToRPN(List<string> str)
        {
            Stack<string> func = new Stack<string>();
            Queue<string> nums = new Queue<string>();
            decimal num;
            for (int i = 0; i < str.Count; i++)
            {
                if (decimal.TryParse(str[i].ToString(), out num))
                {
                    nums.Enqueue(str[i]);
                }
                else if (functions.Contains(str[i]))
                {
                    func.Push(str[i]);
                }
                else if (str[i] == ",")
                {
                    while (func.Peek() != "(")
                    {
                        nums.Enqueue(func.Pop());
                    }
                }
                else if (operators.Contains(str[i]))
                {
                    while (func.Count != 0 && operators.Contains(func.Peek()) && Priorities(str[i]) <= Priorities(func.Peek()))
                    {
                        nums.Enqueue(func.Pop());
                    }
                    func.Push(str[i]);
                }

                else if (str[i] == "(")
                {
                    func.Push("(");
                }
                else if (str[i] == ")")
                {
                    while (func.Peek() != "(")
                    {
                        nums.Enqueue(func.Pop());
                    }
                    func.Pop();

                    if (func.Count != 0 && functions.Contains(func.Peek()))
                    {
                        nums.Enqueue(func.Pop());
                    }
                }
            }

            while (func.Count != 0)
            {
                nums.Enqueue(func.Pop());
            }

            return nums;
        }

        public static decimal ShuntingYard(Queue<string> RPN)
        {
            Stack<decimal> stack = new Stack<decimal>();

            decimal num;

            while (RPN.Count != 0)
            {
                string token = RPN.Dequeue();
                if (decimal.TryParse(token, out num))
                {
                    stack.Push(num);
                }
                else if (operators.Contains(token) || functions.Contains(token))
                {

                    switch (token)
                    {
                        case "+": { decimal first = stack.Pop(); decimal second = stack.Pop(); stack.Push(first + second); } break;
                        case "-": { decimal first = stack.Pop(); decimal second = stack.Pop(); stack.Push(second - first); } break;
                        case "*": { decimal first = stack.Pop(); decimal second = stack.Pop(); stack.Push(second * first); } break;
                        case "/": { decimal first = stack.Pop(); decimal second = stack.Pop(); stack.Push(second / first); } break;
                        case "pow": { decimal first = stack.Pop(); decimal second = stack.Pop(); stack.Push((decimal)Math.Pow((double)second, (double)first)); } break;
                        case "sqrt": { decimal first = stack.Pop(); stack.Push((decimal)Math.Sqrt((double)first)); } break;
                        case "ln": { decimal first = stack.Pop(); stack.Push((decimal)Math.Log((double)first)); } break;

                    }
                }
            }
            if (stack.Count != 1)
            {
                throw new ArgumentException();
            }
            return stack.Pop();
        }
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            try
            {
                string inp = Console.ReadLine();
                List<string> tokens = GetTokens(inp);
                Queue<string> RPN = ToRPN(tokens);
                Console.WriteLine("The result is:\n{0}", ShuntingYard(RPN));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid expression string!");
            }

        }
    }
}