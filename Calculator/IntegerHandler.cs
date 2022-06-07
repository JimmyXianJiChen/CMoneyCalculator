using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// 負責處理正在/剛輸入完一個數字(且尚未輸入小數點)正整數狀態下的處理器
    /// </summary>
    public class IntegerHandler : DigitHandler
    {
        /// <summary>
        /// 在輸入數字模式下將輸入的數字更新道數字上
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Digit">所輸入的數字</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig AddDigit(CalculatorConfig CalculatorConfig, string Digit)
        {
            CalculatorConfig.TextOfRichTextBoxCurrent = int.Parse(CalculatorConfig.TextOfRichTextBoxCurrent + Digit).ToString();
            return CalculatorConfig;
        }

        /// <summary>
        /// 在輸入數字模式下按下小數點後將模式切換到浮點數輸入
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Dot">小數點</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig AddDot(CalculatorConfig CalculatorConfig, string Dot)
        {
            CalculatorConfig.TextOfRichTextBoxCurrent += Dot;
            CalculatorConfig.Status = CalculatorStatus.FLOAT;
            return CalculatorConfig;
        }
    }
}
