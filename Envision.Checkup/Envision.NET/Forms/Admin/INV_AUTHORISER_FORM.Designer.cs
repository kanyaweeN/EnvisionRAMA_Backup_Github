namespace RIS.Forms.Admin
{
    partial class INV_AUTHORISER_FORM
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtAuthorType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtSerialNum = new DevExpress.XtraEditors.SpinEdit();
            this.btnEmpId = new DevExpress.XtraEditors.SimpleButton();
            this.txtEmpID1 = new DevExpress.XtraEditors.TextEdit();
            this.txtEmpID2 = new DevExpress.XtraEditors.TextEdit();
            this.nEntryContainer3 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer2 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.txtAuthorID = new DevExpress.XtraEditors.TextEdit();
            this.nEntryContainer10 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.btnOrgId = new DevExpress.XtraEditors.SimpleButton();
            this.txtOrgID1 = new DevExpress.XtraEditors.TextEdit();
            this.txtOrgID2 = new DevExpress.XtraEditors.TextEdit();
            this.nEntryContainer5 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuthorType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuthorID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(9, 117);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(454, 270);
            this.gridControl1.TabIndex = 670;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DataSourceChanged += new System.EventHandler(this.gridControl1_DataSourceChanged);
            // 
            // gridView1
            // 
            this.gridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn8,
            this.bandedGridColumn7,
            this.bandedGridColumn3,
            this.bandedGridColumn5,
            this.bandedGridColumn4,
            this.bandedGridColumn6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.ShowBands = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Columns.Add(this.bandedGridColumn1);
            this.gridBand1.Columns.Add(this.bandedGridColumn6);
            this.gridBand1.Columns.Add(this.bandedGridColumn5);
            this.gridBand1.Columns.Add(this.bandedGridColumn3);
            this.gridBand1.Columns.Add(this.bandedGridColumn2);
            this.gridBand1.Columns.Add(this.bandedGridColumn8);
            this.gridBand1.Columns.Add(this.bandedGridColumn7);
            this.gridBand1.Columns.Add(this.bandedGridColumn4);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 450;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "ID";
            this.bandedGridColumn1.FieldName = "AUTHORISER_ID";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.Caption = "Type";
            this.bandedGridColumn6.FieldName = "TYPE_NAME";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.Visible = true;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.Caption = "Type 1";
            this.bandedGridColumn5.FieldName = "AUTH_TYPE";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "Serial";
            this.bandedGridColumn3.FieldName = "SERIAL";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "Emp. ID";
            this.bandedGridColumn2.FieldName = "EMP_ID";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            // 
            // bandedGridColumn8
            // 
            this.bandedGridColumn8.Caption = "Emp. Code";
            this.bandedGridColumn8.FieldName = "EMP_UID";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.Visible = true;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.Caption = "Emp. Username";
            this.bandedGridColumn7.FieldName = "USER_NAME";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Visible = true;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "Org ID";
            this.bandedGridColumn4.FieldName = "ORG_ID";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnCancel,
            this.btnClose});
            this.ToolStrip1.Location = new System.Drawing.Point(2, 390);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(478, 25);
            this.ToolStrip1.TabIndex = 777;
            this.ToolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Envision.NET.Properties.Resources.activity;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(46, 22);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Envision.NET.Properties.Resources.FaceSheet24;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(45, 22);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Envision.NET.Properties.Resources.delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(58, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Envision.NET.Properties.Resources.refresh;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 22);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Envision.NET.Properties.Resources.close;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(53, 22);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtAuthorType);
            this.ultraGroupBox1.Controls.Add(this.txtSerialNum);
            this.ultraGroupBox1.Controls.Add(this.btnEmpId);
            this.ultraGroupBox1.Controls.Add(this.txtEmpID1);
            this.ultraGroupBox1.Controls.Add(this.txtEmpID2);
            this.ultraGroupBox1.Controls.Add(this.nEntryContainer3);
            this.ultraGroupBox1.Controls.Add(this.nEntryContainer2);
            this.ultraGroupBox1.Controls.Add(this.nEntryContainer1);
            this.ultraGroupBox1.Controls.Add(this.txtAuthorID);
            this.ultraGroupBox1.Controls.Add(this.nEntryContainer10);
            this.ultraGroupBox1.Location = new System.Drawing.Point(9, 23);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(454, 88);
            this.ultraGroupBox1.TabIndex = 100;
            this.ultraGroupBox1.Text = "Inventory Autorisation";
            // 
            // txtAuthorType
            // 
            this.txtAuthorType.Location = new System.Drawing.Point(225, 26);
            this.txtAuthorType.Name = "txtAuthorType";
            this.txtAuthorType.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtAuthorType.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtAuthorType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAuthorType.Properties.Items.AddRange(new object[] {
            "PR",
            "PO",
            "BOTH"});
            this.txtAuthorType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtAuthorType.Size = new System.Drawing.Size(157, 20);
            this.txtAuthorType.TabIndex = 826;
            // 
            // txtSerialNum
            // 
            this.txtSerialNum.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSerialNum.Location = new System.Drawing.Point(91, 52);
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtSerialNum.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtSerialNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSerialNum.Properties.DisplayFormat.FormatString = "0";
            this.txtSerialNum.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSerialNum.Properties.EditFormat.FormatString = "0";
            this.txtSerialNum.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSerialNum.Properties.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtSerialNum.Size = new System.Drawing.Size(70, 20);
            this.txtSerialNum.TabIndex = 824;
            // 
            // btnEmpId
            // 
            this.btnEmpId.Location = new System.Drawing.Point(349, 51);
            this.btnEmpId.Name = "btnEmpId";
            this.btnEmpId.Size = new System.Drawing.Size(33, 21);
            this.btnEmpId.TabIndex = 811;
            this.btnEmpId.Text = "...";
            this.btnEmpId.Click += new System.EventHandler(this.btnEmpId_Click);
            // 
            // txtEmpID1
            // 
            this.txtEmpID1.Enabled = false;
            this.txtEmpID1.Location = new System.Drawing.Point(225, 52);
            this.txtEmpID1.Name = "txtEmpID1";
            this.txtEmpID1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtEmpID1.Properties.Appearance.Options.UseBackColor = true;
            this.txtEmpID1.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtEmpID1.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtEmpID1.Size = new System.Drawing.Size(36, 20);
            this.txtEmpID1.TabIndex = 814;
            this.txtEmpID1.TabStop = false;
            // 
            // txtEmpID2
            // 
            this.txtEmpID2.Enabled = false;
            this.txtEmpID2.Location = new System.Drawing.Point(262, 52);
            this.txtEmpID2.Name = "txtEmpID2";
            this.txtEmpID2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtEmpID2.Properties.Appearance.Options.UseBackColor = true;
            this.txtEmpID2.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtEmpID2.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtEmpID2.Size = new System.Drawing.Size(86, 20);
            this.txtEmpID2.TabIndex = 813;
            this.txtEmpID2.TabStop = false;
            // 
            // nEntryContainer3
            // 
            this.nEntryContainer3.Interactive = false;
            this.nEntryContainer3.Location = new System.Drawing.Point(166, 50);
            this.nEntryContainer3.Name = "nEntryContainer3";
            this.nEntryContainer3.Size = new System.Drawing.Size(224, 30);
            this.nEntryContainer3.TabIndex = 812;
            this.nEntryContainer3.TabStop = false;
            this.nEntryContainer3.Text = "EMP ID";
            // 
            // nEntryContainer2
            // 
            this.nEntryContainer2.Interactive = false;
            this.nEntryContainer2.Location = new System.Drawing.Point(166, 24);
            this.nEntryContainer2.Name = "nEntryContainer2";
            this.nEntryContainer2.Size = new System.Drawing.Size(224, 30);
            this.nEntryContainer2.TabIndex = 99;
            this.nEntryContainer2.TabStop = false;
            this.nEntryContainer2.Text = "Auth. Type";
            // 
            // nEntryContainer1
            // 
            this.nEntryContainer1.Interactive = false;
            this.nEntryContainer1.Location = new System.Drawing.Point(34, 50);
            this.nEntryContainer1.Name = "nEntryContainer1";
            this.nEntryContainer1.Size = new System.Drawing.Size(135, 30);
            this.nEntryContainer1.TabIndex = 101;
            this.nEntryContainer1.TabStop = false;
            this.nEntryContainer1.Text = "Serial Num.";
            // 
            // txtAuthorID
            // 
            this.txtAuthorID.Enabled = false;
            this.txtAuthorID.Location = new System.Drawing.Point(91, 26);
            this.txtAuthorID.Name = "txtAuthorID";
            this.txtAuthorID.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtAuthorID.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtAuthorID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAuthorID.Size = new System.Drawing.Size(70, 20);
            this.txtAuthorID.TabIndex = 828;
            // 
            // nEntryContainer10
            // 
            this.nEntryContainer10.Interactive = false;
            this.nEntryContainer10.Location = new System.Drawing.Point(34, 24);
            this.nEntryContainer10.Name = "nEntryContainer10";
            this.nEntryContainer10.Size = new System.Drawing.Size(135, 30);
            this.nEntryContainer10.TabIndex = 827;
            this.nEntryContainer10.TabStop = false;
            this.nEntryContainer10.Text = "Auth. ID";
            // 
            // btnOrgId
            // 
            this.btnOrgId.Location = new System.Drawing.Point(698, 13);
            this.btnOrgId.Name = "btnOrgId";
            this.btnOrgId.Size = new System.Drawing.Size(33, 21);
            this.btnOrgId.TabIndex = 817;
            this.btnOrgId.Text = "...";
            this.btnOrgId.Visible = false;
            this.btnOrgId.Click += new System.EventHandler(this.btnOrgId_Click);
            // 
            // txtOrgID1
            // 
            this.txtOrgID1.Enabled = false;
            this.txtOrgID1.Location = new System.Drawing.Point(574, 14);
            this.txtOrgID1.Name = "txtOrgID1";
            this.txtOrgID1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtOrgID1.Properties.Appearance.Options.UseBackColor = true;
            this.txtOrgID1.Size = new System.Drawing.Size(36, 20);
            this.txtOrgID1.TabIndex = 820;
            this.txtOrgID1.TabStop = false;
            this.txtOrgID1.Visible = false;
            // 
            // txtOrgID2
            // 
            this.txtOrgID2.Enabled = false;
            this.txtOrgID2.Location = new System.Drawing.Point(611, 14);
            this.txtOrgID2.Name = "txtOrgID2";
            this.txtOrgID2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtOrgID2.Properties.Appearance.Options.UseBackColor = true;
            this.txtOrgID2.Size = new System.Drawing.Size(86, 20);
            this.txtOrgID2.TabIndex = 819;
            this.txtOrgID2.TabStop = false;
            this.txtOrgID2.Visible = false;
            // 
            // nEntryContainer5
            // 
            this.nEntryContainer5.Interactive = false;
            this.nEntryContainer5.Location = new System.Drawing.Point(515, 12);
            this.nEntryContainer5.Name = "nEntryContainer5";
            this.nEntryContainer5.Size = new System.Drawing.Size(224, 30);
            this.nEntryContainer5.TabIndex = 818;
            this.nEntryContainer5.TabStop = false;
            this.nEntryContainer5.Text = "Org ID";
            this.nEntryContainer5.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Controls.Add(this.ultraGroupBox1);
            this.groupControl1.Controls.Add(this.ToolStrip1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(482, 417);
            this.groupControl1.TabIndex = 667;
            this.groupControl1.Text = "Inventory Autorisation";
            // 
            // INV_AUTHORISER_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(902, 654);
            this.Controls.Add(this.btnOrgId);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtOrgID1);
            this.Controls.Add(this.txtOrgID2);
            this.Controls.Add(this.nEntryContainer5);
            this.Name = "INV_AUTHORISER_FORM";
            this.Text = "Inventory Autorisation";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAuthorType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuthorID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.ToolStrip ToolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnClose;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer1;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraEditors.SimpleButton btnEmpId;
        private DevExpress.XtraEditors.TextEdit txtEmpID1;
        private DevExpress.XtraEditors.TextEdit txtEmpID2;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnOrgId;
        private DevExpress.XtraEditors.TextEdit txtOrgID1;
        private DevExpress.XtraEditors.TextEdit txtOrgID2;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer5;
        private DevExpress.XtraEditors.SpinEdit txtSerialNum;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
        private DevExpress.XtraEditors.ComboBoxEdit txtAuthorType;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer2;
        private DevExpress.XtraEditors.TextEdit txtAuthorID;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
    }
}