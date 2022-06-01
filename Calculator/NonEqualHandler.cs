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
        public NonEqualHandler(Calculator Calculator) : base(Calculator)
        {
        }

        /// <summary>
        /// 當按下等號時去計算結果並將運算式以及結果顯示在畫面中，並將狀態切換到剛輸入等號
        /// </summary>
        /// <param name="Operator">輸入的運算元</param>
        public override Dictionary< string, string> AddEqual(string Operator)
        {
            string Expression = RichTextBoxPrevious.Text + RichTextBoxCurrent.Text + "=";
            string Result = new Expression((RichTextBoxPrevious.Text + RichTextBoxCurrent.Text).Replace('÷', '/').Replace('×', '*')).Evaluate().ToString();
            return ButtonEventHandlerResultGenerator(Expression, Result, CalculatorStatus.EQUAL);
        }

        /// <summary>
        /// 清除目前輸入的數字
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public override Dictionary<string, string> CE(string str)
        {
            return ButtonEventHandlerResultGenerator(this.Calculator.RichTextBoxPrevious.Text, Calculator.DefaultInteger, CalculatorStatus.INTEGER);
        }

        /// <summary>
        /// 將數字轉換正負值
        /// </summary>
        /// <param name="str">Botton.Text</param>
        public override Dictionary<string, string> Negate(string str)
        {
            return ButtonEventHandlerResultGenerator(this.Calculator.RichTextBoxPrevious.Text, (double.Parse(this.Calculator.RichTextBoxCurrent.Text) * -1).ToString(), this.Calculator.Status);
        }
    }
}
