using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex
{
    internal class Program
    {
        public void Calculator()
        {
            Console.WriteLine("Please enter your mathematical expression: ");
            string input = Console.ReadLine();
            List<string> subExpression = new List<string>();
            var expression = input.ToList();
            List<string> stringExpr = new List<string>();
            var number = "";
            for (int i = 0; i < expression.Count; i++)
            {
                if(Char.IsDigit(expression[i]))
                {
                    number += expression[i].ToString();
                }
                else
                {
                    stringExpr.Add(number);
                    stringExpr.Add(expression[i].ToString());
                    number = "";
                }

                if (i == expression.Count - 1) stringExpr.Add(number);
                
            }
            List<string> operators = new List<string>() { "*", "/", "+", "-" };
            foreach (string s in operators)
            {
                while (stringExpr.Contains(s))
                {
                    int p = stringExpr.IndexOf(s);

                    subExpression = new List<string>(stringExpr.GetRange(0, p - 1));
                    double leftValue = double.Parse(stringExpr[p - 1]);
                    double rightValue = double.Parse(stringExpr[p + 1]);

                    if (s == "*")
                    {
                        double multiplicationResult = leftValue * rightValue;
                        subExpression.Add(multiplicationResult.ToString());
                    }
                    else if (s == "/")
                    {
                        double divisionResult = leftValue / rightValue;
                        subExpression.Add(divisionResult.ToString());
                    }
                    else if (s == "+")
                    {
                        double sumResult = leftValue + rightValue;
                        subExpression.Add(sumResult.ToString());
                    }
                    else if (s == "-")
                    {
                        double reduceResult = leftValue - rightValue;
                        subExpression.Add(reduceResult.ToString());
                    }
                    subExpression.AddRange(stringExpr.GetRange(p + 2, stringExpr.Count - (p + 2)));

                    stringExpr = subExpression;
                }
            }
            Console.WriteLine($"Result: {stringExpr[0]}");
        }

        static void Main(string[] args)
        {
            var c = new Program();
            c.Calculator();
        }
    }
}
