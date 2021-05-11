using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessDelete;
using Envision.NET.Forms.Dialog;

namespace Envision.NET.Risk
{
    public partial class RiskIncidentForm : Envision.NET.Forms.Main.MasterForm//DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataSet dsRiskIncident;
        private RiskIncidentViewerForm riskIncidentViewer;
        private RiskCategoryLookUp riskCategoryLookUp;
        private InvolvmentLookUp involvementLookUp;
        private int orgId = new GBLEnvVariable().OrgID;
        private int language = new GBLEnvVariable().CurrentLanguageID;
        private int CurrentEmpId = new GBLEnvVariable().UserID;
        private MyMessageBox messageBox;
        public RiskIncidentForm()
        {
            InitializeComponent();
            this.riskIncidentViewer = new RiskIncidentViewerForm();
            this.riskCategoryLookUp = new RiskCategoryLookUp();
            this.messageBox = new MyMessageBox();
            this.Load += new EventHandler(RiskIncidentForm_Load);
            //this.btnAdd.ItemClick += new ItemClickEventHandler(btnAdd_ItemClick);
            //this.btnDelete.ItemClick += new ItemClickEventHandler(btnDelete_ItemClick);
            //this.btnEdit.ItemClick += new ItemClickEventHandler(btnEdit_ItemClick);
            //this.btnClose.ItemClick += new ItemClickEventHandler(btnClose_ItemClick);
            //this.btnRiskCategory.ItemClick += new ItemClickEventHandler(btnRiskCategory_ItemClick);
            //this.gridIncidentView.DoubleClick += new EventHandler(gridIncidentView_DoubleClick);
            //this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.repositoryItemImageComboBox2.Click += new EventHandler(repositoryItemImageComboBox2_Click);
            //this.btnRefresh.ItemClick += new ItemClickEventHandler(btnRefresh_ItemClick);
        }

        #region Look Up Involvement Click
        protected void repositoryItemImageComboBox2_Click(object sender, EventArgs e)
        {
            if (this.gridIncidentView.FocusedRowHandle > -1)
            {
                DataRow dr = this.gridIncidentView.GetDataRow(this.gridIncidentView.FocusedRowHandle);
                if (dr != null)
                {
                    if (dr["HAS_INVOLVEMENT"].Equals("N"))
                        return;
                    #region Get Involvment
                    ProcessGetRisRiskIncidentUsers processGetRiskIncidentUsers = new ProcessGetRisRiskIncidentUsers();
                    processGetRiskIncidentUsers.RIS_RISKINCIDENTUSERS.ORG_ID = 1;
                    processGetRiskIncidentUsers.RIS_RISKINCIDENTUSERS.INCIDENT_ID = Convert.ToInt32(dr["INCIDENT_ID"]);
                    processGetRiskIncidentUsers.Mode = 2;
                    processGetRiskIncidentUsers.Invoke();

                    DataSet dsInvolvmentSet = new DataSet();
                    dsInvolvmentSet = processGetRiskIncidentUsers.Result;
                    #endregion

                    this.involvementLookUp = new InvolvmentLookUp(dsInvolvmentSet);
                    this.involvementLookUp.ShowDialog(true);
                }
            }
        }
        #endregion

        #region Refresh Click
        protected void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.btnSearch_Click(this, EventArgs.Empty);
        }
        #endregion

        #region Search Click
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadIncidentDataSource(this.dteFrom.DateTime, this.dteTo.DateTime);
        }
        #endregion

        #region Focus Row Double Click
        protected void gridIncidentView_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region Risk Category Click
        protected void btnRiskCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.riskCategoryLookUp.ShowDialog();
        }
        #endregion

        #region Close Form Click
        protected void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Edit Click
        protected void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridIncidentView.FocusedRowHandle > -1)
            {
                DataRow drSelectedRow = this.gridIncidentView.GetDataRow(this.gridIncidentView.FocusedRowHandle);
                if (!drSelectedRow["CREATED_BY"].Equals(this.CurrentEmpId))
                    return;
                DialogResult result = this.riskIncidentViewer.ShowDialog(drSelectedRow, RiskIncidentViewerForm.FormModes.Edit);
                if (result == DialogResult.OK)
                {
                    this.LoadIncidentDataSource(this.dteFrom.DateTime, this.dteTo.DateTime);
                }
            }
        }
        #endregion

        #region Delete Click
        protected void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridIncidentView.FocusedRowHandle > -1)
            {
                DataRow drSelectedRow = this.gridIncidentView.GetDataRow(this.gridIncidentView.FocusedRowHandle);
                if (!drSelectedRow["CREATED_BY"].Equals(this.CurrentEmpId))
                    return;
                if (drSelectedRow != null)
                {
                    string result = this.messageBox.ShowAlert("UID6036", language);
                    if (result == "2")
                    {
                        try
                        {
                            int incidentId = Convert.ToInt32(drSelectedRow["INCIDENT_ID"]);
                            ProcessDeleteRisRiskIncidentUsers processDeleteRiskIncidentUsers = new ProcessDeleteRisRiskIncidentUsers();
                            processDeleteRiskIncidentUsers.Mode = 1;
                            processDeleteRiskIncidentUsers.RIS_RISKINCIDENTUSERS.INCIDENT_ID = incidentId;
                            processDeleteRiskIncidentUsers.Invoke();

                            ProcessDeleteRisRiskIncidents processDeleteRiskIncident = new ProcessDeleteRisRiskIncidents();
                            processDeleteRiskIncident.RIS_RISKINCIDENTS.INCIDENT_ID = incidentId;
                            processDeleteRiskIncident.Invoke();

                            this.LoadIncidentDataSource(this.dteFrom.DateTime, this.dteTo.DateTime);
                        }
                        catch (Exception) { }
                    }
                }
            }
        }
        #endregion

        #region Add Click
        protected void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult result = this.riskIncidentViewer.ShowDialog(RiskIncidentViewerForm.FormModes.Add);
            if (result == DialogResult.OK)
            {
                this.LoadIncidentDataSource(this.dteFrom.DateTime, this.dteTo.DateTime);
            }
        }
        #endregion

        #region First Load
        protected void RiskIncidentForm_Load(object sender, EventArgs e)
        {
            //Set Search Range Date
            DateTime dtFrom = DateTime.Today;
            DateTime dtTo = dtFrom.AddDays(-7);
            this.dteFrom.DateTime = dtTo;
            this.dteTo.DateTime = dtFrom;

            this.LoadIncidentDataSource(this.dteFrom.DateTime, this.dteTo.DateTime);
            this.CloseWaitDialog();
        }
        #endregion

        #region Load Incident DataSource
        private void LoadIncidentDataSource(DateTime dtFrom, DateTime dtTo)
        {
            DateTime dtFrom1 = new DateTime(dtFrom.Year, dtFrom.Month, dtFrom.Day, 0, 0, 0);
            DateTime dtTo1 = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);
            ProcessGetRisRiskIncidents processGetIncidents = new ProcessGetRisRiskIncidents();
            processGetIncidents.RIS_RISKINCIDENTS.ORG_ID = orgId;
            processGetIncidents.Mode = 2;
            processGetIncidents.From = dtFrom1;
            processGetIncidents.To = dtTo1;
            processGetIncidents.Invoke();
            this.dsRiskIncident = processGetIncidents.Result;
            this.gridIncidentControl.DataSource = this.dsRiskIncident.Tables[0];
        }
        #endregion
    }
}