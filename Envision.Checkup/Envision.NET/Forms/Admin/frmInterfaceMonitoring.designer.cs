namespace RIS.Forms.Admin
{
    partial class frmInterfaceMonitoring
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
            this.pnlSearchHN = new System.Windows.Forms.Panel();
            this.txtHN = new DevExpress.XtraEditors.TextEdit();
            this.pnlSearchDate = new System.Windows.Forms.Panel();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.lblDateTo = new DevExpress.XtraEditors.LabelControl();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.cmbSearch = new DevExpress.XtraEditors.RadioGroup();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblShow = new DevExpress.XtraEditors.LabelControl();
            this.chkShowAccept = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowLock = new DevExpress.XtraEditors.CheckEdit();
            this.pnlSearchAccessionNo = new System.Windows.Forms.Panel();
            this.txtAccessionNo = new DevExpress.XtraEditors.TextEdit();
            this.pnlMainControl = new System.Windows.Forms.Panel();
            this.btnResend = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveFile = new DevExpress.XtraEditors.SimpleButton();
            this.container = new DevExpress.XtraEditors.SplitContainerControl();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pnlSearchHN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHN.Properties)).BeginInit();
            this.pnlSearchDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSearch.Properties)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowAccept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowLock.Properties)).BeginInit();
            this.pnlSearchAccessionNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccessionNo.Properties)).BeginInit();
            this.pnlMainControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.container)).BeginInit();
            this.container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearchHN
            // 
            this.pnlSearchHN.Controls.Add(this.txtHN);
            this.pnlSearchHN.Location = new System.Drawing.Point(109, 3);
            this.pnlSearchHN.Name = "pnlSearchHN";
            this.pnlSearchHN.Size = new System.Drawing.Size(182, 22);
            this.pnlSearchHN.TabIndex = 3;
            // 
            // txtHN
            // 
            this.txtHN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHN.Location = new System.Drawing.Point(3, 1);
            this.txtHN.Name = "txtHN";
            this.txtHN.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtHN.Properties.Appearance.Options.UseBackColor = true;
            this.txtHN.Size = new System.Drawing.Size(176, 20);
            this.txtHN.TabIndex = 0;
            this.txtHN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHN_KeyPress);
            // 
            // pnlSearchDate
            // 
            this.pnlSearchDate.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearchDate.Controls.Add(this.dateEnd);
            this.pnlSearchDate.Controls.Add(this.lblDateTo);
            this.pnlSearchDate.Controls.Add(this.dateBegin);
            this.pnlSearchDate.Location = new System.Drawing.Point(109, 3);
            this.pnlSearchDate.Name = "pnlSearchDate";
            this.pnlSearchDate.Size = new System.Drawing.Size(182, 22);
            this.pnlSearchDate.TabIndex = 1;
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(99, 1);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEnd.Size = new System.Drawing.Size(80, 20);
            this.dateEnd.TabIndex = 2;
            this.dateEnd.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.dateEnd_Closed);
            // 
            // lblDateTo
            // 
            this.lblDateTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDateTo.Location = new System.Drawing.Point(89, 4);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(4, 13);
            this.lblDateTo.TabIndex = 1;
            this.lblDateTo.Text = "-";
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Location = new System.Drawing.Point(3, 1);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateBegin.Size = new System.Drawing.Size(80, 20);
            this.dateBegin.TabIndex = 0;
            this.dateBegin.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.dateBegin_Closed);
            // 
            // cmbSearch
            // 
            this.cmbSearch.AutoSizeInLayoutControl = true;
            this.cmbSearch.Location = new System.Drawing.Point(3, 3);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbSearch.Properties.Appearance.Options.UseBackColor = true;
            this.cmbSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cmbSearch.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("DATE", "Date"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("HN", "HN"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ACCESSION_NO", "Accession No")});
            this.cmbSearch.Size = new System.Drawing.Size(100, 55);
            this.cmbSearch.TabIndex = 0;
            this.cmbSearch.EditValueChanged += new System.EventHandler(this.cmbSearch_EditValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(297, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 55);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlSearch.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.pnlFilter);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.cmbSearch);
            this.pnlSearch.Controls.Add(this.pnlSearchDate);
            this.pnlSearch.Controls.Add(this.pnlSearchAccessionNo);
            this.pnlSearch.Controls.Add(this.pnlSearchHN);
            this.pnlSearch.Location = new System.Drawing.Point(205, 3);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(375, 61);
            this.pnlSearch.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.lblShow);
            this.pnlFilter.Controls.Add(this.chkShowAccept);
            this.pnlFilter.Controls.Add(this.chkShowLock);
            this.pnlFilter.Location = new System.Drawing.Point(109, 30);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(182, 25);
            this.pnlFilter.TabIndex = 5;
            // 
            // lblShow
            // 
            this.lblShow.Location = new System.Drawing.Point(3, 6);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(26, 13);
            this.lblShow.TabIndex = 4;
            this.lblShow.Text = "Show";
            // 
            // chkShowAccept
            // 
            this.chkShowAccept.Location = new System.Drawing.Point(49, 3);
            this.chkShowAccept.Name = "chkShowAccept";
            this.chkShowAccept.Properties.AutoWidth = true;
            this.chkShowAccept.Properties.Caption = "Accepted";
            this.chkShowAccept.Size = new System.Drawing.Size(65, 18);
            this.chkShowAccept.TabIndex = 3;
            this.chkShowAccept.CheckedChanged += new System.EventHandler(this.chkShowAccept_CheckedChanged);
            // 
            // chkShowLock
            // 
            this.chkShowLock.Location = new System.Drawing.Point(123, 3);
            this.chkShowLock.Name = "chkShowLock";
            this.chkShowLock.Properties.AutoWidth = true;
            this.chkShowLock.Properties.Caption = "Locked";
            this.chkShowLock.Size = new System.Drawing.Size(53, 18);
            this.chkShowLock.TabIndex = 2;
            this.chkShowLock.CheckedChanged += new System.EventHandler(this.chkShowLock_CheckedChanged);
            // 
            // pnlSearchAccessionNo
            // 
            this.pnlSearchAccessionNo.Controls.Add(this.txtAccessionNo);
            this.pnlSearchAccessionNo.Location = new System.Drawing.Point(109, 3);
            this.pnlSearchAccessionNo.Name = "pnlSearchAccessionNo";
            this.pnlSearchAccessionNo.Size = new System.Drawing.Size(182, 22);
            this.pnlSearchAccessionNo.TabIndex = 2;
            // 
            // txtAccessionNo
            // 
            this.txtAccessionNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAccessionNo.Location = new System.Drawing.Point(3, 1);
            this.txtAccessionNo.Name = "txtAccessionNo";
            this.txtAccessionNo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtAccessionNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtAccessionNo.Size = new System.Drawing.Size(176, 20);
            this.txtAccessionNo.TabIndex = 0;
            this.txtAccessionNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccessionNo_KeyPress);
            // 
            // pnlMainControl
            // 
            this.pnlMainControl.AutoSize = true;
            this.pnlMainControl.Controls.Add(this.btnResend);
            this.pnlMainControl.Controls.Add(this.btnSaveFile);
            this.pnlMainControl.Controls.Add(this.pnlSearch);
            this.pnlMainControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainControl.Location = new System.Drawing.Point(0, 0);
            this.pnlMainControl.Name = "pnlMainControl";
            this.pnlMainControl.Size = new System.Drawing.Size(784, 67);
            this.pnlMainControl.TabIndex = 0;
            // 
            // btnResend
            // 
            this.btnResend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResend.Location = new System.Drawing.Point(706, 7);
            this.btnResend.Name = "btnResend";
            this.btnResend.Size = new System.Drawing.Size(75, 55);
            this.btnResend.TabIndex = 2;
            this.btnResend.Text = "Resend";
            this.btnResend.Click += new System.EventHandler(this.btnResend_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(3, 7);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(75, 55);
            this.btnSaveFile.TabIndex = 0;
            this.btnSaveFile.Text = "(*.txt)";
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // container
            // 
            this.container.AllowDrop = true;
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.container.Horizontal = false;
            this.container.Location = new System.Drawing.Point(0, 67);
            this.container.Name = "container";
            this.container.Panel1.Controls.Add(this.grid);
            this.container.Panel2.Controls.Add(this.txtDescription);
            this.container.Size = new System.Drawing.Size(784, 495);
            this.container.SplitterPosition = 389;
            this.container.TabIndex = 1;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.view;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(784, 389);
            this.grid.TabIndex = 0;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
            // 
            // view
            // 
            this.view.GridControl = this.grid;
            this.view.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.view.Name = "view";
            this.view.OptionsView.ColumnAutoWidth = false;
            this.view.OptionsView.ShowAutoFilterRow = true;
            this.view.OptionsView.ShowDetailButtons = false;
            this.view.OptionsView.ShowGroupPanel = false;
            this.view.OptionsView.ShowIndicator = false;
            this.view.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.view_RowClick);
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(0, 0);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(784, 100);
            this.txtDescription.TabIndex = 0;
            // 
            // frmInterfaceMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.container);
            this.Controls.Add(this.pnlMainControl);
            this.Name = "frmInterfaceMonitoring";
            this.Text = "Interface Monitoring";
            this.Load += new System.EventHandler(this.frmInterfaceMonitoring_Load);
            this.pnlSearchHN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtHN.Properties)).EndInit();
            this.pnlSearchDate.ResumeLayout(false);
            this.pnlSearchDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSearch.Properties)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowAccept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowLock.Properties)).EndInit();
            this.pnlSearchAccessionNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAccessionNo.Properties)).EndInit();
            this.pnlMainControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.container)).EndInit();
            this.container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearchHN;
        private DevExpress.XtraEditors.TextEdit txtHN;
        private System.Windows.Forms.Panel pnlSearchDate;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.LabelControl lblDateTo;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.RadioGroup cmbSearch;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlSearchAccessionNo;
        private DevExpress.XtraEditors.TextEdit txtAccessionNo;
        private System.Windows.Forms.Panel pnlMainControl;
        private DevExpress.XtraEditors.SplitContainerControl container;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraEditors.SimpleButton btnSaveFile;
        private DevExpress.XtraGrid.Views.Grid.GridView view;
        private System.Windows.Forms.TextBox txtDescription;
        private DevExpress.XtraEditors.CheckEdit chkShowLock;
        private DevExpress.XtraEditors.SimpleButton btnResend;
        private System.Windows.Forms.Panel pnlFilter;
        private DevExpress.XtraEditors.LabelControl lblShow;
        private DevExpress.XtraEditors.CheckEdit chkShowAccept;


    }
}