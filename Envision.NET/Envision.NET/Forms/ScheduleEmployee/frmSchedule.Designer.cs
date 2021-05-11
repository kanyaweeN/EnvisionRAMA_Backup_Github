namespace Envision.NET.Forms.ScheduleEmployee
{
    partial class frmSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSchedule));
            this.scControl = new DevExpress.XtraScheduler.SchedulerControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.viewSelectorItem1 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem2 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem3 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem4 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem5 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewNavigatorBackwardItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorBackwardItem();
            this.viewNavigatorForwardItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorForwardItem();
            this.viewNavigatorTodayItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorTodayItem();
            this.viewNavigatorZoomInItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorZoomInItem();
            this.viewNavigatorZoomOutItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorZoomOutItem();
            this.barCheckTime = new DevExpress.XtraBars.BarCheckItem();
            this.viewSelectorRibbonPage1 = new DevExpress.XtraScheduler.UI.ViewSelectorRibbonPage();
            this.viewNavigatorRibbonPageGroup1 = new DevExpress.XtraScheduler.UI.ViewNavigatorRibbonPageGroup();
            this.viewSelectorRibbonPageGroup1 = new DevExpress.XtraScheduler.UI.ViewSelectorRibbonPageGroup();
            this.scStorage = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.rbViewNav = new DevExpress.XtraScheduler.UI.RibbonViewNavigator();
            this.rbViewSelect = new DevExpress.XtraScheduler.UI.RibbonViewSelector(this.components);
            this.ribbonViewSelector2 = new DevExpress.XtraScheduler.UI.RibbonViewSelector(this.components);
            this.ribbonViewNavigator2 = new DevExpress.XtraScheduler.UI.RibbonViewNavigator();
            this.dateNav = new DevExpress.XtraScheduler.DateNavigator();
            this.chkList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.chkResource = new DevExpress.XtraScheduler.UI.ResourcesCheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.scControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbViewNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbViewSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewSelector2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewNavigator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkResource)).BeginInit();
            this.SuspendLayout();
            // 
            // scControl
            // 
            this.scControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scControl.Location = new System.Drawing.Point(190, 102);
            this.scControl.MenuManager = this.ribbonControl1;
            this.scControl.Name = "scControl";
            this.scControl.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.scControl.Size = new System.Drawing.Size(636, 536);
            this.scControl.Start = new System.DateTime(2009, 10, 26, 0, 0, 0, 0);
            this.scControl.Storage = this.scStorage;
            this.scControl.TabIndex = 0;
            this.scControl.Text = "schedulerControl1";
            this.scControl.Views.DayView.TimeRulers.Add(timeRuler1);
            this.scControl.Views.DayView.TimeScale = System.TimeSpan.Parse("00:10:00");
            this.scControl.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.scControl.Views.WorkWeekView.TimeScale = System.TimeSpan.Parse("00:10:00");
            this.scControl.EditRecurrentAppointmentFormShowing += new DevExpress.XtraScheduler.EditRecurrentAppointmentFormEventHandler(this.scControl_EditRecurrentAppointmentFormShowing);
            this.scControl.AppointmentDrag += new DevExpress.XtraScheduler.AppointmentDragEventHandler(this.scControl_AppointmentDrag);
            this.scControl.PreparePopupMenu += new DevExpress.XtraScheduler.PreparePopupMenuEventHandler(this.scControl_PreparePopupMenu);
            this.scControl.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.scControl_EditAppointmentFormShowing);
            this.scControl.DeleteRecurrentAppointmentFormShowing += new DevExpress.XtraScheduler.DeleteRecurrentAppointmentFormEventHandler(this.scControl_DeleteRecurrentAppointmentFormShowing);
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
            this.viewNavigatorBackwardItem1,
            this.viewNavigatorForwardItem1,
            this.viewNavigatorTodayItem1,
            this.viewNavigatorZoomInItem1,
            this.viewNavigatorZoomOutItem1,
            this.barCheckTime});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 22;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.viewSelectorRibbonPage1});
            this.ribbonControl1.SelectedPage = this.viewSelectorRibbonPage1;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(826, 95);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(60, 60);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "consumer48.png");
            // 
            // viewSelectorItem1
            // 
            this.viewSelectorItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem1.Glyph")));
            this.viewSelectorItem1.GroupIndex = 1;
            this.viewSelectorItem1.Id = 10;
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
            this.viewSelectorItem2.Id = 11;
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
            this.viewSelectorItem3.Id = 12;
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
            this.viewSelectorItem4.Id = 13;
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
            this.viewSelectorItem5.Id = 14;
            this.viewSelectorItem5.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D5));
            this.viewSelectorItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem5.LargeGlyph")));
            this.viewSelectorItem5.Name = "viewSelectorItem5";
            this.viewSelectorItem5.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Timeline;
            // 
            // viewNavigatorBackwardItem1
            // 
            this.viewNavigatorBackwardItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorBackwardItem1.Glyph")));
            this.viewNavigatorBackwardItem1.GroupIndex = 1;
            this.viewNavigatorBackwardItem1.Id = 15;
            this.viewNavigatorBackwardItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorBackwardItem1.LargeGlyph")));
            this.viewNavigatorBackwardItem1.Name = "viewNavigatorBackwardItem1";
            // 
            // viewNavigatorForwardItem1
            // 
            this.viewNavigatorForwardItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorForwardItem1.Glyph")));
            this.viewNavigatorForwardItem1.GroupIndex = 1;
            this.viewNavigatorForwardItem1.Id = 16;
            this.viewNavigatorForwardItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorForwardItem1.LargeGlyph")));
            this.viewNavigatorForwardItem1.Name = "viewNavigatorForwardItem1";
            // 
            // viewNavigatorTodayItem1
            // 
            this.viewNavigatorTodayItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorTodayItem1.Glyph")));
            this.viewNavigatorTodayItem1.GroupIndex = 1;
            this.viewNavigatorTodayItem1.Id = 17;
            this.viewNavigatorTodayItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorTodayItem1.LargeGlyph")));
            this.viewNavigatorTodayItem1.Name = "viewNavigatorTodayItem1";
            // 
            // viewNavigatorZoomInItem1
            // 
            this.viewNavigatorZoomInItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorZoomInItem1.Glyph")));
            this.viewNavigatorZoomInItem1.GroupIndex = 1;
            this.viewNavigatorZoomInItem1.Id = 18;
            this.viewNavigatorZoomInItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Add));
            this.viewNavigatorZoomInItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorZoomInItem1.LargeGlyph")));
            this.viewNavigatorZoomInItem1.Name = "viewNavigatorZoomInItem1";
            // 
            // viewNavigatorZoomOutItem1
            // 
            this.viewNavigatorZoomOutItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorZoomOutItem1.Glyph")));
            this.viewNavigatorZoomOutItem1.GroupIndex = 1;
            this.viewNavigatorZoomOutItem1.Id = 19;
            this.viewNavigatorZoomOutItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Subtract));
            this.viewNavigatorZoomOutItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorZoomOutItem1.LargeGlyph")));
            this.viewNavigatorZoomOutItem1.Name = "viewNavigatorZoomOutItem1";
            // 
            // barCheckTime
            // 
            this.barCheckTime.Caption = "Work Time";
            this.barCheckTime.Checked = true;
            this.barCheckTime.Id = 21;
            this.barCheckTime.ImageIndex = 0;
            this.barCheckTime.LargeImageIndex = 0;
            this.barCheckTime.Name = "barCheckTime";
            this.barCheckTime.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckTime_ItemClick);
            // 
            // viewSelectorRibbonPage1
            // 
            this.viewSelectorRibbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.viewNavigatorRibbonPageGroup1,
            this.viewSelectorRibbonPageGroup1});
            this.viewSelectorRibbonPage1.Name = "viewSelectorRibbonPage1";
            // 
            // viewNavigatorRibbonPageGroup1
            // 
            this.viewNavigatorRibbonPageGroup1.ItemLinks.Add(this.viewNavigatorBackwardItem1);
            this.viewNavigatorRibbonPageGroup1.ItemLinks.Add(this.viewNavigatorForwardItem1);
            this.viewNavigatorRibbonPageGroup1.ItemLinks.Add(this.viewNavigatorTodayItem1);
            this.viewNavigatorRibbonPageGroup1.ItemLinks.Add(this.barCheckTime);
            this.viewNavigatorRibbonPageGroup1.ItemLinks.Add(this.viewNavigatorZoomInItem1);
            this.viewNavigatorRibbonPageGroup1.ItemLinks.Add(this.viewNavigatorZoomOutItem1);
            this.viewNavigatorRibbonPageGroup1.Name = "viewNavigatorRibbonPageGroup1";
            this.viewNavigatorRibbonPageGroup1.ShowCaptionButton = false;
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
            // scStorage
            // 
            this.scStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("SCHEDULE_ID", "SCHEDULE_ID", DevExpress.XtraScheduler.FieldValueType.Integer));
            this.scStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("COMMAND", "COMMAND", DevExpress.XtraScheduler.FieldValueType.String));
            this.scStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("SCHEDULE_ID_PARENT", "SCHEDULE_ID_PARENT", DevExpress.XtraScheduler.FieldValueType.Integer));
            this.scStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("RECURRENCEINFO", "RECURRENCEINFO", DevExpress.XtraScheduler.FieldValueType.String));
            this.scStorage.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.scStorage_AppointmentsChanged);
            this.scStorage.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.scStorage_AppointmentsDeleted);
            this.scStorage.AppointmentChanging += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.scStorage_AppointmentChanging);
            this.scStorage.AppointmentDeleting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.scStorage_AppointmentDeleting);
            // 
            // rbViewNav
            // 
            this.rbViewNav.RibbonControl = this.ribbonControl1;
            this.rbViewNav.SchedulerControl = this.scControl;
            // 
            // rbViewSelect
            // 
            this.rbViewSelect.RibbonControl = this.ribbonControl1;
            this.rbViewSelect.SchedulerControl = this.scControl;
            // 
            // ribbonViewSelector2
            // 
            this.ribbonViewSelector2.RibbonControl = this.ribbonControl1;
            this.ribbonViewSelector2.SchedulerControl = this.scControl;
            // 
            // ribbonViewNavigator2
            // 
            this.ribbonViewNavigator2.RibbonControl = this.ribbonControl1;
            this.ribbonViewNavigator2.SchedulerControl = this.scControl;
            // 
            // dateNav
            // 
            this.dateNav.Location = new System.Drawing.Point(5, 102);
            this.dateNav.Name = "dateNav";
            this.dateNav.SchedulerControl = this.scControl;
            this.dateNav.Size = new System.Drawing.Size(179, 297);
            this.dateNav.TabIndex = 2;
            // 
            // chkList
            // 
            this.chkList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.chkList.CheckOnClick = true;
            this.chkList.Location = new System.Drawing.Point(5, 400);
            this.chkList.Name = "chkList";
            this.chkList.Size = new System.Drawing.Size(179, 238);
            this.chkList.TabIndex = 6;
            this.chkList.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkList_ItemCheck);
            // 
            // chkResource
            // 
            this.chkResource.CheckOnClick = true;
            this.chkResource.Location = new System.Drawing.Point(5, 530);
            this.chkResource.Name = "chkResource";
            this.chkResource.SchedulerControl = this.scControl;
            this.chkResource.Size = new System.Drawing.Size(179, 108);
            this.chkResource.TabIndex = 8;
            this.chkResource.Visible = false;
            // 
            // frmSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(826, 639);
            this.Controls.Add(this.chkList);
            this.Controls.Add(this.dateNav);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.scControl);
            this.Controls.Add(this.chkResource);
            this.Name = "frmSchedule";
            this.Text = "Staff Schedule";
            this.Load += new System.EventHandler(this.frmSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbViewNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbViewSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewSelector2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewNavigator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkResource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl scControl;
        private DevExpress.XtraScheduler.SchedulerStorage scStorage;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraScheduler.UI.RibbonViewNavigator rbViewNav;
        private DevExpress.XtraScheduler.UI.RibbonViewSelector rbViewSelect;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem1;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem2;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem3;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem4;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem5;
        private DevExpress.XtraScheduler.UI.ViewNavigatorBackwardItem viewNavigatorBackwardItem1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorForwardItem viewNavigatorForwardItem1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorTodayItem viewNavigatorTodayItem1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorZoomInItem viewNavigatorZoomInItem1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorZoomOutItem viewNavigatorZoomOutItem1;
        private DevExpress.XtraScheduler.UI.ViewSelectorRibbonPage viewSelectorRibbonPage1;
        private DevExpress.XtraScheduler.UI.ViewSelectorRibbonPageGroup viewSelectorRibbonPageGroup1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorRibbonPageGroup viewNavigatorRibbonPageGroup1;
        private DevExpress.XtraScheduler.UI.RibbonViewSelector ribbonViewSelector2;
        private DevExpress.XtraScheduler.UI.RibbonViewNavigator ribbonViewNavigator2;
        private DevExpress.XtraScheduler.DateNavigator dateNav;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarCheckItem barCheckTime;
        private DevExpress.XtraEditors.CheckedListBoxControl chkList;
        private DevExpress.XtraScheduler.UI.ResourcesCheckedListBoxControl chkResource;
    }
}