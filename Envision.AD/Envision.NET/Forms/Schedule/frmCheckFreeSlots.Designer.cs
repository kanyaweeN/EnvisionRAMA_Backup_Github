namespace Envision.NET.Forms.Schedule
{
    partial class frmCheckFreeSlots
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckFreeSlots));
            this.dateNav = new DevExpress.XtraScheduler.DateNavigator();
            this.grdSchedule = new DevExpress.XtraGrid.GridControl();
            this.view1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdBlocks = new DevExpress.XtraGrid.GridControl();
            this.viewBlock = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnGo = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnGoToDate = new DevExpress.XtraBars.BarButtonItem();
            this.img48 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.chklModality = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutcBlock = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dateNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBlocks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chklModality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutcBlock)).BeginInit();
            this.SuspendLayout();
            // 
            // dateNav
            // 
            this.dateNav.DateTime = new System.DateTime(2016, 4, 28, 0, 0, 0, 0);
            this.dateNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateNav.Location = new System.Drawing.Point(0, 95);
            this.dateNav.Multiselect = false;
            this.dateNav.Name = "dateNav";
            this.dateNav.Size = new System.Drawing.Size(365, 434);
            this.dateNav.TabIndex = 0;
            this.dateNav.EditDateModified += new System.EventHandler(this.dateNavigator1_EditDateModified);
            // 
            // grdSchedule
            // 
            this.grdSchedule.Location = new System.Drawing.Point(7, 102);
            this.grdSchedule.MainView = this.view1;
            this.grdSchedule.Name = "grdSchedule";
            this.grdSchedule.Size = new System.Drawing.Size(295, 176);
            this.grdSchedule.TabIndex = 13;
            this.grdSchedule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view1});
            // 
            // view1
            // 
            this.view1.DetailHeight = 50;
            this.view1.GridControl = this.grdSchedule;
            this.view1.HorzScrollStep = 1;
            this.view1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.view1.Name = "view1";
            this.view1.OptionsBehavior.Editable = false;
            this.view1.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            this.view1.OptionsBehavior.SmartVertScrollBar = false;
            this.view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.view1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.view1.OptionsView.ShowGroupPanel = false;
            this.view1.OptionsView.ShowIndicator = false;
            this.view1.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.None;
            this.view1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.view1.Click += new System.EventHandler(this.view1_Click);
            this.view1.GroupRowCollapsing += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.view1_GroupRowCollapsing);
            this.view1.EndGrouping += new System.EventHandler(this.view1_EndGrouping);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.grdBlocks);
            this.layoutControl1.Controls.Add(this.chklModality);
            this.layoutControl1.Controls.Add(this.grdSchedule);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(365, 95);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(308, 434);
            this.layoutControl1.TabIndex = 14;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdBlocks
            // 
            this.grdBlocks.Location = new System.Drawing.Point(7, 289);
            this.grdBlocks.MainView = this.viewBlock;
            this.grdBlocks.MenuManager = this.ribbonControl1;
            this.grdBlocks.Name = "grdBlocks";
            this.grdBlocks.Size = new System.Drawing.Size(295, 139);
            this.grdBlocks.TabIndex = 15;
            this.grdBlocks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewBlock});
            // 
            // viewBlock
            // 
            this.viewBlock.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.viewBlock.GridControl = this.grdBlocks;
            this.viewBlock.Name = "viewBlock";
            this.viewBlock.OptionsView.ColumnAutoWidth = true;
            this.viewBlock.OptionsView.ShowBands = false;
            this.viewBlock.OptionsView.ShowColumnHeaders = false;
            this.viewBlock.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = null;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnGo,
            this.btnClose,
            this.btnGoToDate});
            this.ribbonControl1.LargeImages = this.img48;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.SelectedPage = this.ribbonPage1;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(673, 95);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnGo
            // 
            this.btnGo.Caption = "Go";
            this.btnGo.Id = 0;
            this.btnGo.LargeImageIndex = 0;
            this.btnGo.LargeWidth = 60;
            this.btnGo.Name = "btnGo";
            this.btnGo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGo_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Id = 1;
            this.btnClose.LargeImageIndex = 1;
            this.btnClose.LargeWidth = 60;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // btnGoToDate
            // 
            this.btnGoToDate.Caption = "Go to Date";
            this.btnGoToDate.Id = 2;
            this.btnGoToDate.LargeImageIndex = 2;
            this.btnGoToDate.LargeWidth = 60;
            this.btnGoToDate.Name = "btnGoToDate";
            this.btnGoToDate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGoToDate_ItemClick);
            // 
            // img48
            // 
            this.img48.ImageSize = new System.Drawing.Size(48, 48);
            this.img48.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("img48.ImageStream")));
            this.img48.Images.SetKeyName(0, "go48.png");
            this.img48.Images.SetKeyName(1, "close3_48.png");
            this.img48.Images.SetKeyName(2, "Actions-go-jump-today-icon48.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnGo);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnGoToDate);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            // 
            // chklModality
            // 
            this.chklModality.CheckOnClick = true;
            this.chklModality.Location = new System.Drawing.Point(7, 7);
            this.chklModality.Name = "chklModality";
            this.chklModality.Size = new System.Drawing.Size(295, 84);
            this.chklModality.StyleController = this.layoutControl1;
            this.chklModality.TabIndex = 14;
            this.chklModality.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chklModality_ItemCheck);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutcBlock});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(308, 434);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdSchedule;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 95);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(111, 31);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(306, 187);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chklModality;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(306, 95);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutcBlock
            // 
            this.layoutcBlock.Control = this.grdBlocks;
            this.layoutcBlock.CustomizationFormText = "layoutControlItem3";
            this.layoutcBlock.Location = new System.Drawing.Point(0, 282);
            this.layoutcBlock.MinSize = new System.Drawing.Size(111, 31);
            this.layoutcBlock.Name = "layoutcBlock";
            this.layoutcBlock.Size = new System.Drawing.Size(306, 150);
            this.layoutcBlock.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutcBlock.Text = "layoutcBlock";
            this.layoutcBlock.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutcBlock.TextSize = new System.Drawing.Size(0, 0);
            this.layoutcBlock.TextToControlDistance = 0;
            this.layoutcBlock.TextVisible = false;
            // 
            // frmCheckFreeSlots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 529);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.dateNav);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCheckFreeSlots";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Check Free Slots";
            this.Load += new System.EventHandler(this.frmCheckFreeSlots_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBlocks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chklModality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutcBlock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.DateNavigator dateNav;
        private DevExpress.XtraGrid.GridControl grdSchedule;
        private DevExpress.XtraGrid.Views.Grid.GridView view1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl chklModality;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnGo;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.Utils.ImageCollection img48;
        private DevExpress.XtraBars.BarButtonItem btnGoToDate;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraGrid.GridControl grdBlocks;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView viewBlock;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraLayout.LayoutControlItem layoutcBlock;

    }
}