namespace Envision.NET.Forms.InternalMessage
{
    partial class frmMessageManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageManagement));
            this.barControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnMarkRead = new DevExpress.XtraBars.BarButtonItem();
            this.btnTrash = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnFavorite = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestore = new DevExpress.XtraBars.BarButtonItem();
            this.btnSelectAll = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowFavorite = new DevExpress.XtraBars.BarButtonItem();
            this.pageIndex = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupIndexCommand = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageSent = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupSentCommand = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageDrafts = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupDraftsCommand = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageTrash = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupTrashCommand = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnMaskAsRead = new DevExpress.XtraBars.BarButtonItem();
            this.pnlMessage = new DevExpress.XtraEditors.PanelControl();
            this.viewMessage = new DevExpress.XtraGrid.GridControl();
            this.viewMessage1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.chkSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.imgWL = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMessage)).BeginInit();
            this.pnlMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMessage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // barControl
            // 
            this.barControl.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.barControl.Images = this.imageCollection1;
            this.barControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNew,
            this.btnMarkRead,
            this.btnTrash,
            this.btnDelete,
            this.btnFavorite,
            this.btnRestore,
            this.btnSelectAll,
            this.btnShowFavorite});
            this.barControl.LargeImages = this.imageCollection1;
            this.barControl.Location = new System.Drawing.Point(0, 0);
            this.barControl.MaxItemId = 12;
            this.barControl.Name = "barControl";
            this.barControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pageIndex,
            this.pageSent,
            this.pageDrafts,
            this.pageTrash});
            this.barControl.SelectedPage = this.pageIndex;
            this.barControl.Size = new System.Drawing.Size(592, 143);
            this.barControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this.barControl.SelectedPageChanged += new System.EventHandler(this.barControl_SelectedPageChanged);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "folder-favorites.png");
            this.imageCollection1.Images.SetKeyName(1, "mail-mark-unread-new.png");
            this.imageCollection1.Images.SetKeyName(2, "mail-new.png");
            this.imageCollection1.Images.SetKeyName(3, "trash-empty-2.png");
            this.imageCollection1.Images.SetKeyName(4, "folder-favorites.png");
            this.imageCollection1.Images.SetKeyName(5, "mail-delete-2.png");
            this.imageCollection1.Images.SetKeyName(6, "view-restore.png");
            this.imageCollection1.Images.SetKeyName(7, "icoWL-Accept.png");
            // 
            // btnNew
            // 
            this.btnNew.Caption = "Compose New";
            this.btnNew.Id = 0;
            this.btnNew.LargeImageIndex = 2;
            this.btnNew.Name = "btnNew";
            this.btnNew.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnMarkRead
            // 
            this.btnMarkRead.Caption = "Mark As Read";
            this.btnMarkRead.Id = 7;
            this.btnMarkRead.LargeImageIndex = 1;
            this.btnMarkRead.Name = "btnMarkRead";
            this.btnMarkRead.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnMarkRead.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMarkRead_ItemClick);
            // 
            // btnTrash
            // 
            this.btnTrash.Caption = "Trash";
            this.btnTrash.Id = 2;
            this.btnTrash.LargeImageIndex = 3;
            this.btnTrash.Name = "btnTrash";
            this.btnTrash.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTrash.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTrash_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Id = 8;
            this.btnDelete.LargeImageIndex = 5;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnFavorite
            // 
            this.btnFavorite.Caption = "Add Star";
            this.btnFavorite.Id = 4;
            this.btnFavorite.LargeImageIndex = 4;
            this.btnFavorite.Name = "btnFavorite";
            this.btnFavorite.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnFavorite.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFavorite_ItemClick);
            // 
            // btnRestore
            // 
            this.btnRestore.Caption = "Restore";
            this.btnRestore.Id = 9;
            this.btnRestore.ImageIndex = 6;
            this.btnRestore.LargeImageIndex = 6;
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRestore_ItemClick);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Caption = "Select All";
            this.btnSelectAll.Id = 10;
            this.btnSelectAll.ImageIndex = 7;
            this.btnSelectAll.LargeImageIndex = 7;
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelectAll_ItemClick);
            // 
            // btnShowFavorite
            // 
            this.btnShowFavorite.Caption = "Show Star";
            this.btnShowFavorite.Id = 11;
            this.btnShowFavorite.LargeImageIndex = 0;
            this.btnShowFavorite.Name = "btnShowFavorite";
            this.btnShowFavorite.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowFavorite_ItemClick);
            // 
            // pageIndex
            // 
            this.pageIndex.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.groupIndexCommand,
            this.ribbonPageGroup3,
            this.ribbonPageGroup7});
            this.pageIndex.Name = "pageIndex";
            this.pageIndex.Text = "Inbox";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnSelectAll);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            // 
            // groupIndexCommand
            // 
            this.groupIndexCommand.ItemLinks.Add(this.btnNew);
            this.groupIndexCommand.ItemLinks.Add(this.btnMarkRead);
            this.groupIndexCommand.ItemLinks.Add(this.btnFavorite);
            this.groupIndexCommand.Name = "groupIndexCommand";
            this.groupIndexCommand.ShowCaptionButton = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnTrash);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.AllowMinimize = false;
            this.ribbonPageGroup7.ItemLinks.Add(this.btnShowFavorite);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.ShowCaptionButton = false;
            // 
            // pageSent
            // 
            this.pageSent.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupSentCommand,
            this.ribbonPageGroup8});
            this.pageSent.Name = "pageSent";
            this.pageSent.Text = "Sent";
            // 
            // groupSentCommand
            // 
            this.groupSentCommand.ItemLinks.Add(this.btnNew);
            this.groupSentCommand.ItemLinks.Add(this.btnFavorite);
            this.groupSentCommand.Name = "groupSentCommand";
            this.groupSentCommand.ShowCaptionButton = false;
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.AllowMinimize = false;
            this.ribbonPageGroup8.ItemLinks.Add(this.btnShowFavorite);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.ShowCaptionButton = false;
            // 
            // pageDrafts
            // 
            this.pageDrafts.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5,
            this.groupDraftsCommand});
            this.pageDrafts.Name = "pageDrafts";
            this.pageDrafts.Text = "Drafts";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnSelectAll);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            // 
            // groupDraftsCommand
            // 
            this.groupDraftsCommand.ItemLinks.Add(this.btnNew);
            this.groupDraftsCommand.ItemLinks.Add(this.btnDelete);
            this.groupDraftsCommand.Name = "groupDraftsCommand";
            this.groupDraftsCommand.ShowCaptionButton = false;
            // 
            // pageTrash
            // 
            this.pageTrash.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6,
            this.groupTrashCommand,
            this.ribbonPageGroup2,
            this.ribbonPageGroup9});
            this.pageTrash.Name = "pageTrash";
            this.pageTrash.Text = "Trash";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnSelectAll);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.ShowCaptionButton = false;
            // 
            // groupTrashCommand
            // 
            this.groupTrashCommand.ItemLinks.Add(this.btnNew);
            this.groupTrashCommand.ItemLinks.Add(this.btnFavorite);
            this.groupTrashCommand.Name = "groupTrashCommand";
            this.groupTrashCommand.ShowCaptionButton = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRestore);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.AllowMinimize = false;
            this.ribbonPageGroup9.ItemLinks.Add(this.btnShowFavorite);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.ShowCaptionButton = false;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // btnMaskAsRead
            // 
            this.btnMaskAsRead.Caption = "Mark As Read";
            this.btnMaskAsRead.Id = 1;
            this.btnMaskAsRead.Name = "btnMaskAsRead";
            this.btnMaskAsRead.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // pnlMessage
            // 
            this.pnlMessage.Controls.Add(this.viewMessage);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessage.Location = new System.Drawing.Point(0, 143);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(592, 310);
            this.pnlMessage.TabIndex = 1;
            // 
            // viewMessage
            // 
            this.viewMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewMessage.Location = new System.Drawing.Point(2, 2);
            this.viewMessage.MainView = this.viewMessage1;
            this.viewMessage.MenuManager = this.barControl;
            this.viewMessage.Name = "viewMessage";
            this.viewMessage.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkSelect});
            this.viewMessage.Size = new System.Drawing.Size(588, 306);
            this.viewMessage.TabIndex = 0;
            this.viewMessage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewMessage1});
            this.viewMessage.DoubleClick += new System.EventHandler(this.viewMessage_DoubleClick);
            // 
            // viewMessage1
            // 
            this.viewMessage1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.viewMessage1.GridControl = this.viewMessage;
            this.viewMessage1.Name = "viewMessage1";
            this.viewMessage1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewMessage1.OptionsView.ShowBands = false;
            this.viewMessage1.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 792;
            // 
            // chkSelect
            // 
            this.chkSelect.AutoHeight = false;
            this.chkSelect.Name = "chkSelect";
            // 
            // imgWL
            // 
            this.imgWL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgWL.ImageStream")));
            this.imgWL.TransparentColor = System.Drawing.Color.Magenta;
            this.imgWL.Images.SetKeyName(0, "");
            this.imgWL.Images.SetKeyName(1, "");
            this.imgWL.Images.SetKeyName(2, "");
            this.imgWL.Images.SetKeyName(3, "mail-mark-unread-new.png");
            this.imgWL.Images.SetKeyName(4, "mail-read.png");
            this.imgWL.Images.SetKeyName(5, "draw-star.png");
            // 
            // frmMessageManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 453);
            this.Controls.Add(this.pnlMessage);
            this.Controls.Add(this.barControl);
            this.Name = "frmMessageManagement";
            this.Ribbon = this.barControl;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMessage)).EndInit();
            this.pnlMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.viewMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMessage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl barControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageSent;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageDrafts;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageTrash;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnTrash;
        private DevExpress.XtraBars.BarButtonItem btnFavorite;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageIndex;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupIndexCommand;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupSentCommand;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupDraftsCommand;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupTrashCommand;
        private DevExpress.XtraBars.BarButtonItem btnMarkRead;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnMaskAsRead;
        private DevExpress.XtraEditors.PanelControl pnlMessage;
        private DevExpress.XtraGrid.GridControl viewMessage;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkSelect;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView viewMessage1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private System.Windows.Forms.ImageList imgWL;
        private DevExpress.XtraBars.BarButtonItem btnRestore;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnSelectAll;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem btnShowFavorite;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
       
    }
}