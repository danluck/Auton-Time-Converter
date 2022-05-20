namespace AutonTimeConverter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDecimal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxHex = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxCommon = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxWasChangedEvent = new System.Windows.Forms.GroupBox();
            this.textBoxWasChangedEventContainerClassId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxEventName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDateTimeString = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxClassId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBoxEventDataHex = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxHistory = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxWasChangedEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Output -> DateTime (String):";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(17, 78);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(191, 20);
            this.textBox2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Input -> [Decimal] Seconds since 1980:";
            // 
            // textBoxDecimal
            // 
            this.textBoxDecimal.Location = new System.Drawing.Point(15, 36);
            this.textBoxDecimal.Name = "textBoxDecimal";
            this.textBoxDecimal.Size = new System.Drawing.Size(191, 20);
            this.textBoxDecimal.TabIndex = 5;
            this.textBoxDecimal.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Input ->[HEX Little Endian (DCBA)] 8 symbols:";
            // 
            // textBoxHex
            // 
            this.textBoxHex.Location = new System.Drawing.Point(212, 36);
            this.textBoxHex.Name = "textBoxHex";
            this.textBoxHex.Size = new System.Drawing.Size(233, 20);
            this.textBoxHex.TabIndex = 9;
            this.textBoxHex.TextChanged += new System.EventHandler(this.textBoxHex_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxHex);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDecimal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 305);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 108);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DateTime Converter";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBoxCommon);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.groupBoxWasChangedEvent);
            this.groupBox2.Controls.Add(this.textBoxEventName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxDateTimeString);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.labelStatus);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxClassId);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.richTextBoxEventDataHex);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(654, 265);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Event Converter";
            // 
            // richTextBoxCommon
            // 
            this.richTextBoxCommon.Location = new System.Drawing.Point(9, 193);
            this.richTextBoxCommon.Name = "richTextBoxCommon";
            this.richTextBoxCommon.Size = new System.Drawing.Size(299, 66);
            this.richTextBoxCommon.TabIndex = 19;
            this.richTextBoxCommon.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Output -> Common";
            // 
            // groupBoxWasChangedEvent
            // 
            this.groupBoxWasChangedEvent.Controls.Add(this.textBoxWasChangedEventContainerClassId);
            this.groupBoxWasChangedEvent.Controls.Add(this.label9);
            this.groupBoxWasChangedEvent.Location = new System.Drawing.Point(314, 157);
            this.groupBoxWasChangedEvent.Name = "groupBoxWasChangedEvent";
            this.groupBoxWasChangedEvent.Size = new System.Drawing.Size(326, 83);
            this.groupBoxWasChangedEvent.TabIndex = 17;
            this.groupBoxWasChangedEvent.TabStop = false;
            this.groupBoxWasChangedEvent.Text = "WasChangedEvent";
            // 
            // textBoxWasChangedEventContainerClassId
            // 
            this.textBoxWasChangedEventContainerClassId.Location = new System.Drawing.Point(150, 13);
            this.textBoxWasChangedEventContainerClassId.Name = "textBoxWasChangedEventContainerClassId";
            this.textBoxWasChangedEventContainerClassId.Size = new System.Drawing.Size(98, 20);
            this.textBoxWasChangedEventContainerClassId.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Output -> ClassId (Decimal):";
            // 
            // textBoxEventName
            // 
            this.textBoxEventName.Location = new System.Drawing.Point(388, 131);
            this.textBoxEventName.Name = "textBoxEventName";
            this.textBoxEventName.Size = new System.Drawing.Size(176, 20);
            this.textBoxEventName.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Output -> ClassId (Name):";
            // 
            // textBoxDateTimeString
            // 
            this.textBoxDateTimeString.Location = new System.Drawing.Point(150, 157);
            this.textBoxDateTimeString.Name = "textBoxDateTimeString";
            this.textBoxDateTimeString.Size = new System.Drawing.Size(158, 20);
            this.textBoxDateTimeString.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Output -> DateTime (String):";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(52, 114);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(10, 13);
            this.labelStatus.TabIndex = 12;
            this.labelStatus.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Status:";
            // 
            // textBoxClassId
            // 
            this.textBoxClassId.Location = new System.Drawing.Point(150, 131);
            this.textBoxClassId.Name = "textBoxClassId";
            this.textBoxClassId.Size = new System.Drawing.Size(98, 20);
            this.textBoxClassId.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Output -> ClassId (Decimal):";
            // 
            // richTextBoxEventDataHex
            // 
            this.richTextBoxEventDataHex.Location = new System.Drawing.Point(6, 29);
            this.richTextBoxEventDataHex.Name = "richTextBoxEventDataHex";
            this.richTextBoxEventDataHex.Size = new System.Drawing.Size(642, 77);
            this.richTextBoxEventDataHex.TabIndex = 8;
            this.richTextBoxEventDataHex.Text = "";
            this.richTextBoxEventDataHex.TextChanged += new System.EventHandler(this.richTextBoxEventDataHex_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Input -> Hex data:";
            // 
            // richTextBoxHistory
            // 
            this.richTextBoxHistory.Location = new System.Drawing.Point(672, 22);
            this.richTextBoxHistory.Name = "richTextBoxHistory";
            this.richTextBoxHistory.Size = new System.Drawing.Size(437, 391);
            this.richTextBoxHistory.TabIndex = 13;
            this.richTextBoxHistory.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(672, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "History:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 425);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.richTextBoxHistory);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "AutonDataConverter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxWasChangedEvent.ResumeLayout(false);
            this.groupBoxWasChangedEvent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDecimal;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxHex;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBoxClassId;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RichTextBox richTextBoxEventDataHex;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxDateTimeString;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxEventName;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBoxWasChangedEvent;
		private System.Windows.Forms.TextBox textBoxWasChangedEventContainerClassId;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBoxCommon;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox richTextBoxHistory;
        private System.Windows.Forms.Label label11;
    }
}

