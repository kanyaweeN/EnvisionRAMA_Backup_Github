using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Main;
using System.Configuration;
using System.Data.SqlClient;
using Envision.NET.Forms.Comment;
using Envision.NET.Forms.EMR;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmCommentSystemWorklist : MasterForm
    {
        public frmCommentSystemWorklist()
        {
            InitializeComponent();
        }
        private void frmCommentSystemWorklist_Load(object sender, EventArgs e)
        {
            LoadWorkloadData();
            base.CloseWaitDialog();
        }

        private void LoadModality()
        {
        }

        private void LoadWorkloadData()
        {
            gcCommentList.DataSource = FillData("Prc_RIS_COMMENT_SelectOrderScheduleCase").Tables[0];
        }

        private DataSet FillData(string query)
        {
            DataSet s = new DataSet();
            using (SqlConnection c = new SqlConnection(ConfigurationSettings.AppSettings["connStr"]))
            {
                c.Open();
                using (SqlDataAdapter a = new SqlDataAdapter(query, c))
                {
                    a.SelectCommand.CommandType = CommandType.StoredProcedure;
                    a.Fill(s);
                }
            }
            return s;
        }
        private DataSet FillDataParam(string query, string Mode
            , int ORDER_ID, int EXAM_ID)
        {
            DataSet s = new DataSet();
            using (SqlConnection c = new SqlConnection(ConfigurationSettings.AppSettings["connStr"]))
            {
                c.Open();
                using (SqlDataAdapter a = new SqlDataAdapter(query, c))
                {
                    a.SelectCommand.CommandType = CommandType.StoredProcedure;
                    a.SelectCommand.Parameters.Add(new SqlParameter("@MODE",Mode));
                    a.SelectCommand.Parameters.Add(new SqlParameter("@ORDER_ID", ORDER_ID));
                    a.SelectCommand.Parameters.Add(new SqlParameter("@EXAM_ID", EXAM_ID));
                    a.Fill(s);
                }
            }
            return s;
        }

        private void orderSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmComment().ShowDialog();
        }

        private void orderSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmPopupOrderOrScheduleSummary().ShowDialog();
        }

        private void gvCommentList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvCommentList.FocusedRowHandle < 0) return;

            DataRow fRow = gvCommentList.GetDataRow(gvCommentList.FocusedRowHandle);
            
            DataSet ds = FillDataParam(
                    "Prc_RIS_COMMENT_SelectCommentList"
                    , fRow["ORDER_FROM"].ToString()
                    , Convert.ToInt32(fRow["ORDER_ID"])
                    , Convert.ToInt32(fRow["EXAM_ID"])
                    );

            txtCommentList.Text = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txtCommentList.Text += "\r\n";

                txtCommentList.Text += dr["COMMENT_SUBJECT"].ToString();
                txtCommentList.Text += "\r\n";
                txtCommentList.Text += "\r\n";

                txtCommentList.Text += dr["COMMENT_BODY"].ToString();
                txtCommentList.Text += "\r\n";
                txtCommentList.Text += "\r\n";
                txtCommentList.Text += "\r\n";

                txtCommentList.Text += dr["COMMENT_FROM"].ToString();
                txtCommentList.Text += "\r\n";
                txtCommentList.Text += Convert.ToDateTime(dr["COMMENT_DT"]).ToString("dd/MM/yyyy HH:mm");
                txtCommentList.Text += "\r\n";

                txtCommentList.Text += "--------------------------------------------------";
            }
        }
    }
}
