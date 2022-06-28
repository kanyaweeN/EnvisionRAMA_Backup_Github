namespace RIS.Forms.Inventory
{
    partial class INV_TXN_AUTHORISATION
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
            this.ultraExpandableGroupBox1 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.txtGenOn = new DevExpress.XtraEditors.DateEdit();
            this.txtGenBy = new DevExpress.XtraEditors.ComboBoxEdit();
            this.nEntryContainer4 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.nEntryContainer5 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.btnSearchPRID = new DevExpress.XtraEditors.SimpleButton();
            this.txtPrUID = new DevExpress.XtraEditors.TextEdit();
            this.nEntryContainer1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.ultraExpandableGroupBox3 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel4 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).BeginInit();
            this.ultraExpandableGroupBox1.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenOn.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrUID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox3)).BeginInit();
            this.ultraExpandableGroupBox3.SuspendLayout();
            this.ultraExpandableGroupBoxPanel4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraExpandableGroupBox1
            // 
            this.ultraExpandableGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rounded;
            this.ultraExpandableGroupBox1.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.ultraExpandableGroupBox1.ExpandedSize = new System.Drawing.Size(738, 63);
            this.ultraExpandableGroupBox1.Location = new System.Drawing.Point(1, 2);
            this.ultraExpandableGroupBox1.Name = "ultraExpandableGroupBox1";
            this.ultraExpandableGroupBox1.Size = new System.Drawing.Size(738, 63);
            this.ultraExpandableGroupBox1.TabIndex = 2;
            this.ultraExpandableGroupBox1.Text = "PR Master Group Info.";
            this.ultraExpandableGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtGenOn);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtGenBy);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.nEntryContainer4);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.nEntryContainer5);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.btnSearchPRID);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtPrUID);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.nEntryContainer1);
            this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(3, 20);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(732, 40);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            // 
            // txtGenOn
            // 
            this.txtGenOn.EditValue = null;
            this.txtGenOn.Location = new System.Drawing.Point(498, 6);
            this.txtGenOn.Name = "txtGenOn";
            this.txtGenOn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtGenOn.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtGenOn.Size = new System.Drawing.Size(78, 20);
            this.txtGenOn.TabIndex = 27;
            // 
            // txtGenBy
            // 
            this.txtGenBy.Enabled = false;
            this.txtGenBy.Location = new System.Drawing.Point(344, 6);
            this.txtGenBy.Name = "txtGenBy";
            this.txtGenBy.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtGenBy.Properties.Appearance.Options.UseBackColor = true;
            this.txtGenBy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtGenBy.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtGenBy.Size = new System.Drawing.Size(78, 20);
            this.txtGenBy.TabIndex = 26;
            // 
            // nEntryContainer4
            // 
            this.nEntryContainer4.Interactive = false;
            this.nEntryContainer4.Location = new System.Drawing.Point(434, 3);
            this.nEntryContainer4.Name = "nEntryContainer4";
            this.nEntryContainer4.ShadowInfo.Draw = false;
            this.nEntryContainer4.Size = new System.Drawing.Size(147, 26);
            this.nEntryContainer4.TabIndex = 25;
            this.nEntryContainer4.Text = "Gen on";
            // 
            // nEntryContainer5
            // 
            this.nEntryContainer5.Interactive = false;
            this.nEntryContainer5.Location = new System.Drawing.Point(280, 3);
            this.nEntryContainer5.Name = "nEntryContainer5";
            this.nEntryContainer5.ShadowInfo.Draw = false;
            this.nEntryContainer5.Size = new System.Drawing.Size(146, 26);
            this.nEntryContainer5.TabIndex = 24;
            this.nEntryContainer5.Text = "Gen. by";
            // 
            // btnSearchPRID
            // 
            this.btnSearchPRID.Location = new System.Drawing.Point(243, 6);
            this.btnSearchPRID.Name = "btnSearchPRID";
            this.btnSearchPRID.Size = new System.Drawing.Size(28, 20);
            this.btnSearchPRID.TabIndex = 14;
            this.btnSearchPRID.Text = "...";
            this.btnSearchPRID.Click += new System.EventHandler(this.btnSearchPRID_Click);
            // 
            // txtPrUID
            // 
            this.txtPrUID.Location = new System.Drawing.Point(146, 6);
            this.txtPrUID.Name = "txtPrUID";
            this.txtPrUID.Size = new System.Drawing.Size(91, 20);
            this.txtPrUID.TabIndex = 12;
            // 
            // nEntryContainer1
            // 
            this.nEntryContainer1.Interactive = false;
            this.nEntryContainer1.Location = new System.Drawing.Point(97, 3);
            this.nEntryContainer1.Name = "nEntryContainer1";
            this.nEntryContainer1.ShadowInfo.Draw = false;
            this.nEntryContainer1.Size = new System.Drawing.Size(177, 26);
            this.nEntryContainer1.TabIndex = 11;
            this.nEntryContainer1.Text = "PR UID";
            // 
            // ultraExpandableGroupBox3
            // 
            this.ultraExpandableGroupBox3.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rounded;
            this.ultraExpandableGroupBox3.Controls.Add(this.ultraExpandableGroupBoxPanel4);
            this.ultraExpandableGroupBox3.ExpandedSize = new System.Drawing.Size(737, 342);
            this.ultraExpandableGroupBox3.Location = new System.Drawing.Point(1, 66);
            this.ultraExpandableGroupBox3.Name = "ultraExpandableGroupBox3";
            this.ultraExpandableGroupBox3.Size = new System.Drawing.Size(737, 342);
            this.ultraExpandableGroupBox3.TabIndex = 4;
            this.ultraExpandableGroupBox3.Text = "PR Detail Group Info.";
            this.ultraExpandableGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraExpandableGroupBoxPanel4
            // 
            this.ultraExpandableGroupBoxPanel4.Controls.Add(this.toolStrip2);
            this.ultraExpandableGroupBoxPanel4.Controls.Add(this.gridControl1);
            this.ultraExpandableGroupBoxPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel4.Location = new System.Drawing.Point(3, 20);
            this.ultraExpandableGroupBoxPanel4.Name = "ultraExpandableGroupBoxPanel4";
            this.ultraExpandableGroupBoxPanel4.Size = new System.Drawing.Size(731, 319);
            this.ultraExpandableGroupBoxPanel4.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnDelete,
            this.btnEdit,
            this.btnRefresh,
            this.btnSave,
            this.btnCancel,
            this.btnClose,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 294);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(731, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::RIS.Properties.Resources.activity;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(46, 22);
            this.btnAdd.Text = "Add";
            this.btnAdd.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::RIS.Properties.Resources.delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(58, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::RIS.Properties.Resources.FaceSheet24;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(45, 22);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::RIS.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::RIS.Properties.Resources.QA;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::RIS.Properties.Resources.delete;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 22);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::RIS.Properties.Resources.close;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(53, 22);
            this.btnClose.Text = "Close";
            this.btnClose.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::RIS.Properties.Resources.FaceSheet24;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(79, 22);
            this.toolStripButton1.Text = "Save Draft";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::RIS.Properties.Resources.merge;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(67, 22);
            this.toolStripButton2.Text = "Gen. PO";
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(727, 291);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsCustomization.ShowBandsInCustomizationForm = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = true;
            this.gridView1.OptionsView.ShowBands = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "gridBand2";
            this.gridBand2.Columns.Add(this.bandedGridColumn1);
            this.gridBand2.Columns.Add(this.bandedGridColumn2);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 150;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "Item Name";
            this.bandedGridColumn1.FieldName = "ITEM_NAME";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "Quantity";
            this.bandedGridColumn2.FieldName = "QTY";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // INV_TXN_AUTHORISATION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(826, 570);
            this.Controls.Add(this.ultraExpandableGroupBox3);
            this.Controls.Add(this.ultraExpandableGroupBox1);
            this.Name = "INV_TXN_AUTHORISATION";
            this.Text = "Authorisation";
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).EndInit();
            this.ultraExpandableGroupBox1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGenOn.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrUID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEntryContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox3)).EndInit();
            this.ultraExpandableGroupBox3.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel4.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel4.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox1;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
        private DevExpress.XtraEditors.DateEdit txtGenOn;
        private DevExpress.XtraEditors.ComboBoxEdit txtGenBy;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer4;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer5;
        private DevExpress.XtraEditors.SimpleButton btnSearchPRID;
        private DevExpress.XtraEditors.TextEdit txtPrUID;
        private Nevron.UI.WinForm.Controls.NEntryContainer nEntryContainer1;
        private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox3;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel4;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}