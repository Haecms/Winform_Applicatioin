namespace MainForms
{
    partial class Login
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
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnPassWordChg = new System.Windows.Forms.Button();
            this.btnUserReg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(102, 22);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(206, 21);
            this.txtUserId.TabIndex = 0;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(102, 62);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(206, 21);
            this.txtPassWord.TabIndex = 1;
            this.txtPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassWord_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "사용자 ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "PASSWORD";
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(116, 98);
            this.btnLogIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(81, 57);
            this.btnLogIn.TabIndex = 4;
            this.btnLogIn.Text = "로그인";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnPassWordChg
            // 
            this.btnPassWordChg.Location = new System.Drawing.Point(203, 98);
            this.btnPassWordChg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPassWordChg.Name = "btnPassWordChg";
            this.btnPassWordChg.Size = new System.Drawing.Size(105, 57);
            this.btnPassWordChg.TabIndex = 5;
            this.btnPassWordChg.Text = "비밀번호변경";
            this.btnPassWordChg.UseVisualStyleBackColor = true;
            this.btnPassWordChg.Click += new System.EventHandler(this.btnPassWordChg_Click);
            // 
            // btnUserReg
            // 
            this.btnUserReg.Location = new System.Drawing.Point(29, 98);
            this.btnUserReg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUserReg.Name = "btnUserReg";
            this.btnUserReg.Size = new System.Drawing.Size(81, 57);
            this.btnUserReg.TabIndex = 6;
            this.btnUserReg.Text = "회원 가입";
            this.btnUserReg.UseVisualStyleBackColor = true;
            this.btnUserReg.Click += new System.EventHandler(this.btnUserReg_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 177);
            this.Controls.Add(this.btnUserReg);
            this.Controls.Add(this.btnPassWordChg);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserId);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.Text = "로그인";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnPassWordChg;
        private System.Windows.Forms.Button btnUserReg;
    }
}