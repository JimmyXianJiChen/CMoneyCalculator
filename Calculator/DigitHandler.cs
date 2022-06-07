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
        protected Dictionary<string, string> PreviousOperatorToStatus = new Dictionary<string, string>
        {
            { "+", "PREVIOUSADDMINUS"},
            { "-", "PREVIOUSADDMINUS"},
            { "×", "PREVIOUSMULTIPLYDIVIDE"},
            { "÷", "PREVIOUSMULTIPLYDIVIDE"},
            { "NULL", "PREVIOUSNULL" }
        };

        public void PREVIOUSNULL(string Operator)
        {
            Calculator.PreviousOperator = Calculator.CurrentOperator;
            Calculator.CurrentOperator = Operator;
            Calculator.PreviousValue = Calculator.CurrentValue;
            Calculator.CurrentValue = this.Calculator.RichTextBoxCurrent.Text;
        }

        public DigitHandler(Calculator Calculator) : base(Calculator)
        {
        }

        public override Dictionary<string, string> AddOperator(string Operator)
        {
            //TEST
            typeof(DigitHandler).GetMethod(PreviousOperatorToStatus[Calculator.PreviousOperator]).Invoke(this, new[] { Operator});


            string EquationUpToDate = this.Calculator.RichTextBoxPrevious.Text + this.Calculator.RichTextBoxCurrent.Text;
            string ValueUpToDate = new Expression(EquationUpToDate.Replace('÷', '/').Replace('×', '*')).Evaluate().ToString();
            return ButtonEventHandlerResultGenerator(EquationUpToDate + " " + Operator + " ", ValueUpToDate, CalculatorStatus.OPERATOR);
        }

        public override Dictionary<string, string> Del(string Del)
        {
            string DeletedString = new Expression(("0" + this.Calculator.RichTextBoxCurrent.Text).Remove(this.Calculator.RichTextBoxCurrent.Text.Length)).Evaluate().ToString();
            string StatusAfterDeletion;
            try
            {
                int.Parse(this.Calculator.RichTextBoxCurrent.Text);
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
