namespace RIS.Forms.Order
{
    partial class frmArrivalWorkList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArrivalWorkList));
            this.label2 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.label1 = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.dateTo = new DevExpress.XtraEditors.DateEdit();
            this.dateFrom = new DevExpress.XtraEditors.DateEdit();
            this.lblHN = new Nevron.UI.WinForm.Controls.NEntryContainer();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ultraExpandableGroupBox1 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.txtHN = new DevExpress.XtraEditors.TextEdit();
            this.ultraExpandableGroupBox2 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel2 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
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
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).BeginInit();
            this.ultraExpandableGroupBox1.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox2)).BeginInit();
            this.ultraExpandableGroupBox2.SuspendLayout();
            this.ultraExpandableGroupBoxPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(228, 2);
            this.label2.Name = "label2";
            this.label2.ShadowInfo.Draw = false;
            this.label2.Size = new System.Drawing.Size(153, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(47, 2);
            this.label1.Name = "label1";
            this.label1.ShadowInfo.Draw = false;
            this.label1.Size = new System.Drawing.Size(175, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "From Date";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.FormsUseDefaultLookAndFeel = false;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.advBandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(810, 303);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView1});
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.advBandedGridView1.GridControl = this.gridControl1;
            this.advBandedGridView1.Name = "advBandedGridView1";
            this.advBandedGridView1.Click += new System.EventHandler(this.advBandedGridView1_Click);
            this.advBandedGridView1.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.advBandedGridView1_CustomDrawColumnHeader);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // dateTo
            // 
            this.dateTo.EditValue = null;
            this.dateTo.Location = new System.Drawing.Point(280, 4);
            this.dateTo.Name = "dateTo";
            this.dateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateTo.Size = new System.Drawing.Size(96, 20);
            this.dateTo.TabIndex = 5;
            // 
            // dateFrom
            // 
            this.dateFrom.EditValue = null;
            this.dateFrom.Location = new System.Drawing.Point(110, 5);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateFrom.Size = new System.Drawing.Size(107, 20);
            this.dateFrom.TabIndex = 3;
            // 
            // lblHN
            // 
            this.lblHN.Location = new System.Drawing.Point(42, 2);
            this.lblHN.Name = "lblHN";
            this.lblHN.ShadowInfo.Draw = false;
            this.lblHN.Size = new System.Drawing.Size(148, 27);
            this.lblHN.TabIndex = 0;
            this.lblHN.Text = "HN";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(6, 165);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(814, 307);
            this.panelControl1.TabIndex = 8;
            // 
            // ultraExpandableGroupBox1
            // 
            this.ultraExpandableGroupBox1.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.ultraExpandableGroupBox1.ExpandedSize = new System.Drawing.Size(218, 56);
            this.ultraExpandableGroupBox1.Location = new System.Drawing.Point(78, 103);
            this.ultraExpandableGroupBox1.Name = "ultraExpandableGroupBox1";
            this.ultraExpandableGroupBox1.Size = new System.Drawing.Size(218, 56);
            this.ultraExpandableGroupBox1.TabIndex = 9;
            this.ultraExpandableGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtHN);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.lblHN);
            this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(3, 18);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(212, 35);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            // 
            // txtHN
            // 
            this.txtHN.Location = new System.Drawing.Point(77, 5);
            this.txtHN.Name = "txtHN";
            this.txtHN.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHN.Size = new System.Drawing.Size(108, 20);
            this.txtHN.TabIndex = 1;
            this.txtHN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHN_KeyPress);
            // 
            // ultraExpandableGroupBox2
            // 
            this.ultraExpandableGroupBox2.Controls.Add(this.ultraExpandableGroupBoxPanel2);
            this.ultraExpandableGroupBox2.ExpandedSize = new System.Drawing.Size(449, 56);
            this.ultraExpandableGroupBox2.Location = new System.Drawing.Point(299, 103);
            this.ultraExpandableGroupBox2.Name = "ultraExpandableGroupBox2";
            this.ultraExpandableGroupBox2.Size = new System.Drawing.Size(449, 56);
            this.ultraExpandableGroupBox2.TabIndex = 10;
            this.ultraExpandableGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraExpandableGroupBoxPanel2
            // 
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.btnSearch);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.dateTo);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.dateFrom);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.label2);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.label1);
            this.ultraExpandableGroupBoxPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel2.Location = new System.Drawing.Point(3, 18);
            this.ultraExpandableGroupBoxPanel2.Name = "ultraExpandableGroupBoxPanel2";
            this.ultraExpandableGroupBoxPanel2.Size = new System.Drawing.Size(443, 35);
            this.ultraExpandableGroupBoxPanel2.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(387, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(43, 26);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Go";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.barPrintLast});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 20;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.SelectedPage = this.ribbonPage1;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(820, 97);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(60, 60);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // barCreateNew
            // 
            this.barCreateNew.Caption = "New  Order";
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
            this.barPatient.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPatient_ItemClick);
            // 
            // barLastOrder
            // 
            this.barLastOrder.Caption = "Last  Order";
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
            this.barHome.Caption = "     Home   ";
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
            this.barPrintLast.ImageIndex = 8;
            this.barPrintLast.LargeImageIndex = 8;
            this.barPrintLast.Name = "barPrintLast";
            this.barPrintLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPrintLast_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5,
            this.ribbonPageGroup6,
            this.ribbonPageGroup7,
            this.ribbonPageGroup8});
            this.ribbonPage1.KeyTip = "";
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Order Management";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barCreateNew);
            this.ribbonPageGroup1.KeyTip = "";
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ImageIndex = 1;
            this.ribbonPageGroup2.ItemLinks.Add(this.barModify);
            this.ribbonPageGroup2.KeyTip = "";
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ImageIndex = 8;
            this.ribbonPageGroup3.ItemLinks.Add(this.barSchedule);
            this.ribbonPageGroup3.KeyTip = "";
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ImageIndex = 3;
            this.ribbonPageGroup4.ItemLinks.Add(this.barPatient);
            this.ribbonPageGroup4.KeyTip = "";
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ImageIndex = 5;
            this.ribbonPageGroup5.ItemLinks.Add(this.barLastOrder);
            this.ribbonPageGroup5.KeyTip = "";
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ImageIndex = 6;
            this.ribbonPageGroup6.ItemLinks.Add(this.barPrintLast);
            this.ribbonPageGroup6.KeyTip = "";
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.ShowCaptionButton = false;
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ImageIndex = 0;
            this.ribbonPageGroup7.ItemLinks.Add(this.barView);
            this.ribbonPageGroup7.KeyTip = "";
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.ShowCaptionButton = false;
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ImageIndex = 2;
            this.ribbonPageGroup8.ItemLinks.Add(this.barHome);
            this.ribbonPageGroup8.KeyTip = "";
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.ShowCaptionButton = false;
            // 
            // frmArrivalWorkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 499);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.ultraExpandableGroupBox2);
            this.Controls.Add(this.ultraExpandableGroupBox1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmArrivalWorkList";
            this.Text = "RIS_TF101: Order Management";
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).EndInit();
            this.ultraExpandableGroupBox1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtHN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox2)).EndInit();
            this.ultraExpandableGroupBox2.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NEntryContainer label2;
        private Nevron.UI.WinForm.Controls.NEntryContainer label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.DateEdit dateTo;
        private DevExpress.XtraEditors.DateEdit dateFrom;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private Nevron.UI.WinForm.Controls.NEntryContainer lblHN;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox1;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
        private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox2;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel2;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem barCreateNew;
        private DevExpress.XtraBars.BarButtonItem barModify;
        private DevExpress.XtraBars.BarButtonItem barSchedule;
        private DevExpress.XtraBars.BarButtonItem barPatient;
        private DevExpress.XtraBars.BarButtonItem barLastOrder;
        private DevExpress.XtraBars.BarButtonItem barView;
        private DevExpress.XtraBars.BarButtonItem barHome;
        private DevExpress.XtraBars.BarButtonItem barPrintLast;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        public DevExpress.XtraEditors.TextEdit txtHN;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}