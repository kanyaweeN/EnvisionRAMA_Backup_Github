using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;

namespace Envision.NET.Risk
{
    public partial class EmployeeListLookUp : Form
    {
        private DataSet dsEmpList;
        public DataRow[] ResultRows { get; set; }
        public EmployeeListLookUp()
        {
            InitializeComponent();
            this.Load += new EventHandler(EmployeeListLookUp_Load);
            this.advBandedGridView1.DoubleClick += new EventHandler(gridInvolvmentView_DoubleClick);
            this.repositoryItemCheckEdit1.CheckedChanged += new EventHandler(repositoryItemCheckEdit1_CheckedChanged);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            this.btnOK.Click += new EventHandler(btnOK_Click);
        }
        public DialogResult ShowDialog(DataSet dsInvolvmentList)
        {
            if (dsInvolvmentList != null)
            {
                if (dsInvolvmentList.Tables.Count > 0)
                {
                    if (this.dsEmpList == null)
                    {
                        ProcessGetComment processorGetEmpList = new ProcessGetComment();
                        processorGetEmpList.InvokeMode = ProcessGetComment.InvokModes.GetContact;
                        processorGetEmpList.ORG_ID = 1;
                        processorGetEmpList.Invoke();
                        this.dsEmpList = processorGetEmpList.Result;
                    }
                    //Clear old selected
                    DataRow[] drRows = this.dsEmpList.Tables[0].Select("IS_SELECTED = 'Y'");
                    foreach (DataRow dr in drRows)
                    {
                        dr["IS_SELECTED"] = "N";
                    }
                    //add new selected
                    foreach (DataRow drInvolvment in dsInvolvmentList.Tables[0].Rows)
                    {
                        DataRow[] drRow = this.dsEmpList.Tables[0].Select("CONTACT_UID = '" + drInvolvment["EMP_UID"].ToString() + "'");
                        if(drRow.Length > 0)
                            drRow[0]["IS_SELECTED"] = "Y";
                    }
                }
            }
            return this.ShowDialog();
        }

        #region OK Click
        protected void btnOK_Click(object sender, EventArgs e)
        {
            this.ResultRows = this.dsEmpList.Tables[0].Select("IS_SELECTED = 'Y'");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region Cancel Click
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Check box Click
        protected void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.advBandedGridView1.FocusedRowHandle > -1)
            {
                DataRow drSelectedRow = this.advBandedGridView1.GetDataRow(this.advBandedGridView1.FocusedRowHandle);
                if (drSelectedRow["IS_SELECTED"].Equals("N"))
                    drSelectedRow["IS_SELECTED"] = "Y";
                else
                    drSelectedRow["IS_SELECTED"] = "N";
            }
        }
        #endregion

        #region Row Double Click
        protected void gridInvolvmentView_DoubleClick(object sender, EventArgs e)
        {
            if (this.advBandedGridView1.FocusedRowHandle > -1)
            {
                this.ResultRows = new DataRow[1];
                this.ResultRows[0] = this.advBandedGridView1.GetDataRow(this.advBandedGridView1.FocusedRowHandle);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region First Load
        protected void EmployeeListLookUp_Load(object sender, EventArgs e)
        {
            if (this.dsEmpList == null)
            {
                ProcessGetComment processorGetEmpList = new ProcessGetComment();
                processorGetEmpList.InvokeMode = ProcessGetComment.InvokModes.GetContact;
                processorGetEmpList.ORG_ID = 1;
                processorGetEmpList.Invoke();
                this.dsEmpList = processorGetEmpList.Result;
            }
            this.gridInvolvmentControl.DataSource = this.dsEmpList.Tables[0];
        }
        #endregion
    }
}
