using NCalc2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class DigitHandler : NonEqualHandler
    {
        public DigitHandler(Calculator Calculator) : base(Calculator)
        {
        }

        public override Dictionary<string, string> AddOperator(string Operator)
        {
            string EquationUpToDate = this.Calculator.RichTextBoxPrevious.Text + this.Calculator.RichTextBoxCurrent.Text;
            string ValueUpToDate = new Expression(EquationUpToDate.Replace('÷', '/').Replace('×', '*')).Evaluate().ToString();
            return ButtonEventHandlerResultGenerator(EquationUpToDate + Operator, ValueUpToDate, CalculatorStatus.OPERATOR);
        }

        public override Dictionary<string, string> Del(string Del)
        {
            string DeletedString = new Expression(("0" + this.Calculator.RichTextBoxCurrent.Text).Remove(this.Calculator.RichTextBoxCurrent.Text.Length)).Evaluate().ToString();
            string StatusAfterDeletion;
            try
            {
                int.Parse(RichTextBoxCurrent.Text);
                StatusAfterDeletion = CalculatorStatus.INTEGER;
            }
            catch
            {
                StatusAfterDeletion = CalculatorStatus.FLOAT;
            }
            return ButtonEventHandlerResultGenerator(this.Calculator.RichTextBoxPrevious.Text, DeletedString, StatusAfterDeletion);
        }
    }
}
