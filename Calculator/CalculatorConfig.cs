using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorConfig
    {
        public string TextOfRichTextBoxPrevious { get; set; }
        public string TextOfRichTextBoxCurrent { get; set; }
        public string Status { get; set; }
        public string PreviousValue { get; set; }
        public string CurrentValue { get; set; }
        public string PreviousOperator { get; set; }
        public string CurrentOperator { get; set; }

        public CalculatorConfig(string TextOfPreviousRichTextBox, string TextOfCurrentRichTextBox, string Status, string PreviousValue, string CurrentValue, string PreviousOperator, string CurrentOperator)
        {
            this.TextOfRichTextBoxPrevious = TextOfPreviousRichTextBox;
            this.TextOfRichTextBoxCurrent = TextOfCurrentRichTextBox;
            this.Status = Status;
            this.PreviousValue = PreviousValue;
            this.CurrentValue = CurrentValue;
            this.PreviousOperator = PreviousOperator;
            this.CurrentOperator = CurrentOperator;
        }
    }
}
