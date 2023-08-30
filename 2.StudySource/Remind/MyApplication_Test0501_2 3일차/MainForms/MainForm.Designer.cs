namespace MainForms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSearch = new System.Windows.Forms.ToolStripButton();
            this.tsAdd = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsClose = new System.Windows.Forms.ToolStripButton();
            this.tsExit = new System.Windows.Forms.ToolStripButton();
            this.tssFormName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssNowDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.NowTime = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSearch,
            this.tsAdd,
            this.tsDelete,
            this.tsSave,
            this.toolStripSeparator1,
            this.tsClose,
            this.tsExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 100);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssFormName,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.tssNowDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 100);
            // 
            // tsSearch
            // 
            this.tsSearch.Image = global::MainForms.Properties.Resources.BtnSearch;
            this.tsSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSearch.Name = "tsSearch";
            this.tsSearch.Size = new System.Drawing.Size(54, 97);
            this.tsSearch.Text = "조회";
            this.tsSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsAdd
            // 
            this.tsAdd.Image = global::MainForms.Properties.Resources.BtnAdd;
            this.tsAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(54, 97);
            this.tsAdd.Text = "추가";
            this.tsAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsDelete
            // 
            this.tsDelete.Image = global::MainForms.Properties.Resources.BtnDelete;
            this.tsDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(54, 97);
            this.tsDelete.Text = "삭제";
            this.tsDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsSave
            // 
            this.tsSave.Image = global::MainForms.Properties.Resources.BtnSaveB;
            this.tsSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(54, 97);
            this.tsSave.Text = "저장";
            this.tsSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsClose
            // 
            this.tsClose.Image = global::MainForms.Properties.Resources.BtnClose;
            this.tsClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsClose.Name = "tsClose";
            this.tsClose.Size = new System.Drawing.Size(54, 97);
            this.tsClose.Text = "닫기";
            this.tsClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsExit
            // 
            this.tsExit.Image = global::MainForms.Properties.Resources.BtcExit;
            this.tsExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(54, 97);
            this.tsExit.Text = "종료";
            this.tsExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // tssFormName
            // 
            this.tssFormName.Name = "tssFormName";
            this.tssFormName.Size = new System.Drawing.Size(83, 20);
            this.tssFormName.Text = "FormName";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(198, 20);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(152, 20);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(152, 20);
            this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
            // 
            // tssNowDate
            // 
            this.tssNowDate.AutoSize = false;
            this.tssNowDate.Name = "tssNowDate";
            this.tssNowDate.Size = new System.Drawing.Size(200, 20);
            this.tssNowDate.Text = "DateTime";
            // 
            // NowTime
            // 
            this.NowTime.Interval = 1000;
            this.NowTime.Tick += new System.EventHandler(this.NowTime_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "EZ DEV 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsSearch;
        private System.Windows.Forms.ToolStripButton tsAdd;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsClose;
        private System.Windows.Forms.ToolStripButton tsExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssFormName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tssNowDate;
        private System.Windows.Forms.Timer NowTime;
    }
}