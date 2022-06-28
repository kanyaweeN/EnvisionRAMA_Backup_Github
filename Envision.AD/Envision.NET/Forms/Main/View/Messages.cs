﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;

using DevExpress.XtraGrid.Views.Grid.ViewInfo;
namespace Envision.NET.Forms.Main.View
{
    public partial class Messages : UserControl
    {
        public Messages()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void Messages_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = OutlookData.CreateDataTable();
            gridView1.SetRowExpanded(-1, true);
            gridView1.SetRowExpanded(-2, true);
        }

        private void gridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info == null) return;
            info.GroupText = info.GroupText.Replace("1 items", "1 item");
        }
    }
    public class OutlookData
    {
        public static Random rnd = new Random();
        internal static string[] users = new string[] {"Peter Dolan", "Ryan Fischer", "Richard Fisher", 
												 "Tom Hamlett", "Mark Hamilton", "Steve Lee", "Jimmy Lewis", "Jeffrey W McClain", 
												 "Andrew Miller", "Dave Murrel", "Bert Parkins", "Mike Roller", "Ray Shipman", 
												 "Paul Bailey", "Brad Barnes", "Carl Lucas", "Jerry Campbell"};
        static string[] subject = new string[] { "Integrating Developer Express MasterView control into an Accounting System.",
                                                "Web Edition: Data Entry Page. There is an issue with date validation.",
                                                "Payables Due Calculator is ready for testing.",
                                                "Web Edition: Search Page is ready for testing.",
                                                "Main Menu: Duplicate Items. Somebody has to review all menu items in the system.",
                                                "Receivables Calculator. Where can I find the complete specs?",
                                                "Ledger: Inconsistency. Please fix it.",
                                                "Receivables Printing module is ready for testing.",
                                                "Screen Redraw. Somebody has to look at it.",
                                                "Email System. What library are we going to use?",
                                                "Cannot add new vendor. This module doesn't work!",
                                                "History. Will we track sales history in our system?",
                                                "Main Menu: Add a File menu. File menu item is missing.",
                                                "Currency Mask. The current currency mask in completely unusable.",
                                                "Drag & Drop operations are not available in the scheduler module.",
                                                "Data Import. What database types will we support?",
                                                "Reports. The list of incomplete reports.",
                                                "Data Archiving. We still don't have this features in our application.",
                                                "Email Attachments. Is it possible to add multiple attachments? I haven't found a way to do this.",
                                                "Check Register. We are using different paths for different modules.",
                                                "Data Export. Our customers asked us for export to Microsoft Excel"};

        static int GetImportance(int num)
        {
            int ret = rnd.Next(num);
            if (ret > 2) ret = 1;
            return ret;
        }

        static int GetIcon()
        {
            int ret = rnd.Next(10);
            ret = ret > 2 ? 1 : 0;
            return ret;
        }

        static int GetAttach()
        {
            int ret = rnd.Next(10);
            ret = ret > 5 ? 1 : 0;
            return ret;
        }

        static DateTime GetSent()
        {
            DateTime ret = DateTime.Now;
            int r = rnd.Next(12);
            if (r > 1) ret = ret.AddDays(-rnd.Next(50));
            ret = ret.AddMinutes(-rnd.Next(ret.Minute + ret.Hour * 60 + 360));
            return ret;
        }

        static DateTime GetReceived(DateTime sent)
        {
            DateTime dt = sent.AddMinutes(10 + rnd.Next(120));
            if (dt > DateTime.Now) dt = DateTime.Now.AddMinutes(-1);
            return dt;
        }

        static string GetSubject()
        {
            return subject[rnd.Next(subject.Length - 1)];
        }

        public static string GetFrom()
        {
            return users[rnd.Next(users.Length - 2)];
        }

        static string GetTo()
        {
            return users[users.Length - 1];
        }

        static DateTime GetSentDate()
        {
            DateTime ret = DateTime.Today;
            int r = rnd.Next(12);
            if (r > 1) ret = ret.AddDays(-rnd.Next(50));
            return ret;
        }

        public static DateTime GetDueDate()
        {
            DateTime ret = DateTime.Today;
            ret = ret.AddDays(60 + rnd.Next(50));
            return ret;
        }

        static int GetSize(bool largeData)
        {
            return 1000 + (largeData ? 20 * rnd.Next(10000) : 30 * rnd.Next(100));
        }
        static bool GetHasAttachment()
        {
            return rnd.Next(10) > 5;
        }

        public static DataTable CreateDataTable()
        {
            return CreateDataTable(7);
        }
        public static object[] CreateMailRow(int num, bool realTime)
        {
            DateTime sent = GetSent();
            return new object[] { GetImportance(num), GetAttach(), realTime ? 0 : GetIcon(), GetIcon(), GetSubject(), GetFrom(), GetTo(), sent, realTime ? DateTime.Now : GetReceived(sent) };
        }
        public static DataTable CreateDataTable(int num)
        {
            DataTable tbl = new DataTable("Outlook");
            tbl.Columns.Add("Priority", typeof(int));
            tbl.Columns.Add("Attachment", typeof(int));
            tbl.Columns.Add("Read", typeof(int));
            tbl.Columns.Add("Flag", typeof(int));
            tbl.Columns.Add("Subject", typeof(string));
            tbl.Columns.Add("From", typeof(string));
            tbl.Columns.Add("To", typeof(string));
            tbl.Columns.Add("Sent", typeof(DateTime));
            tbl.Columns.Add("Received", typeof(DateTime));
            for (int i = 0; i < 80; i++)
            {
                tbl.Rows.Add(CreateMailRow(num, false));
            }
            return tbl;
        }
        public static DataTable CreateIssueList()
        {
            DataTable tbl = new DataTable();
            tbl = new DataTable("IssueList");
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("Subject", typeof(string));
            tbl.Columns.Add("Implemented", typeof(int));
            tbl.Columns.Add("Suspended", typeof(bool));
            for (int i = 1; i <= subject.Length; i++)
            {
                tbl.Rows.Add(new object[] { i, subject.GetValue(i - 1), rnd.Next(100), rnd.Next(10) > 8 });
            }
            return tbl;
        }

        //public static ServerSideGridTest CreateNewObject(UnitOfWork uow)
        //{
        //    ServerSideGridTest obj = new ServerSideGridTest(uow);
        //    obj.Subject = GetSubject();
        //    obj.From = GetFrom();
        //    obj.Sent = GetSentDate();
        //    obj.HasAttachment = GetHasAttachment();
        //    obj.Size = GetSize(obj.HasAttachment);
        //    return obj;
        //}
    }
    public class GroupIntervalData
    {
        public static Random rnd = new Random();
        static decimal GetCount()
        {
            return rnd.Next(50) + 10;
        }
        static DateTime GetDate(bool range)
        {
            DateTime ret = DateTime.Now;
            int r = rnd.Next(20);
            if (range)
            {
                if (r > 1) ret = ret.AddDays(rnd.Next(80) - 40);
                if (r > 18) ret = ret.AddMonths(rnd.Next(18));
            }
            else ret = ret.AddDays(rnd.Next(r * 30) - r * 15);
            return ret;
        }
        public static DataTable CreateDataTable(int maxRows)
        {
            return CreateDataTable(maxRows, true);
        }
        public static DataTable CreateDataTable(int maxRows, bool range)
        {
            DataTable tbl = null;
            string DBFileName = @"D:\DB\nwind.mdb";

            if (DBFileName != string.Empty)
            {
                DataSet ds = new DataSet();
                string tblName = "Products";


                string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName;
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " + tblName, con);
                oleDbDataAdapter.Fill(ds, tblName);

                DataTable product = ds.Tables[tblName];
                tbl = new DataTable("GroupInterval");
                tbl.Columns.Add("Product Name", typeof(string));
                tbl.Columns.Add("Category", typeof(int));
                tbl.Columns.Add("Unit Price", typeof(decimal));
                tbl.Columns.Add("Count", typeof(int));
                tbl.Columns.Add("Order Date", typeof(DateTime));
                tbl.Columns.Add("Order Sum", typeof(decimal), "[Unit Price] * [Count]");
                for (int i = 0; i < maxRows; i++)
                {
                    DataRow row = product.Rows[rnd.Next(product.Rows.Count - 1)];
                    tbl.Rows.Add(new object[] { row["ProductName"], row["CategoryID"], row["UnitPrice"], GetCount(), GetDate(range) });
                }
            }
            return tbl;
        }
    }
    public class MailData
    {
        DataRow row;
        public MailData(DataRow row)
        {
            this.row = row;
        }
        public DataRow Row { get { return row; } }
        public int Priority
        {
            get { return (int)row["Priority"]; }
            set { row["Priority"] = value; }
        }
        public int Attachment { get { return (int)row["Attachment"]; } }
        public int Read
        {
            get { return (int)row["Read"]; }
            set { row["Read"] = value; }
        }
        public int Flag
        {
            get { return (int)row["Flag"]; }
            set { row["Flag"] = value; }
        }
        public string Subject { get { return string.Format("{0}", row["Subject"]); } }
        public string From { get { return string.Format("{0}", row["From"]); } }
    }
    public class ColorsObject
    {
        Color fforeColor, fbackColor;
        public ColorsObject(Color fforeColor, Color fbackColor)
        {
            this.fforeColor = fforeColor;
            this.fbackColor = fbackColor;
        }
        public Color ForeColor { get { return fforeColor; } set { fforeColor = value; } }
        public Color BackColor { get { return fbackColor; } set { fbackColor = value; } }
    }
}
