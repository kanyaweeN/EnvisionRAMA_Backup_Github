namespace Envision.NET.Forms.ResultEntry
{
    partial class frmSRTemplateSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSRTemplateSetup));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnMessage = new DevExpress.XtraBars.BarButtonItem();
            this.imgLarge = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.grdTemplate = new DevExpress.XtraGrid.GridControl();
            this.viewTemplate = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.btnDuplicate = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.imgLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = null;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.btnClose,
            this.btnPreview,
            this.btnMessage,
            this.btnDuplicate});
            this.ribbonControl1.LargeImages = this.imgLarge;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.SelectedPage = this.ribbonPage1;
            this.ribbonControl1.Size = new System.Drawing.Size(826, 115);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Id = 0;
            this.btnNew.LargeImageIndex = 29;
            this.btnNew.LargeWidth = 60;
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewTempalte_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Id = 1;
            this.btnEdit.LargeImageIndex = 28;
            this.btnEdit.LargeWidth = 60;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barEditTemplate_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Id = 2;
            this.btnDelete.LargeImageIndex = 27;
            this.btnDelete.LargeWidth = 60;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Id = 3;
            this.btnClose.LargeImageIndex = 31;
            this.btnClose.LargeWidth = 60;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // btnPreview
            // 
            this.btnPreview.Caption = "Preview";
            this.btnPreview.Id = 4;
            this.btnPreview.LargeImageIndex = 32;
            this.btnPreview.LargeWidth = 60;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPreview_ItemClick);
            // 
            // btnMessage
            // 
            this.btnMessage.Caption = "Message";
            this.btnMessage.Id = 5;
            this.btnMessage.LargeImageIndex = 33;
            this.btnMessage.LargeWidth = 60;
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMessage_ItemClick);
            // 
            // imgLarge
            // 
            this.imgLarge.ImageSize = new System.Drawing.Size(60, 60);
            this.imgLarge.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgLarge.ImageStream")));
            this.imgLarge.Images.SetKeyName(0, "add_48.png");
            this.imgLarge.Images.SetKeyName(1, "alert_caution_and_warning48.png");
            this.imgLarge.Images.SetKeyName(2, "reprint_48.png");
            this.imgLarge.Images.SetKeyName(3, "saveLarge.png");
            this.imgLarge.Images.SetKeyName(4, "technologist48.png");
            this.imgLarge.Images.SetKeyName(5, "01entry_48.png");
            this.imgLarge.Images.SetKeyName(6, "CYC24.png");
            this.imgLarge.Images.SetKeyName(7, "save_draft_48.png");
            this.imgLarge.Images.SetKeyName(8, "save_prelim_48.png");
            this.imgLarge.Images.SetKeyName(9, "save_template_48.png");
            this.imgLarge.Images.SetKeyName(10, "save_as_prelim48.png");
            this.imgLarge.Images.SetKeyName(11, "save_as_result48.png");
            this.imgLarge.Images.SetKeyName(12, "order.png");
            this.imgLarge.Images.SetKeyName(13, "icon_faavourite.png");
            this.imgLarge.Images.SetKeyName(14, "icon_report.png");
            this.imgLarge.Images.SetKeyName(15, "new_read_from_template2_48.png");
            this.imgLarge.Images.SetKeyName(16, "save_as_template48.png");
            this.imgLarge.Images.SetKeyName(17, "refresh48.png");
            this.imgLarge.Images.SetKeyName(18, "PNG-Refresh_png-256x256.png");
            this.imgLarge.Images.SetKeyName(19, "Preview-64x64.png");
            this.imgLarge.Images.SetKeyName(20, "Antivirus-48x48.png");
            this.imgLarge.Images.SetKeyName(21, "file-locked-48x48.png");
            this.imgLarge.Images.SetKeyName(22, "Msn-Buddy-1min-icon-48.png");
            this.imgLarge.Images.SetKeyName(23, "Msn-Buddy-Busy-icon-48.png");
            this.imgLarge.Images.SetKeyName(24, "plus_32.png");
            this.imgLarge.Images.SetKeyName(25, "iPhoto-icon48.png");
            this.imgLarge.Images.SetKeyName(26, "shellscript-icon-48.png");
            this.imgLarge.Images.SetKeyName(27, "ico_Delete.png");
            this.imgLarge.Images.SetKeyName(28, "ico_SREdit.png");
            this.imgLarge.Images.SetKeyName(29, "ico_SRNew.png");
            this.imgLarge.Images.SetKeyName(30, "ico_Run.png");
            this.imgLarge.Images.SetKeyName(31, "ico_CloseSR.png");
            this.imgLarge.Images.SetKeyName(32, "ico-preview.png");
            this.imgLarge.Images.SetKeyName(33, "gmail-icon128.jpg");
            this.imgLarge.Images.SetKeyName(34, "icon_report.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6,
            this.ribbonPageGroup2,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Setup Structured Report";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnNew);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnDuplicate);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.ShowCaptionButton = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnMessage);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPreview);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkAll);
            this.panelControl1.Controls.Add(this.grdTemplate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 115);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(826, 524);
            this.panelControl1.TabIndex = 1;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(5, 5);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(67, 17);
            this.chkAll.TabIndex = 2;
            this.chkAll.Text = "Show All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // grdTemplate
            // 
            this.grdTemplate.Location = new System.Drawing.Point(2, 28);
            this.grdTemplate.MainView = this.viewTemplate;
            this.grdTemplate.Name = "grdTemplate";
            this.grdTemplate.Size = new System.Drawing.Size(822, 494);
            this.grdTemplate.TabIndex = 1;
            this.grdTemplate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewTemplate});
            // 
            // viewTemplate
            // 
            this.viewTemplate.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.viewTemplate.GridControl = this.grdTemplate;
            this.viewTemplate.Name = "viewTemplate";
            this.viewTemplate.OptionsBehavior.Editable = false;
            this.viewTemplate.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewTemplate.OptionsView.ShowAutoFilterRow = true;
            this.viewTemplate.OptionsView.ShowBands = false;
            this.viewTemplate.OptionsView.ShowGroupPanel = false;
            this.viewTemplate.DoubleClick += new System.EventHandler(this.viewTemplate_DoubleClick);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Caption = "Duplicate";
            this.btnDuplicate.Id = 6;
            this.btnDuplicate.LargeImageIndex = 34;
            this.btnDuplicate.LargeWidth = 60;
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDuplicate_ItemClick);
            // 
            // frmSRTemplateSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 639);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmSRTemplateSetup";
            this.Text = "frmSRTemplateSetup";
            this.Load += new System.EventHandler(this.frmSRTemplateSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewTemplate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdTemplate;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView viewTemplate;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.Utils.ImageCollection imgLarge;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnPreview;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnMessage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraBars.BarButtonItem btnDuplicate;
    }
}