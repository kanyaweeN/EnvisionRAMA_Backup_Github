namespace RIS.Forms.Admin
{
    partial class INV_VENDOR_FORM
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
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtUID = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.nEntryContainer4 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer2 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.btnOrgId = new DevExpress.XtraEditors.SimpleButton();
            this.txtOrdID1 = new DevExpress.XtraEditors.TextEdit();
            this.txtOrdID2 = new DevExpress.XtraEditors.TextEdit();
            this.nEntryContainer3 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.GridView3 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.txtSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.ToolStrip1.Location = new System.Drawing.Point(2, 437);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(543, 25);
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Controls.Add(this.ultraGroupBox1);
            this.groupControl1.Controls.Add(this.ToolStrip1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(547, 464);
            this.groupControl1.TabIndex = 669;
            this.groupControl1.Text = "Inventory Vendor";
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(5, 117);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(537, 317);
            this.gridControl1.TabIndex = 778;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3});
            this.gridView1.BestFitMaxRowCount = 100;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn9,
            this.bandedGridColumn7,
            this.bandedGridColumn8,
            this.bandedGridColumn10});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowBands = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "gridBand3";
            this.gridBand3.Columns.Add(this.bandedGridColumn9);
            this.gridBand3.Columns.Add(this.bandedGridColumn7);
            this.gridBand3.Columns.Add(this.bandedGridColumn8);
            this.gridBand3.Columns.Add(this.bandedGridColumn10);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 225;
            // 
            // bandedGridColumn9
            // 
            this.bandedGridColumn9.Caption = "Vendor ID";
            this.bandedGridColumn9.FieldName = "VENDOR_ID";
            this.bandedGridColumn9.Name = "bandedGridColumn9";
            this.bandedGridColumn9.Visible = true;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.Caption = "Vendor UID";
            this.bandedGridColumn7.FieldName = "VENDOR_UID";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Visible = true;
            // 
            // bandedGridColumn8
            // 
            this.bandedGridColumn8.Caption = "Vendor Name";
            this.bandedGridColumn8.FieldName = "VENDOR_NAME";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.Visible = true;
            // 
            // bandedGridColumn10
            // 
            this.bandedGridColumn10.Caption = "Org ID";
            this.bandedGridColumn10.FieldName = "ORG_ID";
            this.bandedGridColumn10.Name = "bandedGridColumn10";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtUID);
            this.ultraGroupBox1.Controls.Add(this.txtName);
            this.ultraGroupBox1.Controls.Add(this.txtID);
            this.ultraGroupBox1.Controls.Add(this.nEntryContainer4);
            this.ultraGroupBox1.Controls.Add(this.nEntryContainer1);
            this.ultraGroupBox1.Controls.Add(this.nEntryContainer2);
            this.ultraGroupBox1.Location = new System.Drawing.Point(50, 23);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(437, 84);
            this.ultraGroupBox1.TabIndex = 100;
            this.ultraGroupBox1.Text = "Vendor Information";
            // 
            // txtUID
            // 
            this.txtUID.Enabled = false;
            this.txtUID.Location = new System.Drawing.Point(261, 22);
            this.txtUID.Name = "txtUID";
            this.txtUID.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUID.Properties.Appearance.Options.UseBackColor = true;
            this.txtUID.Size = new System.Drawing.Size(109, 20);
            this.txtUID.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(132, 48);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtName.Properties.Appearance.Options.UseBackColor = true;
            this.txtName.Size = new System.Drawing.Size(239, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(132, 22);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtID.Properties.Appearance.Options.UseBackColor = true;
            this.txtID.Size = new System.Drawing.Size(62, 20);
            this.txtID.TabIndex = 1;
            // 
            // nEntryContainer4
            // 
            this.nEntryContainer4.Interactive = false;
            this.nEntryContainer4.Location = new System.Drawing.Point(59, 46);
            this.nEntryContainer4.Name = "nEntryContainer4";
            this.nEntryContainer4.Size = new System.Drawing.Size(323, 30);
            this.nEntryContainer4.TabIndex = 99;
            this.nEntryContainer4.TabStop = false;
            this.nEntryContainer4.Text = "Vendor Name";
            // 
            // nEntryContainer1
            // 
            this.nEntryContainer1.Interactive = false;
            this.nEntryContainer1.Location = new System.Drawing.Point(200, 20);
            this.nEntryContainer1.Name = "nEntryContainer1";
            this.nEntryContainer1.Size = new System.Drawing.Size(181, 30);
            this.nEntryContainer1.TabIndex = 103;
            this.nEntryContainer1.TabStop = false;
            this.nEntryContainer1.Text = "Vendor UID";
            // 
            // nEntryContainer2
            // 
            this.nEntryContainer2.Interactive = false;
            this.nEntryContainer2.Location = new System.Drawing.Point(59, 20);
            this.nEntryContainer2.Name = "nEntryContainer2";
            this.nEntryContainer2.Size = new System.Drawing.Size(143, 30);
            this.nEntryContainer2.TabIndex = 99;
            this.nEntryContainer2.TabStop = false;
            this.nEntryContainer2.Text = "Vendor ID";
            // 
            // btnOrgId
            // 
            this.btnOrgId.Enabled = false;
            this.btnOrgId.Location = new System.Drawing.Point(1055, 14);
            this.btnOrgId.Name = "btnOrgId";
            this.btnOrgId.Size = new System.Drawing.Size(35, 21);
            this.btnOrgId.TabIndex = 811;
            this.btnOrgId.Text = "...";
            this.btnOrgId.Visible = false;
            this.btnOrgId.Click += new System.EventHandler(this.btnOrgId_Click);
            // 
            // txtOrdID1
            // 
            this.txtOrdID1.Enabled = false;
            this.txtOrdID1.Location = new System.Drawing.Point(865, 14);
            this.txtOrdID1.Name = "txtOrdID1";
            this.txtOrdID1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtOrdID1.Properties.Appearance.Options.UseBackColor = true;
            this.txtOrdID1.Size = new System.Drawing.Size(65, 20);
            this.txtOrdID1.TabIndex = 814;
            this.txtOrdID1.TabStop = false;
            this.txtOrdID1.Visible = false;
            // 
            // txtOrdID2
            // 
            this.txtOrdID2.Enabled = false;
            this.txtOrdID2.Location = new System.Drawing.Point(936, 14);
            this.txtOrdID2.Name = "txtOrdID2";
            this.txtOrdID2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtOrdID2.Properties.Appearance.Options.UseBackColor = true;
            this.txtOrdID2.Size = new System.Drawing.Size(116, 20);
            this.txtOrdID2.TabIndex = 813;
            this.txtOrdID2.TabStop = false;
            this.txtOrdID2.Visible = false;
            // 
            // nEntryContainer3
            // 
            this.nEntryContainer3.Interactive = false;
            this.nEntryContainer3.Location = new System.Drawing.Point(792, 12);
            this.nEntryContainer3.Name = "nEntryContainer3";
            this.nEntryContainer3.Size = new System.Drawing.Size(308, 30);
            this.nEntryContainer3.TabIndex = 812;
            this.nEntryContainer3.TabStop = false;
            this.nEntryContainer3.Text = "Org ID";
            this.nEntryContainer3.Visible = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl3);
            this.groupControl2.Controls.Add(this.txtSearch);
            this.groupControl2.Location = new System.Drawing.Point(605, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(186, 506);
            this.groupControl2.TabIndex = 670;
            this.groupControl2.Text = "Search Item";
            this.groupControl2.Visible = false;
            // 
            // gridControl3
            // 
            this.gridControl3.EmbeddedNavigator.Name = "";
            this.gridControl3.Location = new System.Drawing.Point(6, 51);
            this.gridControl3.MainView = this.GridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(175, 450);
            this.gridControl3.TabIndex = 670;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView3,
            this.bandedGridView1});
            // 
            // GridView3
            // 
            this.GridView3.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.GridView3.BestFitMaxRowCount = 100;
            this.GridView3.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn4});
            this.GridView3.GridControl = this.gridControl3;
            this.GridView3.Name = "GridView3";
            this.GridView3.OptionsView.ColumnAutoWidth = true;
            this.GridView3.OptionsView.ShowBands = false;
            this.GridView3.OptionsView.ShowGroupPanel = false;
            this.GridView3.OptionsView.ShowIndicator = false;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "gridBand2";
            this.gridBand2.Columns.Add(this.bandedGridColumn2);
            this.gridBand2.Columns.Add(this.bandedGridColumn3);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 150;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "UID";
            this.bandedGridColumn2.FieldName = "VENDOR_UID";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "Name";
            this.bandedGridColumn3.FieldName = "VENDOR_NAME";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "ID";
            this.bandedGridColumn1.FieldName = "VENDOR_ID";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "Create On";
            this.bandedGridColumn4.FieldName = "CREATED_ON";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.bandedGridView1.GridControl = this.gridControl3;
            this.bandedGridView1.Name = "bandedGridView1";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(5, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, global::Envision.NET.Properties.Resources.viewtree_16),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.txtSearch.Size = new System.Drawing.Size(176, 22);
            this.txtSearch.TabIndex = 669;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // INV_VENDOR_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1188, 626);
            this.Controls.Add(this.btnOrgId);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.txtOrdID1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtOrdID2);
            this.Controls.Add(this.nEntryContainer3);
            this.Name = "INV_VENDOR_FORM";
            this.Text = "Inventory Vendor";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private DevExpress.XtraEditors.TextEdit txtUID;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtID;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer4;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer1;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView GridView3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraEditors.ButtonEdit txtSearch;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.SimpleButton btnOrgId;
        private DevExpress.XtraEditors.TextEdit txtOrdID1;
        private DevExpress.XtraEditors.TextEdit txtOrdID2;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer3;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}