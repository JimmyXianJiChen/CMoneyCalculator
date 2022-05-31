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
            return ButtonEventHandlerResultGenerator(Expression, Result, this.Calculator.Status);
        }

        /// <summary>
        /// 清除目前輸入的數字
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public override Dictionary<string, string> CE(string str)
        {
            return ButtonEventHandlerResultGenerator(RichTextBoxPrevious.Text, "0", DIGIT);
        }

        /// <summary>
        /// 清除所有的計算資料
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public override Dictionary<string, string> C(string str)
        {
            CE(str);
            RichTextBoxPrevious.Text = string.Empty;
            this.Status = DIGIT;
        }

        /// <summary>
        /// 刪除現正輸入的數字的一個位數
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public void Del(string str)
        {
            RichTextBoxCurrent.Text = new Expression(("0" + RichTextBoxCurrent.Text).Remove(RichTextBoxCurrent.Text.Length)).Evaluate().ToString();
            try
            {
                int.Parse(RichTextBoxCurrent.Text);
                this.Status = DIGIT;
            }
            catch
            {
                this.Status = FLOAT;
            }
        }

        /// <summary>
        /// 將數字轉換正負值
        /// </summary>
        /// <param name="str">Botton.Text</param>
        public void Negate(string str)
        {
            RichTextBoxCurrent.Text = (double.Parse(RichTextBoxCurrent.Text) * -1).ToString();
        }
    }
}
