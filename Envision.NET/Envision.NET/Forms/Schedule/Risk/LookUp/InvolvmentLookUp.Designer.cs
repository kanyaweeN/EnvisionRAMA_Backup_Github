namespace Envision.NET.Risk
{
    partial class InvolvmentLookUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvolvmentLookUp));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnOK = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbAddAndDelete = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridInvolvmentControl = new DevExpress.XtraGrid.GridControl();
            this.gridInvolvmentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsRISK_CAT_UID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsRISK_CAT_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvolvmentControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvolvmentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnDelete,
            this.btnOK,
            this.btnClose});
            this.ribbon.LargeImages = this.imageCollection1;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.SelectedPage = this.ribbonPage1;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(584, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Add";
            this.btnAdd.Id = 0;
            this.btnAdd.LargeImageIndex = 0;
            this.btnAdd.Name = "btnAdd";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Id = 1;
            this.btnDelete.LargeImageIndex = 4;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnOK
            // 
            this.btnOK.Caption = "OK";
            this.btnOK.Id = 2;
            this.btnOK.LargeImageIndex = 7;
            this.btnOK.Name = "btnOK";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Id = 4;
            this.btnClose.LargeImageIndex = 1;
            this.btnClose.Name = "btnClose";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(48, 48);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "add_48.png");
            this.imageCollection1.Images.SetKeyName(1, "exit32.png");
            this.imageCollection1.Images.SetKeyName(2, "icon_order.png");
            this.imageCollection1.Images.SetKeyName(3, "cross.png");
            this.imageCollection1.Images.SetKeyName(4, "delete.png");
            this.imageCollection1.Images.SetKeyName(5, "Delete1.png");
            this.imageCollection1.Images.SetKeyName(6, "save.png");
            this.imageCollection1.Images.SetKeyName(7, "check mark.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbAddAndDelete,
            this.rbClose});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Involvment";
            // 
            // rbAddAndDelete
            // 
            this.rbAddAndDelete.ItemLinks.Add(this.btnAdd);
            this.rbAddAndDelete.ItemLinks.Add(this.btnDelete);
            this.rbAddAndDelete.Name = "rbAddAndDelete";
            this.rbAddAndDelete.ShowCaptionButton = false;
            // 
            // rbClose
            // 
            this.rbClose.ItemLinks.Add(this.btnClose);
            this.rbClose.Name = "rbClose";
            this.rbClose.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 481);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(584, 25);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.layoutControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 143);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(584, 338);
            this.clientPanel.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.gridInvolvmentControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(584, 338);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridInvolvmentControl
            // 
            this.gridInvolvmentControl.Location = new System.Drawing.Point(7, 7);
            this.gridInvolvmentControl.MainView = this.gridInvolvmentView;
            this.gridInvolvmentControl.MenuManager = this.ribbon;
            this.gridInvolvmentControl.Name = "gridInvolvmentControl";
            this.gridInvolvmentControl.Size = new System.Drawing.Size(571, 325);
            this.gridInvolvmentControl.TabIndex = 8;
            this.gridInvolvmentControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridInvolvmentView});
            // 
            // gridInvolvmentView
            // 
            this.gridInvolvmentView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsRISK_CAT_UID,
            this.colsRISK_CAT_DESC,
            this.colsUnit});
            this.gridInvolvmentView.GridControl = this.gridInvolvmentControl;
            this.gridInvolvmentView.Name = "gridInvolvmentView";
            this.gridInvolvmentView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridInvolvmentView.OptionsBehavior.Editable = false;
            this.gridInvolvmentView.OptionsMenu.EnableColumnMenu = false;
            this.gridInvolvmentView.OptionsMenu.EnableFooterMenu = false;
            this.gridInvolvmentView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridInvolvmentView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridInvolvmentView.OptionsView.ShowAutoFilterRow = true;
            this.gridInvolvmentView.OptionsView.ShowGroupPanel = false;
            // 
            // colsRISK_CAT_UID
            // 
            this.colsRISK_CAT_UID.Caption = "Emp code";
            this.colsRISK_CAT_UID.FieldName = "EMP_UID";
            this.colsRISK_CAT_UID.Name = "colsRISK_CAT_UID";
            this.colsRISK_CAT_UID.Visible = true;
            this.colsRISK_CAT_UID.VisibleIndex = 0;
            this.colsRISK_CAT_UID.Width = 65;
            // 
            // colsRISK_CAT_DESC
            // 
            this.colsRISK_CAT_DESC.Caption = "Name";
            this.colsRISK_CAT_DESC.FieldName = "FULL_NAME";
            this.colsRISK_CAT_DESC.Name = "colsRISK_CAT_DESC";
            this.colsRISK_CAT_DESC.Visible = true;
            this.colsRISK_CAT_DESC.VisibleIndex = 1;
            this.colsRISK_CAT_DESC.Width = 182;
            // 
            // colsUnit
            // 
            this.colsUnit.Caption = "Unit";
            this.colsUnit.FieldName = "UNIT_NAME";
            this.colsUnit.Name = "colsUnit";
            this.colsUnit.Visible = true;
            this.colsUnit.VisibleIndex = 2;
            this.colsUnit.Width = 303;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(584, 338);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridInvolvmentControl;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(582, 336);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // InvolvmentLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 506);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "InvolvmentLookUp";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Involvment";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInvolvmentControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvolvmentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbAddAndDelete;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnOK;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbClose;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridInvolvmentControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridInvolvmentView;
        private DevExpress.XtraGrid.Columns.GridColumn colsRISK_CAT_UID;
        private DevExpress.XtraGrid.Columns.GridColumn colsRISK_CAT_DESC;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colsUnit;
    }
}