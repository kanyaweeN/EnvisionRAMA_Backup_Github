namespace Envision.NET.Forms.Academic
{
    partial class frmAcadermicPromote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAcadermicPromote));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cmbClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnPromote = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowPassword = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefreshPassword = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnSavePrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnFromPR = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.btnribbonAdd = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.cmbYearPromote = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnAllLeft = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnAllRight = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.gcLeft = new DevExpress.XtraGrid.GridControl();
            this.gvEnroll = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcRight = new DevExpress.XtraGrid.GridControl();
            this.gvEnrollSelect = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYearPromote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEnroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEnrollSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.cmbClass);
            this.layoutControl1.Controls.Add(this.cmbYearPromote);
            this.layoutControl1.Controls.Add(this.cmbYear);
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Controls.Add(this.gcLeft);
            this.layoutControl1.Controls.Add(this.gcRight);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 95);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(826, 544);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cmbClass
            // 
            this.cmbClass.Location = new System.Drawing.Point(551, 38);
            this.cmbClass.MenuManager = this.ribbonControl1;
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbClass.Size = new System.Drawing.Size(269, 20);
            this.cmbClass.StyleController = this.layoutControl1;
            this.cmbClass.TabIndex = 8;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = null;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPromote,
            this.btnUpdate,
            this.btnSave,
            this.btnCancel,
            this.btnShowPassword,
            this.btnRefreshPassword,
            this.btnDelete,
            this.btnSavePrint,
            this.btnPrint,
            this.btnFromPR});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 21;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.SelectedPage = this.ribbonPage1;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(826, 95);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnPromote
            // 
            this.btnPromote.Caption = "Promote";
            this.btnPromote.Id = 0;
            this.btnPromote.LargeImageIndex = 8;
            this.btnPromote.LargeWidth = 60;
            this.btnPromote.Name = "btnPromote";
            this.btnPromote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPromote_ItemClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Caption = "Edit";
            this.btnUpdate.Id = 1;
            this.btnUpdate.LargeImageIndex = 5;
            this.btnUpdate.LargeWidth = 60;
            this.btnUpdate.Name = "btnUpdate";
            // 
            // btnSave
            // 
            this.btnSave.Caption = " Save  ";
            this.btnSave.Id = 3;
            this.btnSave.LargeImageIndex = 9;
            this.btnSave.LargeWidth = 60;
            this.btnSave.Name = "btnSave";
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Cancel ";
            this.btnCancel.Id = 4;
            this.btnCancel.LargeImageIndex = 12;
            this.btnCancel.LargeWidth = 60;
            this.btnCancel.Name = "btnCancel";
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.Caption = " Show  Password";
            this.btnShowPassword.Id = 11;
            this.btnShowPassword.LargeImageIndex = 9;
            this.btnShowPassword.LargeWidth = 60;
            this.btnShowPassword.Name = "btnShowPassword";
            // 
            // btnRefreshPassword
            // 
            this.btnRefreshPassword.Caption = "Reset Password";
            this.btnRefreshPassword.Id = 12;
            this.btnRefreshPassword.LargeImageIndex = 10;
            this.btnRefreshPassword.LargeWidth = 60;
            this.btnRefreshPassword.Name = "btnRefreshPassword";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Id = 17;
            this.btnDelete.LargeImageIndex = 1;
            this.btnDelete.LargeWidth = 60;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.Caption = "Save&&Print";
            this.btnSavePrint.Id = 18;
            this.btnSavePrint.LargeImageIndex = 10;
            this.btnSavePrint.LargeWidth = 60;
            this.btnSavePrint.Name = "btnSavePrint";
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Print";
            this.btnPrint.Id = 19;
            this.btnPrint.LargeImageIndex = 7;
            this.btnPrint.LargeWidth = 60;
            this.btnPrint.Name = "btnPrint";
            // 
            // btnFromPR
            // 
            this.btnFromPR.Caption = "From PR";
            this.btnFromPR.Id = 20;
            this.btnFromPR.LargeImageIndex = 8;
            this.btnFromPR.LargeWidth = 60;
            this.btnFromPR.Name = "btnFromPR";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(48, 48);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "add_48.png");
            this.imageCollection1.Images.SetKeyName(1, "alert_caution_and_warning48.png");
            this.imageCollection1.Images.SetKeyName(2, "BtnSave.png");
            this.imageCollection1.Images.SetKeyName(3, "close48.png");
            this.imageCollection1.Images.SetKeyName(4, "exit48.png");
            this.imageCollection1.Images.SetKeyName(5, "order_48.png");
            this.imageCollection1.Images.SetKeyName(6, "priority2_48.png");
            this.imageCollection1.Images.SetKeyName(7, "reprint_48.png");
            this.imageCollection1.Images.SetKeyName(8, "result_entry48.png");
            this.imageCollection1.Images.SetKeyName(9, "saveLarge.png");
            this.imageCollection1.Images.SetKeyName(10, "Untitled-1(1).png");
            this.imageCollection1.Images.SetKeyName(11, "saveLarge.png");
            this.imageCollection1.Images.SetKeyName(12, "closeLarge.png");
            this.imageCollection1.Images.SetKeyName(13, "PNG-Refresh_png-256x256.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.btnribbonAdd});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // btnribbonAdd
            // 
            this.btnribbonAdd.AllowTextClipping = false;
            this.btnribbonAdd.ItemLinks.Add(this.btnPromote);
            this.btnribbonAdd.Name = "btnribbonAdd";
            this.btnribbonAdd.ShowCaptionButton = false;
            // 
            // cmbYearPromote
            // 
            this.cmbYearPromote.Location = new System.Drawing.Point(551, 7);
            this.cmbYearPromote.Name = "cmbYearPromote";
            this.cmbYearPromote.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbYearPromote.Size = new System.Drawing.Size(269, 20);
            this.cmbYearPromote.StyleController = this.layoutControl1;
            this.cmbYearPromote.TabIndex = 7;
            // 
            // cmbYear
            // 
            this.cmbYear.Location = new System.Drawing.Point(80, 7);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbYear.Size = new System.Drawing.Size(271, 20);
            this.cmbYear.StyleController = this.layoutControl1;
            this.cmbYear.TabIndex = 6;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnAllLeft);
            this.groupControl1.Controls.Add(this.btnLeft);
            this.groupControl1.Controls.Add(this.btnAllRight);
            this.groupControl1.Controls.Add(this.btnRight);
            this.groupControl1.Location = new System.Drawing.Point(362, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(105, 531);
            this.groupControl1.TabIndex = 1;
            // 
            // btnAllLeft
            // 
            this.btnAllLeft.Location = new System.Drawing.Point(17, 212);
            this.btnAllLeft.Name = "btnAllLeft";
            this.btnAllLeft.Size = new System.Drawing.Size(75, 23);
            this.btnAllLeft.TabIndex = 3;
            this.btnAllLeft.Text = "<<";
            this.btnAllLeft.UseVisualStyleBackColor = true;
            this.btnAllLeft.Click += new System.EventHandler(this.btnAllLeft_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(17, 174);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnAllRight
            // 
            this.btnAllRight.Location = new System.Drawing.Point(17, 97);
            this.btnAllRight.Name = "btnAllRight";
            this.btnAllRight.Size = new System.Drawing.Size(75, 23);
            this.btnAllRight.TabIndex = 0;
            this.btnAllRight.Text = ">>";
            this.btnAllRight.UseVisualStyleBackColor = true;
            this.btnAllRight.Click += new System.EventHandler(this.btnAllRight_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(17, 134);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 1;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // gcLeft
            // 
            this.gcLeft.Location = new System.Drawing.Point(7, 38);
            this.gcLeft.MainView = this.gvEnroll;
            this.gcLeft.Name = "gcLeft";
            this.gcLeft.Size = new System.Drawing.Size(344, 500);
            this.gcLeft.TabIndex = 4;
            this.gcLeft.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEnroll});
            // 
            // gvEnroll
            // 
            this.gvEnroll.GridControl = this.gcLeft;
            this.gvEnroll.Name = "gvEnroll";
            this.gvEnroll.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvEnroll.OptionsView.ShowAutoFilterRow = true;
            this.gvEnroll.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvEnroll.OptionsView.ShowGroupPanel = false;
            // 
            // gcRight
            // 
            this.gcRight.Location = new System.Drawing.Point(478, 69);
            this.gcRight.MainView = this.gvEnrollSelect;
            this.gcRight.Name = "gcRight";
            this.gcRight.Size = new System.Drawing.Size(342, 469);
            this.gcRight.TabIndex = 5;
            this.gcRight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEnrollSelect});
            // 
            // gvEnrollSelect
            // 
            this.gvEnrollSelect.GridControl = this.gcRight;
            this.gvEnrollSelect.Name = "gvEnrollSelect";
            this.gvEnrollSelect.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvEnrollSelect.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(826, 544);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcLeft;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(355, 511);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.groupControl1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(355, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(116, 542);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gcRight;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(471, 62);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(353, 480);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cmbYear;
            this.layoutControlItem4.CustomizationFormText = "Select Year";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(355, 31);
            this.layoutControlItem4.Text = "Select Year";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cmbYearPromote;
            this.layoutControlItem5.CustomizationFormText = "Select Enrollment";
            this.layoutControlItem5.Location = new System.Drawing.Point(471, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(353, 31);
            this.layoutControlItem5.Text = "Year promote";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.cmbClass;
            this.layoutControlItem6.CustomizationFormText = "Class promote";
            this.layoutControlItem6.Location = new System.Drawing.Point(471, 31);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(353, 31);
            this.layoutControlItem6.Text = "Class promote";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(68, 13);
            // 
            // frmAcadermicPromote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 639);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmAcadermicPromote";
            this.Text = "fromAcadermicPromote";
            this.Load += new System.EventHandler(this.frmAcadermicPromote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYearPromote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEnroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEnrollSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Button btnAllLeft;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnAllRight;
        private DevExpress.XtraGrid.GridControl gcLeft;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEnroll;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gcRight;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEnrollSelect;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbYearPromote;
        private DevExpress.XtraEditors.ComboBoxEdit cmbYear;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        public DevExpress.XtraBars.BarButtonItem btnPromote;
        private DevExpress.XtraBars.BarButtonItem btnUpdate;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarButtonItem btnShowPassword;
        private DevExpress.XtraBars.BarButtonItem btnRefreshPassword;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnSavePrint;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnFromPR;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup btnribbonAdd;
        private DevExpress.XtraEditors.ComboBoxEdit cmbClass;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}