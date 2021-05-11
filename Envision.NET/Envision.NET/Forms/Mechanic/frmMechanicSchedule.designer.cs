namespace Envision.NET.Forms.Mechanic
{
    partial class frmMechanicSchedule
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
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMechanicSchedule));
            this.scControl = new DevExpress.XtraScheduler.SchedulerControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.viewSelectorItem1 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem2 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem3 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem4 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem5 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.btnCheckTime = new DevExpress.XtraBars.BarCheckItem();
            this.txtShowPeriod = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.btnShowVisible = new DevExpress.XtraBars.BarCheckItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.viewSelectorRibbonPage1 = new DevExpress.XtraScheduler.UI.ViewSelectorRibbonPage();
            this.viewSelectorRibbonPageGroup1 = new DevExpress.XtraScheduler.UI.ViewSelectorRibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.dateNav = new DevExpress.XtraScheduler.DateNavigator();
            this.chkList = new DevExpress.XtraScheduler.UI.ResourcesCheckedListBoxControl();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.ribbonViewSelector1 = new DevExpress.XtraScheduler.UI.RibbonViewSelector(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.xtraGridBlending1 = new DevExpress.XtraGrid.Blending.XtraGridBlending();
            this.ImgSession = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.scControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewSelector1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgSession)).BeginInit();
            this.SuspendLayout();
            // 
            // scControl
            // 
            this.scControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scControl.Location = new System.Drawing.Point(182, 101);
            this.scControl.MenuManager = this.ribbonControl1;
            this.scControl.Name = "scControl";
            this.scControl.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.scControl.Size = new System.Drawing.Size(654, 523);
            this.scControl.Start = new System.DateTime(2009, 2, 18, 0, 0, 0, 0);
            this.scControl.Storage = this.schedulerStorage1;
            this.scControl.TabIndex = 4;
            this.scControl.Text = "schedulerControl1";
            this.scControl.Views.DayView.TimeRulers.Add(timeRuler1);
            this.scControl.Views.DayView.TimeScale = System.TimeSpan.Parse("00:05:00");
            this.scControl.Views.DayView.WorkTime.End = System.TimeSpan.Parse("17:00:00");
            this.scControl.Views.DayView.WorkTime.Start = System.TimeSpan.Parse("08:00:00");
            this.scControl.Views.TimelineView.WorkTime.End = System.TimeSpan.Parse("17:00:00");
            this.scControl.Views.TimelineView.WorkTime.Start = System.TimeSpan.Parse("08:00:00");
            this.scControl.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.scControl.Views.WorkWeekView.TimeScale = System.TimeSpan.Parse("00:15:00");
            this.scControl.Views.WorkWeekView.WorkTime.End = System.TimeSpan.Parse("17:00:00");
            this.scControl.Views.WorkWeekView.WorkTime.Start = System.TimeSpan.Parse("08:00:00");
            this.scControl.PreparePopupMenu += new DevExpress.XtraScheduler.PreparePopupMenuEventHandler(this.scControl_PreparePopupMenu);
            this.scControl.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.scControl_EditAppointmentFormShowing);
            this.scControl.SelectionChanged += new System.EventHandler(this.scControl_SelectionChanged);
            this.scControl.AppointmentDrop += new DevExpress.XtraScheduler.AppointmentDragEventHandler(this.scControl_AppointmentDrop);
            this.scControl.AppointmentViewInfoCustomizing += new DevExpress.XtraScheduler.AppointmentViewInfoCustomizingEventHandler(this.scControl_AppointmentViewInfoCustomizing);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = null;
            this.ribbonControl1.Images = this.imageCollection1;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.viewSelectorItem1,
            this.viewSelectorItem2,
            this.viewSelectorItem3,
            this.viewSelectorItem4,
            this.viewSelectorItem5,
            this.btnCheckTime,
            this.txtShowPeriod,
            this.btnShowVisible,
            this.btnRefresh});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 16;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.viewSelectorRibbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRadioGroup1});
            this.ribbonControl1.SelectedPage = this.viewSelectorRibbonPage1;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(837, 96);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(60, 60);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(2, "refresh32.png");
            // 
            // viewSelectorItem1
            // 
            this.viewSelectorItem1.Checked = true;
            this.viewSelectorItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem1.Glyph")));
            this.viewSelectorItem1.GroupIndex = 1;
            this.viewSelectorItem1.Id = 0;
            this.viewSelectorItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D1));
            this.viewSelectorItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem1.LargeGlyph")));
            this.viewSelectorItem1.Name = "viewSelectorItem1";
            this.viewSelectorItem1.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Day;
            // 
            // viewSelectorItem2
            // 
            this.viewSelectorItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem2.Glyph")));
            this.viewSelectorItem2.GroupIndex = 1;
            this.viewSelectorItem2.Id = 1;
            this.viewSelectorItem2.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D2));
            this.viewSelectorItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem2.LargeGlyph")));
            this.viewSelectorItem2.Name = "viewSelectorItem2";
            this.viewSelectorItem2.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
            // 
            // viewSelectorItem3
            // 
            this.viewSelectorItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem3.Glyph")));
            this.viewSelectorItem3.GroupIndex = 1;
            this.viewSelectorItem3.Id = 2;
            this.viewSelectorItem3.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D3));
            this.viewSelectorItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem3.LargeGlyph")));
            this.viewSelectorItem3.Name = "viewSelectorItem3";
            this.viewSelectorItem3.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Week;
            // 
            // viewSelectorItem4
            // 
            this.viewSelectorItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem4.Glyph")));
            this.viewSelectorItem4.GroupIndex = 1;
            this.viewSelectorItem4.Id = 3;
            this.viewSelectorItem4.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D4));
            this.viewSelectorItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem4.LargeGlyph")));
            this.viewSelectorItem4.Name = "viewSelectorItem4";
            this.viewSelectorItem4.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            // 
            // viewSelectorItem5
            // 
            this.viewSelectorItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem5.Glyph")));
            this.viewSelectorItem5.GroupIndex = 1;
            this.viewSelectorItem5.Id = 4;
            this.viewSelectorItem5.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D5));
            this.viewSelectorItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem5.LargeGlyph")));
            this.viewSelectorItem5.Name = "viewSelectorItem5";
            this.viewSelectorItem5.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Timeline;
            // 
            // btnCheckTime
            // 
            this.btnCheckTime.Caption = "Work Time";
            this.btnCheckTime.Checked = true;
            this.btnCheckTime.Id = 7;
            this.btnCheckTime.ImageIndex = 0;
            this.btnCheckTime.LargeImageIndex = 0;
            this.btnCheckTime.Name = "btnCheckTime";
            this.btnCheckTime.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCheckTime_ItemClick);
            // 
            // txtShowPeriod
            // 
            this.txtShowPeriod.Edit = this.repositoryItemRadioGroup1;
            this.txtShowPeriod.EditHeight = 100;
            this.txtShowPeriod.EditValue = "3Month";
            this.txtShowPeriod.Id = 8;
            this.txtShowPeriod.Name = "txtShowPeriod";
            this.txtShowPeriod.Width = 200;
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3Month", "Show Schedule in 3 Months"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("6Month", "Show Schedule in 6 Months"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Year", "Show Schedule in 1 Year")});
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            this.repositoryItemRadioGroup1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repositoryItemRadioGroup1_EditValueChanging);
            this.repositoryItemRadioGroup1.EditValueChanged += new System.EventHandler(this.repositoryItemRadioGroup1_EditValueChanged);
            // 
            // btnShowVisible
            // 
            this.btnShowVisible.Caption = "Visible Patient Schedule";
            this.btnShowVisible.Id = 13;
            this.btnShowVisible.LargeImageIndex = 1;
            this.btnShowVisible.Name = "btnShowVisible";
            this.btnShowVisible.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowVisible_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 15;
            this.btnRefresh.LargeImageIndex = 2;
            this.btnRefresh.LargeWidth = 60;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // viewSelectorRibbonPage1
            // 
            this.viewSelectorRibbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.viewSelectorRibbonPageGroup1,
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.viewSelectorRibbonPage1.Name = "viewSelectorRibbonPage1";
            // 
            // viewSelectorRibbonPageGroup1
            // 
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem1);
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem2);
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem3);
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem4);
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem5);
            this.viewSelectorRibbonPageGroup1.Name = "viewSelectorRibbonPageGroup1";
            this.viewSelectorRibbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCheckTime);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Work Time";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowMinimize = false;
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.txtShowPeriod);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnShowVisible);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Show Schedule Period";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowMinimize = false;
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("CommandType", "", DevExpress.XtraScheduler.FieldValueType.String));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("SCHEDULE_ID", "", DevExpress.XtraScheduler.FieldValueType.String));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("SCHEDULE_STATUS", "", DevExpress.XtraScheduler.FieldValueType.String));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("MODALITY_ID", "", DevExpress.XtraScheduler.FieldValueType.String));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("START_DATETIME", "", DevExpress.XtraScheduler.FieldValueType.DateTime));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("END_DATETIME", "", DevExpress.XtraScheduler.FieldValueType.DateTime));
            this.schedulerStorage1.AppointmentChanging += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage1_AppointmentChanging);
            this.schedulerStorage1.AppointmentDeleting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage1_AppointmentDeleting);
            // 
            // dateNav
            // 
            this.dateNav.Location = new System.Drawing.Point(2, 101);
            this.dateNav.Name = "dateNav";
            this.dateNav.SchedulerControl = this.scControl;
            this.dateNav.Size = new System.Drawing.Size(178, 319);
            this.dateNav.TabIndex = 5;
            // 
            // chkList
            // 
            this.chkList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.chkList.CheckOnClick = true;
            this.chkList.Location = new System.Drawing.Point(2, 451);
            this.chkList.Name = "chkList";
            this.chkList.SchedulerControl = this.scControl;
            this.chkList.Size = new System.Drawing.Size(179, 173);
            this.chkList.TabIndex = 6;
            this.chkList.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkList_ItemCheck);
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(43, 426);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "Select All";
            this.chkAll.Size = new System.Drawing.Size(75, 18);
            this.chkAll.TabIndex = 8;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // ribbonViewSelector1
            // 
            this.ribbonViewSelector1.RibbonControl = this.ribbonControl1;
            this.ribbonViewSelector1.SchedulerControl = this.scControl;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2007 Blue";
            // 
            // ImgSession
            // 
            this.ImgSession.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImgSession.ImageStream")));
            // 
            // frmMechanicSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(837, 626);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkList);
            this.Controls.Add(this.dateNav);
            this.Controls.Add(this.scControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMechanicSchedule";
            this.Text = "Schedule";
            this.Load += new System.EventHandler(this.frmSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewSelector1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgSession)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraScheduler.DateNavigator dateNav;
        private DevExpress.XtraScheduler.SchedulerControl scControl;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraScheduler.UI.ResourcesCheckedListBoxControl chkList;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem1;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem2;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem3;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem4;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem5;
        private DevExpress.XtraScheduler.UI.ViewSelectorRibbonPage viewSelectorRibbonPage1;
        private DevExpress.XtraScheduler.UI.ViewSelectorRibbonPageGroup viewSelectorRibbonPageGroup1;
        private DevExpress.XtraScheduler.UI.RibbonViewSelector ribbonViewSelector1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarCheckItem btnCheckTime;
        private DevExpress.XtraGrid.Blending.XtraGridBlending xtraGridBlending1;
        private DevExpress.Utils.ImageCollection ImgSession;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarEditItem txtShowPeriod;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraBars.BarCheckItem btnShowVisible;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
    }
}