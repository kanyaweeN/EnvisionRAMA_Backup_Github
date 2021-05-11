namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Popup
{
    partial class popupSignificateFinding_Associate_Finding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(popupSignificateFinding_Associate_Finding));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = null;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnClose});
            this.ribbon.LargeImages = this.imageCollection1;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.SelectedPage = this.ribbonPage1;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(312, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Associate Finding";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 293);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(312, 25);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.radioGroup1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 143);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(312, 150);
            this.clientPanel.TabIndex = 2;
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.Images.SetKeyName(0, "edit.png");
            this.imageCollection2.Images.SetKeyName(1, "crop.png");
            this.imageCollection2.Images.SetKeyName(2, "pen.png");
            this.imageCollection2.Images.SetKeyName(3, "pointer.png");
            this.imageCollection2.Images.SetKeyName(4, "export.png");
            this.imageCollection2.Images.SetKeyName(5, "import.png");
            this.imageCollection2.Images.SetKeyName(6, "ocwen_circle.png");
            this.imageCollection2.Images.SetKeyName(7, "circle.png");
            this.imageCollection2.Images.SetKeyName(8, "stroke.png");
            this.imageCollection2.Images.SetKeyName(9, "snap-bounding-box.png");
            this.imageCollection2.Images.SetKeyName(10, "styleL.png");
            this.imageCollection2.Images.SetKeyName(11, "15592_14961_16_format_fill_color_icon.png");
            this.imageCollection2.Images.SetKeyName(12, "99468_16214_22_format_stroke_color_icon.png");
            this.imageCollection2.Images.SetKeyName(13, "A_Open_Sm_N.png");
            this.imageCollection2.Images.SetKeyName(14, "tree_folder_open.png");
            this.imageCollection2.Images.SetKeyName(15, "save.png");
            this.imageCollection2.Images.SetKeyName(16, "bpic_clear.png");
            this.imageCollection2.Images.SetKeyName(17, "faq_seach_clear.png");
            this.imageCollection2.Images.SetKeyName(18, "action_clear.png");
            this.imageCollection2.Images.SetKeyName(19, "carousel-next.png");
            this.imageCollection2.Images.SetKeyName(20, "carousel-prev.png");
            this.imageCollection2.Images.SetKeyName(21, "delete.png");
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "add_32.png");
            this.imageCollection1.Images.SetKeyName(1, "close3_32.png");
            this.imageCollection1.Images.SetKeyName(2, "save_draft_32.png");
            this.imageCollection1.Images.SetKeyName(3, "save_prelim_32.png");
            this.imageCollection1.Images.SetKeyName(4, "save_result_32.png");
            this.imageCollection1.Images.SetKeyName(5, "delete.png");
            this.imageCollection1.Images.SetKeyName(6, "edit.png");
            this.imageCollection1.Images.SetKeyName(7, "delete.png");
            this.imageCollection1.Images.SetKeyName(8, "clear.png");
            this.imageCollection1.Images.SetKeyName(9, "text-x-patch.png");
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Id = 0;
            this.btnClose.LargeImageIndex = 1;
            this.btnClose.LargeWidth = 50;
            this.btnClose.Name = "btnClose";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(0, 0);
            this.radioGroup1.MenuManager = this.ribbon;
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Skin Retraction"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Nipple Retraction"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Skin Thickening"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Trabecular Thickening"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Skin Lesion"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Axillary")});
            this.radioGroup1.Size = new System.Drawing.Size(312, 150);
            this.radioGroup1.TabIndex = 0;
            // 
            // popupSignificateFinding_Associate_Finding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 318);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "popupSignificateFinding_Associate_Finding";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Associate Finding";
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
    }
}