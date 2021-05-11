using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Envision.NET.Forms.Dialog
{
    public partial class frmOpenWebsite : Form
    {
        private string urlLink;
        public frmOpenWebsite(string url)
        {
            InitializeComponent();
            this.urlLink = url;
        }

        private void frmOpenWebsite_Load(object sender, EventArgs e)
        {
            Uri ur = new Uri(this.urlLink);
            webBrowser1.Url = ur;
        }
    }
}
