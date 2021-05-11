using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Main;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic;
using Envision.Common;
using DevExpress.XtraEditors.Controls;

namespace Envision.NET.Forms.Admin
{
    public partial class frmPeerReviewDistributional : MasterForm
    {
        DataTable GroupData = new DataTable();

        public frmPeerReviewDistributional()
        {
            InitializeComponent();
        }
        private void frmPeerReviewDistributional_Load(object sender, EventArgs e)
        {
            SetupFilter();
            getRadData();
            getAlgorithmData();

            DateTime dtStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime dtEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            getGroupFromPrStudies(dtStart, dtEnd);
            setGridColumns();
            lookUpRad.Visible = false;
            base.CloseWaitDialog();
        }

        private void SetupFilter()
        {
            this.dtFrom.DateTime = DateTime.Today; //DateTime.Today.AddDays(-1);
            //this.dtTo.DateTime = DateTime.Today;
        }
        private void getRadData()
        {
            ProcessRisPrGroup prcRadGroup = new ProcessRisPrGroup();
            GBLEnvVariable env = new GBLEnvVariable();

            lookUpRad.Properties.DataSource = prcRadGroup.getGroupEmp(env.OrgID);
            lookUpRad.Properties.ValueMember = "PR_GROUP_ID";
            lookUpRad.Properties.DisplayMember = "PR_GROUP_NAME";

            lookUpRad.Properties.PopulateColumns();
            //lookUpRad.Properties.Columns.Add(new LookUpColumnInfo("PR_GROUP_ID", "ID", 20));
            //lookUpRad.Properties.Columns.Add(new LookUpColumnInfo("PR_GROUP_NAME", "Name", 80));
            lookUpRad.Properties.Columns["PR_GROUP_ID"].Visible = false;
            //lookUpRad.Properties.Columns["mergeGroup"].Visible = false;

            lookUpRad.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            lookUpRad.Properties.ShowHeader = false;
            lookUpRad.Properties.NullText = "Please Select Rad Group";
        }
        private void getAlgorithmData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Text");
            dt.Rows.Add(new object[] { 1, "CT" });
            dt.Rows.Add(new object[] { 2, "General 30% Ultrasound 70%" });
            lookUpAlgorithm.Properties.DataSource = dt.DefaultView;
            lookUpAlgorithm.Properties.ValueMember = "ID";
            lookUpAlgorithm.Properties.DisplayMember = "Text";

            //lookUpRad.Properties.PopulateColumns();
            lookUpAlgorithm.Properties.Columns.Add(new LookUpColumnInfo("ID", "ID", 20));
            lookUpAlgorithm.Properties.Columns.Add(new LookUpColumnInfo("Text", "Name", 80));
            lookUpAlgorithm.Properties.Columns["ID"].Visible = false;
            //lookUpRad.Properties.Columns["mergeGroup"].Visible = false;

