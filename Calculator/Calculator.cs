using NCalc2;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// Calculator 物件定義
    /// </summary>
    public partial class Calculator : Form
    {
        /// <summary>
        /// 用於紀錄當下運算式中的第一個運算元
        /// </summary>
        private string PreviousOperator;

        /// <summary>
        /// 用於紀錄當下運算式中的第二個運算元
        /// </summary>
        private string CurrentOperator;

        /// <summary>
        /// 用於紀錄當下運算式中的第一個運算子
        /// </summary>
        private string PreviousValue;

        /// <summary>
        /// 用於紀錄當下運算式中的第二個運算子
        /// </summary>
        private string CurrentValue;

        /// <summary>
        /// 預設的整數值
        /// </summary>
        public const string DefaultInteger = "0";

        /// <summary>
        /// 預設的浮點數值
        /// </summary>
        public const string DefaultFloat = "0.";

        /// <summary>
        /// 預設用於紀錄前兩個運算元的變數的預設值
        /// </summary>
        public const string DefaultOperator = "NULL";

        /// <summary>
        /// 預設用於紀錄前兩個運算子的變數的預設值
        /// </summary>
        public const string DefaultValue = "NULL";

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
                {CalculatorStatus.INTEGER, new IntegerHandler() },
                {CalculatorStatus.FLOAT, new FloatHandler() },
                {CalculatorStatus.OPERATOR, new OperatorHandler() },
                {CalculatorStatus.EQUAL, new EqualHandler() }
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
                {"+/-", "Negate" },
                {"√", "Root"}
            };

            PreviousOperator = DefaultOperator;
            CurrentOperator = DefaultOperator;
            PreviousValue = DefaultValue;
            CurrentValue = DefaultValue;
        }

        /// <summary>
        /// 當有任何按鍵被觸發時的處理函式
        /// </summary>
        /// <param name="sender">事件觸發的物件</param>
        /// <param name="e">事件參數</param>
        private void ButtonClick(object sender, EventArgs e)
        {
            string ButtonText = ((Button)sender).Text;
            ButtonEventHandler Handler = StatusToButtonEventHandler[this.Status];
            CalculatorConfig UpdatedConfig = (CalculatorConfig) typeof(ButtonEventHandler).GetMethod(ButtonTextToMethod[ButtonText]).Invoke(Handler, new object[] { GetCurrentConfig(), ButtonText });
            SetCalculatorToConfig(UpdatedConfig);
            //listBox1.Items.Add(UpdatedConfig.PreviousOperator+"/"+UpdatedConfig.CurrentOperator+"/"+UpdatedConfig.Status);
        }

        /// <summary>
        /// 產生包含Calculator現在組成所有資訊的CalculatorConfig物件
        /// </summary>
        /// <returns></returns>
        private CalculatorConfig GetCurrentConfig()
        {
            return new CalculatorConfig(RichTextBoxPrevious.Text, RichTextBoxCurrent.Text, Status, PreviousValue, CurrentValue, PreviousOperator, CurrentOperator);
        }

        /// <summary>
        /// 將Calculator的狀態設置成所傳入的狀態
        /// </summary>
        /// <param name="CalculatorConfig">呼叫函式當下Calculator的狀態</param>
        private void SetCalculatorToConfig(CalculatorConfig CalculatorConfig)
        {
            RichTextBoxPrevious.Text = CalculatorConfig.TextOfRichTextBoxPrevious;
            RichTextBoxCurrent.Text = CalculatorConfig.TextOfRichTextBoxCurrent;
            Status = CalculatorConfig.Status;
            PreviousValue = CalculatorConfig.PreviousValue;
            CurrentValue = CalculatorConfig.CurrentValue;
            PreviousOperator = CalculatorConfig.PreviousOperator;
            CurrentOperator = CalculatorConfig.CurrentOperator;
        }
    }
}
