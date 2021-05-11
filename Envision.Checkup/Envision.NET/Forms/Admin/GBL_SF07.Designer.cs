namespace RIS.Forms.Admin
{
    partial class GBL_SF07
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GBL_SF07));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.nEntryContainer10 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.nGrouper1 = new Nevron.UI.WinForm.Controls.NGrouper();
            this.grdObjects = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.Delete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Object_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Object_Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Object_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSubNameUser = new System.Windows.Forms.TextBox();
            this.lblSubName = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.txtSubUID = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lblSubUID = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.txtID = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtButton3Caption = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gBLSF07BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).BeginInit();
            this.nGrouper1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubUID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gBLSF07BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.nEntryContainer10);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.MyLookup_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Panel2.Controls.Add(this.nGrouper1);
            this.splitContainer1.Panel2.Controls.Add(this.txtID);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.MyLookup_Paint);
            this.splitContainer1.Panel2.Controls.Add(this.txtButton3Caption);
            this.splitContainer1.Size = new System.Drawing.Size(800, 448);
            this.splitContainer1.SplitterDistance = 212;
            this.splitContainer1.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtSearch.Location = new System.Drawing.Point(14, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(179, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Search";
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.treeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeView1.Location = new System.Drawing.Point(12, 62);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(181, 367);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // nEntryContainer10
            // 
            this.nEntryContainer10.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.nEntryContainer10.LabelSize = new System.Drawing.Size(70, 0);
            this.nEntryContainer10.Location = new System.Drawing.Point(7, 29);
            this.nEntryContainer10.Name = "nEntryContainer10";
            this.nEntryContainer10.Size = new System.Drawing.Size(194, 407);
            this.nEntryContainer10.StrokeInfo.Rounding = 5;
            this.nEntryContainer10.TabIndex = 138;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox2.Location = new System.Drawing.Point(231, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 164;
            this.textBox2.Visible = false;
            // 
            // nGrouper1
            // 
            this.nGrouper1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nGrouper1.Controls.Add(this.grdObjects);
            this.nGrouper1.Controls.Add(this.txtSubNameUser);
            this.nGrouper1.Controls.Add(this.lblSubName);
            this.nGrouper1.Controls.Add(this.txtSubUID);
            this.nGrouper1.Controls.Add(this.button2);
            this.nGrouper1.Controls.Add(this.bindingNavigator1);
            this.nGrouper1.Controls.Add(this.lblSubUID);
            this.nGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nGrouper1.FooterItem.Text = "Footer";
            this.nGrouper1.FooterItem.Visible = false;
            this.nGrouper1.HeaderItem.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular);
            this.nGrouper1.HeaderItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((byte)(255)), ((byte)(255)), ((byte)(255)), ((byte)(255))));
            this.nGrouper1.HeaderItem.Text = "Objects";
            this.nGrouper1.Location = new System.Drawing.Point(12, 29);
            this.nGrouper1.Name = "nGrouper1";
            this.nGrouper1.ShadowInfo.Draw = false;
            this.nGrouper1.Size = new System.Drawing.Size(550, 401);
            this.nGrouper1.TabIndex = 113;
            this.nGrouper1.Text = "nGrouper1";
            // 
            // grdObjects
            // 
            this.grdObjects.AllowUserToAddRows = false;
            this.grdObjects.AllowUserToDeleteRows = false;
            this.grdObjects.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdObjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delete,
            this.Object_ID,
            this.Object_Type,
            this.Object_Name});
            this.grdObjects.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.grdObjects.Location = new System.Drawing.Point(28, 80);
            this.grdObjects.Name = "grdObjects";
            this.grdObjects.Size = new System.Drawing.Size(494, 277);
            this.grdObjects.TabIndex = 153;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.Width = 50;
            // 
            // Object_ID
            // 
            this.Object_ID.DataPropertyName = "OBJECT_ID";
            this.Object_ID.HeaderText = "Object ID";
            this.Object_ID.Name = "Object_ID";
            this.Object_ID.Visible = false;
            // 
            // Object_Type
            // 
            this.Object_Type.DataPropertyName = "OBJECT_TYPE";
            this.Object_Type.HeaderText = "Object Type";
            this.Object_Type.Items.AddRange(new object[] {
            "BTN",
            "CHK",
            "CMB",
            "LBL"});
            this.Object_Type.Name = "Object_Type";
            // 
            // Object_Name
            // 
            this.Object_Name.DataPropertyName = "OBJECT_NAME";
            this.Object_Name.HeaderText = "Object Name";
            this.Object_Name.Name = "Object_Name";
            this.Object_Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Object_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Object_Name.Width = 200;
            // 
            // txtSubNameUser
            // 
            this.txtSubNameUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtSubNameUser.Enabled = false;
            this.txtSubNameUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtSubNameUser.Location = new System.Drawing.Point(401, 36);
            this.txtSubNameUser.Name = "txtSubNameUser";
            this.txtSubNameUser.Size = new System.Drawing.Size(121, 20);
            this.txtSubNameUser.TabIndex = 152;
            // 
            // lblSubName
            // 
            this.lblSubName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubName.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.lblSubName.LabelSize = new System.Drawing.Size(70, 0);
            this.lblSubName.Location = new System.Drawing.Point(281, 33);
            this.lblSubName.Name = "lblSubName";
            this.lblSubName.Size = new System.Drawing.Size(263, 32);
            this.lblSubName.StrokeInfo.Rounding = 5;
            this.lblSubName.TabIndex = 153;
            this.lblSubName.Text = "Submenu Name";
            // 
            // txtSubUID
            // 
            this.txtSubUID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtSubUID.Enabled = false;
            this.txtSubUID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtSubUID.Location = new System.Drawing.Point(137, 36);
            this.txtSubUID.Name = "txtSubUID";
            this.txtSubUID.Size = new System.Drawing.Size(104, 20);
            this.txtSubUID.TabIndex = 150;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(242, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 24);
            this.button2.TabIndex = 151;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator6,
            this.btnAdd,
            this.toolStripSeparator1,
            this.btnDelete,
            this.toolStripSeparator3,
            this.btnRefresh,
            this.toolStripSeparator5,
            this.btnClose});
            this.bindingNavigator1.Location = new System.Drawing.Point(1, 375);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(548, 25);
            this.bindingNavigator1.TabIndex = 126;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 22);
            this.btnSave.Text = "Save";
            this.btnSave.ToolTipText = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Envision.NET.Properties.Resources.activity;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(46, 22);
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Envision.NET.Properties.Resources.delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(58, 22);
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::Envision.NET.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 22);
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Envision.NET.Properties.Resources.close;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(53, 22);
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblSubUID
            // 
            this.lblSubUID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubUID.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.lblSubUID.LabelSize = new System.Drawing.Size(70, 0);
            this.lblSubUID.Location = new System.Drawing.Point(17, 33);
            this.lblSubUID.Name = "lblSubUID";
            this.lblSubUID.Size = new System.Drawing.Size(263, 32);
            this.lblSubUID.StrokeInfo.Rounding = 5;
            this.lblSubUID.TabIndex = 128;
            this.lblSubUID.Text = "Submenu UID";
            // 
            // txtID
            // 
            this.txtID.AutoSize = true;
            this.txtID.Location = new System.Drawing.Point(23, 6);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(18, 13);
            this.txtID.TabIndex = 112;
            this.txtID.Text = "ID";
            this.txtID.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 20);
            this.textBox1.TabIndex = 111;
            this.textBox1.Visible = false;
            // 
            // txtButton3Caption
            // 
            this.txtButton3Caption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtButton3Caption.Enabled = false;
            this.txtButton3Caption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtButton3Caption.Location = new System.Drawing.Point(352, 6);
            this.txtButton3Caption.Name = "txtButton3Caption";
            this.txtButton3Caption.Size = new System.Drawing.Size(73, 20);
            this.txtButton3Caption.TabIndex = 148;
            this.txtButton3Caption.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Help1.png");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            // 
            // GBL_SF07
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 448);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GBL_SF07";
            this.Text = "Objects";
            this.SizeChanged += new System.EventHandler(this.GBL_SF07_SizeChanged);
            this.Load += new System.EventHandler(this.GBL_SF07_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).EndInit();
            this.nGrouper1.ResumeLayout(false);
            this.nGrouper1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubUID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gBLSF07BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TreeView treeView1;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer10;
        private System.Windows.Forms.TextBox textBox2;
        private Nevron.UI.WinForm.Controls.NGrouper nGrouper1;
        private System.Windows.Forms.TextBox txtSubNameUser;
        private Nevron.UI.WinForm.Controls.NEntryContainer lblSubName;
        private System.Windows.Forms.TextBox txtSubUID;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnClose;
        private Nevron.UI.WinForm.Controls.NEntryContainer lblSubUID;
        private System.Windows.Forms.Label txtID;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtButton3Caption;
        private System.Windows.Forms.ImageList imageList1;
        private Nevron.UI.WinForm.Controls.NDataGridView grdObjects;
        private System.Windows.Forms.BindingSource gBLSF07BindingSource;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Object_ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn Object_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Object_Name;
    }
}