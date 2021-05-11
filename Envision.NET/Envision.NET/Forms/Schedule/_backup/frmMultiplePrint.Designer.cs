namespace Envision.NET.Forms.Schedule
{
    partial class frmMultiplePrint
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
            this.groupDemographic = new DevExpress.XtraEditors.GroupControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.txtPatientName = new DevExpress.XtraEditors.TextEdit();
            this.txtHN = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupExam = new DevExpress.XtraEditors.GroupControl();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.view1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupDemographic)).BeginInit();
            this.groupDemographic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupExam)).BeginInit();
            this.groupExam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupDemographic
            // 
            this.groupDemographic.Controls.Add(this.btnPrint);
            this.groupDemographic.Controls.Add(this.txtPatientName);
            this.groupDemographic.Controls.Add(this.txtHN);
            this.groupDemographic.Controls.Add(this.labelControl2);
            this.groupDemographic.Controls.Add(this.labelControl1);
            this.groupDemographic.Location = new System.Drawing.Point(12, 52);
            this.groupDemographic.Name = "groupDemographic";
            this.groupDemographic.Size = new System.Drawing.Size(552, 91);
            this.groupDemographic.TabIndex = 0;
            this.groupDemographic.Text = "Demographic";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(389, 30);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(116, 44);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(85, 53);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Properties.ReadOnly = true;
            this.txtPatientName.Size = new System.Drawing.Size(298, 20);
            this.txtPatientName.TabIndex = 3;
            // 
            // txtHN
            // 
            this.txtHN.Location = new System.Drawing.Point(85, 30);
            this.txtHN.Name = "txtHN";
            this.txtHN.Properties.ReadOnly = true;
            this.txtHN.Size = new System.Drawing.Size(134, 20);
            this.txtHN.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(47, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Name";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(64, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(15, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "HN";
            // 
            // groupExam
            // 
            this.groupExam.Controls.Add(this.grdData);
            this.groupExam.Location = new System.Drawing.Point(12, 149);
            this.groupExam.Name = "groupExam";
            this.groupExam.Size = new System.Drawing.Size(552, 238);
            this.groupExam.TabIndex = 1;
            this.groupExam.Text = "Exam";
            // 
            // grdData
            // 
            this.grdData.Location = new System.Drawing.Point(5, 23);
            this.grdData.MainView = this.view1;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(542, 210);
            this.grdData.TabIndex = 0;
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
            this.view1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.view1.OptionsView.ShowBands = false;
            this.view1.OptionsView.ShowGroupPanel = false;
            this.view1.Click += new System.EventHandler(this.view1_Click);
            this.view1.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.view1_CustomDrawColumnHeader);
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
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(576, 48);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // frmMultiplePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 391);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.groupExam);
            this.Controls.Add(this.groupDemographic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMultiplePrint";
            this.Ribbon = this.ribbonControl1;
            this.ShowInTaskbar = false;
            this.Text = "กรุณาเลือก Exam ที่ต้องการพิมพ์";
            ((System.ComponentModel.ISupportInitialize)(this.groupDemographic)).EndInit();
            this.groupDemographic.ResumeLayout(false);
            this.groupDemographic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupExam)).EndInit();
            this.groupExam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupDemographic;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.TextEdit txtPatientName;
        private DevExpress.XtraEditors.TextEdit txtHN;
        private DevExpress.XtraEditors.GroupControl groupExam;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView view1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
    }
}