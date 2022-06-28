using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using Envision.NET.Forms.Dialog;

namespace Envision.NET.Risk
{
    public partial class RiskIncidentViewerForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private struct RiskIncidentParameters
        {
            public int RISK_CAT_ID { get; set; }
            public int INCIDENT_ID { get; set; }
        }
        public enum FormModes
        {
            Add, Edit, None
        }
        private FormModes _formMode;
        public FormModes FormMode
        {
            get { return this._formMode; }
            set
            {
                this._formMode = value;
                if (this._formMode == FormModes.None)
                {
                    //this.tbIncidentCode.Properties.ReadOnly = true;
                    this.icbPriority.Properties.ReadOnly = true;
                    this.tbIncidentSubject.Properties.ReadOnly = true;
                    this.bteRiskCategory.Properties.ReadOnly = true;
                    this.mmIncidentDescription.Properties.ReadOnly = true;
                }
                else if (this._formMode == FormModes.Add)
                {
                    //this.tbIncidentCode.Properties.ReadOnly = false;
                    this.icbPriority.Properties.ReadOnly = false;
                    this.tbIncidentSubject.Properties.ReadOnly = false;
                    this.bteRiskCategory.Properties.ReadOnly = false;
                    this.mmIncidentDescription.Properties.ReadOnly = false;

                    //this.tbIncidentCode.Text = string.Empty;
                    this.icbPriority.SelectedIndex = 1;
                    this.tbIncidentSubject.Text = string.Empty;
                    this.bteRiskCategory.Text = string.Empty;
                    this.mmIncidentDescription.Text = string.Empty;
                }
                else
                {
                    //this.tbIncidentCode.Properties.ReadOnly = false;
                    this.icbPriority.Properties.ReadOnly = false;
                    this.tbIncidentSubject.Properties.ReadOnly = false;
                    this.bteRiskCategory.Properties.ReadOnly = false;
                    this.mmIncidentDescription.Properties.ReadOnly = false;
                }
            }
        }
        private DataSet dsInvolvmentSet;
        private InvolvmentLookUp involvmentLookUp;
        private RiskCategoryLookUp riskCategoryLookUp;
        private RiskIncidentParameters riskIncidentParameters;
        private MyMessageBox messageBox;
        private int language = new GBLEnvVariable().CurrentLanguageID;
        private int orgId = new GBLEnvVariable().OrgID;
        private int empId = new GBLEnvVariable().UserID;
        private DataRow tempSelectedIncidentRow;
        public RiskIncidentViewerForm()
        {
            InitializeComponent();
            this.riskCategoryLookUp = new RiskCategoryLookUp();
            this.riskIncidentParameters = new RiskIncidentParameters();
            this.messageBox = new MyMessageBox();
            this.Load += new EventHandler(RiskIncidentViewerForm_Load);
            this.btnClose.ItemClick += new ItemClickEventHandler(btnClose_ItemClick);
            this.btnInvolvment.ItemClick += new ItemClickEventHandler(btnInvolvment_ItemClick);
            this.btnRiskCategory.ItemClick += new ItemClickEventHandler(btnRiskCategory_ItemClick);
            this.btnSave.ItemClick += new ItemClickEventHandler(btnSave_ItemClick);
            this.btnDelete.ItemClick += new ItemClickEventHandler(btnDelete_ItemClick);
            this.btnEdit.ItemClick += new ItemClickEventHandler(btnEdit_ItemClick);
            this.btnCancel.ItemClick += new ItemClickEventHandler(btnCancel_ItemClick);
            this.btnAdd.ItemClick += new ItemClickEventHandler(btnAdd_ItemClick);
            this.bteRiskCategory.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(bteRiskCategory_ButtonClick);
        }

