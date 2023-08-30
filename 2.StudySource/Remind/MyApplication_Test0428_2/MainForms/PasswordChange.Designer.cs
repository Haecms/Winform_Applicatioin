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
            this.label1.Location = new System.Drawing.Point(44, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(75, 14);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(217, 25);
            this.txtUserId.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "현재PW";
            // 
            // txtNowPw
            // 
            this.txtNowPw.Location = new System.Drawing.Point(75, 45);
            this.txtNowPw.Name = "txtNowPw";
            this.txtNowPw.Size = new System.Drawing.Size(217, 25);
            this.txtNowPw.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "변경PW";
            // 
            // txtChangePw
            // 
            this.txtChangePw.Location = new System.Drawing.Point(75, 76);
            this.txtChangePw.Name = "txtChangePw";
            this.txtChangePw.Size = new System.Drawing.Size(217, 25);
            this.txtChangePw.TabIndex = 2;
            // 
            // btnPwChange
            // 
            this.btnPwChange.Location = new System.Drawing.Point(165, 122);
            this.btnPwChange.Name = "btnPwChange";
            this.btnPwChange.Size = new System.Drawing.Size(127, 72);
            this.btnPwChange.TabIndex = 3;
            this.btnPwChange.Text = "비밀번호 변경";
            this.btnPwChange.UseVisualStyleBackColor = true;
            this.btnPwChange.Click += new System.EventHandler(this.btnPwChange_Click);
            this.btnPwChange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnPwChange_KeyDown);
            // 
            // PasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 208);
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