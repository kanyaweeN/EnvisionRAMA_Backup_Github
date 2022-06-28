using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.Common;

namespace Envision.NET.Forms.Orders
{
    public partial class frmRequestOnline : Envision.NET.Forms.Main.MasterForm
    {
        private string linkURL;
        public frmRequestOnline()
        {
            InitializeComponent();
        }
        private void frmRequestOnline_Load(object sender, EventArgs e)
        {
            loginPage();
            base.CloseWaitDialog();
        }
        private void loginPage()
        {
            GBLEnvVariable env = new GBLEnvVariable();

            try
            {
                linkURL = @"http://miracleonline/EnvisionOnline/Forms/Admin/frmManualParamterWinForm.aspx?UserLogin=" + env.UserUID + "&PasswordLogin=" + env.PasswordAD;

                Uri ur = new Uri(linkURL);
                //ur.
                this.webBrowser1.Url = ur;
            }
            catch { }
        }
        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loginPage();
        }
    }
}
