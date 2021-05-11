namespace RIS.Forms.Inventory
{
    partial class INV_UNITREORDERLEVEL_FORM
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
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtReorderQty = new DevExpress.XtraEditors.SpinEdit();
            this.txtReorderDays = new DevExpress.XtraEditors.SpinEdit();
            this.btnUnitId = new DevExpress.XtraEditors.SimpleButton();
            this.txtUnitID1 = new DevExpress.XtraEditors.TextEdit();
            this.txtUnitID2 = new DevExpress.XtraEditors.TextEdit();
            this.btnOrgId = new DevExpress.XtraEditors.SimpleButton();
            this.txtOrgID1 = new DevExpress.XtraEditors.TextEdit();
            this.txtOrgID2 = new DevExpress.XtraEditors.TextEdit();
            this.nEntryContainer5 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.btnItemId = new DevExpress.XtraEditors.SimpleButton();
            this.txtItemID1 = new DevExpress.XtraEditors.TextEdit();
            this.txtItemID2 = new DevExpress.XtraEditors.TextEdit();
            this.nEntryContainer3 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer4 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer2 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReorderQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReorderDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(9, 132);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(437, 255);
            this.gridControl1.TabIndex = 670;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn5,
            this.bandedGridColumn4});
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
            this.gridBand1.Columns.Add(this.bandedGridColumn2);
            this.gridBand1.Columns.Add(this.bandedGridColumn3);
            this.gridBand1.Columns.Add(this.bandedGridColumn5);
            this.gridBand1.Columns.Add(this.bandedGridColumn4);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 300;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "Unit ID";
            this.bandedGridColumn1.FieldName = "UNIT_ID";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "Item ID";
            this.bandedGridColumn2.FieldName = "ITEM_ID";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "Reorder Days";
            this.bandedGridColumn3.FieldName = "REORDER_DAYS";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.Caption = "Reorder Qty";
            this.bandedGridColumn5.FieldName = "REORDER_QTY";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Visible = true;
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
            this.btnAdd.Image = global::RIS.Properties.Resources.activity;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(46, 22);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::RIS.Properties.Resources.FaceSheet24;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(45, 22);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::RIS.Properties.Resources.delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(58, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::RIS.Properties.Resources.refresh;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 22);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::RIS.Properties.Resources.close;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(53, 22);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtReorderQty);
            this.ultraGroupBox1.Controls.Add(this.txtReorderDays);
            this.ultraGroupBox1.Controls.Add(this.btnUnitId);
            this.ultraGroupBox1.Controls.Add(this.txtUnitID1);
            this.ultraGroupBox1.Controls.Add(this.txtUnitID2);
            this.ultraGroupBox1.Controls.Add(this.btnItemId);
            this.ultraGroupBox1.Controls.Add(this.txtItemID1);
            this.ultraGroupBox1.Controls.Add(this.txtItemID2);
            this.ultraGroupBox1.Controls.Add(this.nEntryContainer3);
            this.ultraGroupBox1.Controls.Add(this.nEntryContainer4);
            this.ultraGroupBox1.Controls.Add(this.nEntryContainer2);
            this.ultraGroupBox1.Controls.Add(this.nEntryContainer1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(9, 27);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(437, 99);
            this.ultraGroupBox1.TabIndex = 100;
            this.ultraGroupBox1.Text = "Reorder Level";
            // 
            // txtReorderQty
            // 
            this.txtReorderQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtReorderQty.Location = new System.Drawing.Point(119, 52);
            this.txtReorderQty.Name = "txtReorderQty";
            this.txtReorderQty.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtReorderQty.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtReorderQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtReorderQty.Properties.DisplayFormat.FormatString = "0.00";
            this.txtReorderQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtReorderQty.Properties.EditFormat.FormatString = "0.00";
            this.txtReorderQty.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtReorderQty.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txtReorderQty.Size = new System.Drawing.Size(66, 20);
            this.txtReorderQty.TabIndex = 825;
            // 
            // txtReorderDays
            // 
            this.txtReorderDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtReorderDays.Location = new System.Drawing.Point(119, 26);
            this.txtReorderDays.Name = "txtReorderDays";
            this.txtReorderDays.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtReorderDays.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtReorderDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtReorderDays.Properties.DisplayFormat.FormatString = "0";
            this.txtReorderDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtReorderDays.Properties.EditFormat.FormatString = "0";
            this.txtReorderDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtReorderDays.Properties.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtReorderDays.Size = new System.Drawing.Size(66, 20);
            this.txtReorderDays.TabIndex = 824;
            // 
            // btnUnitId
            // 
            this.btnUnitId.Location = new System.Drawing.Point(358, 25);
            this.btnUnitId.Name = "btnUnitId";
            this.btnUnitId.Size = new System.Drawing.Size(33, 21);
            this.btnUnitId.TabIndex = 821;
            this.btnUnitId.Text = "...";
            this.btnUnitId.Click += new System.EventHandler(this.btnUnitId_Click);
            // 
            // txtUnitID1
            // 
            this.txtUnitID1.Enabled = false;
            this.txtUnitID1.Location = new System.Drawing.Point(234, 26);
            this.txtUnitID1.Name = "txtUnitID1";
            this.txtUnitID1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUnitID1.Properties.Appearance.Options.UseBackColor = true;
            this.txtUnitID1.Size = new System.Drawing.Size(36, 20);
            this.txtUnitID1.TabIndex = 823;
            this.txtUnitID1.TabStop = false;
            // 
            // txtUnitID2
            // 
            this.txtUnitID2.Enabled = false;
            this.txtUnitID2.Location = new System.Drawing.Point(271, 26);
            this.txtUnitID2.Name = "txtUnitID2";
            this.txtUnitID2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUnitID2.Properties.Appearance.Options.UseBackColor = true;
            this.txtUnitID2.Size = new System.Drawing.Size(86, 20);
            this.txtUnitID2.TabIndex = 822;
            this.txtUnitID2.TabStop = false;
            // 
            // btnOrgId
            // 
            this.btnOrgId.Location = new System.Drawing.Point(679, 13);
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
            this.txtOrgID1.Location = new System.Drawing.Point(555, 14);
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
            this.txtOrgID2.Location = new System.Drawing.Point(592, 14);
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
            this.nEntryContainer5.Location = new System.Drawing.Point(511, 12);
            this.nEntryContainer5.Name = "nEntryContainer5";
            this.nEntryContainer5.Size = new System.Drawing.Size(208, 30);
            this.nEntryContainer5.TabIndex = 818;
            this.nEntryContainer5.TabStop = false;
            this.nEntryContainer5.Text = "Org ID";
            this.nEntryContainer5.Visible = false;
            // 
            // btnItemId
            // 
            this.btnItemId.Location = new System.Drawing.Point(358, 51);
            this.btnItemId.Name = "btnItemId";
            this.btnItemId.Size = new System.Drawing.Size(33, 21);
            this.btnItemId.TabIndex = 811;
            this.btnItemId.Text = "...";
            this.btnItemId.Click += new System.EventHandler(this.btnItemId_Click);
            // 
            // txtItemID1
            // 
            this.txtItemID1.Enabled = false;
            this.txtItemID1.Location = new System.Drawing.Point(234, 52);
            this.txtItemID1.Name = "txtItemID1";
            this.txtItemID1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtItemID1.Properties.Appearance.Options.UseBackColor = true;
            this.txtItemID1.Size = new System.Drawing.Size(36, 20);
            this.txtItemID1.TabIndex = 814;
            this.txtItemID1.TabStop = false;
            // 
            // txtItemID2
            // 
            this.txtItemID2.Enabled = false;
            this.txtItemID2.Location = new System.Drawing.Point(271, 52);
            this.txtItemID2.Name = "txtItemID2";
            this.txtItemID2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtItemID2.Properties.Appearance.Options.UseBackColor = true;
            this.txtItemID2.Size = new System.Drawing.Size(86, 20);
            this.txtItemID2.TabIndex = 813;
            this.txtItemID2.TabStop = false;
            // 
            // nEntryContainer3
            // 
            this.nEntryContainer3.Interactive = false;
            this.nEntryContainer3.Location = new System.Drawing.Point(190, 50);
            this.nEntryContainer3.Name = "nEntryContainer3";
            this.nEntryContainer3.Size = new System.Drawing.Size(208, 30);
            this.nEntryContainer3.TabIndex = 812;
            this.nEntryContainer3.TabStop = false;
            this.nEntryContainer3.Text = "ITEM ID";
            // 
            // nEntryContainer4
            // 
            this.nEntryContainer4.Interactive = false;
            this.nEntryContainer4.Location = new System.Drawing.Point(43, 50);
            this.nEntryContainer4.Name = "nEntryContainer4";
            this.nEntryContainer4.Size = new System.Drawing.Size(150, 30);
            this.nEntryContainer4.TabIndex = 816;
            this.nEntryContainer4.TabStop = false;
            this.nEntryContainer4.Text = "ReOrder Qty";
            // 
            // nEntryContainer2
            // 
            this.nEntryContainer2.Interactive = false;
            this.nEntryContainer2.Location = new System.Drawing.Point(190, 24);
            this.nEntryContainer2.Name = "nEntryContainer2";
            this.nEntryContainer2.Size = new System.Drawing.Size(208, 30);
            this.nEntryContainer2.TabIndex = 99;
            this.nEntryContainer2.TabStop = false;
            this.nEntryContainer2.Text = "Unit ID";
            // 
            // nEntryContainer1
            // 
            this.nEntryContainer1.Interactive = false;
            this.nEntryContainer1.Location = new System.Drawing.Point(43, 24);
            this.nEntryContainer1.Name = "nEntryContainer1";
            this.nEntryContainer1.Size = new System.Drawing.Size(150, 30);
            this.nEntryContainer1.TabIndex = 101;
            this.nEntryContainer1.TabStop = false;
            this.nEntryContainer1.Text = "ReOrder Days";
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
            this.groupControl1.Text = "Inventory Redorder Level";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF;";
            this.openFileDialog1.InitialDirectory = "c:\\";
            // 
            // INV_UNITREORDERLEVEL_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(902, 654);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtOrgID2);
            this.Controls.Add(this.txtOrgID1);
            this.Controls.Add(this.btnOrgId);
            this.Controls.Add(this.nEntryContainer5);
            this.Name = "INV_UNITREORDERLEVEL_FORM";
            this.Text = "Inventory Unit ReOrder Level";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtReorderQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReorderDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).EndInit();
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
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer1;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraEditors.SimpleButton btnItemId;
        private DevExpress.XtraEditors.TextEdit txtItemID1;
        private DevExpress.XtraEditors.TextEdit txtItemID2;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer3;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnOrgId;
        private DevExpress.XtraEditors.TextEdit txtOrgID1;
        private DevExpress.XtraEditors.TextEdit txtOrgID2;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer5;
        private DevExpress.XtraEditors.SimpleButton btnUnitId;
        private DevExpress.XtraEditors.TextEdit txtUnitID1;
        private DevExpress.XtraEditors.TextEdit txtUnitID2;
        private DevExpress.XtraEditors.SpinEdit txtReorderQty;
        private DevExpress.XtraEditors.SpinEdit txtReorderDays;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
    }
}