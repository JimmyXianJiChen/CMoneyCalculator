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
        private readonly StringCalculationHelper StringCalculationHelper;

        public NonEqualHandler()
        {
            this.StringCalculationHelper = new StringCalculationHelper();
        }

        public string CalculatePrevious(CalculatorConfig CalculatorConfig)
        {
            return StringCalculationHelper.Calculate(CalculatorConfig.PreviousValue, CalculatorConfig.PreviousOperator, CalculatorConfig.CurrentValue);
        }

        public string CalculateCurrent(CalculatorConfig CalculatorConfig)
        {
            return StringCalculationHelper.Calculate(CalculatorConfig.CurrentValue, CalculatorConfig.CurrentOperator, CalculatorConfig.TextOfRichTextBoxCurrent);
        }

        public string GetCurrentText(CalculatorConfig CalculatorConfig)
        {
            return CalculatorConfig.TextOfRichTextBoxCurrent;
        }


        public string CalculatePreviousFirst(CalculatorConfig CalculatorConfig)
        {
            return StringCalculationHelper.Calculate(CalculatePrevious(CalculatorConfig), CalculatorConfig.CurrentOperator, CalculatorConfig.TextOfRichTextBoxCurrent);
        }

        public string CalculateCurrentFirst(CalculatorConfig CalculatorConfig)
        {
            return StringCalculationHelper.Calculate(CalculatorConfig.PreviousValue, CalculatorConfig.PreviousOperator, CalculateCurrent(CalculatorConfig));
        }

        public Dictionary<string, string> CalculateLastTwoInstructions = new Dictionary<string, string>
        {
            { "NULL", "GetCurrentText"},
            { "+", "CalculateCurrent"},
            { "-", "CalculateCurrent"},
            { "×", "CalculateCurrent"},
            { "÷", "CalculateCurrent"}
        };

        public string CalculateLastTwo(CalculatorConfig CalculatorConfig)
        {
            return typeof(NonEqualHandler).GetMethod(CalculateLastTwoInstructions[CalculatorConfig.CurrentOperator]).Invoke(this, new[] { CalculatorConfig }).ToString();
        }

        public Dictionary<string, string> CalculateAllThreeInstructions = new Dictionary<string, string>
        {
            { "+", "CalculateCurrentFirst"},
            { "-", "CalculateCurrentFirst"},
            { "×", "CalculatePreviousFirst"},
            { "÷", "CalculatePreviousFirst"},
        };

        public string CalculateAllThree(CalculatorConfig CalculatorConfig)
        {
            return typeof(NonEqualHandler).GetMethod(CalculateAllThreeInstructions[CalculatorConfig.PreviousOperator]).Invoke(this, new[] { CalculatorConfig }).ToString();
        }

        public Dictionary<string, string> CalculateFinalValueInstruction = new Dictionary<string, string>
        {
            { "NULL", "CalculateLastTwo"},
            { "+", "CalculateAllThree"},
            { "-", "CalculateAllThree"},
            { "×", "CalculateAllThree"},
            { "÷", "CalculateAllThree"}
        };

        public string CalculateFinalValue(CalculatorConfig CalculatorConfig)
        {
            return typeof(NonEqualHandler).GetMethod(CalculateFinalValueInstruction[CalculatorConfig.PreviousOperator]).Invoke(this, new[] { CalculatorConfig }).ToString();
        }


        /// <summary>
        /// 當按下等號時去計算結果並將運算式以及結果顯示在畫面中，並將狀態切換到剛輸入等號
        /// </summary>
        /// <param name="Operator">輸入的運算元</param>
        public override CalculatorConfig AddEqual(CalculatorConfig CalculatorConfig, string Operator)
        {
            //TEST
            string ans = CalculateFinalValue(CalculatorConfig);
            CalculatorConfig.PreviousValue = Calculator.DefaultValue;
            CalculatorConfig.CurrentValue = Calculator.DefaultValue;
            CalculatorConfig.PreviousOperator = Calculator.DefaultOperator;
            CalculatorConfig.CurrentOperator = Calculator.DefaultOperator;


            //string Expression = CalculatorConfig.TextOfRichTextBoxPrevious + CalculatorConfig.TextOfRichTextBoxCurrent + "=";
            //string Result = new Expression((TextOfRichTextBoxPrevious + TextOfRichTextBoxCurrent).Replace('÷', '/').Replace('×', '*')).Evaluate().ToString();
            //return ButtonEventHandlerResultGenerator(Expression, Result, CalculatorStatus.EQUAL);
            CalculatorConfig.TextOfRichTextBoxPrevious = CalculatorConfig.TextOfRichTextBoxPrevious + CalculatorConfig.TextOfRichTextBoxCurrent + "=";
            CalculatorConfig.TextOfRichTextBoxCurrent = ans;
            CalculatorConfig.Status = CalculatorStatus.EQUAL;
            return CalculatorConfig;
        }

        /// <summary>
        /// 清除目前輸入的數字
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public override CalculatorConfig CE(CalculatorConfig CalculatorConfig, string str)
        {
            CalculatorConfig.TextOfRichTextBoxCurrent = Calculator.DefaultInteger;
            CalculatorConfig.Status = CalculatorStatus.INTEGER;
            return CalculatorConfig;
        }

        /// <summary>
        /// 將數字轉換正負值
        /// </summary>
        /// <param name="str">Botton.Text</param>
        public override CalculatorConfig Negate(CalculatorConfig CalculatorConfig, string str)
        {
            CalculatorConfig.TextOfRichTextBoxCurrent = (double.Parse(CalculatorConfig.TextOfRichTextBoxCurrent) * -1).ToString();
            return CalculatorConfig;
        }

        /// <summary>
        /// 將所輸入的數字開根號
        /// </summary>
        /// <param name="CalculatorConfig">Calculator現在的狀態</param>
        /// <param name="Root">Root</param>
        /// <returns></returns>
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
