namespace RIS.Forms.ResultEntry
{
    partial class SaveTemplate
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.txtTemplateName = new System.Windows.Forms.TextBox();
            this.txtExamCode = new System.Windows.Forms.TextBox();
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.rdoShared = new System.Windows.Forms.RadioButton();
            this.rdoGlobal = new System.Windows.Forms.RadioButton();
            this.rdoPrivate = new System.Windows.Forms.RadioButton();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.view1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lkupCritical = new DevExpress.XtraEditors.LookUpEdit();
            this.groupAccess = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabTemp = new DevExpress.XtraTab.XtraTabPage();
            this.tabRad = new DevExpress.XtraTab.XtraTabPage();
            this.grdRad = new DevExpress.XtraGrid.GridControl();
            this.viewRad = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupCritical.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupAccess)).BeginInit();
            this.groupAccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabTemp.SuspendLayout();
            this.tabRad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewRad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(52, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Template Name";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(77, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Exam Code";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(73, 70);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Exam Name";
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(416, 14);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(77, 17);
            this.chkAuto.TabIndex = 2;
            this.chkAuto.Text = "Auto Apply";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.Location = new System.Drawing.Point(146, 13);
            this.txtTemplateName.MaxLength = 100;
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(262, 20);
            this.txtTemplateName.TabIndex = 1;
            this.txtTemplateName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTemplateName_KeyDown);
            // 
            // txtExamCode
            // 
            this.txtExamCode.Location = new System.Drawing.Point(146, 41);
            this.txtExamCode.Name = "txtExamCode";
            this.txtExamCode.Size = new System.Drawing.Size(262, 20);
            this.txtExamCode.TabIndex = 3;
            this.txtExamCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExamCode_KeyDown);
            this.txtExamCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtExamCode_Validating);
            // 
            // txtExamName
            // 
            this.txtExamName.Location = new System.Drawing.Point(146, 67);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(262, 20);
            this.txtExamName.TabIndex = 5;
            this.txtExamName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExamName_KeyDown);
            this.txtExamName.Validating += new System.ComponentModel.CancelEventHandler(this.txtExamName_Validating);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(414, 40);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(33, 21);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "...";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(324, 6);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(70, 17);
            this.chkSelectAll.TabIndex = 13;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Visible = false;
            this.chkSelectAll.Click += new System.EventHandler(this.chkSelectAll_Click);
            // 
            // rdoShared
            // 
            this.rdoShared.AutoSize = true;
            this.rdoShared.Location = new System.Drawing.Point(259, 5);
            this.rdoShared.Name = "rdoShared";
            this.rdoShared.Size = new System.Drawing.Size(59, 17);
            this.rdoShared.TabIndex = 9;
            this.rdoShared.Text = "Shared";
            this.rdoShared.UseVisualStyleBackColor = true;
            this.rdoShared.Click += new System.EventHandler(this.rdo_Check);
            // 
            // rdoGlobal
            // 
            this.rdoGlobal.AutoSize = true;
            this.rdoGlobal.Location = new System.Drawing.Point(197, 5);
            this.rdoGlobal.Name = "rdoGlobal";
            this.rdoGlobal.Size = new System.Drawing.Size(55, 17);
            this.rdoGlobal.TabIndex = 8;
            this.rdoGlobal.Text = "Global";
            this.rdoGlobal.UseVisualStyleBackColor = true;
            this.rdoGlobal.Click += new System.EventHandler(this.rdo_Check);
            this.rdoGlobal.CheckedChanged += new System.EventHandler(this.rdoGlobal_CheckedChanged);
            // 
            // rdoPrivate
            // 
            this.rdoPrivate.AutoSize = true;
            this.rdoPrivate.Checked = true;
            this.rdoPrivate.Location = new System.Drawing.Point(132, 5);
            this.rdoPrivate.Name = "rdoPrivate";
            this.rdoPrivate.Size = new System.Drawing.Size(58, 17);
            this.rdoPrivate.TabIndex = 7;
            this.rdoPrivate.TabStop = true;
            this.rdoPrivate.Text = "Private";
            this.rdoPrivate.UseVisualStyleBackColor = true;
            this.rdoPrivate.Click += new System.EventHandler(this.rdo_Check);
            this.rdoPrivate.CheckedChanged += new System.EventHandler(this.rdoPrivate_CheckedChanged);
            // 
            // grdData
            // 
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.EmbeddedNavigator.Name = "";
            this.grdData.FormsUseDefaultLookAndFeel = false;
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.MainView = this.view1;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(490, 299);
            this.grdData.TabIndex = 10;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view1,
            this.gridView2});
            // 
            // view1
            // 
            this.view1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.view1.GridControl = this.grdData;
            this.view1.Name = "view1";
            this.view1.OptionsBehavior.Editable = false;
            this.view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.view1.OptionsView.ShowAutoFilterRow = true;
            this.view1.OptionsView.ShowBands = false;
            this.view1.OptionsView.ShowGroupPanel = false;
            this.view1.Click += new System.EventHandler(this.view1_Click);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdData;
            this.gridView2.Name = "gridView2";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(443, 489);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(362, 489);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.lkupCritical);
            this.groupControl1.Controls.Add(this.groupAccess);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnBrowse);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.btnCancel);
            this.groupControl1.Controls.Add(this.txtExamName);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtExamCode);
            this.groupControl1.Controls.Add(this.chkAuto);
            this.groupControl1.Controls.Add(this.txtTemplateName);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(537, 521);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "groupControl1";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(26, 96);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(114, 13);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "Critical Result Level";
            // 
            // lkupCritical
            // 
            this.lkupCritical.EditValue = "";
            this.lkupCritical.Location = new System.Drawing.Point(146, 93);
            this.lkupCritical.Name = "lkupCritical";
            this.lkupCritical.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.SpinRight)});
            this.lkupCritical.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SEVERITY_ID", "Name30", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CRITICAL_UID", "CRITICAL ID", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SEVERITY_NAME", "CRITICAL NAME", 30),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SEVERITY_LABEL", "DESCRIPTION", 100)});
            this.lkupCritical.Properties.PopupWidth = 300;
            this.lkupCritical.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkupCritical.Size = new System.Drawing.Size(262, 20);
            this.lkupCritical.TabIndex = 13;
            this.lkupCritical.EditValueChanged += new System.EventHandler(this.lkupCritical_EditValueChanged);
            this.lkupCritical.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.lkupCritical_CloseUp);
            // 
            // groupAccess
            // 
            this.groupAccess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupAccess.Controls.Add(this.xtraTabControl1);
            this.groupAccess.Controls.Add(this.chkSelectAll);
            this.groupAccess.Controls.Add(this.rdoShared);
            this.groupAccess.Controls.Add(this.rdoGlobal);
            this.groupAccess.Controls.Add(this.rdoPrivate);
            this.groupAccess.Location = new System.Drawing.Point(14, 121);
            this.groupAccess.Name = "groupAccess";
            this.groupAccess.ShowCaption = false;
            this.groupAccess.Size = new System.Drawing.Size(509, 362);
            this.groupAccess.TabIndex = 6;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(5, 28);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabTemp;
            this.xtraTabControl1.Size = new System.Drawing.Size(499, 329);
            this.xtraTabControl1.TabIndex = 14;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabTemp,
            this.tabRad});
            this.xtraTabControl1.Text = "xtraTabControl1";
            // 
            // tabTemp
            // 
            this.tabTemp.Controls.Add(this.grdData);
            this.tabTemp.Name = "tabTemp";
            this.tabTemp.Size = new System.Drawing.Size(490, 299);
            this.tabTemp.Text = "Template";
            // 
            // tabRad
            // 
            this.tabRad.Controls.Add(this.grdRad);
            this.tabRad.Name = "tabRad";
            this.tabRad.Size = new System.Drawing.Size(490, 299);
            this.tabRad.Text = "Share for";
            // 
            // grdRad
            // 
            this.grdRad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRad.EmbeddedNavigator.Name = "";
            this.grdRad.FormsUseDefaultLookAndFeel = false;
            this.grdRad.Location = new System.Drawing.Point(0, 0);
            this.grdRad.MainView = this.viewRad;
            this.grdRad.Name = "grdRad";
            this.grdRad.Size = new System.Drawing.Size(490, 299);
            this.grdRad.TabIndex = 11;
            this.grdRad.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewRad,
            this.gridView3});
            // 
            // viewRad
            // 
            this.viewRad.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3});
            this.viewRad.GridControl = this.grdRad;
            this.viewRad.Name = "viewRad";
            this.viewRad.OptionsBehavior.Editable = false;
            this.viewRad.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewRad.OptionsView.ShowAutoFilterRow = true;
            this.viewRad.OptionsView.ShowBands = false;
            this.viewRad.OptionsView.ShowGroupPanel = false;
            this.viewRad.Click += new System.EventHandler(this.viewRad_Click);
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "gridBand1";
            this.gridBand3.Name = "gridBand3";
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.grdRad;
            this.gridView3.Name = "gridView3";
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.advBandedGridView1.Name = "advBandedGridView1";
            this.advBandedGridView1.OptionsBehavior.Editable = false;
            this.advBandedGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.advBandedGridView1.OptionsView.ShowAutoFilterRow = true;
            this.advBandedGridView1.OptionsView.ShowBands = false;
            this.advBandedGridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "gridBand1";
            this.gridBand2.Name = "gridBand2";
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // SaveTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(537, 521);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save Template";
            this.Load += new System.EventHandler(this.SaveTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkupCritical.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupAccess)).EndInit();
            this.groupAccess.ResumeLayout(false);
            this.groupAccess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabTemp.ResumeLayout(false);
            this.tabRad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewRad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.TextBox txtTemplateName;
        private System.Windows.Forms.TextBox txtExamCode;
        private System.Windows.Forms.TextBox txtExamName;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView view1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.RadioButton rdoShared;
        private System.Windows.Forms.RadioButton rdoGlobal;
        private System.Windows.Forms.RadioButton rdoPrivate;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit lkupCritical;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabTemp;
        private DevExpress.XtraTab.XtraTabPage tabRad;
        private DevExpress.XtraGrid.GridControl grdRad;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView viewRad;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupAccess;
    }
}