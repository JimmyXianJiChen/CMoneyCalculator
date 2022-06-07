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
        protected Dictionary<string, string> PreviousOperatorToConfigUpdateMethod = new Dictionary<string, string>
        {
            { "+", "PreviousAddMinusConfigUpdate"},
            { "-", "PreviousAddMinusConfigUpdate"},
            { "×", "PreviousMultiplyDivideConfigUpdate"},
            { "÷", "PreviousMultiplyDivideConfigUpdate"},
            { "NULL", "PreviousNullConfigUpdate" }
        };

        public CalculatorConfig PreviousAddMinusConfigUpdate(CalculatorConfig CalculatorConfig, string Operator)
        {
            CalculatorConfig.CurrentValue = CalculateCurrent(CalculatorConfig);
            CalculatorConfig.CurrentOperator = Operator;
            return CalculatorConfig;
        }

        public CalculatorConfig PreviousMultiplyDivideConfigUpdate(CalculatorConfig CalculatorConfig, string Operator)
        {
            CalculatorConfig.PreviousValue = CalculatePrevious(CalculatorConfig);
            CalculatorConfig.CurrentValue = CalculatorConfig.TextOfRichTextBoxCurrent;
            CalculatorConfig.PreviousOperator = CalculatorConfig.CurrentOperator;
            CalculatorConfig.CurrentOperator = Operator;
            return CalculatorConfig;
        }

        public CalculatorConfig PreviousNullConfigUpdate(CalculatorConfig CalculatorConfig, string Operator)
        {
            CalculatorConfig.PreviousOperator = CalculatorConfig.CurrentOperator;
            CalculatorConfig.CurrentOperator = Operator;
            CalculatorConfig.PreviousValue = CalculatorConfig.CurrentValue;
            CalculatorConfig.CurrentValue = CalculatorConfig.TextOfRichTextBoxCurrent;
            return CalculatorConfig;
        }


        //TODO!!
        public override CalculatorConfig AddOperator(CalculatorConfig CalculatorConfig, string Operator)
        {

            string EquationUpToDate = CalculatorConfig.TextOfRichTextBoxPrevious + CalculatorConfig.TextOfRichTextBoxCurrent;
            string ValueUpToDate = CalculateFinalValue(CalculatorConfig);

            string tt = PreviousOperatorToConfigUpdateMethod[CalculatorConfig.PreviousOperator];
            //TEST
            //WATH out object[]!!! May Error
            CalculatorConfig = (CalculatorConfig) typeof(DigitHandler).GetMethod(PreviousOperatorToConfigUpdateMethod[CalculatorConfig.PreviousOperator]).Invoke(this, new object[] { CalculatorConfig, Operator });

            CalculatorConfig.TextOfRichTextBoxPrevious = EquationUpToDate + Operator;
            CalculatorConfig.TextOfRichTextBoxCurrent = ValueUpToDate;//tt + "/" + ValueUpToDate + "/" + CalculatorConfig.PreviousOperator + "/" + CalculatorConfig.CurrentOperator + "/" + Operator;
            CalculatorConfig.Status = CalculatorStatus.OPERATOR;

            return CalculatorConfig;


            //string EquationUpToDate = TextOfRichTextBoxPrevious + TextOfRichTextBoxCurrent;
            //string ValueUpToDate = new Expression(EquationUpToDate.Replace('÷', '/').Replace('×', '*')).Evaluate().ToString();
            //return ButtonEventHandlerResultGenerator(EquationUpToDate + " " + Operator + " ", ValueUpToDate, CalculatorStatus.OPERATOR);
        }

        public override CalculatorConfig Del(CalculatorConfig CalculatorConfig, string Del)
        {
            string DeletedString = new Expression(("0" + CalculatorConfig.TextOfRichTextBoxCurrent).Remove(CalculatorConfig.TextOfRichTextBoxCurrent.Length)).Evaluate().ToString();
            CalculatorConfig.TextOfRichTextBoxCurrent = DeletedString;
            try
            {
                int.Parse(DeletedString);
                CalculatorConfig.Status = CalculatorStatus.INTEGER;
            }
            catch
            {
                CalculatorConfig.Status = CalculatorStatus.FLOAT;
            }
            return CalculatorConfig;
        }
    }
}
