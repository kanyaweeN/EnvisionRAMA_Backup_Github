using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic;
namespace Envision.NET.Forms.Comment
{
    public partial class frmContactDialog : Form
    {
        private CommentManagement commentManager;
        private DataSet contactDataSet;
        private List<string> idList;
        
        public frmContactDialog()
        {
            InitializeComponent();
            this.commentManager = new CommentManagement();//CommentManagement.GetCommentManager();
            idList = null;
        }
        public frmContactDialog(List<string> ContactIds)
        {
            InitializeComponent();
            this.commentManager = new CommentManagement();//CommentManagement.GetCommentManager();
            idList = ContactIds;
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelect.Text == "Select All")
            {
                chkSelect.Text = "Unselect All";
                for (int i = 0; i < viewContact.DataRowCount; i++)
                {
                    DataRow row = viewContact.GetDataRow(i);
                    row["IS_SELECTED"] = "Y";
                }
            }
            else
            {
                chkSelect.Text = "Select All";
                for (int i = 0; i < viewContact.DataRowCount; i++)
                {
                    DataRow row = viewContact.GetDataRow(i);
                    row["IS_SELECTED"] = "N";
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void viewContact_DoubleClick(object sender, EventArgs e)
        {
            if (this.viewContact.FocusedRowHandle > -1)
            {
                DataRow dr = this.viewContact.GetDataRow(this.viewContact.FocusedRowHandle);
                if (dr["IS_SELECTED"].Equals("Y"))
                    dr["IS_SELECTED"] = null;
                else
                    dr["IS_SELECTED"] = "Y";
            }
        }

        private void setStartSelectContact()
        {
            if (this.contactDataSet == null)
                this.contactDataSet = this.commentManager.GetContactTo();
            if (this.contactDataSet.Tables.Count > 0)
                this.grdContact.DataSource = this.contactDataSet.Tables[0];
        }
        private void setStartSelectContact(List<string> ContactIds)
        {
            if (this.contactDataSet == null)
                this.contactDataSet = this.commentManager.GetContactTo();
            if (contactDataSet.Tables.Count > 0)
            {
                if (contactDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < contactDataSet.Tables[0].Rows.Count; i++)
                    {
                        if (ContactIds.Contains(contactDataSet.Tables[0].Rows[i]["CONTACT_ID"].ToString()))
                            contactDataSet.Tables[0].Rows[i]["IS_SELECTED"] = "Y";
                        this.grdContact.DataSource = this.contactDataSet.Tables[0];
                    }
                }
            }
        }
        public DataRow[] GetContactDataRow()
        {
            DataRow[] rows = this.contactDataSet.Tables[0].Select("[IS_SELECTED] = 'Y'");
            return rows;
        }

        private void frmContact_Load(object sender, EventArgs e)
        {
            if (idList == null)
                setStartSelectContact();
            else
                setStartSelectContact(idList);
        }

       
    }
}
