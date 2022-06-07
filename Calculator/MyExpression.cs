using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    
    class MyExpression
    {
        private string Expression;
        private string PreviousOperator;
        private string CurrentOperator;

        private string NULL = "NULL";
        private string ADDMINUS = "PREVIOUSADDMINUS";
        private string MULTIPLYDIVIDE = "PREVIOUSMULTIPLYDIVIDE";

        private Dictionary<string, Dictionary<char, string>> StatusAndCharToAction = new Dictionary<string, Dictionary<char, string>>
        {
            { "NULL", new Dictionary<char, string>
                {
                    {'0', "AddDigit"},
                    {'1', "AddDigit"},
                    {'2', "AddDigit"},
                    {'3', "AddDigit"},
                    {'4', "AddDigit"},
                    {'5', "AddDigit"},
                    {'6', "AddDigit"},
                    {'7', "AddDigit"},
                    {'8', "AddDigit"},
                    {'9', "AddDigit"},

                }
            },

        };

        private Dictionary<string, string> MultiplyDivideDictionary = new Dictionary<string, string>()
        {
                { "0", "NoAction"},
                { "1", "NoAction"},
                { "2", "NoAction"},
                { "3", "NoAction"},
                { "4", "NoAction"},
                { "5", "NoAction"},
                { "6", "NoAction"},
                { "7", "NoAction"},
                { "8", "NoAction"},
                { "9", "NoAction"},
                { "+", "NoAction"},
                { "-", "NoAction"},
                { "×", "MultiplyDivide"},
                { "÷", "MultiplyDivide"}
        };
        
        private Dictionary<string, string> AddMinusDictionary = new Dictionary<string, string>()
        {
                { "0", "NoAction"},
                { "1", "NoAction"},
                { "2", "NoAction"},
                { "3", "NoAction"},
                { "4", "NoAction"},
                { "5", "NoAction"},
                { "6", "NoAction"},
                { "7", "NoAction"},
                { "8", "NoAction"},
                { "9", "NoAction"},
                { "+", "AddMinus"},
                { "-", "AddMinus"},
                { "×", "NoAction"},
                { "÷", "NoAction"}
        };

        public MyExpression(string Expression)
        {
            this.Expression = Expression;
        }

        public Dictionary<string, Dictionary<char, string>> StatusAndCharToAction1 { get => StatusAndCharToAction; set => StatusAndCharToAction = value; }


        public double Evaluate()
        {
            //string[] Operands = this.Expression.Split(new char[] { '+', '-', '×' , '÷' });
            string[] Operands = this.Expression.Split(new string[] { " + ", " - ", " × ", " ÷ "}, StringSplitOptions.RemoveEmptyEntries);
            foreach(string Operand in Operands)
            {

            }
            return 0;
        }

        public void AddDigit(string Digit)
        {

        }
    }
}
