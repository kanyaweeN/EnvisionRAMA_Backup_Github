namespace Envision.NET.Forms.ResultEntry
{
    partial class frmPRWorklist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPRWorklist));
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.contxtData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.orderSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewData = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.imgWL = new System.Windows.Forms.ImageList(this.components);
            this.imgSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barbtnClose = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.contxtData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.ContextMenuStrip = this.contxtData;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 95);
            this.grdData.MainView = this.viewData;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(723, 327);
            this.grdData.TabIndex = 0;
            this.grdData.ToolTipController = this.toolTipController1;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewData});
            // 
            // contxtData
            // 
            this.contxtData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderSummaryToolStripMenuItem});
            this.contxtData.Name = "contxtData";
            this.contxtData.Size = new System.Drawing.Size(159, 26);
            // 
            // orderSummaryToolStripMenuItem
            // 
            this.orderSummaryToolStripMenuItem.Name = "orderSummaryToolStripMenuItem";
            this.orderSummaryToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.orderSummaryToolStripMenuItem.Text = "Order Summary";
            // 
            // viewData
            // 
            this.viewData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.viewData.GridControl = this.grdData;
            this.viewData.Name = "viewData";
            this.viewData.OptionsView.ShowBands = false;
            this.viewData.DoubleClick += new System.EventHandler(this.viewData_DoubleClick);
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
            // imgWL
            // 
            this.imgWL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgWL.ImageStream")));
            this.imgWL.TransparentColor = System.Drawing.Color.Magenta;
            this.imgWL.Images.SetKeyName(0, "");
            this.imgWL.Images.SetKeyName(1, "");
            this.imgWL.Images.SetKeyName(2, "");
            this.imgWL.Images.SetKeyName(3, "");
            this.imgWL.Images.SetKeyName(4, "");
            this.imgWL.Images.SetKeyName(5, "");
            this.imgWL.Images.SetKeyName(6, "");
            this.imgWL.Images.SetKeyName(7, "");
            this.imgWL.Images.SetKeyName(8, "");
            this.imgWL.Images.SetKeyName(9, "mail-reply-all-3.png");
            this.imgWL.Images.SetKeyName(10, "flag-red.png");
            // 
            // imgSmall
            // 
            this.imgSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgSmall.ImageStream")));
            this.imgSmall.Images.SetKeyName(0, "viewtree_16.png");
            this.imgSmall.Images.SetKeyName(1, "01entry_24.png");
            this.imgSmall.Images.SetKeyName(2, "order.png");
            this.imgSmall.Images.SetKeyName(3, "merge_16.png");
            this.imgSmall.Images.SetKeyName(4, "split_16.png");
            this.imgSmall.Images.SetKeyName(5, "transfer_16.png");
            this.imgSmall.Images.SetKeyName(6, "history_16.png");
            this.imgSmall.Images.SetKeyName(7, "browse_16.png");
            this.imgSmall.Images.SetKeyName(8, "order_16.png");
            this.imgSmall.Images.SetKeyName(9, "favourite_16.png");
            this.imgSmall.Images.SetKeyName(10, "save_template_16.png");
            this.imgSmall.Images.SetKeyName(11, "save_as_template16.png");
            this.imgSmall.Images.SetKeyName(12, "save_draft_16.png");
            this.imgSmall.Images.SetKeyName(13, "save_as_prelim16.png");
            this.imgSmall.Images.SetKeyName(14, "save_as_result16.png");
            this.imgSmall.Images.SetKeyName(15, "check_document16.png");
            this.imgSmall.Images.SetKeyName(16, "add_remove16.png");
            this.imgSmall.Images.SetKeyName(17, "Pen-16x16.png");
            this.imgSmall.Images.SetKeyName(18, "Kde_crystalsvg_eraser.png");
            this.imgSmall.Images.SetKeyName(19, "refresh16.png");
            this.imgSmall.Images.SetKeyName(20, "blackboard.png");
            this.imgSmall.Images.SetKeyName(21, "Preview-16x16.png");
            this.imgSmall.Images.SetKeyName(22, "note-accept-icon-16.png");
            this.imgSmall.Images.SetKeyName(23, "doc-file-2-1-icon-16.png");
            this.imgSmall.Images.SetKeyName(24, "Administrator-icon16.png");
            this.imgSmall.Images.SetKeyName(25, "User-Group-icon16.png");
            this.imgSmall.Images.SetKeyName(26, "note-accept-icon-16.png");
            this.imgSmall.Images.SetKeyName(27, "menuStructure.png");
            this.imgSmall.Images.SetKeyName(28, "Research.png");
            this.imgSmall.Images.SetKeyName(29, "ico_SwitchLayout.png");
            this.imgSmall.Images.SetKeyName(30, "filter-icon16.png");
            this.imgSmall.Images.SetKeyName(31, "refresh16.png");
            this.imgSmall.Images.SetKeyName(32, "conference-icon16.png");
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = null;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barbtnClose});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.SelectedPage = this.ribbonPage1;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(723, 95);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barbtnClose
            // 
            this.barbtnClose.Caption = "Close";
            this.barbtnClose.Id = 0;
            this.barbtnClose.LargeImageIndex = 3;
            this.barbtnClose.LargeWidth = 60;
            this.barbtnClose.Name = "barbtnClose";
            this.barbtnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnClose_ItemClick);
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
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Visible = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Visible = false;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Visible = false;
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            this.ribbonPageGroup5.Visible = false;
            // 
            // frmPRWorklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 422);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmPRWorklist";
            this.Text = "Peer Review Worklist";
            this.Load += new System.EventHandler(this.frmPRWorklist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.contxtData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.viewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView viewData;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private System.Windows.Forms.ContextMenuStrip contxtData;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private System.Windows.Forms.ImageList imgWL;
        private DevExpress.Utils.ImageCollection imgSmall;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barbtnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.ToolStripMenuItem orderSummaryToolStripMenuItem;
    }
}