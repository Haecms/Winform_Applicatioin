namespace MainForms
{
    partial class PasswordChange
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNowPw = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChangePw = new System.Windows.Forms.TextBox();
            this.btnPwChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(59, 12);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(152, 21);
            this.txtUserId.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "현재PW";
            // 
            // txtNowPw
            // 
            this.txtNowPw.Location = new System.Drawing.Point(59, 39);
            this.txtNowPw.Name = "txtNowPw";
            this.txtNowPw.Size = new System.Drawing.Size(152, 21);
            this.txtNowPw.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "변경PW";
            // 
            // txtChangePw
            // 
            this.txtChangePw.Location = new System.Drawing.Point(59, 66);
            this.txtChangePw.Name = "txtChangePw";
            this.txtChangePw.Size = new System.Drawing.Size(152, 21);
            this.txtChangePw.TabIndex = 2;
            this.txtChangePw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChangePw_KeyDown);
            // 
            // btnPwChange
            // 
            this.btnPwChange.Location = new System.Drawing.Point(110, 99);
            this.btnPwChange.Name = "btnPwChange";
            this.btnPwChange.Size = new System.Drawing.Size(100, 63);
            this.btnPwChange.TabIndex = 3;
            this.btnPwChange.Text = "비밀번호 변경";
            this.btnPwChange.UseVisualStyleBackColor = true;
            this.btnPwChange.Click += new System.EventHandler(this.btnPwChange_Click);
            // 
            // PasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 180);
            this.Controls.Add(this.btnPwChange);
            this.Controls.Add(this.txtChangePw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNowPw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.label1);
            this.Name = "PasswordChange";
            this.Text = "비밀번호변경";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNowPw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChangePw;
        private System.Windows.Forms.Button btnPwChange;
    }
}