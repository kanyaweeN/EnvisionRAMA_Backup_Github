using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using System.Drawing.Printing;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Envision.NET.Forms.Dialog
{
    public partial class LookupAlertComment : Envision.NET.Forms.Main.MasterForm
    {
        private static GBLEnvVariable env;
        public LookupAlertComment()
        {
            InitializeComponent();
        }

        private void LookupAlertComment_Load(object sender, EventArgs e)
        {
            DataTable dtAlert = getCommentAlertMessage();
            if (dtAlert.Rows.Count>0)
            {
                grdAccession.DataSource = dtAlert;
                setLookUpAlertComment();
            }
            else
            {
                this.Close();
            }
            
        }

        private void setLookUpAlertComment()
        {
            for (int i = 0; i < viewAccession.Columns.Count; i++)
            {
                viewAccession.Columns[i].Visible = false;
            }

            viewAccession.Columns["Group"].GroupIndex = 1;
            viewAccession.OptionsView.ColumnAutoWidth = false;

            viewAccession.Columns["ACCESSION_NO"].Caption = "Accession No";
            viewAccession.Columns["ACCESSION_NO"].Visible = false;
            viewAccession.Columns["ACCESSION_NO"].OptionsColumn.ReadOnly = true;
            viewAccession.Columns["ACCESSION_NO"].OptionsColumn.AllowEdit = false;
            viewAccession.Columns["ACCESSION_NO"].OptionsColumn.AllowFocus = true;
            viewAccession.Columns["ACCESSION_NO"].Width = 120;
            viewAccession.Columns["ACCESSION_NO"].VisibleIndex = 2;


            viewAccession.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewAccession.Columns["EXAM_NAME"].Visible = true;
            viewAccession.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            viewAccession.Columns["EXAM_NAME"].OptionsColumn.AllowEdit = false;
            viewAccession.Columns["EXAM_NAME"].OptionsColumn.AllowFocus = true;
            viewAccession.Columns["EXAM_NAME"].Width = 135;
            viewAccession.Columns["EXAM_NAME"].VisibleIndex = 3;

            viewAccession.Columns["ORDER_DT"].Caption = "Order Date";
            viewAccession.Columns["ORDER_DT"].Visible = true;
            //viewAccession.Columns["ORDER_DT"].UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            viewAccession.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            viewAccession.Columns["ORDER_DT"].DisplayFormat.FormatString = "dd/MM/yyyy";
            viewAccession.Columns["ORDER_DT"].OptionsColumn.ReadOnly = true;
            viewAccession.Columns["ORDER_DT"].OptionsColumn.AllowEdit = false;
            viewAccession.Columns["ORDER_DT"].OptionsColumn.AllowFocus = true;
            viewAccession.Columns["ORDER_DT"].Width = 65;
            viewAccession.Columns["ORDER_DT"].VisibleIndex = 4;


            viewAccession.Columns["HN"].Caption = "HN";
            viewAccession.Columns["HN"].Visible = true;
            viewAccession.Columns["HN"].OptionsColumn.ReadOnly = true;
            viewAccession.Columns["HN"].OptionsColumn.AllowEdit = false;
            viewAccession.Columns["HN"].OptionsColumn.AllowFocus = true;
            viewAccession.Columns["HN"].Width = 50;
            viewAccession.Columns["HN"].VisibleIndex = 1;
            //lookUpSelect.Properties.DataSource = getCommentAlertMessage();
            //lookUpSelect.Properties.DisplayMember = "ACCESSION_NO";
            //lookUpSelect.Properties.ValueMember = "COMMENTALERT_ID";


            //lookUpSelect.Properties.Columns.Add(new LookUpColumnInfo("COMMENTALERT_ID", "ID"));
            //lookUpSelect.Properties.Columns.Add(new LookUpColumnInfo("ACCESSION_NO", "Accession No", 80));
            //lookUpSelect.Properties.Columns["COMMENTALERT_ID"].Visible = false;

            //lookUpSelect.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        private DataTable getCommentAlertMessage()
        {
            env = new GBLEnvVariable();
            ProcessGetRISCommentAlert procCommentAlert = new ProcessGetRISCommentAlert();
            procCommentAlert.RIS_COMMENTSYSTEMALERT.READER_ID = env.UserID;
            DataSet dsAlertComment = procCommentAlert.GetAlertMessage();
            DataTable dttAlertComment = new DataTable();
            for (int i = 0; i < dsAlertComment.Tables.Count; i++)
                dttAlertComment.Merge(dsAlertComment.Tables[i].Copy());
            dttAlertComment.Columns.Add("Group");
            foreach (DataRow dr in dttAlertComment.Rows)
            {
                if (!string.IsNullOrEmpty(dr["ACCESSION_NO"].ToString()))
                {
                    dr["Group"] = "1";//Accession Group
                }
                else if (Convert.ToInt32(dr["XRAYREQ_ID"]) > 0)
                {
                    dr["Group"] = "3";//Xray request Group
                }
                else
                {
                    dr["Group"] = "2";//Schedule Group
                }
            }
            return dttAlertComment;
        }


        private void grdAccession_DoubleClick(object sender, EventArgs e)
        {
            if (viewAccession.FocusedRowHandle >= 0)
            {

                DataRow dr = viewAccession.GetDataRow(viewAccession.FocusedRowHandle);
                if (!string.IsNullOrEmpty(dr["ACCESSION_NO"].ToString()))
                {
                    this.Close();

                    frmMessageConversation frm = new frmMessageConversation(dr["ACCESSION_NO"].ToString());
                    frm.ShowDialog();
                }
                else if (Convert.ToInt32(dr["SCHEDULE_ID"].ToString())>0)
                {
                    this.Close();

                    frmMessageConversation frm = new frmMessageConversation(Convert.ToInt32(dr["SCHEDULE_ID"].ToString()));
                    frm.ShowDialog();
                }
                else if (Convert.ToInt32(dr["XRAYREQ_ID"].ToString()) > 0)
                {
                    this.Close();

                    frmMessageConversation frm = new frmMessageConversation(Convert.ToInt32(dr["XRAYREQ_ID"].ToString()),true);
                    frm.ShowDialog();
                }
                LookupAlertComment frmLook = new LookupAlertComment();
                frmLook.ShowDialog();
            }
        }

        private void tmComment_Tick(object sender, EventArgs e)
        {
            if (getCommentAlertMessage() != null)
            {
                grdAccession.DataSource = getCommentAlertMessage();
            }
        }

        private void viewAccession_EndGrouping(object sender, EventArgs e)
        {
            (sender as DevExpress.XtraGrid.Views.Grid.GridView).ExpandAllGroups();
        }

        private void viewAccession_GroupRowCollapsing(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            e.Allow = false;
        }

        private void viewAccession_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            (e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo).ButtonBounds = Rectangle.Empty;

            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
           
            if (info.Column.FieldName == "Group")
            {
                if (info.EditValue == "1")
                {
                    info.GroupText = "Order";
                }

                if (info.EditValue == "2")
                {
                    info.GroupText = "Schedule";
                }

                if (info.EditValue == "3")
                {
                    info.GroupText = "Request Online";
                }
                info.Appearance.ForeColor = Color.Blue;
            }
        }

        private void viewAccession_GroupLevelStyle(object sender, DevExpress.XtraGrid.Views.Grid.GroupLevelStyleEventArgs e)
        {
            e.LevelAppearance.BackColor = Color.Transparent;
        }

    }
}