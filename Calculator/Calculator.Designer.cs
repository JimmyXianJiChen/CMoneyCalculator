namespace Calculator
{
    partial class Calculator
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonEqual = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonMinus = new System.Windows.Forms.Button();
            this.ButtonMultiply = new System.Windows.Forms.Button();
            this.ButtonDivide = new System.Windows.Forms.Button();
            this.Button0 = new System.Windows.Forms.Button();
            this.ButtonDot = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.Button6 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button8 = new System.Windows.Forms.Button();
            this.Button9 = new System.Windows.Forms.Button();
            this.Button7 = new System.Windows.Forms.Button();
            this.RichTextBoxCurrent = new System.Windows.Forms.RichTextBox();
            this.RichTextBoxPrevious = new System.Windows.Forms.RichTextBox();
            this.ButtonC = new System.Windows.Forms.Button();
            this.ButtonCE = new System.Windows.Forms.Button();
            this.ButtonDel = new System.Windows.Forms.Button();
            this.ButtonNegate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonEqual
            // 
            this.ButtonEqual.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ButtonEqual.Location = new System.Drawing.Point(374, 568);
            this.ButtonEqual.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonEqual.Name = "ButtonEqual";
            this.ButtonEqual.Size = new System.Drawing.Size(125, 75);
            this.ButtonEqual.TabIndex = 2;
            this.ButtonEqual.Text = "=";
            this.ButtonEqual.UseVisualStyleBackColor = true;
            this.ButtonEqual.Click += new System.EventHandler(this.ButtonClick);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ButtonAdd.Location = new System.Drawing.Point(374, 493);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(125, 75);
            this.ButtonAdd.TabIndex = 3;
            this.ButtonAdd.Text = "+";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonClick);
            // 
            // ButtonMinus
            // 
            this.ButtonMinus.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ButtonMinus.Location = new System.Drawing.Point(374, 418);
            this.ButtonMinus.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonMinus.Name = "ButtonMinus";
            this.ButtonMinus.Size = new System.Drawing.Size(125, 75);
            this.ButtonMinus.TabIndex = 4;
            this.ButtonMinus.Text = "-";
            this.ButtonMinus.UseVisualStyleBackColor = true;
            this.ButtonMinus.Click += new System.EventHandler(this.ButtonClick);
            // 
            // ButtonMultiply
            // 
            this.ButtonMultiply.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ButtonMultiply.Location = new System.Drawing.Point(374, 343);
            this.ButtonMultiply.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonMultiply.Name = "ButtonMultiply";
            this.ButtonMultiply.Size = new System.Drawing.Size(125, 75);
            this.ButtonMultiply.TabIndex = 5;
            this.ButtonMultiply.Text = "×";
            this.ButtonMultiply.UseVisualStyleBackColor = true;
            this.ButtonMultiply.Click += new System.EventHandler(this.ButtonClick);
            // 
            // ButtonDivide
            // 
            this.ButtonDivide.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ButtonDivide.Location = new System.Drawing.Point(374, 268);
            this.ButtonDivide.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonDivide.Name = "ButtonDivide";
            this.ButtonDivide.Size = new System.Drawing.Size(125, 75);
            this.ButtonDivide.TabIndex = 6;
            this.ButtonDivide.Text = "÷";
            this.ButtonDivide.UseVisualStyleBackColor = true;
            this.ButtonDivide.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Button0
            // 
            this.Button0.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button0.Location = new System.Drawing.Point(124, 568);
            this.Button0.Margin = new System.Windows.Forms.Padding(0);
            this.Button0.Name = "Button0";
            this.Button0.Size = new System.Drawing.Size(125, 75);
            this.Button0.TabIndex = 12;
            this.Button0.Text = "0";
            this.Button0.UseVisualStyleBackColor = true;
            this.Button0.Click += new System.EventHandler(this.ButtonClick);
            // 
            // ButtonDot
            // 
            this.ButtonDot.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ButtonDot.Location = new System.Drawing.Point(249, 568);
            this.ButtonDot.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonDot.Name = "ButtonDot";
            this.ButtonDot.Size = new System.Drawing.Size(125, 75);
            this.ButtonDot.TabIndex = 11;
            this.ButtonDot.Text = ".";
            this.ButtonDot.UseVisualStyleBackColor = true;
            this.ButtonDot.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button2.Location = new System.Drawing.Point(124, 493);
            this.Button2.Margin = new System.Windows.Forms.Padding(0);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(125, 75);
            this.Button2.TabIndex = 15;
            this.Button2.Text = "2";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button3.Location = new System.Drawing.Point(249, 493);
            this.Button3.Margin = new System.Windows.Forms.Padding(0);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(125, 75);
            this.Button3.TabIndex = 14;
            this.Button3.Text = "3";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button1.Location = new System.Drawing.Point(-1, 493);
            this.Button1.Margin = new System.Windows.Forms.Padding(0);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(125, 75);
            this.Button1.TabIndex = 13;
            this.Button1.Text = "1";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Button5
            // 
            this.Button5.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button5.Location = new System.Drawing.Point(124, 418);
            this.Button5.Margin = new System.Windows.Forms.Padding(0);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(125, 75);
            this.Button5.TabIndex = 19;
            this.Button5.Text = "5";
            this.Button5.UseVisualStyleBackColor = true;
            this.Button5.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Button6
            // 
            this.Button6.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button6.Location = new System.Drawing.Point(249, 418);
            this.Button6.Margin = new System.Windows.Forms.Padding(0);
            this.Button6.Name = "Button6";
            this.Button6.Size = new System.Drawing.Size(125, 75);
            this.Button6.TabIndex = 18;
            this.Button6.Text = "6";
            this.Button6.UseVisualStyleBackColor = true;
            this.Button6.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Button4
            // 
            this.Button4.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button4.Location = new System.Drawing.Point(-1, 418);
            this.Button4.Margin = new System.Windows.Forms.Padding(0);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(125, 75);
            this.Button4.TabIndex = 17;
            this.Button4.Text = "4";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Button8
            // 
            this.Button8.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button8.Location = new System.Drawing.Point(124, 343);
            this.Button8.Margin = new System.Windows.Forms.Padding(0);
            this.Button8.Name = "Button8";
            this.Button8.Size = new System.Drawing.Size(125, 75);
            this.Button8.TabIndex = 23;
            this.Button8.Text = "8";
            this.Button8.UseVisualStyleBackColor = true;
            this.Button8.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Button9
            // 
            this.Button9.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button9.Location = new System.Drawing.Point(249, 343);
            this.Button9.Margin = new System.Windows.Forms.Padding(0);
            this.Button9.Name = "Button9";
            this.Button9.Size = new System.Drawing.Size(125, 75);
            this.Button9.TabIndex = 22;
            this.Button9.Text = "9";
            this.Button9.UseVisualStyleBackColor = true;
            this.Button9.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Button7
            // 
            this.Button7.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button7.Location = new System.Drawing.Point(-1, 343);
            this.Button7.Margin = new System.Windows.Forms.Padding(0);
            this.Button7.Name = "Button7";
            this.Button7.Size = new System.Drawing.Size(125, 75);
            this.Button7.TabIndex = 21;
            this.Button7.Text = "7";
            this.Button7.UseVisualStyleBackColor = true;
            this.Button7.Click += new System.EventHandler(this.ButtonClick);
            // 
            // RichTextBoxCur
            // 
            this.RichTextBoxCurrent.Font = new System.Drawing.Font("新細明體", 18F);
            this.RichTextBoxCurrent.Location = new System.Drawing.Point(-1, 153);
            this.RichTextBoxCurrent.Name = "RichTextBoxCur";
            this.RichTextBoxCurrent.ReadOnly = true;
            this.RichTextBoxCurrent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichTextBoxCurrent.Size = new System.Drawing.Size(499, 112);
            this.RichTextBoxCurrent.TabIndex = 24;
            this.RichTextBoxCurrent.Text = "";
            // 
            // RichTextBoxPrev
            // 
            this.RichTextBoxPrevious.Font = new System.Drawing.Font("新細明體", 12F);
            this.RichTextBoxPrevious.Location = new System.Drawing.Point(0, 51);
            this.RichTextBoxPrevious.Name = "RichTextBoxPrev";
            this.RichTextBoxPrevious.ReadOnly = true;
            this.RichTextBoxPrevious.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RichTextBoxPrevious.Size = new System.Drawing.Size(499, 70);
            this.RichTextBoxPrevious.TabIndex = 25;
            this.RichTextBoxPrevious.Text = "";
            // 
            // ButtonC
            // 
            this.ButtonC.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ButtonC.Location = new System.Drawing.Point(124, 268);
            this.ButtonC.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonC.Name = "ButtonC";
            this.ButtonC.Size = new System.Drawing.Size(125, 75);
            this.ButtonC.TabIndex = 27;
            this.ButtonC.Text = "C";
            this.ButtonC.UseVisualStyleBackColor = true;
            this.ButtonC.Click += new System.EventHandler(this.ButtonClick);
            // 
            // ButtonCE
            // 
            this.ButtonCE.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ButtonCE.Location = new System.Drawing.Point(-1, 268);
            this.ButtonCE.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonCE.Name = "ButtonCE";
            this.ButtonCE.Size = new System.Drawing.Size(125, 75);
            this.ButtonCE.TabIndex = 28;
            this.ButtonCE.Text = "CE";
            this.ButtonCE.UseVisualStyleBackColor = true;
            this.ButtonCE.Click += new System.EventHandler(this.ButtonClick);
            // 
            // ButtonDel
            // 
            this.ButtonDel.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.ButtonDel.Location = new System.Drawing.Point(249, 267);
            this.ButtonDel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonDel.Name = "ButtonDel";
            this.ButtonDel.Size = new System.Drawing.Size(125, 75);
            this.ButtonDel.TabIndex = 29;
            this.ButtonDel.Text = "Del";
            this.ButtonDel.UseVisualStyleBackColor = true;
            this.ButtonDel.Click += new System.EventHandler(this.ButtonClick);
            // 
            // ButtonNegate
            // 
            this.ButtonNegate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ButtonNegate.Location = new System.Drawing.Point(-1, 568);
            this.ButtonNegate.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonNegate.Name = "ButtonNegate";
            this.ButtonNegate.Size = new System.Drawing.Size(125, 75);
            this.ButtonNegate.TabIndex = 30;
            this.ButtonNegate.Text = "+/-";
            this.ButtonNegate.UseVisualStyleBackColor = true;
            this.ButtonNegate.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 645);
            this.Controls.Add(this.ButtonNegate);
            this.Controls.Add(this.ButtonDel);
            this.Controls.Add(this.ButtonCE);
            this.Controls.Add(this.ButtonC);
            this.Controls.Add(this.RichTextBoxPrevious);
            this.Controls.Add(this.RichTextBoxCurrent);
            this.Controls.Add(this.Button0);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.Button5);
            this.Controls.Add(this.Button6);
            this.Controls.Add(this.Button7);
            this.Controls.Add(this.Button8);
            this.Controls.Add(this.Button9);
            this.Controls.Add(this.ButtonDot);
            this.Controls.Add(this.ButtonDivide);
            this.Controls.Add(this.ButtonMultiply);
            this.Controls.Add(this.ButtonMinus);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonEqual);
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonEqual;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonMinus;
        private System.Windows.Forms.Button ButtonMultiply;
        private System.Windows.Forms.Button ButtonDivide;
        private System.Windows.Forms.Button ButtonDot;

        private System.Windows.Forms.Button Button0;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Button Button3;
        private System.Windows.Forms.Button Button4;
        private System.Windows.Forms.Button Button5;
        private System.Windows.Forms.Button Button6;
        private System.Windows.Forms.Button Button7;
        private System.Windows.Forms.Button Button8;
        private System.Windows.Forms.Button Button9;
        public System.Windows.Forms.RichTextBox RichTextBoxCurrent { get; private set; }
        public System.Windows.Forms.RichTextBox RichTextBoxPrevious { get; private set; }
        private System.Windows.Forms.Button ButtonC;
        private System.Windows.Forms.Button ButtonCE;
        private System.Windows.Forms.Button ButtonDel;
        private System.Windows.Forms.Button ButtonNegate;
    }
}
