namespace RIS.Forms.Order
{
    partial class frmOrderWorkList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderWorkList));
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
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.grdWorkList = new DevExpress.XtraGrid.GridControl();
            this.view1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).BeginInit();
            this.SuspendLayout();
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
            this.ribbonControl1.Size = new System.Drawing.Size(854, 122);
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
            this.barSchedule.Caption = " Schedule ";
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
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // grdWorkList
            // 
            this.grdWorkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWorkList.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grdWorkList.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grdWorkList.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grdWorkList.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.grdWorkList.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grdWorkList.EmbeddedNavigator.Name = "";
            this.grdWorkList.Location = new System.Drawing.Point(0, 122);
            this.grdWorkList.MainView = this.view1;
            this.grdWorkList.Name = "grdWorkList";
            this.grdWorkList.Size = new System.Drawing.Size(854, 495);
            this.grdWorkList.TabIndex = 27;
            this.grdWorkList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view1});
            // 
            // view1
            // 
            this.view1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.view1.GridControl = this.grdWorkList;
            this.view1.Name = "view1";
            this.view1.OptionsView.ShowBands = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmOrderWorkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 617);
            this.Controls.Add(this.grdWorkList);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmOrderWorkList";
            this.Text = "Order work list";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.Utils.ImageCollection imageCollection1;
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
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraGrid.GridControl grdWorkList;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView view1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private System.Windows.Forms.Timer timer1;
    }
}