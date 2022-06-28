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
            bool flag = true;

            #region DataTemp
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("ORG_NAME",typeof(string));
            dtTemp.Columns.Add("HN", typeof(string));
            dtTemp.Columns.Add("TITLE", typeof(string));
            dtTemp.Columns.Add("FNAME", typeof(string));
            dtTemp.Columns.Add("MNAME", typeof(string));
            dtTemp.Columns.Add("LNAME", typeof(string));
            dtTemp.Columns.Add("TITLE_ENG", typeof(string));
            dtTemp.Columns.Add("FNAME_ENG", typeof(string));
            dtTemp.Columns.Add("MNAME_ENG", typeof(string));
            dtTemp.Columns.Add("LNAME_ENG", typeof(string));
            dtTemp.Columns.Add("DOB", typeof(DateTime));
            dtTemp.Columns.Add("EXAM_UID", typeof(string));
            dtTemp.Columns.Add("EXAM_NAME", typeof(string));
            dtTemp.Columns.Add("APPOINT_DT", typeof(DateTime));
            dtTemp.Columns.Add("RATE");
            dtTemp.Columns.Add("CLINIC_TYPE_TEXT", typeof(string));
            dtTemp.Columns.Add("MODALITY_NAME", typeof(string));
            dtTemp.Columns.Add("CREATED_BY");
            dtTemp.Columns.Add("CREATED_ON", typeof(DateTime));
            dtTemp.Columns.Add("ORG_IMG");
            dtTemp.Columns.Add("ORG_ADDR3", typeof(string));
            dtTemp.Columns.Add("ORG_ADDR4", typeof(string));
            dtTemp.Columns.Add("MODALITY_ID", typeof(int));
            dtTemp.Columns.Add("VENDOR_H2", typeof(string));
            dtTemp.Columns.Add("INS_TEXT", typeof(string));
            dtTemp.Columns.Add("EXAM_TYPE_INS", typeof(string));
            dtTemp.Columns.Add("HR_UNIT_INS", typeof(string));
            dtTemp.Columns.Add("UNIT_NAME", typeof(string));
            dtTemp.Columns.Add("UNIT_TITLE", typeof(string));
            dtTemp.Columns.Add("CLAIMABLE_AMT");
            dtTemp.Columns.Add("NONCLAIMABLE_AMT");
            dtTemp.Columns.Add("AGE", typeof(string));
            dtTemp.Columns.Add("GENDER", typeof(string));
            dtTemp.Columns.Add("ROOM_UID", typeof(string));
            dtTemp.Columns.Add("INSURANCE_TYPE_DESC", typeof(string));
            dtTemp.AcceptChanges(); 
            #endregion

            DataTable dts = new DataTable();

            //foreach(DataRow row in dtData.Rows)
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    if (dtData.Rows[i]["CHK"].ToString().Trim() == "Y")
                    {
                        ReportParameters spara = new ReportParameters();
                        spara.ScheduleID = Convert.ToInt32(dtData.Rows[i]["SCHEDULE_ID"].ToString());
                        spara.PatientId = dtData.Rows[i]["HN"].ToString();
                        spara.AppointDate = Convert.ToDateTime(dtData.Rows[i]["START_DATETIME"].ToString());
                        spara.ModalityId = Convert.ToInt32(dtData.Rows[i]["MODALITY_ID"].ToString());
                        ProcessScheduleReport slkp = new ProcessScheduleReport();
                        slkp.ReportParameters = spara;
                        slkp.Invoke();
                        dts = slkp.ResultSet.Tables[0];

                        #region Add Datatemp
                            DataRow drTemp = dtTemp.NewRow();
                            drTemp["ORG_NAME"] = dts.Rows[i]["ORG_NAME"].ToString();
                            drTemp["HN"] = dts.Rows[i]["HN"].ToString();
                            drTemp["TITLE"] = dts.Rows[i]["TITLE"].ToString();
                            drTemp["FNAME"] = dts.Rows[i]["FNAME"].ToString();
                            drTemp["MNAME"] = dts.Rows[i]["MNAME"].ToString();
                            drTemp["LNAME"] = dts.Rows[i]["LNAME"].ToString();
                            drTemp["TITLE_ENG"] = dts.Rows[i]["TITLE_ENG"].ToString();
                            drTemp["FNAME_ENG"] = dts.Rows[i]["FNAME_ENG"].ToString();
                            drTemp["MNAME_ENG"] = dts.Rows[i]["MNAME_ENG"].ToString();
                            drTemp["LNAME_ENG"] = dts.Rows[i]["LNAME_ENG"].ToString();
                            drTemp["DOB"] = Convert.ToDateTime(dts.Rows[i]["DOB"].ToString());
                            drTemp["EXAM_UID"] = dts.Rows[i]["EXAM_UID"].ToString();
                            drTemp["EXAM_NAME"] = dts.Rows[i]["EXAM_NAME"].ToString();
                            drTemp["APPOINT_DT"] = Convert.ToDateTime(dts.Rows[i]["APPOINT_DT"]);
                            drTemp["RATE"] = Convert.ToInt32(dts.Rows[i]["RATE"]).ToString("#,##0");
                            drTemp["CLINIC_TYPE_TEXT"] = dts.Rows[i]["CLINIC_TYPE_TEXT"].ToString();
                            drTemp["MODALITY_NAME"] = dts.Rows[i]["MODALITY_NAME"].ToString();
                            drTemp["CREATED_BY"] = dts.Rows[i]["CREATED_BY"];
                            drTemp["CREATED_ON"] = Convert.ToDateTime(dts.Rows[i]["CREATED_ON"].ToString()).ToString("dd/MM/yyyy HH:mm");
                            drTemp["ORG_IMG"] = dts.Rows[i]["ORG_IMG"].ToString();
                            drTemp["ORG_ADDR3"] = dts.Rows[i]["ORG_ADDR3"].ToString();
                            drTemp["ORG_ADDR4"] = dts.Rows[i]["ORG_ADDR4"].ToString();
                            drTemp["MODALITY_ID"] = dts.Rows[i]["MODALITY_ID"].ToString();
                            drTemp["VENDOR_H2"] = dts.Rows[i]["VENDOR_H2"].ToString();
                            drTemp["INS_TEXT"] = dts.Rows[i]["INS_TEXT"].ToString();
                            drTemp["EXAM_TYPE_INS"] = dts.Rows[i]["EXAM_TYPE_INS"].ToString();
                            drTemp["HR_UNIT_INS"] = dts.Rows[i]["HR_UNIT_INS"].ToString();
                            drTemp["UNIT_NAME"] = dts.Rows[i]["UNIT_NAME"].ToString();
                            drTemp["AGE"] = dts.Rows[i]["AGE"].ToString();
                            drTemp["GENDER"] = dts.Rows[i]["GENDER"].ToString();
                            drTemp["UNIT_TITLE"] = dts.Rows[i]["UNIT_TITLE"].ToString();
                            drTemp["CLAIMABLE_AMT"] = 0;// Convert.ToInt32(dts.Rows[i]["CLAIMABLE_AMT"]).ToString("#,##0");
                            drTemp["NONCLAIMABLE_AMT"] = 0; // Convert.ToInt32(dts.Rows[i]["NONCLAIMABLE_AMT"]).ToString("#,##0");
                            drTemp["ROOM_UID"] = dts.Rows[i]["ROOM_UID"].ToString();
                            drTemp["INSURANCE_TYPE_DESC"] = dts.Rows[i]["INSURANCE_TYPE_DESC"].ToString();
                            dtTemp.Rows.Add(drTemp);
                            dtTemp.AcceptChanges();
                       
                        #endregion

                        flag = false;
                        //break;
                    }
                }
            if (flag) {
                //UID1035
                msg.ShowAlert("UID1035", env.CurrentLanguageID);
                return;
            }
            //Print here.

            #region Print 

            ProcessGetRISExam geExam = new ProcessGetRISExam(true);
            geExam.Invoke();
            DataRow[] drExam = geExam.Result.Tables[0].Select("EXAM_UID='" + dtTemp.Rows[0]["EXAM_UID"].ToString()+"'");
            if (!string.IsNullOrEmpty(drExam[0]["UNIT_ID"].ToString()))
            {
                if (drExam[0]["UNIT_ID"].ToString() == "2")
                {
                    //if (dtTemp.Rows[0]["UNIT_NAME"].ToString().Contains("OER101"))
                    if (dtTemp.Rows[0]["MODALITY_ID"].ToString().Contains("91"))
                    {
                        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                        print.ScheduleDirectPrintMultiER(dtTemp);
                    }
                    else
                    {
                        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                        print.ScheduleDirectPrintMultiAIMC(dtTemp);
                    }
                }
                else
                {
                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                    print.ScheduleDirectPrintMulti(dtTemp);
                }
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