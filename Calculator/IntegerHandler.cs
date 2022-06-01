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
        }

        /// <summary>
        /// 在輸入數字模式下將輸入的數字更新道數字上
        /// </summary>
        /// <param name="Digit">所輸入的數字</param>
        public override Dictionary<string, string> AddDigit(string Digit)
        {
            return ButtonEventHandlerResultGenerator(this.Calculator.RichTextBoxPrevious.Text, int.Parse(this.Calculator.RichTextBoxCurrent.Text + Digit).ToString(), CalculatorStatus.INTEGER);
        }
        
        /// <summary>
        /// 在輸入數字模式下按下小數點後將模式切換到浮點數輸入
        /// </summary>
        /// <param name="Dot">小數點</param>
        public override Dictionary<string, string> AddDot(string Dot)
        {
            return ButtonEventHandlerResultGenerator(this.Calculator.RichTextBoxPrevious.Text, this.Calculator.RichTextBoxCurrent.Text + Dot, CalculatorStatus.FLOAT);
        }
    }
}
