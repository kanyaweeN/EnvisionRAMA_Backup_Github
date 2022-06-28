namespace Envision.NET.Forms.Schedule
{
    partial class frmScheduleDefaultDestination
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScheduleDefaultDestination));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.rb = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbEdit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbSave = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbCancel = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.grdDestination = new DevExpress.XtraGrid.GridControl();
            this.viewDestination = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.sptCtrl = new DevExpress.XtraEditors.SplitContainerControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdModality = new DevExpress.XtraGrid.GridControl();
            this.viewModality = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptCtrl)).BeginInit();
            this.sptCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdModality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewModality)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = null;
            this.ribbonControl1.Images = this.imageCollection1;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSave,
            this.btnClose,
            this.btnEdit,
            this.btnCancel});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rb});
            this.ribbonControl1.SelectedPage = this.rb;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(826, 95);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(60, 60);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "ico_SaveSR.png");
            this.imageCollection1.Images.SetKeyName(1, "ico_CloseSR.png");
            this.imageCollection1.Images.SetKeyName(2, "ico-refresh.png");
            this.imageCollection1.Images.SetKeyName(3, "icon_order32.png");
            this.imageCollection1.Images.SetKeyName(4, "exit32.png");
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Id = 0;
            this.btnSave.LargeImageIndex = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Id = 1;
            this.btnClose.LargeImageIndex = 1;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Id = 2;
            this.btnEdit.LargeImageIndex = 3;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.Id = 3;
            this.btnCancel.LargeImageIndex = 4;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // rb
            // 
            this.rb.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbEdit,
            this.rbSave,
            this.rbCancel,
            this.rbClose});
            this.rb.Name = "rb";
            this.rb.Text = "ribbonPage1";
            // 
            // rbEdit
            // 
            this.rbEdit.ItemLinks.Add(this.btnEdit);
            this.rbEdit.Name = "rbEdit";
            this.rbEdit.ShowCaptionButton = false;
            // 
            // rbSave
            // 
            this.rbSave.ItemLinks.Add(this.btnSave);
            this.rbSave.Name = "rbSave";
            this.rbSave.ShowCaptionButton = false;
            this.rbSave.Visible = false;
            // 
            // rbCancel
            // 
            this.rbCancel.ItemLinks.Add(this.btnCancel);
            this.rbCancel.Name = "rbCancel";
            this.rbCancel.ShowCaptionButton = false;
            this.rbCancel.Visible = false;
            // 
            // rbClose
            // 
            this.rbClose.ItemLinks.Add(this.btnClose);
            this.rbClose.Name = "rbClose";
            this.rbClose.ShowCaptionButton = false;
            // 
            // grdDestination
            // 
            this.grdDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDestination.Location = new System.Drawing.Point(0, 0);
            this.grdDestination.MainView = this.viewDestination;
            this.grdDestination.MenuManager = this.ribbonControl1;
            this.grdDestination.Name = "grdDestination";
            this.grdDestination.Size = new System.Drawing.Size(181, 540);
            this.grdDestination.TabIndex = 1;
            this.grdDestination.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDestination});
            // 
            // viewDestination
            // 
            this.viewDestination.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.viewDestination.GridControl = this.grdDestination;
            this.viewDestination.Name = "viewDestination";
            this.viewDestination.OptionsBehavior.Editable = false;
            this.viewDestination.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewDestination.OptionsView.ShowBands = false;
            this.viewDestination.OptionsView.ShowGroupPanel = false;
            this.viewDestination.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.viewDestination_RowClick);
            this.viewDestination.DoubleClick += new System.EventHandler(this.viewDestination_DoubleClick);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.sptCtrl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 95);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(826, 544);
            this.panelControl1.TabIndex = 2;
            // 
            // sptCtrl
            // 
            this.sptCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptCtrl.Location = new System.Drawing.Point(2, 2);
            this.sptCtrl.Name = "sptCtrl";
            this.sptCtrl.Panel1.Controls.Add(this.grdDestination);
            this.sptCtrl.Panel1.Text = "Panel1";
            this.sptCtrl.Panel2.Controls.Add(this.labelControl1);
            this.sptCtrl.Panel2.Controls.Add(this.grdModality);
            this.sptCtrl.Panel2.Text = "Panel2";
            this.sptCtrl.Size = new System.Drawing.Size(822, 540);
            this.sptCtrl.SplitterPosition = 181;
            this.sptCtrl.TabIndex = 2;
            this.sptCtrl.Text = "splitContainerControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(14, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Select Modality";
            // 
            // grdModality
            // 
            this.grdModality.Location = new System.Drawing.Point(14, 25);
            this.grdModality.MainView = this.viewModality;
            this.grdModality.MenuManager = this.ribbonControl1;
            this.grdModality.Name = "grdModality";
            this.grdModality.Size = new System.Drawing.Size(611, 505);
            this.grdModality.TabIndex = 0;
            this.grdModality.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewModality});
            // 
            // viewModality
            // 
            this.viewModality.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.viewModality.GridControl = this.grdModality;
            this.viewModality.Name = "viewModality";
            this.viewModality.OptionsCustomization.AllowSort = false;
            this.viewModality.OptionsView.ShowAutoFilterRow = true;
            this.viewModality.OptionsView.ShowBands = false;
            this.viewModality.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.viewModality.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "gridBand2";
            this.gridBand2.Name = "gridBand2";
            // 
            // frmScheduleDefaultDestination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 639);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmScheduleDefaultDestination";
            this.Text = "frmScheduleDefaultDestination";
            this.Load += new System.EventHandler(this.frmScheduleDefaultDestination_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptCtrl)).EndInit();
            this.sptCtrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdModality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewModality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rb;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbSave;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbClose;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.GridControl grdDestination;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView viewDestination;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl sptCtrl;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl grdModality;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView viewModality;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbEdit;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbCancel;
    }
}