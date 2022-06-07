using NCalc2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculator.CalculatorStatus;

namespace Calculator
{
    public class EqualHandler : ButtonEventHandler
    {
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

        public override CalculatorConfig AddEqual(CalculatorConfig CalculatorConfig, string Equal)
        {
            return NoAction(CalculatorConfig);
        }

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

        public override CalculatorConfig CE(CalculatorConfig CalculatorConfig, string CE)
        {
            return C(CalculatorConfig, CE);
        }

        public override CalculatorConfig Del(CalculatorConfig CalculatorConfig, string Del)
        {
            CalculatorConfig.TextOfRichTextBoxPrevious = string.Empty;
            return CalculatorConfig;
        }

        public override CalculatorConfig Negate(CalculatorConfig CalculatorConfig, string Del)
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
