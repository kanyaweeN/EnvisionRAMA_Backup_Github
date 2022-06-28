namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Popup
{
    partial class popupSignificateFinding_Special_Case
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(popupSignificateFinding_Special_Case));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.speNoOfSpecialCaseObject = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.chkFocalAsymLocation = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speNoOfSpecialCaseObject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFocalAsymLocation.Properties)).BeginInit();
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
            this.ribbon.Size = new System.Drawing.Size(442, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Id = 0;
            this.btnClose.LargeImageIndex = 1;
            this.btnClose.LargeWidth = 50;
            this.btnClose.Name = "btnClose";
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
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Special Case";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 298);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(442, 25);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.chkFocalAsymLocation);
            this.clientPanel.Controls.Add(this.radioGroup1);
            this.clientPanel.Controls.Add(this.labelControl2);
            this.clientPanel.Controls.Add(this.speNoOfSpecialCaseObject);
            this.clientPanel.Controls.Add(this.labelControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 143);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(442, 155);
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
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(124, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "No of Special Case Object";
            // 
            // speNoOfSpecialCaseObject
            // 
            this.speNoOfSpecialCaseObject.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speNoOfSpecialCaseObject.Location = new System.Drawing.Point(151, 13);
            this.speNoOfSpecialCaseObject.MenuManager = this.ribbon;
            this.speNoOfSpecialCaseObject.Name = "speNoOfSpecialCaseObject";
            this.speNoOfSpecialCaseObject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.speNoOfSpecialCaseObject.Size = new System.Drawing.Size(65, 20);
            this.speNoOfSpecialCaseObject.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(122, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Special Case Object Type";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(151, 39);
            this.radioGroup1.MenuManager = this.ribbon;
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Asymmetric Tubular Structure/Solitary Dilated Duct"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Intramammary Lymph Node"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Global Asymmetry"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Focal Asymmetry ")});
            this.radioGroup1.Size = new System.Drawing.Size(279, 103);
            this.radioGroup1.TabIndex = 3;
            // 
            // chkFocalAsymLocation
            // 
            this.chkFocalAsymLocation.Location = new System.Drawing.Point(291, 115);
            this.chkFocalAsymLocation.MenuManager = this.ribbon;
            this.chkFocalAsymLocation.Name = "chkFocalAsymLocation";
            this.chkFocalAsymLocation.Properties.Caption = "Location";
            this.chkFocalAsymLocation.Size = new System.Drawing.Size(75, 19);
            this.chkFocalAsymLocation.TabIndex = 4;
            // 
            // popupSignificateFinding_Special_Case
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 323);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "popupSignificateFinding_Special_Case";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Special Case";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            this.clientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speNoOfSpecialCaseObject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFocalAsymLocation.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit speNoOfSpecialCaseObject;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkFocalAsymLocation;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
    }
}