            lookUpAlgorithm.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            lookUpAlgorithm.Properties.ShowHeader = false;
            lookUpAlgorithm.Properties.NullText = "Please Select Algorithm";
        }
        private void getGroupFromPrStudies(DateTime dtStart, DateTime dtEnd)
        {
            ProcessRisPrStudies prcEmpInGroup = new ProcessRisPrStudies();
            GBLEnvVariable env = new GBLEnvVariable();

            GroupData = prcEmpInGroup.getGroupFromPrStudies(env.OrgID, dtStart, dtEnd);
            GroupData.Columns.Add("DELETE");
            gridPeerReview.DataSource = GroupData;
        }
        private void setGridColumns()
        {
            for (int i = 0; i < gridViewPeerReviewWorkList.Columns.Count; i++)
                gridViewPeerReviewWorkList.Columns[i].Visible = false;
            gridPeerReview.ForceInitialize();

            gridViewPeerReviewWorkList.OptionsView.ShowAutoFilterRow = true;

            //gridViewPeerReviewWorkList.Columns["PR_GROUP_ID"].Visible = false;
            //gridViewPeerReviewWorkList.Columns["PR_GROUP_ID"].VisibleIndex = 1;
            //gridViewPeerReviewWorkList.Columns["PR_GROUP_ID"].Width = 217;
            //gridViewPeerReviewWorkList.Columns["PR_GROUP_ID"].OptionsColumn.ReadOnly = true;
            //gridViewPeerReviewWorkList.Columns["PR_GROUP_ID"].OptionsColumn.AllowFocus = false;

            gridViewPeerReviewWorkList.Columns["PR_GROUP_NAME"].Visible = true;
            gridViewPeerReviewWorkList.Columns["PR_GROUP_NAME"].Caption = "Group Name";
            gridViewPeerReviewWorkList.Columns["PR_GROUP_NAME"].VisibleIndex = 2;
            gridViewPeerReviewWorkList.Columns["PR_GROUP_NAME"].Width = 150;
            gridViewPeerReviewWorkList.Columns["PR_GROUP_NAME"].OptionsColumn.ReadOnly = true;
            gridViewPeerReviewWorkList.Columns["PR_GROUP_NAME"].OptionsColumn.AllowFocus = false;

            gridViewPeerReviewWorkList.Columns["ALGORITHM_TEXT"].Visible = true;
            gridViewPeerReviewWorkList.Columns["ALGORITHM_TEXT"].Caption = "Algorithm";
            gridViewPeerReviewWorkList.Columns["ALGORITHM_TEXT"].VisibleIndex = 3;
            gridViewPeerReviewWorkList.Columns["ALGORITHM_TEXT"].Width = 150;
            gridViewPeerReviewWorkList.Columns["ALGORITHM_TEXT"].OptionsColumn.ReadOnly = true;
            gridViewPeerReviewWorkList.Columns["ALGORITHM_TEXT"].OptionsColumn.AllowFocus = false;

            gridViewPeerReviewWorkList.Columns["DELETE"].Visible = true;
            gridViewPeerReviewWorkList.Columns["DELETE"].Caption = "Delete";
            gridViewPeerReviewWorkList.Columns["DELETE"].VisibleIndex = 4;
            gridViewPeerReviewWorkList.Columns["DELETE"].OptionsColumn.AllowEdit = true;
            gridViewPeerReviewWorkList.Columns["DELETE"].OptionsColumn.ReadOnly = false;
            gridViewPeerReviewWorkList.Columns["DELETE"].OptionsColumn.FixedWidth = true;
            gridViewPeerReviewWorkList.Columns["DELETE"].Width = 75;

            gridViewPeerReviewWorkList.BestFitColumns();


            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rep = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            rep.Buttons.Clear();
            DevExpress.XtraEditors.Controls.EditorButton btnDelGroup = new DevExpress.XtraEditors.Controls.EditorButton();
            btnDelGroup.Caption = "Delete";
            btnDelGroup.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            rep.Buttons.Add(btnDelGroup);
            rep.ButtonPressed += new ButtonPressedEventHandler(Delete_ButtonPressed);
            rep.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            gridViewPeerReviewWorkList.Columns["DELETE"].ColumnEdit = rep;
    
            
        }

