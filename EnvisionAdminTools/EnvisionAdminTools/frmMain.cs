using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EnvisionAdminTools.HIS;
using System.Deployment.Application;
using System.Reflection;
using System.Net.NetworkInformation;
namespace EnvisionAdminTools
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Office 2007 Blue");
        }

        private void barCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCheckWebService frm = new frmCheckWebService();
            int i = 0;
            bool flag = true;
            for(;i<xtraTabbedMdiManager1.Pages.Count;i++)
                if (xtraTabbedMdiManager1.Pages[i].Text == frm.Text) {
                    xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[i];
                    flag = false;
                    break;
                }
            if (flag)
            {
                frm.MdiParent = this;
                frm.Show();
            }
            
               
        }
        private void barLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmCheckWebService frm = new frmCheckWebService();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //createShortCut();

            frmCheckWebService frm = new frmCheckWebService();
            frm.MdiParent = this;
            frm.Show();
        }

        private void createShortCut()
        {
            if (!ApplicationDeployment.IsNetworkDeployed) return;
            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            Assembly code = Assembly.GetExecutingAssembly();
            string company = string.Empty;
            string description = string.Empty;
            if (Attribute.IsDefined(code, typeof(AssemblyCompanyAttribute)))
            {
                AssemblyCompanyAttribute ascompany = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(code, typeof(AssemblyCompanyAttribute));
                company = Application.CompanyName;
                //MessageBox.Show("TEST:" + company);
            }
            if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
            {
                AssemblyDescriptionAttribute asdescription = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code, typeof(AssemblyDescriptionAttribute));
                description = asdescription.Description;
                //MessageBox.Show("TEST:" + description);
            }
            if (company != string.Empty && description != string.Empty)
            {
                string desktopPath = string.Empty;
                desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\\", description, ".appref-ms");
                string shortcutName = string.Empty;
                shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "\\", company, "\\", description, ".appref-ms");
                System.IO.File.Copy(shortcutName, desktopPath, true);
            }
        }

    }
}