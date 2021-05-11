using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Envision.NET.Forms.Main;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmEnvisionPeerReviewWeb : MasterForm
    {
        public frmEnvisionPeerReviewWeb()
        {
            InitializeComponent();
        }

        private void frmEnvisionPeerReviewWeb_Load(object sender, EventArgs e)
        {
            //if (this.ISOpenwebOutside == "Y")
            //{
            //    Miracle.PACS.IECompatible ieCom = new Miracle.PACS.IECompatible();
            //    ieCom.OpenLink("http://miracleonline", this.ReportingSerivce_URL);
            //}
            //else
            //{
            //    Uri ur = new Uri(this.ReportingSerivce_URL);
            //    webBrowser1.Url = ur;
            //}
            base.CloseWaitDialog();

        }
    }
}