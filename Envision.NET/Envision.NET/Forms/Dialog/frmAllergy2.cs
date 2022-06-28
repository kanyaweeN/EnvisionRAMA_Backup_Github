using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic;

namespace Envision.NET.Forms.Dialog
{
    public partial class frmAllergy2 : Form
    {
        private HIS_Patient _hisPatientWebService;
        private DevExpress.Utils.WaitDialogForm waitDialog;

        string hn = string.Empty;

        public frmAllergy2()
        {
            InitializeComponent();
        }
        public frmAllergy2(string _hn)
        {
            InitializeComponent();

            hn = _hn;
        }

        private void frmAllergy2_Load(object sender, EventArgs e)
        {
            gridAllergyControl.BackColor = Color.Transparent;  
            this._hisPatientWebService = new HIS_Patient();

            if (!string.IsNullOrEmpty(hn))
                LoadAllergyData();
            else
                ResetAllergyData();
        }
        private void LoadAllergyData()
        {
            this.ShowLoadingDialog("Loading...", 150, 50);
            try
            {
                DataSet ds = this._hisPatientWebService.Get_Adr(hn.Trim());
                if (ds.Tables.Count > 0)
                {
                    this.gridAllergyControl.DataSource = ds.Tables[0];
                }
                this.waitDialog.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                //MessageBox.Show(ex.Message);
#endif

                this.ResetAllergyData();
                this.waitDialog.Close();
            }
        }
        private void ResetAllergyData()
        {
            this.gridAllergyControl.DataSource = null;
        }
        private void ShowLoadingDialog(string message, int width, int height)
        {
            this.waitDialog = new DevExpress.Utils.WaitDialogForm(message, "Dialog", new Size(width, height));
        }
    }
}