namespace Envision.NET.Forms.Dialog
{
    partial class dlgAddEmpToGroupMessageConversation
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.grdGroupMessage = new DevExpress.XtraGrid.GridControl();
            this.viewGroupMessage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.laGrName = new DevExpress.XtraEditors.LabelControl();
            this.laGrDesc = new DevExpress.XtraEditors.LabelControl();
            this.laGrTag = new DevExpress.XtraEditors.LabelControl();
            this.txtTag = new DevExpress.XtraEditors.TextEdit();
            this.txtDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.laStar = new DevExpress.XtraEditors.LabelControl();
            this.btnDeleteGroup = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewGroupMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Name = "ribbon";
            this.ribbon.Size = new System.Drawing.Size(366, 48);
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.grdGroupMessage);
            this.clientPanel.Location = new System.Drawing.Point(3, 104);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(357, 407);
            this.clientPanel.TabIndex = 2;
            // 
            // grdGroupMessage
            // 
            this.grdGroupMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGroupMessage.Location = new System.Drawing.Point(0, 0);
            this.grdGroupMessage.MainView = this.viewGroupMessage;
            this.grdGroupMessage.MenuManager = this.ribbon;
            this.grdGroupMessage.Name = "grdGroupMessage";
            this.grdGroupMessage.Size = new System.Drawing.Size(357, 407);
            this.grdGroupMessage.TabIndex = 8;
            this.grdGroupMessage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewGroupMessage});
            // 
            // viewGroupMessage
            // 
            this.viewGroupMessage.Appearance.GroupRow.Options.UseTextOptions = true;
            this.viewGroupMessage.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewGroupMessage.GridControl = this.grdGroupMessage;
            this.viewGroupMessage.GroupFormat = "{1} {2}";
            this.viewGroupMessage.Name = "viewGroupMessage";
            this.viewGroupMessage.OptionsCustomization.AllowFilter = false;
            this.viewGroupMessage.OptionsLayout.Columns.AddNewColumns = false;
            this.viewGroupMessage.OptionsLayout.Columns.RemoveOldColumns = false;
            this.viewGroupMessage.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewGroupMessage.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.viewGroupMessage.OptionsView.RowAutoHeight = true;
            this.viewGroupMessage.OptionsView.ShowAutoFilterRow = true;
            this.viewGroupMessage.OptionsView.ShowColumnHeaders = false;
            this.viewGroupMessage.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.viewGroupMessage.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.viewGroupMessage.OptionsView.ShowGroupPanel = false;
            this.viewGroupMessage.OptionsView.ShowHorzLines = false;
            this.viewGroupMessage.OptionsView.ShowIndicator = false;
            this.viewGroupMessage.OptionsView.ShowPreviewLines = false;
            this.viewGroupMessage.OptionsView.ShowVertLines = false;
            this.viewGroupMessage.PaintStyleName = "Web";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(80, 517);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 32);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // laGrName
            // 
            this.laGrName.Location = new System.Drawing.Point(7, 55);
            this.laGrName.Name = "laGrName";
            this.laGrName.Size = new System.Drawing.Size(59, 13);
            this.laGrName.TabIndex = 12;
            this.laGrName.Text = "Group Name";
            // 
            // laGrDesc
            // 
            this.laGrDesc.Location = new System.Drawing.Point(13, 81);
            this.laGrDesc.Name = "laGrDesc";
            this.laGrDesc.Size = new System.Drawing.Size(53, 13);
            this.laGrDesc.TabIndex = 13;
            this.laGrDesc.Text = "Description";
            // 
            // laGrTag
            // 
            this.laGrTag.Location = new System.Drawing.Point(237, 55);
            this.laGrTag.Name = "laGrTag";
            this.laGrTag.Size = new System.Drawing.Size(18, 13);
            this.laGrTag.TabIndex = 14;
            this.laGrTag.Text = "Tag";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(261, 52);
            this.txtTag.MenuManager = this.ribbon;
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(96, 20);
            this.txtTag.TabIndex = 15;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(72, 78);
            this.txtDesc.MenuManager = this.ribbon;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(285, 20);
            this.txtDesc.TabIndex = 16;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(72, 52);
            this.txtName.MenuManager = this.ribbon;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(146, 20);
            this.txtName.TabIndex = 17;
            this.txtName.EditValueChanged += new System.EventHandler(this.txtName_EditValueChanged);
            // 
            // laStar
            // 
            this.laStar.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laStar.Appearance.ForeColor = System.Drawing.Color.Red;
            this.laStar.Appearance.Options.UseFont = true;
            this.laStar.Appearance.Options.UseForeColor = true;
            this.laStar.Location = new System.Drawing.Point(219, 55);
            this.laStar.Name = "laStar";
            this.laStar.Size = new System.Drawing.Size(10, 18);
            this.laStar.TabIndex = 19;
            this.laStar.Text = "*";
            this.laStar.Visible = false;
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Location = new System.Drawing.Point(180, 517);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(94, 32);
            this.btnDeleteGroup.TabIndex = 21;
            this.btnDeleteGroup.Text = "Delete";
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // dlgAddEmpToGroupMessageConversation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 555);
            this.Controls.Add(this.btnDeleteGroup);
            this.Controls.Add(this.laStar);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.laGrTag);
            this.Controls.Add(this.laGrDesc);
            this.Controls.Add(this.laGrName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgAddEmpToGroupMessageConversation";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Emp To Group";
            this.Load += new System.EventHandler(this.dlgAddEmpToGroupMessageConversation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewGroupMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraGrid.GridControl grdGroupMessage;
        private DevExpress.XtraGrid.Views.Grid.GridView viewGroupMessage;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl laGrName;
        private DevExpress.XtraEditors.LabelControl laGrDesc;
        private DevExpress.XtraEditors.LabelControl laGrTag;
        private DevExpress.XtraEditors.TextEdit txtTag;
        private DevExpress.XtraEditors.TextEdit txtDesc;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl laStar;
        private DevExpress.XtraEditors.SimpleButton btnDeleteGroup;
    }
}