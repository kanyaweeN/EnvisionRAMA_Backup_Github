//	Define these preprocessor directives as required for the type of database being used.
#define DATABASE_MSACCESS
//#define DATABASE_SQLSERVER

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.EmployeeSchedule;
using Infragistics.Win.UltraWinToolbars;
using System.Data.OleDb;
using Infragistics.Win.UltraWinEditors;
using RIS.Common.UtilityClass;
using RIS.Forms.GBLMessage;
using RIS.Common.Common;
using RIS.BusinessLogic;
namespace RIS.Forms.EmployeeSchedule
{
    
    
	#region frmMain class
	/// <summary>
	/// Main dialog for the UltraWinSchedule DB Demo Application.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
        private UUL.ControlFrame.Controls.TabControl CloseControl;
		#region Member variables

		private Infragistics.Win.EmployeeSchedule.UltraCalendarInfo ultraCalendarInfo1;
        private Infragistics.Win.EmployeeSchedule.UltraCalendarLook ultraCalendarLook1;
        private Infragistics.Win.EmployeeSchedule.UltraMonthViewMulti ultraMonthViewMulti1;
		private System.Windows.Forms.Panel frmMain_Fill_Panel;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Splitter splitter1;
        private Infragistics.Win.EmployeeSchedule.UltraDayView ultraDayView1;
        private Infragistics.Win.EmployeeSchedule.UltraMonthViewSingle ultraMonthViewSingle1;
        public UltraWeekView ultraWeekView1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmAppointmentGrouping_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmAppointmentGrouping_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmAppointmentGrouping_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmAppointmentGrouping_Toolbars_Dock_Area_Right;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Splitter splitter2;
		private Infragistics.Win.IGControls.IGContextMenu contextMenu1;
		private Infragistics.Win.IGControls.IGMenuItem menuItem_ModifyOwner;
		private Infragistics.Win.IGControls.IGMenuItem menuItem_RemoveOwner;
		private System.Windows.Forms.Panel pnlOwners;

		private WinScheduleDatabaseSupportBase _databaseSupport = null;
        int count = 0;
		#endregion Member variables

		#region Constructor
		/// <summary>
		/// Creates a new instance of the <see cref="frmMain"/> class.
		/// </summary>
		public frmMain(UUL.ControlFrame.Controls.TabControl clsCtl)
		{
			this.InitializeComponent();
			this.InitializeUI();
            CloseControl = clsCtl;
            CloseControl.ClosePressed += new EventHandler(CloseControl_ClosePressed);
            
		}
		#endregion Constructor

