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
    public partial class ContactLookUp : Form
    {
        public delegate void onContactLookUpClose(object sender, DataRow[] selectedContactDataRow);
        public event onContactLookUpClose OnContactLookUpClose;
        private static ContactLookUp _contactLookUp;
        private CommentManagement commentManager;
        private DataSet contactDataSet;
        public ContactLookUp()
        {
            InitializeComponent();
            this.commentManager = CommentManagement.GetCommentManager();
            this.btnClose.Click += new EventHandler(btnClose_Click);
            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.viewContact.DoubleClick += new EventHandler(gridView1_DoubleClick);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
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
        public void SetStartSelectContact()
        {
            if(this.contactDataSet == null)
                this.contactDataSet = this.commentManager.GetContactTo();
            if(this.contactDataSet.Tables.Count > 0)
                this.grdContact.DataSource = this.contactDataSet.Tables[0];
        }
        public void SetStartSelectContact(List<string> ContactIds)
        {
            if(this.contactDataSet == null)
                this.contactDataSet = this.commentManager.GetContactTo();
            if (contactDataSet.Tables.Count > 0)
            {
                if (contactDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < contactDataSet.Tables[0].Rows.Count ; i++)
                    {
                        if(ContactIds.Contains(contactDataSet.Tables[0].Rows[i]["CONTACT_ID"].ToString()))
                            contactDataSet.Tables[0].Rows[i]["IS_SELECTED"] = "Y";
                        this.grdContact.DataSource = this.contactDataSet.Tables[0];
                    }
                }
            }
        }

        #region Button Event
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            DataRow[] rows = this.contactDataSet.Tables[0].Select("[IS_SELECTED] = 'Y'");
            if (this.OnContactLookUpClose != null)
                this.OnContactLookUpClose(this, rows);
            this.Close();
        }
        #endregion

        #region Overidde Method
        protected override void OnShown(EventArgs e)
        {
            this.SetStartSelectContact();
            base.OnShown(e);
        }
        protected override void OnClosed(EventArgs e)
        {
            this.viewContact.ClearColumnsFilter();
            base.OnClosed(e);
        }
        #endregion

        public static ContactLookUp GetContactLookUp()
        {
            if (_contactLookUp == null)
                _contactLookUp = new ContactLookUp();
            return _contactLookUp;
        }

        public DataRow[] GetContactDataRow(string contactIds)
        {
            if (this.contactDataSet == null)
                this.contactDataSet = this.commentManager.GetContactTo();
            if (this.contactDataSet.Tables.Count > 0 && contactIds != string.Empty)
                return this.contactDataSet.Tables[0].Select("[CONTACT_ID] IN ("+ contactIds  +")");
            else
                return null;
        }

        public void ClearSelectedRows()
        {
            if (this.contactDataSet != null)
            {
                if (this.contactDataSet.Tables.Count > 0)
                {
                    DataRow[] selectedRows = this.contactDataSet.Tables[0].Select("[IS_SELECTED] = 'Y'");
                    foreach (DataRow dr in selectedRows)
                        dr["IS_SELECTED"] = "N";
                }
            }
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
            else {
                chkSelect.Text = "Select All";
                for (int i = 0; i < viewContact.DataRowCount; i++)
                {
                    DataRow row = viewContact.GetDataRow(i);
                    row["IS_SELECTED"] = "N";
                }
            }
        }
    }
}
