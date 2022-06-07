using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// 協助對以字串形式表達的數字做運算的工具
    /// </summary>
    public class StringCalculationHelper
    {
        /// <summary>
        /// 記錄個個運算元該呼叫哪個函式去計算的字典
        /// </summary>
        private readonly Dictionary<string, string> OperatorToAction = new Dictionary<string, string>
        {
            { "+", "ADD"},
            { "-", "MINUS"},
            { "×", "MULTIPLY"},
            { "÷", "DIVIDE"}
        };

        /// <summary>
        /// 計算兩數相加
        /// </summary>
        /// <param name="Operand1">第一個運算子</param>
        /// <param name="Operand2">第二個運算子</param>
        /// <returns>計算結果</returns>
        public string ADD(string Operand1, string Operand2)
        {
            return (double.Parse(Operand1) + double.Parse(Operand2)).ToString();
        }

        /// <summary>
        /// 計算兩數相減
        /// </summary>
        /// <param name="Operand1">第一個運算子</param>
        /// <param name="Operand2">第二個運算子</param>
        /// <returns>計算結果</returns>
        public string MINUS(string Operand1, string Operand2)
        {
            return (double.Parse(Operand1) - double.Parse(Operand2)).ToString();
        }

        /// <summary>
        /// 計算兩數相乘
        /// </summary>
        /// <param name="Operand1">第一個運算子</param>
        /// <param name="Operand2">第二個運算子</param>
        /// <returns>計算結果</returns>
        public string MULTIPLY(string Operand1, string Operand2)
        {
            return (double.Parse(Operand1) * double.Parse(Operand2)).ToString();
        }

        /// <summary>
        /// 計算兩數相除
        /// </summary>
        /// <param name="Operand1">第一個運算子</param>
        /// <param name="Operand2">第二個運算子</param>
        /// <returns>計算結果</returns>
        public string DIVIDE(string Operand1, string Operand2)
        {
            return (double.Parse(Operand1) / double.Parse(Operand2)).ToString();
        }

        /// <summary>
        /// 計算所輸入的兩個運算子雨衣個運算元所組成的表達式的值
        /// </summary>
        /// <param name="Operand1">第一個運算子</param>
        /// <param name="Operator">運算元</param>
        /// <param name="Operand2">第二個運算子</param>
        /// <returns>計算結果</returns>
        public string Calculate(string Operand1, string Operator, string Operand2)
        {
            return typeof(StringCalculationHelper).GetMethod(OperatorToAction[Operator]).Invoke(this, new[] { Operand1, Operand2 }).ToString();
        }
    }
}
