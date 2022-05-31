using NCalc2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using static Calculator.STATUS;

namespace Calculator
{
    public abstract class ButtonEventHandler
    {
        protected readonly Calculator Calculator;
        protected RichTextBox RichTextBoxPrevious;
        protected RichTextBox RichTextBoxCurrent;
        protected Dictionary<string, string> ButtonTextToActions = new Dictionary<string, string>();
        
        /// <summary>
        /// 正在輸入整數的狀態
        /// </summary>
        public const string DIGIT = "Digit";

        /// <summary>
        /// 剛輸入完運算元的狀態
        /// </summary>
        public const string OPERATOR = "Operator";

        /// <summary>
        /// 正在輸入浮點數的狀態
        /// </summary>
        public const string FLOAT = "Float";

        /// <summary>
        /// 剛輸入完等號的狀態
        /// </summary>
        public const string EQUAL = "Equal";

        public ButtonEventHandler(Calculator Calculator)
        {
            this.Calculator = Calculator;
            this.RichTextBoxPrevious = Calculator.RichTextBoxPrevious;
            this.RichTextBoxCurrent = Calculator.RichTextBoxCurrent;
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
            return ButtonEventHandlerResultGenerator(string.Empty, "0", Calculator.STATUS.INTEGER);
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
                    { "CurrrentText", CurrentText },
                    { "Status", Status }
                };
        }

        /// <summary>
        /// 當輸入的符號不合法時不採取任何動作
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public string NoAction(string str)
        {
            return this.Calculator.Status;
        }
    }
}
