namespace Envision.NET.Forms.InternalMessage
{
    partial class frmEmpList
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
            this.viewEmp = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colEMP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMP_UID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFULLNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUNIT_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJOBROLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buttonsContainer1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            ((System.ComponentModel.ISupportInitialize)(this.viewEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainer1)).BeginInit();
            this.buttonsContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewEmp
            // 
            this.viewEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewEmp.Location = new System.Drawing.Point(0, 48);
            this.viewEmp.MainView = this.gridView1;
            this.viewEmp.Name = "viewEmp";
            this.viewEmp.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkSelect});
            this.viewEmp.Size = new System.Drawing.Size(356, 321);
            this.viewEmp.TabIndex = 0;
            this.viewEmp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCheck,
            this.colEMP_ID,
            this.colEMP_UID,
            this.colFULLNAME,
            this.colUNIT_NAME,
            this.colJOBROLE});
            this.gridView1.GridControl = this.viewEmp;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // colCheck
            // 
            this.colCheck.Caption = " ";
            this.colCheck.ColumnEdit = this.chkSelect;
            this.colCheck.FieldName = "IS_SELECTED";
            this.colCheck.Name = "colCheck";
            this.colCheck.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colCheck.Visible = true;
            this.colCheck.VisibleIndex = 0;
            this.colCheck.Width = 43;
            // 
            // chkSelect
            // 
            this.chkSelect.AutoHeight = false;
            this.chkSelect.Name = "chkSelect";
            // 
            // colEMP_ID
            // 
            this.colEMP_ID.FieldName = "EMP_ID";
            this.colEMP_ID.Name = "colEMP_ID";
            this.colEMP_ID.OptionsColumn.AllowEdit = false;
            // 
            // colEMP_UID
            // 
            this.colEMP_UID.Caption = "Code";
            this.colEMP_UID.FieldName = "EMP_UID";
            this.colEMP_UID.Name = "colEMP_UID";
            this.colEMP_UID.OptionsColumn.AllowEdit = false;
            this.colEMP_UID.Visible = true;
            this.colEMP_UID.VisibleIndex = 1;
            this.colEMP_UID.Width = 80;
            // 
            // colFULLNAME
            // 
            this.colFULLNAME.Caption = "Name";
            this.colFULLNAME.FieldName = "FULLNAME";
            this.colFULLNAME.Name = "colFULLNAME";
            this.colFULLNAME.OptionsColumn.AllowEdit = false;
            this.colFULLNAME.Visible = true;
            this.colFULLNAME.VisibleIndex = 2;
            this.colFULLNAME.Width = 243;
            // 
            // colUNIT_NAME
            // 
            this.colUNIT_NAME.Caption = "Unit";
            this.colUNIT_NAME.FieldName = "UNIT_NAME";
            this.colUNIT_NAME.Name = "colUNIT_NAME";
            this.colUNIT_NAME.OptionsColumn.AllowEdit = false;
            this.colUNIT_NAME.Visible = true;
            this.colUNIT_NAME.VisibleIndex = 3;
            this.colUNIT_NAME.Width = 80;
            // 
            // colJOBROLE
            // 
            this.colJOBROLE.Caption = "Role";
            this.colJOBROLE.FieldName = "JOB_TITLE_DESC";
            this.colJOBROLE.Name = "colJOBROLE";
            this.colJOBROLE.OptionsColumn.AllowEdit = false;
            this.colJOBROLE.Visible = true;
            this.colJOBROLE.VisibleIndex = 4;
            this.colJOBROLE.Width = 100;
            // 
            // buttonsContainer1
            // 
            this.buttonsContainer1.Controls.Add(this.btnCancel);
            this.buttonsContainer1.Controls.Add(this.btnSubmit);
            this.buttonsContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsContainer1.Location = new System.Drawing.Point(0, 369);
            this.buttonsContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonsContainer1.Name = "buttonsContainer1";
            this.buttonsContainer1.Size = new System.Drawing.Size(356, 30);
            this.buttonsContainer1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(279, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Location = new System.Drawing.Point(198, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 26);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "OK";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Size = new System.Drawing.Size(356, 48);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // frmEmpList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 399);
            this.Controls.Add(this.viewEmp);
            this.Controls.Add(this.buttonsContainer1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmpList";
            this.Ribbon = this.ribbonControl1;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Names: Contacts";
            this.Load += new System.EventHandler(this.frmEmpList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainer1)).EndInit();
            this.buttonsContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl viewEmp;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl buttonsContainer1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSubmit;
        private DevExpress.XtraGrid.Columns.GridColumn colCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colEMP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colEMP_UID;
        private DevExpress.XtraGrid.Columns.GridColumn colFULLNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colUNIT_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colJOBROLE;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkSelect;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
    }
}