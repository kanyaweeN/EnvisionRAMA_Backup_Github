namespace Envision.NET.Forms.Admin
{
    partial class frmHrUnitSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHrUnitSetup));
            this.gv_GetData = new DevExpress.XtraGrid.GridControl();
            this.view_GetData = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.panel_Insert = new DevExpress.XtraEditors.PanelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtUnitAlias = new DevExpress.XtraEditors.TextEdit();
            this.btn_Cancle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_OKUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Browse = new DevExpress.XtraEditors.SimpleButton();
            this.txt_BrowseExcel = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_UNIT_NAME_ALIAS = new DevExpress.XtraEditors.TextEdit();
            this.txt_PHONE_NO = new DevExpress.XtraEditors.TextEdit();
            this.txt_LOC = new DevExpress.XtraEditors.TextEdit();
            this.txt_LOC_ALIAS = new DevExpress.XtraEditors.TextEdit();
            this.txt_UNIT_NAME = new DevExpress.XtraEditors.TextEdit();
            this.txt_UNIT_PARENT_NAME = new DevExpress.XtraEditors.TextEdit();
            this.txt_DESCR = new DevExpress.XtraEditors.TextEdit();
            this.txt_UNIT_UID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_New = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Save = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.rb_UnitSetup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.gv_GetData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_GetData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Insert)).BeginInit();
            this.panel_Insert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitAlias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BrowseExcel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UNIT_NAME_ALIAS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PHONE_NO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LOC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LOC_ALIAS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UNIT_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UNIT_PARENT_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DESCR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UNIT_UID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_GetData
            // 
            this.gv_GetData.Location = new System.Drawing.Point(7, 40);
            this.gv_GetData.MainView = this.view_GetData;
            this.gv_GetData.Name = "gv_GetData";
            this.gv_GetData.Size = new System.Drawing.Size(813, 283);
            this.gv_GetData.TabIndex = 2;
            this.gv_GetData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_GetData});
            // 
            // view_GetData
            // 
            this.view_GetData.Appearance.BandPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.view_GetData.Appearance.BandPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.view_GetData.Appearance.BandPanel.ForeColor = System.Drawing.Color.Black;
            this.view_GetData.Appearance.BandPanel.Options.UseBackColor = true;
            this.view_GetData.Appearance.BandPanel.Options.UseBorderColor = true;
            this.view_GetData.Appearance.BandPanel.Options.UseForeColor = true;
            this.view_GetData.Appearance.BandPanelBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.view_GetData.Appearance.BandPanelBackground.BackColor2 = System.Drawing.Color.White;
            this.view_GetData.Appearance.BandPanelBackground.Options.UseBackColor = true;
            this.view_GetData.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.view_GetData.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.view_GetData.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.view_GetData.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.view_GetData.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.view_GetData.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.view_GetData.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.view_GetData.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.view_GetData.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.view_GetData.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.view_GetData.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.view_GetData.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.view_GetData.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.view_GetData.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.view_GetData.Appearance.Empty.Options.UseBackColor = true;
            this.view_GetData.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.view_GetData.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.view_GetData.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.view_GetData.Appearance.EvenRow.Options.UseBackColor = true;
            this.view_GetData.Appearance.EvenRow.Options.UseBorderColor = true;
            this.view_GetData.Appearance.EvenRow.Options.UseForeColor = true;
            this.view_GetData.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.view_GetData.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.view_GetData.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.view_GetData.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.view_GetData.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.view_GetData.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.view_GetData.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.view_GetData.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.view_GetData.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.view_GetData.Appearance.FilterPanel.Options.UseBackColor = true;
            this.view_GetData.Appearance.FilterPanel.Options.UseForeColor = true;
            this.view_GetData.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.view_GetData.Appearance.FixedLine.Options.UseBackColor = true;
            this.view_GetData.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.view_GetData.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.view_GetData.Appearance.FocusedCell.Options.UseBackColor = true;
            this.view_GetData.Appearance.FocusedCell.Options.UseForeColor = true;
            this.view_GetData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.view_GetData.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.view_GetData.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.view_GetData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.view_GetData.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.view_GetData.Appearance.FocusedRow.Options.UseForeColor = true;
            this.view_GetData.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.view_GetData.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.view_GetData.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.view_GetData.Appearance.FooterPanel.Options.UseBackColor = true;
            this.view_GetData.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.view_GetData.Appearance.FooterPanel.Options.UseForeColor = true;
            this.view_GetData.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.view_GetData.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.view_GetData.Appearance.GroupButton.Options.UseBackColor = true;
            this.view_GetData.Appearance.GroupButton.Options.UseBorderColor = true;
            this.view_GetData.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.view_GetData.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.view_GetData.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.view_GetData.Appearance.GroupFooter.Options.UseBackColor = true;
            this.view_GetData.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.view_GetData.Appearance.GroupFooter.Options.UseForeColor = true;
            this.view_GetData.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.view_GetData.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.view_GetData.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.view_GetData.Appearance.GroupPanel.Options.UseBackColor = true;
            this.view_GetData.Appearance.GroupPanel.Options.UseForeColor = true;
            this.view_GetData.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.view_GetData.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.view_GetData.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.view_GetData.Appearance.GroupRow.Options.UseBackColor = true;
            this.view_GetData.Appearance.GroupRow.Options.UseBorderColor = true;
            this.view_GetData.Appearance.GroupRow.Options.UseForeColor = true;
            this.view_GetData.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.view_GetData.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.view_GetData.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.view_GetData.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.view_GetData.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.view_GetData.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.view_GetData.Appearance.HeaderPanelBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.view_GetData.Appearance.HeaderPanelBackground.BackColor2 = System.Drawing.Color.White;
            this.view_GetData.Appearance.HeaderPanelBackground.Options.UseBackColor = true;
            this.view_GetData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.view_GetData.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.view_GetData.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.view_GetData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.view_GetData.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.view_GetData.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.view_GetData.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.view_GetData.Appearance.HorzLine.Options.UseBackColor = true;
            this.view_GetData.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.view_GetData.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.view_GetData.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.view_GetData.Appearance.OddRow.Options.UseBackColor = true;
            this.view_GetData.Appearance.OddRow.Options.UseBorderColor = true;
            this.view_GetData.Appearance.OddRow.Options.UseForeColor = true;
            this.view_GetData.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.view_GetData.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.view_GetData.Appearance.Preview.Options.UseFont = true;
            this.view_GetData.Appearance.Preview.Options.UseForeColor = true;
            this.view_GetData.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.view_GetData.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.view_GetData.Appearance.Row.Options.UseBackColor = true;
            this.view_GetData.Appearance.Row.Options.UseForeColor = true;
            this.view_GetData.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.view_GetData.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.view_GetData.Appearance.RowSeparator.Options.UseBackColor = true;
            this.view_GetData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.view_GetData.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.view_GetData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.view_GetData.Appearance.SelectedRow.Options.UseForeColor = true;
            this.view_GetData.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.view_GetData.Appearance.TopNewRow.Options.UseBackColor = true;
            this.view_GetData.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.view_GetData.Appearance.VertLine.Options.UseBackColor = true;
            this.view_GetData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.view_GetData.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.view_GetData.GridControl = this.gv_GetData;
            this.view_GetData.Name = "view_GetData";
            this.view_GetData.OptionsBehavior.Editable = false;
            this.view_GetData.OptionsView.ColumnAutoWidth = true;
            this.view_GetData.OptionsView.EnableAppearanceEvenRow = true;
            this.view_GetData.OptionsView.EnableAppearanceOddRow = true;
            this.view_GetData.OptionsView.ShowAutoFilterRow = true;
            this.view_GetData.OptionsView.ShowBands = false;
            this.view_GetData.PaintStyleName = "(Default)";
            this.view_GetData.Click += new System.EventHandler(this.view_GetData_Click);
            this.view_GetData.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.view_GetData_RowUpdated);
            this.view_GetData.DoubleClick += new System.EventHandler(this.view_GetData_DoubleClick);
            // 
            // gridBand1
            // 
            this.gridBand1.Name = "gridBand1";
            // 
            // panel_Insert
            // 
            this.panel_Insert.Controls.Add(this.labelControl9);
            this.panel_Insert.Controls.Add(this.txtUnitAlias);
            this.panel_Insert.Controls.Add(this.btn_Cancle);
            this.panel_Insert.Controls.Add(this.btn_OKUpdate);
            this.panel_Insert.Controls.Add(this.labelControl7);
            this.panel_Insert.Controls.Add(this.labelControl5);
            this.panel_Insert.Controls.Add(this.labelControl4);
            this.panel_Insert.Controls.Add(this.labelControl8);
            this.panel_Insert.Controls.Add(this.labelControl3);
            this.panel_Insert.Controls.Add(this.labelControl6);
            this.panel_Insert.Controls.Add(this.labelControl2);
            this.panel_Insert.Controls.Add(this.txt_UNIT_NAME_ALIAS);
            this.panel_Insert.Controls.Add(this.txt_PHONE_NO);
            this.panel_Insert.Controls.Add(this.txt_LOC);
            this.panel_Insert.Controls.Add(this.txt_LOC_ALIAS);
            this.panel_Insert.Controls.Add(this.txt_UNIT_NAME);
            this.panel_Insert.Controls.Add(this.txt_UNIT_PARENT_NAME);
            this.panel_Insert.Controls.Add(this.txt_DESCR);
            this.panel_Insert.Controls.Add(this.txt_UNIT_UID);
            this.panel_Insert.Controls.Add(this.labelControl1);
            this.panel_Insert.Enabled = false;
            this.panel_Insert.Location = new System.Drawing.Point(7, 334);
            this.panel_Insert.Name = "panel_Insert";
            this.panel_Insert.Size = new System.Drawing.Size(813, 204);
            this.panel_Insert.TabIndex = 2;
            this.panel_Insert.Visible = false;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(22, 60);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(47, 13);
            this.labelControl9.TabIndex = 8;
            this.labelControl9.Text = "Unit Alias ";
            // 
            // txtUnitAlias
            // 
            this.txtUnitAlias.Location = new System.Drawing.Point(75, 57);
            this.txtUnitAlias.Name = "txtUnitAlias";
            this.txtUnitAlias.Size = new System.Drawing.Size(243, 20);
            this.txtUnitAlias.TabIndex = 7;
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.Location = new System.Drawing.Point(418, 146);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(90, 38);
            this.btn_Cancle.TabIndex = 5;
            this.btn_Cancle.Text = "Cancle";
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // btn_OKUpdate
            // 
            this.btn_OKUpdate.Location = new System.Drawing.Point(322, 146);
            this.btn_OKUpdate.Name = "btn_OKUpdate";
            this.btn_OKUpdate.Size = new System.Drawing.Size(90, 38);
            this.btn_OKUpdate.StyleController = this.layoutControl1;
            this.btn_OKUpdate.TabIndex = 5;
            this.btn_OKUpdate.Text = "Update";
            this.btn_OKUpdate.Click += new System.EventHandler(this.btn_OKUpdate_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.btn_Browse);
            this.layoutControl1.Controls.Add(this.panel_Insert);
            this.layoutControl1.Controls.Add(this.txt_BrowseExcel);
            this.layoutControl1.Controls.Add(this.gv_GetData);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 95);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(826, 544);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(753, 7);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(67, 22);
            this.btn_Browse.StyleController = this.layoutControl1;
            this.btn_Browse.TabIndex = 21;
            this.btn_Browse.Text = "Browse...";
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // txt_BrowseExcel
            // 
            this.txt_BrowseExcel.Location = new System.Drawing.Point(87, 7);
            this.txt_BrowseExcel.Name = "txt_BrowseExcel";
            this.txt_BrowseExcel.Size = new System.Drawing.Size(655, 20);
            this.txt_BrowseExcel.StyleController = this.layoutControl1;
            this.txt_BrowseExcel.TabIndex = 20;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(826, 544);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gv_GetData;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 33);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(824, 294);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_BrowseExcel;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(746, 33);
            this.layoutControlItem2.Text = "Browe for Excel";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(75, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_Browse;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(746, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(78, 33);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.panel_Insert;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 327);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(824, 215);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(489, 34);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(57, 13);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Parent Alias";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(37, 86);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(30, 13);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Phone";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(20, 34);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(49, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Unit Name";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(484, 90);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(62, 13);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "LocationAlise";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(487, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "ParentName";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(16, 112);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(53, 13);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Description";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(506, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Location";
            // 
            // txt_UNIT_NAME_ALIAS
            // 
            this.txt_UNIT_NAME_ALIAS.Location = new System.Drawing.Point(552, 31);
            this.txt_UNIT_NAME_ALIAS.Name = "txt_UNIT_NAME_ALIAS";
            this.txt_UNIT_NAME_ALIAS.Size = new System.Drawing.Size(178, 20);
            this.txt_UNIT_NAME_ALIAS.TabIndex = 2;
            // 
            // txt_PHONE_NO
            // 
            this.txt_PHONE_NO.Location = new System.Drawing.Point(75, 83);
            this.txt_PHONE_NO.Name = "txt_PHONE_NO";
            this.txt_PHONE_NO.Size = new System.Drawing.Size(143, 20);
            this.txt_PHONE_NO.TabIndex = 4;
            // 
            // txt_LOC
            // 
            this.txt_LOC.Location = new System.Drawing.Point(552, 61);
            this.txt_LOC.Name = "txt_LOC";
            this.txt_LOC.Size = new System.Drawing.Size(208, 20);
            this.txt_LOC.TabIndex = 5;
            // 
            // txt_LOC_ALIAS
            // 
            this.txt_LOC_ALIAS.Location = new System.Drawing.Point(552, 87);
            this.txt_LOC_ALIAS.Name = "txt_LOC_ALIAS";
            this.txt_LOC_ALIAS.Size = new System.Drawing.Size(181, 20);
            this.txt_LOC_ALIAS.TabIndex = 5;
            // 
            // txt_UNIT_NAME
            // 
            this.txt_UNIT_NAME.Location = new System.Drawing.Point(75, 31);
            this.txt_UNIT_NAME.Name = "txt_UNIT_NAME";
            this.txt_UNIT_NAME.Size = new System.Drawing.Size(243, 20);
            this.txt_UNIT_NAME.TabIndex = 1;
            // 
            // txt_UNIT_PARENT_NAME
            // 
            this.txt_UNIT_PARENT_NAME.Location = new System.Drawing.Point(552, 5);
            this.txt_UNIT_PARENT_NAME.Name = "txt_UNIT_PARENT_NAME";
            this.txt_UNIT_PARENT_NAME.Size = new System.Drawing.Size(166, 20);
            this.txt_UNIT_PARENT_NAME.TabIndex = 6;
            // 
            // txt_DESCR
            // 
            this.txt_DESCR.Location = new System.Drawing.Point(75, 109);
            this.txt_DESCR.Name = "txt_DESCR";
            this.txt_DESCR.Size = new System.Drawing.Size(387, 20);
            this.txt_DESCR.TabIndex = 3;
            // 
            // txt_UNIT_UID
            // 
            this.txt_UNIT_UID.Location = new System.Drawing.Point(75, 5);
            this.txt_UNIT_UID.Name = "txt_UNIT_UID";
            this.txt_UNIT_UID.Size = new System.Drawing.Size(181, 20);
            this.txt_UNIT_UID.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Unit Code";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(48, 48);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "delete.png");
            this.imageCollection1.Images.SetKeyName(1, "exit32.png");
            this.imageCollection1.Images.SetKeyName(2, "add_48.png");
            this.imageCollection1.Images.SetKeyName(3, "saveLarge.png");
            this.imageCollection1.Images.SetKeyName(4, "thumb_Recycle_Bin.png");
            this.imageCollection1.Images.SetKeyName(5, "blue-recycle-bin-icon.png");
            this.imageCollection1.Images.SetKeyName(6, "Recycle-Bin-icon.png");
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowMinimize = false;
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = null;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_New,
            this.btn_Save,
            this.btn_Delete});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 10;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.SelectedPage = this.ribbonPage1;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(826, 95);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btn_New
            // 
            this.btn_New.Caption = "New";
            this.btn_New.Id = 0;
            this.btn_New.LargeImageIndex = 2;
            this.btn_New.LargeWidth = 100;
            this.btn_New.Name = "btn_New";
            this.btn_New.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_New_ItemClick);
            // 
            // btn_Save
            // 
            this.btn_Save.Caption = "Save";
            this.btn_Save.Id = 8;
            this.btn_Save.LargeImageIndex = 3;
            this.btn_Save.LargeWidth = 100;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Save_ItemClick);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Caption = "Delete";
            this.btn_Delete.Id = 9;
            this.btn_Delete.LargeImageIndex = 6;
            this.btn_Delete.LargeWidth = 100;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Delete_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btn_New);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btn_Save);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btn_Delete);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItemNew";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.LargeImageIndex = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // rb_UnitSetup
            // 
            this.rb_UnitSetup.ItemLinks.Add(this.btn_New);
            this.rb_UnitSetup.Name = "rb_UnitSetup";
            // 
            // frmHrUnitSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 639);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmHrUnitSetup";
            this.Text = "frmHrUnitSetup";
            this.Load += new System.EventHandler(this.frmHrUnitSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_GetData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_GetData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Insert)).EndInit();
            this.panel_Insert.ResumeLayout(false);
            this.panel_Insert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitAlias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_BrowseExcel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UNIT_NAME_ALIAS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PHONE_NO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LOC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LOC_ALIAS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UNIT_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UNIT_PARENT_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DESCR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UNIT_UID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gv_GetData;
        private DevExpress.XtraEditors.PanelControl panel_Insert;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_UNIT_UID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_DESCR;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_PHONE_NO;
        private DevExpress.XtraEditors.TextEdit txt_UNIT_NAME;
        private DevExpress.XtraEditors.TextEdit txt_UNIT_PARENT_NAME;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txt_UNIT_NAME_ALIAS;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txt_LOC_ALIAS;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.TextEdit txt_BrowseExcel;
        private DevExpress.XtraEditors.SimpleButton btn_Browse;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btn_New;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView view_GetData;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraEditors.SimpleButton btn_OKUpdate;
        private DevExpress.XtraEditors.SimpleButton btn_Cancle;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rb_UnitSetup;
        private DevExpress.XtraBars.BarButtonItem btn_Save;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txt_LOC;
        private DevExpress.XtraBars.BarButtonItem btn_Delete;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtUnitAlias;


    }
}