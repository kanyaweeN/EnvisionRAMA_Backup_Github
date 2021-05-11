namespace Envision.NET.Mammogram.StructureReport
{
    partial class BiradDominantCystList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BiradDominantCystList));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnOK = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.LargeImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabMass = new DevExpress.XtraTab.XtraTabPage();
            this.gcDominantMassList = new DevExpress.XtraGrid.GridControl();
            this.gvDominantMass = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMassNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCbMassNo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gcBreast = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repBtnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.tabCyst = new DevExpress.XtraTab.XtraTabPage();
            this.gcDominantCystList = new DevExpress.XtraGrid.GridControl();
            this.gvDominantCyst = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMassNo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCombobox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDelete2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDetele2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.LargeImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabMass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDominantMassList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDominantMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCbMassNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnDelete)).BeginInit();
            this.tabCyst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDominantCystList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDominantCyst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCombobox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDetele2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnOK,
            this.btnCancel});
            this.ribbon.LargeImages = this.LargeImageCollection;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 2;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.SelectedPage = this.ribbonPage1;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(650, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // btnOK
            // 
            this.btnOK.Caption = "Save";
            this.btnOK.Id = 0;
            this.btnOK.LargeImageIndex = 2;
            this.btnOK.LargeWidth = 50;
            this.btnOK.Name = "btnOK";
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.Id = 1;
            this.btnCancel.LargeImageIndex = 11;
            this.btnCancel.LargeWidth = 50;
            this.btnCancel.Name = "btnCancel";
            // 
            // LargeImageCollection
            // 
            this.LargeImageCollection.ImageSize = new System.Drawing.Size(32, 32);
            this.LargeImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("LargeImageCollection.ImageStream")));
            this.LargeImageCollection.Images.SetKeyName(0, "carousel-next.png");
            this.LargeImageCollection.Images.SetKeyName(1, "carousel-prev.png");
            this.LargeImageCollection.Images.SetKeyName(2, "check-icon.png");
            this.LargeImageCollection.Images.SetKeyName(3, "clear.png");
            this.LargeImageCollection.Images.SetKeyName(4, "Delete.png");
            this.LargeImageCollection.Images.SetKeyName(5, "features-highlight.png");
            this.LargeImageCollection.Images.SetKeyName(6, "features-undo.png");
            this.LargeImageCollection.Images.SetKeyName(7, "mark.png");
            this.LargeImageCollection.Images.SetKeyName(8, "quick_select_32x32.png");
            this.LargeImageCollection.Images.SetKeyName(9, "styleL.png");
            this.LargeImageCollection.Images.SetKeyName(10, "text-x-patch.png");
            this.LargeImageCollection.Images.SetKeyName(11, "close3_32.png");
            this.LargeImageCollection.Images.SetKeyName(12, "save_draft_32.png");
            this.LargeImageCollection.Images.SetKeyName(13, "save_prelim_32.png");
            this.LargeImageCollection.Images.SetKeyName(14, "save_result_32.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Dominant Cysts";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnOK);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCancel);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 446);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(650, 25);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.tabControl);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 143);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(650, 303);
            this.clientPanel.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.tabMass;
            this.tabControl.Size = new System.Drawing.Size(650, 303);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabMass,
            this.tabCyst});
            // 
            // tabMass
            // 
            this.tabMass.Controls.Add(this.gcDominantMassList);
            this.tabMass.Name = "tabMass";
            this.tabMass.Size = new System.Drawing.Size(641, 272);
            this.tabMass.Text = "Mass";
            // 
            // gcDominantMassList
            // 
            this.gcDominantMassList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDominantMassList.Location = new System.Drawing.Point(0, 0);
            this.gcDominantMassList.MainView = this.gvDominantMass;
            this.gcDominantMassList.MenuManager = this.ribbon;
            this.gcDominantMassList.Name = "gcDominantMassList";
            this.gcDominantMassList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCbMassNo,
            this.repBtnDelete});
            this.gcDominantMassList.Size = new System.Drawing.Size(641, 272);
            this.gcDominantMassList.TabIndex = 1;
            this.gcDominantMassList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDominantMass});
            // 
            // gvDominantMass
            // 
            this.gvDominantMass.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMassNo,
            this.gcBreast,
            this.gcLocation,
            this.gcSize,
            this.gcDelete});
            this.gvDominantMass.GridControl = this.gcDominantMassList;
            this.gvDominantMass.Name = "gvDominantMass";
            this.gvDominantMass.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvDominantMass.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvDominantMass.OptionsView.ShowGroupPanel = false;
            // 
            // gcMassNo
            // 
            this.gcMassNo.Caption = "Mass No.";
            this.gcMassNo.ColumnEdit = this.repCbMassNo;
            this.gcMassNo.FieldName = "MASS_NO";
            this.gcMassNo.Name = "gcMassNo";
            this.gcMassNo.Visible = true;
            this.gcMassNo.VisibleIndex = 0;
            this.gcMassNo.Width = 57;
            // 
            // repCbMassNo
            // 
            this.repCbMassNo.AutoHeight = false;
            this.repCbMassNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCbMassNo.Name = "repCbMassNo";
            this.repCbMassNo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // gcBreast
            // 
            this.gcBreast.Caption = "Breast";
            this.gcBreast.FieldName = "BREAST_VIEW";
            this.gcBreast.Name = "gcBreast";
            this.gcBreast.OptionsColumn.AllowEdit = false;
            this.gcBreast.Visible = true;
            this.gcBreast.VisibleIndex = 1;
            this.gcBreast.Width = 164;
            // 
            // gcLocation
            // 
            this.gcLocation.Caption = "Clock Location";
            this.gcLocation.FieldName = "LOCATION";
            this.gcLocation.Name = "gcLocation";
            this.gcLocation.OptionsColumn.AllowEdit = false;
            this.gcLocation.Visible = true;
            this.gcLocation.VisibleIndex = 2;
            this.gcLocation.Width = 111;
            // 
            // gcSize
            // 
            this.gcSize.Caption = "Size";
            this.gcSize.FieldName = "SIZE";
            this.gcSize.Name = "gcSize";
            this.gcSize.OptionsColumn.AllowEdit = false;
            this.gcSize.Visible = true;
            this.gcSize.VisibleIndex = 3;
            this.gcSize.Width = 137;
            // 
            // gcDelete
            // 
            this.gcDelete.Caption = "Delete";
            this.gcDelete.ColumnEdit = this.repBtnDelete;
            this.gcDelete.Name = "gcDelete";
            this.gcDelete.Visible = true;
            this.gcDelete.VisibleIndex = 4;
            this.gcDelete.Width = 57;
            // 
            // repBtnDelete
            // 
            this.repBtnDelete.AutoHeight = false;
            this.repBtnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repBtnDelete.Name = "repBtnDelete";
            this.repBtnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // tabCyst
            // 
            this.tabCyst.Controls.Add(this.gcDominantCystList);
            this.tabCyst.Name = "tabCyst";
            this.tabCyst.Size = new System.Drawing.Size(641, 272);
            this.tabCyst.Text = "Cyst";
            // 
            // gcDominantCystList
            // 
            this.gcDominantCystList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDominantCystList.Location = new System.Drawing.Point(0, 0);
            this.gcDominantCystList.MainView = this.gvDominantCyst;
            this.gcDominantCystList.MenuManager = this.ribbon;
            this.gcDominantCystList.Name = "gcDominantCystList";
            this.gcDominantCystList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCombobox2,
            this.repDetele2});
            this.gcDominantCystList.Size = new System.Drawing.Size(641, 272);
            this.gcDominantCystList.TabIndex = 2;
            this.gcDominantCystList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDominantCyst});
            // 
            // gvDominantCyst
            // 
            this.gvDominantCyst.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMassNo2,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gcDelete2});
            this.gvDominantCyst.GridControl = this.gcDominantCystList;
            this.gvDominantCyst.Name = "gvDominantCyst";
            this.gvDominantCyst.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvDominantCyst.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvDominantCyst.OptionsView.ShowGroupPanel = false;
            // 
            // gcMassNo2
            // 
            this.gcMassNo2.Caption = "Mass No.";
            this.gcMassNo2.ColumnEdit = this.repCombobox2;
            this.gcMassNo2.FieldName = "MASS_NO";
            this.gcMassNo2.Name = "gcMassNo2";
            this.gcMassNo2.Visible = true;
            this.gcMassNo2.VisibleIndex = 0;
            this.gcMassNo2.Width = 57;
            // 
            // repCombobox2
            // 
            this.repCombobox2.AutoHeight = false;
            this.repCombobox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCombobox2.Name = "repCombobox2";
            this.repCombobox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Breast";
            this.gridColumn2.FieldName = "BREAST_VIEW";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 164;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Clock Location";
            this.gridColumn3.FieldName = "LOCATION";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 111;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Size";
            this.gridColumn4.FieldName = "SIZE";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 137;
            // 
            // gcDelete2
            // 
            this.gcDelete2.Caption = "Delete";
            this.gcDelete2.ColumnEdit = this.repDetele2;
            this.gcDelete2.Name = "gcDelete2";
            this.gcDelete2.Visible = true;
            this.gcDelete2.VisibleIndex = 4;
            this.gcDelete2.Width = 57;
            // 
            // repDetele2
            // 
            this.repDetele2.AutoHeight = false;
            this.repDetele2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repDetele2.Name = "repDetele2";
            this.repDetele2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // BiradDominantCystList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 471);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "BiradDominantCystList";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Dominant Cysts";
            ((System.ComponentModel.ISupportInitialize)(this.LargeImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabMass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDominantMassList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDominantMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCbMassNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnDelete)).EndInit();
            this.tabCyst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDominantCystList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDominantCyst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCombobox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDetele2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.Utils.ImageCollection LargeImageCollection;
        private DevExpress.XtraBars.BarButtonItem btnOK;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabMass;
        private DevExpress.XtraGrid.GridControl gcDominantMassList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDominantMass;
        private DevExpress.XtraGrid.Columns.GridColumn gcMassNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repCbMassNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcBreast;
        private DevExpress.XtraGrid.Columns.GridColumn gcLocation;
        private DevExpress.XtraGrid.Columns.GridColumn gcSize;
        private DevExpress.XtraGrid.Columns.GridColumn gcDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repBtnDelete;
        private DevExpress.XtraTab.XtraTabPage tabCyst;
        private DevExpress.XtraGrid.GridControl gcDominantCystList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDominantCyst;
        private DevExpress.XtraGrid.Columns.GridColumn gcMassNo2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repCombobox2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gcDelete2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repDetele2;
    }
}