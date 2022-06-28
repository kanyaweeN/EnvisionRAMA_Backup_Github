namespace Envision.NET.Forms.Schedule
{
    partial class frmWaitingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaitingList));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnAccept = new DevExpress.XtraBars.BarButtonItem();
            this.btnGo = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnSummary = new DevExpress.XtraBars.BarButtonItem();
            this.barClose = new DevExpress.XtraBars.BarButtonItem();
            this.barAcceptOnline = new DevExpress.XtraBars.BarButtonItem();
            this.btnPendAccept = new DevExpress.XtraBars.BarButtonItem();
            this.btnPendingClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnPending = new DevExpress.XtraBars.BarButtonItem();
            this.barCloseStatCase = new DevExpress.XtraBars.BarButtonItem();
            this.cmbModality = new DevExpress.XtraBars.BarEditItem();
            this.cmbModalityItems = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.rbbWaiting = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbbPending = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbbAppOnline = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbbOnlineStat = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupbarCloseStatCase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ccbModality = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.contextList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeOrderToScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentWaitingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentPendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.view1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bgRefreshGrid = new System.ComponentModel.BackgroundWorker();
            this.tmRefreshGrid = new System.Windows.Forms.Timer(this.components);
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbModalityItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ccbModality.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.contextList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbonControl1.Images = this.imageCollection1;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAccept,
            this.btnGo,
            this.btnClose,
            this.btnSummary,
            this.barClose,
            this.barAcceptOnline,
            this.btnPendAccept,
            this.btnPendingClose,
            this.btnPending,
            this.barCloseStatCase,
            this.cmbModality});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 12;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbbWaiting,
            this.rbbPending,
            this.rbbAppOnline,
            this.rbbOnlineStat});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbModalityItems});
            this.ribbonControl1.SelectedPage = this.rbbWaiting;
            this.ribbonControl1.Size = new System.Drawing.Size(716, 143);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this.ribbonControl1.SelectedPageChanged += new System.EventHandler(this.ribbonControl1_SelectedPageChanged);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "icoWL-Accept.png");
            this.imageCollection1.Images.SetKeyName(1, "viewtree_24.png");
            this.imageCollection1.Images.SetKeyName(2, "delete.png");
            this.imageCollection1.Images.SetKeyName(3, "history_48.png");
            this.imageCollection1.Images.SetKeyName(4, "Wait-icon32.png");
            // 
            // btnAccept
            // 
            this.btnAccept.Caption = "Accept";
            this.btnAccept.Id = 0;
            this.btnAccept.LargeImageIndex = 0;
            this.btnAccept.LargeWidth = 60;
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAccept_ItemClick);
            // 
            // btnGo
            // 
            this.btnGo.Id = 8;
            this.btnGo.Name = "btnGo";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Id = 2;
            this.btnClose.LargeImageIndex = 2;
            this.btnClose.LargeWidth = 60;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // btnSummary
            // 
            this.btnSummary.Caption = "Summary";
            this.btnSummary.Id = 3;
            this.btnSummary.ImageIndex = 3;
            this.btnSummary.LargeImageIndex = 3;
            this.btnSummary.LargeWidth = 60;
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSummary_ItemClick);
            // 
            // barClose
            // 
            this.barClose.Caption = "Close";
            this.barClose.Id = 4;
            this.barClose.ImageIndex = 2;
            this.barClose.LargeImageIndex = 2;
            this.barClose.LargeWidth = 60;
            this.barClose.Name = "barClose";
            this.barClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barClose_ItemClick);
            // 
            // barAcceptOnline
            // 
            this.barAcceptOnline.Caption = "Accept";
            this.barAcceptOnline.Id = 5;
            this.barAcceptOnline.LargeImageIndex = 0;
            this.barAcceptOnline.LargeWidth = 60;
            this.barAcceptOnline.Name = "barAcceptOnline";
            // 
            // btnPendAccept
            // 
            this.btnPendAccept.Caption = "Accept";
            this.btnPendAccept.Id = 6;
            this.btnPendAccept.LargeImageIndex = 0;
            this.btnPendAccept.LargeWidth = 60;
            this.btnPendAccept.Name = "btnPendAccept";
            this.btnPendAccept.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPendAccept_ItemClick);
            // 
            // btnPendingClose
            // 
            this.btnPendingClose.Caption = "Close";
            this.btnPendingClose.Id = 7;
            this.btnPendingClose.LargeImageIndex = 2;
            this.btnPendingClose.LargeWidth = 60;
            this.btnPendingClose.Name = "btnPendingClose";
            this.btnPendingClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPendingClose_ItemClick);
            // 
            // btnPending
            // 
            this.btnPending.Caption = "Pending";
            this.btnPending.Id = 9;
            this.btnPending.LargeImageIndex = 4;
            this.btnPending.LargeWidth = 60;
            this.btnPending.Name = "btnPending";
            this.btnPending.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPending_ItemClick);
            // 
            // barCloseStatCase
            // 
            this.barCloseStatCase.Caption = "Close";
            this.barCloseStatCase.Id = 10;
            this.barCloseStatCase.LargeImageIndex = 2;
            this.barCloseStatCase.LargeWidth = 60;
            this.barCloseStatCase.Name = "barCloseStatCase";
            this.barCloseStatCase.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCloseStatCase_ItemClick);
            // 
            // cmbModality
            // 
            this.cmbModality.Caption = "Modality : ";
            this.cmbModality.Edit = this.cmbModalityItems;
            this.cmbModality.Id = 11;
            this.cmbModality.Name = "cmbModality";
            this.cmbModality.Width = 200;
            // 
            // cmbModalityItems
            // 
            this.cmbModalityItems.AutoHeight = false;
            this.cmbModalityItems.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbModalityItems.Name = "cmbModalityItems";
            // 
            // rbbWaiting
            // 
            this.rbbWaiting.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup4,
            this.ribbonPageGroup3});
            this.rbbWaiting.Name = "rbbWaiting";
            this.rbbWaiting.Text = "Waiting";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAccept);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPending);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnSummary);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            // 
            // rbbPending
            // 
            this.rbbPending.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup9,
            this.ribbonPageGroup8});
            this.rbbPending.Name = "rbbPending";
            this.rbbPending.Text = "Pending";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.btnPendAccept);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.ShowCaptionButton = false;
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.btnPendingClose);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.ShowCaptionButton = false;
            // 
            // rbbAppOnline
            // 
            this.rbbAppOnline.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.rbbAppOnline.Name = "rbbAppOnline";
            this.rbbAppOnline.Text = "Auto Appointment";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barClose);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            // 
            // rbbOnlineStat
            // 
            this.rbbOnlineStat.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupbarCloseStatCase});
            this.rbbOnlineStat.Name = "rbbOnlineStat";
            this.rbbOnlineStat.Text = "Online Stat Case";
            // 
            // groupbarCloseStatCase
            // 
            this.groupbarCloseStatCase.ItemLinks.Add(this.barCloseStatCase);
            this.groupbarCloseStatCase.Name = "groupbarCloseStatCase";
            this.groupbarCloseStatCase.ShowCaptionButton = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 143);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(716, 397);
            this.panelControl1.TabIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.ccbModality);
            this.layoutControl1.Controls.Add(this.grdData);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(712, 393);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ccbModality
            // 
            this.ccbModality.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ccbModality.Location = new System.Drawing.Point(62, 7);
            this.ccbModality.MenuManager = this.ribbonControl1;
            this.ccbModality.Name = "ccbModality";
            this.ccbModality.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ccbModality.Size = new System.Drawing.Size(210, 20);
            this.ccbModality.StyleController = this.layoutControl1;
            this.ccbModality.TabIndex = 3;
            this.ccbModality.EditValueChanged += new System.EventHandler(this.ccbModality_EditValueChanged);
            // 
            // grdData
            // 
            this.grdData.ContextMenuStrip = this.contextList;
            this.grdData.Location = new System.Drawing.Point(7, 38);
            this.grdData.MainView = this.view1;
            this.grdData.MenuManager = this.ribbonControl1;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(699, 349);
            this.grdData.TabIndex = 0;
            this.grdData.ToolTipController = this.toolTipController1;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view1});
            // 
            // contextList
            // 
            this.contextList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeOrderToScheduleToolStripMenuItem,
            this.commentWaitingListToolStripMenuItem,
            this.commentPendingToolStripMenuItem});
            this.contextList.Name = "contextList";
            this.contextList.Size = new System.Drawing.Size(214, 70);
            this.contextList.Opening += new System.ComponentModel.CancelEventHandler(this.contextList_Opening);
            // 
            // changeOrderToScheduleToolStripMenuItem
            // 
            this.changeOrderToScheduleToolStripMenuItem.Name = "changeOrderToScheduleToolStripMenuItem";
            this.changeOrderToScheduleToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.changeOrderToScheduleToolStripMenuItem.Text = "Change Order to Schedule";
            this.changeOrderToScheduleToolStripMenuItem.Visible = false;
            this.changeOrderToScheduleToolStripMenuItem.Click += new System.EventHandler(this.changeOrderToScheduleToolStripMenuItem_Click);
            // 
            // commentWaitingListToolStripMenuItem
            // 
            this.commentWaitingListToolStripMenuItem.Name = "commentWaitingListToolStripMenuItem";
            this.commentWaitingListToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.commentWaitingListToolStripMenuItem.Text = "Comments";
            this.commentWaitingListToolStripMenuItem.Visible = false;
            this.commentWaitingListToolStripMenuItem.Click += new System.EventHandler(this.commentWaitingListToolStripMenuItem_Click);
            // 
            // commentPendingToolStripMenuItem
            // 
            this.commentPendingToolStripMenuItem.Name = "commentPendingToolStripMenuItem";
            this.commentPendingToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.commentPendingToolStripMenuItem.Text = "Comments";
            this.commentPendingToolStripMenuItem.Visible = false;
            this.commentPendingToolStripMenuItem.Click += new System.EventHandler(this.commentPendingToolStripMenuItem_Click);
            // 
            // view1
            // 
            this.view1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.view1.GridControl = this.grdData;
            this.view1.Name = "view1";
            this.view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.view1.OptionsView.ShowBands = false;
            this.view1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.view1.OptionsView.ShowGroupPanel = false;
            this.view1.GroupRowCollapsing += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.view1_GroupRowCollapsing);
            this.view1.DoubleClick += new System.EventHandler(this.view1_DoubleClick);
            this.view1.EndGrouping += new System.EventHandler(this.view1_EndGrouping);
            this.view1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.view1_RowStyle);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // toolTipController1
            // 
            this.toolTipController1.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController1_GetActiveObjectInfo);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(712, 393);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdData;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(710, 360);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ccbModality;
            this.layoutControlItem2.CustomizationFormText = "Modality : ";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(276, 31);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(276, 31);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(276, 31);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Modality : ";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(276, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(434, 31);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnPendAccept);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.ShowCaptionButton = false;
            // 
            // bgRefreshGrid
            // 
            this.bgRefreshGrid.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRefreshGrid_DoWork);
            this.bgRefreshGrid.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgRefreshGrid_RunWorkerCompleted);
            // 
            // tmRefreshGrid
            // 
            this.tmRefreshGrid.Tick += new System.EventHandler(this.tmRefreshGrid_Tick);
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.Images.SetKeyName(0, "alert.png");
            // 
            // frmWaitingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 540);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWaitingList";
            this.Ribbon = this.ribbonControl1;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Waiting List";
            this.Load += new System.EventHandler(this.frmWaitingList_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWaitingList_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbModalityItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ccbModality.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.contextList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.view1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnAccept;
        private DevExpress.XtraBars.BarButtonItem btnGo;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbbWaiting;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView view1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraBars.BarButtonItem btnSummary;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbbAppOnline;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem barAcceptOnline;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbbPending;
        private DevExpress.XtraBars.BarButtonItem btnPendAccept;
        private DevExpress.XtraBars.BarButtonItem btnPendingClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.BarButtonItem btnPending;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private System.ComponentModel.BackgroundWorker bgRefreshGrid;
        private System.Windows.Forms.Timer tmRefreshGrid;
        private DevExpress.XtraBars.BarButtonItem barCloseStatCase;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbbOnlineStat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupbarCloseStatCase;
        private DevExpress.XtraBars.BarEditItem cmbModality;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbModalityItems;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ccbModality;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.ContextMenuStrip contextList;
        private System.Windows.Forms.ToolStripMenuItem changeOrderToScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentWaitingListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentPendingToolStripMenuItem;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}