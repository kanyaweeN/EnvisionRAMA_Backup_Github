namespace Envision.NET.Forms.Dialog
{
    partial class GroupEmpMessageConversation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupEmpMessageConversation));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.img16 = new DevExpress.Utils.ImageCollection(this.components);
            this.barBtnAddGroup = new DevExpress.XtraBars.BarButtonItem();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.grdGroupTech = new DevExpress.XtraGrid.GridControl();
            this.viewTech = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.img16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupTech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewTech)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbon.Images = this.img16;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnAddGroup});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageHeaderItemLinks.Add(this.barBtnAddGroup);
            this.ribbon.Size = new System.Drawing.Size(376, 48);
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // img16
            // 
            this.img16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("img16.ImageStream")));
            this.img16.Images.SetKeyName(0, "group_16.png");
            this.img16.Images.SetKeyName(1, "add_24.png");
            this.img16.Images.SetKeyName(2, "edit-add-16.png");
            // 
            // barBtnAddGroup
            // 
            this.barBtnAddGroup.Caption = "Add New group";
            this.barBtnAddGroup.Id = 8;
            this.barBtnAddGroup.ImageIndex = 2;
            this.barBtnAddGroup.Name = "barBtnAddGroup";
            toolTipTitleItem1.Text = "Group";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Add new group";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.barBtnAddGroup.SuperTip = superToolTip1;
            this.barBtnAddGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnAddGroup_ItemClick);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.btnOk);
            this.clientPanel.Controls.Add(this.grdGroupTech);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 48);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(376, 490);
            this.clientPanel.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(137, 445);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(89, 33);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grdGroupTech
            // 
            this.grdGroupTech.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdGroupTech.Location = new System.Drawing.Point(0, 0);
            this.grdGroupTech.MainView = this.viewTech;
            this.grdGroupTech.Name = "grdGroupTech";
            this.grdGroupTech.Size = new System.Drawing.Size(376, 438);
            this.grdGroupTech.TabIndex = 2;
            this.grdGroupTech.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewTech});
            this.grdGroupTech.DoubleClick += new System.EventHandler(this.grdGroupTech_DoubleClick);
            // 
            // viewTech
            // 
            this.viewTech.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.viewTech.GridControl = this.grdGroupTech;
            this.viewTech.Name = "viewTech";
            this.viewTech.OptionsBehavior.Editable = false;
            this.viewTech.OptionsView.ShowAutoFilterRow = true;
            this.viewTech.OptionsView.ShowDetailButtons = false;
            this.viewTech.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.viewTech.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.viewTech.OptionsView.ShowGroupPanel = false;
            this.viewTech.OptionsView.ShowHorzLines = false;
            this.viewTech.OptionsView.ShowIndicator = false;
            this.viewTech.OptionsView.ShowPreviewLines = false;
            this.viewTech.OptionsView.ShowVertLines = false;
            this.viewTech.PaintStyleName = "Web";
            this.viewTech.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.viewTech_CustomDrawGroupRow);
            this.viewTech.GroupRowCollapsing += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.viewTech_GroupRowCollapsing);
            this.viewTech.EndGrouping += new System.EventHandler(this.viewTech_EndGrouping);
            // 
            // GroupEmpMessageConversation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 538);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GroupEmpMessageConversation";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group";
            this.Load += new System.EventHandler(this.GroupEmpMessageConversation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupTech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewTech)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraGrid.GridControl grdGroupTech;
        private DevExpress.XtraGrid.Views.Grid.GridView viewTech;
        private DevExpress.Utils.ImageCollection img16;
        private DevExpress.XtraBars.BarButtonItem barBtnAddGroup;
    }
}