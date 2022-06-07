using NCalc2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// 負責在剛輸入數字的狀態下處理按鈕事件的處理器的父類
    /// </summary>
    public abstract class DigitHandler : NonEqualHandler
    {
        /// <summary>
        /// 計錄依據算系統所記錄的第一個運算元所對應到該執行的函式的字典
        /// </summary>
        private readonly Dictionary<string, string> PreviousOperatorToConfigUpdateMethod = new Dictionary<string, string>
        {
            { "+", "PreviousAddMinusConfigUpdate"},
            { "-", "PreviousAddMinusConfigUpdate"},
            { "×", "PreviousMultiplyDivideConfigUpdate"},
            { "÷", "PreviousMultiplyDivideConfigUpdate"},
            { "NULL", "PreviousNullConfigUpdate" }
        };

        /// <summary>
        /// 當前一個運算元為非NULL且是加或減的時候更新運算系統資料
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Operator">當下的運算元</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public CalculatorConfig PreviousAddMinusConfigUpdate(CalculatorConfig CalculatorConfig, string Operator)
        {
            CalculatorConfig.CurrentValue = CalculateCurrent(CalculatorConfig);
            CalculatorConfig.CurrentOperator = Operator;
            return CalculatorConfig;
        }

        /// <summary>
        /// 當前一個運算元為非NULL且是乘或除的時候更新運算系統資料
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Operator">當下的運算元</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public CalculatorConfig PreviousMultiplyDivideConfigUpdate(CalculatorConfig CalculatorConfig, string Operator)
        {
            CalculatorConfig.PreviousValue = CalculatePrevious(CalculatorConfig);
            CalculatorConfig.CurrentValue = CalculatorConfig.TextOfRichTextBoxCurrent;
            CalculatorConfig.PreviousOperator = CalculatorConfig.CurrentOperator;
            CalculatorConfig.CurrentOperator = Operator;
            return CalculatorConfig;
        }

        /// <summary>
        /// 當前一個運算元是NULL時更新運算系統資料
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Operator">當下的運算元</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public CalculatorConfig PreviousNullConfigUpdate(CalculatorConfig CalculatorConfig, string Operator)
        {
            CalculatorConfig.PreviousOperator = CalculatorConfig.CurrentOperator;
            CalculatorConfig.CurrentOperator = Operator;
            CalculatorConfig.PreviousValue = CalculatorConfig.CurrentValue;
            CalculatorConfig.CurrentValue = CalculatorConfig.TextOfRichTextBoxCurrent;
            return CalculatorConfig;
        }

        /// <summary>
        /// 在輸入數字的情況下加入運算元，並將數字與運算元更新到運算式中
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Operator">運算元</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig AddOperator(CalculatorConfig CalculatorConfig, string Operator)
        {
            string EquationUpToDate = CalculatorConfig.TextOfRichTextBoxPrevious + CalculatorConfig.TextOfRichTextBoxCurrent;
            string ValueUpToDate = CalculateFinalValue(CalculatorConfig);

            string tt = PreviousOperatorToConfigUpdateMethod[CalculatorConfig.PreviousOperator];
            CalculatorConfig = (CalculatorConfig) typeof(DigitHandler).GetMethod(PreviousOperatorToConfigUpdateMethod[CalculatorConfig.PreviousOperator]).Invoke(this, new object[] { CalculatorConfig, Operator });

            CalculatorConfig.TextOfRichTextBoxPrevious = EquationUpToDate + Operator;
            CalculatorConfig.TextOfRichTextBoxCurrent = ValueUpToDate;
            CalculatorConfig.Status = CalculatorStatus.OPERATOR;

            return CalculatorConfig;
        }

        /// <summary>
        /// 刪除現正輸入的數字的一個位數
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Del">Del</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig Del(CalculatorConfig CalculatorConfig, string Del)
        {
            string DeletedString = new Expression(("0" + CalculatorConfig.TextOfRichTextBoxCurrent).Remove(CalculatorConfig.TextOfRichTextBoxCurrent.Length)).Evaluate().ToString();
            CalculatorConfig.TextOfRichTextBoxCurrent = DeletedString;
            try
            {
                int.Parse(DeletedString);
                CalculatorConfig.Status = CalculatorStatus.INTEGER;
            }
            catch
            {
                CalculatorConfig.Status = CalculatorStatus.FLOAT;
            }
            return CalculatorConfig;
        }
    }
}
