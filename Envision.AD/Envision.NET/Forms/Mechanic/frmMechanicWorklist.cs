using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Main;
using DevExpress.XtraGrid;

namespace Envision.NET.Forms.Mechanic
{
    public partial class frmMechanicWorklist : MasterForm
    {
        DataTable dtMtnSchedule;
        DataView dvMtnSchedule;
        DataRow drMtnSchedule;
        List<int> selectModId = new List<int>();

        public frmMechanicWorklist()//(UUL.ControlFrame.Controls.TabControl tabControl)
        {
            InitializeComponent();

            txtFromDate.DateTime = DateTime.Now;
            txtToDate.DateTime = DateTime.Now;

            //chkShowCanceled.CheckState = CheckState.Checked;
            //chkShowPostponed.CheckState = CheckState.Checked;
            //chkWorkInProgress.CheckState = CheckState.Checked;
        }
        private void frmMechanicWorklist_Load(object sender, EventArgs e)
        {
            #region initial modality combobox
            ProcessGetRISModality bg = new ProcessGetRISModality(true);
            bg.Invoke();
            DataTable dt = bg.Result.Tables[0];

            selectModId.Clear();
            selectModId.Add(0);

            chkListModality.Properties.Items.Clear();
            chkListModality.Properties.Items.Add("ALL:MODALITY");

            foreach (DataRow dr in dt.Rows)
            {
                selectModId.Add((int)dr["MODALITY_ID"]);
                chkListModality.Properties.Items.Add(dr["MODALITY_NAME"].ToString() + "(" + dr["MODALITY_UID"].ToString() + ")");
            }

            chkListModality.Properties.Items[0].CheckState = CheckState.Checked;
            chkListModality.Text = "ALL:MODALITY";
            #endregion
            
            ReloadMtnSchedule();

            base.CloseWaitDialog();
        }

        private void LoadDataMtnSchedule()
        {
            ProcessGetRISModalitymaintenanceschedule getData = new ProcessGetRISModalitymaintenanceschedule(0);
            DateTime date = txtFromDate.DateTime;
            getData.RIS_MODALITYMAINTENANCESCHEDULE.START_TIME = new DateTime(date.Year,date.Month,date.Day,0,0,0);
            date = txtToDate.DateTime;
            getData.RIS_MODALITYMAINTENANCESCHEDULE.END_TIME = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59); ;
            getData.Invoke();
            DataTable table = getData.Result.Tables[0];

