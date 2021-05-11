using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using System.Windows.Controls;
using System.Web.UI.WebControls;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.OleDb;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Envision.NET.Forms.Dialog;
using Envision.Common;

namespace Envision.NET.Forms.Admin
{
    
    public partial class frmHrUnitSetup : MasterForm
    {
        private DataTable dtGrid = new DataTable();
        private int unitID;
        private int CountdtSet;
        private ProcessGetHRUnit getHRUnit;
        private ProcessAddHRUnit_forExcel addHRUnit;
        private ProcessUpdateHRUnit_forExcel updateHRUnit;
        private ProcessDeleteHRUnit_forExcel deleteHRUnit;
        private ProcessGetCountHRUnit countHRUnit;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();

        public frmHrUnitSetup()
        {
            InitializeComponent();
        }

        private void frmHrUnitSetup_Load(object sender, EventArgs e)
        {
            getHRUnit = new ProcessGetHRUnit();
            getHRUnit.Invoke();
            dtGrid = getHRUnit.Result.Tables[0];
            dtGrid.Columns.Add("DELETED");
            dtGrid.Columns.Add("UPDATED");
            dtGrid.AcceptChanges();
            txt_BrowseExcel.Enabled = false;
            btn_Browse.Enabled = true;
            btn_Save.Enabled = false;
            gv_GetData.DataSource = dtGrid;
            loadViewTable();        
            
            base.CloseWaitDialog();
        }

        private void loadViewTable()
        {
            for (int i = 0; i < view_GetData.Columns.Count; i++)
            {
                view_GetData.Columns[i].Visible = false;
            }

            view_GetData.Columns["UNIT_ID"].VisibleIndex = 0;
            view_GetData.Columns["UNIT_ID"].Visible = false;

            view_GetData.Columns["UNIT_UID"].VisibleIndex = 1;
            view_GetData.Columns["UNIT_UID"].Caption = "UnitCode";
            //view_GetData.Columns["UNIT_UID"].Width = 100;

            view_GetData.Columns["UNIT_NAME"].VisibleIndex = 2;
            view_GetData.Columns["UNIT_NAME"].Caption = "UnitName";
            //view_GetData.Columns["UNIT_NAME"].Width = 100;

            //view_GetData.Columns["UNIT_ALIAS"].VisibleIndex = 3;
            //view_GetData.Columns["UNIT_ALIAS"].Caption = "Unit Alias";
            //view_GetData.Columns["UNIT_ALIAS"].Width = 100;
            view_GetData.Columns["PHONE_NO"].VisibleIndex = 4;
            view_GetData.Columns["PHONE_NO"].Caption = "Phone";
            //view_GetData.Columns["PHONE_NO"].Width = 100;

            view_GetData.Columns["UNIT_NAME_ALIAS"].VisibleIndex = 5;
            view_GetData.Columns["UNIT_NAME_ALIAS"].Caption = "Place";
            //view_GetData.Columns["UNIT_NAME_ALIAS"].Width = 100;

            view_GetData.Columns["DESCR"].VisibleIndex = 6;
            view_GetData.Columns["DESCR"].Caption = "Description";
            //view_GetData.Columns["DESCR"].Width = 100;

            view_GetData.Columns["UNIT_PARENT_NAME"].VisibleIndex = 7;
            view_GetData.Columns["UNIT_PARENT_NAME"].Caption = "ParentName";

            view_GetData.Columns["LOC_ALIAS"].VisibleIndex = 8;
            view_GetData.Columns["LOC_ALIAS"].Caption = "LocationAlise";
            //view_GetData.Columns["LOC_ALIAS"].Width = 100;

            view_GetData.Columns["LOC"].VisibleIndex = 9;
            view_GetData.Columns["LOC"].Caption = "Location";
            //view_GetData.Columns["UNIT_PARENT_NAME"].Width = 100;

            //#region Repository Delete
            //DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDel = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            //btnDel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            //btnDel.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            //btnDel.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //btnDel.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnDel_ButtonClick);
            //#endregion

            //view_GetData.Columns["DELETED"].VisibleIndex = 9;
            //view_GetData.Columns["DELETED"].Caption = " ";
            //view_GetData.Columns["DELETED"].ColumnEdit = btnDel;
            //view_GetData.Columns["DELETED"].Width = 30;

            txt_BrowseExcel.Text = string.Empty;
        }

