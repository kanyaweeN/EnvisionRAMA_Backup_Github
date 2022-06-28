namespace Envision.NET.Forms.ResultEntry.StructuredReport.Covid
{
    partial class xtraControlCovidDEC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xtraTabResultControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabFinding = new DevExpress.XtraTab.XtraTabPage();
            this.grdFindingDetail = new DevExpress.XtraGrid.GridControl();
            this.viewFindingDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdFinding = new DevExpress.XtraGrid.GridControl();
            this.viewFinding = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabImpression = new DevExpress.XtraTab.XtraTabPage();
            this.grdImpressionDetail = new DevExpress.XtraGrid.GridControl();
            this.viewImpressionDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdImpression = new DevExpress.XtraGrid.GridControl();
            this.viewImpression = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rtPreview = new DevExpress.XtraRichEdit.RichEditControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblSeverity = new DevExpress.XtraEditors.LabelControl();
            this.btnWorklist = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveFinalized = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabResultControl)).BeginInit();
            this.xtraTabResultControl.SuspendLayout();
            this.tabFinding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFindingDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewFindingDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewFinding)).BeginInit();
            this.tabImpression.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImpressionDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewImpressionDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImpression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewImpression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabResultControl
            // 
            this.xtraTabResultControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.xtraTabResultControl.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.xtraTabResultControl.Appearance.Options.UseBackColor = true;
            this.xtraTabResultControl.Location = new System.Drawing.Point(7, 7);
            this.xtraTabResultControl.Name = "xtraTabResultControl";
            this.xtraTabResultControl.SelectedTabPage = this.tabFinding;
            this.xtraTabResultControl.Size = new System.Drawing.Size(550, 595);
            this.xtraTabResultControl.TabIndex = 0;
            this.xtraTabResultControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabFinding,
            this.tabImpression});
            // 
            // tabFinding
            // 
            this.tabFinding.Appearance.PageClient.BackColor = System.Drawing.Color.White;
            this.tabFinding.Appearance.PageClient.Options.UseBackColor = true;
            this.tabFinding.Controls.Add(this.grdFindingDetail);
            this.tabFinding.Controls.Add(this.grdFinding);
            this.tabFinding.Name = "tabFinding";
            this.tabFinding.Size = new System.Drawing.Size(541, 564);
            this.tabFinding.Text = "Finding";
            // 
            // grdFindingDetail
            // 
            this.grdFindingDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFindingDetail.Location = new System.Drawing.Point(188, 0);
            this.grdFindingDetail.MainView = this.viewFindingDetail;
            this.grdFindingDetail.Name = "grdFindingDetail";
            this.grdFindingDetail.Size = new System.Drawing.Size(353, 564);
            this.grdFindingDetail.TabIndex = 8;
            this.grdFindingDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewFindingDetail});
            // 
            // viewFindingDetail
            // 
            this.viewFindingDetail.Appearance.GroupRow.Options.UseTextOptions = true;
            this.viewFindingDetail.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewFindingDetail.GridControl = this.grdFindingDetail;
            this.viewFindingDetail.GroupFormat = "{1} {2}";
            this.viewFindingDetail.Name = "viewFindingDetail";
            this.viewFindingDetail.OptionsCustomization.AllowFilter = false;
            this.viewFindingDetail.OptionsLayout.Columns.AddNewColumns = false;
            this.viewFindingDetail.OptionsLayout.Columns.RemoveOldColumns = false;
            this.viewFindingDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewFindingDetail.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.viewFindingDetail.OptionsView.RowAutoHeight = true;
            this.viewFindingDetail.OptionsView.ShowColumnHeaders = false;
            this.viewFindingDetail.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.viewFindingDetail.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.viewFindingDetail.OptionsView.ShowGroupPanel = false;
            this.viewFindingDetail.OptionsView.ShowHorzLines = false;
            this.viewFindingDetail.OptionsView.ShowIndicator = false;
            this.viewFindingDetail.OptionsView.ShowPreviewLines = false;
            this.viewFindingDetail.OptionsView.ShowVertLines = false;
            this.viewFindingDetail.PaintStyleName = "Web";
            this.viewFindingDetail.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.viewFindingDetail_CustomDrawGroupRow);
            this.viewFindingDetail.GroupRowCollapsing += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.viewFindingDetail_GroupRowCollapsing);
            this.viewFindingDetail.EndGrouping += new System.EventHandler(this.viewFindingDetail_EndGrouping);
            // 
            // grdFinding
            // 
            this.grdFinding.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdFinding.Location = new System.Drawing.Point(0, 0);
            this.grdFinding.MainView = this.viewFinding;
            this.grdFinding.Name = "grdFinding";
            this.grdFinding.Size = new System.Drawing.Size(188, 564);
            this.grdFinding.TabIndex = 7;
            this.grdFinding.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewFinding});
            // 
            // viewFinding
            // 
            this.viewFinding.Appearance.GroupRow.Options.UseTextOptions = true;
            this.viewFinding.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewFinding.GridControl = this.grdFinding;
            this.viewFinding.GroupFormat = "{1} {2}";
            this.viewFinding.Name = "viewFinding";
            this.viewFinding.OptionsCustomization.AllowFilter = false;
            this.viewFinding.OptionsLayout.Columns.AddNewColumns = false;
            this.viewFinding.OptionsLayout.Columns.RemoveOldColumns = false;
            this.viewFinding.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewFinding.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.viewFinding.OptionsView.RowAutoHeight = true;
            this.viewFinding.OptionsView.ShowColumnHeaders = false;
            this.viewFinding.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.viewFinding.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.viewFinding.OptionsView.ShowGroupPanel = false;
            this.viewFinding.OptionsView.ShowHorzLines = false;
            this.viewFinding.OptionsView.ShowIndicator = false;
            this.viewFinding.OptionsView.ShowPreviewLines = false;
            this.viewFinding.OptionsView.ShowVertLines = false;
            this.viewFinding.PaintStyleName = "Web";
            this.viewFinding.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.viewFinding_RowCellClick);
            // 
            // tabImpression
            // 
            this.tabImpression.Controls.Add(this.grdImpressionDetail);
            this.tabImpression.Controls.Add(this.grdImpression);
            this.tabImpression.Name = "tabImpression";
            this.tabImpression.Size = new System.Drawing.Size(541, 564);
            this.tabImpression.Text = "Impression";
            // 
            // grdImpressionDetail
            // 
            this.grdImpressionDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdImpressionDetail.Location = new System.Drawing.Point(188, 0);
            this.grdImpressionDetail.MainView = this.viewImpressionDetail;
            this.grdImpressionDetail.Name = "grdImpressionDetail";
            this.grdImpressionDetail.Size = new System.Drawing.Size(353, 564);
            this.grdImpressionDetail.TabIndex = 10;
            this.grdImpressionDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewImpressionDetail});
            // 
            // viewImpressionDetail
            // 
            this.viewImpressionDetail.Appearance.GroupRow.Options.UseTextOptions = true;
            this.viewImpressionDetail.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewImpressionDetail.GridControl = this.grdImpressionDetail;
            this.viewImpressionDetail.GroupFormat = "{1} {2}";
            this.viewImpressionDetail.Name = "viewImpressionDetail";
            this.viewImpressionDetail.OptionsCustomization.AllowFilter = false;
            this.viewImpressionDetail.OptionsLayout.Columns.AddNewColumns = false;
            this.viewImpressionDetail.OptionsLayout.Columns.RemoveOldColumns = false;
            this.viewImpressionDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewImpressionDetail.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.viewImpressionDetail.OptionsView.RowAutoHeight = true;
            this.viewImpressionDetail.OptionsView.ShowColumnHeaders = false;
            this.viewImpressionDetail.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.viewImpressionDetail.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.viewImpressionDetail.OptionsView.ShowGroupPanel = false;
            this.viewImpressionDetail.OptionsView.ShowHorzLines = false;
            this.viewImpressionDetail.OptionsView.ShowIndicator = false;
            this.viewImpressionDetail.OptionsView.ShowPreviewLines = false;
            this.viewImpressionDetail.OptionsView.ShowVertLines = false;
            this.viewImpressionDetail.PaintStyleName = "Web";
            this.viewImpressionDetail.EndSorting += new System.EventHandler(this.viewImpressionDetail_EndSorting);
            this.viewImpressionDetail.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.viewImpressionDetail_CustomDrawGroupRow);
            this.viewImpressionDetail.GroupRowCollapsing += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.viewImpressionDetail_GroupRowCollapsing);
            this.viewImpressionDetail.EndGrouping += new System.EventHandler(this.viewImpressionDetail_EndGrouping);
            // 
            // grdImpression
            // 
            this.grdImpression.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdImpression.Location = new System.Drawing.Point(0, 0);
            this.grdImpression.MainView = this.viewImpression;
            this.grdImpression.Name = "grdImpression";
            this.grdImpression.Size = new System.Drawing.Size(188, 564);
            this.grdImpression.TabIndex = 9;
            this.grdImpression.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewImpression});
            // 
            // viewImpression
            // 
            this.viewImpression.Appearance.GroupRow.Options.UseTextOptions = true;
            this.viewImpression.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewImpression.GridControl = this.grdImpression;
            this.viewImpression.GroupFormat = "{1} {2}";
            this.viewImpression.Name = "viewImpression";
            this.viewImpression.OptionsCustomization.AllowFilter = false;
            this.viewImpression.OptionsLayout.Columns.AddNewColumns = false;
            this.viewImpression.OptionsLayout.Columns.RemoveOldColumns = false;
            this.viewImpression.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewImpression.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.viewImpression.OptionsView.RowAutoHeight = true;
            this.viewImpression.OptionsView.ShowColumnHeaders = false;
            this.viewImpression.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.viewImpression.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.viewImpression.OptionsView.ShowGroupPanel = false;
            this.viewImpression.OptionsView.ShowHorzLines = false;
            this.viewImpression.OptionsView.ShowIndicator = false;
            this.viewImpression.OptionsView.ShowPreviewLines = false;
            this.viewImpression.OptionsView.ShowVertLines = false;
            this.viewImpression.PaintStyleName = "Web";
            this.viewImpression.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.viewImpression_RowCellClick);
            // 
            // rtPreview
            // 
            this.rtPreview.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.rtPreview.Location = new System.Drawing.Point(568, 7);
            this.rtPreview.Name = "rtPreview";
            this.rtPreview.Size = new System.Drawing.Size(299, 476);
            this.rtPreview.TabIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.lblSeverity);
            this.layoutControl1.Controls.Add(this.btnWorklist);
            this.layoutControl1.Controls.Add(this.btnSaveFinalized);
            this.layoutControl1.Controls.Add(this.xtraTabResultControl);
            this.layoutControl1.Controls.Add(this.rtPreview);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(873, 608);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblSeverity
            // 
            this.lblSeverity.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeverity.Appearance.Options.UseFont = true;
            this.lblSeverity.Location = new System.Drawing.Point(568, 494);
            this.lblSeverity.Name = "lblSeverity";
            this.lblSeverity.Size = new System.Drawing.Size(299, 25);
            this.lblSeverity.StyleController = this.layoutControl1;
            this.lblSeverity.TabIndex = 6;
            // 
            // btnWorklist
            // 
            this.btnWorklist.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWorklist.Appearance.Options.UseFont = true;
            this.btnWorklist.Location = new System.Drawing.Point(568, 575);
            this.btnWorklist.Name = "btnWorklist";
            this.btnWorklist.Padding = new System.Windows.Forms.Padding(5);
            this.btnWorklist.Size = new System.Drawing.Size(299, 27);
            this.btnWorklist.StyleController = this.layoutControl1;
            this.btnWorklist.TabIndex = 5;
            this.btnWorklist.Text = "Back to Worklist";
            // 
            // btnSaveFinalized
            // 
            this.btnSaveFinalized.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveFinalized.Appearance.Options.UseFont = true;
            this.btnSaveFinalized.Location = new System.Drawing.Point(568, 530);
            this.btnSaveFinalized.Name = "btnSaveFinalized";
            this.btnSaveFinalized.Padding = new System.Windows.Forms.Padding(10);
            this.btnSaveFinalized.Size = new System.Drawing.Size(299, 34);
            this.btnSaveFinalized.StyleController = this.layoutControl1;
            this.btnSaveFinalized.TabIndex = 4;
            this.btnSaveFinalized.Text = "Save as Final";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(873, 608);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.rtPreview;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(561, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(310, 0);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(310, 31);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(310, 487);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.xtraTabResultControl;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(561, 606);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSaveFinalized;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(561, 523);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(310, 45);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnWorklist;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(561, 568);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(310, 38);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lblSeverity;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(561, 487);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(310, 36);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // xtraControlCovidDEC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "xtraControlCovidDEC";
            this.Size = new System.Drawing.Size(873, 608);
            this.Load += new System.EventHandler(this.xtraControlCovidDEC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabResultControl)).EndInit();
            this.xtraTabResultControl.ResumeLayout(false);
            this.tabFinding.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFindingDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewFindingDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewFinding)).EndInit();
            this.tabImpression.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdImpressionDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewImpressionDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImpression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewImpression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabResultControl;
        private DevExpress.XtraTab.XtraTabPage tabFinding;
        private DevExpress.XtraTab.XtraTabPage tabImpression;
        private DevExpress.XtraRichEdit.RichEditControl rtPreview;
        private DevExpress.XtraGrid.GridControl grdFinding;
        private DevExpress.XtraGrid.Views.Grid.GridView viewFinding;
        private DevExpress.XtraGrid.GridControl grdFindingDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView viewFindingDetail;
        private DevExpress.XtraGrid.GridControl grdImpressionDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView viewImpressionDetail;
        private DevExpress.XtraGrid.GridControl grdImpression;
        private DevExpress.XtraGrid.Views.Grid.GridView viewImpression;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnWorklist;
        private DevExpress.XtraEditors.SimpleButton btnSaveFinalized;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LabelControl lblSeverity;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
