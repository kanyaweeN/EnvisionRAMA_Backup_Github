namespace RIS.Forms.Order
{
    partial class frmReprint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReprint));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.grdOrder = new DevExpress.XtraGrid.GridControl();
            this.view1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.rdoSticker = new System.Windows.Forms.RadioButton();
            this.rdoOrder = new System.Windows.Forms.RadioButton();
            this.chkPrintExam = new DevExpress.XtraEditors.CheckEdit();
            this.textNoOfPrint = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
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
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintExam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNoOfPrint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // grdOrder
            // 
            this.grdOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrder.EmbeddedNavigator.Name = "";
            this.grdOrder.FormsUseDefaultLookAndFeel = false;
            this.grdOrder.Location = new System.Drawing.Point(0, 0);
            this.grdOrder.MainView = this.view1;
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.Size = new System.Drawing.Size(809, 388);
            this.grdOrder.TabIndex = 1;
            this.grdOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view1,
            this.gridView1});
            // 
            // view1
            // 
            this.view1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.view1.GridControl = this.grdOrder;
            this.view1.Name = "view1";
            this.view1.OptionsView.ShowBands = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdOrder;
            this.gridView1.Name = "gridView1";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(414, 26);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // rdoSticker
            // 
            this.rdoSticker.AutoSize = true;
            this.rdoSticker.Location = new System.Drawing.Point(389, 7);
            this.rdoSticker.Name = "rdoSticker";
            this.rdoSticker.Size = new System.Drawing.Size(84, 17);
            this.rdoSticker.TabIndex = 3;
            this.rdoSticker.Text = "พิมพ์ Sticker";
            this.rdoSticker.UseVisualStyleBackColor = true;
            this.rdoSticker.CheckedChanged += new System.EventHandler(this.rdoSticker_CheckedChanged);
            // 
            // rdoOrder
            // 
            this.rdoOrder.AutoSize = true;
            this.rdoOrder.Checked = true;
            this.rdoOrder.Location = new System.Drawing.Point(308, 7);
            this.rdoOrder.Name = "rdoOrder";
            this.rdoOrder.Size = new System.Drawing.Size(77, 17);
            this.rdoOrder.TabIndex = 4;
            this.rdoOrder.TabStop = true;
            this.rdoOrder.Text = "พิมพ์ Order";
            this.rdoOrder.UseVisualStyleBackColor = true;
            this.rdoOrder.CheckedChanged += new System.EventHandler(this.rdoOrder_CheckedChanged);
            // 
            // chkPrintExam
            // 
            this.chkPrintExam.Enabled = false;
            this.chkPrintExam.Location = new System.Drawing.Point(479, 7);
            this.chkPrintExam.Name = "chkPrintExam";
            this.chkPrintExam.Properties.Caption = "พิมพ์ Exam";
            this.chkPrintExam.Size = new System.Drawing.Size(75, 18);
            this.chkPrintExam.TabIndex = 5;
            // 
            // textNoOfPrint
            // 
            this.textNoOfPrint.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textNoOfPrint.Location = new System.Drawing.Point(308, 27);
            this.textNoOfPrint.Name = "textNoOfPrint";
            this.textNoOfPrint.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.textNoOfPrint.Properties.IsFloatValue = false;
            this.textNoOfPrint.Properties.Mask.EditMask = "N00";
            this.textNoOfPrint.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.textNoOfPrint.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textNoOfPrint.Size = new System.Drawing.Size(100, 20);
            this.textNoOfPrint.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(251, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "พิมพ์จำนวน";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonKeyTip = "";
            this.ribbonControl1.ApplicationIcon = null;
            this.ribbonControl1.Images = this.imageCollection1;
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
            this.barClose});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 22;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.SelectedPage = this.ribbonPage1;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(809, 122);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(60, 60);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // barCreateNew
            // 
            this.barCreateNew.Caption = "New  Order ";
            this.barCreateNew.Id = 12;
            this.barCreateNew.ImageIndex = 3;
            this.barCreateNew.LargeImageIndex = 3;
            this.barCreateNew.Name = "barCreateNew";
            this.barCreateNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCreateNew_ItemClick);
            // 
            // barModify
            // 
            this.barModify.Caption = "Edit Order";
            this.barModify.Id = 13;
            this.barModify.ImageIndex = 0;
            this.barModify.LargeImageIndex = 0;
            this.barModify.Name = "barModify";
            this.barModify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barModify_ItemClick);
            // 
            // barSchedule
            // 
            this.barSchedule.Caption = "Arrival Work List";
            this.barSchedule.Id = 14;
            this.barSchedule.ImageIndex = 7;
            this.barSchedule.LargeImageIndex = 7;
            this.barSchedule.Name = "barSchedule";
            this.barSchedule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSchedule_ItemClick);
            // 
            // barPatient
            // 
            this.barPatient.Caption = " Patient  ";
            this.barPatient.Id = 15;
            this.barPatient.ImageIndex = 6;
            this.barPatient.LargeImageIndex = 6;
            this.barPatient.Name = "barPatient";
            this.barPatient.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPatient_ItemClick);
            // 
            // barLastOrder
            // 
            this.barLastOrder.Caption = "Last Order";
            this.barLastOrder.Id = 16;
            this.barLastOrder.ImageIndex = 9;
            this.barLastOrder.LargeImageIndex = 9;
            this.barLastOrder.Name = "barLastOrder";
            this.barLastOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLastOrder_ItemClick);
            // 
            // barView
            // 
            this.barView.Caption = "Performance";
            this.barView.Id = 17;
            this.barView.ImageIndex = 1;
            this.barView.LargeImageIndex = 1;
            this.barView.Name = "barView";
            this.barView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barView_ItemClick);
            // 
            // barHome
            // 
            this.barHome.Caption = "    Home   ";
            this.barHome.Id = 18;
            this.barHome.ImageIndex = 2;
            this.barHome.LargeImageIndex = 2;
            this.barHome.Name = "barHome";
            this.barHome.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barHome_ItemClick);
            // 
            // barPrintLast
            // 
            this.barPrintLast.Caption = "Reprint";
            this.barPrintLast.Id = 19;
            this.barPrintLast.ImageIndex = 10;
            this.barPrintLast.LargeImageIndex = 10;
            this.barPrintLast.Name = "barPrintLast";
            this.barPrintLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPrintLast_ItemClick);
            // 
            // barManul
            // 
            this.barManul.Caption = "Manual";
            this.barManul.Id = 20;
            this.barManul.ImageIndex = 11;
            this.barManul.LargeImageIndex = 11;
            this.barManul.Name = "barManul";
            this.barManul.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManul_ItemClick);
            // 
            // barClose
            // 
            this.barClose.Caption = "     Close    ";
            this.barClose.Id = 21;
            this.barClose.ImageIndex = 8;
            this.barClose.LargeImageIndex = 8;
            this.barClose.Name = "barClose";
            this.barClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barClose_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup9,
            this.ribbonPageGroup5,
            this.ribbonPageGroup4,
            this.ribbonPageGroup3,
            this.ribbonPageGroup6,
            this.ribbonPageGroup7,
            this.ribbonPageGroup8,
            this.ribbonPageGroup10});
            this.ribbonPage1.KeyTip = "";
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Order Management";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barCreateNew);
            this.ribbonPageGroup1.KeyTip = "";
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "                     ";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ImageIndex = 1;
            this.ribbonPageGroup2.ItemLinks.Add(this.barModify);
            this.ribbonPageGroup2.KeyTip = "";
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "                  ";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.AllowTextClipping = false;
            this.ribbonPageGroup9.ItemLinks.Add(this.barManul);
            this.ribbonPageGroup9.KeyTip = "";
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.ShowCaptionButton = false;
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.AllowTextClipping = false;
            this.ribbonPageGroup5.ImageIndex = 5;
            this.ribbonPageGroup5.ItemLinks.Add(this.barLastOrder);
            this.ribbonPageGroup5.KeyTip = "";
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            this.ribbonPageGroup5.Text = "                   ";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ImageIndex = 3;
            this.ribbonPageGroup4.ItemLinks.Add(this.barPatient);
            this.ribbonPageGroup4.KeyTip = "";
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "                     ";
            this.ribbonPageGroup4.Visible = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ImageIndex = 8;
            this.ribbonPageGroup3.ItemLinks.Add(this.barSchedule);
            this.ribbonPageGroup3.KeyTip = "";
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "                 ";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.AllowTextClipping = false;
            this.ribbonPageGroup6.ImageIndex = 6;
            this.ribbonPageGroup6.ItemLinks.Add(this.barPrintLast);
            this.ribbonPageGroup6.KeyTip = "";
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.ShowCaptionButton = false;
            this.ribbonPageGroup6.Text = "             ";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.AllowTextClipping = false;
            this.ribbonPageGroup7.ImageIndex = 0;
            this.ribbonPageGroup7.ItemLinks.Add(this.barView);
            this.ribbonPageGroup7.KeyTip = "";
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.ShowCaptionButton = false;
            this.ribbonPageGroup7.Text = "                      ";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.AllowTextClipping = false;
            this.ribbonPageGroup8.ImageIndex = 2;
            this.ribbonPageGroup8.ItemLinks.Add(this.barHome);
            this.ribbonPageGroup8.KeyTip = "";
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.ShowCaptionButton = false;
            this.ribbonPageGroup8.Text = "                  ";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.AllowTextClipping = false;
            this.ribbonPageGroup10.ItemLinks.Add(this.barClose);
            this.ribbonPageGroup10.KeyTip = "";
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.ShowCaptionButton = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 122);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rdoOrder);
            this.splitContainer1.Panel1.Controls.Add(this.rdoSticker);
            this.splitContainer1.Panel1.Controls.Add(this.chkPrintExam);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel1.Controls.Add(this.textNoOfPrint);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdOrder);
            this.splitContainer1.Size = new System.Drawing.Size(809, 447);
            this.splitContainer1.SplitterDistance = 55;
            this.splitContainer1.TabIndex = 8;
            // 
            // frmReprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 569);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmReprint";
            this.Text = "RIS_TF01: Order Management";
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintExam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNoOfPrint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraGrid.GridControl grdOrder;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView view1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.RadioButton rdoSticker;
        private System.Windows.Forms.RadioButton rdoOrder;
        private DevExpress.XtraEditors.CheckEdit chkPrintExam;
        private DevExpress.XtraEditors.SpinEdit textNoOfPrint;
        private DevExpress.XtraEditors.LabelControl labelControl1;
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
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}