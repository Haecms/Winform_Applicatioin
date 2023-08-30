namespace MyFirstCSharp.Lesson05
{
    partial class Chap33_ProPerty
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
            this.btnSalesBook = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBookStock = new System.Windows.Forms.Label();
            this.btnBookStock = new System.Windows.Forms.Button();
            this.txtBookInCNT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSalesBook
            // 
            this.btnSalesBook.Location = new System.Drawing.Point(251, 53);
            this.btnSalesBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalesBook.Name = "btnSalesBook";
            this.btnSalesBook.Size = new System.Drawing.Size(156, 28);
            this.btnSalesBook.TabIndex = 0;
            this.btnSalesBook.Text = "만화책 판매";
            this.btnSalesBook.UseVisualStyleBackColor = true;
            this.btnSalesBook.Click += new System.EventHandler(this.btnSalesBook_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "현재 재고 량";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "개";
            // 
            // lblBookStock
            // 
            this.lblBookStock.AutoSize = true;
            this.lblBookStock.Location = new System.Drawing.Point(352, 28);
            this.lblBookStock.Name = "lblBookStock";
            this.lblBookStock.Size = new System.Drawing.Size(11, 12);
            this.lblBookStock.TabIndex = 3;
            this.lblBookStock.Text = "0";
            // 
            // btnBookStock
            // 
            this.btnBookStock.Location = new System.Drawing.Point(21, 53);
            this.btnBookStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBookStock.Name = "btnBookStock";
            this.btnBookStock.Size = new System.Drawing.Size(156, 28);
            this.btnBookStock.TabIndex = 4;
            this.btnBookStock.Text = "입고";
            this.btnBookStock.UseVisualStyleBackColor = true;
            this.btnBookStock.Click += new System.EventHandler(this.btnBookStock_Click);
            // 
            // txtBookInCNT
            // 
            this.txtBookInCNT.Location = new System.Drawing.Point(21, 20);
            this.txtBookInCNT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBookInCNT.Name = "txtBookInCNT";
            this.txtBookInCNT.Size = new System.Drawing.Size(132, 21);
            this.txtBookInCNT.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "개";
            // 
            // Chap33_ProPerty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 102);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBookInCNT);
            this.Controls.Add(this.btnBookStock);
            this.Controls.Add(this.lblBookStock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalesBook);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Chap33_ProPerty";
            this.Text = "Chap15_ProPerty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalesBook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBookStock;
        private System.Windows.Forms.Button btnBookStock;
        private System.Windows.Forms.TextBox txtBookInCNT;
        private System.Windows.Forms.Label label4;
    }
}