namespace ChatUser
{
    partial class InBoxUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelMember = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelMember
            // 
            this.labelMember.AutoSize = true;
            this.labelMember.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.labelMember.ForeColor = System.Drawing.Color.LightGray;
            this.labelMember.Location = new System.Drawing.Point(3, 5);
            this.labelMember.Name = "labelMember";
            this.labelMember.Size = new System.Drawing.Size(58, 19);
            this.labelMember.TabIndex = 0;
            this.labelMember.Text = "label1";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.ForeColor = System.Drawing.Color.LightGray;
            this.labelState.Location = new System.Drawing.Point(8, 29);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(53, 20);
            this.labelState.TabIndex = 3;
            this.labelState.Text = "label2";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.ForeColor = System.Drawing.Color.LightGray;
            this.labelDate.Location = new System.Drawing.Point(166, 5);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(53, 20);
            this.labelDate.TabIndex = 4;
            this.labelDate.Text = "label2";
            // 
            // InBoxUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.labelMember);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.Name = "InBoxUC";
            this.Size = new System.Drawing.Size(250, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMember;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Label labelDate;
    }
}
