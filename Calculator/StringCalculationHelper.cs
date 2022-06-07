using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class StringCalculationHelper
    {
        public Dictionary<string, string> OperatorToAction = new Dictionary<string, string>
        {
            { "+", "ADD"},
            { "-", "MINUS"},
            { "×", "MULTIPLY"},
            { "÷", "DIVIDE"}
        };
        public string ADD(string A, string B)
        {
            return (double.Parse(A) + double.Parse(B)).ToString();
        }
        public string MINUS(string A, string B)
        {
            return (double.Parse(A) - double.Parse(B)).ToString();
        }
        public string MULTIPLY(string A, string B)
        {
            return (double.Parse(A) * double.Parse(B)).ToString();
        }
        public string DIVIDE(string A, string B)
        {
            return (double.Parse(A) / double.Parse(B)).ToString();
        }

        public string Calculate(string Operand1, string Operator, string Operand2)
        {
            return typeof(StringCalculationHelper).GetMethod(OperatorToAction[Operator]).Invoke(this, new[] { Operand1, Operand2 }).ToString();
        }
    }
}
