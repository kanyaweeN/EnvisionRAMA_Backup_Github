using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmPopupRadstudyGroup : Envision.NET.Forms.Main.MasterForm// Form
    {
        private string _type;
        private MyMessageBox msg;
        ProcessAddRISRadstudygroup prc;
        public frmPopupRadstudyGroup()
        {
            InitializeComponent();
        }
        public frmPopupRadstudyGroup(int _RADIOLOGIST_ID, string _ACCESSION_NO, bool _IS_FAVOURITE, bool _IS_TEACHING, bool _IS_OTHERS, string _Type,string _EXAM_NAME)
        {
            InitializeComponent();
            prc = new ProcessAddRISRadstudygroup();
            prc.RIS_RADSTUDYGROUP = new RIS_RADSTUDYGROUP();
            prc.RIS_RADSTUDYGROUP.RADIOLOGIST_ID = _RADIOLOGIST_ID;
            prc.RIS_RADSTUDYGROUP.ACCESSION_NO = _ACCESSION_NO;
            prc.RIS_RADSTUDYGROUP.IS_FAVOURITE = _IS_FAVOURITE;
            prc.RIS_RADSTUDYGROUP.IS_TEACHING = _IS_TEACHING;
            prc.RIS_RADSTUDYGROUP.IS_OTHERS = _IS_OTHERS;
            _type = _Type;

            txtStudy.Text = _EXAM_NAME;
        }
        private void frmPopupRadstudyGroup_Load(object sender, EventArgs e)
        {
            cmbLevel.SelectedIndex = 0;
            if (_type == "F")
            {
                lbType.Text = "Add Favorites";
                this.Text = "Add Favorites";
            }
            else
            {
                lbType.Text = "Add Teaching";
                this.Text = "Add Teaching";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                prc.RIS_RADSTUDYGROUP.Tags = txtTag.Text;
                prc.RIS_RADSTUDYGROUP.Level = Convert.ToInt32(cmbLevel.SelectedIndex + 1).ToString();
                prc.RIS_RADSTUDYGROUP.CPT_code = txtCPT.Tag == null ? null : txtCPT.Tag.ToString();
                prc.RIS_RADSTUDYGROUP.ACR_Code = txtACR.Tag == null ? null : txtACR.Tag.ToString();
                prc.RIS_RADSTUDYGROUP.ICD_Code = txtICD.Tag == null ? null : txtICD.Tag.ToString();

                prc.Invoke(_type);
                this.DialogResult = DialogResult.OK;
                this.Close();
        }

        private void btnCPT_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(find_CPTCode);
            lv.AddColumn("CPT_ID", "CPT ID", false, true);
            lv.AddColumn("CPT_UID", "CPT Code", true, true);
            lv.AddColumn("CPT_DESC", "CPT Description", true, true);

            lv.Text = "CPT Search";

            lv.Data = lvS.SelectACR_CPT_ICD().Tables[1];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_CPTCode(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            string s = txtCPT.Tag == null ? string.Empty : txtCPT.Tag.ToString();
            if (retValue[0] != s)
            {
                txtCPT.Tag = retValue[1];
                txtCPT.Text = retValue[1] + ":" + retValue[2];
            }
        }
        private void btnICD_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(find_ICDCode);
            lv.AddColumn("ICD_ID", "ICD ID", false, true);
            lv.AddColumn("ICD_UID", "ICD Code", true, true);
            lv.AddColumn("ICD_DESC", "ICD Description", true, true);

            lv.Text = "ICD Search";

            lv.Data = lvS.SelectACR_CPT_ICD().Tables[2];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_ICDCode(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            string s = txtICD.Tag == null ? string.Empty : txtICD.Tag.ToString();
            if (retValue[0] != s)
            {
                txtICD.Tag = retValue[1];
                txtICD.Text = retValue[1] + ":" + retValue[2];
            }
        }
        private void btnACR_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(find_ACRCode);
            lv.AddColumn("ACR_ID", "ACR ID", false, true);
            lv.AddColumn("ACR_UID", "ACR Code", true, true);
            lv.AddColumn("ACR_DESC", "ACR Description", true, true);

            lv.Text = "ACR Search";

            lv.Data = lvS.SelectACR_CPT_ICD().Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_ACRCode(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            string s = txtACR.Tag == null ? string.Empty : txtACR.Tag.ToString();
            if (retValue[0] != s)
            {
                txtACR.Tag = retValue[1];
                txtACR.Text = retValue[1] + ":" + retValue[2];
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
