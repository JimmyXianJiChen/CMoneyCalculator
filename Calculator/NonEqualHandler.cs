using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc2;

namespace Calculator
{
    public abstract class NonEqualHandler : ButtonEventHandler
    {
        public List<string> ininin = new List<string>();

        public Dictionary<string, string> OperatorToAction = new Dictionary<string, string>
        {
            { "+", "ADD"},
            { "-", "MINUS"},
            { "×", "MULTIPLY"},
            { "÷", "DIVIDE"}
        };

        public string ADD(string A, string B)
        {
            ininin.Add("ADD");
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

        public string CalculatePrevious()
        {
            ininin.Add("Cal prev");
            return typeof(NonEqualHandler).GetMethod(OperatorToAction[Calculator.PreviousOperator]).Invoke(this, new[] { Calculator.PreviousValue, Calculator.CurrentValue }).ToString();
        }

        public string CalculateCurrent()
        {
            ininin.Add("Cal cur");
            var aa = Calculator.CurrentValue;
            var ab = this.Calculator.RichTextBoxCurrent.Text;
            var ac = OperatorToAction[Calculator.CurrentOperator];
            var ad = ADD(Calculator.CurrentValue, this.Calculator.RichTextBoxCurrent.Text);
            return typeof(NonEqualHandler).GetMethod(OperatorToAction[Calculator.CurrentOperator]).Invoke(this, new[] { Calculator.CurrentValue, this.Calculator.RichTextBoxCurrent.Text }).ToString();
        }

        public string GetCurrentText()
        {
            return this.Calculator.RichTextBoxCurrent.Text;
        }



        public void PREVIOUSADDMINUS(string Operator)
        {
            Calculator.CurrentValue = CalculateCurrent();
            Calculator.CurrentOperator = Operator;
        }

        public void PREVIOUSMULTIPLYDIVIDE(string Operator)
        {
            Calculator.PreviousValue = CalculatePrevious();
            Calculator.PreviousOperator = Calculator.CurrentOperator;
            Calculator.CurrentValue = Calculator.RichTextBoxCurrent.Text;
            Calculator.CurrentOperator = Operator;
        }


        public string CalculatePreviousFirst()
        {
            return typeof(NonEqualHandler).GetMethod(OperatorToAction[Calculator.CurrentOperator]).Invoke(this, new[] { CalculatePrevious(), this.Calculator.RichTextBoxCurrent.Text }).ToString();
        }

        public string CalculateCurrentFirst()
        {
            return typeof(NonEqualHandler).GetMethod(OperatorToAction[Calculator.PreviousOperator]).Invoke(this, new[] { Calculator.PreviousValue, CalculateCurrent() }).ToString();
        }





        public Dictionary<string, string> CalculateLastTwoInstructions = new Dictionary<string, string>
        {
            { "NULL", "GetCurrentText"},
            { "+", "CalculateCurrent"},
            { "-", "CalculateCurrent"},
            { "×", "CalculateCurrent"},
            { "÷", "CalculateCurrent"}
        };

        public string CalculateLastTwo()
        {
            ininin.Add("last two");
            return typeof(NonEqualHandler).GetMethod(CalculateLastTwoInstructions[Calculator.CurrentOperator]).Invoke(this, null).ToString();
        }

        public Dictionary<string, string> CalculateAllThreeInstructions = new Dictionary<string, string>
        {
            { "+", "CalculateCurrentFirst"},
            { "-", "CalculateCurrentFirst"},
            { "×", "CalculatePreviousFirst"},
            { "÷", "CalculatePreviousFirst"},
        };

        public string CalculateAllThree()
        {
            ininin.Add("three");
            return typeof(NonEqualHandler).GetMethod(CalculateAllThreeInstructions[Calculator.PreviousOperator]).Invoke(this, null).ToString();
        }

        public Dictionary<string, string> CalculateFinalValueInstruction = new Dictionary<string, string>
        {
            { "NULL", "CalculateLastTwo"},
            { "+", "CalculateAllThree"},
            { "-", "CalculateAllThree"},
            { "×", "CalculateAllThree"},
            { "÷", "CalculateAllThree"}
        };



        public string CalculateFinalValue()
        {
            ininin.Add("Cal Final Val");
            return typeof(NonEqualHandler).GetMethod(CalculateFinalValueInstruction[Calculator.PreviousOperator]).Invoke(this, null).ToString();
        }


        public NonEqualHandler(Calculator Calculator) : base(Calculator)
        {
            
        }

        /// <summary>
        /// 當按下等號時去計算結果並將運算式以及結果顯示在畫面中，並將狀態切換到剛輸入等號
        /// </summary>
        /// <param name="Operator">輸入的運算元</param>
        public override Dictionary< string, string> AddEqual(string Operator)
        {
            ininin.Add("AddEqual");
            //TEST
            string ans = CalculateFinalValue();
            Calculator.PreviousValue = "NULL";
            Calculator.CurrentValue = "NULL";
            Calculator.PreviousOperator = "NULL";
            Calculator.CurrentOperator = "NULL";
            

            string Expression = this.Calculator.RichTextBoxPrevious.Text + this.Calculator.RichTextBoxCurrent.Text + "=";
            string Result = new Expression((this.Calculator.RichTextBoxPrevious.Text + this.Calculator.RichTextBoxCurrent.Text).Replace('÷', '/').Replace('×', '*')).Evaluate().ToString();
            return ButtonEventHandlerResultGenerator(Expression, Result + "??" + ans, CalculatorStatus.EQUAL);
        }

        /// <summary>
        /// 清除目前輸入的數字
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public override Dictionary<string, string> CE(string str)
        {
            return ButtonEventHandlerResultGenerator(this.Calculator.RichTextBoxPrevious.Text, Calculator.DefaultInteger, CalculatorStatus.INTEGER);
        }

        /// <summary>
        /// 將數字轉換正負值
        /// </summary>
        /// <param name="str">Botton.Text</param>
        public override Dictionary<string, string> Negate(string str)
        {
            return ButtonEventHandlerResultGenerator(this.Calculator.RichTextBoxPrevious.Text, (double.Parse(this.Calculator.RichTextBoxCurrent.Text) * -1).ToString(), this.Calculator.Status);
        }
    }
}
