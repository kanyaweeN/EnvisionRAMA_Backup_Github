
namespace RIS.Forms.Admin
{
    partial class GBL_SF11
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GBL_SF11));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nGrouper1 = new Nevron.UI.WinForm.Controls.NGrouper();
            this.btnRole = new Nevron.UI.WinForm.Controls.NButton();
            this.btnObject = new Nevron.UI.WinForm.Controls.NButton();
            this.grdGrantObject = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.Delete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIEW = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CREATE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MODIFY = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.REMOVE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnLookUp = new Nevron.UI.WinForm.Controls.NButton();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.lblEmpName = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.lblEmpId = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.JobName = new System.Windows.Forms.TextBox();
            this.lblJobName = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.txtJobId = new System.Windows.Forms.TextBox();
            this.lblJobId = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.lblUnitName = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.txtUnitId = new System.Windows.Forms.TextBox();
            this.lblUnitId = new Nevron.UI.WinForm.Controls.NEntryContainer();
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
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).BeginInit();
            this.nGrouper1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrantObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnitName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnitId)).BeginInit();
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
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.nGrouper1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(823, 527);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // nGrouper1
            // 
            this.nGrouper1.Controls.Add(this.btnRole);
            this.nGrouper1.Controls.Add(this.btnObject);
            this.nGrouper1.Controls.Add(this.grdGrantObject);
            this.nGrouper1.Controls.Add(this.btnLookUp);
            this.nGrouper1.Controls.Add(this.txtEmpName);
            this.nGrouper1.Controls.Add(this.lblEmpName);
            this.nGrouper1.Controls.Add(this.txtEmpID);
            this.nGrouper1.Controls.Add(this.lblEmpId);
            this.nGrouper1.Controls.Add(this.JobName);
            this.nGrouper1.Controls.Add(this.lblJobName);
            this.nGrouper1.Controls.Add(this.txtJobId);
            this.nGrouper1.Controls.Add(this.lblJobId);
            this.nGrouper1.Controls.Add(this.txtUnitName);
            this.nGrouper1.Controls.Add(this.lblUnitName);
            this.nGrouper1.Controls.Add(this.txtUnitId);
            this.nGrouper1.Controls.Add(this.lblUnitId);
            this.nGrouper1.Controls.Add(this.bindingNavigator1);
            this.nGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nGrouper1.FooterItem.Text = "Footer";
            this.nGrouper1.FooterItem.Visible = false;
            this.nGrouper1.HeaderItem.Style.FontInfo = new Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular);
            this.nGrouper1.HeaderItem.Style.TextFillStyle = new Nevron.GraphicsCore.NColorFillStyle(new Nevron.GraphicsCore.NArgbColor(((byte)(255)), ((byte)(255)), ((byte)(255)), ((byte)(255))));
            this.nGrouper1.HeaderItem.Text = "Grant Object Permission";
            this.nGrouper1.Location = new System.Drawing.Point(38, 22);
            this.nGrouper1.Name = "nGrouper1";
            this.nGrouper1.ShadowInfo.Draw = false;
            this.nGrouper1.Size = new System.Drawing.Size(694, 493);
            this.nGrouper1.TabIndex = 113;
            this.nGrouper1.Text = "nGrouper1";
            this.nGrouper1.Click += new System.EventHandler(this.nGrouper1_Click);
            // 
            // btnRole
            // 
            this.btnRole.Location = new System.Drawing.Point(347, 174);
            this.btnRole.Name = "btnRole";
            this.btnRole.Size = new System.Drawing.Size(99, 23);
            this.btnRole.TabIndex = 152;
            this.btnRole.Text = "Inherit from Role";
            this.btnRole.UseVisualStyleBackColor = false;
            this.btnRole.Click += new System.EventHandler(this.nButton3_Click);
            // 
            // btnObject
            // 
            this.btnObject.Location = new System.Drawing.Point(209, 174);
            this.btnObject.Name = "btnObject";
            this.btnObject.Size = new System.Drawing.Size(104, 23);
            this.btnObject.TabIndex = 152;
            this.btnObject.Text = "Inherit from Object";
            this.btnObject.UseVisualStyleBackColor = false;
            this.btnObject.Click += new System.EventHandler(this.nButton2_Click);
            // 
            // grdGrantObject
            // 
            this.grdGrantObject.AllowUserToAddRows = false;
            this.grdGrantObject.AllowUserToDeleteRows = false;
            this.grdGrantObject.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdGrantObject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGrantObject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delete,
            this.ID,
            this.UID,
            this.NAME,
            this.VIEW,
            this.CREATE,
            this.MODIFY,
            this.REMOVE});
            this.grdGrantObject.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.grdGrantObject.Location = new System.Drawing.Point(21, 217);
            this.grdGrantObject.Name = "grdGrantObject";
            this.grdGrantObject.Size = new System.Drawing.Size(653, 237);
            this.grdGrantObject.TabIndex = 151;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Width = 40;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "GRANTOBJECT_ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // UID
            // 
            this.UID.DataPropertyName = "SUBMENU_ID";
            this.UID.HeaderText = "UID";
            this.UID.Name = "UID";
            this.UID.ReadOnly = true;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "SUBMENU_NAME_USER";
            this.NAME.HeaderText = "NAME";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.Width = 160;
            // 
            // VIEW
            // 
            this.VIEW.DataPropertyName = "CAN_VIEW";
            this.VIEW.FalseValue = "N";
            this.VIEW.HeaderText = "VIEW";
            this.VIEW.Name = "VIEW";
            this.VIEW.TrueValue = "Y";
            this.VIEW.Width = 50;
            // 
            // CREATE
            // 
            this.CREATE.DataPropertyName = "CAN_CREATE";
            this.CREATE.FalseValue = "N";
            this.CREATE.HeaderText = "CREATE";
            this.CREATE.Name = "CREATE";
            this.CREATE.TrueValue = "Y";
            this.CREATE.Width = 55;
            // 
            // MODIFY
            // 
            this.MODIFY.DataPropertyName = "CAN_MODIFY";
            this.MODIFY.FalseValue = "N";
            this.MODIFY.HeaderText = "MODIFY";
            this.MODIFY.Name = "MODIFY";
            this.MODIFY.TrueValue = "Y";
            this.MODIFY.Width = 50;
            // 
            // REMOVE
            // 
            this.REMOVE.DataPropertyName = "CAN_REMOVE";
            this.REMOVE.FalseValue = "N";
            this.REMOVE.HeaderText = "REMOVE";
            this.REMOVE.Name = "REMOVE";
            this.REMOVE.TrueValue = "Y";
            this.REMOVE.Width = 55;
            // 
            // btnLookUp
            // 
            this.btnLookUp.Location = new System.Drawing.Point(77, 139);
            this.btnLookUp.Name = "btnLookUp";
            this.btnLookUp.Size = new System.Drawing.Size(75, 23);
            this.btnLookUp.TabIndex = 150;
            this.btnLookUp.Text = "Look Up";
            this.btnLookUp.UseVisualStyleBackColor = false;
            this.btnLookUp.Click += new System.EventHandler(this.nButton1_Click);
            // 
            // txtEmpName
            // 
            this.txtEmpName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtEmpName.Enabled = false;
            this.txtEmpName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtEmpName.Location = new System.Drawing.Point(393, 139);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(133, 20);
            this.txtEmpName.TabIndex = 148;
            // 
            // lblEmpName
            // 
            this.lblEmpName.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.lblEmpName.LabelSize = new System.Drawing.Size(70, 0);
            this.lblEmpName.Location = new System.Drawing.Point(328, 136);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(218, 32);
            this.lblEmpName.StrokeInfo.Rounding = 5;
            this.lblEmpName.TabIndex = 149;
            this.lblEmpName.Text = "EMP NAME";
            // 
            // txtEmpID
            // 
            this.txtEmpID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtEmpID.Enabled = false;
            this.txtEmpID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtEmpID.Location = new System.Drawing.Point(240, 139);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(73, 20);
            this.txtEmpID.TabIndex = 146;
            // 
            // lblEmpId
            // 
            this.lblEmpId.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.lblEmpId.LabelSize = new System.Drawing.Size(70, 0);
            this.lblEmpId.Location = new System.Drawing.Point(175, 136);
            this.lblEmpId.Name = "lblEmpId";
            this.lblEmpId.Size = new System.Drawing.Size(147, 32);
            this.lblEmpId.StrokeInfo.Rounding = 5;
            this.lblEmpId.TabIndex = 147;
            this.lblEmpId.Text = "EMP ID";
            // 
            // JobName
            // 
            this.JobName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.JobName.Enabled = false;
            this.JobName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.JobName.Location = new System.Drawing.Point(393, 101);
            this.JobName.Name = "JobName";
            this.JobName.Size = new System.Drawing.Size(133, 20);
            this.JobName.TabIndex = 144;
            // 
            // lblJobName
            // 
            this.lblJobName.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.lblJobName.LabelSize = new System.Drawing.Size(70, 0);
            this.lblJobName.Location = new System.Drawing.Point(328, 98);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(218, 32);
            this.lblJobName.StrokeInfo.Rounding = 5;
            this.lblJobName.TabIndex = 145;
            this.lblJobName.Text = "JOB NAME";
            // 
            // txtJobId
            // 
            this.txtJobId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtJobId.Enabled = false;
            this.txtJobId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtJobId.Location = new System.Drawing.Point(240, 101);
            this.txtJobId.Name = "txtJobId";
            this.txtJobId.Size = new System.Drawing.Size(73, 20);
            this.txtJobId.TabIndex = 142;
            // 
            // lblJobId
            // 
            this.lblJobId.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.lblJobId.LabelSize = new System.Drawing.Size(70, 0);
            this.lblJobId.Location = new System.Drawing.Point(175, 98);
            this.lblJobId.Name = "lblJobId";
            this.lblJobId.Size = new System.Drawing.Size(147, 32);
            this.lblJobId.StrokeInfo.Rounding = 5;
            this.lblJobId.TabIndex = 143;
            this.lblJobId.Text = "JOB ID";
            // 
            // txtUnitName
            // 
            this.txtUnitName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtUnitName.Enabled = false;
            this.txtUnitName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUnitName.Location = new System.Drawing.Point(393, 63);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(133, 20);
            this.txtUnitName.TabIndex = 140;
            // 
            // lblUnitName
            // 
            this.lblUnitName.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.lblUnitName.LabelSize = new System.Drawing.Size(70, 0);
            this.lblUnitName.Location = new System.Drawing.Point(328, 60);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(218, 32);
            this.lblUnitName.StrokeInfo.Rounding = 5;
            this.lblUnitName.TabIndex = 141;
            this.lblUnitName.Text = "UNIT NAME";
            // 
            // txtUnitId
            // 
            this.txtUnitId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtUnitId.Enabled = false;
            this.txtUnitId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUnitId.Location = new System.Drawing.Point(240, 63);
            this.txtUnitId.Name = "txtUnitId";
            this.txtUnitId.Size = new System.Drawing.Size(73, 20);
            this.txtUnitId.TabIndex = 138;
            // 
            // lblUnitId
            // 
            this.lblUnitId.ClientPadding = new Nevron.UI.NPadding(1, 1, 1, 1);
            this.lblUnitId.LabelSize = new System.Drawing.Size(70, 0);
            this.lblUnitId.Location = new System.Drawing.Point(175, 60);
            this.lblUnitId.Name = "lblUnitId";
            this.lblUnitId.Size = new System.Drawing.Size(147, 32);
            this.lblUnitId.StrokeInfo.Rounding = 5;
            this.lblUnitId.TabIndex = 139;
            this.lblUnitId.Text = "UNIT ID";
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
            this.bindingNavigator1.Location = new System.Drawing.Point(1, 467);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(692, 25);
            this.bindingNavigator1.TabIndex = 126;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 22);
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
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator3.Click += new System.EventHandler(this.toolStripSeparator3_Click);
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
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // GBL_SF11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(823, 527);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GBL_SF11";
            this.Text = "Grant Object Permission";
            this.Load += new System.EventHandler(this.GBL_SF11_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nGrouper1)).EndInit();
            this.nGrouper1.ResumeLayout(false);
            this.nGrouper1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrantObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnitName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnitId)).EndInit();
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
        private System.Windows.Forms.TextBox txtEmpName;
        private Nevron.UI.WinForm.Controls.NEntryContainer lblEmpName;
        private System.Windows.Forms.TextBox txtEmpID;
        private Nevron.UI.WinForm.Controls.NEntryContainer lblEmpId;
        private System.Windows.Forms.TextBox JobName;
        private Nevron.UI.WinForm.Controls.NEntryContainer lblJobName;
        private System.Windows.Forms.TextBox txtJobId;
        private Nevron.UI.WinForm.Controls.NEntryContainer lblJobId;
        private System.Windows.Forms.TextBox txtUnitName;
        private Nevron.UI.WinForm.Controls.NEntryContainer lblUnitName;
        private System.Windows.Forms.TextBox txtUnitId;
        private Nevron.UI.WinForm.Controls.NEntryContainer lblUnitId;
        private Nevron.UI.WinForm.Controls.NDataGridView grdGrantObject;
        private Nevron.UI.WinForm.Controls.NButton btnLookUp;
        private Nevron.UI.WinForm.Controls.NButton btnRole;
        private Nevron.UI.WinForm.Controls.NButton btnObject;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VIEW;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CREATE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MODIFY;
        private System.Windows.Forms.DataGridViewCheckBoxColumn REMOVE;


    }
}