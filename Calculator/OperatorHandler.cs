using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class OperatorHandler : NonEqualHandler
    {
        public override CalculatorConfig AddDigit(CalculatorConfig CalculatorConfig, string Digit)
        {
            CalculatorConfig.TextOfRichTextBoxCurrent = Digit;
            CalculatorConfig.Status = CalculatorStatus.INTEGER;
            return CalculatorConfig;
        }

        public override CalculatorConfig AddDot(CalculatorConfig CalculatorConfig, string Dot)
        {
            CalculatorConfig.TextOfRichTextBoxCurrent = Calculator.DefaultFloat;
            CalculatorConfig.Status = CalculatorStatus.INTEGER;
            return CalculatorConfig;
        }

        public override CalculatorConfig AddOperator(CalculatorConfig CalculatorConfig, string Operator)
        {
            CalculatorConfig.CurrentOperator = Operator;
            CalculatorConfig.TextOfRichTextBoxPrevious = CalculatorConfig.TextOfRichTextBoxPrevious.Remove(CalculatorConfig.TextOfRichTextBoxPrevious.Length - 1) + Operator;
            return CalculatorConfig;
        }

        public override CalculatorConfig Del(CalculatorConfig CalculatorConfig, string Del)
        {
            return CalculatorConfig;
        }
    }
}
