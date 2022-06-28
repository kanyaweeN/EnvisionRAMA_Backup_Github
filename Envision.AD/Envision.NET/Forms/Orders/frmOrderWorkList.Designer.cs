namespace Envision.NET.Forms.Orders
{
    partial class frmOrderWorkList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderWorkList));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barCreateNew = new DevExpress.XtraBars.BarButtonItem();
            this.barModify = new DevExpress.XtraBars.BarButtonItem();
            this.barSchedule = new DevExpress.XtraBars.BarButtonItem();
            this.barPatient = new DevExpress.XtraBars.BarButtonItem();
            this.barLastOrder = new DevExpress.XtraBars.BarButtonItem();
            this.barView = new DevExpress.XtraBars.BarButtonItem();
            this.barHome = new DevExpress.XtraBars.BarButtonItem();
            this.barPrintLast = new DevExpress.XtraBars.BarButtonItem();
            this.barManul = new DevExpress.XtraBars.BarButtonItem();
            this.barClose = new DevExpress.XtraBars.BarButtonItem();
            this.barWorkList = new DevExpress.XtraBars.BarButtonItem();
            this.barScanImage = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.grdWorkList = new DevExpress.XtraGrid.GridControl();
            this.view1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dateSearch = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkSearch = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateSearch2 = new DevExpress.XtraEditors.DateEdit();
            this.chkToday = new DevExpress.XtraEditors.CheckEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.bgWL = new System.ComponentModel.BackgroundWorker();
            this.barComments = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSearch.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateSearch2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSearch2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkToday.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = null;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barCreateNew,
            this.barModify,
            this.barSchedule,
            this.barPatient,
            this.barLastOrder,
            this.barView,
            this.barHome,
            this.barPrintLast,
            this.barManul,
            this.barClose,
            this.barWorkList,
            this.barScanImage,
            this.barComments});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 25;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.SelectedPage = this.ribbonPage1;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(854, 96);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barCreateNew
            // 
            this.barCreateNew.Caption = "New  Order ";
            this.barCreateNew.Id = 12;
            this.barCreateNew.LargeImageIndex = 6;
            this.barCreateNew.LargeWidth = 70;
            this.barCreateNew.Name = "barCreateNew";
            this.barCreateNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCreateNew_ItemClick);
            // 
            // barModify
            // 
            this.barModify.Caption = "Edit Order";
            this.barModify.Id = 13;
            this.barModify.ImageIndex = 0;
            this.barModify.LargeImageIndex = 0;
            this.barModify.LargeWidth = 60;
            this.barModify.Name = "barModify";
            this.barModify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barModify_ItemClick);
            // 
            // barSchedule
            // 
            this.barSchedule.Caption = " Schedule ";
            this.barSchedule.Id = 14;
            this.barSchedule.ImageIndex = 7;
            this.barSchedule.LargeImageIndex = 9;
            this.barSchedule.LargeWidth = 60;
            this.barSchedule.Name = "barSchedule";
            this.barSchedule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSchedule_ItemClick);
            // 
            // barPatient
            // 
            this.barPatient.Caption = " Patient  ";
            this.barPatient.Id = 15;
            this.barPatient.ImageIndex = 6;
            this.barPatient.LargeImageIndex = 8;
            this.barPatient.LargeWidth = 60;
            this.barPatient.Name = "barPatient";
            // 
            // barLastOrder
            // 
            this.barLastOrder.Caption = "Last Order";
            this.barLastOrder.Id = 16;
            this.barLastOrder.ImageIndex = 9;
            this.barLastOrder.LargeImageIndex = 9;
            this.barLastOrder.LargeWidth = 60;
            this.barLastOrder.Name = "barLastOrder";
            this.barLastOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLastOrder_ItemClick);
            // 
            // barView
            // 
            this.barView.Caption = "Performance";
            this.barView.Id = 17;
            this.barView.ImageIndex = 1;
            this.barView.LargeImageIndex = 1;
            this.barView.LargeWidth = 66;
            this.barView.Name = "barView";
            this.barView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barView_ItemClick);
            // 
            // barHome
            // 
            this.barHome.Caption = "    Home   ";
            this.barHome.Id = 18;
            this.barHome.ImageIndex = 2;
            this.barHome.LargeImageIndex = 2;
            this.barHome.LargeWidth = 60;
            this.barHome.Name = "barHome";
            this.barHome.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barHome_ItemClick);
            // 
            // barPrintLast
            // 
            this.barPrintLast.Caption = "Reprint";
            this.barPrintLast.Id = 19;
            this.barPrintLast.ImageIndex = 10;
            this.barPrintLast.LargeImageIndex = 7;
            this.barPrintLast.LargeWidth = 60;
            this.barPrintLast.Name = "barPrintLast";
            this.barPrintLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPrintLast_ItemClick);
            // 
            // barManul
            // 
            this.barManul.Caption = "Manual";
            this.barManul.Id = 20;
            this.barManul.LargeImageIndex = 4;
            this.barManul.LargeWidth = 60;
            this.barManul.Name = "barManul";
            this.barManul.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManul_ItemClick);
            // 
            // barClose
            // 
            this.barClose.Caption = "     Close    ";
            this.barClose.Id = 21;
            this.barClose.ImageIndex = 8;
            this.barClose.LargeImageIndex = 1;
            this.barClose.LargeWidth = 60;
            this.barClose.Name = "barClose";
            this.barClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barClose_ItemClick);
            // 
            // barWorkList
            // 
            this.barWorkList.Caption = "Worklist";
            this.barWorkList.Id = 22;
            this.barWorkList.LargeImageIndex = 10;
            this.barWorkList.LargeWidth = 60;
            this.barWorkList.Name = "barWorkList";
            // 
            // barScanImage
            // 
            this.barScanImage.Caption = "Scan";
            this.barScanImage.Id = 23;
            this.barScanImage.LargeImageIndex = 11;
            this.barScanImage.LargeWidth = 60;
            this.barScanImage.Name = "barScanImage";
            this.barScanImage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barScanImage_ItemClick);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(60, 60);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "adminstrator_48.png");
            this.imageCollection1.Images.SetKeyName(1, "alert_caution_and_warning48.png");
            this.imageCollection1.Images.SetKeyName(2, "home_48.png");
            this.imageCollection1.Images.SetKeyName(3, "johndoegood.png");
            this.imageCollection1.Images.SetKeyName(4, "manual_order48.png");
            this.imageCollection1.Images.SetKeyName(5, "new_from_last_order2_48.png");
            this.imageCollection1.Images.SetKeyName(6, "order_48.png");
            this.imageCollection1.Images.SetKeyName(7, "reprint_48.png");
            this.imageCollection1.Images.SetKeyName(8, "result_48.png");
            this.imageCollection1.Images.SetKeyName(9, "schedule_48.png");
            this.imageCollection1.Images.SetKeyName(10, "signature48.png");
            this.imageCollection1.Images.SetKeyName(11, "remote-scan_icon_medium.gif");
            this.imageCollection1.Images.SetKeyName(12, "mail-reply-all-3.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup9,
            this.ribbonPageGroup11,
            this.ribbonPageGroup5,
            this.ribbonPageGroup4,
            this.ribbonPageGroup3,
            this.ribbonPageGroup6,
            this.ribbonPageGroup8,
            this.ribbonPageGroup10});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Order Management";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barCreateNew);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "                     ";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ImageIndex = 1;
            this.ribbonPageGroup2.ItemLinks.Add(this.barModify);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "                  ";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.AllowTextClipping = false;
            this.ribbonPageGroup9.ItemLinks.Add(this.barManul);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.ShowCaptionButton = false;
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.ItemLinks.Add(this.barWorkList);
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            this.ribbonPageGroup11.ShowCaptionButton = false;
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.AllowTextClipping = false;
            this.ribbonPageGroup5.ImageIndex = 5;
            this.ribbonPageGroup5.ItemLinks.Add(this.barLastOrder);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            this.ribbonPageGroup5.Text = "                   ";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ImageIndex = 3;
            this.ribbonPageGroup4.ItemLinks.Add(this.barScanImage);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "                     ";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ImageIndex = 8;
            this.ribbonPageGroup3.ItemLinks.Add(this.barComments);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "                 ";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.AllowTextClipping = false;
            this.ribbonPageGroup6.ImageIndex = 6;
            this.ribbonPageGroup6.ItemLinks.Add(this.barPrintLast);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.ShowCaptionButton = false;
            this.ribbonPageGroup6.Text = "             ";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.AllowTextClipping = false;
            this.ribbonPageGroup8.ImageIndex = 2;
            this.ribbonPageGroup8.ItemLinks.Add(this.barHome);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.ShowCaptionButton = false;
            this.ribbonPageGroup8.Text = "                  ";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.AllowTextClipping = false;
            this.ribbonPageGroup10.ItemLinks.Add(this.barClose);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.ShowCaptionButton = false;
            // 
            // grdWorkList
            // 
            this.grdWorkList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWorkList.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWorkList.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grdWorkList.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grdWorkList.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grdWorkList.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.grdWorkList.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grdWorkList.Location = new System.Drawing.Point(7, 35);
            this.grdWorkList.MainView = this.view1;
            this.grdWorkList.Name = "grdWorkList";
            this.grdWorkList.Size = new System.Drawing.Size(830, 472);
            this.grdWorkList.TabIndex = 27;
            this.grdWorkList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view1});
            // 
            // view1
            // 
            this.view1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.view1.GridControl = this.grdWorkList;
            this.view1.Name = "view1";
            this.view1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.view1.OptionsFilter.AllowFilterEditor = false;
            this.view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.view1.OptionsView.ColumnAutoWidth = true;
            this.view1.OptionsView.ShowAutoFilterRow = true;
            this.view1.OptionsView.ShowBands = false;
            this.view1.OptionsView.ShowGroupPanel = false;
            this.view1.DoubleClick += new System.EventHandler(this.view1_DoubleClick);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dateSearch
            // 
            this.dateSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dateSearch.EditValue = null;
            this.dateSearch.Location = new System.Drawing.Point(204, 7);
            this.dateSearch.Name = "dateSearch";
            this.dateSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateSearch.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateSearch.Size = new System.Drawing.Size(110, 20);
            this.dateSearch.TabIndex = 30;
            this.dateSearch.EditValueChanged += new System.EventHandler(this.dateSearch_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(558, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "Select HN :";
            // 
            // chkSearch
            // 
            this.chkSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.chkSearch.EditValue = true;
            this.chkSearch.Location = new System.Drawing.Point(123, 8);
            this.chkSearch.Name = "chkSearch";
            this.chkSearch.Properties.Caption = "Search";
            this.chkSearch.Size = new System.Drawing.Size(75, 18);
            this.chkSearch.TabIndex = 32;
            this.chkSearch.CheckedChanged += new System.EventHandler(this.chkSearch_CheckedChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.dateSearch2);
            this.groupControl1.Controls.Add(this.chkToday);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.textBox1);
            this.groupControl1.Controls.Add(this.btnRefresh);
            this.groupControl1.Controls.Add(this.grdWorkList);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.chkSearch);
            this.groupControl1.Controls.Add(this.dateSearch);
            this.groupControl1.Location = new System.Drawing.Point(0, 102);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(842, 512);
            this.groupControl1.TabIndex = 33;
            this.groupControl1.Text = "groupControl1";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelControl2.Location = new System.Drawing.Point(320, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(10, 13);
            this.labelControl2.TabIndex = 38;
            this.labelControl2.Text = "to";
            // 
            // dateSearch2
            // 
            this.dateSearch2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dateSearch2.EditValue = null;
            this.dateSearch2.Location = new System.Drawing.Point(336, 7);
            this.dateSearch2.MenuManager = this.ribbonControl1;
            this.dateSearch2.Name = "dateSearch2";
            this.dateSearch2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateSearch2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateSearch2.Size = new System.Drawing.Size(111, 20);
            this.dateSearch2.TabIndex = 37;
            // 
            // chkToday
            // 
            this.chkToday.Location = new System.Drawing.Point(497, 6);
            this.chkToday.MenuManager = this.ribbonControl1;
            this.chkToday.Name = "chkToday";
            this.chkToday.Properties.Caption = "Today";
            this.chkToday.Size = new System.Drawing.Size(34, 18);
            this.chkToday.TabIndex = 36;
            this.chkToday.Visible = false;
            this.chkToday.CheckedChanged += new System.EventHandler(this.chkToday_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(761, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 35;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(617, 7);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 20);
            this.textBox1.TabIndex = 34;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 33;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // bgWL
            // 
            this.bgWL.WorkerSupportsCancellation = true;
            this.bgWL.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWL_DoWork);
            // 
            // barComments
            // 
            this.barComments.Caption = "Comments";
            this.barComments.Id = 24;
            this.barComments.LargeImageIndex = 12;
            this.barComments.LargeWidth = 60;
            this.barComments.Name = "barComments";
            this.barComments.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barComments_ItemClick);
            // 
            // frmOrderWorkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 617);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmOrderWorkList";
            this.Text = "Order work list";
            this.Load += new System.EventHandler(this.frmOrderWorkList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSearch.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateSearch2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSearch2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkToday.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        public DevExpress.XtraBars.BarButtonItem barCreateNew;
        public DevExpress.XtraBars.BarButtonItem barModify;
        public DevExpress.XtraBars.BarButtonItem barSchedule;
        public DevExpress.XtraBars.BarButtonItem barPatient;
        public DevExpress.XtraBars.BarButtonItem barLastOrder;
        public DevExpress.XtraBars.BarButtonItem barView;
        public DevExpress.XtraBars.BarButtonItem barHome;
        public DevExpress.XtraBars.BarButtonItem barPrintLast;
        private DevExpress.XtraBars.BarButtonItem barManul;
        private DevExpress.XtraBars.BarButtonItem barClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraGrid.GridControl grdWorkList;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView view1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.DateEdit dateSearch;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkSearch;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarButtonItem barWorkList;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup11;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.ComponentModel.BackgroundWorker bgWL;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.CheckEdit chkToday;
        private DevExpress.XtraEditors.DateEdit dateSearch2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraBars.BarButtonItem barScanImage;
        private DevExpress.XtraBars.BarButtonItem barComments;
    }
}