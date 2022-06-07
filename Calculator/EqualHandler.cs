using NCalc2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculator.CalculatorStatus;

namespace Calculator
{
    /// <summary>
    /// 負責處理在剛輸入等號的情況下按鈕觸發事件的處理器
    /// </summary>
    public class EqualHandler : ButtonEventHandler
    {
        /// <summary>
        /// 將輸入的數字更新到數字上取代原有運算結果
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Digit">所輸入的數字</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig AddDigit(CalculatorConfig CalculatorConfig, string Digit)
        {
            return new CalculatorConfig(string.Empty,
                                        Digit,
                                        CalculatorStatus.INTEGER,
                                        Calculator.DefaultValue,
                                        Calculator.DefaultValue,
                                        Calculator.DefaultOperator,
                                        Calculator.DefaultOperator
                             );
        }

        /// <summary>
        /// 按下小數點後將模式切換到浮點數輸入並將輸入數字設成預設浮點數值
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Dot">小數點</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig AddDot(CalculatorConfig CalculatorConfig, string Dot)
        {
            return new CalculatorConfig(string.Empty,
                                    Calculator.DefaultFloat,
                                    CalculatorStatus.FLOAT,
                                    Calculator.DefaultValue,
                                    Calculator.DefaultValue,
                                    Calculator.DefaultOperator,
                                    Calculator.DefaultOperator
                            );
        }

        /// <summary>
        /// 當按下等號時去計算結果並將運算式以及結果顯示在畫面中，並將狀態切換到剛輸入等號
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Equal">等號</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig AddEqual(CalculatorConfig CalculatorConfig, string Equal)
        {
            return NoAction(CalculatorConfig);
        }

        /// <summary>
        /// 加入運算元
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Operator">運算元</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig AddOperator(CalculatorConfig CalculatorConfig, string Operator)
        {
            return new CalculatorConfig(CalculatorConfig.TextOfRichTextBoxCurrent + Operator,
                        CalculatorConfig.TextOfRichTextBoxCurrent,
                        CalculatorStatus.OPERATOR,
                        Calculator.DefaultValue,
                        CalculatorConfig.TextOfRichTextBoxCurrent,
                        Calculator.DefaultOperator,
                        Operator
                );
        }

        /// <summary>
        /// 將所有紀錄都清空的函式
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="CE">CE</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig CE(CalculatorConfig CalculatorConfig, string CE)
        {
            return C(CalculatorConfig, CE);
        }

        /// <summary>
        /// 將先前運算式清空
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Del">Del</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig Del(CalculatorConfig CalculatorConfig, string Del)
        {
            CalculatorConfig.TextOfRichTextBoxPrevious = string.Empty;
            return CalculatorConfig;
        }

        /// <summary>
        /// 將數字轉換正負值
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="str">Botton.Text</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig Negate(CalculatorConfig CalculatorConfig, string str)
        {
            CalculatorConfig.TextOfRichTextBoxPrevious = string.Empty;
            try
            {
                CalculatorConfig.TextOfRichTextBoxCurrent = (int.Parse(CalculatorConfig.TextOfRichTextBoxCurrent) * -1).ToString();
                CalculatorConfig.Status = CalculatorStatus.INTEGER;
            }
            catch
            {
                CalculatorConfig.TextOfRichTextBoxCurrent = (double.Parse(CalculatorConfig.TextOfRichTextBoxCurrent) * -1).ToString();
                CalculatorConfig.Status = CalculatorStatus.FLOAT;
            }
            return CalculatorConfig;
        }

        /// <summary>
        /// 將所輸入的數字開根號
        /// </summary>
        /// <param name="CalculatorConfig">Calculator現在的狀態</param>
        /// <param name="Root">Root</param>
        /// <returns></returns>
        /// 
        public override CalculatorConfig Root(CalculatorConfig CalculatorConfig, string Root)
        {
            string root = Math.Sqrt(double.Parse(CalculatorConfig.TextOfRichTextBoxCurrent)).ToString();
            try
            {
                CalculatorConfig.TextOfRichTextBoxCurrent = int.Parse(root).ToString();
                CalculatorConfig.Status = CalculatorStatus.INTEGER;
            }
            catch
            {
                CalculatorConfig.TextOfRichTextBoxCurrent = double.Parse(root).ToString();
                CalculatorConfig.Status = CalculatorStatus.FLOAT;
            }
            CalculatorConfig.TextOfRichTextBoxPrevious = string.Empty;
            return CalculatorConfig;
        }
    }
}
