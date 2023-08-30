namespace Mainforms
{
    partial class LogIn
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
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnPWChange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.btnUserReg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(137, 137);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(104, 85);
            this.btnLogIn.TabIndex = 0;
            this.btnLogIn.Text = "로그인";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnPWChange
            // 
            this.btnPWChange.Location = new System.Drawing.Point(260, 137);
            this.btnPWChange.Name = "btnPWChange";
            this.btnPWChange.Size = new System.Drawing.Size(95, 85);
            this.btnPWChange.TabIndex = 1;
            this.btnPWChange.Text = "비밀번호변경";
            this.btnPWChange.UseVisualStyleBackColor = true;
            this.btnPWChange.Click += new System.EventHandler(this.btnPWChange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "PASSWORD";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(148, 36);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(141, 25);
            this.txtUserName.TabIndex = 4;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(148, 72);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(141, 25);
            this.txtPassWord.TabIndex = 5;
            this.txtPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassWord_KeyDown);
            // 
            // btnUserReg
            // 
            this.btnUserReg.Location = new System.Drawing.Point(25, 137);
            this.btnUserReg.Name = "btnUserReg";
            this.btnUserReg.Size = new System.Drawing.Size(95, 85);
            this.btnUserReg.TabIndex = 6;
            this.btnUserReg.Text = "회원가입";
            this.btnUserReg.UseVisualStyleBackColor = true;
            this.btnUserReg.Click += new System.EventHandler(this.btnUserReg_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 272);
            this.Controls.Add(this.btnUserReg);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPWChange);
            this.Controls.Add(this.btnLogIn);
            this.Name = "LogIn";
            this.Text = "로그인";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnPWChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Button btnUserReg;
    }
}