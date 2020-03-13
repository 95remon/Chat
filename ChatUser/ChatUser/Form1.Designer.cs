namespace ChatUser
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
            this.txtEmailReg = new System.Windows.Forms.TextBox();
            this.txtPasswordReg = new System.Windows.Forms.TextBox();
            this.txtPhoneReg = new System.Windows.Forms.TextBox();
            this.txtPasswordLog = new System.Windows.Forms.TextBox();
            this.txtEmailLog = new System.Windows.Forms.TextBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.labEmailReg = new System.Windows.Forms.Label();
            this.labPasswordReg = new System.Windows.Forms.Label();
            this.labPhoneReg = new System.Windows.Forms.Label();
            this.labEmailLog = new System.Windows.Forms.Label();
            this.labPasswordLog = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEmailReg
            // 
            this.txtEmailReg.Location = new System.Drawing.Point(160, 104);
            this.txtEmailReg.Name = "txtEmailReg";
            this.txtEmailReg.Size = new System.Drawing.Size(100, 20);
            this.txtEmailReg.TabIndex = 0;
            // 
            // txtPasswordReg
            // 
            this.txtPasswordReg.Location = new System.Drawing.Point(160, 188);
            this.txtPasswordReg.Name = "txtPasswordReg";
            this.txtPasswordReg.Size = new System.Drawing.Size(100, 20);
            this.txtPasswordReg.TabIndex = 1;
            // 
            // txtPhoneReg
            // 
            this.txtPhoneReg.Location = new System.Drawing.Point(160, 261);
            this.txtPhoneReg.Name = "txtPhoneReg";
            this.txtPhoneReg.Size = new System.Drawing.Size(100, 20);
            this.txtPhoneReg.TabIndex = 2;
            // 
            // txtPasswordLog
            // 
            this.txtPasswordLog.Location = new System.Drawing.Point(578, 189);
            this.txtPasswordLog.Name = "txtPasswordLog";
            this.txtPasswordLog.Size = new System.Drawing.Size(100, 20);
            this.txtPasswordLog.TabIndex = 4;
            // 
            // txtEmailLog
            // 
            this.txtEmailLog.Location = new System.Drawing.Point(578, 105);
            this.txtEmailLog.Name = "txtEmailLog";
            this.txtEmailLog.Size = new System.Drawing.Size(100, 20);
            this.txtEmailLog.TabIndex = 3;
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(176, 375);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 23);
            this.btnReg.TabIndex = 5;
            this.btnReg.Text = "Registration";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(603, 375);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(75, 23);
            this.btnLog.TabIndex = 6;
            this.btnLog.Text = "Login";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // labEmailReg
            // 
            this.labEmailReg.AutoSize = true;
            this.labEmailReg.Location = new System.Drawing.Point(29, 111);
            this.labEmailReg.Name = "labEmailReg";
            this.labEmailReg.Size = new System.Drawing.Size(31, 13);
            this.labEmailReg.TabIndex = 7;
            this.labEmailReg.Text = "Email";
            // 
            // labPasswordReg
            // 
            this.labPasswordReg.AutoSize = true;
            this.labPasswordReg.Location = new System.Drawing.Point(29, 195);
            this.labPasswordReg.Name = "labPasswordReg";
            this.labPasswordReg.Size = new System.Drawing.Size(53, 13);
            this.labPasswordReg.TabIndex = 8;
            this.labPasswordReg.Text = "Password";
            // 
            // labPhoneReg
            // 
            this.labPhoneReg.AutoSize = true;
            this.labPhoneReg.Location = new System.Drawing.Point(29, 268);
            this.labPhoneReg.Name = "labPhoneReg";
            this.labPhoneReg.Size = new System.Drawing.Size(37, 13);
            this.labPhoneReg.TabIndex = 9;
            this.labPhoneReg.Text = "Phone";
            // 
            // labEmailLog
            // 
            this.labEmailLog.AutoSize = true;
            this.labEmailLog.Location = new System.Drawing.Point(471, 112);
            this.labEmailLog.Name = "labEmailLog";
            this.labEmailLog.Size = new System.Drawing.Size(31, 13);
            this.labEmailLog.TabIndex = 10;
            this.labEmailLog.Text = "Email";
            // 
            // labPasswordLog
            // 
            this.labPasswordLog.AutoSize = true;
            this.labPasswordLog.Location = new System.Drawing.Point(471, 196);
            this.labPasswordLog.Name = "labPasswordLog";
            this.labPasswordLog.Size = new System.Drawing.Size(53, 13);
            this.labPasswordLog.TabIndex = 11;
            this.labPasswordLog.Text = "Password";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 450);
            this.Controls.Add(this.labPasswordLog);
            this.Controls.Add(this.labEmailLog);
            this.Controls.Add(this.labPhoneReg);
            this.Controls.Add(this.labPasswordReg);
            this.Controls.Add(this.labEmailReg);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.txtPasswordLog);
            this.Controls.Add(this.txtEmailLog);
            this.Controls.Add(this.txtPhoneReg);
            this.Controls.Add(this.txtPasswordReg);
            this.Controls.Add(this.txtEmailReg);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmailReg;
        private System.Windows.Forms.TextBox txtPasswordReg;
        private System.Windows.Forms.TextBox txtPhoneReg;
        private System.Windows.Forms.TextBox txtPasswordLog;
        private System.Windows.Forms.TextBox txtEmailLog;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Label labEmailReg;
        private System.Windows.Forms.Label labPasswordReg;
        private System.Windows.Forms.Label labPhoneReg;
        private System.Windows.Forms.Label labEmailLog;
        private System.Windows.Forms.Label labPasswordLog;
    }
}

