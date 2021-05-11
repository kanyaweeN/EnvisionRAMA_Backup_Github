using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using RIS.Common;
//using RIS.Common.Common;
//using RIS.BusinessLogic;
//using RIS.Forms.GBLMessage;
//using RIS.Operational.CRFile;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
namespace Envision.NET.Forms.Schedule
{
    public partial class frmMultiplePrint : DevExpress.XtraBars.Ribbon.RibbonForm
    {
       
        private bool PreItemflag = false;
        private Graphics Grp;
        private Rectangle Rta; 
        private RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
      
        private DataTable dtData;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();

        public frmMultiplePrint()
        {
            InitializeComponent();
        }
        public frmMultiplePrint(int ScheduleID)
        {
            InitializeComponent();

            dtData = new DataTable();
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            process.RIS_SCHEDULE.SCHEDULE_ID = ScheduleID;
            dtData = process.GetMultiPrint();
            if (dtData != null)
            {
                if (!string.IsNullOrEmpty(dtData.Rows[0]["HN"].ToString()))
                {
                    txtHN.Text = dtData.Rows[0]["HN"].ToString();
                    txtPatientName.Text = dtData.Rows[0]["PATIENTNAME"].ToString();
                    grdData.DataSource = dtData;
                }
            }

            loadDataToGrid();
        }
        private string SelectName(string HN)
        {
            return "";
            //ProcessGetHISRegistration geHis = new ProcessGetHISRegistration(HN);
            //geHis.Invoke();
            //DataTable dt = geHis.Result.Tables[0];
            //return dt.Rows[0]["FNAME"].ToString() +" "+ dt.Rows[0]["LNAME"].ToString();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ProcessScheduleReport slkp = new ProcessScheduleReport();
            slkp.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(dtData.Rows[0]["SCHEDULE_ID"].ToString());
            slkp.RIS_SCHEDULE.ORG_ID = env.OrgID;
            slkp.getReport();
            DataSet ds = slkp.ResultSet;
            if(ds.Tables.Count>1)
                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow[] chkRow = dtData.Select("CHK='N'");
                    for (int i = 0; i < chkRow.Length; i++)
                    {
                        DataRow[] removeRow = ds.Tables[1].Select("EXAM_UID='" + chkRow[i]["EXAM_UID"].ToString()+"'");
                        if (removeRow.Length > 0)
                        {
                            ds.Tables[1].Rows.Remove(removeRow[0]);
                            ds.Tables[1].AcceptChanges();
                        }
                    }
                }

            #region Print

            if (ds.Tables.Count > 1)
                if (ds.Tables[1].Rows.Count > 0)
                {
                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                    print.AppointmentDirectPrintMulti(ds, ds.Tables[1].Rows[0]["PAT_DEST_LABEL"].ToString());
                }

            #endregion

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
        private string getdefaultprinter()
        {
            string printername;
            PrintDocument getprintername = new PrintDocument();
            printername = getprintername.PrinterSettings.PrinterName;
            return printername;
        }
        private void loadDataToGrid() {
            for (int i = 1; i < dtData.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["START_DATETIME"].Visible = true;
            view1.Columns["START_DATETIME"].Caption = "Start";
            view1.Columns["START_DATETIME"].ColVIndex = 2;
            view1.Columns["START_DATETIME"].OptionsColumn.AllowEdit = false;
            DevExpress.XtraGrid.Columns.GridColumn gc = view1.Columns["START_DATETIME"];
            gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gc.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            view1.Columns["START_DATETIME"].BestFit();
            //view1.Columns["START_DATETIME"].Width = 80;

            view1.Columns["END_DATETIME"].Visible = true;
            view1.Columns["END_DATETIME"].Caption = "End";
            view1.Columns["END_DATETIME"].ColVIndex = 3;
            //view1.Columns["END_DATETIME"].Width = 80;
            view1.Columns["END_DATETIME"].OptionsColumn.AllowEdit = false;
            gc = view1.Columns["END_DATETIME"];
            gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gc.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            view1.Columns["END_DATETIME"].BestFit();

            view1.Columns["MODALITY_NAME"].Visible = true;
            view1.Columns["MODALITY_NAME"].Caption = "Modality";
            view1.Columns["MODALITY_NAME"].ColVIndex = 4;
            view1.Columns["MODALITY_NAME"].Width = 100;
            view1.Columns["MODALITY_NAME"].OptionsColumn.AllowEdit = false;

            view1.Columns["EXAM_UID"].Visible = true;
            view1.Columns["EXAM_UID"].Caption = "Exam Code";
            view1.Columns["EXAM_UID"].ColVIndex = 5;
            view1.Columns["EXAM_UID"].Width = 80;
            view1.Columns["EXAM_UID"].OptionsColumn.AllowEdit = false;

            view1.Columns["EXAM_NAME"].Visible = true;
            view1.Columns["EXAM_NAME"].Caption = "Exam Name";
            view1.Columns["EXAM_NAME"].ColVIndex = 6;
            view1.Columns["EXAM_NAME"].BestFit();
            view1.Columns["EXAM_NAME"].OptionsColumn.AllowEdit = false;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.Click += new EventHandler(chk_Click);
            view1.Columns["CHK"].ColumnEdit = chk;
            view1.Columns["CHK"].BestFit();
            view1.Columns["CHK"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view1.Columns["CHK"].Name = "CHK";
            view1.Columns["CHK"].Caption = " ";
            view1.Columns["CHK"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view1.Columns["CHK"].Visible = true;
            view1.Columns["CHK"].ColVIndex = 1;


          
        }
        private void chk_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            dtData = (DataTable)grdData.DataSource;
            dtData.Rows[view1.FocusedRowHandle]["CHK"] = chk.Checked ? "N" : "Y";
            dtData.AcceptChanges();
            grdData.DataSource = dtData;
        }

        private void view1_Click(object sender, EventArgs e)
        {
            GridHitInfo info;

            Point pt = view1.GridControl.PointToClient(Control.MousePosition);
            info = view1.CalcHitInfo(pt);
            if (info.InColumn)
            {
                if (info.Column == null) return;
                if (info.Column.Name == "CHK")
                {
                    dtData = (DataTable)grdData.DataSource;
                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        dtData.Rows[i]["CHK"] = PreItemflag ? "N" : "Y";
                    }
                    grdData.DataSource = dtData;
                    PreItemflag = !PreItemflag;
                }
            }
        }
        private void view1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            if (e.Column.Name == "CHK")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, PreItemflag);
                e.Handled = true;
                Grp = e.Graphics;
                Rta = e.Bounds;
            }
        }
        private void DrawCheckBox(Graphics g, Rectangle r, bool chk)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;

            info = (DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)edit.CreateViewInfo();
            painter = (DevExpress.XtraEditors.Drawing.CheckEditPainter)edit.CreatePainter();
            info.EditValue = chk;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);

            painter.Draw(args);
            args.Cache.Dispose();
        }
    }
}