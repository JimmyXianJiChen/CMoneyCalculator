using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class FloatHandler : DigitHandler
    {

        public override CalculatorConfig AddDigit(CalculatorConfig CalculatorConfig, string Digit)
        {
            CalculatorConfig.TextOfRichTextBoxCurrent += Digit;
            return CalculatorConfig;
        }

        public override CalculatorConfig AddDot(CalculatorConfig CalculatorConfig, string Dot)
        {
            return CalculatorConfig;
        }
    }
}
