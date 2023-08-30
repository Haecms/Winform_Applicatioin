namespace FormList
{
    partial class UserMaster
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
            this.tboxUser = new System.Windows.Forms.TextBox();
            this.tboxUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbboxDepart = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnGridAdd = new System.Windows.Forms.Button();
            this.btnGridDelete = new System.Windows.Forms.Button();
            this.btnGridSave = new System.Windows.Forms.Button();
            this.gbox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.GroupBox();
            this.pboxPicture = new System.Windows.Forms.PictureBox();
            this.btnImageDelete = new System.Windows.Forms.Button();
            this.btnImageSave = new System.Windows.Forms.Button();
            this.btnImageCall = new System.Windows.Forms.Button();
            this.dgtGRid = new System.Windows.Forms.DataGridView();
            this.gbox1.SuspendLayout();
            this.btnDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgtGRid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "사용자";
            // 
            // tboxUser
            // 
            this.tboxUser.Location = new System.Drawing.Point(93, 54);
            this.tboxUser.Name = "tboxUser";
            this.tboxUser.Size = new System.Drawing.Size(160, 25);
            this.tboxUser.TabIndex = 1;
            // 
            // tboxUserName
            // 
            this.tboxUserName.Location = new System.Drawing.Point(368, 54);
            this.tboxUserName.Name = "tboxUserName";
            this.tboxUserName.Size = new System.Drawing.Size(160, 25);
            this.tboxUserName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "사용자 이름";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(569, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "부서";
            // 
            // cbboxDepart
            // 
            this.cbboxDepart.FormattingEnabled = true;
            this.cbboxDepart.Location = new System.Drawing.Point(620, 54);
            this.cbboxDepart.Name = "cbboxDepart";
            this.cbboxDepart.Size = new System.Drawing.Size(176, 23);
            this.cbboxDepart.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("굴림", 15F);
            this.btnSearch.Location = new System.Drawing.Point(818, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 79);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnGridAdd
            // 
            this.btnGridAdd.Location = new System.Drawing.Point(23, 26);
            this.btnGridAdd.Name = "btnGridAdd";
            this.btnGridAdd.Size = new System.Drawing.Size(101, 49);
            this.btnGridAdd.TabIndex = 7;
            this.btnGridAdd.Text = "추가";
            this.btnGridAdd.UseVisualStyleBackColor = true;
            this.btnGridAdd.Click += new System.EventHandler(this.btnGridAdd_Click);
            // 
            // btnGridDelete
            // 
            this.btnGridDelete.Location = new System.Drawing.Point(156, 26);
            this.btnGridDelete.Name = "btnGridDelete";
            this.btnGridDelete.Size = new System.Drawing.Size(101, 49);
            this.btnGridDelete.TabIndex = 8;
            this.btnGridDelete.Text = "삭제";
            this.btnGridDelete.UseVisualStyleBackColor = true;
            this.btnGridDelete.Click += new System.EventHandler(this.btnGridDelete_Click);
            // 
            // btnGridSave
            // 
            this.btnGridSave.Location = new System.Drawing.Point(304, 26);
            this.btnGridSave.Name = "btnGridSave";
            this.btnGridSave.Size = new System.Drawing.Size(101, 49);
            this.btnGridSave.TabIndex = 9;
            this.btnGridSave.Text = "저장";
            this.btnGridSave.UseVisualStyleBackColor = true;
            this.btnGridSave.Click += new System.EventHandler(this.btnGridSave_Click);
            // 
            // gbox1
            // 
            this.gbox1.Controls.Add(this.btnSearch);
            this.gbox1.Controls.Add(this.cbboxDepart);
            this.gbox1.Controls.Add(this.label3);
            this.gbox1.Controls.Add(this.tboxUserName);
            this.gbox1.Controls.Add(this.label2);
            this.gbox1.Controls.Add(this.tboxUser);
            this.gbox1.Controls.Add(this.label1);
            this.gbox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbox1.Location = new System.Drawing.Point(0, 0);
            this.gbox1.Name = "gbox1";
            this.gbox1.Size = new System.Drawing.Size(1171, 119);
            this.gbox1.TabIndex = 11;
            this.gbox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Controls.Add(this.btnGridSave);
            this.btnDelete.Controls.Add(this.btnGridDelete);
            this.btnDelete.Controls.Add(this.btnGridAdd);
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.Location = new System.Drawing.Point(0, 119);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(1171, 95);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.TabStop = false;
            // 
            // pboxPicture
            // 
            this.pboxPicture.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pboxPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboxPicture.Location = new System.Drawing.Point(818, 197);
            this.pboxPicture.Name = "pboxPicture";
            this.pboxPicture.Size = new System.Drawing.Size(347, 235);
            this.pboxPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxPicture.TabIndex = 13;
            this.pboxPicture.TabStop = false;
            // 
            // btnImageDelete
            // 
            this.btnImageDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnImageDelete.Location = new System.Drawing.Point(1051, 455);
            this.btnImageDelete.Name = "btnImageDelete";
            this.btnImageDelete.Size = new System.Drawing.Size(108, 49);
            this.btnImageDelete.TabIndex = 10;
            this.btnImageDelete.Text = "삭제";
            this.btnImageDelete.UseVisualStyleBackColor = true;
            this.btnImageDelete.Click += new System.EventHandler(this.btnImageDelete_Click);
            // 
            // btnImageSave
            // 
            this.btnImageSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnImageSave.Location = new System.Drawing.Point(940, 455);
            this.btnImageSave.Name = "btnImageSave";
            this.btnImageSave.Size = new System.Drawing.Size(108, 49);
            this.btnImageSave.TabIndex = 11;
            this.btnImageSave.Text = "저장";
            this.btnImageSave.UseVisualStyleBackColor = true;
            this.btnImageSave.Click += new System.EventHandler(this.btnImageSave_Click);
            // 
            // btnImageCall
            // 
            this.btnImageCall.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnImageCall.Location = new System.Drawing.Point(828, 455);
            this.btnImageCall.Name = "btnImageCall";
            this.btnImageCall.Size = new System.Drawing.Size(108, 49);
            this.btnImageCall.TabIndex = 12;
            this.btnImageCall.Text = "불러오기";
            this.btnImageCall.UseVisualStyleBackColor = true;
            this.btnImageCall.Click += new System.EventHandler(this.btnImageCall_Click);
            // 
            // dgtGRid
            // 
            this.dgtGRid.AllowUserToAddRows = false;
            this.dgtGRid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgtGRid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgtGRid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgtGRid.Location = new System.Drawing.Point(0, 211);
            this.dgtGRid.Name = "dgtGRid";
            this.dgtGRid.RowHeadersWidth = 51;
            this.dgtGRid.RowTemplate.Height = 27;
            this.dgtGRid.Size = new System.Drawing.Size(818, 345);
            this.dgtGRid.TabIndex = 10;
            this.dgtGRid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgtGRid_CellClick);
            // 
            // UserMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 758);
            this.Controls.Add(this.btnImageDelete);
            this.Controls.Add(this.pboxPicture);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnImageSave);
            this.Controls.Add(this.btnImageCall);
            this.Controls.Add(this.gbox1);
            this.Controls.Add(this.dgtGRid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserMaster";
            this.Text = "추가";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserMaster_Load);
            this.gbox1.ResumeLayout(false);
            this.gbox1.PerformLayout();
            this.btnDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgtGRid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxUser;
        private System.Windows.Forms.TextBox tboxUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbboxDepart;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnGridAdd;
        private System.Windows.Forms.Button btnGridDelete;
        private System.Windows.Forms.Button btnGridSave;
        private System.Windows.Forms.GroupBox gbox1;
        private System.Windows.Forms.GroupBox btnDelete;
        private System.Windows.Forms.PictureBox pboxPicture;
        private System.Windows.Forms.Button btnImageDelete;
        private System.Windows.Forms.Button btnImageSave;
        private System.Windows.Forms.Button btnImageCall;
        private System.Windows.Forms.DataGridView dgtGRid;
    }
}