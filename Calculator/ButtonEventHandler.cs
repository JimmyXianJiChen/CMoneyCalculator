using NCalc2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using static Calculator.CalculatorStatus;

namespace Calculator
{
    public abstract class ButtonEventHandler
    {
        protected readonly Calculator Calculator;

        protected Dictionary<string, string> ButtonTextToActions = new Dictionary<string, string>();




        public ButtonEventHandler(Calculator Calculator)
        {
            this.Calculator = Calculator;
        }

        public abstract Dictionary<string, string> AddDigit(string Digit);

        /// <summary>
        /// 當按下運算元的按鍵時去計算前面的運算式，並將狀態切換到剛輸入運算元
        /// </summary>
        /// <param name="Operator">輸入的運算元</param>
        public abstract Dictionary<string, string> AddOperator(string Operator);

        /// <summary>
        /// 當按下小數點後所需完成的後續動作
        /// </summary>
        /// <param name="Dot">小數點</param>
        public abstract Dictionary<string, string> AddDot(string Dot);

        /// <summary>
        /// 當按下等號後所需完成的後續動作
        /// </summary>
        /// <param name="Dot">小數點</param>
        public abstract Dictionary<string, string> AddEqual(string Equal);

        /// <summary>
        /// 清除目前輸入的數字
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public abstract Dictionary<string, string> CE(string CE);

        /// <summary>
        /// 清除所有的計算資料
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public Dictionary<string, string> C(string C)
        {
            return ButtonEventHandlerResultGenerator(string.Empty, Calculator.DefaultInteger, CalculatorStatus.INTEGER);
        }

        /// <summary>
        /// 刪除現正輸入的數字的一個位數
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public abstract Dictionary<string, string> Del(string Del);

        /// <summary>
        /// 將數字轉換正負值
        /// </summary>
        /// <param name="str">Botton.Text</param>
        public abstract Dictionary<string, string> Negate(string Del);

        public Dictionary<string, string> ButtonEventHandlerResultGenerator(string PreviousText, string CurrentText, string Status)
        {
            return new Dictionary<string, string>
                {
                    { "PreviousText", PreviousText },
                    { "CurrentText", CurrentText },
                    { "Status", Status }
                };
        }

        /// <summary>
        /// 當輸入的符號不合法時不採取任何動作
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        protected Dictionary<string, string> NoAction()
        {
            return ButtonEventHandlerResultGenerator(this.Calculator.RichTextBoxPrevious.Text, this.Calculator.RichTextBoxCurrent.Text, this.Calculator.Status);
        }

        public char? GetPreviousOperator(string Expression)
        {
            char[] charArray = Expression.ToCharArray();
            char[] Operators = { '+', '-', '×', '÷' };
            Array.Reverse(charArray);
            string ReversedExpression = new string(charArray);
            int IndexOfLastOperator = ReversedExpression.IndexOfAny(Operators);
            try
            {
                return ReversedExpression[IndexOfLastOperator];
            }
            catch
            {
                return null;
            }
        }
    }
}
