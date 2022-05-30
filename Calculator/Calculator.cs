using NCalc2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
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

        /// <summary>
        /// 用於紀錄在各種情況下該呼叫哪個函式的字典
        /// </summary>
        private Dictionary<string, Dictionary<string, string>> ButtonToAction;

        /// <summary>
        /// 目前的輸入狀態
        /// </summary>
        private string Status;

        /// <summary>
        /// 之前所有輸入運算式的運算結果
        /// </summary>
        private string PrevVal = "0";

        /// <summary>
        /// 目前正在輸入的數字
        /// </summary>
        private string CurVal = "0";

        /// <summary>
        /// Calculator的Constructor
        /// </summary>
        public Calculator()
        {
            InitializeComponent();
            Status = "Digit";
            RichTextBoxCurrent.Text = "0";
            RichTextBoxCurrent.Refresh();
            ButtonToAction = new Dictionary<string, Dictionary<string, string>>()
            {
                {"Digit",
                    new Dictionary<string, string>()
                    {
                        { "0", "DigitAddDigit"},
                        { "1", "DigitAddDigit"},
                        { "2", "DigitAddDigit"},
                        { "3", "DigitAddDigit"},
                        { "4", "DigitAddDigit"},
                        { "5", "DigitAddDigit"},
                        { "6", "DigitAddDigit"},
                        { "7", "DigitAddDigit"},
                        { "8", "DigitAddDigit"},
                        { "9", "DigitAddDigit"},
                        { ".", "DigitAddDot"},
                        { "+", "AddOperator"},
                        { "-", "AddOperator"},
                        { "×", "AddOperator"},
                        { "÷", "AddOperator"},
                        { "=", "AddEqual"},
                        {"CE", "CE" },
                        {"C", "C" },
                        {"Del", "Del" },
                        {"+/-", "Negate" }
                    }
                },
                {"Float",
                    new Dictionary<string, string>()
                    {
                        { "0", "FloatAddDigit"},
                        { "1", "FloatAddDigit"},
                        { "2", "FloatAddDigit"},
                        { "3", "FloatAddDigit"},
                        { "4", "FloatAddDigit"},
                        { "5", "FloatAddDigit"},
                        { "6", "FloatAddDigit"},
                        { "7", "FloatAddDigit"},
                        { "8", "FloatAddDigit"},
                        { "9", "FloatAddDigit"},
                        { ".", "NoAction"},
                        { "+", "AddOperator"},
                        { "-", "AddOperator"},
                        { "×", "AddOperator"},
                        { "÷", "AddOperator"},
                        { "=", "AddEqual"},
                        {"CE", "CE" },
                        {"C", "C" },
                        {"Del", "Del" },
                        {"+/-", "Negate" }
                    }
                },
                {"Operator",
                    new Dictionary<string, string>()
                    {
                        { "0", "OperatorAddDigit"},
                        { "1", "OperatorAddDigit"},
                        { "2", "OperatorAddDigit"},
                        { "3", "OperatorAddDigit"},
                        { "4", "OperatorAddDigit"},
                        { "5", "OperatorAddDigit"},
                        { "6", "OperatorAddDigit"},
                        { "7", "OperatorAddDigit"},
                        { "8", "OperatorAddDigit"},
                        { "9", "OperatorAddDigit"},
                        { ".", "OperatorDotAutoZero"},
                        { "+", "OperatorReplaceOperator"},
                        { "-", "OperatorReplaceOperator"},
                        { "×", "OperatorReplaceOperator"},
                        { "÷", "OperatorReplaceOperator"},
                        { "=", "AddEqual"},
                        {"CE", "CE" },
                        {"C", "C" },
                        {"Del", "NoAction" },
                        {"+/-", "Negate" }
                    }
                },
                {"Equal",
                    new Dictionary<string, string>()
                    {
                        { "0", "EqualReplaceDigit"},
                        { "1", "EqualReplaceDigit"},
                        { "2", "EqualReplaceDigit"},
                        { "3", "EqualReplaceDigit"},
                        { "4", "EqualReplaceDigit"},
                        { "5", "EqualReplaceDigit"},
                        { "6", "EqualReplaceDigit"},
                        { "7", "EqualReplaceDigit"},
                        { "8", "EqualReplaceDigit"},
                        { "9", "EqualReplaceDigit"},
                        { ".", "EqualDotAutoZero"},
                        { "+", "EqualAddOperator"},
                        { "-", "EqualAddOperator"},
                        { "×", "EqualAddOperator"},
                        { "÷", "EqualAddOperator"},
                        { "=", "NoAction"},
                        {"CE", "C" },
                        {"C", "C" },
                        {"Del", "EqualDel" },
                        {"+/-", "EqualNegate" }
                    }
                },
            };
        }

        /// <summary>
        /// 當有任何按鍵被觸發時的處理函式
        /// </summary>
        /// <param name="sender">事件觸發的物件</param>
        /// <param name="e">事件參數</param>
        private void ButtonClick(object sender, EventArgs e)
        {
            string ButtonText = ((Button)sender).Text;
            typeof(Calculator).GetMethod(ButtonToAction[Status][ButtonText]).Invoke(this, new[] { ButtonText });
        }

        /// <summary>
        /// 在輸入數字模式下將輸入的數字更新道數字上
        /// </summary>
        /// <param name="Digit">所輸入的數字</param>
        public void DigitAddDigitOld(string Digit)
        {
            CurVal = double.Parse(CurVal + Digit).ToString();
            RichTextBoxCurrent.Text = CurVal;
        }
        
        /// <summary>
        /// 在輸入數字模式下將輸入的數字更新道數字上
        /// </summary>
        /// <param name="Digit">所輸入的數字</param>
        public void DigitAddDigit(string Digit)
        {
            RichTextBoxCurrent.Text = int.Parse(RichTextBoxCurrent.Text + Digit).ToString();
        }

        /// <summary>
        /// 在輸入數字模式下按下小數點後將模式切換到浮點數輸入
        /// </summary>
        /// <param name="Dot">小數點</param>
        public void DigitAddDotOld(string Dot)
        {
            CurVal += Dot;
            RichTextBoxCurrent.Text = CurVal;
            this.Status = FLOAT;
        }
        
        /// <summary>
        /// 在輸入數字模式下按下小數點後將模式切換到浮點數輸入
        /// </summary>
        /// <param name="Dot">小數點</param>
        public void DigitAddDot(string Dot)
        {
            RichTextBoxCurrent.Text += Dot;
            this.Status = FLOAT;
        }

        /// <summary>
        /// 在目前已經在輸入浮點數的情況且接著輸入數字的情況下將數字加到現有浮點數的後面
        /// </summary>
        /// <param name="Digit">所輸入的數字</param>
        public void FloatAddDigitOld(string Digit)
        {
            CurVal += Digit;
            RichTextBoxCurrent.Text = CurVal;
        }
        
        /// <summary>
        /// 在目前已經在輸入浮點數的情況且接著輸入數字的情況下將數字加到現有浮點數的後面
        /// </summary>
        /// <param name="Digit">所輸入的數字</param>
        public void FloatAddDigit(string Digit)
        {
            RichTextBoxCurrent.Text += Digit;
        }

        /// <summary>
        /// 在輸入運算元之後輸入數字時將數字更新到下方的欄位定將狀態切換到剛輸入數字
        /// </summary>
        /// <param name="Digit">所輸入的數字</param>
        public void OperatorAddDigitOld(string Digit)
        {
            CurVal = Digit;
            RichTextBoxCurrent.Text = Digit;
            this.Status = DIGIT;
        }
        
        /// <summary>
        /// 在輸入運算元之後輸入數字時將數字更新到下方的欄位定將狀態切換到剛輸入數字
        /// </summary>
        /// <param name="Digit">所輸入的數字</param>
        public void OperatorAddDigit(string Digit)
        {
            RichTextBoxCurrent.Text = Digit;
            this.Status = DIGIT;
        }

        /// <summary>
        /// 當前一個按下的按鍵為運算元時，按下.的按鍵後自動在其之前補上0，並將狀態切換到剛輸入浮點數數字
        /// </summary>
        /// <param name="Dot">小數點</param>
        public void OperatorDotAutoZeroOld(string Dot)
        {
            CurVal = "0.";
            RichTextBoxCurrent.Text = CurVal;
            this.Status = FLOAT;
        }
        
        /// <summary>
        /// 當前一個按下的按鍵為運算元時，按下.的按鍵後自動在其之前補上0，並將狀態切換到剛輸入浮點數數字
        /// </summary>
        /// <param name="Dot">小數點</param>
        public void OperatorDotAutoZero(string Dot)
        {
            RichTextBoxCurrent.Text = "0.";
            this.Status = FLOAT;
        }

        /// <summary>
        /// 當前一個輸入的是運算元但又重複輸入運算元時，用新輸入的運算元取代原有的運算元
        /// </summary>
        /// <param name="Operator">輸入的運算元</param>
        public void OperatorReplaceOperatorOld(string Operator)
        {
            RichTextBoxPrevious.Text = PrevVal + Operator;
        }
        
        /// <summary>
        /// 當前一個輸入的是運算元但又重複輸入運算元時，用新輸入的運算元取代原有的運算元
        /// </summary>
        /// <param name="Operator">輸入的運算元</param>
        public void OperatorReplaceOperator(string Operator)
        {
            RichTextBoxPrevious.Text = RichTextBoxPrevious.Text.Remove(RichTextBoxPrevious.Text.Length - 1) + Operator;
        }

        /// <summary>
        /// 在前一個輸入的按鈕是等號接著輸入數字時，用新輸入的數字取代運算結果，並將狀態切換到剛輸入數字
        /// </summary>
        /// <param name="Digit">輸入的數字</param>
        public void EqualReplaceDigitOld(string Digit)
        {
            PrevVal = string.Empty;
            CurVal = Digit;
            RichTextBoxPrevious.Text = PrevVal;
            RichTextBoxCurrent.Text = CurVal;
            this.Status = DIGIT;
        }
        
        /// <summary>
        /// 在前一個輸入的按鈕是等號接著輸入數字時，用新輸入的數字取代運算結果，並將狀態切換到剛輸入數字
        /// </summary>
        /// <param name="Digit">輸入的數字</param>
        public void EqualReplaceDigit(string Digit)
        {
            RichTextBoxPrevious.Text = string.Empty;
            RichTextBoxCurrent.Text = Digit;
            this.Status = DIGIT;
        }

        /// <summary>
        /// 在剛輸入等號又按下小數點的情況下將先前的運算記錄清空，並自動為浮底數的前面補上0
        /// </summary>
        /// <param name="Dot">小數點</param>
        public void EqualDotAutoZero(string Dot)
        {
            OperatorDotAutoZero(Dot);
            RichTextBoxPrevious.Text = string.Empty;
            this.Status = FLOAT;
        }

        /// <summary>
        /// 在前一個輸入是等號接著輸入運算元的時候，讓算盤基於等號的運算結果繼續去運算，並將狀態切換到剛輸入運算元
        /// </summary>
        /// <param name="Operator">輸入的運算元</param>
        public void EqualAddOperatorOld(string Operator)
        {
            RichTextBoxPrevious.Text = PrevVal + Operator;
            //???
            this.Status = OPERATOR;
        }

        /// <summary>
        /// 在前一個輸入是等號接著輸入運算元的時候，讓算盤基於等號的運算結果繼續去運算，並將狀態切換到剛輸入運算元
        /// </summary>
        /// <param name="Operator">輸入的運算元</param>
        public void EqualAddOperator(string Operator)
        {
            RichTextBoxPrevious.Text = RichTextBoxCurrent.Text + Operator;
            this.Status = OPERATOR;
        }

        /// <summary>
        /// 當按下運算元的按鍵時去計算前面的運算式，並將狀態切換到剛輸入運算元
        /// </summary>
        /// <param name="Operator">輸入的運算元</param>
        public void AddOperatorOld(string Operator)
        {
            PrevVal = new Expression((RichTextBoxPrevious.Text + CurVal).Replace('÷', '/').Replace('×', '*')).Evaluate().ToString();
            CurVal = PrevVal;

            //Original
            RichTextBoxPrevious.Text = PrevVal + Operator;
            RichTextBoxCurrent.Text = PrevVal;
            this.Status = OPERATOR;
        }
        
        /// <summary>
        /// 當按下運算元的按鍵時去計算前面的運算式，並將狀態切換到剛輸入運算元
        /// </summary>
        /// <param name="Operator">輸入的運算元</param>
        public void AddOperator(string Operator)
        {
            //MOD
            RichTextBoxPrevious.Text += RichTextBoxCurrent.Text + Operator;
            this.Status = OPERATOR;
        }

        /// <summary>
        /// 當按下等號時去計算結果並將運算式以及結果顯示在畫面中，並將狀態切換到剛輸入等號
        /// </summary>
        /// <param name="Operator">輸入的運算元</param>
        public void AddEqualOld(string Operator)
        {
            string Expression = RichTextBoxPrevious.Text + CurVal + "=";
            string Result = new Expression((RichTextBoxPrevious.Text + CurVal).Replace('÷', '/').Replace('×', '*')).Evaluate().ToString();
            RichTextBoxPrevious.Text = Expression;
            RichTextBoxCurrent.Text = Result;
            PrevVal = Result;
            CurVal = Result;
            this.Status = EQUAL;
        }
        
        /// <summary>
        /// 當按下等號時去計算結果並將運算式以及結果顯示在畫面中，並將狀態切換到剛輸入等號
        /// </summary>
        /// <param name="Operator">輸入的運算元</param>
        public void AddEqual(string Operator)
        {
            string Expression = RichTextBoxPrevious.Text + RichTextBoxCurrent.Text + "=";
            string Result = new Expression((RichTextBoxPrevious.Text + RichTextBoxCurrent.Text).Replace('÷', '/').Replace('×', '*')).Evaluate().ToString();
            RichTextBoxPrevious.Text = Expression;
            RichTextBoxCurrent.Text = Result;
            this.Status = EQUAL;
        }

        /// <summary>
        /// 清除目前輸入的數字
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public void CEOld(string str)
        {
            CurVal = "0";
            RichTextBoxCurrent.Text = CurVal;
        }
        
        /// <summary>
        /// 清除目前輸入的數字
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public void CE(string str)
        {
            RichTextBoxCurrent.Text = "0";
            this.Status = DIGIT;
        }

        /// <summary>
        /// 清除所有的計算資料
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public void COld(string str)
        {
            CE(str);
            PrevVal = "0";
            RichTextBoxPrevious.Text = string.Empty;
        }
        
        /// <summary>
        /// 清除所有的計算資料
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public void C(string str)
        {
            CE(str);
            RichTextBoxPrevious.Text = string.Empty;
            this.Status = DIGIT;
        }

        /// <summary>
        /// 刪除現正輸入的數字的一個位數
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public void DelOld(string str)
        {
            CurVal = ("0" + CurVal).Remove(CurVal.Length);
            RichTextBoxCurrent.Text = CurVal;
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

        /// <summary>
        /// 在運算完之後按下正負號時除了轉換正負號之外還會清空上方運算式的資訊
        /// </summary>
        /// <param name="str">Botton.Text</param>
        public void EqualNegate(string str)
        {
            RichTextBoxPrevious.Text = string.Empty;
            RichTextBoxCurrent.Text = (double.Parse(RichTextBoxCurrent.Text) * -1).ToString();
        }

        /// <summary>
        /// 當輸入的符號不合法時不採取任何動作
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public void NoAction(string str)
        {
        }
    }
}
