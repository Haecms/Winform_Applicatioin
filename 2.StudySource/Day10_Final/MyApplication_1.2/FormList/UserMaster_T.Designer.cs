namespace FormList
{
    partial class UserMaster_T
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.myGrid1 = new Services.MyGrid();
            this.cboDept1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserId1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.myGrid2 = new Services.MyGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDept1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUserName1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUserId1);
            this.groupBox1.Controls.Add(this.label6);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myGrid2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "사용자 ID";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(122, 50);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(100, 25);
            this.txtUserId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "사용자명";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(349, 50);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 25);
            this.txtUserName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(506, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "관리 부서";
            // 
            // cboDept
            // 
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(584, 50);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(121, 23);
            this.cboDept.TabIndex = 2;
            // 
            // myGrid1
            // 
            this.myGrid1.AllowUserToAddRows = false;
            this.myGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGrid1.Location = new System.Drawing.Point(3, 21);
            this.myGrid1.Name = "myGrid1";
            this.myGrid1.RowHeadersWidth = 51;
            this.myGrid1.RowTemplate.Height = 27;
            this.myGrid1.Size = new System.Drawing.Size(967, 582);
            this.myGrid1.TabIndex = 0;
            // 
            // cboDept1
            // 
            this.cboDept1.FormattingEnabled = true;
            this.cboDept1.Location = new System.Drawing.Point(695, 48);
            this.cboDept1.Name = "cboDept1";
            this.cboDept1.Size = new System.Drawing.Size(121, 23);
            this.cboDept1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(617, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "관리 부서";
            // 
            // txtUserName1
            // 
            this.txtUserName1.Location = new System.Drawing.Point(460, 48);
            this.txtUserName1.Name = "txtUserName1";
            this.txtUserName1.Size = new System.Drawing.Size(100, 25);
            this.txtUserName1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "사용자명";
            // 
            // txtUserId1
            // 
            this.txtUserId1.Location = new System.Drawing.Point(233, 48);
            this.txtUserId1.Name = "txtUserId1";
            this.txtUserId1.Size = new System.Drawing.Size(100, 25);
            this.txtUserId1.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "사용자 ID";
            // 
            // myGrid2
            // 
            this.myGrid2.AllowUserToAddRows = false;
            this.myGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGrid2.Location = new System.Drawing.Point(3, 21);
            this.myGrid2.Name = "myGrid2";
            this.myGrid2.RowHeadersWidth = 51;
            this.myGrid2.RowTemplate.Height = 27;
            this.myGrid2.Size = new System.Drawing.Size(967, 582);
            this.myGrid2.TabIndex = 0;
            // 
            // UserMaster_T
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(973, 726);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "UserMaster_T";
            this.Text = "사용자마스터_T";
            this.Load += new System.EventHandler(this.UserMaster_T_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGrid2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserId;
        public Services.MyGrid myGrid1;
        private System.Windows.Forms.ComboBox cboDept1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserId1;
        private System.Windows.Forms.Label label6;
        private Services.MyGrid myGrid2;
    }
}
