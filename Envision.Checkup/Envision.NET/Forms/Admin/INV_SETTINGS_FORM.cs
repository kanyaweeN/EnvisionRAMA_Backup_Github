using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Forms.GBLMessage;
using RIS.BusinessLogic;
using RIS.Common;
using System.Data.SqlClient;

namespace RIS.Forms.Admin
{
    public partial class INV_SETTINGS_FORM : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        MyMessageBox mymsb = new MyMessageBox();

        public INV_SETTINGS_FORM(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            CloseControl = closecontrol;

            //using (ProcessGetInvSettings select = new ProcessGetInvSettings())
            //{
            //    select.Invoke();
            //    gridControl1.DataSource = select.ResultTable.Copy();
            //}

            DataTable table = Select_Table_INV_SETTINGS();
            if (table.Rows.Count > 0)
            {
                AddNewText(table.Rows[0]);
            }

            EnableProp_Setting(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text.Equals("Add"))
            {
                btnAdd.Visible = true;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                btnAdd.Text = "Save";

                EnableProp_Setting(true);
            }
            else
            {
                btnAdd_Process();
                btnCancel_Process();
                btnAdd.Text = "Add";
            }
        }

        private void btnAdd_Process()
        {
            if (!Control_Cheking()) return;

            using(ProcessAddInvSettings insert = new ProcessAddInvSettings())
            {
                INV_SETTINGS common = new INV_SETTINGS();

                //common.SETTINGS_ID = int.Parse(txtID.Text);
                common.SETTINGS_UID = txtUID.Text;

                common.PO_AUTH_LEVEL = Convert.ToInt32(txtAuthLevel.Value);
                common.AUTO_PR_FREQ_DAYS = Convert.ToInt32(txtFreqDay.Value);
                common.GLOBAL_SELLING_MARKUP = Convert.ToDouble(txtSellMarkup.Value);

                common.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;

                common.INV_METHOD = txtMethod.SelectedIndex.ToString();
                common.FREE_PROD_PRICING = txtFreePrice.SelectedIndex.ToString();
                common.DISCOUNT_EFFECT = txtDiscEffect.SelectedIndex.ToString();

                common.GENERATE_AUTO_PR = chkGenAutoPr.Checked ? "Y" : "N";
                common.ALLOW_NEW_IF_PENDING = chkAllowNew.Checked ? "Y" : "N";
                common.OVERRIDE_IF_EMERGENCY = chkOverride.Checked ? "Y" : "N";
                common.SELL_REUSED_WO_RENTRY = chkSellReused.Checked ? "Y" : "N";
                common.REORDER_CALC_METHOD = chkReOrderCalc.Checked ? "Y" : "N";
                common.CENTRAL_STOCK_UNIT = chkCentralStockUnit.Checked ? "Y" : "N";
                common.DEPT_STOCK_UNIT = chkDeptStockUnit.Checked ? "Y" : "N";

                insert.INV_SETTINGS = common;
                insert.Invoke();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text.Equals("Edit"))
            {
                btnAdd.Visible = false;
                btnEdit.Visible = true;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                btnEdit.Text = "Save";

                EnableProp_Setting(true);
            }
            else
            {
                if (!Control_Cheking()) return;

                btnEdit_Process();
                btnCancel_Process();
                btnEdit.Text = "Edit";
            }
        }

