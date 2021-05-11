namespace RIS.Forms.Inventory
{
    partial class INV_AUTHORISATION_FORM
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
            this.btnItemId = new DevExpress.XtraEditors.SimpleButton();
            this.txtItemID1 = new DevExpress.XtraEditors.TextEdit();
            this.txtItemID2 = new DevExpress.XtraEditors.TextEdit();
            this.nEntryContainer3 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer4 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer2 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit2 = new DevExpress.XtraEditors.SpinEdit();
            this.nEntryContainer8 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer10 = new Nevron.UI.WinForm.Controls.NEntryContainer();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtItemID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer10)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(9, 185);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(437, 202);
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
            this.gridBand1.Width = 375;
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
            this.bandedGridColumn3.Caption = "ReOrder Days";
            this.bandedGridColumn3.FieldName = "REORDER_DAYS";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.Caption = "ReOrder Qty";
            this.bandedGridColumn5.FieldName = "REORDER_QTY";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Visible = true;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "Org ID";
            this.bandedGridColumn4.FieldName = "ORG_ID";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
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
            this.ultraGroupBox1.Location = new System.Drawing.Point(9, 92);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(437, 87);
            this.ultraGroupBox1.TabIndex = 100;
            this.ultraGroupBox1.Text = "Inventory Autorisation";
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
            this.groupControl1.Controls.Add(this.ultraGroupBox2);
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Controls.Add(this.ultraGroupBox1);
            this.groupControl1.Controls.Add(this.ToolStrip1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(482, 417);
            this.groupControl1.TabIndex = 667;
            this.groupControl1.Text = "Inventory Autorisation";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.spinEdit1);
            this.ultraGroupBox2.Controls.Add(this.spinEdit2);
            this.ultraGroupBox2.Controls.Add(this.nEntryContainer8);
            this.ultraGroupBox2.Controls.Add(this.nEntryContainer10);
            this.ultraGroupBox2.Location = new System.Drawing.Point(9, 23);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(437, 63);
            this.ultraGroupBox2.TabIndex = 778;
            this.ultraGroupBox2.Text = "Inventory Autorisation";
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(266, 26);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.spinEdit1.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit1.Properties.DisplayFormat.FormatString = "0.00";
            this.spinEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit1.Properties.EditFormat.FormatString = "0.00";
            this.spinEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit1.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.spinEdit1.Size = new System.Drawing.Size(124, 20);
            this.spinEdit1.TabIndex = 825;
            // 
            // spinEdit2
            // 
            this.spinEdit2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit2.Location = new System.Drawing.Point(119, 26);
            this.spinEdit2.Name = "spinEdit2";
            this.spinEdit2.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.spinEdit2.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.spinEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit2.Properties.DisplayFormat.FormatString = "0";
            this.spinEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit2.Properties.EditFormat.FormatString = "0";
            this.spinEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit2.Properties.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.spinEdit2.Size = new System.Drawing.Size(66, 20);
            this.spinEdit2.TabIndex = 824;
            // 
            // nEntryContainer8
            // 
            this.nEntryContainer8.Interactive = false;
            this.nEntryContainer8.Location = new System.Drawing.Point(190, 24);
            this.nEntryContainer8.Name = "nEntryContainer8";
            this.nEntryContainer8.Size = new System.Drawing.Size(208, 30);
            this.nEntryContainer8.TabIndex = 816;
            this.nEntryContainer8.TabStop = false;
            this.nEntryContainer8.Text = "ReOrder Qty";
            // 
            // nEntryContainer10
            // 
            this.nEntryContainer10.Interactive = false;
            this.nEntryContainer10.Location = new System.Drawing.Point(43, 24);
            this.nEntryContainer10.Name = "nEntryContainer10";
            this.nEntryContainer10.Size = new System.Drawing.Size(150, 30);
            this.nEntryContainer10.TabIndex = 101;
            this.nEntryContainer10.TabStop = false;
            this.nEntryContainer10.Text = "ReOrder Days";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF;";
            this.openFileDialog1.InitialDirectory = "c:\\";
            // 
            // INV_AUTHORISATION_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(902, 654);
            this.Controls.Add(this.groupControl1);
            this.Name = "INV_AUTHORISATION_FORM";
            this.Text = "Inventory Autorisation";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtItemID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer10)).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton btnUnitId;
        private DevExpress.XtraEditors.TextEdit txtUnitID1;
        private DevExpress.XtraEditors.TextEdit txtUnitID2;
        private DevExpress.XtraEditors.SpinEdit txtReorderQty;
        private DevExpress.XtraEditors.SpinEdit txtReorderDays;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraEditors.SpinEdit spinEdit2;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer8;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer10;
    }
}