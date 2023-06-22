namespace cs_form_230622_pdf
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PDF出力 = new Button();
            label1 = new Label();
            梅フォント = new ComboBox();
            SuspendLayout();
            // 
            // PDF出力
            // 
            PDF出力.Location = new Point(450, 51);
            PDF出力.Margin = new Padding(5, 6, 5, 6);
            PDF出力.Name = "PDF出力";
            PDF出力.Size = new Size(129, 46);
            PDF出力.TabIndex = 1;
            PDF出力.Text = "PDF出力";
            PDF出力.UseVisualStyleBackColor = true;
            PDF出力.Click += PDF出力_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 323);
            label1.Name = "label1";
            label1.Size = new Size(307, 30);
            label1.TabIndex = 2;
            label1.Text = "この Form : Yu Gothic UI, 15.75pt";
            // 
            // 梅フォント
            // 
            梅フォント.DropDownStyle = ComboBoxStyle.DropDownList;
            梅フォント.FormattingEnabled = true;
            梅フォント.Items.AddRange(new object[] { "梅Hyゴシック", "梅HyゴシックO5", "梅明朝" });
            梅フォント.Location = new Point(59, 56);
            梅フォント.Name = "梅フォント";
            梅フォント.Size = new Size(248, 38);
            梅フォント.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 379);
            Controls.Add(梅フォント);
            Controls.Add(label1);
            Controls.Add(PDF出力);
            Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button PDF出力;
        private Label label1;
        private ComboBox 梅フォント;
    }
}