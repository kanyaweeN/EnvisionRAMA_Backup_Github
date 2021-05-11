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
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.NET.Forms.Dialog;
using Envision.Common;

namespace Envision.NET.Risk
{
    public partial class RiskCategoryLookUp : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public enum FormModes
        {
            None, Add, Edit, Delete
        }
        private FormModes _formMode = FormModes.None;
        public FormModes FormMode
        {
            get { return _formMode; }
            set
            {
                this._formMode = value;
                if (this._formMode == FormModes.None)
                {
                    this.tbRiskCatCode.Properties.ReadOnly = true;
                    this.tbRiskCatDesc.Properties.ReadOnly = true;
                    this.tempCatCode = string.Empty;
                    this.tempCatDesc = string.Empty;
                }
                else if (this._formMode == FormModes.Add)
                {
                    this.tbRiskCatCode.Properties.ReadOnly = false;
                    this.tbRiskCatDesc.Properties.ReadOnly = false;
                    this.tbRiskCatCode.Focus();
                }
                else if (this._formMode == FormModes.Edit)
                {
                    this.tbRiskCatCode.Properties.ReadOnly = false;
                    this.tbRiskCatDesc.Properties.ReadOnly = false;
                    this.tbRiskCatCode.Focus();
                }
            }
        }
        private DataSet dsCategory;
        private MyMessageBox myMessageBox;
        private int language = new GBLEnvVariable().CurrentLanguageID;
        private int userId = new GBLEnvVariable().UserID;
        private int orgId = new GBLEnvVariable().OrgID;
        private string tempCatCode;
        private string tempCatDesc;
        public DataRow SelectedCategoryRow { get; set; }
        public RiskCategoryLookUp()
        {
            InitializeComponent();
            this.myMessageBox = new MyMessageBox();
            this.Load += new EventHandler(RiskCategolyLookUp_Load);
            this.btnAddCat.ItemClick += new ItemClickEventHandler(btnAddCat_ItemClick);
            this.btnClose.ItemClick += new ItemClickEventHandler(btnClose_ItemClick);
            this.btnEdit.ItemClick += new ItemClickEventHandler(btnEdit_ItemClick);
            this.btnDelete.ItemClick += new ItemClickEventHandler(btnDelete_ItemClick);
            this.btnSave.ItemClick += new ItemClickEventHandler(btnSave_ItemClick);
            this.btnCancel.ItemClick += new ItemClickEventHandler(btnCancel_ItemClick);
            this.gridRiskCatView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridRiskCatView_FocusedRowChanged);
            
        }

        #region Grid Focus Row Changed
        protected void gridRiskCatView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.FormMode = FormModes.None;
        }
        #endregion

        #region Cancel Click
        protected void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this._formMode != FormModes.None)
            {
                this.tbRiskCatCode.Text = this.tempCatCode;
                this.tbRiskCatDesc.Text = this.tempCatDesc;
            }
            this.FormMode = FormModes.None;
        }
        #endregion

        #region Save Click
        protected void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this._formMode != FormModes.None)
            {
                if (!string.IsNullOrEmpty(this.tbRiskCatCode.Text.Trim()) &&
                    !string.IsNullOrEmpty(this.tbRiskCatDesc.Text.Trim()))
                {
                    string result = this.myMessageBox.ShowAlert("UID6031", language);
                    if (result == "2")
                    {
                        if (this._formMode == FormModes.Add)
                        {
                            try
                            {
                                ProcessAddRisRiskCategorise processAddRiskCategory = new ProcessAddRisRiskCategorise();
                                processAddRiskCategory.RIS_RISKCATEGORISE.RISK_CAT_UID = this.tbRiskCatCode.Text;
                                processAddRiskCategory.RIS_RISKCATEGORISE.RISK_CAT_DESC = this.tbRiskCatDesc.Text;
                                processAddRiskCategory.RIS_RISKCATEGORISE.ORG_ID = this.orgId;
                                processAddRiskCategory.RIS_RISKCATEGORISE.CREATED_BY = this.userId;
                                processAddRiskCategory.Invoke();

                                this.LoadCategorise();
                                this.FormMode = FormModes.None;
                            }
                            catch (Exception) { }
                        }
                        else if (this._formMode == FormModes.Edit)
                        {
                            try
                            {
                                if (this.gridRiskCatView.FocusedRowHandle > -1)
                                {
                                    DataRow drUpdateRiskRow = this.gridRiskCatView.GetDataRow(this.gridRiskCatView.FocusedRowHandle);
                                    if (drUpdateRiskRow != null)
                                    {
                                        ProcessUpdateRisRiskCategorise processUpdateRiskCategory = new ProcessUpdateRisRiskCategorise();
                                        processUpdateRiskCategory.RIS_RISKCATEGORISE.RISK_CAT_ID = Convert.ToInt32(drUpdateRiskRow["RISK_CAT_ID"]);
                                        processUpdateRiskCategory.RIS_RISKCATEGORISE.RISK_CAT_UID = this.tbRiskCatCode.Text;
                                        processUpdateRiskCategory.RIS_RISKCATEGORISE.RISK_CAT_DESC = this.tbRiskCatDesc.Text;
                                        processUpdateRiskCategory.RIS_RISKCATEGORISE.LAST_MODIFIED_BY = this.userId;
                                        processUpdateRiskCategory.RIS_RISKCATEGORISE.ORG_ID = this.orgId;
                                        processUpdateRiskCategory.Invoke();

                                        this.LoadCategorise();
                                        this.FormMode = FormModes.None;
                                    }
                                }
                            }
                            catch (Exception) { }
                        }
                    }
                }
                else 
                {
                    this.myMessageBox.ShowAlert("UID6033", language);
                }
            }
        }
        #endregion

        #region Delete Click
        protected void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            string result = this.myMessageBox.ShowAlert("UID6032", language);
            if (result == "2")
            {
                try
                {
                    if (this.gridRiskCatView.FocusedRowHandle > -1)
                    {
                        DataRow drDeleteRiskRow = this.gridRiskCatView.GetDataRow(this.gridRiskCatView.FocusedRowHandle);
                        if (drDeleteRiskRow != null)
                        {
                            ProcessDeleteRisRiskCategorise processDeleteRiskCategory = new ProcessDeleteRisRiskCategorise();
                            processDeleteRiskCategory.RIS_RISKCATEGORISE.RISK_CAT_ID = Convert.ToInt32(drDeleteRiskRow["RISK_CAT_ID"]);
                            processDeleteRiskCategory.Invoke();

                            this.LoadCategorise();
                            this.FormMode = FormModes.None;
                            this.gridRiskCatControl.Enabled = true;
                        }
                    }
                }
                catch (Exception) { }
            }
        }
        #endregion

        #region Edit Click
        protected void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.FormMode = FormModes.Edit;
            this.tempCatCode = this.tbRiskCatCode.Text;
            this.tempCatDesc = this.tbRiskCatDesc.Text;
        }
        #endregion

        #region Close Click
        protected void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Add Category Click
        protected void btnAddCat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.FormMode = FormModes.Add;
            this.tempCatCode = this.tbRiskCatCode.Text;
            this.tempCatDesc = this.tbRiskCatDesc.Text;
        }
        #endregion

        #region First Load
        protected void RiskCategolyLookUp_Load(object sender, EventArgs e)
        {
            this.FormMode = FormModes.None;
            this.LoadCategorise();
        }
        #endregion

        #region Load Categorise
        private void LoadCategorise()
        {
            ProcessGetRisRiskCategorise processGetRiskCategorise = new ProcessGetRisRiskCategorise();
            processGetRiskCategorise.RIS_RISKCATEGORISE.ORG_ID = 1;
            processGetRiskCategorise.Invoke();
            dsCategory = processGetRiskCategorise.Result;
            this.gridRiskCatControl.DataSource = dsCategory.Tables[0];
            this.tbRiskCatCode.DataBindings.Clear();
            this.tbRiskCatDesc.DataBindings.Clear();
            this.tbRiskCatCode.DataBindings.Add(new Binding("TEXT", dsCategory.Tables[0], "RISK_CAT_UID"));
            this.tbRiskCatDesc.DataBindings.Add(new Binding("TEXT", dsCategory.Tables[0], "RISK_CAT_DESC"));
        }
        #endregion

        #region Show LookUp Event
        public DialogResult ShowDialog(bool CanSelectRow)
        {
            if (CanSelectRow)
            {
                this.gridRiskCatView.DoubleClick += new EventHandler(gridRiskCatView_DoubleClick);
            }
            return this.ShowDialog();
        }
        #endregion

        #region Select Row
        protected void gridRiskCatView_DoubleClick(object sender, EventArgs e)
        {
            if (this.gridRiskCatView.FocusedRowHandle > -1)
            {
                DataRow drSelectRow = this.gridRiskCatView.GetDataRow(this.gridRiskCatView.FocusedRowHandle);
                this.SelectedCategoryRow = drSelectRow;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region On Closing (Overidde)
        protected override void OnClosing(CancelEventArgs e)
        {
            this.gridRiskCatView.DoubleClick -= new EventHandler(gridRiskCatView_DoubleClick);
            base.OnClosing(e);
        }
        #endregion
    }
}