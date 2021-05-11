using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraGrid;

using RIS.BusinessLogic;
using RIS.Common.Common;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Data.SqlClient;
using System.Globalization;
using RIS.Common;
using RIS.Forms.GBLMessage;


namespace RIS.Forms.Technologist
{
    public partial class Distribution_Channel :Form
    {
        RIS.Forms.GBLMessage.MyMessageBox msg = new RIS.Forms.GBLMessage.MyMessageBox();
        private int SearchEMPID,ReDisExmpid;
        private string Tab = "Dis";
        private DataTable dtgDrag;
        private DataTable KeepAcc;
        bool ItemFlag = false;
        private Graphics Grp;
        private Rectangle Rta;
        private string GridChoose;
        private RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
        GBLEnvVariable env = new GBLEnvVariable();
        //private RepositoryItemCheckEdit chk = new RepositoryItemCheckEdit();

        UUL.ControlFrame.Controls.TabControl tabcontrol;
        public Distribution_Channel(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            tabcontrol = clsCtl;
            tabcontrol.ClosePressed += new EventHandler(tabcontrol_ClosePressed);
        }

        private void tabcontrol_ClosePressed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Distribution_Channel_Load(object sender, EventArgs e)
        {
            
            txtAssignSearch.Enabled = false;
            SetShowGrid("All");
            SetNullGrid();
            chkAutoaddtolist.Checked = true;
            bindData();
        }
        private void SetNullGrid()
        {

            ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
            ge.DistributionNew.selectcase = 0;
            ge.DistributionNew.EMP_ID = 000;
            ge.Invoke();
            DataSet ds = ge.ResultSet;
            gridControl1.DataSource = ds.Tables[0];
            SetColumnGrid();
        }
        private void bindData()
        {
            txtAssignSearch.Text = "Rad. ID/Rad. Name";
            txtAssignDis.Text = "Rad. ID/Rad. Name";
            dateEdit1.Text = "DD/MM/YYYY";
            dateEdit2.Text = "DD/MM/YYYY";

            txtAccessionDis.Enabled = false;
            txtHnDis.Enabled = false;

            //btnDistribution.Enabled = false;
            //btnDelete.Enabled = false;


            gridControl1.DataSource = null;

            grdHNMain.DataSource = null;
            grdHNselect.DataSource = null;
            SetShowGrid("All");

        }

        #region LookUp

        private void btnSearchS_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;

            txtAccessionDis.Enabled = false;
            txtHnDis.Enabled = false;

