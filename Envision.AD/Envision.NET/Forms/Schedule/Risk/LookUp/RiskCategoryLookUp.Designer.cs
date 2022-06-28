namespace Envision.NET.Risk
{
    partial class RiskCategoryLookUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RiskCategoryLookUp));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAddCat = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbAddCat = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbConfrim = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbCloseForm = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridRiskCatControl = new DevExpress.XtraGrid.GridControl();
            this.gridRiskCatView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsRISK_CAT_UID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsRISK_CAT_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbRiskCatDesc = new DevExpress.XtraEditors.TextEdit();
            this.tbRiskCatCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRiskCatControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRiskCatView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRiskCatDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRiskCatCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddCat,
            this.btnEdit,
            this.btnClose,
            this.btnCancel,
            this.btnDelete,
            this.btnSave});
            this.ribbon.LargeImages = this.imageCollection1;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.SelectedPage = this.ribbonPage1;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(618, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnAddCat
            // 
            this.btnAddCat.Caption = "Add";
            this.btnAddCat.Id = 0;
            this.btnAddCat.LargeImageIndex = 0;
            this.btnAddCat.Name = "btnAddCat";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Id = 1;
            this.btnEdit.LargeImageIndex = 2;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Id = 2;
            this.btnClose.LargeImageIndex = 1;
            this.btnClose.Name = "btnClose";
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.Id = 3;
            this.btnCancel.LargeImageIndex = 5;
            this.btnCancel.Name = "btnCancel";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Id = 4;
            this.btnDelete.LargeImageIndex = 4;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Id = 5;
            this.btnSave.LargeImageIndex = 6;
            this.btnSave.Name = "btnSave";
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
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbAddCat,
            this.rbConfrim,
            this.rbCloseForm});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // rbAddCat
            // 
            this.rbAddCat.ItemLinks.Add(this.btnAddCat);
            this.rbAddCat.ItemLinks.Add(this.btnEdit);
            this.rbAddCat.ItemLinks.Add(this.btnDelete);
            this.rbAddCat.Name = "rbAddCat";
            this.rbAddCat.ShowCaptionButton = false;
            // 
            // rbConfrim
            // 
            this.rbConfrim.ItemLinks.Add(this.btnSave);
            this.rbConfrim.ItemLinks.Add(this.btnCancel);
            this.rbConfrim.Name = "rbConfrim";
            this.rbConfrim.ShowCaptionButton = false;
            // 
            // rbCloseForm
            // 
            this.rbCloseForm.ItemLinks.Add(this.btnClose);
            this.rbCloseForm.Name = "rbCloseForm";
            this.rbCloseForm.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 459);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(618, 25);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.layoutControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 143);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(618, 316);
            this.clientPanel.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.gridRiskCatControl);
            this.layoutControl1.Controls.Add(this.tbRiskCatDesc);
            this.layoutControl1.Controls.Add(this.tbRiskCatCode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(618, 316);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridRiskCatControl
            // 
            this.gridRiskCatControl.Location = new System.Drawing.Point(4, 54);
            this.gridRiskCatControl.MainView = this.gridRiskCatView;
            this.gridRiskCatControl.MenuManager = this.ribbon;
            this.gridRiskCatControl.Name = "gridRiskCatControl";
            this.gridRiskCatControl.Size = new System.Drawing.Size(611, 259);
            this.gridRiskCatControl.TabIndex = 7;
            this.gridRiskCatControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridRiskCatView});
            // 
            // gridRiskCatView
            // 
            this.gridRiskCatView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsRISK_CAT_UID,
            this.colsRISK_CAT_DESC});
            this.gridRiskCatView.GridControl = this.gridRiskCatControl;
            this.gridRiskCatView.Name = "gridRiskCatView";
            this.gridRiskCatView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridRiskCatView.OptionsBehavior.Editable = false;
            this.gridRiskCatView.OptionsMenu.EnableColumnMenu = false;
            this.gridRiskCatView.OptionsMenu.EnableFooterMenu = false;
            this.gridRiskCatView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridRiskCatView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridRiskCatView.OptionsView.ShowAutoFilterRow = true;
            this.gridRiskCatView.OptionsView.ShowGroupPanel = false;
            // 
            // colsRISK_CAT_UID
            // 
            this.colsRISK_CAT_UID.Caption = "Risk Code";
            this.colsRISK_CAT_UID.FieldName = "RISK_CAT_UID";
            this.colsRISK_CAT_UID.Name = "colsRISK_CAT_UID";
            this.colsRISK_CAT_UID.Visible = true;
            this.colsRISK_CAT_UID.VisibleIndex = 0;
            this.colsRISK_CAT_UID.Width = 84;
            // 
            // colsRISK_CAT_DESC
            // 
            this.colsRISK_CAT_DESC.Caption = "Risk Description";
            this.colsRISK_CAT_DESC.FieldName = "RISK_CAT_DESC";
            this.colsRISK_CAT_DESC.Name = "colsRISK_CAT_DESC";
            this.colsRISK_CAT_DESC.Visible = true;
            this.colsRISK_CAT_DESC.VisibleIndex = 1;
            this.colsRISK_CAT_DESC.Width = 506;
            // 
            // tbRiskCatDesc
            // 
            this.tbRiskCatDesc.Location = new System.Drawing.Point(158, 29);
            this.tbRiskCatDesc.MenuManager = this.ribbon;
            this.tbRiskCatDesc.Name = "tbRiskCatDesc";
            this.tbRiskCatDesc.Size = new System.Drawing.Size(457, 20);
            this.tbRiskCatDesc.StyleController = this.layoutControl1;
            this.tbRiskCatDesc.TabIndex = 6;
            // 
            // tbRiskCatCode
            // 
            this.tbRiskCatCode.Location = new System.Drawing.Point(158, 4);
            this.tbRiskCatCode.MenuManager = this.ribbon;
            this.tbRiskCatCode.Name = "tbRiskCatCode";
            this.tbRiskCatCode.Size = new System.Drawing.Size(457, 20);
            this.tbRiskCatCode.StyleController = this.layoutControl1;
            this.tbRiskCatCode.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(618, 316);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.tbRiskCatCode;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
            this.layoutControlItem1.Size = new System.Drawing.Size(616, 25);
            this.layoutControlItem1.Text = "Risk Category Code";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(146, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.tbRiskCatDesc;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(616, 25);
            this.layoutControlItem2.Text = "Risk Category Description";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(146, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridRiskCatControl;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Size = new System.Drawing.Size(616, 264);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // RiskCategoryLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 484);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "RiskCategoryLookUp";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Risk Category";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRiskCatControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRiskCatView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRiskCatDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRiskCatCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbAddCat;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridRiskCatControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridRiskCatView;
        private DevExpress.XtraEditors.TextEdit tbRiskCatDesc;
        private DevExpress.XtraEditors.TextEdit tbRiskCatCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbConfrim;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbCloseForm;
        private DevExpress.XtraBars.BarButtonItem btnAddCat;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colsRISK_CAT_UID;
        private DevExpress.XtraGrid.Columns.GridColumn colsRISK_CAT_DESC;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnSave;
    }
}