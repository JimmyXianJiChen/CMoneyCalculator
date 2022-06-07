using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// 負責處理正在/剛輸入完一個數字(且已輸入小數點)浮點數狀態下的處理器
    /// </summary>
    public class FloatHandler : DigitHandler
    {
        /// <summary>
        /// 在輸入浮點數模式下將輸入的數字更新到數字上
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Digit">所輸入的數字</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig AddDigit(CalculatorConfig CalculatorConfig, string Digit)
        {
            CalculatorConfig.TextOfRichTextBoxCurrent += Digit;
            return CalculatorConfig;
        }

        /// <summary>
        /// 在輸入浮點數模式下按下小數點，不做任何動作
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Dot">小數點</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig AddDot(CalculatorConfig CalculatorConfig, string Dot)
        {
            return CalculatorConfig;
        }
    }
}