        #region Add Click
        protected void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.FormMode = FormModes.Add;
        }
        #endregion

        #region Cancel Click
        protected void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.tempSelectedIncidentRow != null)
            {
                this.FormMode = FormModes.None;
                //this.tbIncidentCode.Text = this.tempSelectedIncidentRow["INCIDENT_UID"].ToString();
                this.tbIncidentSubject.Text = this.tempSelectedIncidentRow["INCIDENT_SUBJ"].ToString();
                this.mmIncidentDescription.Text = this.tempSelectedIncidentRow["INCIDENT_DESC"].ToString();
                this.riskIncidentParameters.RISK_CAT_ID = Convert.ToInt32(tempSelectedIncidentRow["RISK_CAT_ID"]);
                this.riskIncidentParameters.INCIDENT_ID = Convert.ToInt32(tempSelectedIncidentRow["INCIDENT_ID"]);
                this.bteRiskCategory.Text = this.tempSelectedIncidentRow["RISK_CAT_NAME"].ToString();
                string priority = tempSelectedIncidentRow["PRIORITY"].ToString();
                if (priority == "L")
                    this.icbPriority.SelectedIndex = 0;
                else if (priority == "H")
                    this.icbPriority.SelectedIndex = 2;
                else
                    this.icbPriority.SelectedIndex = 1;
            }
        }
        #endregion

        #region Edit Click
        protected void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(!this.tempSelectedIncidentRow["CREATED_BY"].Equals(this.empId))
                return;
            this.FormMode = FormModes.Edit;
        }
        #endregion

        #region Delete Click
        protected void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!this.tempSelectedIncidentRow["CREATED_BY"].Equals(this.empId))
                return;
            string result = this.messageBox.ShowAlert("UID6036", language);
            if (result == "2")
            {
                try
                {
                    int incidentId = this.riskIncidentParameters.INCIDENT_ID;
                    ProcessDeleteRisRiskIncidentUsers processDeleteRiskIncidentUsers = new ProcessDeleteRisRiskIncidentUsers();
                    processDeleteRiskIncidentUsers.Mode = 1;
                    processDeleteRiskIncidentUsers.RIS_RISKINCIDENTUSERS.INCIDENT_ID = incidentId;
                    processDeleteRiskIncidentUsers.Invoke();

                    ProcessDeleteRisRiskIncidents processDeleteRiskIncident = new ProcessDeleteRisRiskIncidents();
                    processDeleteRiskIncident.RIS_RISKINCIDENTS.INCIDENT_ID = incidentId;
                    processDeleteRiskIncident.Invoke();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    
                }
                catch (Exception) { }
            }
        }
        #endregion

        #region Save Incident
        protected void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this._formMode != FormModes.None)
            {
                if (!string.IsNullOrEmpty(this.tbIncidentSubject.Text.Trim())
                    && !string.IsNullOrEmpty(this.bteRiskCategory.Text.Trim())
                    && !string.IsNullOrEmpty(this.mmIncidentDescription.Text.Trim()))
                {
                    if (this._formMode == FormModes.Add)
                    {
                        string result = this.messageBox.ShowAlert("UID6034", language);
                        if (result == "2")
                        {
                            try
                            {
                                ProcessAddRisRiskIncidents processAddRiskIncident = new ProcessAddRisRiskIncidents();
                                processAddRiskIncident.RIS_RISKINCIDENTS.RISK_CAT_ID = this.riskIncidentParameters.RISK_CAT_ID;
                                processAddRiskIncident.RIS_RISKINCIDENTS.ORG_ID = orgId;
                                processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_UID = string.Empty;
                                processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_SUBJ = this.tbIncidentSubject.Text;
                                processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_DT = DateTime.Now;
                                processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_DESC = this.mmIncidentDescription.Text;
                                processAddRiskIncident.RIS_RISKINCIDENTS.CREATED_BY = empId;
                                processAddRiskIncident.RIS_RISKINCIDENTS.COMMENT_ID = -1;
                                processAddRiskIncident.RIS_RISKINCIDENTS.PRIORITY = this.icbPriority.EditValue.ToString();
                                processAddRiskIncident.Invoke();

                                if (this.dsInvolvmentSet != null)
                                {
                                    if (this.dsInvolvmentSet.Tables.Count > 0)
                                    {
                                        foreach (DataRow drInvolvment in this.dsInvolvmentSet.Tables[0].Rows)
                                        {
                                            ProcessAddRisRiskIncidentUsers processAddRiskIncidentUser = new ProcessAddRisRiskIncidentUsers();
                                            processAddRiskIncidentUser.RIS_RISKINCIDENTUSERS.CREATED_BY = empId;
                                            processAddRiskIncidentUser.RIS_RISKINCIDENTUSERS.EMP_ID = Convert.ToInt32(drInvolvment["EMP_ID"]);
                                            processAddRiskIncidentUser.RIS_RISKINCIDENTUSERS.INCIDENT_ID = processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_ID;
                                            processAddRiskIncidentUser.RIS_RISKINCIDENTUSERS.ORG_ID = orgId;
                                            processAddRiskIncidentUser.Invoke();
                                        }
                                    }
                                }
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            catch (Exception) { }
                        }
                    }
                    else if (this._formMode == FormModes.Edit)
                    {
                        string result = this.messageBox.ShowAlert("UID6035", language);
                        if (result == "2")
                        {
                            try
                            {
                                ProcessUpdateRisRiskIncidents processUpdateRiskIncident = new ProcessUpdateRisRiskIncidents();
                                processUpdateRiskIncident.RIS_RISKINCIDENTS.RISK_CAT_ID = this.riskIncidentParameters.RISK_CAT_ID;
                                processUpdateRiskIncident.RIS_RISKINCIDENTS.ORG_ID = orgId;
                                processUpdateRiskIncident.RIS_RISKINCIDENTS.INCIDENT_UID = string.Empty;
                                processUpdateRiskIncident.RIS_RISKINCIDENTS.INCIDENT_SUBJ = this.tbIncidentSubject.Text;
                                processUpdateRiskIncident.RIS_RISKINCIDENTS.INCIDENT_ID = this.riskIncidentParameters.INCIDENT_ID;
                                processUpdateRiskIncident.RIS_RISKINCIDENTS.INCIDENT_DESC = this.mmIncidentDescription.Text;
                                processUpdateRiskIncident.RIS_RISKINCIDENTS.LAST_MODIFIED_BY = empId;
                                processUpdateRiskIncident.RIS_RISKINCIDENTS.PRIORITY = this.icbPriority.EditValue.ToString();
                                processUpdateRiskIncident.Invoke();

                                //Clear old involvment
                                ProcessDeleteRisRiskIncidentUsers processDeleteRiskIncidentUsers = new ProcessDeleteRisRiskIncidentUsers();
                                processDeleteRiskIncidentUsers.Mode = 1;
                                processDeleteRiskIncidentUsers.RIS_RISKINCIDENTUSERS.INCIDENT_ID = this.riskIncidentParameters.INCIDENT_ID;
                                processDeleteRiskIncidentUsers.Invoke();

                                //Add new involvment
                                foreach (DataRow drInvolvment in this.dsInvolvmentSet.Tables[0].Rows)
                                {
                                    ProcessAddRisRiskIncidentUsers processAddRiskIncidentUser = new ProcessAddRisRiskIncidentUsers();
                                    processAddRiskIncidentUser.RIS_RISKINCIDENTUSERS.CREATED_BY = empId;
                                    processAddRiskIncidentUser.RIS_RISKINCIDENTUSERS.EMP_ID = Convert.ToInt32(drInvolvment["EMP_ID"]);
                                    processAddRiskIncidentUser.RIS_RISKINCIDENTUSERS.INCIDENT_ID = this.riskIncidentParameters.INCIDENT_ID;
                                    processAddRiskIncidentUser.RIS_RISKINCIDENTUSERS.ORG_ID = orgId;
                                    processAddRiskIncidentUser.Invoke();
                                }

                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            catch (Exception) { }
                        }
                    }
                }
                else
                {
                    this.messageBox.ShowAlert("UID6033", language);
                }
            }
        }
        #endregion

        #region Select Risk Category
        protected void bteRiskCategory_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this._formMode != FormModes.None)
            {
                DialogResult result = this.riskCategoryLookUp.ShowDialog(true);
                if (result == DialogResult.OK)
                {
                    DataRow drResultRow = this.riskCategoryLookUp.SelectedCategoryRow;
                    if (drResultRow != null)
                    {
                        this.riskIncidentParameters.RISK_CAT_ID = Convert.ToInt32(drResultRow["RISK_CAT_ID"]);
                        this.bteRiskCategory.Text = "[" + drResultRow["RISK_CAT_UID"].ToString() + "] "
                            + drResultRow["RISK_CAT_DESC"].ToString();
                    }
                }
            }
        }
        #endregion

        #region Risk Category Click
        protected void btnRiskCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.riskCategoryLookUp.ShowDialog();
        }
        #endregion

        #region Involvment Click
        protected void btnInvolvment_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this._formMode == FormModes.None)
            {
                this.involvmentLookUp = new InvolvmentLookUp(this.dsInvolvmentSet);
                this.involvmentLookUp.ShowDialog(true);
            }
            else if (this._formMode == FormModes.Add)
            {
                this.involvmentLookUp = new InvolvmentLookUp(this.dsInvolvmentSet);
                DialogResult result = this.involvmentLookUp.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.dsInvolvmentSet = this.involvmentLookUp.EmplyeeResultDataSet.Copy();
                }
            }
            else if (this._formMode == FormModes.Edit)
            {
                this.involvmentLookUp = new InvolvmentLookUp(this.dsInvolvmentSet);
                this.involvmentLookUp.ShowDialog();
            }
        }
        #endregion

        #region Close Form Click
        protected void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region First Load
        protected void RiskIncidentViewerForm_Load(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Show Form Events
        
        public DialogResult ShowDialog(FormModes showWithMode)
        {
            this.FormMode = showWithMode;
            return this.ShowDialog();
        }

        public DialogResult ShowDialog(DataRow initialDataRow, FormModes showWithMode)
        {
            this.FormMode = showWithMode;
            if (initialDataRow != null)
            {
                try
                {
                    #region Get Incident Detail
                    int incident_id = Convert.ToInt32(initialDataRow["INCIDENT_ID"]);
                    ProcessGetRisRiskIncidents processGetRiskIncidents = new ProcessGetRisRiskIncidents();
                    processGetRiskIncidents.RIS_RISKINCIDENTS.INCIDENT_ID = incident_id;
                    processGetRiskIncidents.RIS_RISKINCIDENTS.ORG_ID = 1;
                    processGetRiskIncidents.Mode = 1;
                    processGetRiskIncidents.Invoke();
                    DataSet dsIncidentById = processGetRiskIncidents.Result;
                    if (dsIncidentById != null)
                    {
                        if (dsIncidentById.Tables.Count > 0)
                        {
                            if (dsIncidentById.Tables[0].Rows.Count > 0)
                            {
                                this.tempSelectedIncidentRow = dsIncidentById.Tables[0].Rows[0];
                                this.riskIncidentParameters.RISK_CAT_ID = Convert.ToInt32(dsIncidentById.Tables[0].Rows[0]["RISK_CAT_ID"]);
                                this.riskIncidentParameters.INCIDENT_ID = Convert.ToInt32(dsIncidentById.Tables[0].Rows[0]["INCIDENT_ID"]);
                                //this.tbIncidentCode.Text = dsIncidentById.Tables[0].Rows[0]["INCIDENT_UID"].ToString();
                                string priority = dsIncidentById.Tables[0].Rows[0]["PRIORITY"].ToString();
                                if (priority == "L")
                                    this.icbPriority.SelectedIndex = 0;
                                else if (priority == "H")
                                    this.icbPriority.SelectedIndex = 2;
                                else
                                    this.icbPriority.SelectedIndex = 1;
                                this.tbIncidentSubject.Text = dsIncidentById.Tables[0].Rows[0]["INCIDENT_SUBJ"].ToString();
                                this.bteRiskCategory.Text = dsIncidentById.Tables[0].Rows[0]["RISK_CAT_NAME"].ToString();
                                this.mmIncidentDescription.Text = dsIncidentById.Tables[0].Rows[0]["INCIDENT_DESC"].ToString();
                            }
                        }
                    }
                    #endregion

                    #region Get Involvment
                    ProcessGetRisRiskIncidentUsers processGetRiskIncidentUsers = new ProcessGetRisRiskIncidentUsers();
                    processGetRiskIncidentUsers.RIS_RISKINCIDENTUSERS.ORG_ID = 1;
                    processGetRiskIncidentUsers.RIS_RISKINCIDENTUSERS.INCIDENT_ID = incident_id;
                    processGetRiskIncidentUsers.Mode = 2;
                    processGetRiskIncidentUsers.Invoke();
                    this.dsInvolvmentSet = processGetRiskIncidentUsers.Result;
                    #endregion
                    //this.tbIncidentCode.Focus();
                }
                catch (Exception) { }
            }
            return this.ShowDialog();
        }
        #endregion

        #region On Closeing (Override)
        protected override void OnClosing(CancelEventArgs e)
        {
            this.tempSelectedIncidentRow = null;
            this.dsInvolvmentSet = null;
            base.OnClosing(e);
        }
        #endregion
    }
}