using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Envision.NET.Risk
{
    public partial class InvolvmentLookUp : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public enum FormModes
        {
            None, Add
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

                }
                else if(this._formMode == FormModes.Add)
                {

                }
            }
        }
        private EmployeeListLookUp empLookUp;
        private DataSet dsEmpList;
        public DataSet EmplyeeResultDataSet { get; set; }
        private bool IsReadOnly = false;
        #region Constructor
        public InvolvmentLookUp(DataSet dsInvolvmentList)
        {
            InitializeComponent();
            this.Load += new EventHandler(InvolvmentLookUp_Load);
            this.btnAdd.ItemClick += new ItemClickEventHandler(btnAdd_ItemClick);
            this.btnDelete.ItemClick += new ItemClickEventHandler(btnDelete_ItemClick);
            this.btnClose.ItemClick += new ItemClickEventHandler(btnClose_ItemClick);
            this.btnOK.ItemClick += new ItemClickEventHandler(btnOK_ItemClick);
            this.empLookUp = new EmployeeListLookUp();
            this.dsEmpList = dsInvolvmentList;
            if (this.dsEmpList == null || this.dsEmpList.Tables.Count == 0)
            {
                this.dsEmpList = new DataSet();
                this.dsEmpList.Tables.Add();
                this.dsEmpList.Tables[0].Columns.Add("EMP_ID", typeof(int), "");
                this.dsEmpList.Tables[0].Columns.Add("EMP_UID", typeof(string), "");
                this.dsEmpList.Tables[0].Columns.Add("FULL_NAME", typeof(string), "");
                this.dsEmpList.Tables[0].Columns.Add("UNIT_NAME", typeof(string), "");
                this.dsEmpList.Tables[0].AcceptChanges();
            }
            else
            {

            }
        }
        public InvolvmentLookUp()
            : this(null) { }
        #endregion

        #region Ok Click
        protected void btnOK_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.EmplyeeResultDataSet = this.dsEmpList.Copy();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region Close Click
        protected void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.EmplyeeResultDataSet = this.dsEmpList.Copy();
            this.DialogResult = DialogResult.OK;
            //this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Delete Click
        protected void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!this.IsReadOnly)
            {
                if (this.gridInvolvmentView.FocusedRowHandle > -1)
                {
                    DataRow drRemover = this.gridInvolvmentView.GetDataRow(this.gridInvolvmentView.FocusedRowHandle);
                    this.dsEmpList.Tables[0].Rows.Remove(drRemover);
                }
            }
        }
        #endregion

        #region Add Click
        protected void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!this.IsReadOnly)
            {
                this.FormMode = FormModes.Add;
                DialogResult result = this.empLookUp.ShowDialog(this.dsEmpList);
                if (result == DialogResult.OK)
                {
                    DataRow[] drEmpDtls = this.empLookUp.ResultRows;
                    this.dsEmpList.Tables[0].Rows.Clear();
                    foreach (DataRow drEmpDtl in drEmpDtls)
                    {
                        this.dsEmpList.Tables[0].Rows.Add(drEmpDtl["CONTACT_ID"], drEmpDtl["CONTACT_UID"], drEmpDtl["CONTACT_NAME"], drEmpDtl["UNIT_NAME"]);
                    }
                }
            }
        }
        #endregion

        #region First Load
        protected void InvolvmentLookUp_Load(object sender, EventArgs e)
        {
            this.FormMode = FormModes.None;
            this.gridInvolvmentControl.DataSource = this.dsEmpList.Tables[0];
        }
        #endregion

        #region Show LookUp Event
        public DialogResult ShowDialog(bool IsReadOnly)
        {
            this.IsReadOnly = true;
            return this.ShowDialog();
        }
        #endregion
    }
}