            dtMtnSchedule = table;
            dvMtnSchedule = new DataView(table);
        }
        private void LoadFilterMtnSchedule()
        {

            #region less than one selected
            bool unSelAll = true;

            int kk = 0;
            while (kk < chkListModality.Properties.Items.Count)
            {
                if (chkListModality.Properties.Items[kk].CheckState == CheckState.Checked)
                {
                    unSelAll = false;
                    break;
                }
                ++kk;
            }

            if (unSelAll)
            {
                chkListModality.Properties.Items[0].CheckState = CheckState.Checked;
                chkListModality.Text = "ALL:MODALITY";
            }
            #endregion

            DataView dv = new DataView(dtMtnSchedule);
            dv.RowFilter = "";

            if (chkListModality.Properties.Items[0].CheckState == CheckState.Checked)
                dv.RowFilter = "";
            else
            {
                List<string> id = new List<string>();
                int k = 1;
                while (k < chkListModality.Properties.Items.Count)
                {
                    if (chkListModality.Properties.Items[k].CheckState == CheckState.Checked)
                    {
                        id.Add(selectModId[k].ToString());
                    }
                    ++k;
                }

                if (id.Count > 0)
                {
                    string qry = "";
                    foreach (string str in id.ToArray())
                        qry += " MODALITY_ID=" + str + " or ";
                    qry = qry.Substring(0, qry.Length - 3);

                    dv.RowFilter = "(" + qry + ")";
                }
            }

            #region Set Status RowFilter

            string rowFilStatus = "";

            //if (dv.RowFilter == "")
            //    rowFilStatus += "(MTN_SCH_STATUS = 'N')";
            //else
            //    rowFilStatus += " AND (MTN_SCH_STATUS = 'N')";

            rowFilStatus = "(MTN_SCH_STATUS = 'N')";

            #region Show Complete Status
            if (chkShowComplete.CheckState == CheckState.Checked)
            {
                if (rowFilStatus == "")
                    rowFilStatus += "(MTN_SCH_STATUS = 'C')";
                else
                    rowFilStatus += " OR (MTN_SCH_STATUS = 'C')";
            }
            #endregion

            #region Show Cancel Status
            if (chkShowCanceled.CheckState == CheckState.Checked)
            {
                if (rowFilStatus == "")
                    rowFilStatus += "(MTN_SCH_STATUS = 'X')";
                else
                    rowFilStatus += " OR (MTN_SCH_STATUS = 'X')";
            }
            #endregion

            #region Show Work in Progress Status
            if (chkWorkInProgress.CheckState == CheckState.Checked)
            {
                if (rowFilStatus == "")
                    rowFilStatus += "(MTN_SCH_STATUS = 'W')";
                else
                    rowFilStatus += " OR (MTN_SCH_STATUS = 'W')";
            }
            #endregion

            #region Show Postponed Status
            if (chkShowPostponed.CheckState == CheckState.Checked)
            {
                if (rowFilStatus == "")
                    rowFilStatus += "(MTN_SCH_STATUS = 'P')";
                else
                    rowFilStatus += " OR (MTN_SCH_STATUS = 'P')";
            }
            #endregion

            if (dv.RowFilter == "")
                dv.RowFilter += "(" + rowFilStatus + ")";
            else
                dv.RowFilter += "AND(" + rowFilStatus + ")";

            #endregion

            dvMtnSchedule = dv;
        }
        private void LoadGridMtnSchedule()
        {
            gridControl1.DataSource = dvMtnSchedule;
            int k = 0;
            while (k < gridView1.Columns.Count)
            {
                gridView1.Columns[k].Visible = false;
                gridView1.Columns[k].OptionsColumn.AllowEdit = false;
                ++k;
            }

            gridView1.Columns["MTN_DT"].ColVIndex = 0;
            gridView1.Columns["MTN_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["MTN_DT"].DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            gridView1.Columns["MTN_DT"].Caption = "Maintenance Date";

            gridView1.Columns["MODALITY_NAME"].ColVIndex = 1;
            gridView1.Columns["MODALITY_NAME"].Caption = "Modality";

            gridView1.Columns["MTN_TYPE_UID"].ColVIndex = 2;
            gridView1.Columns["MTN_TYPE_UID"].Caption = "Maintenance Type";

            gridView1.Columns["START_TIME"].ColVIndex = 3;
            gridView1.Columns["START_TIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["START_TIME"].DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            gridView1.Columns["START_TIME"].Caption = "Start Time";

            gridView1.Columns["END_TIME"].ColVIndex = 4;
            gridView1.Columns["END_TIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["END_TIME"].DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            gridView1.Columns["END_TIME"].Caption = "End Time";

            gridView1.Columns["MTN_SCH_STATUS_TEXT"].ColVIndex = 5;
            gridView1.Columns["MTN_SCH_STATUS_TEXT"].Caption = "Status";

            gridView1.Columns["MTN_COST"].ColVIndex = 6;
            gridView1.Columns["MTN_COST"].Caption = "Maintenance Cost";

            gridView1.Columns["RESPONSIBLE_PERSON_NAME"].ColVIndex = 7;
            gridView1.Columns["RESPONSIBLE_PERSON_NAME"].Caption = "Responsible Person";

            // 'N' 'New'
            // 'W' 'Work In Progress'
            // 'C' 'Completed'
            // 'P' 'Postponed'
            // 'X' 'Canceled'

            gridView1.FormatConditions.Clear();

            StyleFormatCondition cn;

            cn = new StyleFormatCondition
                (FormatConditionEnum.Equal, gridView1.Columns["MTN_SCH_STATUS"], null, "N");
            cn.ApplyToRow = true;
            cn.Appearance.BackColor = Color.Pink;
            gridView1.FormatConditions.Add(cn);

            cn = new StyleFormatCondition
                (FormatConditionEnum.Equal, gridView1.Columns["MTN_SCH_STATUS"], null, "W");
            cn.ApplyToRow = true;
            cn.Appearance.BackColor = Color.OrangeRed;
            gridView1.FormatConditions.Add(cn);

            cn = new StyleFormatCondition
                (FormatConditionEnum.Equal, gridView1.Columns["MTN_SCH_STATUS"], null, "C");
            cn.ApplyToRow = true;
            cn.Appearance.BackColor = Color.OrangeRed;
            gridView1.FormatConditions.Add(cn);

            cn = new StyleFormatCondition
                (FormatConditionEnum.Equal, gridView1.Columns["MTN_SCH_STATUS"], null, "P");
            cn.ApplyToRow = true;
            cn.Appearance.BackColor = Color.LightGray;
            gridView1.FormatConditions.Add(cn);

            cn = new StyleFormatCondition
                (FormatConditionEnum.Equal, gridView1.Columns["MTN_SCH_STATUS"], null, "X");
            cn.ApplyToRow = true;
            cn.Appearance.BackColor = Color.LightGray;
            gridView1.FormatConditions.Add(cn);

            if (gridView1.RowCount <= 99)
                gridView1.BestFitColumns();
        }
        private void ReloadMtnSchedule()
        {
            LoadDataMtnSchedule();
            LoadFilterMtnSchedule();
            LoadGridMtnSchedule();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            ReloadMtnSchedule();
        }
        private void chkShowStatus_CheckedChanged(object sender, EventArgs e)
        {
            ReloadMtnSchedule();
        }
        private void chkListModality_CloseUp(object sender, CloseUpEventArgs e)
        {
            ReloadMtnSchedule();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
                LoadMTNFixing_Form();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                int foRow = gridView1.FocusedRowHandle;
                drMtnSchedule = gridView1.GetDataRow(foRow);
            }
        }
        private void LoadMTNFixing_Form()
        {
            frmMechanicWorklist_FixingForm form = new frmMechanicWorklist_FixingForm(drMtnSchedule);
            DialogResult diResult = form.ShowDialog();
            if (diResult == DialogResult.OK)
                ReloadMtnSchedule();
        }
    }
}
