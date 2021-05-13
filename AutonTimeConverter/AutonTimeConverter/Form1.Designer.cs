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
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "DateTime";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(15, 77);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(191, 20);
			this.textBox2.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(154, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "[Decimal] Seconds since 1980:";
			// 
			// textBoxDecimal
			// 
			this.textBoxDecimal.Location = new System.Drawing.Point(12, 31);
			this.textBoxDecimal.Name = "textBoxDecimal";
			this.textBoxDecimal.Size = new System.Drawing.Size(191, 20);
			this.textBoxDecimal.TabIndex = 5;
			this.textBoxDecimal.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(209, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(186, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "[HEX Little Endian (DCBA)] 8 symbols:";
			// 
			// textBoxHex
			// 
			this.textBoxHex.Location = new System.Drawing.Point(209, 31);
			this.textBoxHex.Name = "textBoxHex";
			this.textBoxHex.Size = new System.Drawing.Size(233, 20);
			this.textBoxHex.TabIndex = 9;
			this.textBoxHex.TextChanged += new System.EventHandler(this.textBoxHex_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(463, 126);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxHex);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxDecimal);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "Form1";
			this.Text = "AutonTimeConverter";
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
	}
}

