using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessRead;
namespace Envision.NET.Forms.ResultEntry.StructuredReport
{
    public partial class frmTemplateConfirm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int examId;
        private DataTable dtData;
        private GBLEnvVariable env;
        public int TEMPLATE_ID { get; set; }
        private MyMessageBox msg;
        public frmTemplateConfirm()
        {
            InitializeComponent();
            TEMPLATE_ID = 0;
            examId = 0;
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
        }
        public frmTemplateConfirm(int EXAM_ID)
        {
            InitializeComponent();
            TEMPLATE_ID = 0;
            examId = EXAM_ID;
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            initSelectTemplate();
        }
        private void frmTemplateConfirm_Load(object sender, EventArgs e)
        {
            if (cboTemplate.Items.Count > 1)
                cboTemplate.DroppedDown = true;
        }

        private void btnRunReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cboTemplate.SelectedValue == null)
                msg.ShowAlert("UID1404", env.CurrentLanguageID);
            else
            {
                TEMPLATE_ID = Convert.ToInt32(cboTemplate.SelectedValue.ToString());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void initSelectTemplate() {
            ProcessGetSRUserPreference proc = new ProcessGetSRUserPreference();
            proc.SR_USERPREFERENCE.EMP_ID = env.UserID;
            DataTable dttEmp = proc.GetByEmpId();
            if (Miracle.Util.Utilities.IsHaveData(dttEmp))
            {
                ProcessGetSRTemplate procTempalte = new ProcessGetSRTemplate();
                procTempalte.SR_TEMPLATE.EXAM_ID = examId;
                //DataView dv = new DataView(procTempalte.GetByExam());
                //dv.RowFilter = "CREATED_BY=" + env.UserID;
                //DataTable dtt = dv.ToTable();
                DataTable dtt = procTempalte.GetByExam();
                if (Miracle.Util.Utilities.IsHaveData(dtt))
                {
                    dtData = new DataTable();
                    dtData = dtt.Clone();
                    foreach (DataRow rowEmp in dttEmp.Rows) { 
                        foreach (DataRow rowHandle in dtt.Rows)
                        {
                            if (rowEmp["TEMPLATE_ID"].ToString() != rowHandle["TEMPLATE_ID"].ToString()) continue;
                            DataRow rowAdd = dtData.NewRow();
                            for (int i = 0; i < dtt.Columns.Count; i++) rowAdd[i] = rowHandle[i];
                            dtData.Rows.Add(rowAdd);
                            dtData.AcceptChanges();
                            break;
                        }
                    }
                }
                else
                {
                    dtData = new DataTable();
                    dtData = dtt.Clone();
                }
            }
            else {
                ProcessGetSRTemplate procTempalte = new ProcessGetSRTemplate();
                procTempalte.SR_TEMPLATE.EXAM_ID = -1;
                dtData = procTempalte.GetByExam();
            }
            cboTemplate.DisplayMember = "TEMPLATE_NAME";
            cboTemplate.ValueMember = "TEMPLATE_ID";
            cboTemplate.DataSource = dtData;
        }

        private void cboTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTemplate.SelectedIndex < 0) return;
            DataRow[] rows = dtData.Select("TEMPLATE_ID=" + cboTemplate.SelectedValue.ToString());
            if (rows.Length > 0) {
                txtExam.Text = rows[0]["EXAM_NAME"].ToString();
                txtDesc.Text = rows[0]["DESCRIPTION"].ToString();
                txtUser.Text = rows[0]["CREATOR"].ToString();
            }
        }
    }
}