		#region Windows Form Designer generated code

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}

				//	Dispose of the WinScheduleDatabaseSupportBase object
				if ( this._databaseSupport != null )
				{
					this._databaseSupport.Dispose();
					this._databaseSupport = null;
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.OptionSet optionSet1 = new Infragistics.Win.UltraWinToolbars.OptionSet("DateButtons");
            Infragistics.Win.UltraWinToolbars.OptionSet optionSet2 = new Infragistics.Win.UltraWinToolbars.OptionSet("ViewStyle");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("tlbMainMenu");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("menuData");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("tlbMainToolbar");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool1 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Day", "DateButtons");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool2 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Week", "DateButtons");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool3 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Month", "DateButtons");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("menuFile");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("menuMain_File_Exit");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("menuMain_File_Exit");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("New");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AddOwner");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AddAppointment");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AddOwner");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool4 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Day", "DateButtons");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool5 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Week", "DateButtons");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool6 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Month", "DateButtons");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("menuView");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool7 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("menuMain_View_Standard", "ViewStyle");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool8 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("menuMain_View_Office2003", "ViewStyle");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool9 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("menuMain_View_VS2005", "ViewStyle");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool8 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Office2007");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool10 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("menuMain_View_Standard", "ViewStyle");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool11 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("menuMain_View_Office2003", "ViewStyle");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool12 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("menuMain_View_VS2005", "ViewStyle");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool9 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("menuData");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("menuMain_Data_UpdateAppointmentsTable");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("menuMain_Data_UpdateOwnersTable");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("menuMain_Data_UpdateAppointmentsTable");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool11 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("menuQueries");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("menuQueries_AllOwners");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("menuQueries_AllAppointments");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("menuQueries_AppointmentsByOwner");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("menuQueries_AppointmentsByOwner");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("menuQueries_AllAppointments");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("menuQueries_AllOwners");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool13 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("menuMain_View_Office2007_Blue", "ViewStyle");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool14 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("menuMain_View_Office2007_Black", "ViewStyle");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool12 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Office2007");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool15 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("menuMain_View_Office2007_Blue", "ViewStyle");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool16 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("menuMain_View_Office2007_Black", "ViewStyle");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool17 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("menuMain_View_Office2007_Silver", "ViewStyle");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool18 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("menuMain_View_Office2007_Silver", "ViewStyle");
            this.ultraCalendarInfo1 = new Infragistics.Win.EmployeeSchedule.UltraCalendarInfo(this.components);
            this.ultraCalendarLook1 = new Infragistics.Win.EmployeeSchedule.UltraCalendarLook(this.components);
            this.ultraMonthViewMulti1 = new Infragistics.Win.EmployeeSchedule.UltraMonthViewMulti();
            this.frmMain_Fill_Panel = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.ultraWeekView1 = new Infragistics.Win.EmployeeSchedule.UltraWeekView();
            this.ultraMonthViewSingle1 = new Infragistics.Win.EmployeeSchedule.UltraMonthViewSingle();
            this.ultraDayView1 = new Infragistics.Win.EmployeeSchedule.UltraDayView();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlOwners = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.contextMenu1 = new Infragistics.Win.IGControls.IGContextMenu();
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.ultraMonthViewMulti1)).BeginInit();
            this.frmMain_Fill_Panel.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraWeekView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraMonthViewSingle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDayView1)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraCalendarInfo1
            // 
            this.ultraCalendarInfo1.AllowRecurringAppointments = true;
            this.ultraCalendarInfo1.DataBindingsForAppointments.BindingContextControl = this;
            this.ultraCalendarInfo1.DataBindingsForOwners.BindingContextControl = this;
            this.ultraCalendarInfo1.ValidateAppointment += new Infragistics.Win.EmployeeSchedule.ValidateAppointmentEventHandler(this.ultraCalendarInfo1_ValidateAppointment);
            // 
            // ultraCalendarLook1
            // 
            this.ultraCalendarLook1.ViewStyle = Infragistics.Win.EmployeeSchedule.ViewStyle.Office2007;
            // 
            // ultraMonthViewMulti1
            // 
            this.ultraMonthViewMulti1.BackColor = System.Drawing.SystemColors.Window;
            this.ultraMonthViewMulti1.CalendarInfo = this.ultraCalendarInfo1;
            this.ultraMonthViewMulti1.CalendarLook = this.ultraCalendarLook1;
            this.ultraMonthViewMulti1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraMonthViewMulti1.Location = new System.Drawing.Point(0, 0);
            this.ultraMonthViewMulti1.MonthOrientation = Infragistics.Win.EmployeeSchedule.MonthOrientation.DownThenAcross;
            this.ultraMonthViewMulti1.Name = "ultraMonthViewMulti1";
            this.ultraMonthViewMulti1.Size = new System.Drawing.Size(142, 124);
            this.ultraMonthViewMulti1.TabIndex = 1;
            // 
            // frmMain_Fill_Panel
            // 
            this.frmMain_Fill_Panel.Controls.Add(this.splitter1);
            this.frmMain_Fill_Panel.Controls.Add(this.pnlMain);
            this.frmMain_Fill_Panel.Controls.Add(this.pnlLeft);
            this.frmMain_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmMain_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmMain_Fill_Panel.Location = new System.Drawing.Point(0, 49);
            this.frmMain_Fill_Panel.Name = "frmMain_Fill_Panel";
            this.frmMain_Fill_Panel.Size = new System.Drawing.Size(696, 421);
            this.frmMain_Fill_Panel.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.splitter1.Location = new System.Drawing.Point(144, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 421);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.ultraWeekView1);
            this.pnlMain.Controls.Add(this.ultraMonthViewSingle1);
            this.pnlMain.Controls.Add(this.ultraDayView1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(144, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(552, 421);
            this.pnlMain.TabIndex = 6;
            // 
            // ultraWeekView1
            // 
            this.ultraWeekView1.CalendarInfo = this.ultraCalendarInfo1;
            this.ultraWeekView1.CalendarLook = this.ultraCalendarLook1;
            this.ultraWeekView1.Location = new System.Drawing.Point(160, 232);
            this.ultraWeekView1.Name = "ultraWeekView1";
            this.ultraWeekView1.ShowClickToAddIndicator = Infragistics.Win.DefaultableBoolean.False;
            this.ultraWeekView1.Size = new System.Drawing.Size(168, 144);
            this.ultraWeekView1.TabIndex = 2;
            this.ultraWeekView1.Visible = false;
            // 
            // ultraMonthViewSingle1
            // 
            this.ultraMonthViewSingle1.CalendarInfo = this.ultraCalendarInfo1;
            this.ultraMonthViewSingle1.CalendarLook = this.ultraCalendarLook1;
            this.ultraMonthViewSingle1.Location = new System.Drawing.Point(160, 72);
            this.ultraMonthViewSingle1.Name = "ultraMonthViewSingle1";
            this.ultraMonthViewSingle1.ShowClickToAddIndicator = Infragistics.Win.DefaultableBoolean.False;
            this.ultraMonthViewSingle1.Size = new System.Drawing.Size(168, 152);
            this.ultraMonthViewSingle1.TabIndex = 1;
            this.ultraMonthViewSingle1.Visible = false;
            // 
            // ultraDayView1
            // 
            this.ultraDayView1.CalendarInfo = this.ultraCalendarInfo1;
            this.ultraDayView1.CalendarLook = this.ultraCalendarLook1;
            this.ultraDayView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraDayView1.Location = new System.Drawing.Point(0, 0);
            this.ultraDayView1.Name = "ultraDayView1";
            this.ultraDayView1.ShowClickToAddIndicator = Infragistics.Win.DefaultableBoolean.False;
            this.ultraDayView1.Size = new System.Drawing.Size(552, 421);
            this.ultraDayView1.TabIndex = 8;
            this.ultraDayView1.Text = "ultraDayView1";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlOwners);
            this.pnlLeft.Controls.Add(this.splitter2);
            this.pnlLeft.Controls.Add(this.ultraMonthViewMulti1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(144, 421);
            this.pnlLeft.TabIndex = 5;
            // 
            // pnlOwners
            // 
            this.pnlOwners.AutoScroll = true;
            this.pnlOwners.BackColor = System.Drawing.Color.White;
            this.pnlOwners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOwners.Location = new System.Drawing.Point(0, 126);
            this.pnlOwners.Name = "pnlOwners";
            this.pnlOwners.Size = new System.Drawing.Size(144, 295);
            this.pnlOwners.TabIndex = 3;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 124);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(144, 2);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // contextMenu1
            // 
            this.contextMenu1.ImageList = null;
            this.contextMenu1.Style = Infragistics.Win.IGControls.MenuStyle.OfficeXP;
            // 
            // _frmAppointmentGrouping_Toolbars_Dock_Area_Right
            // 
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(696, 49);
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Right.Name = "_frmAppointmentGrouping_Toolbars_Dock_Area_Right";
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 421);
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.ImageTransparentColor = System.Drawing.Color.Magenta;
            optionSet1.AllowAllUp = false;
            optionSet2.AllowAllUp = false;
            this.ultraToolbarsManager1.OptionSets.Add(optionSet1);
            this.ultraToolbarsManager1.OptionSets.Add(optionSet2);
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool2});
            ultraToolbar1.Text = "tlbMainMenu";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            stateButtonTool1.Checked = true;
            stateButtonTool1.InstanceProps.IsFirstInGroup = true;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            stateButtonTool1,
            stateButtonTool2,
            stateButtonTool3});
            ultraToolbar2.Text = "tlbMainToolbar";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool5.SharedProps.Caption = "&File";
            popupMenuTool5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
            buttonTool2.SharedProps.Caption = "E&xit";
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            popupMenuTool6.SharedProps.AppearancesSmall.Appearance = appearance1;
            popupMenuTool6.SharedProps.Caption = "&New";
            popupMenuTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            popupMenuTool6.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3});
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            buttonTool4.SharedProps.AppearancesSmall.Appearance = appearance2;
            buttonTool4.SharedProps.Caption = "&Appointment";
            buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool4.SharedProps.ToolTipText = "Add a new Appointment";
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            buttonTool5.SharedProps.AppearancesSmall.Appearance = appearance3;
            buttonTool5.SharedProps.Caption = "&Owner";
            buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool5.SharedProps.ToolTipText = "Add a new Owner";
            stateButtonTool4.Checked = true;
            stateButtonTool4.OptionSetKey = "DateButtons";
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            stateButtonTool4.SharedProps.AppearancesSmall.Appearance = appearance4;
            stateButtonTool4.SharedProps.Caption = "Da&y";
            stateButtonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            stateButtonTool5.OptionSetKey = "DateButtons";
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            stateButtonTool5.SharedProps.AppearancesSmall.Appearance = appearance5;
            stateButtonTool5.SharedProps.Caption = "&Week";
            stateButtonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            stateButtonTool6.OptionSetKey = "DateButtons";
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            stateButtonTool6.SharedProps.AppearancesSmall.Appearance = appearance6;
            stateButtonTool6.SharedProps.Caption = "&Month";
            stateButtonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            popupMenuTool7.SharedProps.Caption = "&View";
            stateButtonTool7.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            stateButtonTool8.Checked = true;
            stateButtonTool8.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            stateButtonTool9.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            popupMenuTool7.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            stateButtonTool7,
            stateButtonTool8,
            stateButtonTool9,
            popupMenuTool8});
            stateButtonTool10.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            stateButtonTool10.OptionSetKey = "ViewStyle";
            stateButtonTool10.SharedProps.Caption = "Standard";
            stateButtonTool11.Checked = true;
            stateButtonTool11.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            stateButtonTool11.OptionSetKey = "ViewStyle";
            stateButtonTool11.SharedProps.Caption = "Office2003";
            stateButtonTool12.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            stateButtonTool12.OptionSetKey = "ViewStyle";
            stateButtonTool12.SharedProps.Caption = "VS2005";
            popupMenuTool9.SharedProps.Caption = "&Data";
            popupMenuTool9.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool7});
            buttonTool8.SharedProps.Caption = "Update &Owners Table";
            buttonTool9.SharedProps.Caption = "Update &Schedule";
            popupMenuTool11.SharedProps.Caption = "Queries";
            popupMenuTool11.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool10,
            buttonTool11,
            buttonTool12});
            buttonTool13.SharedProps.Caption = "Appointments By Owner";
            buttonTool14.SharedProps.Caption = "All Appointments";
            buttonTool15.SharedProps.Caption = "All Owners";
            stateButtonTool13.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            stateButtonTool13.OptionSetKey = "ViewStyle";
            stateButtonTool13.SharedProps.Caption = "Blue";
            stateButtonTool14.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            stateButtonTool14.OptionSetKey = "ViewStyle";
            stateButtonTool14.SharedProps.Caption = "Black";
            popupMenuTool12.SharedProps.Caption = "Office2007";
            stateButtonTool15.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            stateButtonTool16.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            stateButtonTool17.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            popupMenuTool12.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            stateButtonTool15,
            stateButtonTool16,
            stateButtonTool17});
            stateButtonTool18.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            stateButtonTool18.OptionSetKey = "ViewStyle";
            stateButtonTool18.SharedProps.Caption = "Silver";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool5,
            buttonTool2,
            popupMenuTool6,
            buttonTool4,
            buttonTool5,
            stateButtonTool4,
            stateButtonTool5,
            stateButtonTool6,
            popupMenuTool7,
            stateButtonTool10,
            stateButtonTool11,
            stateButtonTool12,
            popupMenuTool9,
            buttonTool8,
            buttonTool9,
            popupMenuTool11,
            buttonTool13,
            buttonTool14,
            buttonTool15,
            stateButtonTool13,
            stateButtonTool14,
            popupMenuTool12,
            stateButtonTool18});
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // _frmAppointmentGrouping_Toolbars_Dock_Area_Left
            // 
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 49);
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Left.Name = "_frmAppointmentGrouping_Toolbars_Dock_Area_Left";
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 421);
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _frmAppointmentGrouping_Toolbars_Dock_Area_Top
            // 
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Top.Name = "_frmAppointmentGrouping_Toolbars_Dock_Area_Top";
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(696, 49);
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _frmAppointmentGrouping_Toolbars_Dock_Area_Bottom
            // 
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 470);
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Bottom.Name = "_frmAppointmentGrouping_Toolbars_Dock_Area_Bottom";
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(696, 0);
            this._frmAppointmentGrouping_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(696, 470);
            this.Controls.Add(this.frmMain_Fill_Panel);
            this.Controls.Add(this._frmAppointmentGrouping_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._frmAppointmentGrouping_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._frmAppointmentGrouping_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._frmAppointmentGrouping_Toolbars_Dock_Area_Bottom);
            this.Name = "frmMain";
            this.Text = "Employee Schedule";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraMonthViewMulti1)).EndInit();
            this.frmMain_Fill_Panel.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraWeekView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraMonthViewSingle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDayView1)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

		}
		
		#endregion	Windows Form Designer generated code

		

		#region Event handlers
        private void CloseControl_ClosePressed(object sender, EventArgs e)
        {
            count++;
            
                if (count == 1)
                {
                    if (this.DatabaseSupport.HasAppointmentChanges ||
                 this.DatabaseSupport.HasOwnerChanges)
                    {
                        MyMessageBox msg = new MyMessageBox();
                        string id = msg.ShowAlert("UID021", new GBLEnvVariable().CurrentLanguageID);
                        if (id == "2")
                        {
                            this.DatabaseSupport.UpdateAppointmentsTable();
                            
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            
        }
		/// <summary>
		/// Handles the main form's Closing event
		/// </summary>
		private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
			//	If the Appointments or Owners table has changes pending that have not
			//	yet been committed to the database, prompt the end user to determine
			//	whether they want to save the changes.
			if ( this.DatabaseSupport.HasAppointmentChanges ||
				 this.DatabaseSupport.HasOwnerChanges )
			{
				DialogResult result = MessageBox.Show( "You have made changes to data that have not been committed to the database. Save changes?", "Data changed", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question );

				switch ( result )
				{
					case DialogResult.Cancel:
					{
						e.Cancel = true;
						break;
					}

					case DialogResult.Yes:
					{
						try
						{
							this.DatabaseSupport.UpdateAppointmentsTable();
						}
						catch( Exception ex )
						{
							MessageBox.Show( "Error updating Appointments table: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
						}

						try
						{
							this.DatabaseSupport.UpdateOwnersTable();
						}
						catch( Exception ex )
						{
							MessageBox.Show( "Error updating Owners table: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
						}

						break;
					}

				}
			}
		}

		/// <summary>
		/// Handles the UltraToolbarManager's ToolClick event.
		/// </summary>
		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch ( e.Tool.Key )
			{
				case "Day":
				{
					this.ShowScheduleControl( this.ultraDayView1 );
					break;
				}

				case "Week":
				{
					this.ShowScheduleControl( this.ultraWeekView1 );			
					break;
				}

				case "Month":
				{
					this.ShowScheduleControl( this.ultraMonthViewSingle1 );			
					break;
				}

				case "menuMain_View_Standard":
				{
					this.ultraDayView1.Appearance.BackColor = SystemColors.Control;
					this.ultraCalendarLook1.ViewStyle = ViewStyle.Standard;
					this.ultraToolbarsManager1.Style = ToolbarStyle.OfficeXP;
					this.contextMenu1.Style = Infragistics.Win.IGControls.MenuStyle.OfficeXP;
					break;
				}

				case "menuMain_View_Office2003":
				{
					this.ultraDayView1.Appearance.BackColor = SystemColors.Control;
					this.ultraCalendarLook1.ViewStyle = ViewStyle.Office2003;
					this.ultraToolbarsManager1.Style = ToolbarStyle.Office2003;
					this.contextMenu1.Style = Infragistics.Win.IGControls.MenuStyle.Office2003;
					break;
				}

				case "menuMain_View_VS2005":
				{
					this.ultraDayView1.Appearance.BackColor = SystemColors.Control;
					this.ultraCalendarLook1.ViewStyle = ViewStyle.VisualStudio2005;
					this.ultraToolbarsManager1.Style = ToolbarStyle.VisualStudio2005;
					this.contextMenu1.Style = Infragistics.Win.IGControls.MenuStyle.VisualStudio2005;
					break;
				}

				case "menuMain_View_Office2007_Blue":
				case "menuMain_View_Office2007_Black":
				case "menuMain_View_Office2007_Silver":
				{
					this.ultraDayView1.Appearance.Reset();
					this.ultraCalendarLook1.ViewStyle = ViewStyle.Office2007;
					this.ultraToolbarsManager1.Style = ToolbarStyle.Office2007;
					this.contextMenu1.Style = Infragistics.Win.IGControls.MenuStyle.Office2007;

					if ( e.Tool.Key == "menuMain_View_Office2007_Blue" )
						Infragistics.Win.Office2007ColorTable.ColorScheme = Office2007ColorScheme.Blue;
					else
					if ( e.Tool.Key == "menuMain_View_Office2007_Black" )
						Infragistics.Win.Office2007ColorTable.ColorScheme = Office2007ColorScheme.Black;
					else
					if ( e.Tool.Key == "menuMain_View_Office2007_Silver" )
						Infragistics.Win.Office2007ColorTable.ColorScheme = Office2007ColorScheme.Silver;
					
					StateButtonTool stateButtonTool = this.ultraToolbarsManager1.Tools[e.Tool.Key] as StateButtonTool;
					stateButtonTool.Checked = true;

					//	Assign the default color scheme
					string ownerKey = "INFRAGISTICS_POWER_USER";
					if ( this.ultraCalendarInfo1.Owners.Exists(ownerKey) )
					{
                        Infragistics.Win.EmployeeSchedule.Owner owner = this.ultraCalendarInfo1.Owners[ownerKey];
						owner.Outlook2007ColorScheme = this.ultraCalendarLook1.Outlook2007ColorSchemes.DefaultScheme;
					}

					break;
				}

				case "AddOwner":
				{
					frmOwner frmOwner = new frmOwner( this.ultraCalendarInfo1 );
					frmOwner.ShowMe( null );
					if ( frmOwner.DialogResult == DialogResult.OK )
					{
						Owner newOwner = this.ultraCalendarInfo1.Owners.Add( frmOwner.Key, frmOwner.OwnerName );
						newOwner.EmailAddress = frmOwner.EMailAddress;
						newOwner.Visible = frmOwner.OwnerVisible;
						newOwner.Locked = frmOwner.Locked;
						this.AddCheckboxForOwner( newOwner );
					}

					break;
				}

				case "menuMain_Data_UpdateAppointmentsTable":
				{
					try
					{
						this.DatabaseSupport.UpdateAppointmentsTable();
					}
					catch( Exception ex )
					{
						MessageBox.Show( "Error updating Appointments table: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
					}

					break;
				}

				case "menuMain_Data_UpdateOwnersTable":
				{
					try
					{
						this.DatabaseSupport.UpdateOwnersTable();
					}
					catch( Exception ex )
					{
						MessageBox.Show( "Error updating Owners table: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
					}

					break;
				}

				case "menuQueries_AllAppointments":
				case "menuQueries_AllOwners":
				case "menuQueries_AppointmentsByOwner":
				{
					QueryType queryType = QueryType.AllAppointments;
					if ( e.Tool.Key == "menuQueries_AllOwners" )
						queryType = QueryType.AllOwners;
					else
					if ( e.Tool.Key == "menuQueries_AppointmentsByOwner" )
						queryType = QueryType.AppointmentsByOwner;

					frmQuery frmQuery = new frmQuery( this.DatabaseSupport, queryType );
					frmQuery.ShowDialog();

					break;
				}


				case "menuMain_File_Exit":
				{
					this.Close();
					break;
				}

			}
		}

		/// <summary>
		/// Handles the main form's Load event.
		/// </summary>
		private void frmMain_Load(object sender, System.EventArgs e)
		{
		}

		/// <summary>
		/// Handles the MouseDown event for the WinSchedule controls.
		/// </summary>
		private void WinScheduleControl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
           
            
			if ( e.Button == MouseButtons.Right )
			{
				Point cursorPos = new Point( e.X, e.Y );
				Owner ownerAtPoint = null;
				UltraDayView dayView = sender as UltraDayView;
				UltraMonthViewSingleBase monthViewSingleBase = sender as UltraMonthViewSingleBase;
                
				if ( dayView != null )
					ownerAtPoint = dayView.GetOwnerFromPoint( cursorPos );
				else
				if ( monthViewSingleBase != null )
					ownerAtPoint = monthViewSingleBase.GetOwnerFromPoint( cursorPos );

				if ( ownerAtPoint != null )
				{
					this.menuItem_ModifyOwner.Tag = ownerAtPoint;
					this.menuItem_RemoveOwner.Tag = ownerAtPoint;
				}
			}
		}

		/// <summary>
		/// Handles the Click event for the context menu items.
		/// </summary>
		private void OnContextMenuItemClick( object sender, EventArgs e )
		{
			Owner owner = null;
			
			if ( sender == this.menuItem_ModifyOwner )
			{
				owner = this.menuItem_ModifyOwner.Tag as Owner;
				frmOwner frmOwner = new frmOwner( this.ultraCalendarInfo1 );
				frmOwner.Text = string.Format("Modify owner '{0}'", owner.Name );
				frmOwner.ShowMe( owner );
				if ( frmOwner.DialogResult == DialogResult.OK )
				{
					owner.Key = frmOwner.Key;
					owner.Name = frmOwner.OwnerName;
					owner.EmailAddress = frmOwner.EMailAddress;
					owner.Visible = frmOwner.OwnerVisible;
					owner.Locked = frmOwner.Locked;
					this.InitializeOwnersPanel( true );
				}
			}
			else
			if ( sender == this.menuItem_RemoveOwner )
			{
				owner = this.menuItem_RemoveOwner.Tag as Owner;
				DialogResult result = MessageBox.Show( string.Format( "Are you sure you want to remove the owner '{0}'?", owner.Name ), "Remove Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question );
 				if ( result == DialogResult.Yes )
				{
					this.ultraCalendarInfo1.Owners.Remove( owner );
					this.InitializeOwnersPanel( false );
				}
			}
		}

		/// <summary>
		/// Handles the CheckedChanged event for the checkboxes which represent Owners.
		/// </summary>
		private void OwnerCheckbox_CheckedChanged( object sender, EventArgs e )
		{
			UltraCheckEditor checkEditor = sender as UltraCheckEditor;
			Owner owner = checkEditor.Tag as Owner;
			owner.Visible = checkEditor.Checked;
		}

		/// <summary>
		/// Handles the UltraCalendarInfo component's 'ValidateAppointment' event.
		/// </summary>
        private void ultraCalendarInfo1_ValidateAppointment(object sender, Infragistics.Win.EmployeeSchedule.ValidateAppointmentEventArgs e)
		{
			//	Make sure the number of bytes needed to serialize the Appointment
			//	does not exceed the size of the 'AllProperties' field.
			byte[] appointmentBytes = e.Appointment.Save();
			if ( appointmentBytes != null &&
				 appointmentBytes.Length > WinScheduleDatabaseSupportBase.MAX_APPOINTMENT_BYTES )
			{
				e.Message = "Appointment data exceeds size of the 'AllProperties' field.";
				e.CloseDialog = false;
			}
		}

		#endregion Event handlers

		#region Properties
			#region DatabaseSupport
		/// <summary>
		/// Returns an instance of the WinScheduleDatabaseSupportBase object
		/// that provides access to the Appointments and Owners tables.
		/// </summary>
		private WinScheduleDatabaseSupportBase DatabaseSupport
		{
			get
			{
				if ( this._databaseSupport == null )
				{
//#if DATABASE_SQLSERVER
					this._databaseSupport = new WinScheduleMSSQLServerSupport();
//#else
					//this._databaseSupport = new WinScheduleMSAccessSupport();
//#endif
				}
				return this._databaseSupport;
			}
		}
			#endregion DatabaseSupport

		#endregion Properties

		#region Methods

			#region InitializeUI
		/// <summary>
		/// Initialize the user interface by configuring controls, etc.
		/// </summary>
		private void InitializeUI()
		{
            
			//	Set the appointment grouping properties for the WinSchedule controls
			//	that support appointment grouping.
			this.ultraDayView1.GroupingStyle = DayViewGroupingStyle.OwnerWithinDate;
			this.ultraWeekView1.OwnerDisplayStyle = OwnerDisplayStyle.Separate;
			this.ultraWeekView1.MaximumOwnersInView = 2;
			this.ultraMonthViewSingle1.OwnerDisplayStyle = OwnerDisplayStyle.Separate;
			this.ultraMonthViewSingle1.MaximumOwnersInView = 2;

			//	Hide the unassigned owner
			this.ultraCalendarInfo1.Owners.UnassignedOwner.Visible = false;

            //	Set up data binding for Owners
            OwnersDataBinding ownersDataBinding = this.ultraCalendarInfo1.DataBindingsForOwners;
            ownersDataBinding.AllPropertiesMember = "ALLPROPERTIES";
            ownersDataBinding.NameMember = "Owner";
            //ownersDataBinding.NameMember = "ROOM_ID";
            ownersDataBinding.KeyMember = "EMP_ID";
            ownersDataBinding.VisibleMember = "VISIBLE";
            ownersDataBinding.SetDataBinding(this.DatabaseSupport.DataSet, WinScheduleDatabaseSupportBase.OWNERS_TABLE_NAME);
            ownersDataBinding.BindingContextControl = this;
            ownersDataBinding.BindingContext = this.BindingContext;
            
            //	Set up data binding for Appointments
            AppointmentsDataBinding appointmentsDataBinding = this.ultraCalendarInfo1.DataBindingsForAppointments;
            appointmentsDataBinding.AllPropertiesMember = "ALLPROPERTIES";
            appointmentsDataBinding.StartDateTimeMember = "START_TIME";
            appointmentsDataBinding.EndDateTimeMember = "END_TIME";
            appointmentsDataBinding.ScRateMember = "LOCATION";
            appointmentsDataBinding.SubjectMember = "SUBJECT";
            appointmentsDataBinding.ScCreatedByMember = "CREATED_BY";
            appointmentsDataBinding.ScOrgIDMember = "ORG_ID";
            appointmentsDataBinding.RefDoctorMember = "IMPORTANCE";
            appointmentsDataBinding.RefFromMember = "SCHEDULE_STATUS";
            appointmentsDataBinding.ScheduleDataMember = "DETAILS";
            //appointmentsDataBinding.RefFromMember = "BLOCK_REASON";
           
            //appointmentsDataBinding.ScRateMember = "RATE";
            appointmentsDataBinding.AllDayEventMember = "ALL_DAY_EVENT";
            appointmentsDataBinding.AccessionMember = "CATEGORY_ID";
            appointmentsDataBinding.OwnerKeyMember = "SCHEDULE_FOR";
            //appointmentsDataBinding.AccessionMember = "EXAM_ID";
            //appointmentsDataBinding.DescriptionMember = "CLINIC_TYPE";

			appointmentsDataBinding.SetDataBinding( this.DatabaseSupport.DataSet, WinScheduleDatabaseSupportBase.APPOINTMENTS_TABLE_NAME );
			appointmentsDataBinding.BindingContextControl = this;

			//	Handle the MouseDown event for the WinSchedule controls
			this.ultraDayView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinScheduleControl_MouseDown);
			this.ultraWeekView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinScheduleControl_MouseDown);
			this.ultraMonthViewSingle1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WinScheduleControl_MouseDown);
            
			//	Configure the context menu, and assign the context menu to
			//	each of the WinSchedule controls
			this.menuItem_ModifyOwner = new Infragistics.Win.IGControls.IGMenuItem( "Modify Owner", new EventHandler(this.OnContextMenuItemClick) );
			this.menuItem_RemoveOwner = new Infragistics.Win.IGControls.IGMenuItem( "Remove Owner", new EventHandler(this.OnContextMenuItemClick) );
			//this.contextMenu1.MenuItems.Add( this.menuItem_ModifyOwner );
			//this.contextMenu1.MenuItems.Add( this.menuItem_RemoveOwner );
			this.ultraDayView1.ContextMenu = this.contextMenu1;
			this.ultraWeekView1.ContextMenu = this.contextMenu1;
			this.ultraMonthViewSingle1.ContextMenu = this.contextMenu1;

			//	Add a checkbox for each owner in the collection to the Panel control
			this.InitializeOwnersPanel( false );

			//	Initialize the dialog for the current view
			if ( this.ultraCalendarLook1.ViewStyle == ViewStyle.Office2007 )
			{
				Office2007ColorScheme colorScheme = Infragistics.Win.Office2007ColorTable.ColorScheme;
				string toolKey = string.Format("menuMain_View_Office2007_{0}", colorScheme );
				if ( this.ultraToolbarsManager1.Tools.Exists(toolKey) )
				{
					ToolBase tool = this.ultraToolbarsManager1.Tools[toolKey];
					this.ultraToolbarsManager1_ToolClick( this.ultraToolbarsManager1, new ToolClickEventArgs(tool, null) );
					
					//	Reserve the default color schemes; we will assign them to
					//	the Owner that was initially present in the database table.
					Outlook2007ColorSchemeCollection colorSchemes = this.ultraCalendarLook1.Outlook2007ColorSchemes;
					colorSchemes.DisallowAutoAssignment( colorSchemes.BaseColorBlue );
					colorSchemes.DisallowAutoAssignment( colorSchemes.BaseColorBlack );
				}
			}

		}
			#endregion InitializeUI

			#region InitializeOwnersPanel
		/// <summary>
		/// Adds checkboxes to the pnlOwners Panel control when 'refreshOnly' is false;
		/// when 'refreshOnly' is true, the existing ones are refreshed.
		/// </summary>
		private void InitializeOwnersPanel( bool refreshOnly )
		{
			if ( refreshOnly )
			{
				for ( int i = 0; i < this.pnlOwners.Controls.Count; i ++ )
				{
					UltraCheckEditor checkEditor = this.pnlOwners.Controls[i] as UltraCheckEditor;
					if ( checkEditor != null )
					{
						Owner owner = checkEditor.Tag as Owner;
						if ( checkEditor.Text != owner.Name )
							checkEditor.Text = owner.Name;

						if ( checkEditor.Checked != owner.Visible )
							checkEditor.Checked = owner.Visible;

					}
				}
			}
			else
			{
				this.pnlOwners.Controls.Clear();

				for ( int i = 0; i < this.ultraCalendarInfo1.Owners.Count; i ++ )
				{
					Owner owner = this.ultraCalendarInfo1.Owners[i];
                    if (i > 0)
                    {
                        this.AddCheckboxForOwner(owner);
                    }
				}
			}
		}
			#endregion InitializeOwnersPanel

			#region AddCheckboxForOwner
		/// <summary>
		/// Adds an UltraCheckEditor control to the 'pnlOwners' control
		/// for the specified Owner.
		/// </summary>
		/// <param name="owner">The Owner for which a checkbox is to be added.</param>
		private void AddCheckboxForOwner( Owner owner )
		{
			int controlCount = this.pnlOwners.Controls.Count;
			int newTop = controlCount * 20;

			UltraCheckEditor checkEditor = new UltraCheckEditor();
			checkEditor.Text = owner.Name;
			checkEditor.Checked = owner.Visible;
			checkEditor.Tag = owner;
			checkEditor.Location = new Point( this.pnlOwners.Left + 2, newTop );
			checkEditor.Size = new Size( this.pnlOwners.Width - 5, 20 );
			this.pnlOwners.Controls.Add( checkEditor );
			checkEditor.BringToFront();
			checkEditor.CheckedChanged += new EventHandler( this.OwnerCheckbox_CheckedChanged );
		}
			#endregion AddCheckboxForOwner

			#region ShowScheduleControl
		/// <summary>
		/// Shows the specified UltraScheduleControlBase-derived control,
		/// and hides the others; also sets its Dock property to 'Fill'
		/// </summary>
		/// <param name="scheduleControl">The UltraScheduleControlBase-derived control to show.</param>
		private void ShowScheduleControl( UltraScheduleControlBase scheduleControl )
		{
			if ( scheduleControl != this.ultraDayView1 )
				this.ultraDayView1.Visible = false;

			if ( scheduleControl != this.ultraWeekView1 )
				this.ultraWeekView1.Visible = false;
	
			if ( scheduleControl != this.ultraMonthViewSingle1 )
				this.ultraMonthViewSingle1.Visible = false;

			scheduleControl.Visible = true;
			scheduleControl.Dock = DockStyle.Fill;
		}
			#endregion ShowScheduleControl

		#endregion Methods

	}
	#endregion frmMain class
}
