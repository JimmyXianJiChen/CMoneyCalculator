using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc2;

namespace Calculator
{
    /// <summary>
    /// 在非剛輸入等號狀態下的處理器的父類
    /// </summary>
    public abstract class NonEqualHandler : ButtonEventHandler
    {
        /// <summary>
        /// 協助對以字串形式表達的數字做運算的工具
        /// </summary>
        private readonly StringCalculationHelper StringCalculationHelper;

        /// <summary>
        /// 建構子
        /// </summary>
        public NonEqualHandler()
        {
            this.StringCalculationHelper = new StringCalculationHelper();
        }

        /// <summary>
        /// 計算前兩個運算子的部分的值
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <returns>計算結果</returns>
        public string CalculatePrevious(CalculatorConfig CalculatorConfig)
        {
            return StringCalculationHelper.Calculate(CalculatorConfig.PreviousValue, CalculatorConfig.PreviousOperator, CalculatorConfig.CurrentValue);
        }

        /// <summary>
        /// 計算後兩個運算子的部分的值
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <returns>計算結果</returns>
        public string CalculateCurrent(CalculatorConfig CalculatorConfig)
        {
            return StringCalculationHelper.Calculate(CalculatorConfig.CurrentValue, CalculatorConfig.CurrentOperator, CalculatorConfig.TextOfRichTextBoxCurrent);
        }

        /// <summary>
        /// 拿取目前RichTextBoxCurrent中的文字
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <returns>計算結果</returns>
        public string GetCurrentText(CalculatorConfig CalculatorConfig)
        {
            return CalculatorConfig.TextOfRichTextBoxCurrent;
        }

        /// <summary>
        /// 紀錄先運算前兩個運算子的函
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <returns>計算結果</returns>
        public string CalculatePreviousFirst(CalculatorConfig CalculatorConfig)
        {
            return StringCalculationHelper.Calculate(CalculatePrevious(CalculatorConfig), CalculatorConfig.CurrentOperator, CalculatorConfig.TextOfRichTextBoxCurrent);
        }

        /// <summary>
        /// 紀錄先運算後兩個運算子的函
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <returns>計算結果</returns>
        public string CalculateCurrentFirst(CalculatorConfig CalculatorConfig)
        {
            return StringCalculationHelper.Calculate(CalculatorConfig.PreviousValue, CalculatorConfig.PreviousOperator, CalculateCurrent(CalculatorConfig));
        }

        /// <summary>
        /// 紀錄在運算兩個運算子兩個運算元的情況下依照先乘除後加減原則該計算的方式的字典
        /// </summary>
        private readonly Dictionary<string, string> CalculateLastTwoInstructions = new Dictionary<string, string>
        {
            { "NULL", "GetCurrentText"},
            { "+", "CalculateCurrent"},
            { "-", "CalculateCurrent"},
            { "×", "CalculateCurrent"},
            { "÷", "CalculateCurrent"}
        };

        /// <summary>
        /// 當運算系統中有運算元是NULL時計算總值的方法
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <returns>計算結果</returns>
        public string CalculateLastTwo(CalculatorConfig CalculatorConfig)
        {
            return typeof(NonEqualHandler).GetMethod(CalculateLastTwoInstructions[CalculatorConfig.CurrentOperator]).Invoke(this, new[] { CalculatorConfig }).ToString();
        }

        /// <summary>
        /// 紀錄在運算三個運算子兩個運算元的情況下依照先乘除後加減原則該計算的方式的字典
        /// </summary>
        private readonly Dictionary<string, string> CalculateAllThreeInstructions = new Dictionary<string, string>
        {
            { "+", "CalculateCurrentFirst"},
            { "-", "CalculateCurrentFirst"},
            { "×", "CalculatePreviousFirst"},
            { "÷", "CalculatePreviousFirst"},
        };

        /// <summary>
        /// 當三個運算元都不是空的時候計算最終值的函式
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <returns>計算結果</returns>
        public string CalculateAllThree(CalculatorConfig CalculatorConfig)
        {
            return typeof(NonEqualHandler).GetMethod(CalculateAllThreeInstructions[CalculatorConfig.PreviousOperator]).Invoke(this, new[] { CalculatorConfig }).ToString();
        }

        /// <summary>
        /// 紀錄在計算最終值時不同情況下該執行的指令的字典
        /// </summary>
        private readonly Dictionary<string, string> CalculateFinalValueInstruction = new Dictionary<string, string>
        {
            { "NULL", "CalculateLastTwo"},
            { "+", "CalculateAllThree"},
            { "-", "CalculateAllThree"},
            { "×", "CalculateAllThree"},
            { "÷", "CalculateAllThree"}
        };

        /// <summary>
        /// 計算運算式最終值的函示
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <returns>計算結果</returns>
        public string CalculateFinalValue(CalculatorConfig CalculatorConfig)
        {
            return typeof(NonEqualHandler).GetMethod(CalculateFinalValueInstruction[CalculatorConfig.PreviousOperator]).Invoke(this, new[] { CalculatorConfig }).ToString();
        }

        /// <summary>
        /// 當按下等號時去計算結果並將運算式以及結果顯示在畫面中，並將狀態切換到剛輸入等號
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Operator">輸入的運算元</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig AddEqual(CalculatorConfig CalculatorConfig, string Operator)
        {
            string ans = CalculateFinalValue(CalculatorConfig);
            CalculatorConfig.PreviousValue = Calculator.DefaultValue;
            CalculatorConfig.CurrentValue = Calculator.DefaultValue;
            CalculatorConfig.PreviousOperator = Calculator.DefaultOperator;
            CalculatorConfig.CurrentOperator = Calculator.DefaultOperator;

            CalculatorConfig.TextOfRichTextBoxPrevious = CalculatorConfig.TextOfRichTextBoxPrevious + CalculatorConfig.TextOfRichTextBoxCurrent + "=";
            CalculatorConfig.TextOfRichTextBoxCurrent = ans;
            CalculatorConfig.Status = CalculatorStatus.EQUAL;
            return CalculatorConfig;
        }

        /// <summary>
        /// 清除目前輸入的數字
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="str">按鍵的符號</param>
        /// <returns>完成動作後Calculator的狀態</returns>
        public override CalculatorConfig CE(CalculatorConfig CalculatorConfig, string str)
        {
            CalculatorConfig.TextOfRichTextBoxCurrent = Calculator.DefaultInteger;
            CalculatorConfig.Status = CalculatorStatus.INTEGER;
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
            CalculatorConfig.TextOfRichTextBoxCurrent = (double.Parse(CalculatorConfig.TextOfRichTextBoxCurrent) * -1).ToString();
            return CalculatorConfig;
        }

        /// <summary>
        /// 將所輸入的數字開根號
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        /// <param name="Root">Root</param>
        /// <returns>完成動作後Calculator的狀態</returns>
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
            return CalculatorConfig;
        }
    }
}
