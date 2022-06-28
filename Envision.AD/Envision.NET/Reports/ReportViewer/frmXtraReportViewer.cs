using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Envision.NET.Reports.ReportViewer
{
    public partial class frmXtraReportViewer : DevExpress.XtraEditors.XtraForm
    {
        public string reportURL;
        public frmXtraReportViewer()
        {
            InitializeComponent();
        }
        public frmXtraReportViewer(string url)
        {
            InitializeComponent();
            reportURL = url;
        }
        private void frmXtraReportViewer_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    Uri ur = new Uri(reportURL);
            //    //ur.
            //    this.webBrowser1.Url = ur;
            //}
            //catch { }


            Navigate(reportURL);

        }
        private void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser1.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (HasHorizontalScrollbar)
            {
                webBrowser1.Size = new Size(webBrowser1.Document.Body.ScrollRectangle.Width, webBrowser1.Document.Body.ScrollRectangle.Height);
                frmXtraReportViewer.ActiveForm.Size = new Size(webBrowser1.Document.Body.ScrollRectangle.Width, webBrowser1.Document.Body.ScrollRectangle.Height);
            }
        }

        public bool HasHorizontalScrollbar
        {
            get
            {
                var width1 = webBrowser1.Document.Body.ScrollRectangle.Width;
                var width2 = webBrowser1.Document.Window.Size.Width;

                return width1 > width2;
            }
        }
    }
}