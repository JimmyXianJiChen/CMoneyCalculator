using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class IntegerHandler : DigitHandler
    {
        /// <summary>
        /// 在輸入數字模式下將輸入的數字更新道數字上
        /// </summary>
        /// <param name="Digit">所輸入的數字</param>
        public override CalculatorConfig AddDigit(CalculatorConfig CalculatorConfig, string Digit)
        {
            CalculatorConfig.TextOfRichTextBoxCurrent = int.Parse(CalculatorConfig.TextOfRichTextBoxCurrent + Digit).ToString();
            return CalculatorConfig;
        }

        /// <summary>
        /// 在輸入數字模式下按下小數點後將模式切換到浮點數輸入
        /// </summary>
        /// <param name="Dot">小數點</param>
        public override CalculatorConfig AddDot(CalculatorConfig CalculatorConfig, string Dot)
        {
            CalculatorConfig.TextOfRichTextBoxCurrent += Dot;
            CalculatorConfig.Status = CalculatorStatus.FLOAT;
            return CalculatorConfig;
        }
    }
}
