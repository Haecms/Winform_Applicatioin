namespace FormList
{
    partial class ProPerty
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
            this.btnIn = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStock);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtInQty);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSale);
            this.groupBox2.Controls.Add(this.btnIn);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(22, 223);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(400, 111);
            this.btnIn.TabIndex = 0;
            this.btnIn.Text = "입고등록";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnSale
            // 
            this.btnSale.Location = new System.Drawing.Point(428, 223);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(400, 111);
            this.btnSale.TabIndex = 1;
            this.btnSale.Text = "판매등록";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(445, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "재고수량";
            // 
            // txtInQty
            // 
            this.txtInQty.Location = new System.Drawing.Point(251, 162);
            this.txtInQty.Name = "txtInQty";
            this.txtInQty.Size = new System.Drawing.Size(100, 25);
            this.txtInQty.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "입고수량";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(518, 168);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(0, 15);
            this.lblStock.TabIndex = 5;
            // 
            // ProPerty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(973, 726);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ProPerty";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSale;
    }
}
