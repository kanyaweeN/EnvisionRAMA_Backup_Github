using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Envision.NET.Forms.Main;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.Utils;

namespace Envision.NET.Forms.Financial
{
    public partial class frmFinReceiveWorklist : MasterForm
    {
        //UUL.ControlFrame.Controls.TabControl closeControl;
        private DataSet dsFinData;
        private string chkModality;
        private bool checkCanSearch;
        private List<int> modID = new List<int>();
        private List<int> modID2 = new List<int>();
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();

        private bool firstLoad = true;

        //public frmFinReceiveWorklist(UUL.ControlFrame.Controls.TabControl tabControl)
        public frmFinReceiveWorklist()
        {
            InitializeComponent();
            //closeControl = tabControl;
        }

        private void frmFinReceiveWorklist_Load(object sender, EventArgs e)
        {
            env.ErrorForm = base.Menu_Name_Class;

            dteFromdate.DateTime = DateTime.Now;
            dteTodate.DateTime = DateTime.Now;
            checkCanSearch = true;
            initModality();
            setDataGrid();
            setGrid();

            firstLoad = false;
            base.CloseWaitDialog();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            setDataGrid();
            setGrid();
        }
        private void initModality()
        {
            ProcessGetFINPayment mod = new ProcessGetFINPayment();
            mod.FIN_PAYMENT.PAY_ID = -4;
            mod.Invoke();
            DataTable dtt = mod.Result.Tables[0];
            string modName = "";
            modID.Clear();
            ccbModality.Properties.Items.Clear();
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                ccbModality.Properties.Items.Add(dtt.Rows[i]["MODALITY_NAME"]);
                if (i == 0)
                    modName = dtt.Rows[i]["MODALITY_NAME"].ToString();
                else
                    modName += "," + dtt.Rows[i]["MODALITY_NAME"].ToString();
                modID.Add(Convert.ToInt32(dtt.Rows[i]["MODALITY_ID"]));
            }
            ccbModality.SetEditValue(modName);
            checkCanSearch = true;
        }
        private void setDataGrid()
        {
            base.LabelWaitDialog("Loading Data");

            if (!checkCanSearch)
            { msg.ShowAlert("UID4028", env.CurrentLanguageID); return; }
            DateTime dteFrom = new DateTime(dteFromdate.DateTime.Year, dteFromdate.DateTime.Month, dteFromdate.DateTime.Day, 0, 0, 0);
            DateTime dteTo = new DateTime(dteTodate.DateTime.Year, dteTodate.DateTime.Month, dteTodate.DateTime.Day, 23, 59, 59);
            ProcessGetFINPayment fin = new ProcessGetFINPayment();
            fin.FIN_PAYMENT.PAY_ID = -2;
            fin.FIN_PAYMENT.FROM_DATE = dteFrom;
            fin.FIN_PAYMENT.TO_DATE = dteTo;
            fin.Invoke();
            ProcessGetFINPaymentdtl findtl = new ProcessGetFINPaymentdtl();
            findtl.FIN_PAYMENTDTL.FROM_DATE = dteFrom;
            findtl.FIN_PAYMENTDTL.TO_DATE = dteTo;
            findtl.FIN_PAYMENTDTL.EXAM_ID = -9;
            findtl.Invoke();
            DataTable dtFin = new DataTable();
            DataTable dtFindtl = new DataTable();
            if (fin.Result.Tables[0] == null) return;
            if (fin.Result.Tables[0].Rows.Count > 0)
            {
                if (modID2.Count > 0)
                {
                    string selectMod = "";
                    string selectPay = "";
                    dtFin = fin.Result.Tables[0].Clone();
                    dtFindtl = findtl.Result.Tables[0].Clone();
                    for (int i = 0; i < modID2.Count; i++)
                    {
                        if (i == 0)
                            selectMod = modID2[i].ToString();
                        else
                            selectMod += "," + modID2[i].ToString();
                    }
                    DataRow[] drSelMod = findtl.Result.Tables[0].Select("MODALITY_ID IN (" + selectMod + ")");
                    if (drSelMod.Length == 0)
                    {
                        dtFin.Rows.Clear();
                        dtFindtl.Rows.Clear();
                    }
                    else
                    {

                        for (int y = 0; y <= drSelMod.Length - 1; y++)
                        {
                            if (y == 0)
                                selectPay = drSelMod[y]["PAY_ID"].ToString();
                            else
                                selectPay += "," + drSelMod[y]["PAY_ID"].ToString();
                        }
                        DataRow[] drSelPay = fin.Result.Tables[0].Select("PAY_ID IN (" + selectPay + ")");
                        for (int z = 0; z <= drSelPay.Length - 1; z++)
                        {
                            dtFin.Rows.Add(drSelPay[z].ItemArray);
                        }
                        DataRow[] drSelPay2 = findtl.Result.Tables[0].Select("PAY_ID IN (" + selectPay + ")");
                        for (int x = 0; x <= drSelPay2.Length - 1; x++)
                        {
                            dtFindtl.Rows.Add(drSelPay2[x].ItemArray);
                        }
                    }
                    foreach (DataRow row1 in dtFindtl.Rows)
                    {
                        if (string.IsNullOrEmpty(row1["PAID"].ToString()) || row1["PAID"].ToString() != "0.00")
                        {
                            decimal rate = Convert.ToDecimal(row1["RATE"]);
                            decimal discount = Convert.ToDecimal(row1["DISCOUNT"]);
                            decimal paid = rate + discount;
                            row1["PAID"] = paid.ToString("0.00");
                        }
                    }
                    dtFin.TableName = "Fin";
                    dtFindtl.TableName = "Findtl";

                }
                else
                {
                    dtFin = fin.Result.Tables[0];
                    dtFin.TableName = "Fin";

                    string _filterOrderId = "";
                    foreach (DataRow row in dtFin.Rows)
                        _filterOrderId += "," + row["ORDER_ID"].ToString();

                    DataRow[] rows = findtl.Result.Tables[0].Select("ORDER_ID in ("+_filterOrderId.Substring(1)+")");
                    dtFindtl = rows.CopyToDataTable();

                    foreach (DataRow row1 in dtFindtl.Rows)
                    {
                        if (string.IsNullOrEmpty(row1["PAID"].ToString()) || row1["PAID"].ToString() != "0.00")
                        {
                            decimal rate = Convert.ToDecimal(row1["PAID"]);
                            decimal discount = Convert.ToDecimal(row1["DISCOUNT"]);
                            decimal paid = rate + discount;
                            row1["PAID"] = paid.ToString("0.00");
                        }
                    }


                    dtFindtl.TableName = "Findtl";
                }
            }
            else
            {
                dtFin = fin.Result.Tables[0];
                dtFin.TableName = "Fin";

                string _filterOrderId = "";
                foreach (DataRow row in dtFin.Rows)
                    _filterOrderId += "," + row["ORDER_ID"].ToString();

                DataRow[] rows = findtl.Result.Tables[0].Select("ORDER_ID in (" + _filterOrderId.Substring(1) + ")");
                dtFindtl = rows.CopyToDataTable();

                foreach (DataRow row1 in dtFindtl.Rows)
                {
                    if (string.IsNullOrEmpty(row1["PAID"].ToString()) || row1["PAID"].ToString() != "0.00")
                    {
                        decimal rate = Convert.ToDecimal(row1["RATE"]);
                        decimal discount = Convert.ToDecimal(row1["DISCOUNT"]);
                        decimal paid = rate + discount;
                        row1["PAID"] = paid.ToString("0.00");
                    }
                }
                dtFindtl.TableName = "Findtl";
            }



            dsFinData = new DataSet();
            dsFinData.Tables.Add(dtFin.Copy());
            dsFinData.Tables.Add(dtFindtl.Copy());
            dsFinData.AcceptChanges();
            dsFinData.Relations.Add("FinData", dsFinData.Tables["Fin"].Columns["ORDER_ID"], dsFinData.Tables["Findtl"].Columns["ORDER_ID"]);
            dsFinData.AcceptChanges();
            grdData.DataSource = dsFinData.Tables[0];
            base.CloseWaitDialog();
        }
        private void setDataGridByHN()
        {
            if (!checkCanSearch)
            { msg.ShowAlert("UID4028", env.CurrentLanguageID); return; }
            if (!string.IsNullOrEmpty(txtHn.Text))
            {
                ProcessGetFINPayment fin = new ProcessGetFINPayment();
                fin.FIN_PAYMENT.PAY_ID = -3;
                fin.FIN_PAYMENT.HN = txtHn.Text.Trim();
                fin.Invoke();
                ProcessGetFINPaymentdtl findtl = new ProcessGetFINPaymentdtl();
                findtl.FIN_PAYMENTDTL.EXAM_ID = -10;
                findtl.FIN_PAYMENTDTL.HN = txtHn.Text.Trim();
                findtl.FIN_PAYMENTDTL.FROM_DATE = DateTime.Now.AddYears(-100);
                findtl.FIN_PAYMENTDTL.TO_DATE = DateTime.Now.AddYears(100);
                findtl.Invoke();

                DataTable dtFin = new DataTable();
                DataTable dtFindtl = new DataTable();

                if (fin.Result.Tables[0] == null) return;
                if (fin.Result.Tables[0].Rows.Count > 0)
                {
                    if (modID2.Count > 0)
                    {
                        string selectMod = "";
                        string selectPay = "";
                        dtFin = fin.Result.Tables[0].Clone();
                        dtFindtl = findtl.Result.Tables[0].Clone();
                        for (int i = 0; i < modID2.Count; i++)
                        {
                            if (i == 0)
                                selectMod = modID2[i].ToString();
                            else
                                selectMod += "," + modID2[i].ToString();
                        }
                        DataRow[] drSelMod = findtl.Result.Tables[0].Select("MODALITY_ID IN (" + selectMod + ")");
                        for (int y = 0; y <= drSelMod.Length - 1; y++)
                        {
                            if (y == 0)
                                selectPay = drSelMod[y]["PAY_ID"].ToString();
                            else
                                selectPay += "," + drSelMod[y]["PAY_ID"].ToString();
                        }
                        DataRow[] drSelPay;
                        if (string.IsNullOrEmpty(selectPay))
                        { MessageBox.Show("Please select modality."); return; }
                        else
                            drSelPay = fin.Result.Tables[0].Select("PAY_ID IN (" + selectPay + ")");

                        for (int z = 0; z <= drSelPay.Length - 1; z++)
                        {
                            dtFin.Rows.Add(drSelPay[z].ItemArray);
                        }
                        for (int x = 0; x <= drSelMod.Length - 1; x++)
                        {
                            dtFindtl.Rows.Add(drSelMod[x].ItemArray);

                        }

                        foreach (DataRow row1 in dtFindtl.Rows)
                        {
                            if (string.IsNullOrEmpty(row1["PAID"].ToString()) || row1["PAID"].ToString() != "0.00")
                            {
                                decimal rate = Convert.ToDecimal(row1["RATE"]);
                                decimal discount = Convert.ToDecimal(row1["DISCOUNT"]);
                                decimal paid = rate + discount;
                                row1["PAID"] = paid.ToString("0.00");
                            }
                        }


                    }
                    else
                    {
                        dtFin = fin.Result.Tables[0];
                        dtFindtl = findtl.Result.Tables[0];
                        foreach (DataRow row1 in dtFindtl.Rows)
                        {
                            if (string.IsNullOrEmpty(row1["PAID"].ToString()) || row1["PAID"].ToString() != "0.00")
                            {
                                decimal rate = Convert.ToDecimal(row1["RATE"]);
                                decimal discount = Convert.ToDecimal(row1["DISCOUNT"]);
                                decimal paid = rate + discount;
                                row1["PAID"] = paid.ToString("0.00");
                            }
                        }
                    }
                }
                dtFin.TableName = "Fin";
                dtFindtl.TableName = "Findtl";
                dsFinData = new DataSet();
                dsFinData.Tables.Add(dtFin.Copy());
                dsFinData.Tables.Add(dtFindtl.Copy());
                dsFinData.AcceptChanges();
                dsFinData.Relations.Add("FinData", dsFinData.Tables["Fin"].Columns["ORDER_ID"], dsFinData.Tables["Findtl"].Columns["ORDER_ID"]);
                dsFinData.AcceptChanges();
                grdData.DataSource = dsFinData.Tables[0];
            }

        }
        private void setGrid()
        {
            viewMaster.OptionsDetail.ShowDetailTabs = false;
            grdData.ForceInitialize();
            DevExpress.XtraGrid.Views.Grid.GridView viewSub = new DevExpress.XtraGrid.Views.Grid.GridView(grdData);
            grdData.LevelTree.Nodes.Add("FinData", viewSub);
            viewSub.PopulateColumns(dsFinData.Tables["Findtl"]);
            viewSub.OptionsView.ColumnAutoWidth = false;
            viewSub.OptionsView.ShowGroupPanel = false;
            viewSub.OptionsView.ShowIndicator = false;
            viewSub.OptionsView.ShowFooter = true;


            #region Master

            #region Edit Columns
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtOne = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit speOne = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            speOne.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            speOne.Buttons[0].Visible = false;
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnPay = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnPay.Buttons[0].Caption = "Pay Now";
            btnPay.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            btnPay.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnPay.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnPay_ButtonClick);
            #endregion