        private void btnDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow dr = view_GetData.GetDataRow(view_GetData.FocusedRowHandle);
            deleteHRUnit = new ProcessDeleteHRUnit_forExcel();
            deleteHRUnit.HR_UNIT.UNIT_ID = Convert.ToInt32(dr[0]);
            deleteHRUnit.Invoke();

            getHRUnit = new ProcessGetHRUnit();
            getHRUnit.Invoke();
            dtGrid = getHRUnit.Result.Tables[0];
            dtGrid.Columns.Add("DELETED");
            dtGrid.Columns.Add("UPDATED");
            dtGrid.AcceptChanges();

            gv_GetData.DataSource = dtGrid;
            loadViewTable();
        }

        private void btn_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel_Insert.Visible = true;
            panel_Insert.Enabled = true;
            txt_BrowseExcel.Text = String.Empty;
            
            txt_BrowseExcel.Enabled = false;
            btn_Save.Enabled = true;
            btn_Browse.Enabled = false;
            //btn_OKUpdate.Visible = false;
            btn_OKUpdate.Enabled = false;
            unitID = 0;

            txt_UNIT_UID.Text = String.Empty;
            txt_UNIT_NAME.Text = String.Empty;
            txt_DESCR.Text = String.Empty;
            txt_LOC_ALIAS.Text = String.Empty;
            txt_PHONE_NO.Text = String.Empty;
            txt_UNIT_NAME_ALIAS.Text = String.Empty;
            txt_UNIT_PARENT_NAME.Text = String.Empty;

