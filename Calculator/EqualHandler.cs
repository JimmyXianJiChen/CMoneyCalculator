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
        public EqualHandler(Calculator Calculator) : base (Calculator)
        {
        }

        public override Dictionary<string, string> AddDigit(string Digit)
        {
            return ButtonEventHandlerResultGenerator(string.Empty, Digit, CalculatorStatus.INTEGER);
        }

        public override Dictionary<string, string> AddDot(string Dot)
        {
            return ButtonEventHandlerResultGenerator(string.Empty, Calculator.DefaultFloat, CalculatorStatus.FLOAT);
        }

        public override Dictionary<string, string> AddEqual(string Equal)
        {
            return NoAction();
        }

        public override Dictionary<string, string> AddOperator(string Operator)
        {
            Calculator.CurrentValue = this.Calculator.RichTextBoxCurrent.Text;
            Calculator.CurrentOperator = Operator;
            return ButtonEventHandlerResultGenerator(this.Calculator.RichTextBoxCurrent.Text + " " +　Operator + " ", this.Calculator.RichTextBoxCurrent.Text, CalculatorStatus.OPERATOR);
        }

        public override Dictionary<string, string> CE(string CE)
        {
            return C(CE);
        }

        public override Dictionary<string, string> Del(string Del)
        {
            return ButtonEventHandlerResultGenerator(string.Empty, this.Calculator.RichTextBoxCurrent.Text, CalculatorStatus.EQUAL);
        }

        public override Dictionary<string, string> Negate(string Del)
        {
            string NegatedResult;
            try
            {
                NegatedResult = (int.Parse(this.Calculator.RichTextBoxCurrent.Text) * -1).ToString();
            }
            catch
            {
                NegatedResult = (double.Parse(this.Calculator.RichTextBoxCurrent.Text) * -1).ToString();
            }
            return ButtonEventHandlerResultGenerator(string.Empty, NegatedResult, CalculatorStatus.EQUAL);
        }
    }
}
