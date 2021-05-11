namespace RIS.Forms.Schedule
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
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler4 = new DevExpress.XtraScheduler.TimeRuler();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSchedule));
            this.scControl = new DevExpress.XtraScheduler.SchedulerControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.viewSelectorItem1 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem2 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem3 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem4 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem5 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.btnCheckTime = new DevExpress.XtraBars.BarCheckItem();
            this.viewSelectorRibbonPage1 = new DevExpress.XtraScheduler.UI.ViewSelectorRibbonPage();
            this.viewSelectorRibbonPageGroup1 = new DevExpress.XtraScheduler.UI.ViewSelectorRibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.dateNav = new DevExpress.XtraScheduler.DateNavigator();
            this.chkList = new DevExpress.XtraScheduler.UI.ResourcesCheckedListBoxControl();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.ribbonViewSelector1 = new DevExpress.XtraScheduler.UI.RibbonViewSelector(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.grdSchedule = new DevExpress.XtraGrid.GridControl();
            this.view1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelHNSearch = new DevExpress.XtraEditors.PanelControl();
            this.lblExam = new DevExpress.XtraEditors.LabelControl();
            this.lblResult = new DevExpress.XtraEditors.LabelControl();
            this.btnMoveLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveNext = new DevExpress.XtraEditors.SimpleButton();
            this.txtHNSearch = new DevExpress.XtraEditors.TextEdit();
            this.btnMovePrev = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveFirst = new DevExpress.XtraEditors.SimpleButton();
            this.xtraGridBlending1 = new DevExpress.XtraGrid.Blending.XtraGridBlending();
            ((System.ComponentModel.ISupportInitialize)(this.scControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewSelector1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHNSearch)).BeginInit();
            this.panelHNSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHNSearch.Properties)).BeginInit();
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
            this.scControl.Views.DayView.TimeRulers.Add(timeRuler3);
            this.scControl.Views.DayView.TimeScale = System.TimeSpan.Parse("00:05:00");
            this.scControl.Views.DayView.WorkTime.End = System.TimeSpan.Parse("17:00:00");
            this.scControl.Views.DayView.WorkTime.Start = System.TimeSpan.Parse("08:00:00");
            this.scControl.Views.TimelineView.WorkTime.End = System.TimeSpan.Parse("17:00:00");
            this.scControl.Views.TimelineView.WorkTime.Start = System.TimeSpan.Parse("08:00:00");
            this.scControl.Views.WorkWeekView.TimeRulers.Add(timeRuler4);
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
            this.ribbonControl1.ApplicationButtonKeyTip = "";
            this.ribbonControl1.ApplicationIcon = null;
            this.ribbonControl1.Images = this.imageCollection1;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.viewSelectorItem1,
            this.viewSelectorItem2,
            this.viewSelectorItem3,
            this.viewSelectorItem4,
            this.viewSelectorItem5,
            this.btnCheckTime});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.viewSelectorRibbonPage1});
            this.ribbonControl1.SelectedPage = this.viewSelectorRibbonPage1;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(837, 97);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(60, 60);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
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
            this.viewSelectorItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.viewSelectorItem1.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)
                        | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
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
            this.viewSelectorItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.viewSelectorItem2.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)
                        | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
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
            this.viewSelectorItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.viewSelectorItem3.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)
                        | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
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
            this.viewSelectorItem4.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.viewSelectorItem4.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)
                        | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
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
            this.viewSelectorItem5.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.viewSelectorItem5.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)
                        | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
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
            // viewSelectorRibbonPage1
            // 
            this.viewSelectorRibbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.viewSelectorRibbonPageGroup1,
            this.ribbonPageGroup1});
            this.viewSelectorRibbonPage1.KeyTip = "";
            this.viewSelectorRibbonPage1.Name = "viewSelectorRibbonPage1";
            // 
            // viewSelectorRibbonPageGroup1
            // 
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem1);
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem2);
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem3);
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem4);
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem5);
            this.viewSelectorRibbonPageGroup1.KeyTip = "";
            this.viewSelectorRibbonPageGroup1.Name = "viewSelectorRibbonPageGroup1";
            this.viewSelectorRibbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCheckTime);
            this.ribbonPageGroup1.KeyTip = "";
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Work Time";
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("CommandType", "", DevExpress.XtraScheduler.FieldValueType.String));
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
            this.dateNav.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo;
            // 
            // chkList
            // 
            this.chkList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.chkList.CheckOnClick = true;
            this.chkList.LeftCoord = 0;
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
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // grdSchedule
            // 
            this.grdSchedule.EmbeddedNavigator.Name = "";
            this.grdSchedule.FormsUseDefaultLookAndFeel = false;
            this.grdSchedule.Location = new System.Drawing.Point(310, 5);
            this.grdSchedule.MainView = this.view1;
            this.grdSchedule.Name = "grdSchedule";
            this.grdSchedule.Size = new System.Drawing.Size(243, 86);
            this.grdSchedule.TabIndex = 12;
            this.grdSchedule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view1});
            // 
            // view1
            // 
            this.view1.GridControl = this.grdSchedule;
            this.view1.Name = "view1";
            this.view1.OptionsBehavior.Editable = false;
            this.view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.view1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.view1.OptionsView.ShowColumnHeaders = false;
            this.view1.OptionsView.ShowGroupPanel = false;
            this.view1.OptionsView.ShowHorzLines = false;
            this.view1.OptionsView.ShowIndicator = false;
            // 
            // panelHNSearch
            // 
            this.panelHNSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelHNSearch.Controls.Add(this.lblExam);
            this.panelHNSearch.Controls.Add(this.lblResult);
            this.panelHNSearch.Controls.Add(this.btnMoveLast);
            this.panelHNSearch.Controls.Add(this.btnMoveNext);
            this.panelHNSearch.Controls.Add(this.txtHNSearch);
            this.panelHNSearch.Controls.Add(this.btnMovePrev);
            this.panelHNSearch.Controls.Add(this.btnMoveFirst);
            this.panelHNSearch.Location = new System.Drawing.Point(555, 5);
            this.panelHNSearch.Name = "panelHNSearch";
            this.panelHNSearch.Size = new System.Drawing.Size(275, 86);
            this.panelHNSearch.TabIndex = 14;
            // 
            // lblExam
            // 
            this.lblExam.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblExam.Appearance.Options.UseFont = true;
            this.lblExam.Location = new System.Drawing.Point(5, 10);
            this.lblExam.Name = "lblExam";
            this.lblExam.Size = new System.Drawing.Size(0, 13);
            this.lblExam.TabIndex = 6;
            // 
            // lblResult
            // 
            this.lblResult.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblResult.Appearance.Options.UseFont = true;
            this.lblResult.Location = new System.Drawing.Point(5, 58);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(79, 13);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "Please key HN";
            // 
            // btnMoveLast
            // 
            this.btnMoveLast.Location = new System.Drawing.Point(242, 29);
            this.btnMoveLast.Name = "btnMoveLast";
            this.btnMoveLast.Size = new System.Drawing.Size(29, 23);
            this.btnMoveLast.TabIndex = 4;
            this.btnMoveLast.Text = ">|";
            this.btnMoveLast.Click += new System.EventHandler(this.btnMoveLast_Click);
            // 
            // btnMoveNext
            // 
            this.btnMoveNext.Location = new System.Drawing.Point(214, 29);
            this.btnMoveNext.Name = "btnMoveNext";
            this.btnMoveNext.Size = new System.Drawing.Size(29, 23);
            this.btnMoveNext.TabIndex = 3;
            this.btnMoveNext.Text = ">";
            this.btnMoveNext.Click += new System.EventHandler(this.btnMoveNext_Click);
            // 
            // txtHNSearch
            // 
            this.txtHNSearch.EditValue = "";
            this.txtHNSearch.Location = new System.Drawing.Point(62, 31);
            this.txtHNSearch.Name = "txtHNSearch";
            this.txtHNSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtHNSearch.Properties.Appearance.Options.UseFont = true;
            this.txtHNSearch.Properties.Appearance.Options.UseTextOptions = true;
            this.txtHNSearch.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtHNSearch.Size = new System.Drawing.Size(152, 20);
            this.txtHNSearch.TabIndex = 2;
            this.txtHNSearch.Validated += new System.EventHandler(this.txtHNSearch_Validated);
            this.txtHNSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHNSearch_KeyDown);
            // 
            // btnMovePrev
            // 
            this.btnMovePrev.Location = new System.Drawing.Point(33, 29);
            this.btnMovePrev.Name = "btnMovePrev";
            this.btnMovePrev.Size = new System.Drawing.Size(29, 23);
            this.btnMovePrev.TabIndex = 1;
            this.btnMovePrev.Text = "<";
            this.btnMovePrev.Click += new System.EventHandler(this.btnMovePrev_Click);
            // 
            // btnMoveFirst
            // 
            this.btnMoveFirst.Location = new System.Drawing.Point(5, 29);
            this.btnMoveFirst.Name = "btnMoveFirst";
            this.btnMoveFirst.Size = new System.Drawing.Size(29, 23);
            this.btnMoveFirst.TabIndex = 0;
            this.btnMoveFirst.Text = "|<";
            this.btnMoveFirst.Click += new System.EventHandler(this.btnMoveFirst_Click);
            // 
            // xtraGridBlending1
            // 
            this.xtraGridBlending1.GridControl = this.grdSchedule;
            // 
            // frmSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(837, 626);
            this.Controls.Add(this.panelHNSearch);
            this.Controls.Add(this.grdSchedule);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkList);
            this.Controls.Add(this.dateNav);
            this.Controls.Add(this.scControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule";
            this.Load += new System.EventHandler(this.frmSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewSelector1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHNSearch)).EndInit();
            this.panelHNSearch.ResumeLayout(false);
            this.panelHNSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHNSearch.Properties)).EndInit();
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
        private DevExpress.XtraGrid.GridControl grdSchedule;
        private DevExpress.XtraGrid.Views.Grid.GridView view1;
        private DevExpress.XtraEditors.PanelControl panelHNSearch;
        private DevExpress.XtraEditors.LabelControl lblResult;
        private DevExpress.XtraEditors.SimpleButton btnMoveLast;
        private DevExpress.XtraEditors.SimpleButton btnMoveNext;
        private DevExpress.XtraEditors.TextEdit txtHNSearch;
        private DevExpress.XtraEditors.SimpleButton btnMovePrev;
        private DevExpress.XtraEditors.SimpleButton btnMoveFirst;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarCheckItem btnCheckTime;
        private DevExpress.XtraEditors.LabelControl lblExam;
        private DevExpress.XtraGrid.Blending.XtraGridBlending xtraGridBlending1;
    }
}