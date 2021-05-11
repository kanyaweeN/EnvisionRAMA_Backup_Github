namespace Envision.NET.Forms.Main
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup1 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            this.ribMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.appMain = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.btnLogOff = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.pccMain = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.lblVersion = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.navBarImg = new DevExpress.Utils.ImageCollection(this.components);
            this.barCalculator = new DevExpress.XtraBars.BarButtonItem();
            this.barNotePad = new DevExpress.XtraBars.BarButtonItem();
            this.barMessage = new DevExpress.XtraBars.BarButtonItem();
            this.barComments = new DevExpress.XtraBars.BarButtonItem();
            this.barMyDocument = new DevExpress.XtraBars.BarButtonItem();
            this.barHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barCareLink = new DevExpress.XtraBars.BarButtonItem();
            this.ribMainStatus = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.mdiMain = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.navBarMain = new DevExpress.XtraNavBar.NavBarControl();
            this.splitLeft = new DevExpress.XtraEditors.SplitterControl();
            this.myDefaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.gddFont = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
            this.bgPort = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblUserName = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblHosName = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblDate = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbLanguage = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolBarImg = new System.Windows.Forms.ToolStripButton();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.bgMsg = new System.ComponentModel.BackgroundWorker();
            this.alertMsg = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.rbMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bgPreload = new System.ComponentModel.BackgroundWorker();
            this.tmMsg = new System.Windows.Forms.Timer(this.components);
            this.alertComment = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.appMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pccMain)).BeginInit();
            this.pccMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdiMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gddFont)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribMain
            // 
            this.ribMain.ApplicationButtonDropDownControl = this.appMain;
            this.ribMain.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribMain.Images = this.navBarImg;
            this.ribMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnLogOff,
            this.btnExit,
            this.barCalculator,
            this.barNotePad,
            this.barMessage,
            this.barComments,
            this.barMyDocument,
            this.barHelp,
            this.barCareLink});
            this.ribMain.Location = new System.Drawing.Point(0, 0);
            this.ribMain.MaxItemId = 12;
            this.ribMain.Name = "ribMain";
            this.ribMain.PageCategoryAlignment = DevExpress.XtraBars.Ribbon.RibbonPageCategoryAlignment.Right;
            this.ribMain.PageHeaderItemLinks.Add(this.barHelp);
            this.ribMain.ShowToolbarCustomizeItem = false;
            this.ribMain.Size = new System.Drawing.Size(1016, 52);
            this.ribMain.StatusBar = this.ribMainStatus;
            this.ribMain.Toolbar.ItemLinks.Add(this.barCalculator);
            this.ribMain.Toolbar.ItemLinks.Add(this.barNotePad);
            this.ribMain.Toolbar.ItemLinks.Add(this.barMessage);
            this.ribMain.Toolbar.ItemLinks.Add(this.barComments);
            this.ribMain.Toolbar.ItemLinks.Add(this.barMyDocument);
            this.ribMain.Toolbar.ItemLinks.Add(this.barCareLink);
            this.ribMain.Toolbar.ShowCustomizeItem = false;
            this.ribMain.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // appMain
            // 
            this.appMain.BottomPaneControlContainer = null;
            this.appMain.ItemLinks.Add(this.btnLogOff);
            this.appMain.ItemLinks.Add(this.btnExit);
            this.appMain.Name = "appMain";
            this.appMain.Ribbon = this.ribMain;
            this.appMain.RightPaneControlContainer = this.pccMain;
            this.appMain.ShowRightPane = true;
            // 
            // btnLogOff
            // 
            this.btnLogOff.Caption = "LogOff";
            this.btnLogOff.Id = 0;
            this.btnLogOff.LargeGlyph = global::Envision.NET.Properties.Resources.logoff32;
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogOff_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 1;
            this.btnExit.LargeGlyph = global::Envision.NET.Properties.Resources.exit32;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // pccMain
            // 
            this.pccMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pccMain.Controls.Add(this.lblVersion);
            this.pccMain.Controls.Add(this.labelControl2);
            this.pccMain.Controls.Add(this.labelControl1);
            this.pccMain.Location = new System.Drawing.Point(345, 281);
            this.pccMain.Name = "pccMain";
            this.pccMain.Ribbon = this.ribMain;
            this.pccMain.Size = new System.Drawing.Size(246, 59);
            this.pccMain.TabIndex = 8;
            this.pccMain.Visible = false;
            // 
            // lblVersion
            // 
            this.lblVersion.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Appearance.Options.UseFont = true;
            this.lblVersion.Location = new System.Drawing.Point(108, 15);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(0, 13);
            this.lblVersion.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(33, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(151, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Copyright © 2009 MATLAB.";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(33, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Envision.NET";
            // 
            // navBarImg
            // 
            this.navBarImg.ImageSize = new System.Drawing.Size(24, 24);
            this.navBarImg.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("navBarImg.ImageStream")));
            this.navBarImg.Images.SetKeyName(0, "icon_home32.png");
            this.navBarImg.Images.SetKeyName(1, "icon_schedule32.png");
            this.navBarImg.Images.SetKeyName(2, "icon_order32.png");
            this.navBarImg.Images.SetKeyName(3, "technologist32.png");
            this.navBarImg.Images.SetKeyName(4, "reporting_management2_32.png");
            this.navBarImg.Images.SetKeyName(5, "business_intelligence32.png");
            this.navBarImg.Images.SetKeyName(6, "personal_schedule32.png");
            this.navBarImg.Images.SetKeyName(7, "browse_24.png");
            this.navBarImg.Images.SetKeyName(8, "calculator_orange24.jpg");
            this.navBarImg.Images.SetKeyName(9, "icon_adminstrator32.png");
            this.navBarImg.Images.SetKeyName(10, "mechanic2.png");
            this.navBarImg.Images.SetKeyName(11, "Calculator_16.png");
            this.navBarImg.Images.SetKeyName(12, "Notepad_Icon.png");
            this.navBarImg.Images.SetKeyName(13, "mail-mark-unread-new.png");
            this.navBarImg.Images.SetKeyName(14, "gmail-icon128.jpg");
            this.navBarImg.Images.SetKeyName(15, "gmail-icon128_NewMessage.jpg");
            this.navBarImg.Images.SetKeyName(16, "mail-reply-all-3.png");
            this.navBarImg.Images.SetKeyName(17, "menuStructure.png");
            this.navBarImg.Images.SetKeyName(18, "menuAcedemic.png");
            this.navBarImg.Images.SetKeyName(19, "menuOlap.png");
            this.navBarImg.Images.SetKeyName(20, "menuRisk.png");
            this.navBarImg.Images.SetKeyName(21, "shared folder.png");
            this.navBarImg.Images.SetKeyName(22, "cute-ball-help-icon32.png");
            // 
            // barCalculator
            // 
            this.barCalculator.Caption = "Calculator";
            this.barCalculator.Id = 3;
            this.barCalculator.ImageIndex = 11;
            this.barCalculator.Name = "barCalculator";
            this.barCalculator.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCalculator_ItemClick);
            // 
            // barNotePad
            // 
            this.barNotePad.Caption = "Notepad";
            this.barNotePad.Id = 4;
            this.barNotePad.ImageIndex = 12;
            this.barNotePad.Name = "barNotePad";
            this.barNotePad.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barNotePad_ItemClick);
            // 
            // barMessage
            // 
            this.barMessage.Caption = "Message";
            this.barMessage.Id = 5;
            this.barMessage.ImageIndex = 14;
            this.barMessage.Name = "barMessage";
            this.barMessage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barMessage_ItemClick);
            // 
            // barComments
            // 
            this.barComments.Caption = "Comments";
            this.barComments.Id = 7;
            this.barComments.ImageIndex = 16;
            this.barComments.Name = "barComments";
            this.barComments.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barComments_ItemClick);
            // 
            // barMyDocument
            // 
            this.barMyDocument.Caption = "My Document";
            this.barMyDocument.Id = 8;
            this.barMyDocument.ImageIndex = 21;
            this.barMyDocument.Name = "barMyDocument";
            this.barMyDocument.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barMyDocument_ItemClick);
            // 
            // barHelp
            // 
            this.barHelp.Caption = "Help";
            this.barHelp.Id = 9;
            this.barHelp.ImageIndex = 22;
            this.barHelp.Name = "barHelp";
            toolTipTitleItem1.Text = "Help ?";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "More detail in Envision.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.barHelp.SuperTip = superToolTip1;
            this.barHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barHelp_ItemClick);
            // 
            // barCareLink
            // 
            this.barCareLink.Caption = "Care";
            this.barCareLink.Id = 11;
            this.barCareLink.ImageIndex = 17;
            this.barCareLink.Name = "barCareLink";
            toolTipItem2.Text = "Care.rama.mahidol.ac.th";
            superToolTip2.Items.Add(toolTipItem2);
            this.barCareLink.SuperTip = superToolTip2;
            this.barCareLink.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCareLink_ItemClick);
            // 
            // ribMainStatus
            // 
            this.ribMainStatus.Location = new System.Drawing.Point(0, 744);
            this.ribMainStatus.Name = "ribMainStatus";
            this.ribMainStatus.Ribbon = this.ribMain;
            this.ribMainStatus.Size = new System.Drawing.Size(1016, 23);
            // 
            // mdiMain
            // 
            this.mdiMain.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            this.mdiMain.MdiParent = this;
            this.mdiMain.PageRemoved += new DevExpress.XtraTabbedMdi.MdiTabPageEventHandler(this.mdiMain_PageRemoved);
            // 
            // navBarMain
            // 
            this.navBarMain.ActiveGroup = null;
            this.navBarMain.AllowSelectedLink = true;
            this.navBarMain.ContentButtonHint = null;
            this.navBarMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarMain.LargeImages = this.navBarImg;
            this.navBarMain.Location = new System.Drawing.Point(0, 77);
            this.navBarMain.Name = "navBarMain";
            this.navBarMain.OptionsNavPane.ExpandedWidth = 180;
            this.navBarMain.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarMain.Size = new System.Drawing.Size(180, 667);
            this.navBarMain.SmallImages = this.navBarImg;
            this.navBarMain.TabIndex = 4;
            this.navBarMain.Text = "navBarControl1";
            this.navBarMain.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarMain_LinkClicked);
            this.navBarMain.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarMain_LinkPressed);
            this.navBarMain.DoubleClick += new System.EventHandler(this.navBarMain_DoubleClick);
            // 
            // splitLeft
            // 
            this.splitLeft.Location = new System.Drawing.Point(180, 77);
            this.splitLeft.Name = "splitLeft";
            this.splitLeft.Size = new System.Drawing.Size(6, 667);
            this.splitLeft.TabIndex = 5;
            this.splitLeft.TabStop = false;
            // 
            // myDefaultLookAndFeel
            // 
            this.myDefaultLookAndFeel.LookAndFeel.SkinName = "Blue";
            // 
            // gddFont
            // 
            // 
            // 
            // 
            this.gddFont.Gallery.Appearance.ItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gddFont.Gallery.Appearance.ItemCaption.Options.UseFont = true;
            this.gddFont.Gallery.Appearance.ItemCaption.Options.UseTextOptions = true;
            this.gddFont.Gallery.Appearance.ItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gddFont.Gallery.Appearance.ItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gddFont.Gallery.Appearance.ItemDescription.Options.UseTextOptions = true;
            this.gddFont.Gallery.Appearance.ItemDescription.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gddFont.Gallery.Appearance.ItemDescription.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gddFont.Gallery.ColumnCount = 1;
            this.gddFont.Gallery.FixedImageSize = false;
            galleryItemGroup1.Caption = "Main";
            this.gddFont.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup1});
            this.gddFont.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Left;
            this.gddFont.Gallery.RowCount = 6;
            this.gddFont.Gallery.ShowGroupCaption = false;
            this.gddFont.Gallery.ShowItemText = true;
            this.gddFont.Gallery.SizeMode = DevExpress.XtraBars.Ribbon.GallerySizeMode.Vertical;
            this.gddFont.Name = "gddFont";
            // 
            // bgPort
            // 
            this.bgPort.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgPort_DoWork);
            this.bgPort.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgPort_RunWorkerCompleted);
            this.bgPort.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgPort_ProgressChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserName,
            this.toolStripSeparator1,
            this.lblHosName,
            this.toolStripSeparator2,
            this.lblDate,
            this.toolStripSeparator3,
            this.cmbLanguage,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.toolBarImg});
            this.toolStrip1.Location = new System.Drawing.Point(0, 52);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(1016, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = false;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(150, 22);
            this.lblUserName.Text = "ผู้ดูแลระบบ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblHosName
            // 
            this.lblHosName.AutoSize = false;
            this.lblHosName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHosName.Name = "lblHosName";
            this.lblHosName.Size = new System.Drawing.Size(250, 22);
            this.lblHosName.Text = "โรงพยาบาลเพื่อประชาชน";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = false;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(150, 22);
            this.lblDate.Text = "14/10/2009";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbLanguage.Size = new System.Drawing.Size(121, 25);
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(286, 22);
            this.toolStripLabel1.Text = "                                                                                 " +
                "            ";
            // 
            // toolBarImg
            // 
            this.toolBarImg.AutoSize = false;
            this.toolBarImg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBarImg.Image = global::Envision.NET.Properties.Resources.gmail_icon128;
            this.toolBarImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBarImg.Name = "toolBarImg";
            this.toolBarImg.Size = new System.Drawing.Size(23, 20);
            this.toolBarImg.Text = "Internal Message";
            this.toolBarImg.Visible = false;
            this.toolBarImg.Click += new System.EventHandler(this.toolBarImg_Click);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "icon03.png");
            this.ImageList.Images.SetKeyName(1, "Calculator_16.png");
            // 
            // bgMsg
            // 
            this.bgMsg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgMsg_DoWork);
            this.bgMsg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgMsg_RunWorkerCompleted);
            this.bgMsg.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgMsg_ProgressChanged);
            // 
            // alertMsg
            // 
            this.alertMsg.AutoFormDelay = 4000;
            this.alertMsg.ShowPinButton = false;
            this.alertMsg.FormClosing += new DevExpress.XtraBars.Alerter.AlertFormClosingEventHandler(this.alertMsg_FormClosing);
            this.alertMsg.AlertClick += new DevExpress.XtraBars.Alerter.AlertClickEventHandler(this.alertMsg_AlertClick);
            // 
            // rbMain
            // 
            this.rbMain.ApplicationIcon = null;
            this.rbMain.Location = new System.Drawing.Point(186, 77);
            this.rbMain.MaxItemId = 10;
            this.rbMain.Name = "rbMain";
            this.rbMain.ShowCategoryInCaption = false;
            this.rbMain.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.rbMain.ShowToolbarCustomizeItem = false;
            this.rbMain.Size = new System.Drawing.Size(830, 22);
            this.rbMain.Toolbar.ShowCustomizeItem = false;
            this.rbMain.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bgPreload
            // 
            this.bgPreload.WorkerSupportsCancellation = true;
            this.bgPreload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgPreload_DoWork);
            this.bgPreload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgPreload_RunWorkerCompleted);
            this.bgPreload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgPreload_ProgressChanged);
            // 
            // tmMsg
            // 
            this.tmMsg.Interval = 5000;
            this.tmMsg.Tick += new System.EventHandler(this.tmMsg_Tick);
            // 
            // alertComment
            // 
            this.alertComment.AutoFormDelay = 4000;
            this.alertComment.ShowPinButton = false;
            this.alertComment.FormClosing += new DevExpress.XtraBars.Alerter.AlertFormClosingEventHandler(this.alertComment_FormClosing);
            this.alertComment.AlertClick += new DevExpress.XtraBars.Alerter.AlertClickEventHandler(this.alertComment_AlertClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1016, 767);
            this.Controls.Add(this.rbMain);
            this.Controls.Add(this.pccMain);
            this.Controls.Add(this.splitLeft);
            this.Controls.Add(this.navBarMain);
            this.Controls.Add(this.ribMainStatus);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ribMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribMain;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribMainStatus;
            this.Text = "Envision.NET";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.appMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pccMain)).EndInit();
            this.pccMain.ResumeLayout(false);
            this.pccMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdiMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gddFont)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribMain;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribMainStatus;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager mdiMain;
        private DevExpress.XtraNavBar.NavBarControl navBarMain;
        private DevExpress.XtraEditors.SplitterControl splitLeft;
        private DevExpress.LookAndFeel.DefaultLookAndFeel myDefaultLookAndFeel;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu appMain;
        private DevExpress.XtraBars.PopupControlContainer pccMain;
        private DevExpress.XtraBars.Ribbon.GalleryDropDown gddFont;
        private DevExpress.XtraBars.BarButtonItem btnLogOff;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.ComponentModel.BackgroundWorker bgPort;
        private DevExpress.Utils.ImageCollection navBarImg;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblHosName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox cmbLanguage;
        private System.Windows.Forms.ImageList ImageList;
        private System.ComponentModel.BackgroundWorker bgMsg;
        private DevExpress.XtraBars.Alerter.AlertControl alertMsg;
        private DevExpress.XtraBars.Ribbon.RibbonControl rbMain;
        private System.Windows.Forms.ToolStripLabel lblUserName;
        private DevExpress.XtraEditors.LabelControl lblVersion;
        private System.ComponentModel.BackgroundWorker bgPreload;
        private DevExpress.XtraBars.BarButtonItem barCalculator;
        private DevExpress.XtraBars.BarButtonItem barNotePad;
        private DevExpress.XtraBars.BarButtonItem barMessage;
        private System.Windows.Forms.Timer tmMsg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolBarImg;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private DevExpress.XtraBars.BarButtonItem barComments;
        private DevExpress.XtraBars.BarButtonItem barMyDocument;
        private DevExpress.XtraBars.Alerter.AlertControl alertComment;
        private DevExpress.XtraBars.BarButtonItem barHelp;
        private DevExpress.XtraBars.BarButtonItem barCareLink;
    }
}