using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class OperatorHandler : NonEqualHandler
    {
        public OperatorHandler(Calculator Calculator) : base(Calculator)
        {
        }

        public override Dictionary<string, string> AddDigit(string Digit)
        {
            return ButtonEventHandlerResultGenerator(this.Calculator.RichTextBoxPrevious.Text, Digit, CalculatorStatus.INTEGER);
        }

        public override Dictionary<string, string> AddDot(string Dot)
        {
            return ButtonEventHandlerResultGenerator(this.Calculator.RichTextBoxPrevious.Text, Calculator.DefaultFloat, CalculatorStatus.FLOAT);
        }

        public override Dictionary<string, string> AddOperator(string Operator)
        {
            return ButtonEventHandlerResultGenerator(this.Calculator.RichTextBoxPrevious.Text.Remove(this.Calculator.RichTextBoxPrevious.Text.Length) + Operator, this.Calculator.RichTextBoxCurrent.Text, CalculatorStatus.OPERATOR);
        }

        public override Dictionary<string, string> Del(string Del)
        {
            return NoAction();
        }
    }
}
