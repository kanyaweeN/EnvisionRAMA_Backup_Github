namespace Envision.NET.Forms.ResultEntry
{
    partial class frmPopupEvaluationExtend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPopupEvaluationExtend));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnChange = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtEvaluationReport = new DevExpress.XtraRichEdit.RichEditControl();
            this.rdoClinicSign = new DevExpress.XtraEditors.RadioGroup();
            this.txtComment = new DevExpress.XtraEditors.MemoEdit();
            this.tbLangComment = new DevExpress.XtraEditors.MemoEdit();
            this.gridControlGrade = new DevExpress.XtraGrid.GridControl();
            this.gridViewGrade = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsChkOpinion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repChkOpinion = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcGRADE_LABEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlLangaugeOfReport = new DevExpress.XtraGrid.GridControl();
            this.gridViewLangaugeOfReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsChkReport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repChkReport1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelEvaluationReport = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoClinicSign.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLangComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChkOpinion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLangaugeOfReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLangaugeOfReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChkReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelEvaluationReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSave,
            this.btnChange,
            this.btnCancel});
            this.ribbon.LargeImages = this.imageCollection1;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.SelectedPage = this.ribbonPage1;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(792, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Id = 0;
            this.btnSave.LargeImageIndex = 2;
            this.btnSave.LargeWidth = 50;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnChange
            // 
            this.btnChange.Caption = "Edit";
            this.btnChange.Id = 1;
            this.btnChange.LargeImageIndex = 1;
            this.btnChange.LargeWidth = 50;
            this.btnChange.Name = "btnChange";
            this.btnChange.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChange_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.Id = 2;
            this.btnCancel.LargeImageIndex = 3;
            this.btnCancel.LargeWidth = 50;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "delete_32.png");
            this.imageCollection1.Images.SetKeyName(1, "edit_2add.png");
            this.imageCollection1.Images.SetKeyName(2, "save.png");
            this.imageCollection1.Images.SetKeyName(3, "close3_32.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Feedback";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnChange);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCancel);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 674);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(792, 25);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.layoutControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 143);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(792, 531);
            this.clientPanel.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.txtEvaluationReport);
            this.layoutControl1.Controls.Add(this.rdoClinicSign);
            this.layoutControl1.Controls.Add(this.txtComment);
            this.layoutControl1.Controls.Add(this.tbLangComment);
            this.layoutControl1.Controls.Add(this.gridControlGrade);
            this.layoutControl1.Controls.Add(this.gridControlLangaugeOfReport);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(792, 531);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtEvaluationReport
            // 
            this.txtEvaluationReport.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtEvaluationReport.Location = new System.Drawing.Point(10, 408);
            this.txtEvaluationReport.MenuManager = this.ribbon;
            this.txtEvaluationReport.Name = "txtEvaluationReport";
            this.txtEvaluationReport.ReadOnly = true;
            this.txtEvaluationReport.Size = new System.Drawing.Size(773, 114);
            this.txtEvaluationReport.TabIndex = 18;
            this.txtEvaluationReport.Text = "richEditControl1";
            // 
            // rdoClinicSign
            // 
            this.rdoClinicSign.Location = new System.Drawing.Point(357, 25);
            this.rdoClinicSign.MenuManager = this.ribbon;
            this.rdoClinicSign.Name = "rdoClinicSign";
            this.rdoClinicSign.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Likely"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Unlikely")});
            this.rdoClinicSign.Size = new System.Drawing.Size(429, 25);
            this.rdoClinicSign.StyleController = this.layoutControl1;
            this.rdoClinicSign.TabIndex = 17;
            this.rdoClinicSign.SelectedIndexChanged += new System.EventHandler(this.rdoClinicSign_SelectedIndexChanged);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(357, 79);
            this.txtComment.MenuManager = this.ribbon;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(429, 107);
            this.txtComment.StyleController = this.layoutControl1;
            this.txtComment.TabIndex = 16;
            // 
            // tbLangComment
            // 
            this.tbLangComment.Location = new System.Drawing.Point(357, 215);
            this.tbLangComment.MenuManager = this.ribbon;
            this.tbLangComment.Name = "tbLangComment";
            this.tbLangComment.Size = new System.Drawing.Size(429, 161);
            this.tbLangComment.StyleController = this.layoutControl1;
            this.tbLangComment.TabIndex = 15;
            // 
            // gridControlGrade
            // 
            this.gridControlGrade.Location = new System.Drawing.Point(7, 7);
            this.gridControlGrade.MainView = this.gridViewGrade;
            this.gridControlGrade.Name = "gridControlGrade";
            this.gridControlGrade.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repChkOpinion});
            this.gridControlGrade.Size = new System.Drawing.Size(339, 179);
            this.gridControlGrade.TabIndex = 5;
            this.gridControlGrade.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewGrade});
            this.gridControlGrade.DoubleClick += new System.EventHandler(this.gridControlGrade_DoubleClick);
            // 
            // gridViewGrade
            // 
            this.gridViewGrade.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsChkOpinion,
            this.gcGRADE_LABEL});
            this.gridViewGrade.GridControl = this.gridControlGrade;
            this.gridViewGrade.Name = "gridViewGrade";
            this.gridViewGrade.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewGrade.OptionsView.ShowGroupPanel = false;
            // 
            // colsChkOpinion
            // 
            this.colsChkOpinion.Caption = " ";
            this.colsChkOpinion.ColumnEdit = this.repChkOpinion;
            this.colsChkOpinion.FieldName = "IS_SELECTED";
            this.colsChkOpinion.Name = "colsChkOpinion";
            this.colsChkOpinion.Visible = true;
            this.colsChkOpinion.VisibleIndex = 0;
            this.colsChkOpinion.Width = 20;
            // 
            // repChkOpinion
            // 
            this.repChkOpinion.AutoHeight = false;
            this.repChkOpinion.Name = "repChkOpinion";
            this.repChkOpinion.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repChkOpinion.ValueChecked = "Y";
            this.repChkOpinion.ValueUnchecked = "N";
            this.repChkOpinion.Click += new System.EventHandler(this.repChkOpinion_Click);
            // 
            // gcGRADE_LABEL
            // 
            this.gcGRADE_LABEL.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcGRADE_LABEL.AppearanceHeader.Options.UseFont = true;
            this.gcGRADE_LABEL.Caption = "Opinion of Clinical Report";
            this.gcGRADE_LABEL.FieldName = "GRADE_LABEL";
            this.gcGRADE_LABEL.Name = "gcGRADE_LABEL";
            this.gcGRADE_LABEL.OptionsColumn.AllowEdit = false;
            this.gcGRADE_LABEL.Visible = true;
            this.gcGRADE_LABEL.VisibleIndex = 1;
            this.gcGRADE_LABEL.Width = 302;
            // 
            // gridControlLangaugeOfReport
            // 
            gridLevelNode1.RelationName = "Level1";
            this.gridControlLangaugeOfReport.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControlLangaugeOfReport.Location = new System.Drawing.Point(7, 197);
            this.gridControlLangaugeOfReport.MainView = this.gridViewLangaugeOfReport;
            this.gridControlLangaugeOfReport.Name = "gridControlLangaugeOfReport";
            this.gridControlLangaugeOfReport.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repChkReport1});
            this.gridControlLangaugeOfReport.Size = new System.Drawing.Size(339, 179);
            this.gridControlLangaugeOfReport.TabIndex = 14;
            this.gridControlLangaugeOfReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLangaugeOfReport});
            this.gridControlLangaugeOfReport.DoubleClick += new System.EventHandler(this.gridControlLangaugeOfReport_DoubleClick);
            // 
            // gridViewLangaugeOfReport
            // 
            this.gridViewLangaugeOfReport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colsChkReport});
            this.gridViewLangaugeOfReport.GridControl = this.gridControlLangaugeOfReport;
            this.gridViewLangaugeOfReport.Name = "gridViewLangaugeOfReport";
            this.gridViewLangaugeOfReport.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewLangaugeOfReport.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "Language of Report";
            this.gridColumn1.FieldName = "REPORT_LANG_LABEL";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 302;
            // 
            // colsChkReport
            // 
            this.colsChkReport.Caption = " ";
            this.colsChkReport.ColumnEdit = this.repChkReport1;
            this.colsChkReport.FieldName = "IS_SELECTED";
            this.colsChkReport.Name = "colsChkReport";
            this.colsChkReport.Visible = true;
            this.colsChkReport.VisibleIndex = 0;
            this.colsChkReport.Width = 20;
            // 
            // repChkReport1
            // 
            this.repChkReport1.AutoHeight = false;
            this.repChkReport1.Name = "repChkReport1";
            this.repChkReport1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repChkReport1.ValueChecked = "Y";
            this.repChkReport1.ValueUnchecked = "N";
            this.repChkReport1.Click += new System.EventHandler(this.repChkReport1_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.panelEvaluationReport});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(792, 531);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControlLangaugeOfReport;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 190);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(350, 190);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(350, 190);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(350, 190);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlGrade;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(350, 190);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(350, 190);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(350, 190);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.tbLangComment;
            this.layoutControlItem3.CustomizationFormText = "Comments";
            this.layoutControlItem3.Location = new System.Drawing.Point(350, 190);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(440, 190);
            this.layoutControlItem3.Text = "Comments";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(317, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtComment;
            this.layoutControlItem4.CustomizationFormText = "If you disagree, please give your comments(s) in this box";
            this.layoutControlItem4.Location = new System.Drawing.Point(350, 54);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(440, 136);
            this.layoutControlItem4.Text = "If you disagree, please give your comments(s) in this box";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(317, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.rdoClinicSign;
            this.layoutControlItem5.CustomizationFormText = "If you disagree,do you think this is likely to be clinically significant?";
            this.layoutControlItem5.Location = new System.Drawing.Point(350, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 54);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(100, 54);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(440, 54);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "If you disagree,do you think this is likely to be clinically significant?";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(317, 13);
            // 
            // panelEvaluationReport
            // 
            this.panelEvaluationReport.CustomizationFormText = "panelEvaluationReport";
            this.panelEvaluationReport.ExpandButtonVisible = true;
            this.panelEvaluationReport.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6});
            this.panelEvaluationReport.Location = new System.Drawing.Point(0, 380);
            this.panelEvaluationReport.Name = "panelEvaluationReport";
            this.panelEvaluationReport.Size = new System.Drawing.Size(790, 149);
            this.panelEvaluationReport.Text = "Evaluation Report Result";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtEvaluationReport;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(784, 125);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 221);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(325, 214);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // frmPopupEvaluationExtend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 699);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmPopupEvaluationExtend";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Feedback";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoClinicSign.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLangComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChkOpinion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLangaugeOfReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLangaugeOfReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChkReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelEvaluationReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControlGrade;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewGrade;
        private DevExpress.XtraGrid.Columns.GridColumn gcGRADE_LABEL;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.GridControl gridControlLangaugeOfReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLangaugeOfReport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.RadioGroup rdoClinicSign;
        private DevExpress.XtraEditors.MemoEdit txtComment;
        private DevExpress.XtraEditors.MemoEdit tbLangComment;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem btnChange;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraGrid.Columns.GridColumn colsChkOpinion;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repChkOpinion;
        private DevExpress.XtraGrid.Columns.GridColumn colsChkReport;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repChkReport1;
        private DevExpress.XtraLayout.LayoutControlGroup panelEvaluationReport;
        private DevExpress.XtraRichEdit.RichEditControl txtEvaluationReport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}