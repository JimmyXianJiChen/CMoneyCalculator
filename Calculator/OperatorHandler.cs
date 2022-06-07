using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// 負責處理剛輸入完運算元的狀態下按鈕事件的處理器
    /// </summary>
    public class OperatorHandler : NonEqualHandler
    {
        /// <summary>
        /// 按下新數字後將輸入值更新乘所輸入的新數值
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Digit">數字</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig AddDigit(CalculatorConfig CalculatorConfig, string Digit)
        {
            CalculatorConfig.TextOfRichTextBoxCurrent = Digit;
            CalculatorConfig.Status = CalculatorStatus.INTEGER;
            return CalculatorConfig;
        }

        /// <summary>
        /// 按下小數點後將輸入值更新乘預設浮點數值
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Dot">小數點</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig AddDot(CalculatorConfig CalculatorConfig, string Dot)
        {
            CalculatorConfig.TextOfRichTextBoxCurrent = Calculator.DefaultFloat;
            CalculatorConfig.Status = CalculatorStatus.INTEGER;
            return CalculatorConfig;
        }

        /// <summary>
        /// 替換掉原本輸入的運算元
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Operator">運算元</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig AddOperator(CalculatorConfig CalculatorConfig, string Operator)
        {
            CalculatorConfig.CurrentOperator = Operator;
            CalculatorConfig.TextOfRichTextBoxPrevious = CalculatorConfig.TextOfRichTextBoxPrevious.Remove(CalculatorConfig.TextOfRichTextBoxPrevious.Length - 1) + Operator;
            return CalculatorConfig;
        }

        /// <summary>
        /// 不做任何動作
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Del">Del</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig Del(CalculatorConfig CalculatorConfig, string Del)
        {
            return CalculatorConfig;
        }
    }
}