        private void btnEdit_Process()
        {
            if (!Control_Cheking()) return;

            using (ProcessUpdateInvSettings update = new ProcessUpdateInvSettings())
            {
                INV_SETTINGS common = new INV_SETTINGS();

                try
                {
                    common.SETTINGS_ID = int.Parse(txtID.Text);
                }
                catch
                {
                    common.SETTINGS_ID = 0;
                }
                common.SETTINGS_UID = txtUID.Text;

                common.PO_AUTH_LEVEL = Convert.ToInt32(txtAuthLevel.Value);
                common.AUTO_PR_FREQ_DAYS = Convert.ToInt32(txtFreqDay.Value);
                common.GLOBAL_SELLING_MARKUP = Convert.ToDouble(txtSellMarkup.Value);

                common.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;

                common.INV_METHOD = txtMethod.SelectedIndex.ToString();
                common.FREE_PROD_PRICING = txtFreePrice.SelectedIndex.ToString();
                common.DISCOUNT_EFFECT = txtDiscEffect.SelectedIndex.ToString();

                common.GENERATE_AUTO_PR = chkGenAutoPr.Checked ? "Y" : "N";
                common.ALLOW_NEW_IF_PENDING = chkAllowNew.Checked ? "Y" : "N";
                common.OVERRIDE_IF_EMERGENCY = chkOverride.Checked ? "Y" : "N";
                common.SELL_REUSED_WO_RENTRY = chkSellReused.Checked ? "Y" : "N";
                common.REORDER_CALC_METHOD = chkReOrderCalc.Checked ? "Y" : "N";
                common.CENTRAL_STOCK_UNIT = chkCentralStockUnit.Checked ? "Y" : "N";
                common.DEPT_STOCK_UNIT = chkDeptStockUnit.Checked ? "Y" : "N";

                common.CREATED_BY = new Common.Common.GBLEnvVariable().UserID;

                update.INV_SETTINGS = common;
                update.Invoke();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim().Equals("")) return;

            if (mymsb.ShowAlert("UID2003", 1) == "2")
            {
                INV_SETTINGS common = new INV_SETTINGS();
                common.SETTINGS_ID = int.Parse(txtID.Text);

                ProcessDeleteInvSettings delete = new ProcessDeleteInvSettings();
                delete.INV_SETTINGS = common;
                delete.Invoke();

                btnCancel_Process();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Process();
        }

        private void btnCancel_Process()
        {
            btnAdd.Visible = false;
            btnEdit.Visible = true;
            btnDelete.Visible = false;
            btnCancel.Visible = false;

            btnAdd.Text = "Add";
            btnEdit.Text = "Edit";

            //using (ProcessGetInvSettings select = new ProcessGetInvSettings())
            //{
            //    select.Invoke();
            //    gridControl1.DataSource = select.ResultTable.Copy();
            //}

            EnableProp_Setting(false);

            ClearText();

            DataTable table = Select_Table_INV_SETTINGS();
            if (table.Rows.Count > 0)
            {
                AddNewText(table.Rows[0]);
            }
                //gridControl1.DataSource = select.ResultTable.Copy();

            //gridView1_FocusedRowChanged(gridView1.FocusedRowHandle);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }

        private DataTable Select_Table_INV_SETTINGS()
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
            DataTable datatable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand();
                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandText = @"  SELECT     INV_SETTINGS.*, GBL_ENV.ORG_NAME, GBL_ENV.ORG_UID, GBL_ENV.ORG_ALIAS
                                                        FROM         INV_SETTINGS LEFT OUTER JOIN
                                                        GBL_ENV ON INV_SETTINGS.ORG_ID = GBL_ENV.ORG_ID";
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(datatable);

                return datatable;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //if (txtSearch.Text.Trim().Equals(""))
            //{
            //    using (ProcessGetInvSettings select = new ProcessGetInvSettings())
            //    {
            //        select.Invoke();
            //        gridControl1.DataSource = select.ResultTable.Copy();
            //    }
            //}
            //else
            //{
            //    using (ProcessGetInvSettings select = new ProcessGetInvSettings())
            //    {
            //        select.Invoke();
            //        gridControl1.DataSource = select.ResultTable.Copy();
            //    }

            //    DataTable table = ((DataTable)gridControl1.DataSource).Copy();

            //    string expression = " SETTINGS_ID = " + txtSearch.Text + " OR " +
            //                        " SETTINGS_UID like '%" + txtSearch.Text + "%' OR " +
            //                        " INV_METHOD like '%" + txtSearch.Text + "%' OR " +
            //                        " FREE_PROD_PRICING like '%" + txtSearch.Text + "%' OR " +
            //                        " DISCOUNT_EFFECT like '%" + txtSearch.Text + "%' OR " +
            //                        " PO_AUTH_LEVEL = " + txtSearch.Text + " OR " +
            //                        " GENERATE_AUTO_PR like '%" + txtSearch.Text + "%' OR " +
            //                        " AUTO_PR_FREQ_DAYS = " + txtSearch.Text + " OR " +
            //                        " GLOBAL_SELLING_MARKUP = " + txtSearch.Text + " OR " +
            //                        " ALLOW_NEW_IF_PENDING like '%" + txtSearch.Text + "%' OR " +
            //                        " OVERRIDE_IF_EMERGENCY like '%" + txtSearch.Text + "%' OR " +
            //                        " SELL_REUSED_WO_RENTRY like '%" + txtSearch.Text + "%' OR " +
            //                        " REORDER_CALC_METHOD like '%" + txtSearch.Text + "%' OR " +
            //                        " CENTRAL_STOCK_UNIT like '%" + txtSearch.Text + "%' OR " +
            //                        " DEPT_STOCK_UNIT like '%" + txtSearch.Text + "%' OR " +
            //                        " ORG_ID = " + txtSearch.Text + " OR " +
            //                        " CREATED_ON like '" + txtSearch.Text + "'  ";

            //    //DataRow[] rows = table.Select(expression);
            //    //List<DataRow> rowlist = new List<DataRow>();
            //    //rowlist.AddRange(rows);
            //    //DataTable newtable = table.Clone();

            //    //foreach (DataRow row in rowlist.ToArray())
            //    //{
            //    //    newtable.Rows.Add(row);
            //    //}

            //    //gridControl1.DataSource = newtable.Copy();             
            //}
        }

        private void EnableProp_Setting(bool enable)
        {
            //txtID.Enabled = enable;
            txtUID.Enabled = enable;

            txtAuthLevel.Enabled = enable;
            txtFreqDay.Enabled = enable;
            txtSellMarkup.Enabled = enable;

            //btnOrgId.Enabled = enable;

            txtMethod.Enabled = enable;
            txtFreePrice.Enabled = enable;
            txtDiscEffect.Enabled = enable;

            chkGenAutoPr.Enabled = enable;

            chkAllowNew.Enabled = enable;

            chkOverride.Enabled = enable;

            chkSellReused.Enabled = enable;

            chkReOrderCalc.Enabled = enable;

            chkCentralStockUnit.Enabled = enable;

            chkDeptStockUnit.Enabled = enable;

        }

        private void btnOrgId_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnOrgId_Clicks);

