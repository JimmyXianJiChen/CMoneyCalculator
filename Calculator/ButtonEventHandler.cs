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
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="Status"></param>
        public ButtonEventHandler()
        {
        }

        public abstract CalculatorConfig AddDigit(CalculatorConfig CalculatorConfig, string Digit);

        /// <summary>
        /// 當按下運算元的按鍵時去計算前面的運算式，並將狀態切換到剛輸入運算元
        /// </summary>
        /// <param name="Operator">輸入的運算元</param>
        public abstract CalculatorConfig AddOperator(CalculatorConfig CalculatorConfig, string Operator);

        /// <summary>
        /// 當按下小數點後所需完成的後續動作
        /// </summary>
        /// <param name="Dot">小數點</param>
        public abstract CalculatorConfig AddDot(CalculatorConfig CalculatorConfig, string Dot);

        /// <summary>
        /// 當按下等號後所需完成的後續動作
        /// </summary>
        /// <param name="Dot">小數點</param>
        public abstract CalculatorConfig AddEqual(CalculatorConfig CalculatorConfig, string Equal);

        /// <summary>
        /// 清除目前輸入的數字
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public abstract CalculatorConfig CE(CalculatorConfig CalculatorConfig, string CE);

        /// <summary>
        /// 清除所有的計算資料
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public CalculatorConfig C(CalculatorConfig CalculatorConfig, string C)
        {
            return new CalculatorConfig(string.Empty,
                                        Calculator.DefaultInteger,
                                        CalculatorStatus.INTEGER,
                                        Calculator.DefaultValue,
                                        Calculator.DefaultValue,
                                        Calculator.DefaultOperator,
                                        Calculator.DefaultOperator
                                        );
        }

        /// <summary>
        /// 刪除現正輸入的數字的一個位數
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        public abstract CalculatorConfig Del(CalculatorConfig CalculatorConfig, string Del);

        /// <summary>
        /// 將數字轉換正負值
        /// </summary>
        /// <param name="str">Botton.Text</param>
        public abstract CalculatorConfig Negate(CalculatorConfig CalculatorConfig, string Negate);

        /// <summary>
        /// 將所輸入的數字開根號
        /// </summary>
        /// <param name="CalculatorConfig">Calculator現在的狀態</param>
        /// <param name="Root">Root</param>
        /// <returns></returns>
        public abstract CalculatorConfig Root(CalculatorConfig CalculatorConfig, string Root);

        /// <summary>
        /// 當輸入的符號不合法時不採取任何動作
        /// </summary>
        /// <param name="str">按鍵的符號</param>
        protected CalculatorConfig NoAction(CalculatorConfig CalculatorConfig)
        {
            return CalculatorConfig;
        }
    }
}
