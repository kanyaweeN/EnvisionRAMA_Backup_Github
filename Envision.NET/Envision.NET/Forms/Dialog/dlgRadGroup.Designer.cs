namespace Envision.NET.Forms.Dialog
{
    partial class dlgRadGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgRadGroup));
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.laGrName = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grdPrRadGroup = new DevExpress.XtraGrid.GridControl();
            this.viewPrRadGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.img16 = new DevExpress.Utils.ImageCollection(this.components);
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnDeleteGroup = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrRadGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewPrRadGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.dxErrorProvider1.SetIconAlignment(this.txtName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtName.Location = new System.Drawing.Point(73, 58);
            this.txtName.MenuManager = this.ribbon;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(271, 20);
            this.txtName.TabIndex = 29;
            this.txtName.EditValueChanged += new System.EventHandler(this.txtName_EditValueChanged);
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Name = "ribbon";
            this.ribbon.Size = new System.Drawing.Size(372, 48);
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // laGrName
            // 
            this.laGrName.Location = new System.Drawing.Point(8, 61);
            this.laGrName.Name = "laGrName";
            this.laGrName.Size = new System.Drawing.Size(59, 13);
            this.laGrName.TabIndex = 24;
            this.laGrName.Text = "Group Name";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.grdPrRadGroup);
            this.panelControl1.Location = new System.Drawing.Point(4, 84);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(357, 407);
            this.panelControl1.TabIndex = 22;
            // 
            // grdPrRadGroup
            // 
            this.grdPrRadGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPrRadGroup.Location = new System.Drawing.Point(0, 0);
            this.grdPrRadGroup.MainView = this.viewPrRadGroup;
            this.grdPrRadGroup.MenuManager = this.ribbon;
            this.grdPrRadGroup.Name = "grdPrRadGroup";
            this.grdPrRadGroup.Size = new System.Drawing.Size(357, 407);
            this.grdPrRadGroup.TabIndex = 8;
            this.grdPrRadGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewPrRadGroup});
            // 
            // viewPrRadGroup
            // 
            this.viewPrRadGroup.Appearance.GroupRow.Options.UseTextOptions = true;
            this.viewPrRadGroup.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewPrRadGroup.GridControl = this.grdPrRadGroup;
            this.viewPrRadGroup.GroupFormat = "{1} {2}";
            this.viewPrRadGroup.Name = "viewPrRadGroup";
            this.viewPrRadGroup.OptionsCustomization.AllowFilter = false;
            this.viewPrRadGroup.OptionsLayout.Columns.AddNewColumns = false;
            this.viewPrRadGroup.OptionsLayout.Columns.RemoveOldColumns = false;
            this.viewPrRadGroup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewPrRadGroup.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.viewPrRadGroup.OptionsView.RowAutoHeight = true;
            this.viewPrRadGroup.OptionsView.ShowAutoFilterRow = true;
            this.viewPrRadGroup.OptionsView.ShowColumnHeaders = false;
            this.viewPrRadGroup.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.viewPrRadGroup.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.viewPrRadGroup.OptionsView.ShowGroupPanel = false;
            this.viewPrRadGroup.OptionsView.ShowHorzLines = false;
            this.viewPrRadGroup.OptionsView.ShowIndicator = false;
            this.viewPrRadGroup.OptionsView.ShowPreviewLines = false;
            this.viewPrRadGroup.OptionsView.ShowVertLines = false;
            this.viewPrRadGroup.PaintStyleName = "Web";
            // 
            // img16
            // 
            this.img16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("img16.ImageStream")));
            this.img16.Images.SetKeyName(0, "browse_16.png");
            this.img16.Images.SetKeyName(1, "activity.gif");
            this.img16.Images.SetKeyName(2, "group_16.png");
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "browse_16.png");
            this.imageCollection1.Images.SetKeyName(1, "activity.gif");
            this.imageCollection1.Images.SetKeyName(2, "group_16.png");
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Location = new System.Drawing.Point(184, 523);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(94, 32);
            this.btnDeleteGroup.TabIndex = 32;
            this.btnDeleteGroup.Text = "Delete";
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(84, 523);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 32);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // dlgRadGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 561);
            this.Controls.Add(this.btnDeleteGroup);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.laGrName);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgRadGroup";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rad Group";
            this.Load += new System.EventHandler(this.dlgRadGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPrRadGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewPrRadGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.ImageCollection img16;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl laGrName;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdPrRadGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView viewPrRadGroup;
        private DevExpress.XtraEditors.SimpleButton btnDeleteGroup;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}