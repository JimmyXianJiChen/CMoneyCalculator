using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class FloatHandler :DigitHandler
    {
        public FloatHandler(Calculator Calculator) : base(Calculator)
        {
        }

        public override Dictionary<string, string> AddDigit(string Digit)
        {
            return ButtonEventHandlerResultGenerator(this.Calculator.RichTextBoxPrevious.Text, this.Calculator.RichTextBoxCurrent.Text + Digit, CalculatorStatus.FLOAT);
        }

        public override Dictionary<string, string> AddDot(string Dot)
        {
            return NoAction();
        }
    }
}
