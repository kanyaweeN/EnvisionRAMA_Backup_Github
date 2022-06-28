namespace Envision.NET.Risk
{
    partial class RiskIncidentViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RiskIncidentViewerForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRiskCategory = new DevExpress.XtraBars.BarButtonItem();
            this.btnInvolvment = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbTask = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbRiskAndinvolvment = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbSaveAndCancel = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.icbPriority = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.imgWL = new System.Windows.Forms.ImageList(this.components);
            this.mmIncidentDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bteRiskCategory = new DevExpress.XtraEditors.ButtonEdit();
            this.tbIncidentSubject = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icbPriority.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmIncidentDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteRiskCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbIncidentSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::Envision.NET.Properties.Resources.Envision;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnRiskCategory,
            this.btnInvolvment,
            this.btnSave,
            this.btnCancel,
            this.btnClose});
            this.ribbon.LargeImages = this.imageCollection1;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.SelectedPage = this.ribbonPage1;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(670, 143);
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
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Id = 1;
            this.btnEdit.LargeImageIndex = 2;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Id = 2;
            this.btnDelete.LargeImageIndex = 4;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnRiskCategory
            // 
            this.btnRiskCategory.Caption = "Risk Category";
            this.btnRiskCategory.Id = 3;
            this.btnRiskCategory.LargeImageIndex = 9;
            this.btnRiskCategory.Name = "btnRiskCategory";
            this.btnRiskCategory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRiskCategory_ItemClick);
            // 
            // btnInvolvment
            // 
            this.btnInvolvment.Caption = "Involvement";
            this.btnInvolvment.Id = 4;
            this.btnInvolvment.LargeImageIndex = 8;
            this.btnInvolvment.Name = "btnInvolvment";
            this.btnInvolvment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInvolvment_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Id = 5;
            this.btnSave.LargeImageIndex = 6;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.Id = 6;
            this.btnCancel.LargeImageIndex = 5;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Id = 7;
            this.btnClose.LargeImageIndex = 1;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
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
            this.imageCollection1.Images.SetKeyName(8, "demographic.png");
            this.imageCollection1.Images.SetKeyName(9, "risk_icon.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbTask,
            this.rbRiskAndinvolvment,
            this.rbSaveAndCancel,
            this.rbClose});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Incident";
            // 
            // rbTask
            // 
            this.rbTask.ItemLinks.Add(this.btnAdd);
            this.rbTask.ItemLinks.Add(this.btnEdit);
            this.rbTask.ItemLinks.Add(this.btnDelete);
            this.rbTask.Name = "rbTask";
            this.rbTask.ShowCaptionButton = false;
            // 
            // rbRiskAndinvolvment
            // 
            this.rbRiskAndinvolvment.ItemLinks.Add(this.btnRiskCategory);
            this.rbRiskAndinvolvment.ItemLinks.Add(this.btnInvolvment);
            this.rbRiskAndinvolvment.Name = "rbRiskAndinvolvment";
            this.rbRiskAndinvolvment.ShowCaptionButton = false;
            // 
            // rbSaveAndCancel
            // 
            this.rbSaveAndCancel.ItemLinks.Add(this.btnSave);
            this.rbSaveAndCancel.ItemLinks.Add(this.btnCancel);
            this.rbSaveAndCancel.Name = "rbSaveAndCancel";
            this.rbSaveAndCancel.ShowCaptionButton = false;
            // 
            // rbClose
            // 
            this.rbClose.ItemLinks.Add(this.btnClose);
            this.rbClose.Name = "rbClose";
            this.rbClose.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 486);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(670, 25);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.layoutControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 143);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(670, 343);
            this.clientPanel.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.icbPriority);
            this.layoutControl1.Controls.Add(this.mmIncidentDescription);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.bteRiskCategory);
            this.layoutControl1.Controls.Add(this.tbIncidentSubject);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(670, 343);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // icbPriority
            // 
            this.icbPriority.EditValue = "M";
            this.icbPriority.Location = new System.Drawing.Point(584, 32);
            this.icbPriority.MenuManager = this.ribbon;
            this.icbPriority.Name = "icbPriority";
            this.icbPriority.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbPriority.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Low", "L", 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Medium", "M", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("High", "H", 8)});
            this.icbPriority.Properties.SmallImages = this.imgWL;
            this.icbPriority.Size = new System.Drawing.Size(83, 20);
            this.icbPriority.StyleController = this.layoutControl1;
            this.icbPriority.TabIndex = 9;
            // 
            // imgWL
            // 
            this.imgWL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgWL.ImageStream")));
            this.imgWL.TransparentColor = System.Drawing.Color.Magenta;
            this.imgWL.Images.SetKeyName(0, "");
            this.imgWL.Images.SetKeyName(1, "");
            this.imgWL.Images.SetKeyName(2, "");
            this.imgWL.Images.SetKeyName(3, "");
            this.imgWL.Images.SetKeyName(4, "");
            this.imgWL.Images.SetKeyName(5, "");
            this.imgWL.Images.SetKeyName(6, "");
            this.imgWL.Images.SetKeyName(7, "");
            this.imgWL.Images.SetKeyName(8, "");
            // 
            // mmIncidentDescription
            // 
            this.mmIncidentDescription.Location = new System.Drawing.Point(5, 81);
            this.mmIncidentDescription.MenuManager = this.ribbon;
            this.mmIncidentDescription.Name = "mmIncidentDescription";
            this.mmIncidentDescription.Size = new System.Drawing.Size(662, 258);
            this.mmIncidentDescription.StyleController = this.layoutControl1;
            this.mmIncidentDescription.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(7, 60);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(114, 13);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Incident Description";
            // 
            // bteRiskCategory
            // 
            this.bteRiskCategory.Location = new System.Drawing.Point(91, 32);
            this.bteRiskCategory.MenuManager = this.ribbon;
            this.bteRiskCategory.Name = "bteRiskCategory";
            this.bteRiskCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteRiskCategory.Size = new System.Drawing.Size(430, 20);
            this.bteRiskCategory.StyleController = this.layoutControl1;
            this.bteRiskCategory.TabIndex = 6;
            this.bteRiskCategory.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteRiskCategory_ButtonClick);
            // 
            // tbIncidentSubject
            // 
            this.tbIncidentSubject.Location = new System.Drawing.Point(91, 4);
            this.tbIncidentSubject.MenuManager = this.ribbon;
            this.tbIncidentSubject.Name = "tbIncidentSubject";
            this.tbIncidentSubject.Size = new System.Drawing.Size(576, 20);
            this.tbIncidentSubject.StyleController = this.layoutControl1;
            this.tbIncidentSubject.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(670, 343);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.tbIncidentSubject;
            this.layoutControlItem2.CustomizationFormText = "Incident Subject";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 5);
            this.layoutControlItem2.Size = new System.Drawing.Size(668, 28);
            this.layoutControlItem2.Text = "Subject";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.bteRiskCategory;
            this.layoutControlItem3.CustomizationFormText = "Risk Category";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 5);
            this.layoutControlItem3.Size = new System.Drawing.Size(522, 28);
            this.layoutControlItem3.Text = "Risk Category";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.labelControl1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 5);
            this.layoutControlItem4.Size = new System.Drawing.Size(668, 21);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.mmIncidentDescription;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 77);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 2, 2, 3);
            this.layoutControlItem5.Size = new System.Drawing.Size(668, 264);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.icbPriority;
            this.layoutControlItem1.CustomizationFormText = "Priority";
            this.layoutControlItem1.Location = new System.Drawing.Point(522, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(146, 28);
            this.layoutControlItem1.Text = "Priority";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 20);
            // 
            // RiskIncidentViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 511);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "RiskIncidentViewerForm";
            this.Ribbon = this.ribbon;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Risk Incident";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icbPriority.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmIncidentDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteRiskCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbIncidentSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbTask;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbRiskAndinvolvment;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbSaveAndCancel;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbClose;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRiskCategory;
        private DevExpress.XtraBars.BarButtonItem btnInvolvment;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit tbIncidentSubject;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.MemoEdit mmIncidentDescription;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit bteRiskCategory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbPriority;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.ImageList imgWL;
    }
}