            string qry = @"
                            select
                                ORG_ID,ORG_UID,ORG_NAME,ORG_ALIAS
                            from
                                GBL_ENV
                            where 
                                ORG_ID like '%%' OR ORG_UID like '%%' OR
                                ORG_NAME like '%%' OR ORG_ALIAS like '%%'
                            order by ORG_ID asc;
                        ";

            string fields = "ID, Code, Name, Alias";
            string con = "";
            lv.getData(qry, fields, con, "Global Environtment");
            lv.Show();
        }

        private void btnOrgId_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            //string[] retValue = e.NewValue.Split(new Char[] { '^' });

            //txtOrdID1.Tag = retValue[0];
            //txtOrdID1.Text = retValue[1];
            //txtOrdID2.Text = retValue[2];
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //DataTable table = (DataTable)gridControl1.DataSource;
            //DataRow row = table.Rows[e.FocusedRowHandle];

            //AddNewText(row);
        }

        private void gridView1_FocusedRowChanged(int focusRowHandle)
        {
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs param
                = new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(focusRowHandle, focusRowHandle);

            gridView1_FocusedRowChanged(new object(),param);
        }

        private void AddNewText(DataRow row)
        {
            try
            {
                txtID.Text = row["SETTINGS_ID"].ToString();
                txtUID.Text = row["SETTINGS_UID"].ToString();

                txtAuthLevel.Value = Convert.ToDecimal(row["PO_AUTH_LEVEL"]);
                txtFreqDay.Value = Convert.ToDecimal(row["AUTO_PR_FREQ_DAYS"]);
                txtSellMarkup.Value = Convert.ToDecimal(row["GLOBAL_SELLING_MARKUP"]);

                //txtOrdID1.Tag = row["ORG_ID"].ToString();
                //txtOrdID1.Text = row["ORG_UID"].ToString();
                //txtOrdID2.Text = row["ORG_NAME"].ToString();

                try
                {
                    txtMethod.SelectedIndex = Convert.ToInt32(row["INV_METHOD"]);
                }
                catch { }
                try
                {
                    txtFreePrice.SelectedIndex = Convert.ToInt32(row["FREE_PROD_PRICING"]);
                }
                catch { }
                try
                {
                    txtDiscEffect.SelectedIndex = Convert.ToInt32(row["DISCOUNT_EFFECT"]);
                }
                catch { }

                chkGenAutoPr.Checked = row["GENERATE_AUTO_PR"].Equals("Y") ? true : false;
                chkAllowNew.Checked = row["ALLOW_NEW_IF_PENDING"].Equals("Y") ? true : false;
                chkOverride.Checked = row["OVERRIDE_IF_EMERGENCY"].Equals("Y") ? true : false;
                chkSellReused.Checked = row["SELL_REUSED_WO_RENTRY"].Equals("Y") ? true : false;
                chkReOrderCalc.Checked = row["REORDER_CALC_METHOD"].Equals("Y") ? true : false;
                chkCentralStockUnit.Checked = row["CENTRAL_STOCK_UNIT"].Equals("Y") ? true : false;
                chkDeptStockUnit.Checked = row["DEPT_STOCK_UNIT"].Equals("Y") ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ClearText()
        {
            txtID.Text = "";
            txtUID.Text = "";

            txtAuthLevel.Text = "";
            txtFreqDay.Text = "";
            txtSellMarkup.Text = "";

            //txtOrdID1.Tag = "";
            //txtOrdID1.Text = "";
            //txtOrdID2.Text = "";

            txtMethod.Text = "";
            txtFreePrice.Text = "";
            txtDiscEffect.Text = "";

            chkGenAutoPr.Checked = false;

            chkAllowNew.Checked = false;

            chkOverride.Checked = false;

            chkSellReused.Checked = false;

            chkReOrderCalc.Checked = false;

            chkCentralStockUnit.Checked = false;

            chkDeptStockUnit.Checked = false;
        }

        private bool Control_Cheking()
        {
            if (//txtID.Text.Trim() == "" ||
                txtUID.Text.Trim() == "" ||
                txtMethod.SelectedIndex == -1||
                txtFreePrice.SelectedIndex == -1||
                txtDiscEffect.SelectedIndex == -1)
            {
                MessageBox.Show("Infor. incomplete");
                return false;
            }

            return true;
        }

    }
}