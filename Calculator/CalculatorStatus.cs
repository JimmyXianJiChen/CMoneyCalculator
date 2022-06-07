using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
