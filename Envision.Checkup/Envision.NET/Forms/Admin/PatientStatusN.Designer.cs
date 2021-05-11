namespace RIS.Forms.Admin
{
    partial class PatientStatusN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientStatusN));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.Navigator = new DevExpress.XtraEditors.ControlNavigator();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.grdContrl = new DevExpress.XtraGrid.GridControl();
            this.views = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.brBtnNew = new DevExpress.XtraBars.BarButtonItem();
            this.brBtnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.brHome = new DevExpress.XtraBars.BarButtonItem();
            this.brClose = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.brBtnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.imageRibbon = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtStatusText = new DevExpress.XtraEditors.TextEdit();
            this.txtUID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lblAlertUID = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chkDefault = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdContrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.views)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefault.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl1.Controls.Add(this.Navigator);
            this.groupControl1.Controls.Add(this.grdContrl);
            this.groupControl1.Location = new System.Drawing.Point(0, 103);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(470, 290);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Patient Status";
            // 
            // Navigator
            // 
            this.Navigator.Buttons.Append.Hint = "NEW";
            this.Navigator.Buttons.Append.ImageIndex = 0;
            this.Navigator.Buttons.Append.Visible = false;
            this.Navigator.Buttons.CancelEdit.Hint = "CANCEL";
            this.Navigator.Buttons.CancelEdit.ImageIndex = 3;
            this.Navigator.Buttons.CancelEdit.Visible = false;
            this.Navigator.Buttons.Edit.Hint = "EDIT";
            this.Navigator.Buttons.Edit.Visible = false;
            this.Navigator.Buttons.EndEdit.ImageIndex = 2;
            this.Navigator.Buttons.EndEdit.Visible = false;
            this.Navigator.Buttons.ImageList = this.imageCollection1;
            this.Navigator.Buttons.Last.Hint = "Last";
            this.Navigator.Buttons.Next.Hint = "Next";
            this.Navigator.Buttons.NextPage.Hint = "NextPage";
            this.Navigator.Buttons.NextPage.Visible = false;
            this.Navigator.Buttons.Prev.Hint = "Back";
            this.Navigator.Buttons.PrevPage.Hint = "PrevPage";
            this.Navigator.Buttons.PrevPage.Visible = false;
            this.Navigator.Buttons.Remove.ImageIndex = 1;
            this.Navigator.Buttons.Remove.Visible = false;
            this.Navigator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Navigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Navigator.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.Navigator.Location = new System.Drawing.Point(2, 252);
            this.Navigator.Name = "Navigator";
            this.Navigator.NavigatableControl = this.grdContrl;
            this.Navigator.Size = new System.Drawing.Size(466, 36);
            this.Navigator.TabIndex = 1;
            this.Navigator.Text = "controlNavigator1";
            this.Navigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.Navigator.Click += new System.EventHandler(this.Navigator_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // grdContrl
            // 
            this.grdContrl.EmbeddedNavigator.Name = "";
            this.grdContrl.FormsUseDefaultLookAndFeel = false;
            this.grdContrl.Location = new System.Drawing.Point(5, 23);
            this.grdContrl.MainView = this.views;
            this.grdContrl.Name = "grdContrl";
            this.grdContrl.Size = new System.Drawing.Size(458, 217);
            this.grdContrl.TabIndex = 123;
            this.grdContrl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.views});
            // 
            // views
            // 
            this.views.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.views.GridControl = this.grdContrl;
            this.views.Name = "views";
            this.views.OptionsView.ColumnAutoWidth = true;
            this.views.OptionsView.ShowAutoFilterRow = true;
            this.views.OptionsView.ShowBands = false;
            this.views.OptionsView.ShowGroupPanel = false;
            this.views.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.views_FocusedRowChanged);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonKeyTip = "";
            this.ribbonControl1.ApplicationIcon = null;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.brBtnNew,
            this.brBtnEdit,
            this.brHome,
            this.brClose,
            this.barButtonItem5,
            this.brBtnDelete});
            this.ribbonControl1.LargeImages = this.imageRibbon;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.SelectedPage = this.ribbonPage1;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(745, 97);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // brBtnNew
            // 
            this.brBtnNew.Caption = "New Patient";
            this.brBtnNew.Id = 0;
            this.brBtnNew.LargeImageIndex = 0;
            this.brBtnNew.Name = "brBtnNew";
            this.brBtnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.brBtnNew_ItemClick);
            // 
            // brBtnEdit
            // 
            this.brBtnEdit.Caption = "Edit Patient";
            this.brBtnEdit.Id = 1;
            this.brBtnEdit.LargeImageIndex = 1;
            this.brBtnEdit.Name = "brBtnEdit";
            this.brBtnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.brBtnEdit_ItemClick);
            // 
            // brHome
            // 
            this.brHome.Caption = "Home";
            this.brHome.Id = 2;
            this.brHome.LargeImageIndex = 2;
            this.brHome.Name = "brHome";
            this.brHome.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.brHome_ItemClick);
            // 
            // brClose
            // 
            this.brClose.Caption = "Close";
            this.brClose.Id = 3;
            this.brClose.LargeImageIndex = 3;
            this.brClose.Name = "brClose";
            this.brClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.brClose_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 4;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // brBtnDelete
            // 
            this.brBtnDelete.Caption = "Delete Patient";
            this.brBtnDelete.Id = 5;
            this.brBtnDelete.LargeImageIndex = 4;
            this.brBtnDelete.Name = "brBtnDelete";
            this.brBtnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.brBtnDelete_ItemClick);
            // 
            // imageRibbon
            // 
            this.imageRibbon.ImageSize = new System.Drawing.Size(60, 60);
            this.imageRibbon.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageRibbon.ImageStream")));
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup5,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.KeyTip = "";
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.brBtnNew);
            this.ribbonPageGroup1.KeyTip = "";
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.brBtnEdit);
            this.ribbonPageGroup2.KeyTip = "";
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.brBtnDelete);
            this.ribbonPageGroup5.KeyTip = "";
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.brHome);
            this.ribbonPageGroup3.KeyTip = "";
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.brClose);
            this.ribbonPageGroup4.KeyTip = "";
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            // 
            // chkActive
            // 
            this.chkActive.Location = new System.Drawing.Point(77, 141);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Caption = "Active";
            this.chkActive.Size = new System.Drawing.Size(57, 18);
            this.chkActive.TabIndex = 2;
            this.chkActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkActive_KeyDown);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(79, 65);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(146, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(51, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(79, 177);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtStatusText
            // 
            this.txtStatusText.Location = new System.Drawing.Point(79, 110);
            this.txtStatusText.Name = "txtStatusText";
            this.txtStatusText.Size = new System.Drawing.Size(154, 20);
            this.txtStatusText.TabIndex = 1;
            this.txtStatusText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStatusText_KeyDown);
            // 
            // txtUID
            // 
            this.txtUID.Location = new System.Drawing.Point(79, 84);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(154, 20);
            this.txtUID.TabIndex = 0;
            this.txtUID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUID_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 87);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Status UID :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 113);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Status Text :";
            // 
            // groupControl2
            // 
            this.groupControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl2.Controls.Add(this.lblAlertUID);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.chkDefault);
            this.groupControl2.Controls.Add(this.btnCancel);
            this.groupControl2.Controls.Add(this.chkActive);
            this.groupControl2.Controls.Add(this.btnSave);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.lblStatus);
            this.groupControl2.Controls.Add(this.txtUID);
            this.groupControl2.Controls.Add(this.txtStatusText);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Location = new System.Drawing.Point(476, 103);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(257, 288);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.TabStop = true;
            this.groupControl2.Text = "Views";
            // 
            // lblAlertUID
            // 
            this.lblAlertUID.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblAlertUID.Appearance.Options.UseForeColor = true;
            this.lblAlertUID.Location = new System.Drawing.Point(239, 87);
            this.lblAlertUID.Name = "lblAlertUID";
            this.lblAlertUID.Size = new System.Drawing.Size(6, 13);
            this.lblAlertUID.TabIndex = 11;
            this.lblAlertUID.Text = "*";
            this.lblAlertUID.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(55, 65);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(18, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "ID :";
            // 
            // chkDefault
            // 
            this.chkDefault.Location = new System.Drawing.Point(144, 141);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Properties.Caption = "Set Default";
            this.chkDefault.Size = new System.Drawing.Size(75, 18);
            this.chkDefault.TabIndex = 3;
            this.chkDefault.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkDefault_KeyDown);
            // 
            // PatientStatusN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(745, 439);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "PatientStatusN";
            this.Text = "PatientStatusN";
            this.Load += new System.EventHandler(this.PatientStatusN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdContrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.views)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefault.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ControlNavigator Navigator;
        private DevExpress.XtraGrid.GridControl grdContrl;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView views;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.Utils.ImageCollection imageRibbon;
        private DevExpress.XtraBars.BarButtonItem brBtnNew;
        private DevExpress.XtraBars.BarButtonItem brBtnEdit;
        private DevExpress.XtraBars.BarButtonItem brHome;
        private DevExpress.XtraBars.BarButtonItem brClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtStatusText;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.TextEdit txtUID;
        private DevExpress.XtraBars.BarButtonItem brBtnDelete;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckEdit chkDefault;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblAlertUID;

    }
}