            txtAccessionSearch.Text = "";
            txtHnSearch.Text = "";
            dateEdit1.Text = "DD/MM/YYYY";
            dateEdit2.Text = "DD/MM/YYYY";
            //dateEdit1.Focus();
            btnSearch.Focus();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnSearchS_Clicks);
            lv.AddColumn("EMP_UID", "EMP NAME", true, true);
            lv.AddColumn("FULLNAME", "Name", true, true);
            lv.AddColumn("EMP_ID", "ID", false, true);
            lv.Text = "Radiologist Detail List";
            lv.Size = new Size(600, 400);
            ProcessGetDistributeNew geD = new ProcessGetDistributeNew();
            geD.DistributionNew.selectcase = 19;
            geD.Invoke();
            DataTable dtt = geD.ResultSet.Tables[0];
            lv.Data = dtt;
            //lv.Data = RIS.BusinessLogic.Order.SelectHNAll();
            lv.ShowBox();
        }
        private void btnSearchS_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtAssignSearch.Text = retValue[1];
            SearchEMPID = Convert.ToInt32(retValue[2]);
            dateEdit1.Focus();
        }
        private void btnSearchD_Click(object sender, EventArgs e)
        {
            txtHnDis.Enabled = true;
            txtAccessionDis.Enabled = true;
            txtHnDis.Text = "";
            txtAccessionDis.Text = "";
            txtAccessionDis.Focus();
            ProcessGetDistributeNew geD = new ProcessGetDistributeNew();
            geD.DistributionNew.selectcase = 19;
            geD.Invoke();
            DataTable dtt = geD.ResultSet.Tables[0];

            gridControl1.DataSource = null;
            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnSearchD_Clicks);
            lv.AddColumn("EMP_UID", "EMP NAME", true, true);
            lv.AddColumn("FULLNAME", "Name", true, true);
            lv.AddColumn("EMP_ID", "ID", false, true);
            lv.Text = "Radiologist Detail List";
            lv.Size = new Size(600, 400);
            lv.Data = dtt;
            lv.ShowBox();
        }
        private void btnSearchD_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            this.txtHnDis.Text = "";
            gridControl1.DataSource = null;
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtAssignDis.Text = retValue[1];
            SearchEMPID = Convert.ToInt32(retValue[2]);

            txtAccessionDis.Focus();
        }
        private void btnReDistribute_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnReDistribute_Clicks);
            lv.AddColumn("EMP_UID", "EMP NAME", true, true);
            lv.AddColumn("FULLNAME", "Name", true, true);
            lv.AddColumn("EMP_ID", "ID", false, true);
            lv.Text = "Radiologist Detail List";
            lv.Size = new Size(600, 400);
            ProcessGetDistributeNew geD = new ProcessGetDistributeNew();
            geD.DistributionNew.selectcase = 19;
            geD.Invoke();
            DataTable dtt = geD.ResultSet.Tables[0];
            lv.Data = dtt;
            //lv.Data = RIS.BusinessLogic.Order.SelectHNAll();
            lv.ShowBox();
        }
        private void btnReDistribute_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtToRadiologist.Text = retValue[1];
            ReDisExmpid = Convert.ToInt32(retValue[2]);
        } 

        #endregion

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }
        private void ClearSearch()
        {
            gridControl1.DataSource = null;
            txtAssignSearch.Text = "Rad. ID/Rad. Name";
            dateEdit1.Text = "DD/MM/YYYY";
            dateEdit2.Text = "DD/MM/YYYY";
            txtHnSearch.Text = "";
            txtAccessionSearch.Text = "";
            txtAssignSearch.Focus();
            SearchEMPID = 0;
        }
        private void btnClearDistribute_Click(object sender, EventArgs e)
        {
            ClearDis();
        }
        private void ClearDis()
        {
            txtAccessionDis.Text = "";
            txtAssignDis.Text = "Rad. ID/Rad. Name";
            txtHnDis.Text = "";
            chkAutoaddtolist.Checked = true;

            bindData();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            if (txtAssignSearch.Text == "" || txtAssignSearch.Text == "Rad. ID/Rad. Name" && txtHnSearch.Text == "" && txtAccessionSearch.Text == "" && dateEdit1.Text == "DD/MM/YYYY" && dateEdit2.Text == "DD/MM/YYYY")
            {
                msg.ShowAlert("UID4006",new GBLEnvVariable().CurrentLanguageID);
            }
            else
            {

                try
                {
                    SearchInSearchCriteria();
                    DataTable dtCount = (DataTable)gridControl1.DataSource;
                }
                catch (Exception er) {
                    //MessageBox.Show(er.Message); 
                }
            }
        }

        private void SearchInSearchCriteria()
        {
                try
                {
                    /*-------------------------------select One Choice--------------------------------------------*/
                    if (txtAssignSearch.Text != "" && txtAssignSearch.Text != "Rad. ID/Rad. Name" && txtHnSearch.Text == "" && txtAccessionSearch.Text == "" && dateEdit1.Text == "DD/MM/YYYY" && dateEdit2.Text == "DD/MM/YYYY")
                    {
                        ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                        ge.DistributionNew.selectcase = 0;
                        ge.DistributionNew.EMP_ID = SearchEMPID;
                        ge.Invoke();
                        DataSet ds = ge.ResultSet;

                        gridControl1.DataSource = ds.Tables[0];
                        SetColumnGrid();
                        this.advBandedGridView1.BestFitColumns();

                    }
                    else if (txtAssignSearch.Text == "" || txtAssignSearch.Text == "Rad. ID/Rad. Name" && txtHnSearch.Text.Trim() != "" && txtAccessionSearch.Text == "" && dateEdit1.Text == "DD/MM/YYYY" && dateEdit2.Text == "DD/MM/YYYY")
                    {
                        ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                        ge.DistributionNew.selectcase = 2;
                        ge.DistributionNew.hn = txtHnSearch.Text;
                        //ge.DistributionNew.EMP_ID = SearchEMPID;
                        ge.Invoke();
                        DataSet ds = ge.ResultSet;


                        gridControl1.DataSource = ds.Tables[0];
                        SetColumnGrid();
                        this.advBandedGridView1.BestFitColumns();
                    }
                    else if (txtAssignSearch.Text == "" || txtAssignSearch.Text == "Rad. ID/Rad. Name" && txtHnSearch.Text == "" && txtAccessionSearch.Text.Trim() !="" && dateEdit1.Text == "DD/MM/YYYY" && dateEdit2.Text == "DD/MM/YYYY" )
                    {
                        ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                        ge.DistributionNew.selectcase = 1;
                        ge.DistributionNew.accessionno = txtAccessionSearch.Text;
                        //ge.DistributionNew.EMP_ID = SearchEMPID;
                        ge.Invoke();
                        DataSet ds = ge.ResultSet;

                        gridControl1.DataSource = ds.Tables[0];
                        SetColumnGrid();
                        this.advBandedGridView1.BestFitColumns();
                    }
                    else if (txtAssignSearch.Text == "" || txtAssignSearch.Text == "Rad. ID/Rad. Name" && txtHnSearch.Text == "" && txtAccessionSearch.Text == "" && dateEdit1.Text != "DD/MM/YYYY" && dateEdit2.Text != "DD/MM/YYYY")
                    {
                        ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                        ge.DistributionNew.selectcase = 3;
                        ge.DistributionNew.datefrom = dateEdit1.DateTime;
                        ge.DistributionNew.todate = dateEdit2.DateTime.AddDays(1);
                        ge.Invoke();
                        DataSet ds = ge.ResultSet;


                        gridControl1.DataSource = ds.Tables[0];
                        SetColumnGrid();
                        this.advBandedGridView1.BestFitColumns();
                    }
                    /*-------------------------------select two Choice--------------------------------------------*/
                    else if (txtAssignSearch.Text != "" && txtAssignSearch.Text != "Rad. ID/Rad. Name" && txtHnSearch.Text == "" && txtAccessionSearch.Text.Trim() != "" && dateEdit1.Text == "DD/MM/YYYY" && dateEdit2.Text == "DD/MM/YYYY")
                    {
                        ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                        ge.DistributionNew.selectcase = 4;
                        ge.DistributionNew.EMP_ID = SearchEMPID;
                        ge.DistributionNew.accessionno = txtAccessionSearch.Text;
                        ge.Invoke();
                        DataSet ds = ge.ResultSet;

                        gridControl1.DataSource = ds.Tables[0];
                        SetColumnGrid();
                        this.advBandedGridView1.BestFitColumns();
                    }
                    else if (txtAssignSearch.Text != "" && txtAssignSearch.Text != "Rad. ID/Rad. Name" && txtHnSearch.Text.Trim() != "" && txtAccessionSearch.Text == "" && dateEdit1.Text == "DD/MM/YYYY" && dateEdit2.Text == "DD/MM/YYYY")
                    {
                        ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                        ge.DistributionNew.selectcase = 5;
                        ge.DistributionNew.EMP_ID = SearchEMPID;
                        ge.DistributionNew.hn = txtHnSearch.Text;
                        ge.Invoke();
                        DataSet ds = ge.ResultSet;


                        gridControl1.DataSource = ds.Tables[0];
                        SetColumnGrid();
                        this.advBandedGridView1.BestFitColumns();
                    }

                    else if (txtAssignSearch.Text != "" && txtAssignSearch.Text != "Rad. ID/Rad. Name" && txtHnSearch.Text == "" && txtAccessionSearch.Text == "" && dateEdit1.Text != "DD/MM/YYYY" && dateEdit2.Text != "DD/MM/YYYY")
                    {
                        ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                        ge.DistributionNew.selectcase = 6;
                        ge.DistributionNew.EMP_ID = SearchEMPID;
                        ge.DistributionNew.datefrom = dateEdit1.DateTime;
                        ge.DistributionNew.todate = dateEdit2.DateTime.AddDays(1);
                        ge.Invoke();
                        DataSet ds = ge.ResultSet;

                        gridControl1.DataSource = ds.Tables[0];
                        SetColumnGrid();
                        this.advBandedGridView1.BestFitColumns();
                    }
                    #region Search All Case
                    //else if (txtAssignSearch.Text == "" || txtAssignSearch.Text == "Rad. ID/Rad. Name" && txtHnSearch.Text.Trim() != "" && txtAccessionSearch.Text.Trim() != "" && dateEdit1.Text == "DD/MM/YYYY" && dateEdit2.Text == "DD/MM/YYYY" )
                    //{
                    //    ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                    //    ge.DistributionNew.selectcase = 7;
                    //    //ge.DistributionNew.EMP_ID = SearchEMPID;
                    //    ge.DistributionNew.accessionno = txtAccessionSearch.Text;
                    //    ge.DistributionNew.hn = txtHnSearch.Text;
                    //    ge.Invoke();
                    //    DataSet ds = ge.ResultSet;


                    //    gridControl1.DataSource = ds.Tables[0];
                    //    SetColumnGrid();
                    //    this.advBandedGridView1.BestFitColumns();
                    //}
                    //else if (txtAssignSearch.Text == "" || txtAssignSearch.Text == "Rad. ID/Rad. Name" && txtHnSearch.Text == "" && txtAccessionSearch.Text.Trim() != "" && dateEdit1.Text != "DD/MM/YYYY" && dateEdit2.Text != "DD/MM/YYYY")
                    //{
                    //    ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                    //    ge.DistributionNew.selectcase = 8;
                    //    //ge.DistributionNew.EMP_ID = SearchEMPID;
                    //    ge.DistributionNew.accessionno = txtAccessionSearch.Text;
                    //    ge.DistributionNew.datefrom = Convert.ToDateTime(dateEdit1.DateTime.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    //    ge.DistributionNew.todate = Convert.ToDateTime(dateEdit2.DateTime.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    //    ge.Invoke();
                    //    DataSet ds = ge.ResultSet;


                    //    gridControl1.DataSource = ds.Tables[0];
                    //    SetColumnGrid();
                    //    this.advBandedGridView1.BestFitColumns();
                    //}
                    //else if (txtAssignSearch.Text == "" || txtAssignSearch.Text == "Rad. ID/Rad. Name" && txtHnSearch.Text.Trim() != "" && txtAccessionSearch.Text == "" && dateEdit1.Text != "DD/MM/YYYY" && dateEdit2.Text != "DD/MM/YYYY")
                    //{
                    //    ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                    //    ge.DistributionNew.selectcase = 9;
                    //    //ge.DistributionNew.EMP_ID = SearchEMPID;
                    //    ge.DistributionNew.hn = txtHnSearch.Text;
                    //    ge.DistributionNew.datefrom = Convert.ToDateTime(dateEdit1.DateTime.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    //    ge.DistributionNew.todate = Convert.ToDateTime(dateEdit2.DateTime.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    //    ge.Invoke();
                    //    DataSet ds = ge.ResultSet;

                    //    gridControl1.DataSource = ds.Tables[0];
                    //    SetColumnGrid();
                    //    this.advBandedGridView1.BestFitColumns();
                    //}
                    ///*-------------------------------select three Choice--------------------------------------------*/
                    //else if (txtAssignSearch.Text != "" && txtAssignSearch.Text != "Rad. ID/Rad. Name" && txtHnSearch.Text.Trim() != "" && txtAccessionSearch.Text.Trim() != "" && dateEdit1.Text == "DD/MM/YYYY" && dateEdit2.Text == "DD/MM/YYYY")
                    //{
                    //    ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                    //    ge.DistributionNew.selectcase = 10;
                    //    ge.DistributionNew.EMP_ID = SearchEMPID;
                    //    ge.DistributionNew.accessionno = txtAccessionSearch.Text;
                    //    ge.DistributionNew.hn = txtHnSearch.Text;
                    //    ge.Invoke();
                    //    DataSet ds = ge.ResultSet;

                    //    gridControl1.DataSource = ds.Tables[0];
                    //    SetColumnGrid();
                    //    this.advBandedGridView1.BestFitColumns();
                    //}
                    //else if (txtAssignSearch.Text != "" && txtAssignSearch.Text != "Rad. ID/Rad. Name" && txtHnSearch.Text == "" && txtAccessionSearch.Text.Trim() != "" && dateEdit1.Text != "DD/MM/YYYY" && dateEdit2.Text != "DD/MM/YYYY")
                    //{
                    //    ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                    //    ge.DistributionNew.selectcase = 11;
                    //    ge.DistributionNew.EMP_ID = SearchEMPID;
                    //    ge.DistributionNew.accessionno = txtAccessionSearch.Text;
                    //    ge.DistributionNew.datefrom = Convert.ToDateTime(dateEdit1.DateTime.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    //    ge.DistributionNew.todate = Convert.ToDateTime(dateEdit2.DateTime.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    //    ge.Invoke();
                    //    DataSet ds = ge.ResultSet;


                    //    gridControl1.DataSource = ds.Tables[0];
                    //    SetColumnGrid();
                    //    this.advBandedGridView1.BestFitColumns();
                    //}
                    //else if (txtAssignSearch.Text == "" || txtAssignSearch.Text == "Rad. ID/Rad. Name" && txtHnSearch.Text.Trim() != "" && txtAccessionSearch.Text.Trim() != "" && dateEdit1.Text != "DD/MM/YYYY" && dateEdit2.Text != "DD/MM/YYYY")
                    //{
                    //    ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                    //    ge.DistributionNew.selectcase = 12;
                    //    //ge.DistributionNew.EMP_ID = SearchEMPID;
                    //    ge.DistributionNew.hn = txtHnSearch.Text;
                    //    ge.DistributionNew.accessionno = txtAccessionSearch.Text;
                    //    ge.DistributionNew.datefrom = Convert.ToDateTime(dateEdit1.DateTime.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    //    ge.DistributionNew.todate = Convert.ToDateTime(dateEdit2.DateTime.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    //    ge.Invoke();
                    //    DataSet ds = ge.ResultSet;


                    //    gridControl1.DataSource = ds.Tables[0];
                    //    SetColumnGrid();
                    //    this.advBandedGridView1.BestFitColumns();
                    //}
                    ///*-------------------------------select four Choice--------------------------------------------*/
                    //else if (txtAssignSearch.Text != "" && txtAssignSearch.Text != "Rad. ID/Rad. Name" && txtHnSearch.Text.Trim() != "" && txtAccessionSearch.Text.Trim() != "" && dateEdit1.Text != "DD/MM/YYYY" && dateEdit2.Text != "DD/MM/YYYY")
                    //{
                    //    ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                    //    ge.DistributionNew.selectcase = 15;
                    //    ge.DistributionNew.EMP_ID = SearchEMPID;
                    //    ge.DistributionNew.hn = txtHnSearch.Text;
                    //    ge.DistributionNew.accessionno = txtAccessionSearch.Text;
                    //    ge.DistributionNew.datefrom = Convert.ToDateTime(dateEdit1.DateTime.Year.ToString("yyyy-MM-dd HH:mm:ss"));//dateEdit1.DateTime.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    //    ge.DistributionNew.todate = Convert.ToDateTime(dateEdit2.DateTime.Year.ToString("yyyy-MM-dd HH:mm:ss"));
                    //    ge.Invoke();
                    //    DataSet ds = ge.ResultSet;

                    //    gridControl1.DataSource = ds.Tables[0];
                    //    SetColumnGrid();
                    //    this.advBandedGridView1.BestFitColumns();
                    //} 
                    #endregion
                }
                catch
                {
                    msg.ShowAlert("UID4006", new GBLEnvVariable().CurrentLanguageID);
                }

        }

        private void chkAutoaddtolist_EditValueChanged(object sender, EventArgs e)
        {
            if (chkAutoaddtolist.Checked == true)
            {
                btnAddtolist.Enabled = false;
            }
            else if (chkAutoaddtolist.Checked == false)
            {
                btnAddtolist.Enabled = true;
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtt = (DataTable)gridControl1.DataSource;
                if (dtt.Rows.Count > 0)
                {
                    advBandedGridView1.DeleteSelectedRows();
                }
                else
                {
                    viewHNMain.DeleteSelectedRows();
                }


                //dtt.AcceptChanges();

                //for (int i = 0; i < dtt.Rows.Count; i++)
                //{
                //    dtt.AcceptChanges();
                //    if (dtt.Rows[i]["All"].ToString() == "Y")
                //    {
                //        advBandedGridView1.SelectRow(i);
                //        advBandedGridView1.DeleteRow(i);
                //    }
                //    dtt.AcceptChanges();
                //    advBandedGridView1.RefreshData();
                //    //advBandedGridView1.DeleteSelectedRows();
                //}

                //dtt.AcceptChanges();

                DataTable dtTemp = new DataTable();
                dtt = dtTemp.Copy();
                //viewHNMain.DeleteSelectedRows();
            }
            catch (Exception exp)
            {
            }

        
        }
        private void SelectAll(string flag)
        {
            if (flag == "AC")
            {
            txtAccessionDis.SelectionStart = 0;
            txtAccessionDis.SelectionLength = txtAccessionDis.Text.Length;
            txtAccessionDis.Focus();
            }
            else if (flag == "HN")
            {
                txtHnDis.SelectionStart = 0;
                txtHnDis.SelectionLength = txtHnDis.Text.Length;
                txtHnDis.Focus();
            }
            else if (flag == "HNS")
            {
                txtHnSearch.SelectionStart = 0;
                txtHnSearch.SelectionLength = txtHnSearch.Text.Length;
                txtHnSearch.Focus();
            }
            else if (flag == "ACS")
            {
                txtAccessionSearch.SelectionStart = 0;
                txtAccessionSearch.SelectionLength = txtAccessionSearch.Text.Length;
                txtAccessionSearch.Focus();
            }

        }
        private void btnAddtolist_Click(object sender, EventArgs e)
        {
                GetAccesionPageDistribute();
        }

        private void btnDistribution_Click(object sender, EventArgs e)
        {
            if (xtraTabControl2.SelectedTabPage == xtabGridAll)
            {
                if (gridControl1.DataSource == null)
                {
                    return;
                }
            }
            else if (xtraTabControl2.SelectedTabPage == xtabGridHN)
            {
                if (grdHNMain.DataSource == null)
                {
                    return;
                }
            }
            //gridControl1.DataSource = null;
            txtAssignDis.Text = "";
            txtAccessionDis.Text = "";
            txtHnDis.Text = "";
            txtAccessionSearch.Text = "";
            txtAssignSearch.Text = "";
            txtHnSearch.Text = "";
            UpdateData();
            bindData();

        }
        private void UpdateData()
        {
            RIS.Common.Common.GBLEnvVariable env = new GBLEnvVariable();


                if (Tab == "Search")
                {
                    DataTable dtg = (DataTable)gridControl1.DataSource;
                    DataTable dtt = dtg.Copy();

                    dtt.AcceptChanges();

                    for (int i = 0; i < dtt.Rows.Count; i++)
                    {
                        ProcessUpdateDistributionNew upd = new ProcessUpdateDistributionNew();
                        upd.DistributionNew.accessionno = dtt.Rows[i]["Accession NO."].ToString();
                        if (string.IsNullOrEmpty(dtt.Rows[i]["Assigned Rad."].ToString()))
                        {
                            upd.DistributionNew.assignedTo = 0;

                            //upd.DistributionNew.PRIORITY = dtt.Rows[i]["Priority"].ToString();
                            //upd.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                            //upd.Invoke();
                        }
                        else
                        {
                            if (KeepAcc != null)
                            {


                                foreach (DataRow drTemp in KeepAcc.Rows)
                                {
                                    if (dtt.Rows[i]["Accession NO."].ToString() == drTemp["Accession"].ToString())
                                    {
                                        upd.DistributionNew.assignedTo = Convert.ToInt32(dtt.Rows[i]["Assigned Rad."]);

                                        upd.DistributionNew.PRIORITY = dtt.Rows[i]["Priority"].ToString();
                                        upd.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                                        upd.Invoke();
                                    }

                                }
                            }
                        }
                    }
                }
                else if (Tab == "Dis")
                {
                    if (grdHNMain.DataSource != null)
                    {
                        DataTable dtgHN = (DataTable)grdHNMain.DataSource;
                        DataTable dttHN = dtgHN.Copy();
                        dttHN.AcceptChanges();


                        for (int i = 0; i < dttHN.Rows.Count; i++)
                        {
                            ProcessUpdateDistributionNew upd = new ProcessUpdateDistributionNew();
                            upd.DistributionNew.accessionno = dttHN.Rows[i]["Accession NO."].ToString();
                            upd.DistributionNew.assignedTo = SearchEMPID;
                            upd.DistributionNew.PRIORITY = dttHN.Rows[i]["Priority"].ToString();
                            upd.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                            upd.Invoke();
                        } 
                    }
                    else if (gridControl1.DataSource != null)
                    {
                        DataTable dtgAC = (DataTable)gridControl1.DataSource;
                        DataTable dttAC = dtgAC.Copy();
                        dttAC.AcceptChanges();

                        for (int z = 0; z < dttAC.Rows.Count; z++)
                        {
                            ProcessUpdateDistributionNew upd = new ProcessUpdateDistributionNew();
                            upd.DistributionNew.accessionno = dttAC.Rows[z]["Accession NO."].ToString();
                            upd.DistributionNew.assignedTo = SearchEMPID;
                            upd.DistributionNew.PRIORITY = dtgAC.Rows[z]["Priority"].ToString();
                            upd.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                            upd.Invoke();
                        }
                    }
                }
        }
        private void SetColumnGrid()
        {
            GridChoose = "Main";   
            //---Focus row---//
            advBandedGridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
            //--------------------------//
            advBandedGridView1.OptionsSelection.MultiSelect = true;
            advBandedGridView1.OptionsView.ShowGroupPanel = false;
            //advBandedGridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            advBandedGridView1.OptionsView.AutoCalcPreviewLineCount = true;
            advBandedGridView1.OptionsView.ShowAutoFilterRow = true;
            advBandedGridView1.OptionsView.ShowBands = false;
            advBandedGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            for (int i = 0; i < advBandedGridView1.Columns.Count; i++)
            {
                advBandedGridView1.Columns[i].Visible = false;
            }

            //DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkGrid = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            //chkGrid.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            //chkGrid.ValueChecked = "Y";
            //chkGrid.ValueUnchecked = "N";
            //chkGrid.Click += new EventHandler(chkGrid_Click);

            //advBandedGridView1.Columns["All"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //advBandedGridView1.Columns["All"].Caption = "";
            //advBandedGridView1.Columns["All"].Visible = true;
            //advBandedGridView1.Columns["All"].ColumnEdit = chkGrid;
            
            advBandedGridView1.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["HN"].Visible = true;
            advBandedGridView1.Columns["HN"].OptionsColumn.ReadOnly = true;

            advBandedGridView1.Columns["Pat.Name"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Pat.Name"].Visible = true;
            advBandedGridView1.Columns["Pat.Name"].Caption = "Pat.Name";
            advBandedGridView1.Columns["Pat.Name"].OptionsColumn.ReadOnly = true;

            advBandedGridView1.Columns["Exam Code"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Exam Code"].Visible = true;
            advBandedGridView1.Columns["Exam Code"].Caption = "Exam Code";
            advBandedGridView1.Columns["Exam Code"].OptionsColumn.ReadOnly = true;

            advBandedGridView1.Columns["Exam Name"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Exam Name"].Visible = true;
            advBandedGridView1.Columns["Exam Name"].Caption = "Exam Name";
            advBandedGridView1.Columns["Exam Name"].OptionsColumn.ReadOnly = true;

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtDate = new RepositoryItemTextEdit();

            advBandedGridView1.Columns["Order Date Time"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Order Date Time"].Visible = true;
            advBandedGridView1.Columns["Order Date Time"].ColumnEdit = txtDate;
            advBandedGridView1.Columns["Order Date Time"].Caption = "Order Date Time";
            advBandedGridView1.Columns["Order Date Time"].OptionsColumn.ReadOnly = true;

            advBandedGridView1.Columns["Accession No."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Accession No."].Visible = true;
            advBandedGridView1.Columns["Accession No."].Caption = "Accession No.";
            advBandedGridView1.Columns["Accession No."].OptionsColumn.ReadOnly = true;


            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox imCmb = new RepositoryItemImageComboBox();
            imCmb.SmallImages = this.imgWL;
            imCmb.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "R", 6),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "U", 7),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "S", 8)});

            imCmb.Buttons.Clear();

            advBandedGridView1.Columns["Priority"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Priority"].Visible = true;
            advBandedGridView1.Columns["Priority"].ColumnEdit = imCmb;
            advBandedGridView1.Columns["Priority"].Caption = "Priority";
            advBandedGridView1.Columns["Priority"].ColVIndex = 0;
            advBandedGridView1.Columns["Priority"].OptionsColumn.ReadOnly = true;

            advBandedGridView1.Columns["Result Status"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Result Status"].Visible = true;
            advBandedGridView1.Columns["Result Status"].Caption = "Result Status";
            advBandedGridView1.Columns["Result Status"].OptionsColumn.ReadOnly = true;
            
            ProcessGetDistributeNew dis = new ProcessGetDistributeNew();
            dis.DistributionNew.selectcase = 19;
            dis.Invoke();
            DataSet dstt = dis.ResultSet;

            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit grdCmd = new RepositoryItemGridLookUpEdit();
            grdCmd.DataSource = dstt.Tables[0];

            #region SetGrdLookup
            grdCmd.View.OptionsView.ShowAutoFilterRow = true;
            grdCmd.View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;

            grdCmd.View.Columns["EMP_UID"].Visible = true;
            grdCmd.View.Columns["EMP_UID"].Caption = "Code";


            grdCmd.View.Columns["FULLNAME"].Visible = true;
            grdCmd.View.Columns["EMP_ID"].Visible = false;

            #endregion

            grdCmd.ValueMember = "EMP_ID";
            grdCmd.DisplayMember = "FULLNAME";
            grdCmd.NullText = "";
            grdCmd.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(grdCmd_CloseUp);

            //DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmb = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //for (int i = 0; i < dstt.Tables[0].Rows.Count; i++)
            //{
            //    cmb.Items.Add(dstt.Tables[0].Rows[i]["FULLNAME"].ToString());
            //}
            
            advBandedGridView1.Columns["Assigned Rad."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Assigned Rad."].Visible = true;
            advBandedGridView1.Columns["Assigned Rad."].ColumnEdit =grdCmd;
            advBandedGridView1.Columns["Assigned Rad."].Caption = "Assigned Rad.";
            advBandedGridView1.Columns["Assigned Rad."].OptionsColumn.ReadOnly = false;

            advBandedGridView1.Columns["Distributed By."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Distributed By."].Visible = true;
            advBandedGridView1.Columns["Distributed By."].Caption = "Distributed By.";
            advBandedGridView1.Columns["Distributed By."].OptionsColumn.ReadOnly = true;

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit textDis = new RepositoryItemTextEdit();
            advBandedGridView1.Columns["Distributed ON."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Distributed ON."].Visible = true;
            advBandedGridView1.Columns["Distributed ON."].Caption = "Distributed ON.";
            advBandedGridView1.Columns["Distributed ON."].ColumnEdit = textDis;
            advBandedGridView1.Columns["Distributed ON."].OptionsColumn.ReadOnly = true;

            advBandedGridView1.Columns["AGE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["AGE"].Visible = true;
            advBandedGridView1.Columns["AGE"].Caption = "AGE";
            advBandedGridView1.Columns["AGE"].OptionsColumn.ReadOnly = true;

            advBandedGridView1.Columns["OPD"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["OPD"].Visible = true;
            advBandedGridView1.Columns["OPD"].Caption = "Order Dept.";
            advBandedGridView1.Columns["OPD"].OptionsColumn.ReadOnly = true;
        }

        public void grdCmd_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                if (e.AcceptValue)
                {


                    if (dr["Result Status"].ToString() != "Finalize")
                    {
                        string _id = msg.ShowAlert("UID4008", env.CurrentLanguageID);
                        if (_id == "3")
                        {
                            KeepAcc = new DataTable();
                            KeepAcc.Columns.Add("Accession");
                            KeepAcc.AcceptChanges();

                            DataRow drNew = KeepAcc.NewRow();
                            drNew["Accession"] = dr["Accession No."];

                            KeepAcc.Rows.Add(drNew);

                            ProcessUpdateDistributionNew upDis = new ProcessUpdateDistributionNew();
                            upDis.DistributionNew.accessionno = dr["Accession No."].ToString();
                            upDis.DistributionNew.assignedTo = (int)e.Value;//dtGW.Rows[viewDisWorklist.FocusedRowHandle]["ASSIGNED TO"];
                            upDis.DistributionNew.PRIORITY = dr["Priority"].ToString();
                            upDis.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                            upDis.Invoke();
                        }
                        else if (_id == "2")
                        {
                            ProcessUpdateDistributionNew upDis = new ProcessUpdateDistributionNew();
                            upDis.DistributionNew.accessionno = dr["Accession No."].ToString();
                            upDis.DistributionNew.assignedTo = 0;//dtGW.Rows[viewDisWorklist.FocusedRowHandle]["ASSIGNED TO"];
                            upDis.DistributionNew.PRIORITY = dr["Priority"].ToString();
                            upDis.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                            upDis.Invoke();
                            e.Value = 0;
                        }
                        else
                        {
                            e.Value = dr["Assigned Rad."];
                        }

                    }
                    else
                    {
                        string _id = msg.ShowAlert("UID4021", env.CurrentLanguageID);
                        e.Value = 0;
                    }
                }
                    SearchInSearchCriteria();
            }
            catch (Exception ex)
            { }
        }

        private void chkGrid_Click(object sender, EventArgs e)
        {
            //DataTable dtt = (DataTable)gridControl1.DataSource;

            //if (advBandedGridView1.FocusedRowHandle <0)
            //{
            //    return;
            //}
            //if (chk.ValueChecked == "Y")
            //{
            //    dtt.Rows[advBandedGridView1.FocusedRowHandle]["All"] = "N";  
            //}
            //else
            //{
            //    dtt.Rows[advBandedGridView1.FocusedRowHandle]["All"] = "Y";
            //}
            //advBandedGridView1.SelectRow(advBandedGridView1.FocusedRowHandle);

            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (advBandedGridView1.FocusedRowHandle >= 0)
            {

                DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                dr["All"] = chk.Checked ? "N" : "Y";
                //PreItemflag = false;
            }

        }
        private void SetColumnGridHN()
        {
            GridChoose = "HN";
            viewHNselect.Columns["All"].Visible = false;
            viewHNselect.OptionsSelection.EnableAppearanceFocusedRow = true;
            viewHNselect.OptionsSelection.EnableAppearanceFocusedCell = false;
            viewHNselect.OptionsSelection.InvertSelection = false;
            //viewHNselect.OptionsSelection.MultiSelect = true;
            viewHNselect.FocusRectStyle = DrawFocusRectStyle.RowFocus;

            ProcessGetDistributeNew dis = new ProcessGetDistributeNew();
            dis.DistributionNew.selectcase = 19;
            dis.Invoke();
            DataSet dstt = dis.ResultSet;
            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit grdCmd = new RepositoryItemGridLookUpEdit();
            grdCmd.DataSource = dstt.Tables[0];

            #region SetGrdLookup
            grdCmd.View.OptionsView.ShowAutoFilterRow = true;
            grdCmd.View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;

            grdCmd.View.Columns["EMP_UID"].Visible = true;
            grdCmd.View.Columns["EMP_UID"].Caption = "Code";


            grdCmd.View.Columns["FULLNAME"].Visible = true;
            grdCmd.View.Columns["EMP_ID"].Visible = false;

            viewHNselect.Columns["Assigned Rad."].ColumnEdit =grdCmd;
            #endregion

            grdCmd.ValueMember = "EMP_ID";
            grdCmd.DisplayMember = "FULLNAME";
            grdCmd.NullText = "";

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit textDis = new RepositoryItemTextEdit();
            viewHNselect.Columns["Distributed ON."].ColumnEdit = textDis;
            /*---------------------------------------------------------------*/


           
            viewHNMain.Columns["All"].Visible = false;
            viewHNMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            viewHNMain.OptionsSelection.EnableAppearanceFocusedRow = true;
            viewHNMain.OptionsSelection.InvertSelection = false;
            viewHNMain.OptionsSelection.MultiSelect = true;
            viewHNMain.FocusRectStyle = DrawFocusRectStyle.RowFocus;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox imCmb = new RepositoryItemImageComboBox();
            imCmb.SmallImages = this.imgWL;
            imCmb.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "R", 6),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "U", 7),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "S", 8)});

            imCmb.Buttons.Clear();

            viewHNMain.Columns["Priority"].ColumnEdit = imCmb;
            viewHNMain.Columns["Priority"].ColVIndex = 0;
            viewHNMain.Columns["Assigned Rad."].ColumnEdit = grdCmd;
            viewHNMain.Columns["Distributed ON."].ColumnEdit = textDis;

            viewHNselect.Columns["Priority"].ColumnEdit = imCmb;
            viewHNselect.Columns["Priority"].ColVIndex = 0;

        }
        private void GetAccesionPageDistribute()
        {
            if (txtAccessionDis.Text.Trim() != "")
            {
                SelectAll("AC");

                ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                ge.DistributionNew.selectcase = 20;
                ge.DistributionNew.accessionno = txtAccessionDis.Text;
                ge.Invoke();
                DataSet dsSearch = ge.ResultSet;

                DataTable dtTemp = new DataTable();

                if (gridControl1.DataSource != null)
                {
                    DataTable dtSearch = new DataTable();
                    dtSearch = dsSearch.Tables[0];
                    dtTemp = (DataTable)gridControl1.DataSource;

                    DataRow[] drs = dtTemp.Select("[Accession No.]='" + txtAccessionDis.Text + "'");
                    if (drs.Length > 0) return;


                    for (int y = 0; y < dtSearch.Rows.Count; y++)
                    {
                        //if (Convert.ToInt32(dtSearch.Rows[y]["Accession No."]) < 0)
                        //{

                            //foreach (DataRow dr in dtSearch.Rows)
                            //{

                            DataRow Newdr = dtTemp.NewRow();

                            Newdr["HN"] = dtSearch.Rows[y]["HN"];
                            Newdr["Pat.Name"] = dtSearch.Rows[y]["Pat.Name"];
                            Newdr["AGE"] = dtSearch.Rows[y]["AGE"];
                            Newdr["Exam Code"] = dtSearch.Rows[y]["Exam Code"];
                            Newdr["Exam Name"] = dtSearch.Rows[y]["Exam Name"];
                            Newdr["Accession No."] = dtSearch.Rows[y]["Accession No."];
                            Newdr["Order Date Time"] = dtSearch.Rows[y]["Order Date Time"];
                            Newdr["Priority"] = dtSearch.Rows[y]["Priority"];
                            Newdr["Result Status"] = dtSearch.Rows[y]["Result Status"];
                            Newdr["Assigned Rad."] = dtSearch.Rows[y]["Assigned Rad."];
                            Newdr["Distributed By."] = dtSearch.Rows[y]["Distributed By."];
                            Newdr["OPD"] = dtSearch.Rows[y]["OPD"];

                            dtTemp.Rows.Add(Newdr);
                            //}

                        //}
                    }
                }
                else
                {
                    dtTemp = dsSearch.Tables[0];
                }
                gridControl1.DataSource = dtTemp;
                SetColumnGrid();
                DataTable dtCount = (DataTable)gridControl1.DataSource;
            }
            else if (txtHnDis.Text.Trim() != "" )
            {
                                    SetShowGrid("HN");

                    ProcessGetDistributeNew geD = new ProcessGetDistributeNew();
                    geD.DistributionNew.selectcase = 21;
                    geD.DistributionNew.hn = txtHnDis.Text.Trim();
                    geD.Invoke();

                    DataSet dsDHN = geD.ResultSet;

                    SelectAll("HN");

                    grdHNselect.DataSource = dsDHN.Tables[0];
                    grdHNMain.DataSource = dsDHN.Tables[0].Clone() ;

                    SetColumnGridHN();

                }

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == pageSearchCriteria)
            {
                gridControl1.DataSource = null;
                Tab = "Search";
                ClearSearch();
                SetShowGrid("All");
                txtAssignSearch.Focus();
                btnDistribution.Visible = true;
                btnClearDistribute.Visible = true;
                btnDelete.Visible = true;

            }
            else if (xtraTabControl1.SelectedTabPage == pageDistributeCriteria)
            {
                gridControl1.DataSource = null;
                Tab = "Dis";
                ClearDis();
                SetShowGrid("All");
                txtAssignDis.Focus();
                btnDistribution.Visible = true;
                btnClearDistribute.Visible = true;
                btnDelete.Visible = true;
            }
            else if (xtraTabControl1.SelectedTabPage == pageDistributionWorklist )
            {
                gridControl1.DataSource = null;
                Tab = "Worklist";
                xtraTabControl2.SelectedTabPage = xtabGridDisList;
                deFromDate.DateTime = DateTime.Now;
                deToDate.DateTime = DateTime.Now;
                Populate(1);
                SetGridWorklist();
                btnDistribution.Visible = false;
                btnClearDistribute.Visible = false;;
                btnDelete.Visible = false;

            }
        }

        #region When hit Enter on S Page

        private void txtAssignSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }
        private void btnSearchS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }


        private void dateEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateEdit2.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void dateEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHnSearch.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }
        private void txtHnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectAll("HNS");
                btnSearch_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }
        private void txtAccessionSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectAll("ACS");
                btnSearch_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }
        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }
        private void btnClearSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }

        #endregion

        #region When hit Enter on D Page

        private void txtAssignDis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchD.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtAccessionDis_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                    GetAccesionPageDistribute();     
            }
        }


        private void txtHnDis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                    SetShowGrid("HN");

                    ProcessGetDistributeNew geD = new ProcessGetDistributeNew();
                    geD.DistributionNew.selectcase = 21;
                    geD.DistributionNew.hn = txtHnDis.Text.Trim();
                    geD.Invoke();

                    DataSet dsDHN = geD.ResultSet;

                    SelectAll("HN");

                    grdHNselect.DataSource = dsDHN.Tables[0];
                    grdHNMain.DataSource = dsDHN.Tables[0].Clone() ;

                    SetColumnGridHN();
            
            }
        } 
        #endregion

        private void SetShowGrid(string flag)
        {
            if (flag == "All")
            {
                xtraTabControl2.SelectedTabPage = xtabGridAll;
            }
            else if (flag == "HN")
            {
                xtraTabControl2.SelectedTabPage = xtabGridHN;
            }
        }

        #region Drag & Drop
        //private void BindGridDrag()
        //{
        //    grdHNselect.DataSource =
        //    gridControl1.DataSource = dataTable1;
        //    gridControl2.DataSource = dataTable1.Clone();
        //}

        GridHitInfo downHitInfo = null;

        private void View_MouseDown(object sender, MouseEventArgs e)
        {
            GridView View = sender as GridView;
            downHitInfo = null;
            GridHitInfo hitInfo = View.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
                downHitInfo = hitInfo;
        }

        private void View_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    DataRow row = view.GetDataRow(downHitInfo.RowHandle);
                    view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                    downHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }

        private void grid_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grid_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            DataTable table = grid.DataSource as DataTable;
            DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
            if (row != null && table != null && row.Table != table)
            {
                table.ImportRow(row);
                row.Delete();
            }
        }

        #endregion

        #region Check All
        private void advBandedGridView1_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            if (e.Column.Caption == "")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                //DrawCheckBox(e.Graphics, e.Bounds, ItemFlag);
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

        private void advBandedGridView1_Click(object sender, EventArgs e)
        {
            GridHitInfo info;

            Point pt = advBandedGridView1.GridControl.PointToClient(Control.MousePosition);
            info = advBandedGridView1.CalcHitInfo(pt);
            if (info.InColumn)
            {
                if (info.Column == null) return;
                if (info.Column.Caption == "")
                {
                    if (ItemFlag == false)
                    {
                        DataTable dtt = (DataTable)gridControl1.DataSource;
                        dtt.AcceptChanges();
                        for (int z = 0; z < dtt.Rows.Count; z++)
                        {
                            dtt.Rows[z]["All"] = "Y";
                        }
                        dtt.AcceptChanges();
                        gridControl1.DataSource = dtt;
                        ItemFlag = true;
                    }
                    else
                    {
                        DataTable dtt = (DataTable)gridControl1.DataSource;
                        dtt.AcceptChanges();
                        for (int z = 0; z < dtt.Rows.Count; z++)
                        {
                            dtt.Rows[z]["All"] = "N";
                        }
                        dtt.AcceptChanges();
                        gridControl1.DataSource = dtt;
                        ItemFlag = false;
                    }
                }
            }
        } 
        #endregion

        #region PopulateGrid

        public void Populate(int sp)
        {

            //CultureInfo culture = new CultureInfo("en-US", true);
            //DateTime _fromdate = Convert.ToDateTime(deFromDate.DateTime,culture);
            //DateTime _todate = Convert.ToDateTime(deToDate.DateTime,culture);
            //DateTime _fromdate = Convert.ToDateTime(dateTimePicker1.Value, culture);
            //DateTime _todate = Convert.ToDateTime(dateTimePicker2.Value, culture);
            try
            {
                ResultEntryWorkList channeldata = new ResultEntryWorkList();
                channeldata.SpType = sp;
                channeldata.FromDate = deFromDate.DateTime;
                channeldata.ToDate = deToDate.DateTime;
                channeldata.OrgID = new GBLEnvVariable().OrgID;
                ProcessGetDistributionChannel prcdist = new ProcessGetDistributionChannel();
                prcdist.ResultEntryWorkList = channeldata;
                prcdist.Invoke();
                DataTable dt = prcdist.ResultSet.Tables[0];

                grdDisWorklist.DataSource = dt;
                //UltraGrid1.Refresh();


                //UltraGrid1.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }


            //Radiologist();
        }

        #endregion PopulateGrid

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 1)
            {
                Populate(2);
                SetGridWorklist();
            }
            else
            {
                Populate(3);
                SetGridWorklist();
            }           
        }
        private void SetGridWorklist()
        {
            GridChoose = "Work";
            viewDisWorklist.OptionsView.ShowAutoFilterRow = true;

            viewDisWorklist.Columns["PRIORITY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["PATIENT NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["EXAM CODE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["EXAM NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["ORDER TIME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["ORDER ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["ACCESSION NO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["ASSIGNED TO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            viewDisWorklist.Columns["PRIORITY"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["HN"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["PATIENT NAME"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["EXAM CODE"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["EXAM NAME"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["ORDER TIME"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["ORDER ID"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["ACCESSION NO"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["ASSIGNED TO"].OptionsColumn.ReadOnly = false;


            ProcessGetDistributeNew geDis = new ProcessGetDistributeNew();
            geDis.DistributionNew.selectcase = 19;
            geDis.Invoke();
            DataTable dtLv = geDis.ResultSet.Tables[0];


            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit grdLookup = new RepositoryItemGridLookUpEdit();
            grdLookup.DataSource = dtLv;

            #region SetGrdLookup

            grdLookup.View.OptionsView.ShowAutoFilterRow = true;

            grdLookup.View.Columns["EMP_UID"].Visible = false;
            grdLookup.View.Columns["FULLNAME"].Visible = true;
            grdLookup.View.Columns["EMP_ID"].Visible = false;

            #endregion

            grdLookup.ValueMember = "EMP_ID";
            grdLookup.DisplayMember = "FULLNAME";
            grdLookup.NullText = "";
            grdLookup.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(grdLookup_CloseUp);

            viewDisWorklist.Columns["ASSIGNED TO"].ColumnEdit = grdLookup;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox imCmb = new RepositoryItemImageComboBox();
            imCmb.SmallImages = this.imgWL;
            imCmb.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "R", 6),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "U", 7),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "S", 8)});

            imCmb.Buttons.Clear();

            viewDisWorklist.Columns["PRIORITY"].ColumnEdit = imCmb;
            viewDisWorklist.Columns["PRIORITY"].OptionsColumn.ReadOnly = true;



        }

        private void grdLookup_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                if (e.AcceptValue)
                {


                    DataRow dr = viewDisWorklist.GetDataRow(viewDisWorklist.FocusedRowHandle);
                    //if (dr["Result Status"].ToString() != "Finalize")
                    //{
                    string _id = msg.ShowAlert("UID4008", env.CurrentLanguageID);
                    if (_id == "3")
                    {
                        ProcessUpdateDistributionNew upDis = new ProcessUpdateDistributionNew();
                        upDis.DistributionNew.accessionno = dr["ACCESSION NO"].ToString();
                        upDis.DistributionNew.assignedTo = (int)e.Value;//dtGW.Rows[viewDisWorklist.FocusedRowHandle]["ASSIGNED TO"];
                        upDis.DistributionNew.PRIORITY = dr["Priority"].ToString();
                        upDis.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                        upDis.Invoke();
                    }
                    else if (_id == "2")
                    {
                        ProcessUpdateDistributionNew upDis = new ProcessUpdateDistributionNew();
                        upDis.DistributionNew.accessionno = dr["ACCESSION NO"].ToString();
                        upDis.DistributionNew.assignedTo = 0;//dtGW.Rows[viewDisWorklist.FocusedRowHandle]["ASSIGNED TO"];
                        upDis.DistributionNew.PRIORITY = dr["Priority"].ToString();
                        upDis.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                        upDis.Invoke();
                        e.Value = 0;
                    }
                    else
                    {
                        e.Value = dr["ASSIGNED TO"];
                    }
                    //}
                    //else
                    //{
                    //    e.Value = 0;
                    //}
                }
            }
            catch (Exception ex)
            { }
        }

        private void tsmR_Click(object sender, EventArgs e)
        {
            if (GridChoose == "Main")
            {
                //tsmR.Image = Envision.NET.Properties.Resources.QA;
                //DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                //dr["PRIORITY"] = "R";
                //advBandedGridView1.RefreshData();


                if (advBandedGridView1.FocusedRowHandle < 0) return;

                MyMessageBox msg = new MyMessageBox();
                string strMsg = msg.ShowAlert("UID2123", env.CurrentLanguageID);

                if (strMsg == "2")
                {
                    tsmR.Image = Envision.NET.Properties.Resources.QA;
                    DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                    dr["PRIORITY"] = "R";
                    advBandedGridView1.RefreshData();


                    ProcessUpdateRISOrderdtl upPri = new ProcessUpdateRISOrderdtl();
                    upPri.RISOrderdtl.ACCESSION_NO = dr["ACCESSION NO."].ToString();
                    upPri.RISOrderdtl.PRIORITY = dr["PRIORITY"].ToString();
                    upPri.RISOrderdtl.LAST_MODIFIED_BY = env.UserID;
                    upPri.UpdatePriority();
                }

            }
            else if (GridChoose == "HN")
            {
                tsmR.Image = Envision.NET.Properties.Resources.QA;
                DataRow dr = viewHNMain.GetDataRow(viewHNMain.FocusedRowHandle);
                dr["PRIORITY"] = "R";
                viewHNMain.RefreshData(); 
            }
            else if (GridChoose == "Work")
            {
                tsmR.Image = Envision.NET.Properties.Resources.QA;
                DataRow dr = viewDisWorklist.GetDataRow(viewDisWorklist.FocusedRowHandle);
                dr["PRIORITY"] = "R";
                viewDisWorklist.RefreshData(); 
            }
        }

        private void tsmU_Click(object sender, EventArgs e)
        {
            if (GridChoose == "Main")
            {
                if (advBandedGridView1.FocusedRowHandle < 0) return;

                MyMessageBox msg = new MyMessageBox();
                string strMsg = msg.ShowAlert("UID2123", env.CurrentLanguageID);

                if (strMsg == "2")
                {
                    tsmR.Image = Envision.NET.Properties.Resources.QA;
                    DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                    dr["PRIORITY"] = "U";
                    advBandedGridView1.RefreshData();


                    ProcessUpdateRISOrderdtl upPri = new ProcessUpdateRISOrderdtl();
                    upPri.RISOrderdtl.ACCESSION_NO = dr["ACCESSION NO."].ToString();
                    upPri.RISOrderdtl.PRIORITY = dr["PRIORITY"].ToString();
                    upPri.RISOrderdtl.LAST_MODIFIED_BY = env.UserID;
                    upPri.UpdatePriority();
                }
            }
            else if (GridChoose == "HN")
            {
                tsmU.Image = Envision.NET.Properties.Resources.QA;
                DataRow dr = viewHNMain.GetDataRow(viewHNMain.FocusedRowHandle);
                dr["PRIORITY"] = "U";
                viewHNMain.RefreshData();
            }
            else if (GridChoose == "Work")
            {
                tsmU.Image = Envision.NET.Properties.Resources.QA;
                DataRow dr = viewDisWorklist.GetDataRow(viewDisWorklist.FocusedRowHandle);
                dr["PRIORITY"] = "U";
                viewDisWorklist.RefreshData();
            }
        }

        private void tsmS_Click(object sender, EventArgs e)
        {
            if (GridChoose == "Main")
            {
                if (advBandedGridView1.FocusedRowHandle < 0) return;

                MyMessageBox msg = new MyMessageBox();
                string strMsg = msg.ShowAlert("UID2123", env.CurrentLanguageID);

                if (strMsg == "2")
                {
                    tsmR.Image = Envision.NET.Properties.Resources.QA;
                    DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                    dr["PRIORITY"] = "S";
                    advBandedGridView1.RefreshData();


                    ProcessUpdateRISOrderdtl upPri = new ProcessUpdateRISOrderdtl();
                    upPri.RISOrderdtl.ACCESSION_NO = dr["ACCESSION NO."].ToString();
                    upPri.RISOrderdtl.PRIORITY = dr["PRIORITY"].ToString();
                    upPri.RISOrderdtl.LAST_MODIFIED_BY = env.UserID;
                    upPri.UpdatePriority();
                }

            }
            else if (GridChoose == "HN")
            {
                tsmS.Image = Envision.NET.Properties.Resources.QA;
                DataRow dr = viewHNMain.GetDataRow(viewHNMain.FocusedRowHandle);
                dr["PRIORITY"] = "S";
                viewHNMain.RefreshData();
            }
            else if (GridChoose == "Work")
            {
                tsmS.Image = Envision.NET.Properties.Resources.QA;
                DataRow dr = viewDisWorklist.GetDataRow(viewDisWorklist.FocusedRowHandle);
                dr["PRIORITY"] = "S";
                viewDisWorklist.RefreshData();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (advBandedGridView1.FocusedRowHandle>=0 || viewDisWorklist.FocusedRowHandle>=0 || viewHNMain.FocusedRowHandle >=0)
            {
                string Priority = "";
                DataRow drView = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                DataRow drViewWL = viewDisWorklist.GetDataRow(viewDisWorklist.FocusedRowHandle);
                DataRow drViewHN = viewHNMain.GetDataRow(viewHNMain.FocusedRowHandle);
                if (drView != null)
                {
                    Priority = drView["PRIORITY"].ToString();
                }
                if (drViewHN != null)
                {
                    Priority = drViewHN["PRIORITY"].ToString();
                }
                if (drViewWL != null)
                {
                    Priority = drViewWL["PRIORITY"].ToString();
                }
                switch (Priority)
                {
                    case "R":
                        tsmS.Image = null;
                        tsmU.Image = null;
                        tsmR.Image = Envision.NET.Properties.Resources.QA;
                        break;
                    case "U":
                        tsmS.Image = null;
                        tsmU.Image = Envision.NET.Properties.Resources.QA;
                        tsmR.Image = null;
                        break;
                    case "S":
                        tsmS.Image = Envision.NET.Properties.Resources.QA;
                        tsmU.Image = null;
                        tsmR.Image = null;
                        break;
                    default:
                        break;
                }
            }
        }

        private void barDistributeCriteria_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage != pageDistributeCriteria)
            {
                xtraTabControl1.SelectedTabPage = pageDistributeCriteria;
                gridControl1.DataSource = null;
                Tab = "Dis";
                ClearDis();
                SetShowGrid("All");
                txtAssignDis.Focus();
                btnDistribution.Visible = true;
                btnClearDistribute.Visible = true;
                btnDelete.Visible = true;
            }
        }

        private void barSearchCriteria_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(xtraTabControl1.SelectedTabPage != pageSearchCriteria)
            {
                xtraTabControl1.SelectedTabPage = pageSearchCriteria;
                gridControl1.DataSource = null;
            Tab = "Search";
            ClearSearch();
            SetShowGrid("All");
            txtAssignSearch.Focus();
            btnDistribution.Visible = true;
            btnClearDistribute.Visible = true;
            btnDelete.Visible = true;
            }
        }

        private void barDistributionWorklist_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage != pageDistributionWorklist)
            {
                xtraTabControl1.SelectedTabPage = pageDistributionWorklist;
                gridControl1.DataSource = null;
                Tab = "Worklist";
                xtraTabControl2.SelectedTabPage = xtabGridDisList;
                deFromDate.DateTime = DateTime.Now;
                deToDate.DateTime = DateTime.Now;
                Populate(1);
                SetGridWorklist();
                btnDistribution.Visible = false;
                btnClearDistribute.Visible = false; ;
                btnDelete.Visible = false;
            }
        }

        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabcontrol.SelectedIndex;
            tabcontrol.TabPages.RemoveAt(index);
        }
    }
}