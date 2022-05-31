using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class IntegerHandler : DigitHandler
    {
        public IntegerHandler(Calculator Calculator) : base (Calculator)
        {
            this.ButtonTextToActions = new Dictionary<string, string>()
                    {
                        { "0", "DigitAddDigit"},
                        { "1", "DigitAddDigit"},
                        { "2", "DigitAddDigit"},
                        { "3", "DigitAddDigit"},
                        { "4", "DigitAddDigit"},
                        { "5", "DigitAddDigit"},
                        { "6", "DigitAddDigit"},
                        { "7", "DigitAddDigit"},
                        { "8", "DigitAddDigit"},
                        { "9", "DigitAddDigit"},
                        { ".", "DigitAddDot"},
                        { "+", "AddOperator"},
                        { "-", "AddOperator"},
                        { "×", "AddOperator"},
                        { "÷", "AddOperator"},
                        { "=", "AddEqual"},
                        {"CE", "CE" },
                        {"C", "C" },
                        {"Del", "Del" },
                        {"+/-", "Negate" }
                    };
        }

        /// <summary>
        /// 在輸入數字模式下將輸入的數字更新道數字上
        /// </summary>
        /// <param name="Digit">所輸入的數字</param>
        private string DigitAddDigit(string Digit)
        {
            RichTextBoxCurrent.Text = int.Parse(RichTextBoxCurrent.Text + Digit).ToString();
            return DIGIT;
        }
        
        /// <summary>
        /// 在輸入數字模式下按下小數點後將模式切換到浮點數輸入
        /// </summary>
        /// <param name="Dot">小數點</param>
        private string DigitAddDot(string Dot)
        {
            this.RichTextBoxCurrent.Text += Dot;
            return FLOAT;
        }
    }
}
