using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;
using Envision.WebService.EMROERWebService;
using Envision.BusinessLogic;

namespace Envision.NET.Forms.Technologist
{
    public partial class frmPatientData_ClinicalData : Form
    {
        public string HN;
        DataTable table_EMPOER;
        DataTable dtDemographic;

        DataView view_EMPOER;

        public frmPatientData_ClinicalData(string HN)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800,600);
            this.HN = HN;

            this.xtraTabControl1.SelectedTabPageIndex = 0;
            this.xtraTabControl2.SelectedTabPageIndex = 0;
        }

        private void frmPatientData_ClinicalData_Load(object sender, EventArgs e)
        {
            ProcessGetHISRegistration bg = new ProcessGetHISRegistration(HN);
            bg.Invoke();
            dtDemographic = bg.Result.Tables[0];

            if (dtDemographic.Rows.Count > 0)
            {
                txtHN.Text = dtDemographic.Rows[0]["HN"].ToString();

                string name = dtDemographic.Rows[0]["FNAME"].ToString() + " " + dtDemographic.Rows[0]["LNAME"].ToString();
                txtName.Text = name;
            }

            ReloadClinical();
        }

        private DataSet GetEMRbyMRN()
        {
            EMROERWebService ws = new EMROERWebService();
            DataSet dsEMR = ws.GetEMRbyMRN(HN);
            return dsEMR;
        }

        private void LoadClinicalData()
        {
            DataTable tb_Gen = new DataTable("Clnical Table");
            tb_Gen.Columns.AddRange(
                    new DataColumn[] { 
                        new DataColumn("hn")
                        ,new DataColumn("name")
                        ,new DataColumn("v_date")
                        ,new DataColumn("v_time")
                        ,new DataColumn("cc")
                        ,new DataColumn("pi")
                        ,new DataColumn("ph")
                        ,new DataColumn("smoke")
                        ,new DataColumn("alch")
                        ,new DataColumn("ud")
                        ,new DataColumn("dm")
                        ,new DataColumn("ht")
                        ,new DataColumn("dpm")
                        ,new DataColumn("cva")
                        ,new DataColumn("cad")
                        ,new DataColumn("bio")
                        ,new DataColumn("other")
                        ,new DataColumn("adr")
                        ,new DataColumn("tp")
                        ,new DataColumn("pr")
                        ,new DataColumn("rr")
                        ,new DataColumn("sbp")
                        ,new DataColumn("dbp")
                        ,new DataColumn("cr")
                        ,new DataColumn("ga")
                        ,new DataColumn("heent")
                        ,new DataColumn("cadio")
                        ,new DataColumn("rpr")
                        ,new DataColumn("gi")
                        ,new DataColumn("cns")
                        ,new DataColumn("ext")
                        ,new DataColumn("diags")
                        ,new DataColumn("plan")
                        ,new DataColumn("IS_ENVISION")
                    }
                );

            DataTable tb_fromWS = GetEMRbyMRN().Tables[0];
            if (tb_fromWS.Rows.Count > 0)
            {
                tb_fromWS.Columns.Add("IS_ENVISION");
                foreach (DataRow dr in tb_fromWS.Rows)
                {
                    dr["IS_ENVISION"] = "N";
                    tb_Gen.Rows.Add(dr.ItemArray);
                }
            }

            LookUpSelect getData = new LookUpSelect();
            DataSet ds = getData.SelectClinicalData(HN);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Add("IS_ENVISION");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dr["IS_ENVISION"] = "Y";
                    tb_Gen.Rows.Add(dr.ItemArray);
                }
            }

            table_EMPOER = tb_Gen.Copy();
            table_EMPOER.Columns.Add("v_datetime", typeof(DateTime));
            table_EMPOER.AcceptChanges();

            view_EMPOER = new DataView(table_EMPOER);
        }
        private void LoadClinicalFilter()
        {
            DataTable tb = table_EMPOER;
            foreach (DataRow dr in tb.Rows)
            {
                if (dr["IS_ENVISION"].ToString() == "Y")
                {
                    string[] date_str = dr["v_date"].ToString().Split(new string[] { "/" }, StringSplitOptions.None);
                    string day = date_str[1];
                    string month = date_str[0];
                    string year = date_str[2];
                    string new_date_str = string.Format("{0}/{1}/{2}", day, month, year);

                    dr["v_date"] = new_date_str;
                }
            }

            foreach (DataRow dr in tb.Rows)
            {
                string[] date_str = dr["v_date"].ToString().Split(new string[] { "/" }, StringSplitOptions.None);
                int year = Convert.ToInt32(date_str[2]);
                int month = Convert.ToInt32(date_str[1]);
                int day = Convert.ToInt32(date_str[0]);

                string[] time_str = dr["v_time"].ToString().Split(new string[] { ":" }, StringSplitOptions.None);
                int hour = Convert.ToInt32(time_str[0]);
                int min = Convert.ToInt32(time_str[1]);

                DateTime date_time = new DateTime(year, month, day, hour, min, 0);
                //dr["v_datetime"] = date_time.ToString("dd/MM/yyyy HH:mm");
                dr["v_datetime"] = date_time;
            }

            table_EMPOER.AcceptChanges();
            view_EMPOER = new DataView(table_EMPOER);
            view_EMPOER.Sort = "v_datetime desc";
        }
        private void LoadClinicalGrid()
        {
            //gridControl1.DataSource = table_EMPOER;
            gridControl1.DataSource = view_EMPOER;

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Visible = false;
                gridView1.Columns[i].OptionsColumn.ReadOnly = true;
            }

            //gridView1.Columns["v_date"].Caption = "ER Date";
            //gridView1.Columns["v_date"].ColVIndex = 1;

            //gridView1.Columns["v_time"].Caption = "ER Time";
            //gridView1.Columns["v_time"].ColVIndex = 2;

            gridView1.Columns["v_datetime"].Caption = "ER DateTime";
            gridView1.Columns["v_datetime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["v_datetime"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            gridView1.Columns["v_datetime"].ColVIndex = 1;

            gridView1.Columns["adr"].Caption = "Adr";//"Adr (แพ้ยา)";
            gridView1.Columns["adr"].ColVIndex = 2;

            gridView1.Columns["tp"].Caption = "Tp";//"Tp (อุณหภูมิ)";
            gridView1.Columns["tp"].ColVIndex = 3;

            gridView1.Columns["ht"].Caption = "Ht";//"Ht (ความดัน)";
            gridView1.Columns["ht"].ColVIndex = 4;

            gridView1.Columns["dm"].Caption = "Dm";//"Dm (เบาหวาน)";
            gridView1.Columns["dm"].ColVIndex = 5;

            gridView1.Columns["smoke"].Caption = "Smoke";//"Smoke (สูบบุหรี่)";
            gridView1.Columns["smoke"].ColVIndex = 6;

            gridView1.Columns["alch"].Caption = "Alcohal";//"Alcohal (ดื่มแอลกอฮอร์)";
            gridView1.Columns["alch"].ColVIndex = 7;

            gridView1.Columns["bio"].Caption = "Bio";//"Bio (เคยผ่าตัด)";
            gridView1.Columns["bio"].ColVIndex = 8;

            gridView1.Columns["sbp"].Caption = "Sbp";//"Sbp (ค่าชีพจรตัวบน)";
            gridView1.Columns["sbp"].ColVIndex = 9;

            gridView1.Columns["dbp"].Caption = "Dbp";//"Dbp (ค่าชีพจรตัวล่าง)";
            gridView1.Columns["dbp"].ColVIndex = 10;

            gridView1.Columns["ud"].Caption = "Ud";
            gridView1.Columns["ud"].ColVIndex = 11;

            gridView1.Columns["dpm"].Caption = "Dpm";
            gridView1.Columns["dpm"].ColVIndex = 12;

            gridView1.Columns["cva"].Caption = "Cva";
            gridView1.Columns["cva"].ColVIndex = 13;

            gridView1.Columns["cad"].Caption = "Cad";
            gridView1.Columns["cad"].ColVIndex = 14;

            gridView1.Columns["other"].Caption = "Other";
            gridView1.Columns["other"].ColVIndex = 15;

            gridView1.Columns["pr"].Caption = "Pr";
            gridView1.Columns["pr"].ColVIndex = 16;

            gridView1.Columns["rr"].Caption = "Rr";
            gridView1.Columns["rr"].ColVIndex = 17;

            gridView1.Columns["cr"].Caption = "Cr";
            gridView1.Columns["cr"].ColVIndex = 18;

            //gridView1.Columns["ga"].Caption = "Ga";
            //gridView1.Columns["ga"].ColVIndex = 19;

            //gridView1.Columns["heent"].Caption = "Heent";
            //gridView1.Columns["heent"].ColVIndex = 20;

            //gridView1.Columns["cadio"].Caption = "Cadio";
            //gridView1.Columns["cadio"].ColVIndex = 21;

            //gridView1.Columns["rpr"].Caption = "Rpr";
            //gridView1.Columns["rpr"].ColVIndex = 22;



            //gridView1.Columns["gi"].Caption = "Gi";
            //gridView1.Columns["gi"].ColVIndex = 26;

            //gridView1.Columns["cns"].Caption = "Cns";
            //gridView1.Columns["cns"].ColVIndex = 27;

            //gridView1.Columns["ext"].Caption = "Ext";
            //gridView1.Columns["ext"].ColVIndex = 28;



            //gridView1.Columns["diags"].Caption = "Diags (ICD 10, ICD9 CM)";
            //gridView1.Columns["diags"].ColVIndex = 29;

            //gridView1.Columns["plan"].Caption = "Plan (แผนการรักษา)";
            //gridView1.Columns["plan"].ColVIndex = 30;



            //gridView1.Columns["hn"].Caption = "HN";
            //gridView1.Columns["hn"].ColVIndex = 3;

            //gridView1.Columns["name"].Caption = "Name";
            //gridView1.Columns["name"].ColVIndex = 4;


            gridView1.BestFitColumns();
        }
        private void ReloadClinical()
        {
            LoadClinicalData();
            LoadClinicalFilter();
            LoadClinicalGrid();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;

            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            txtCC.Text = row["cc"].ToString();
            txtPI.Text = row["pi"].ToString();
            txtPH.Text = row["ph"].ToString();

            txtGi.Text = row["gi"].ToString();
            txtCns.Text = row["cns"].ToString();
            txtExt.Text = row["ext"].ToString();

            txtDiags.Text = row["diags"].ToString();
            txtPlan.Text = row["plan"].ToString();

            txtStudyDate.Text = row["v_datetime"].ToString();

            txtGa.Text = row["ga"].ToString();
            txtHeent.Text = row["heent"].ToString();
            txtCadio.Text = row["cadio"].ToString();
            txtRpr.Text = row["rpr"].ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}