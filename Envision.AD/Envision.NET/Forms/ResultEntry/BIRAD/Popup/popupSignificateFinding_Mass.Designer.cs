namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Popup
{
    partial class popupSignificateFinding_Mass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(popupSignificateFinding_Mass));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMassNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.rdgBreastView = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMassLocation = new DevExpress.XtraEditors.TextEdit();
            this.txtMassClockLocation = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.rdgShape = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.rdgMargin = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.rdgDensityWithCalcification = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.rdgDensityWithFat = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMassNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgBreastView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMassLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMassClockLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgShape.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgMargin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgDensityWithCalcification.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgDensityWithFat.Properties)).BeginInit();
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
            this.ribbonPage1.Text = "Mass";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 463);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(442, 25);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.rdgDensityWithFat);
            this.clientPanel.Controls.Add(this.labelControl9);
            this.clientPanel.Controls.Add(this.labelControl8);
            this.clientPanel.Controls.Add(this.rdgDensityWithCalcification);
            this.clientPanel.Controls.Add(this.labelControl7);
            this.clientPanel.Controls.Add(this.rdgMargin);
            this.clientPanel.Controls.Add(this.labelControl6);
            this.clientPanel.Controls.Add(this.rdgShape);
            this.clientPanel.Controls.Add(this.labelControl5);
            this.clientPanel.Controls.Add(this.txtMassClockLocation);
            this.clientPanel.Controls.Add(this.labelControl4);
            this.clientPanel.Controls.Add(this.txtMassLocation);
            this.clientPanel.Controls.Add(this.labelControl3);
            this.clientPanel.Controls.Add(this.rdgBreastView);
            this.clientPanel.Controls.Add(this.labelControl2);
            this.clientPanel.Controls.Add(this.txtMassNo);
            this.clientPanel.Controls.Add(this.labelControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 143);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(442, 320);
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
            this.labelControl1.Location = new System.Drawing.Point(21, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mass No";
            // 
            // txtMassNo
            // 
            this.txtMassNo.Location = new System.Drawing.Point(94, 10);
            this.txtMassNo.MenuManager = this.ribbon;
            this.txtMassNo.Name = "txtMassNo";
            this.txtMassNo.Size = new System.Drawing.Size(55, 20);
            this.txtMassNo.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(155, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Breast View";
            // 
            // rdgBreastView
            // 
            this.rdgBreastView.Location = new System.Drawing.Point(217, 6);
            this.rdgBreastView.MenuManager = this.ribbon;
            this.rdgBreastView.Name = "rdgBreastView";
            this.rdgBreastView.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdgBreastView.Properties.Appearance.Options.UseBackColor = true;
            this.rdgBreastView.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Left"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Right")});
            this.rdgBreastView.Size = new System.Drawing.Size(100, 26);
            this.rdgBreastView.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(21, 40);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Mass Location";
            // 
            // txtMassLocation
            // 
            this.txtMassLocation.Location = new System.Drawing.Point(94, 37);
            this.txtMassLocation.MenuManager = this.ribbon;
            this.txtMassLocation.Name = "txtMassLocation";
            this.txtMassLocation.Size = new System.Drawing.Size(102, 20);
            this.txtMassLocation.TabIndex = 5;
            // 
            // txtMassClockLocation
            // 
            this.txtMassClockLocation.Location = new System.Drawing.Point(318, 37);
            this.txtMassClockLocation.MenuManager = this.ribbon;
            this.txtMassClockLocation.Name = "txtMassClockLocation";
            this.txtMassClockLocation.Size = new System.Drawing.Size(79, 20);
            this.txtMassClockLocation.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(217, 40);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(95, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Mass Clock Location";
            // 
            // rdgShape
            // 
            this.rdgShape.Location = new System.Drawing.Point(94, 63);
            this.rdgShape.MenuManager = this.ribbon;
            this.rdgShape.Name = "rdgShape";
            this.rdgShape.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdgShape.Properties.Appearance.Options.UseBackColor = true;
            this.rdgShape.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Round"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Oval"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Lobular"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Irregular")});
            this.rdgShape.Size = new System.Drawing.Size(303, 26);
            this.rdgShape.TabIndex = 9;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(21, 69);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(30, 13);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Shape";
            // 
            // rdgMargin
            // 
            this.rdgMargin.Location = new System.Drawing.Point(94, 95);
            this.rdgMargin.MenuManager = this.ribbon;
            this.rdgMargin.Name = "rdgMargin";
            this.rdgMargin.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdgMargin.Properties.Appearance.Options.UseBackColor = true;
            this.rdgMargin.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Spiculated"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Indistinct"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Obscured"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Microlobulated"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Circumscribe")});
            this.rdgMargin.Size = new System.Drawing.Size(303, 113);
            this.rdgMargin.TabIndex = 11;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(21, 101);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 13);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Margin";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(21, 220);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 13);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "Density";
            // 
            // rdgDensityWithCalcification
            // 
            this.rdgDensityWithCalcification.Location = new System.Drawing.Point(94, 239);
            this.rdgDensityWithCalcification.MenuManager = this.ribbon;
            this.rdgDensityWithCalcification.Name = "rdgDensityWithCalcification";
            this.rdgDensityWithCalcification.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdgDensityWithCalcification.Properties.Appearance.Options.UseBackColor = true;
            this.rdgDensityWithCalcification.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Benign"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Malignant Cal. "),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Indetermine")});
            this.rdgDensityWithCalcification.Size = new System.Drawing.Size(303, 26);
            this.rdgDensityWithCalcification.TabIndex = 13;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(94, 220);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(141, 13);
            this.labelControl8.TabIndex = 14;
            this.labelControl8.Text = "Density with Calcification";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(94, 271);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(91, 13);
            this.labelControl9.TabIndex = 15;
            this.labelControl9.Text = "Density with Fat";
            // 
            // rdgDensityWithFat
            // 
            this.rdgDensityWithFat.Location = new System.Drawing.Point(94, 290);
            this.rdgDensityWithFat.MenuManager = this.ribbon;
            this.rdgDensityWithFat.Name = "rdgDensityWithFat";
            this.rdgDensityWithFat.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdgDensityWithFat.Properties.Appearance.Options.UseBackColor = true;
            this.rdgDensityWithFat.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Yes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "No")});
            this.rdgDensityWithFat.Size = new System.Drawing.Size(205, 26);
            this.rdgDensityWithFat.TabIndex = 16;
            // 
            // popupSignificateFinding_Mass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 488);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "popupSignificateFinding_Mass";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Mass";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            this.clientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMassNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgBreastView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMassLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMassClockLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgShape.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgMargin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgDensityWithCalcification.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgDensityWithFat.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtMassNo;
        private DevExpress.XtraEditors.RadioGroup rdgBreastView;
        private DevExpress.XtraEditors.TextEdit txtMassLocation;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtMassClockLocation;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.RadioGroup rdgMargin;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.RadioGroup rdgShape;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.RadioGroup rdgDensityWithCalcification;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.RadioGroup rdgDensityWithFat;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}