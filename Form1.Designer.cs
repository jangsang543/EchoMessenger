    namespace EchoMessenger
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
            lblTitle = new Label();
            txtStr = new TextBox();
            lstMsg = new ListBox();
            btnSend = new Button();
            lblCount = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("궁서체", 40F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTitle.ForeColor = Color.Blue;
            lblTitle.Location = new Point(71, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(608, 80);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Echo Messenger";
            // 
            // txtStr
            // 
            txtStr.Location = new Point(71, 559);
            txtStr.Name = "txtStr";
            txtStr.Size = new Size(759, 31);
            txtStr.TabIndex = 1;
            txtStr.TextChanged += textBox1_TextChanged;
            txtStr.KeyDown += txtStr_KeyDown;
            // 
            // lstMsg
            // 
            lstMsg.FormattingEnabled = true;
            lstMsg.ItemHeight = 25;
            lstMsg.Location = new Point(71, 123);
            lstMsg.Name = "lstMsg";
            lstMsg.Size = new Size(947, 354);
            lstMsg.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(128, 255, 255);
            btnSend.Font = new Font("휴먼모음T", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnSend.ForeColor = Color.Black;
            btnSend.Location = new Point(853, 513);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(196, 110);
            btnSend.TabIndex = 3;
            btnSend.Text = "전송";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblCount.ForeColor = Color.Black;
            lblCount.Location = new Point(71, 695);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(136, 28);
            lblCount.TabIndex = 4;
            lblCount.Text = "현재 대화: 0개";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            ClientSize = new Size(1305, 731);
            Controls.Add(lblCount);
            Controls.Add(btnSend);
            Controls.Add(lstMsg);
            Controls.Add(txtStr);
            Controls.Add(lblTitle);
            ForeColor = Color.RoyalBlue;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtStr;
        private ListBox lstMsg;
        private Button btnSend;
        private Label lblCount;
    }
}
