using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic;

namespace Envision.NET.Forms.Technologist
{
    public partial class frmConsumable : Form
    {
        //private DBUtility dbu;
        private Graphics Grp;
        private Rectangle Rta;
        GridHitInfo hitInfo = null;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();


        private OrderManager orderManger;
        private Order thisOrder;

        private DataTable dttUpdate = new DataTable();
        private DataTable dtExamConsumable;
        private int _orderid;
        private int _modality;
        private int _clinictype;

        private DateTime OrderDate = DateTime.Now;
        public frmConsumable()
        {
            InitializeComponent();
        }
        public frmConsumable(int orderID)
        {
            InitializeComponent();
            _orderid = orderID;
        }
        //public frmConsumable()//(UUL.ControlFrame.Controls.TabControl clsCtl)
        //{
        //    InitializeComponent();
        //}
        private void frmConsumable_Load(object sender, EventArgs e)
        {
            LoadData(_orderid);
        }

        private void LoadData()
        {
            LookUpSelect lk = new LookUpSelect();
            dtExamConsumable = lk.SelectExamConsumable().Tables[0];
            orderManger = new OrderManager();
            thisOrder = new Order(29853);
            OrderDate = thisOrder.Item.ORDER_DT;
            setGridData();
            calTotal();
            dttUpdate = thisOrder.ItemDetail.Clone();
        }
        private void LoadData(int orderID)
        {
            LookUpSelect lk = new LookUpSelect();
            dtExamConsumable = lk.SelectExamConsumable().Tables[0];

            orderManger = new OrderManager();
            thisOrder = new Order(orderID);
            OrderDate = thisOrder.Item.ORDER_DT;
            _modality = (int)thisOrder.ItemDetail.Rows[0]["MODALITY_ID"];
            _clinictype = (int)thisOrder.ItemDetail.Rows[0]["CLINIC_TYPE"];

            setGridData();
            calTotal();
            dttUpdate = thisOrder.ItemDetail.Clone();

        }
        private string DataRow(DataRow dr)
        {
            string s = "";
            if (dr != null)
                foreach (object o in dr.ItemArray)
                    s = (s == "" ? "" : s + "; ") + o.ToString();
            return s;
        }
        private void setGridData()
        {
            try
            {
                DataTable dtt = thisOrder.ItemDetail.Copy();
                foreach (DataRow dr in dtt.Rows)
                {
                    if (dr["SERVICE_TYPE"].ToString() != "3")
                    {
                        if (dr["SERVICE_TYPE"].ToString().Trim() != "")
                        {
                            dr.Delete();
                        }
                    }
                }
                dtt.AcceptChanges();
                DataView dv = new DataView(dtt);
                if (dv.Table.Rows.Count > 0)
                    dv.RowFilter = " IS_DELETED <>'Y' ";
                grdOrderdtl.DataSource = dv;

                view1.OptionsView.ShowBands = false;
                view1.OptionsSelection.EnableAppearanceFocusedCell = false;
                view1.OptionsSelection.EnableAppearanceFocusedRow = false;
                view1.OptionsView.ShowColumnHeaders = true;
                view1.OptionsCustomization.AllowSort = false;
                view1.OptionsView.ShowGroupPanel = false;

                for (int i = 0; i < view1.Columns.Count; i++)
                    view1.Columns[i].Visible = false;

                string rate_type = "";
                //if (_clinictype == 7)
                //    rate_type = "SPECIAL_RATE";
                //else
                //    rate_type = "RATE";

                rate_type = "RATE";

                view1.Columns[rate_type].Caption = "Rate";
                view1.Columns[rate_type].OptionsColumn.ReadOnly = true;

                view1.Columns[rate_type].DisplayFormat.FormatString = "#,##0.00";
                view1.Columns[rate_type].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                view1.Columns[rate_type].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

                view1.Columns["EXAM_UID"].ColVIndex = 0;
                view1.Columns["EXAM_NAME"].ColVIndex = 1;
                view1.Columns["QTY"].ColVIndex = 2;
                view1.Columns[rate_type].ColVIndex = 3;
                view1.Columns["colDelete"].ColVIndex = 4;

                //view1.Columns["EXAM_UID"].Caption = "Exam Code";
                view1.Columns["EXAM_UID"].Caption = "Consumable Code";
                //view1.Columns["EXAM_NAME"].Caption = "Exam Name";
                view1.Columns["EXAM_NAME"].Caption = "Consumable Name";
                //view1.Columns["PRIORITY"].Caption = "";//"Priority";

                //view1.Columns["CLINIC_TYPE"].Caption = "Clinic";
                //view1.Columns["MODALITY_ID"].Caption = "Modality";
                //view1.Columns["ASSIGNED_TO"].Caption = "Radiologist";
                //view1.Columns["BPVIEW_ID"].Caption = "Sides";
                view1.Columns["QTY"].Caption = "QTY";

                //view1.Columns["PRIORITY"].ColVIndex = 0;

                //view1.Columns["BPVIEW_ID"].ColVIndex = 3;
                //view1.Columns["CLINIC_TYPE"].ColVIndex = 6;
                //view1.Columns["MODALITY_ID"].ColVIndex = 7;
                //view1.Columns["ASSIGNED_TO"].ColVIndex = 8;

                view1.Columns["colDelete"].Visible = true;
                view1.Columns["EXAM_UID"].Visible = true;
                view1.Columns["EXAM_NAME"].Visible = true;
                //view1.Columns["PRIORITY"].Visible = true;
                //view1.Columns["MODALITY_ID"].Visible = true;
                //view1.Columns["ASSIGNED_TO"].Visible = true;
                //view1.Columns["BPVIEW_ID"].Visible = true;
                view1.Columns["QTY"].Visible = true;

                //view1.Columns["EXAM_UID"].BestFit();
                //view1.Columns["EXAM_NAME"].BestFit();
                // view1.Columns["PRIORITY"].BestFit();

                //view1.Columns["CLINIC_TYPE"].BestFit();
                //view1.Columns["MODALITY_ID"].BestFit();
                //view1.Columns["ASSIGNED_TO"].BestFit();

                RepositoryItemSpinEdit spe = new RepositoryItemSpinEdit();
                spe.ValueChanged += new EventHandler(spe_ValueChanged);
                view1.Columns["QTY"].ColumnEdit = spe;

                RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
                btn.AutoHeight = false;
                btn.BestFitWidth = 9;
                btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
                btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                btn.Buttons[0].Caption = string.Empty;
                btn.Click += new EventHandler(btnDeleteRow_Click);
                view1.Columns["colDelete"].Caption = string.Empty;
                view1.Columns["colDelete"].ColumnEdit = btn;
                view1.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                view1.Columns["colDelete"].Width = 10;
                view1.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

                RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repositoryItemLookUpEdit1.ImmediatePopup = true;
                repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                repositoryItemLookUpEdit1.AutoHeight = false;
                repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID", "Exam Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
                repositoryItemLookUpEdit1.DisplayMember = "EXAM_UID";
                repositoryItemLookUpEdit1.ValueMember = "EXAM_UID";
                repositoryItemLookUpEdit1.DropDownRows = 5;
                repositoryItemLookUpEdit1.DataSource = dtExamConsumable;
                repositoryItemLookUpEdit1.NullText = string.Empty;
                repositoryItemLookUpEdit1.KeyUp += new KeyEventHandler(examCode_KeyUp);
                repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examCode_CloseUp);
                view1.Columns["EXAM_UID"].ColumnEdit = repositoryItemLookUpEdit1;
                view1.Columns["EXAM_UID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

                RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                repositoryItemLookUpEdit2.ImmediatePopup = true;
                repositoryItemLookUpEdit2.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
                repositoryItemLookUpEdit2.AutoHeight = false;
                repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_NAME", "Exam Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
                repositoryItemLookUpEdit2.DisplayMember = "EXAM_NAME";
                repositoryItemLookUpEdit2.ValueMember = "EXAM_NAME";
                repositoryItemLookUpEdit2.DropDownRows = 5;
                repositoryItemLookUpEdit2.DataSource = dtExamConsumable;
                repositoryItemLookUpEdit2.NullText = string.Empty;
                repositoryItemLookUpEdit2.KeyUp += new KeyEventHandler(examName_KeyUp);
                repositoryItemLookUpEdit2.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examName_CloseUp);
                view1.Columns["EXAM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
                view1.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

                gridBestFitColumn();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void spe_ValueChanged(object sender, EventArgs e)
        {
            string str = "";
            SpinEdit spe = new SpinEdit();
            spe = (SpinEdit)sender;
            DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
            int sp = Convert.ToInt32(spe.Value.ToString());
            if (sp > 0)
            {
                dr["QTY"] = sp;
                dr.AcceptChanges();
                calTotal();
            }
            else
            {
                dr["QTY"] = 0;
                dr.AcceptChanges();
                calTotal();
            }
        }
        private void calTotal()
        {
            decimal total = 0.0M;
            DataView dv = (DataView)grdOrderdtl.DataSource;
            foreach (DataRow dr in dv.Table.Rows)
            {
                decimal taxTemp = dr["RATE"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(dr["RATE"]);
                int qty = dr["QTY"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["QTY"]);

                total = total + (taxTemp * qty);
            }
            txtTotal.Text = total.ToString("#,##0.00");
        }
        void examName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    view1.FocusedColumn = view1.VisibleColumns[view1.FocusedColumn.VisibleIndex + 1];
                else
                {
                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();
                }
            }
        }
        void examCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    view1.FocusedColumn = view1.VisibleColumns[view1.FocusedColumn.VisibleIndex + 1];
                else
                {
                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();
                }
            }
        }
        void examName_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                int row = view1.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    bool flag = updateExamName(e.Value.ToString());
                    if (flag)
                    {
                        if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                        {
                            view1.FocusedRowHandle = row;
                            view1.FocusedColumn = view1.VisibleColumns[2];
                        }
                        else
                        {
                            view1.FocusedColumn = view1.VisibleColumns[0];
                            view1.MoveNext();
                        }
                    }
                    else
                    {
                        msg.ShowAlert("UID1014", env.CurrentLanguageID);
                        e.AcceptValue = false;
                    }
                }
            }
        }
        void examCode_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                int row = view1.FocusedRowHandle;
                if (e.Value.ToString() != string.Empty)
                {
                    bool flag = updateExamUID(e.Value.ToString());
                    if (flag)
                    {
                        if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                        {
                            view1.FocusedRowHandle = row;
                            view1.FocusedColumn = view1.VisibleColumns[2];
                        }
                        else
                        {
                            view1.FocusedColumn = view1.VisibleColumns[0];
                            view1.MoveNext();
                        }
                    }
                    else
                    {
                        msg.ShowAlert("UID1014", env.CurrentLanguageID);
                        e.AcceptValue = false;
                    }
                }
            }
        }
        private bool updateExamName(string strSearch)
        {
            //LookUpSelect lk = new LookUpSelect();
            DataTable dtExam = dtExamConsumable; //order.Ris_Exam();
            DataTable dtBP_View = RISBaseData.BP_View();
            DataView dv = (DataView)grdOrderdtl.DataSource;
            DataTable dtt = dv.Table;
            int row = view1.FocusedRowHandle;
            int i = 0;
            for (; i < dtExam.Rows.Count; i++)
                if (dtExam.Rows[i]["EXAM_NAME"].ToString() == strSearch)
                    break;
            if (i < dtExam.Rows.Count)
            {
                DataRow dr = dtExam.Rows[i];
                if (thisOrder.CheckConfliction(OrderDate, (int)dr["EXAM_ID"], dtt))
                    return false;
                dtt.Rows[row]["EXAM_ID"] = dr["EXAM_ID"];
                dtt.Rows[row]["EXAM_UID"] = dr["EXAM_UID"];
                dtt.Rows[row]["EXAM_NAME"] = dr["EXAM_NAME"];
                dtt.Rows[row]["RATE"] = dr["RATE"];
                dtt.Rows[row]["BPVIEW_ID"] = 5;
                dtt.Rows[row]["QTY"] = 1;
                dtt.Rows[row]["MODALITY_ID"] = _modality;

                if (dtt.Rows[row]["COMMENTS"].ToString().IndexOf("</F>") <= 0)
                {
                    DataRow[] drClinic = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + dtt.Rows[row]["CLINIC_TYPE"].ToString());
                    DataRow[] drExam = dtExamConsumable.Select("EXAM_ID = " + dtt.Rows[row]["EXAM_ID"].ToString());
                    switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                    {
                        case "Normal":
                            dtt.Rows[row]["RATE"] = drExam[0]["RATE"];
                            break;
                        case "Special":
                            dtt.Rows[row]["RATE"] = drExam[0]["SPECIAL_RATE"];
                            break;
                        case "VIP":
                            dtt.Rows[row]["RATE"] = drExam[0]["VIP_RATE"];
                            break;
                        default:
                            break;
                    }
                }


                view1.RefreshData();
                gridBestFitColumn();
                if (canAddRow())
                {
                    dr = dtt.NewRow();
                    dr["PRIORITY"] = "R";
                    dr["IS_DELETED"] = "N";
                    dr["EXAM_DT"] = DateTime.Today;
                    dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                    dtt.Rows.Add(dr);
                }
                calTotal();
                return true;
            }
            else
                return false;
        }
        private int modalityDefault(string ID)
        {
            int intReturn = 0;
            DataView dv = new DataView(RISBaseData.Ris_ModalityExam());
            dv.RowFilter = " IS_DEFAULT_MODALITY ='Y' and EXAM_ID=" + ID;
            if (dv.Count > 0)
                intReturn = (int)dv[0][1];
            return intReturn;
        }
        private bool canAddRow()
        {
            DataView dv = (DataView)grdOrderdtl.DataSource;
            DataTable dtt = dv.Table;
            bool flag = true;
            foreach (DataRow dr in dtt.Rows)
            {
                if (dr["EXAM_ID"].ToString().Trim() == string.Empty)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        private bool updateExamUID(string strSearch)
        {
            DataTable dtExam = dtExamConsumable;//order.Ris_Exam();
            DataTable dtBP_View = RISBaseData.BP_View();
            DataView dv = (DataView)grdOrderdtl.DataSource;
            DataTable dtt = dv.Table;
            int row = view1.FocusedRowHandle;

            int i = 0;
            for (; i < dtExam.Rows.Count; i++)
                if (dtExam.Rows[i]["EXAM_UID"].ToString() == strSearch)
                    break;
            if (i < dtExam.Rows.Count)
            {
                DataRow dr = dtExam.Rows[i];
                if (dr["EXAM_ID"].ToString().Trim() != dtt.Rows[row]["EXAM_ID"].ToString())
                    if (thisOrder.CheckConfliction(OrderDate, (int)dr["EXAM_ID"], dtt))
                        return false;
                dtt.Rows[row]["EXAM_ID"] = dr["EXAM_ID"];
                dtt.Rows[row]["EXAM_UID"] = dr["EXAM_UID"];
                dtt.Rows[row]["EXAM_NAME"] = dr["EXAM_NAME"];
                dtt.Rows[row]["RATE"] = dr["RATE"];
                dtt.Rows[row]["BPVIEW_ID"] = 5;
                dtt.Rows[row]["QTY"] = 1;
                dtt.Rows[row]["MODALITY_ID"] = _modality;
                if (dtt.Rows[row]["COMMENTS"].ToString().IndexOf("</F>") <= 0)
                {
                    DataRow[] drClinic = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + dtt.Rows[row]["CLINIC_TYPE"].ToString());
                    DataRow[] drExam = dtExamConsumable.Select("EXAM_ID = " + dtt.Rows[row]["EXAM_ID"].ToString());
                    switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                    {
                        case "Normal":
                            dtt.Rows[row]["RATE"] = drExam[0]["RATE"];
                            break;
                        case "Special":
                            dtt.Rows[row]["RATE"] = drExam[0]["SPECIAL_RATE"];
                            break;
                        case "VIP":
                            dtt.Rows[row]["RATE"] = drExam[0]["VIP_RATE"];
                            break;
                        default:
                            break;
                    }
                }
                view1.RefreshData();
                gridBestFitColumn();
                if (canAddRow())
                {
                    dr = dtt.NewRow();
                    dr["PRIORITY"] = "R";
                    dr["IS_DELETED"] = "N";
                    dr["EXAM_DT"] = DateTime.Today;
                    dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                    dtt.Rows.Add(dr);
                }
                calTotal();
                return true;
            }
            else
                return false;
        }
        private void gridBestFitColumn()
        {
            view1.Columns["EXAM_NAME"].BestFit();
            view1.Columns["RATE"].BestFit();
            view1.Columns["EXAM_UID"].BestFit();
            view1.Columns["EXAM_NAME"].BestFit();
            //view1.Columns["PRIORITY"].BestFit();
            //view1.Columns["SPECIAL_RATE"].BestFit();
            //view1.Columns["MODALITY_ID"].BestFit();
            //view1.Columns["ASSIGNED_TO"].BestFit();
            //view1.Columns["CLINIC_TYPE"].BestFit();
            //view1.Columns["BPVIEW_ID"].BestFit();
            view1.Columns["QTY"].BestFit();
            int w = view1.Columns["EXAM_NAME"].Width;
            view1.Columns["EXAM_NAME"].Width = w + 10;
            //w = view1.Columns["PRIORITY"].Width;
            //view1.Columns["PRIORITY"].Width = 20;
            //w = view1.Columns["ASSIGNED_TO"].Width;
            //view1.Columns["ASSIGNED_TO"].Width = w + 10;
            //w = view1.Columns["CLINIC_TYPE"].Width;
            //view1.Columns["CLINIC_TYPE"].Width = w + 5;
            w = view1.Columns["EXAM_UID"].Width;
            view1.Columns["EXAM_UID"].Width = w + 5;

            view1.Columns["colDelete"].Width = 10;
        }
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)grdOrderdtl.DataSource;
            DataTable dtt = dv.Table;
            if (dtt.Rows.Count > 0)
            {
                if (dv.Count == 1)
                {
                    if (dv[0][24].ToString() == "N")
                    {
                        if (dv[0][6].ToString() == string.Empty)
                        {
                            //treeRadio.Nodes.Clear();
                            //treeRadio.Nodes.Add("No Radiologist");
                        }
                    }
                }
                else
                {
                    DataRow dr = null;
                    dr = dtt.Rows[view1.FocusedRowHandle];
                    if (dr["EXAM_ID"].ToString().Trim() == string.Empty && _modality.ToString().Trim() == string.Empty)
                        return;
                    string s = msg.ShowAlert("UID1025", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        DataRow drAdd = dttUpdate.NewRow();
                        for (int i = 0; i < dttUpdate.Columns.Count; i++)
                            drAdd[i] = dr[i];
                        drAdd["IS_DELETED"] = "Y";
                        dttUpdate.Rows.Add(drAdd);
                        dttUpdate.AcceptChanges();

                        dtt.Rows[view1.FocusedRowHandle].Delete();
                        dtt.AcceptChanges();
                        dv = new DataView(dtt);
                        grdOrderdtl.DataSource = dv;
                        if (dtt.Rows.Count == 1)
                        {
                            if (dtt.Rows[0]["MODALITY_ID"].ToString().Trim() == string.Empty)
                            {
                                //treeRadio.Nodes.Clear();
                                //treeRadio.Nodes.Add("No Radiologist");
                            }
                        }
                    }
                }
                calTotal();
                gridBestFitColumn();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string s = msg.ShowAlert("UID1020", env.CurrentLanguageID);
            if (s == "2")
            {
                fillDataToEditOrder(thisOrder);
                updateData();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            //LoadData();
        }
        private void fillDataToEditOrder(Order Ord)
        {

            DataView dv = (DataView)grdOrderdtl.DataSource;
            DataTable dtt = dv.Table.Copy();
            int i = 0;
            while (i < dtt.Rows.Count)
            {
                if (dtt.Rows[i]["EXAM_ID"].ToString() == string.Empty)
                {
                    dtt.Rows[i].Delete();
                    dtt.AcceptChanges();
                    i = 0;
                }
                else
                    i++;
            }
            dtt.AcceptChanges();
            if (dttUpdate.Rows.Count > 0)
            {
                foreach (DataRow dr in dttUpdate.Rows)
                {
                    DataRow drAdd = dtt.NewRow();
                    for (i = 0; i < dttUpdate.Columns.Count; i++)
                        drAdd[i] = dr[i];
                    dtt.Rows.Add(drAdd);
                }
            }
            i = 0;
            Ord.ItemDetail = dtt.Copy();
            //Ord.Ris_OrderImage = this.thisOrder.Ris_OrderImage.Copy();
            //Ord.Ris_PatICD = this.thisOrder.Ris_PatICD.Copy();

            //Ord.Item.REF_UNIT = txtOrderDepartment.Tag == null || txtOrderDepartment.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtOrderDepartment.Tag);
            //Ord.Item.REF_DOC = txtOrderPhysician.Tag == null || txtOrderPhysician.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtOrderPhysician.Tag);
            //Ord.Item.INSURANCE_TYPE_ID = txtInsurace.Tag == null || txtInsurace.Tag.ToString() == string.Empty ? 0 : Convert.ToInt32(txtInsurace.Tag);
            //Ord.Item.PAT_STATUS = txtPatientType.Tag == null || txtPatientType.Tag.ToString() == string.Empty ? string.Empty : txtPatientType.Tag.ToString();
            //Ord.Item.Lmp_DT = datePeriod.DateTime;
            //Ord.Item.REF_DOC_INSTRUCTION = this.thisOrder.Item.REF_DOC_INSTRUCTION;
            //Ord.Item.CLINICAL_INSTRUCTION = this.thisOrder.Item.CLINICAL_INSTRUCTION;
            //Ord.Item.LAST_MODIFIED_BY = env.UserID;
            //Ord.Item.ORG_ID = env.OrgID;
            //if (txtOrderDepartment.Tag != null)
            //    if (txtOrderDepartment.Text.Trim() != string.Empty)
            //        Ord.Item.REF_UNIT = Convert.ToInt32(txtOrderDepartment.Tag);
            //if (txtOrderPhysician.Tag != null)
            //    if (txtOrderPhysician.Text.Trim() != string.Empty)
            //        Ord.Item.REF_DOC = Convert.ToInt32(txtOrderPhysician.Tag);

            //Ord.Demographic = this.thisOrder.Demographic;
            //Ord.Demographic.Doctor_Name = txtOrderPhysician.Text;
            //Ord.Demographic.Department_Name = txtOrderDepartment.Text;
            //Ord.Demographic.InsuranceID = Ord.Item.INSURANCE_TYPE_ID;
            //Ord.Demographic.Department_Name = txtOrderDepartment.Text;
            //Ord.Demographic.Doctor_Name = txtOrderPhysician.Text;
            //if (txtInsurace.Tag != null)
            //{
            //    if (txtInsurace.Text.Trim() != string.Empty)
            //        Ord.Demographic.Insurance_Type = txtInsurace.Text;
            //}
            //if (Ord.Demographic.LinkDown == false && Ord.Demographic.DataFromHIS)
            //    Ord.Demographic.Reg_UID = txtHN.Text.Trim();
            //else if (Ord.Demographic.DataFromLocal)
            //{
            //    Ord.Demographic.DateOfBirth = txtDOB.DateTime;
            //    Ord.Demographic.FirstName_ENG = txtEngName.Text;
            //    Ord.Demographic.LastName_ENG = txtLastEngName.Text;
            //    Ord.Demographic.Phone1 = txtTelephone.Text;
            //}
            orderManger.Add(Ord);
        }
        private bool updateData()
        {
            bool flag = orderManger[0].Invoke();
            if (flag)
            {
                //cboGender.SelectedIndex = 0;
                thisOrder = new Order();
                orderManger = new OrderManager();
                //loadFormLanguage();
                //clearContexInControl();
                //setEnableDisableControl(false);
                //setBackColor(defaultBackColor);
                //setForeColor(defaultForeColor);
                setGridData();
                //setGridOrder();
            }
            else
            {
                msg.ShowAlert("UID1024", env.CurrentLanguageID);
                DataRow dr = thisOrder.ItemDetail.NewRow();
                dr["SPECIAL_CLINIC"] = "N";
                dr["IS_DELETED"] = "N";
                dr["PRIORITY"] = "R";
                dr["EXAM_DT"] = DateTime.Today;
                dr["CLINIC_TYPE"] = thisOrder.IsRowDefalutClinic;
                dr["colDelete"] = "Delete";
                thisOrder.ItemDetail.Rows.Add(dr);
                setGridData();
                setGridData();
                orderManger = new OrderManager();
                //txtOrderDepartment.Focus();
            }
            return flag;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}