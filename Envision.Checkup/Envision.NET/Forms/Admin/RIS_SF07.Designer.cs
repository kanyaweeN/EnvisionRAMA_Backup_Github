
namespace RIS.Forms.Admin
{
    partial class RIS_SF07
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RIS_SF07));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.nEntryContainer10 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nGrouper1 = new Nevron.UI.WinForm.Controls.NGrouper();
            this.grdModalityType = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.clmDel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPEUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALIAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).BeginInit();
            this.nGrouper1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdModalityType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.nEntryContainer10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.nGrouper1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(768, 448);
            this.splitContainer1.SplitterDistance = 73;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtSearch.Location = new System.Drawing.Point(12, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(179, 20);
            this.txtSearch.TabIndex = 140;
            this.txtSearch.Text = "Search";
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.treeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeView1.Location = new System.Drawing.Point(10, 53);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(181, 367);
            this.treeView1.TabIndex = 139;
            this.treeView1.Visible = false;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // nEntryContainer10
            // 
            this.nEntryContainer10.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.nEntryContainer10.LabelSize = new System.Drawing.Size(70, 0);
            this.nEntryContainer10.Location = new System.Drawing.Point(5, 20);
            this.nEntryContainer10.Name = "nEntryContainer10";
            this.nEntryContainer10.Size = new System.Drawing.Size(194, 407);
            this.nEntryContainer10.StrokeInfo.Rounding = 5;
            this.nEntryContainer10.TabIndex = 141;
            this.nEntryContainer10.Visible = false;
            // 
            // nGrouper1
            // 
            this.nGrouper1.Controls.Add(this.grdModalityType);
            this.nGrouper1.Controls.Add(this.bindingNavigator1);
            this.nGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nGrouper1.FooterItem.Text = "Footer";
            this.nGrouper1.FooterItem.Visible = false;
            this.nGrouper1.HeaderItem.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular);
            this.nGrouper1.HeaderItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((byte)(255)), ((byte)(255)), ((byte)(255)), ((byte)(255))));
            this.nGrouper1.HeaderItem.Text = "Modality Type";
            this.nGrouper1.Location = new System.Drawing.Point(3, 20);
            this.nGrouper1.Name = "nGrouper1";
            this.nGrouper1.ShadowInfo.Draw = false;
            this.nGrouper1.Size = new System.Drawing.Size(558, 401);
            this.nGrouper1.TabIndex = 113;
            this.nGrouper1.Text = "nGrouper1";
            this.nGrouper1.Click += new System.EventHandler(this.nGrouper1_Click);
            // 
            // grdModalityType
            // 
            this.grdModalityType.AllowUserToAddRows = false;
            this.grdModalityType.AllowUserToDeleteRows = false;
            this.grdModalityType.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdModalityType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdModalityType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDel,
            this.ID,
            this.TYPEUID,
            this.TYPENAME,
            this.ALIAS,
            this.DESCR});
            this.grdModalityType.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.grdModalityType.Location = new System.Drawing.Point(9, 47);
            this.grdModalityType.Name = "grdModalityType";
            this.grdModalityType.Size = new System.Drawing.Size(541, 293);
            this.grdModalityType.TabIndex = 127;
            // 
            // clmDel
            // 
            this.clmDel.HeaderText = "DELETE";
            this.clmDel.Name = "clmDel";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "TYPE_ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // TYPEUID
            // 
            this.TYPEUID.DataPropertyName = "TYPE_UID";
            this.TYPEUID.HeaderText = "TYPE UID";
            this.TYPEUID.Name = "TYPEUID";
            // 
            // TYPENAME
            // 
            this.TYPENAME.DataPropertyName = "TYPE_NAME";
            this.TYPENAME.HeaderText = "TYPE NAME";
            this.TYPENAME.Name = "TYPENAME";
            // 
            // ALIAS
            // 
            this.ALIAS.DataPropertyName = "TYPE_NAME_ALIAS";
            this.ALIAS.HeaderText = "ALIAS";
            this.ALIAS.Name = "ALIAS";
            // 
            // DESCR
            // 
            this.DESCR.DataPropertyName = "DESCR";
            this.DESCR.HeaderText = "DESCR";
            this.DESCR.Name = "DESCR";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.bindingNavigatorSeparator2,
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
            this.bindingNavigator1.Size = new System.Drawing.Size(556, 25);
            this.bindingNavigator1.TabIndex = 126;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 22);
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Envision.NET.Properties.Resources.activity;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 22);
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
            this.btnDelete.Size = new System.Drawing.Size(63, 22);
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
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
            this.btnRefresh.Size = new System.Drawing.Size(68, 22);
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
            this.btnClose.Size = new System.Drawing.Size(55, 22);
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RIS_SF07
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(768, 448);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RIS_SF07";
            this.Text = "Modality Type";
            this.Load += new System.EventHandler(this.RIS_SF07_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).EndInit();
            this.nGrouper1.ResumeLayout(false);
            this.nGrouper1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdModalityType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Nevron.UI.WinForm.Controls.NGrouper nGrouper1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnSave;
        private Nevron.UI.WinForm.Controls.NDataGridView grdModalityType;
        private System.Windows.Forms.DataGridViewTextBoxColumn lANGIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lANGUIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lANGNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn iSACTIVEDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TreeView treeView1;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPEUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALIAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCR;


    }
}