            viewMaster.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["HN"].Visible = true;
            viewMaster.Columns["HN"].Caption = "HN";
            viewMaster.Columns["HN"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["HN"].Width = 100;
            viewMaster.Columns["HN"].ColVIndex = 0;

            viewMaster.Columns["PATIENT_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["PATIENT_NAME"].Visible = true;
            viewMaster.Columns["PATIENT_NAME"].Caption = "Patient Name";
            viewMaster.Columns["PATIENT_NAME"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["PATIENT_NAME"].Width = 200;
            viewMaster.Columns["PATIENT_NAME"].ColVIndex = 1;

            viewMaster.Columns["RATE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["RATE"].Visible = true;
            viewMaster.Columns["RATE"].Caption = "Total Payable";
            viewMaster.Columns["RATE"].ColumnEdit = speOne;
            viewMaster.Columns["RATE"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["RATE"].Width = 100;
            viewMaster.Columns["RATE"].ColVIndex = 2;

            viewMaster.Columns["EMP_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["EMP_NAME"].Visible = true;
            viewMaster.Columns["EMP_NAME"].Caption = "Paid By.";
            viewMaster.Columns["EMP_NAME"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["EMP_NAME"].Width = 100;
            viewMaster.Columns["EMP_NAME"].ColVIndex = 3;

            viewMaster.Columns["PAY_DT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["PAY_DT"].Visible = true;
            viewMaster.Columns["PAY_DT"].Caption = "Paid Datetime";
            viewMaster.Columns["PAY_DT"].ColumnEdit = txtOne;
            viewMaster.Columns["PAY_DT"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["PAY_DT"].Width = 120;
            viewMaster.Columns["PAY_DT"].ColVIndex = 4;

            viewMaster.Columns["STATUS"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["STATUS"].Visible = true;
            viewMaster.Columns["STATUS"].Caption = "Status";
            viewMaster.Columns["STATUS"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["STATUS"].Width = 100;
            viewMaster.Columns["STATUS"].ColVIndex = 5;

            viewMaster.Columns["PAY_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["PAY_ID"].Visible = true;
            viewMaster.Columns["PAY_ID"].Caption = "Pay Now";
            viewMaster.Columns["PAY_ID"].ColumnEdit = btnPay;
            viewMaster.Columns["PAY_ID"].OptionsColumn.ReadOnly = false;
            viewMaster.Columns["PAY_ID"].Width = 70;
            viewMaster.Columns["PAY_ID"].ColVIndex = 6;

            viewMaster.Columns["ORDER_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["ORDER_ID"].Visible = false;
            viewMaster.Columns["ORDER_ID"].Caption = "ORDER_ID";
            viewMaster.Columns["ORDER_ID"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["ORDER_ID"].Width = 10;

            viewMaster.Columns["PATIENT_NAMEENG"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["PATIENT_NAMEENG"].Visible = false;
            viewMaster.Columns["PATIENT_NAMEENG"].Caption = "PATIENT_NAMEENG";
            viewMaster.Columns["PATIENT_NAMEENG"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["PATIENT_NAMEENG"].Width = 10;

            viewMaster.Columns["EMP_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["EMP_UID"].Visible = false;
            viewMaster.Columns["EMP_UID"].Caption = "EMP_UID";
            viewMaster.Columns["EMP_UID"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["EMP_UID"].Width = 10;

            viewMaster.Columns["UNIT_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["UNIT_UID"].Visible = false;
            viewMaster.Columns["UNIT_UID"].Caption = "UNIT_UID";
            viewMaster.Columns["UNIT_UID"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["UNIT_UID"].Width = 10;

            viewMaster.Columns["UNIT_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewMaster.Columns["UNIT_NAME"].Visible = false;
            viewMaster.Columns["UNIT_NAME"].Caption = "UNIT_NAME";
            viewMaster.Columns["UNIT_NAME"].OptionsColumn.ReadOnly = true;
            viewMaster.Columns["UNIT_NAME"].Width = 10;
            #endregion

            #region Sub
            viewSub.Columns["EXAM_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["EXAM_UID"].Visible = true;
            viewSub.Columns["EXAM_UID"].Caption = "Exam Code";
            viewSub.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["EXAM_UID"].Width = 50;
            viewSub.Columns["EXAM_UID"].VisibleIndex = 1;

            viewSub.Columns["EXAM_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["EXAM_NAME"].Visible = true;
            viewSub.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewSub.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["EXAM_NAME"].Width = 200;
            viewSub.Columns["EXAM_NAME"].VisibleIndex = 2;

            viewSub.Columns["ACCESSION_NO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["ACCESSION_NO"].Visible = true;
            viewSub.Columns["ACCESSION_NO"].Caption = "ACCESSION_NO";
            viewSub.Columns["ACCESSION_NO"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["ACCESSION_NO"].Width = 150;
            viewSub.Columns["ACCESSION_NO"].VisibleIndex = 3;

            viewSub.Columns["RATE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["RATE"].Visible = true;
            viewSub.Columns["RATE"].Caption = "Rate";
            viewSub.Columns["RATE"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["RATE"].Width = 100;
            viewSub.Columns["RATE"].VisibleIndex = 4;

            viewSub.Columns["QTY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["QTY"].Visible = true;
            viewSub.Columns["QTY"].Caption = "QTY";
            viewSub.Columns["QTY"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["QTY"].Width = 100;
            viewSub.Columns["QTY"].VisibleIndex = 5;

            viewSub.Columns["PAYABLE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["PAYABLE"].Visible = true;
            viewSub.Columns["PAYABLE"].Caption = "Amount";
            viewSub.Columns["PAYABLE"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["PAYABLE"].Width = 150;
            viewSub.Columns["PAYABLE"].SummaryItem.FieldName = "PAYABLE";
            viewSub.Columns["PAYABLE"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            viewSub.Columns["PAYABLE"].SummaryItem.DisplayFormat = "Total : {0}";
            viewSub.Columns["PAYABLE"].VisibleIndex = 6;

            viewSub.Columns["PAID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["PAID"].Visible = true;
            viewSub.Columns["PAID"].Caption = "Paid";
            viewSub.Columns["PAID"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["PAID"].Width = 150;
            viewSub.Columns["PAID"].SummaryItem.FieldName = "PAID";
            viewSub.Columns["PAID"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            viewSub.Columns["PAID"].SummaryItem.DisplayFormat = "Total : {0}";

            viewSub.Columns["PAID"].VisibleIndex = 7;

            viewSub.Columns["DISCOUNT"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["DISCOUNT"].Visible = false;
            viewSub.Columns["DISCOUNT"].Caption = "DISCOUNT";
            viewSub.Columns["DISCOUNT"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["DISCOUNT"].Width = 100;
            //viewSub.Columns["DISCOUNT"].VisibleIndex = 8;

            viewSub.Columns["PAY_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["PAY_ID"].Visible = false;
            viewSub.Columns["PAY_ID"].Caption = "PAY_ID";
            viewSub.Columns["PAY_ID"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["PAY_ID"].Width = 100;
            //viewSub.Columns["PAY_ID"].VisibleIndex = 9;

            viewSub.Columns["STATUS"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["STATUS"].Visible = false;
            viewSub.Columns["STATUS"].Caption = "STATUS";
            viewSub.Columns["STATUS"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["STATUS"].Width = 10;
            //viewSub.Columns["STATUS"].VisibleIndex = 10;

            viewSub.Columns["ORDER_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["ORDER_ID"].Visible = false;
            viewSub.Columns["ORDER_ID"].Caption = "ORDER_ID";
            viewSub.Columns["ORDER_ID"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["ORDER_ID"].Width = 10;
            //viewSub.Columns["ORDER_ID"].VisibleIndex = 11;

            viewSub.Columns["EXAM_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["EXAM_ID"].Visible = false;
            viewSub.Columns["EXAM_ID"].Caption = "EXAM_ID";
            viewSub.Columns["EXAM_ID"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["EXAM_ID"].Width = 10;
            //viewSub.Columns["EXAM_ID"].VisibleIndex = 12;

            viewSub.Columns["MODALITY_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["MODALITY_ID"].Visible = false;
            viewSub.Columns["MODALITY_ID"].Caption = "MODALITY_ID";
            viewSub.Columns["MODALITY_ID"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["MODALITY_ID"].Width = 10;
            //viewSub.Columns["MODALITY_ID"].VisibleIndex = 13;

            viewSub.Columns["MODALITY_UID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["MODALITY_UID"].Visible = false;
            viewSub.Columns["MODALITY_UID"].Caption = "MODALITY_UID";
            viewSub.Columns["MODALITY_UID"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["MODALITY_UID"].Width = 10;
            //viewSub.Columns["MODALITY_UID"].VisibleIndex = 14;

            viewSub.Columns["MODALITY_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewSub.Columns["MODALITY_NAME"].Visible = false;
            viewSub.Columns["MODALITY_NAME"].Caption = "EXAM_UID";
            viewSub.Columns["MODALITY_NAME"].OptionsColumn.ReadOnly = true;
            viewSub.Columns["MODALITY_NAME"].Width = 10;
            //viewSub.Columns["MODALITY_NAME"].VisibleIndex = 15;

            #endregion
        }

        private void btnPay_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            DataRow dr = viewMaster.GetDataRow(viewMaster.FocusedRowHandle);
            if (dr != null)
            {
                if (dr.ItemArray.Length > 0)
                {
                    if (dr["STATUS"].ToString() == "UNPAID")
                    {
                        if (radioGroup1.SelectedIndex == 0)
                        {
                            FIN_RECEIVE_FORM frm = new FIN_RECEIVE_FORM(Convert.ToInt64(dr["PAY_ID"]), dr["HN"].ToString(), dteFromdate.DateTime, dteTodate.DateTime);
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.Text = "Payment";
                            frm.ShowDialog();
                            setDataGrid();
                            setGrid();
                        }
                        else if (radioGroup1.SelectedIndex == 1)
                        {
                            FIN_RECEIVE_FORM frm = new FIN_RECEIVE_FORM(Convert.ToInt64(dr["PAY_ID"]), dr["HN"].ToString());
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.Text = "Payment";
                            frm.ShowDialog();
                            setDataGridByHN();
                            setGrid();
                        }
                    }

                }
            }

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                pncHN.Visible = false;
                pncDatetime.Visible = true;
            }
            else
            {
                pncDatetime.Visible = false;
                pncHN.Visible = true;
            }
        }

        private void txtHn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                setDataGridByHN();
                setGrid();
            }
        }

        private void ccbModality_EditValueChanged(object sender, EventArgs e)
        {
            if (firstLoad) return;

            checkCanSearch = true;
            modID2.Clear();
            for (int i = 0; i < ccbModality.Properties.Items.Count; i++)
            {
                if (ccbModality.Properties.Items[i].CheckState == CheckState.Checked)
                {
                    modID2.Add(modID[i]);
                }
            }
            if (modID2.Count > 0)
            {
                if (radioGroup1.SelectedIndex == 0)
                {
                    setDataGrid();
                    setGrid();
                }
                else if (radioGroup1.SelectedIndex == 1)
                {
                    setDataGridByHN();
                    setGrid();
                }
            }
            else
            {
                checkCanSearch = false;
            }

        }
    }
}