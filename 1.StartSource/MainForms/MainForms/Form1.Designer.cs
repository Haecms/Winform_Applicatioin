namespace MainForms
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tboxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHello = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tboxName
            // 
            this.tboxName.Location = new System.Drawing.Point(80, 47);
            this.tboxName.Name = "tboxName";
            this.tboxName.Size = new System.Drawing.Size(601, 25);
            this.tboxName.TabIndex = 0;
            this.tboxName.Text = "고티카";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "이름";
            // 
            // btnHello
            // 
            this.btnHello.Location = new System.Drawing.Point(219, 89);
            this.btnHello.Name = "btnHello";
            this.btnHello.Size = new System.Drawing.Size(294, 82);
            this.btnHello.TabIndex = 2;
            this.btnHello.Text = "인사하기";
            this.btnHello.UseVisualStyleBackColor = true;
            this.btnHello.Click += new System.EventHandler(this.btnHello_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 497);
            this.Controls.Add(this.btnHello);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHello;
    }
}