            dtGrid.Rows.Clear();
            dtGrid.AcceptChanges();
        }

        private void view_GetData_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void view_GetData_Click(object sender, EventArgs e)
        {
            btn_OKUpdate.Enabled = true;
            if (view_GetData.FocusedRowHandle < -1) return;
            DataRow row = view_GetData.GetDataRow(view_GetData.FocusedRowHandle);
            if (row["UNIT_ID"] is DBNull)
            { }
            else
            { unitID = Convert.ToInt32(row["UNIT_ID"]); }

            string unit_UID = row["UNIT_UID"].ToString();
            string unit_NAME = row["UNIT_NAME"].ToString();
            string unit_ALIAS = row["UNIT_ALIAS"].ToString();
            string unit_NAME_ALIAS = row["UNIT_NAME_ALIAS"].ToString();
            string unit_PHONE_NO = row["PHONE_NO"].ToString();
            string unit_DESCR = row["DESCR"].ToString();
            string unit_LOC = row["LOC"].ToString();
            string unit_LOC_ALIAS = row["LOC_ALIAS"].ToString();
            string unit_PARENT_NAME = row["UNIT_PARENT_NAME"].ToString();

            panel_Insert.Visible = true;
            panel_Insert.Enabled = true;
            txt_UNIT_UID.Text = unit_UID;
            txt_UNIT_NAME.Text = unit_NAME;
            txtUnitAlias.Text = unit_ALIAS;
            txt_UNIT_NAME_ALIAS.Text = unit_NAME_ALIAS;
            txt_PHONE_NO.Text = unit_PHONE_NO;
            txt_DESCR.Text = unit_DESCR;
            txt_LOC.Text = unit_LOC;
            txt_LOC_ALIAS.Text = unit_LOC_ALIAS;
            txt_UNIT_PARENT_NAME.Text = unit_PARENT_NAME;
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        { 
            OpenFileDialog browsedFile = new OpenFileDialog();
            browsedFile.Filter = "Excel Files (.xls)|*.xls| Excel Files(.xlsx)|*.xlsx| Excel Files(*.xlsm)|*.xlsm";
            browsedFile.ShowDialog();
            txt_BrowseExcel.Text = browsedFile.FileName;
            


            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            System.Data.DataSet DtSet;

            string strConnection = string.Format(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;", browsedFile.FileName);
            MyConnection = new System.Data.OleDb.OleDbConnection(strConnection);
            if (browsedFile.FileName != "")
            { 
                MyConnection.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = MyConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                MyConnection.Close();



                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + SheetName + "]", MyConnection);
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);

                CountdtSet = DtSet.Tables[0].Rows.Count;


                dtGrid.Rows.Clear();
                dtGrid.AcceptChanges();
                dtGrid.BeginLoadData();
                for (int i = 0; i < CountdtSet; i++)
                {
                    var ds_UnitUID = DtSet.Tables[0].Rows[i][0];
                    var ds_UnitName = DtSet.Tables[0].Rows[i][1];
                    var ds_UnitPlaceID = DtSet.Tables[0].Rows[i][2];
                    var ds_UnitPlaceName = DtSet.Tables[0].Rows[i][3];
                    var ds_UnitTel1 = DtSet.Tables[0].Rows[i][4];
                    var ds_UnitTel2 = DtSet.Tables[0].Rows[i][5];
                    var ds_UnitEffStdate = DtSet.Tables[0].Rows[i][6];
                    var ds_UnitEffEnddate = DtSet.Tables[0].Rows[i][7];
                    var ds_UnitCostID = DtSet.Tables[0].Rows[i][8];

                    DataRow rowAdd = dtGrid.NewRow();
                    rowAdd["UNIT_UID"] = ds_UnitUID;
                    rowAdd["UNIT_NAME"] = ds_UnitName;
                    rowAdd["UNIT_NAME_ALIAS"] = ds_UnitPlaceID;
                    rowAdd["DESCR"] = ds_UnitPlaceName;                   
                    rowAdd["PHONE_NO"] = ds_UnitTel1.ToString() + ',' + ds_UnitTel2.ToString();
                    rowAdd["LOC"]       = null;
                    rowAdd["LOC_ALIAS"] = null;
                    rowAdd["UNIT_PARENT_NAME"] = null;
                    dtGrid.Rows.Add(rowAdd);
                    dtGrid.AcceptChanges();
                    btn_Save.Enabled = true;
                }

                dtGrid.EndLoadData();
                unitID = 0;
            }
        }

        private void view_GetData_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        { }

        private void btn_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (unitID>0)
            {
                getHRUnit = new ProcessGetHRUnit();
            getHRUnit.Invoke();
            //getHRUnit.HR_UNIT.UNIT_ID();

            countHRUnit = new ProcessGetCountHRUnit();
            countHRUnit.HR_UNIT.UNIT_UID = txt_UNIT_UID.Text;
            countHRUnit.Invoke();
            int resultCount = Convert.ToInt32(countHRUnit.Result.Tables[0].Rows[0][0]);

            DataRow row = view_GetData.GetDataRow(view_GetData.FocusedRowHandle); // กรณีอัพเดท
            string unit_UIDO = row["UNIT_UID"].ToString(); ;
            string unit_UIDN = txt_UNIT_UID.Text;
            if (resultCount > 0 && unit_UIDO != unit_UIDN)
            {
                string s = string.Empty;
                s = msg.ShowAlert("UID7002", env.CurrentLanguageID);
            }
            else
            {
               // if (dtGrid.Rows[21] == 'U')
               // var iiii = dtGrid.Select;  //// เลือก เอา colum  ที่มี updated ออกมา แล้วจะออัพเดทได้   ใ.... มีปุ่มลบด้วย เคนะ

                int countRows = dtGrid.Rows.Count;

                var cou = dtGrid.Rows[0].RowState;

                var dts = dtGrid.AsEnumerable().Where(r => r.RowState == DataRowState.Modified).CopyToDataTable<DataRow>();

                foreach (DataRow r in dts.Rows)
                {
                    updateHRUnit = new ProcessUpdateHRUnit_forExcel();
                    updateHRUnit.HR_UNIT.UNIT_ID            = r.Field<int>("UNIT_ID");
                    updateHRUnit.HR_UNIT.UNIT_UID           = (r["UNIT_UID"] is System.DBNull) ? "NULL" : r.Field<string>("UNIT_UID");
                    updateHRUnit.HR_UNIT.UNIT_ID_PARENT     = (r["UNIT_ID_PARENT"] is System.DBNull) ? 0 : r.Field<int>("UNIT_ID_PARENT");
                    updateHRUnit.HR_UNIT.UNIT_NAME          = (r["UNIT_NAME"] is System.DBNull) ? "NULL" : r.Field<string>("UNIT_NAME");
                    updateHRUnit.HR_UNIT.UNIT_NAME_ALIAS    = (r["UNIT_NAME_ALIAS"] is System.DBNull) ? "NULL" : r.Field<string>("UNIT_NAME_ALIAS");
                    updateHRUnit.HR_UNIT.PHONE_NO           = (r["PHONE_NO"] is System.DBNull) ? "NULL" : r.Field<string>("PHONE_NO");
                    updateHRUnit.HR_UNIT.DESCR              = (r["DESCR"] is System.DBNull) ? "NULL" : r.Field<string>("DESCR");
                    updateHRUnit.HR_UNIT.UNIT_ALIAS         = (r["UNIT_ALIAS"] is System.DBNull) ? "NULL" : r.Field<string>("UNIT_ALIAS");
                    //updateHRUnit.HR_UNIT.UNIT_TYPE          = (r["UNIT_TYPE"] is System.DBNull) ? '0' : r.Field<char>("UNIT_TYPE");
                    updateHRUnit.HR_UNIT.UNIT_INS           = (r["UNIT_INS"] is System.DBNull) ? "NULL" : r.Field<string>("UNIT_INS");
                    updateHRUnit.HR_UNIT.IS_EXTERNAL        = 'Y'; //(r["IS_EXTERNAL"] is System.DBNull) ? 'Y' : r.Field<Char>("IS_EXTERNAL");
                    updateHRUnit.HR_UNIT.LOC                = (r["LOC"] is System.DBNull) ? "NULL" : r.Field<string>("LOC");
                    updateHRUnit.HR_UNIT.LAST_MODIFIED_BY   = (r["LAST_MODIFIED_BY"] is System.DBNull) ? 0 : r.Field<int>("LAST_MODIFIED_BY");
                    updateHRUnit.HR_UNIT.ORG_ID             = (r["ORG_ID"] is System.DBNull) ? 1 : r.Field<int>("ORG_ID");
                    updateHRUnit.HR_UNIT.LOC_ALIAS          = (r["LOC_ALIAS"] is System.DBNull) ? "NULL" : r.Field<string>("LOC_ALIAS");
                    updateHRUnit.HR_UNIT.UNIT_PARENT_NAME = (r["UNIT_PARENT_NAME"] is System.DBNull) ? "NULL" : r.Field<string>("UNIT_PARENT_NAME");
                    updateHRUnit.Invoke();
                }
                string s = string.Empty;
                s = msg.ShowAlert("UID7001", env.CurrentLanguageID);
                getHRUnit = new ProcessGetHRUnit();
                getHRUnit.Invoke();
                dtGrid = getHRUnit.Result.Tables[0];
                dtGrid.Columns.Add("DELETED");
                dtGrid.Columns.Add("UPDATED");
                dtGrid.AcceptChanges();

                gv_GetData.DataSource = dtGrid;
                loadViewTable();

                panel_Insert.Visible = false;
                panel_Insert.Enabled = false;
                txt_UNIT_UID.Text = String.Empty;
                txt_UNIT_NAME.Text = String.Empty;
                txt_DESCR.Text = String.Empty;
                txt_LOC_ALIAS.Text = String.Empty;
                txt_PHONE_NO.Text = String.Empty;
                txt_UNIT_NAME_ALIAS.Text = String.Empty;
                txt_UNIT_PARENT_NAME.Text = String.Empty;
            }
            }
            else
            {
                if (txt_BrowseExcel.Text == null || txt_BrowseExcel.Text == "")
                {
                    if (txt_UNIT_UID.Text == "" || txt_UNIT_UID.Text == null)
                    {
                        string s = string.Empty;
                        s = msg.ShowAlert("UID7003", env.CurrentLanguageID);
                    }
                    else
                    {
                        countHRUnit = new ProcessGetCountHRUnit();
                        countHRUnit.HR_UNIT.UNIT_UID = txt_UNIT_UID.Text;
                        countHRUnit.Invoke();
                        int resultCount = Convert.ToInt32(countHRUnit.Result.Tables[0].Rows[0][0]);

                        if (resultCount > 0)
                        {
                            string s = string.Empty;
                            s = msg.ShowAlert("UID7002", env.CurrentLanguageID);
                        }
                        else
                        {
                            addHRUnit = new ProcessAddHRUnit_forExcel();
                            addHRUnit.HR_UNIT.UNIT_UID = txt_UNIT_UID.Text;
                            addHRUnit.HR_UNIT.UNIT_NAME = txt_UNIT_NAME.Text;
                            addHRUnit.HR_UNIT.UNIT_ALIAS = txtUnitAlias.Text;
                            addHRUnit.HR_UNIT.UNIT_NAME_ALIAS = txt_UNIT_NAME_ALIAS.Text;
                            addHRUnit.HR_UNIT.PHONE_NO = txt_PHONE_NO.Text;
                            addHRUnit.HR_UNIT.DESCR = txt_DESCR.Text;
                            addHRUnit.HR_UNIT.LOC_ALIAS = txt_LOC_ALIAS.Text;
                            addHRUnit.HR_UNIT.LOC = txt_LOC.Text;
                            addHRUnit.HR_UNIT.UNIT_PARENT_NAME = txt_UNIT_PARENT_NAME.Text;
                            addHRUnit.HR_UNIT.UNIT_ID_PARENT = null;
                            addHRUnit.HR_UNIT.UNIT_TYPE = null;
                            addHRUnit.HR_UNIT.UNIT_INS = null;
                            addHRUnit.HR_UNIT.IS_EXTERNAL = 'Y';
                            addHRUnit.HR_UNIT.CREATED_BY = env.UserID;
                            addHRUnit.HR_UNIT.ORG_ID = env.OrgID;

                            addHRUnit.Invoke();

                            string s = string.Empty;
                            s = msg.ShowAlert("UID7000", env.CurrentLanguageID);
                            getHRUnit = new ProcessGetHRUnit();
                            getHRUnit.Invoke();
                            dtGrid = getHRUnit.Result.Tables[0];
                            dtGrid.Columns.Add("DELETED");
                            dtGrid.Columns.Add("UPDATED");
                            dtGrid.AcceptChanges();

                            gv_GetData.DataSource = dtGrid;
                            loadViewTable();

                            panel_Insert.Visible = false;
                            panel_Insert.Enabled = false;
                            txt_UNIT_UID.Text = String.Empty;
                            txt_UNIT_NAME.Text = String.Empty;
                            txtUnitAlias.Text = String.Empty;
                            txt_UNIT_PARENT_NAME.Text = String.Empty;
                            txt_PHONE_NO.Text = String.Empty;
                            txt_DESCR.Text = String.Empty;
                            txt_LOC.Text = String.Empty;
                            txt_LOC_ALIAS.Text = String.Empty;
                            txt_UNIT_NAME_ALIAS.Text = String.Empty;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < CountdtSet; i++)
                    {
                        var ds_UnitUID = dtGrid.Rows[i][1];
                        var ds_UnitName = dtGrid.Rows[i][3];
                        var ds_UnitAlias = dtGrid.Rows[i][4];
                        var ds_UnitTel1 = dtGrid.Rows[i][5];
                        var ds_UnitDESCR = dtGrid.Rows[i][6];
                        var ds_UnitLOC = dtGrid.Rows[i][9];
                        var ds_UnitLOCAlias = dtGrid.Rows[i][15];
                        var ds_UnitParentname = dtGrid.Rows[i][16];
                        

                        //var oi = dtGrid.Rows

                        addHRUnit = new ProcessAddHRUnit_forExcel();
                        addHRUnit.HR_UNIT.UNIT_UID = txt_UNIT_UID.Text;
                        addHRUnit.HR_UNIT.UNIT_NAME = txt_UNIT_NAME.Text;
                        addHRUnit.HR_UNIT.UNIT_ALIAS = txtUnitAlias.Text;
                        addHRUnit.HR_UNIT.UNIT_NAME_ALIAS = txt_UNIT_NAME_ALIAS.Text;
                        addHRUnit.HR_UNIT.PHONE_NO = txt_PHONE_NO.Text;
                        addHRUnit.HR_UNIT.DESCR = txt_DESCR.Text;
                        addHRUnit.HR_UNIT.LOC_ALIAS = txt_LOC_ALIAS.Text;
                        addHRUnit.HR_UNIT.LOC = txt_LOC.Text;
                        addHRUnit.HR_UNIT.UNIT_PARENT_NAME = txt_UNIT_PARENT_NAME.Text;
                        addHRUnit.HR_UNIT.UNIT_ID_PARENT = null;
                        addHRUnit.HR_UNIT.UNIT_TYPE = null;
                        addHRUnit.HR_UNIT.UNIT_INS = null;
                        addHRUnit.HR_UNIT.IS_EXTERNAL = 'Y';
                        addHRUnit.HR_UNIT.CREATED_BY = env.UserID;
                        addHRUnit.HR_UNIT.ORG_ID = env.OrgID;
                        addHRUnit.Invoke();
                    }
                    dtGrid.EndLoadData();

                    string s = string.Empty;
                    s = msg.ShowAlert("UID7000", env.CurrentLanguageID);
                    getHRUnit = new ProcessGetHRUnit();
                    getHRUnit.Invoke();
                    dtGrid = getHRUnit.Result.Tables[0];
                    dtGrid.Columns.Add("DELETED");
                    dtGrid.Columns.Add("UPDATED");
                    dtGrid.AcceptChanges();

                    gv_GetData.DataSource = dtGrid;
                    loadViewTable();

                    panel_Insert.Visible = false;
                    panel_Insert.Enabled = false;
                    txt_UNIT_UID.Text = String.Empty;
                    txt_UNIT_NAME.Text = String.Empty;
                    txt_DESCR.Text = String.Empty;
                    txt_LOC_ALIAS.Text = String.Empty;
                    txt_PHONE_NO.Text = String.Empty;
                    txt_UNIT_NAME_ALIAS.Text = String.Empty;
                    txt_UNIT_PARENT_NAME.Text = String.Empty;
                    txt_LOC.Text = String.Empty;
                }
            }
            
        }

        private void btn_OKUpdate_Click(object sender, EventArgs e)
        {
            if (view_GetData.FocusedRowHandle >= 0) {
                DataRow row = view_GetData.GetDataRow(view_GetData.FocusedRowHandle);
                row["UNIT_UID"] = txt_UNIT_UID.Text.Trim();
                row["UNIT_NAME"] = txt_UNIT_NAME.Text.Trim();
                row["UNIT_ALIAS"] = txtUnitAlias.Text;
                row["UNIT_NAME_ALIAS"] = txt_UNIT_NAME_ALIAS.Text.Trim();
                row["PHONE_NO"] = txt_PHONE_NO.Text.Trim();
                row["DESCR"] = txt_DESCR.Text;
                row["LOC_ALIAS"] = txt_LOC_ALIAS.Text.Trim();
                row["LOC"] = txt_LOC.Text.Trim();
                row["UNIT_PARENT_NAME"] = txt_UNIT_PARENT_NAME.Text.Trim();
                row["UPDATED"] = 'U';
            }
            btn_Save.Enabled = true;
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            panel_Insert.Visible = false;
            panel_Insert.Enabled = false;
            btn_OKUpdate.Visible = true;
            btn_OKUpdate.Enabled = true;
            btn_Browse.Visible = true;
            btn_Browse.Enabled = true;
            btn_Save.Enabled = false;

            txt_UNIT_UID.Text = String.Empty;
            txt_UNIT_NAME.Text = String.Empty;
            txt_DESCR.Text = String.Empty;
            txt_LOC_ALIAS.Text = String.Empty;
            txt_PHONE_NO.Text = String.Empty;
            txt_UNIT_NAME_ALIAS.Text = String.Empty;
            txt_UNIT_PARENT_NAME.Text = String.Empty;
            txt_LOC.Text = String.Empty;

            getHRUnit = new ProcessGetHRUnit();
            getHRUnit.Invoke();
            dtGrid = getHRUnit.Result.Tables[0];
            dtGrid.Columns.Add("DELETED");
            dtGrid.Columns.Add("UPDATED");
            dtGrid.AcceptChanges();

            gv_GetData.DataSource = dtGrid;
            loadViewTable();

            base.CloseWaitDialog();

        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (unitID > 0)
            {
                deleteHRUnit = new ProcessDeleteHRUnit_forExcel();
                deleteHRUnit.HR_UNIT.UNIT_ID = unitID;
                deleteHRUnit.Invoke();

                getHRUnit = new ProcessGetHRUnit();
                getHRUnit.Invoke();
                dtGrid = getHRUnit.Result.Tables[0];
                dtGrid.Columns.Add("DELETED");
                dtGrid.Columns.Add("UPDATED");
                dtGrid.AcceptChanges();

                gv_GetData.DataSource = dtGrid;

                txt_UNIT_UID.Text = String.Empty;
                txt_UNIT_NAME.Text = String.Empty;
                txt_DESCR.Text = String.Empty;
                txt_LOC_ALIAS.Text = String.Empty;
                txt_PHONE_NO.Text = String.Empty;
                txt_UNIT_NAME_ALIAS.Text = String.Empty;
                txt_UNIT_PARENT_NAME.Text = String.Empty;

                loadViewTable();
                
            }
            else
            {
                if (view_GetData.FocusedRowHandle >= 0)
                {
                    dtGrid = getHRUnit.Result.Tables[0];
                    //dtGrid.Columns.Add("DELETED");
                    dtGrid.Rows.RemoveAt(view_GetData.FocusedRowHandle);

                    txt_UNIT_UID.Text = String.Empty;
                    txt_UNIT_NAME.Text = String.Empty;
                    txt_DESCR.Text = String.Empty;
                    txt_LOC_ALIAS.Text = String.Empty;
                    txt_PHONE_NO.Text = String.Empty;
                    txt_UNIT_NAME_ALIAS.Text = String.Empty;
                    txt_UNIT_PARENT_NAME.Text = String.Empty;

                    dtGrid.AcceptChanges();

                }
                
            }
        }

        


    }
}
