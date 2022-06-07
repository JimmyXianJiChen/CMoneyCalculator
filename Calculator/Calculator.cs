using NCalc2;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Calculator
{
    public static class CalculatorStatus
    {
        /// <summary>
        /// 正在輸入整數的狀態
        /// </summary>
        public const string INTEGER = "INTEGER";

        /// <summary>
        /// 正在輸入浮點數的狀態
        /// </summary>
        public const string FLOAT = "FLOAT";

        /// <summary>
        /// 剛輸入完運算元的狀態
        /// </summary>
        public const string OPERATOR = "OPERATOR";

        /// <summary>
        /// 剛輸入完等號的狀態
        /// </summary>
        public const string EQUAL = "EQUAL";
    }

    public partial class Calculator : Form
    {

        public string PreviousOperator;
        public string CurrentOperator;
        public string PreviousValue;
        public string CurrentValue;

        /// <summary>
        /// 預設的整數值
        /// </summary>
        public const string DefaultInteger = "0";

        /// <summary>
        /// 預設的浮點數值
        /// </summary>
        public const string DefaultFloat = "0.";

        /// <summary>
        /// 用於紀錄在各種情況下該呼叫哪個Handler的字典
        /// </summary>
        private Dictionary<string, ButtonEventHandler> StatusToButtonEventHandler;

        /// <summary>
        /// 用於紀錄在各個Button被按下的情況下該呼叫哪個Method的字典
        /// </summary>
        private Dictionary<string, string> ButtonTextToMethod;

        /// <summary>
        /// 目前的輸入狀態
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// Calculator的Constructor
        /// </summary>
        public Calculator()
        {
            InitializeComponent();
            //Status = "Digit";
            Status = CalculatorStatus.INTEGER;
            RichTextBoxCurrent.Text = DefaultInteger;
            RichTextBoxCurrent.Refresh();

            StatusToButtonEventHandler = new Dictionary<string, ButtonEventHandler>()
            {
                {CalculatorStatus.INTEGER, new IntegerHandler(this) },
                {CalculatorStatus.FLOAT, new FloatHandler(this) },
                {CalculatorStatus.OPERATOR, new OperatorHandler(this) },
                {CalculatorStatus.EQUAL, new EqualHandler(this) }
            };

            ButtonTextToMethod = new Dictionary<string, string>()
            {
                { "0", "AddDigit"},
                { "1", "AddDigit"},
                { "2", "AddDigit"},
                { "3", "AddDigit"},
                { "4", "AddDigit"},
                { "5", "AddDigit"},
                { "6", "AddDigit"},
                { "7", "AddDigit"},
                { "8", "AddDigit"},
                { "9", "AddDigit"},
                { ".", "AddDot"},
                { "+", "AddOperator"},
                { "-", "AddOperator"},
                { "×", "AddOperator"},
                { "÷", "AddOperator"},
                { "=", "AddEqual"},
                {"CE", "CE" },
                {"C", "C" },
                {"Del", "Del" },
                {"+/-", "Negate" }
            };

            PreviousOperator = "NULL";
            CurrentOperator = "NULL";
        }

        /// <summary>
        /// 當有任何按鍵被觸發時的處理函式
        /// </summary>
        /// <param name="sender">事件觸發的物件</param>
        /// <param name="e">事件參數</param>
        private void ButtonClick(object sender, EventArgs e)
        {
            string ButtonText = ((Button)sender).Text;
            //typeof(Calculator).GetMethod(ButtonToAction[Status][ButtonText]).Invoke(this, new[] { ButtonText });
            ButtonEventHandler Handler = StatusToButtonEventHandler[this.Status];
            Dictionary<string,string> ans = (Dictionary<string, string>) typeof(ButtonEventHandler).GetMethod(ButtonTextToMethod[ButtonText]).Invoke(Handler, new[] { ButtonText });
            this.RichTextBoxPrevious.Text = ans["PreviousText"];
            this.RichTextBoxCurrent.Text = ans["CurrentText"];
            this.Status = ans["Status"];
        }
    }
}