        private void Delete_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (gridViewPeerReviewWorkList.FocusedRowHandle > -1)
            {

                DataRow row = gridViewPeerReviewWorkList.GetDataRow(gridViewPeerReviewWorkList.FocusedRowHandle);

                ProcessRisPrStudies prc = new ProcessRisPrStudies();
                prc.delete(Convert.ToInt32(row["PR_GROUP_ID"].ToString()), Convert.ToInt32(row["PR_ALGORITHM_ID"].ToString()));

                GroupData.Rows.Remove(row);
                GroupData.AcceptChanges();

               
            }
        }


        private void barBtnRadGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgRadGroup frm = new dlgRadGroup();
            frm.ShowDialog();

            getRadData();
        }
        private void barBtnAlgorithm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgAlgorithm frm = new dlgAlgorithm();
            frm.ShowDialog();

            getAlgorithmData();
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
            //this.Close();
        }



        private void btnRadGroupEdit_Click(object sender, EventArgs e)
        {
            if (lookUpRad.EditValue == null)
            {
                dxErrorProvider1.SetError(lookUpRad, "cannot empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                return;
            }
            else
            {
                lookUpRad.ErrorText = string.Empty;

                dlgRadGroup frm = new dlgRadGroup(Convert.ToInt32(lookUpRad.EditValue.ToString()), lookUpRad.Text);
                frm.ShowDialog();

                getRadData();
            }
        }

        private void btnAlgorithmEdit_Click(object sender, EventArgs e)
        {

            if (lookUpAlgorithm.EditValue == null)
            {
                dxErrorProvider1.SetError(lookUpAlgorithm, "cannot empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                return;
            }
            else
            {
                dlgAlgorithm frm = new dlgAlgorithm();
                frm.ShowDialog();

                getAlgorithmData();
                //lookUpAlgorithm.ErrorText = string.Empty;

                //dlgRadGroup frm = new dlgRadGroup();
                //frm.ShowDialog();

                //getRadData();
            }
        }

        private void btnDistribute_Click(object sender, EventArgs e)
        {
            ShowWaitDialog();

            if (lookUpAlgorithm.EditValue != null && lookUpRad.EditValue != null)
            {
                lookUpRad.ErrorText = string.Empty;
                lookUpAlgorithm.ErrorText = string.Empty;
                GBLEnvVariable env = new GBLEnvVariable();

                int AlgorithmId = 0;
                AlgorithmId = Convert.ToInt32(lookUpAlgorithm.EditValue.ToString());

                int grId = 0;
                grId = Convert.ToInt32(lookUpRad.EditValue.ToString());

                ProcessRisPrStudies prcPrStudies = new ProcessRisPrStudies();
                var id = prcPrStudies.getGroupFromPrStudiesByGroupIdAndAlgorithmId(grId, AlgorithmId, env.OrgID).Rows.Count;
                if (prcPrStudies.getGroupFromPrStudiesByGroupIdAndAlgorithmId(grId, AlgorithmId, env.OrgID).Rows.Count == 0)
                {
                    DataTable EmpInGroupData = new DataTable();
                    DataTable AlgorithmData = new DataTable();
                    ProcessRisPrAlgorithm prc = new ProcessRisPrAlgorithm();

                    AlgorithmData = prc.getAlgorithmData(AlgorithmId, env.OrgID);

                    ProcessRisPrGroup prcEmpInGroup = new ProcessRisPrGroup();
                    EmpInGroupData = prcEmpInGroup.getEmpInGroup(grId, env.OrgID);

                    foreach (DataRow itemGroups in EmpInGroupData.Rows)
                    {
                        foreach (DataRow itemAlgorithms in AlgorithmData.Rows)
                        {
                            ProcessRisPrStudies prcStudies = new ProcessRisPrStudies();
                            prcStudies.createdPrStudies(itemAlgorithms["ACCESSION_NO"].ToString(), grId, AlgorithmId, Convert.ToInt32(itemGroups["RAD_ID"].ToString()), env.OrgID, env.UserID);
                        }
                    }

                    DateTime dtStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    DateTime dtEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                    getGroupFromPrStudies(dtStart, dtEnd);
                }
            }
            else
            {
                if (lookUpRad.EditValue == null)
                {
                    dxErrorProvider1.SetError(lookUpRad, "cannot empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }
                else
                {
                    lookUpRad.ErrorText = string.Empty;
                }

                if (lookUpAlgorithm.EditValue == null)
                {
                    dxErrorProvider1.SetError(lookUpAlgorithm, "cannot empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                }
                else
                {
                    lookUpAlgorithm.ErrorText = string.Empty;
                }
            }
            base.CloseWaitDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dtFrom.Text))
            {
                dxErrorProvider1.SetError(dtFrom, "cannot empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                return;
            }
            else
            {
                dtFrom.ErrorText = string.Empty;

                ShowWaitDialog();
                DateTime sd = dtFrom.DateTime;

                DateTime dtStart = new DateTime(sd.Year, sd.Month, sd.Day, 0, 0, 0);
                DateTime dtEnd = new DateTime(sd.Year, sd.Month, sd.Day, 23, 59, 59);

                getGroupFromPrStudies(dtStart, dtEnd);
                setGridColumns();

                base.CloseWaitDialog();
            }
        }



        
       
    }
}
