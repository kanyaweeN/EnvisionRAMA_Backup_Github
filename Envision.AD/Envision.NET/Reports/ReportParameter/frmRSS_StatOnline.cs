using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using System.Threading;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class frmRSS_StatOnline : Envision.NET.Forms.Main.MasterForm
    {
        public frmRSS_StatOnline()
        {
            InitializeComponent();
        }

        private void frmRSS_StatOnline_Load(object sender, EventArgs e)
        {
            LoadControl();
            this.CloseWaitDialog();
        }

        private void LoadControl()
        {
            txtType.Items.Clear();
            txtType.Items.Add("Summary");
            txtType.Items.Add("Department");
            txtType.Items.Add("Clinic Type");
            txtType.Items.Add("Unit Name");
            txtType.SelectedIndex = 0;

            txtTypeSch.Items.Clear();
            txtTypeSch.Items.Add("Summary");
            txtTypeSch.Items.Add("Department");
            txtTypeSch.Items.Add("Clinic Type");
            txtTypeSch.Items.Add("Unit Name");
            txtTypeSch.SelectedIndex = 0;

            cmbReportType.Items.Clear();
            cmbReportType.Items.Add("Daily");
            cmbReportType.Items.Add("Monthly");
            cmbReportType.SelectedIndex = 0;

            cmbReportTypeSch.Items.Clear();
            cmbReportTypeSch.Items.Add("Daily");
            cmbReportTypeSch.Items.Add("Monthly");
            cmbReportTypeSch.SelectedIndex = 0;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        
            
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
           
            DateTime fdate1, tdate1;

                if (cmbReportType.Text == "Monthly")
                {
                    fdate1 = new DateTime(txtDateFrom.Value.Year, txtDateFrom.Value.Month, 1, 0, 0, 0);
                   tdate1 = new DateTime(txtDateTo.Value.Year, txtDateTo.Value.Month, 1, 0, 0, 0);
                }
                else  // --- Daily
                {
                     fdate1 = new DateTime(txtDateFrom.Value.Year, txtDateFrom.Value.Month, txtDateFrom.Value.Day, 0, 0, 0);
                     tdate1 = new DateTime(txtDateTo.Value.Year, txtDateTo.Value.Month, txtDateTo.Value.Day, 23, 59, 59);
                  
                }
        
            ProcessGetRSS_StatOnline objParameter = new ProcessGetRSS_StatOnline();
            objParameter.GetFromDate = fdate1.ToString("yyyy-MM-dd HH:mm:ss");
            objParameter.GetToDate = tdate1.ToString("yyyy-MM-dd HH:mm:ss");
            objParameter.GetGroupType = txtType.Text;
            objParameter.GetDurationType = cmbReportType.Text;
            objParameter.GetReportType = "RSS_StatOnlineRequestXray";

            RSS_StatOnline frm = new RSS_StatOnline();
            frm.Show();

        }

        private void btnCancleSch_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRunReportSch_Click(object sender, EventArgs e)
        {
            DateTime fdate1, tdate1;  
            if (cmbReportTypeSch.Text == "Monthly")
                {
                     fdate1 = new DateTime(txtDateFromSch.Value.Year, txtDateFromSch.Value.Month, 1, 0, 0, 0);
                     tdate1 = new DateTime(txtDateToSch.Value.Year, txtDateToSch.Value.Month, 1, 0, 0, 0);

                }
                else  // --- Daily
                {
                     fdate1 = new DateTime(txtDateFromSch.Value.Year, txtDateFromSch.Value.Month, txtDateFromSch.Value.Day, 0, 0, 0);
                     tdate1 = new DateTime(txtDateToSch.Value.Year, txtDateToSch.Value.Month, txtDateToSch.Value.Day, 23, 59, 59);

            }
          
            ProcessGetRSS_StatOnline objParameter = new ProcessGetRSS_StatOnline();
            objParameter.GetFromDate = fdate1.ToString("yyyy-MM-dd HH:mm:ss");
            objParameter.GetToDate = tdate1.ToString("yyyy-MM-dd HH:mm:ss");
            objParameter.GetGroupType = txtTypeSch.Text;
            objParameter.GetDurationType = cmbReportTypeSch.Text;
            objParameter.GetReportType = "RSS_StatOnlineSchedule";

            RSS_StatOnline frm = new RSS_StatOnline();
            frm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRunReportWL_Click(object sender, EventArgs e)
        {
            DateTime fdate1, tdate1;
             fdate1 = new DateTime(txtDateFromWL.Value.Year, txtDateFromWL.Value.Month, txtDateFromWL.Value.Day, 0, 0, 0);
             tdate1 = new DateTime(txtDateToWL.Value.Year, txtDateToWL.Value.Month, txtDateToWL.Value.Day, 23, 59, 59);


            ProcessGetRSS_StatOnline objParameter = new ProcessGetRSS_StatOnline();
            objParameter.GetFromDate = fdate1.ToString("yyyy-MM-dd HH:mm:ss");
            objParameter.GetToDate = tdate1.ToString("yyyy-MM-dd HH:mm:ss");
            objParameter.GetGroupType = "";
            objParameter.GetReportType = "RSS_StatOnlineScheduleWaitingList";

            RSS_StatOnline frm = new RSS_StatOnline();
            frm.Show();
        }

        private void btnCancleWL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDateTXT(txtDateFrom, txtDateTo, cmbReportType);

            //// ==== Monthly ====
            //if (cmbReportType.SelectedIndex == 1)
            //{
            //    txtDateFrom.Format = DateTimePickerFormat.Custom;
            //    txtDateFrom.CustomFormat = "MMMM/yyyy";
            // //   textBox3.Text = Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames[dateTimePicker1.Value.Month - 1];
            //  txtDateFrom.ShowUpDown = true;
            //   //txtDateFrom.Value.Year();
            //    txtDateTo.Enabled = false;
            //}
            //else
            //{
            //    txtDateFrom.Format = DateTimePickerFormat.Long;
            //    txtDateTo.Enabled = true;
            //    txtDateFrom.ShowUpDown = false;
            //}


        }

        private void cmbReportTypeSch_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDateTXT(txtDateFromSch, txtDateToSch, cmbReportTypeSch);
        }

        private void setDateTXT(DateTimePicker fromDT, DateTimePicker toDT, ComboBox cmbReportDuration)
        {
            // ==== Monthly ====
            if (cmbReportDuration.Text == "Monthly")
            {
                fromDT.Format = DateTimePickerFormat.Custom;
                fromDT.CustomFormat = "MMMM/yyyy";
                //   textBox3.Text = Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames[dateTimePicker1.Value.Month - 1];
                fromDT.ShowUpDown = true;
                //txtDateFrom.Value.Year();
                toDT.Enabled = false;
            }
            else
            {
                fromDT.Format = DateTimePickerFormat.Long;
                toDT.Enabled = true;
                fromDT.ShowUpDown = false;
            }
        }


        // ============== Direct Print 

        private void btnDirectPrint_Click(object sender, EventArgs e)
        {

           
        }

//        private int m_currentPageIndex;
//    private IList<Stream> m_streams;

//        private void Run()
//        {
//            LocalReport report = new LocalReport();
//            report.ReportPath = @"..\..\Report.rdlc";
//            report.DataSources.Add(
//               new ReportDataSource("Sales", LoadSalesData()));
//            Export(report);
//            Print();
//        }

//       private void PrintPage(object sender, PrintPageEventArgs ev)
//    {
//        Metafile pageImage = new
//           Metafile(m_streams[m_currentPageIndex]);

//        // Adjust rectangular area with printer margins.
//        Rectangle adjustedRect = new Rectangle(
//            ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
//            ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
//            ev.PageBounds.Width,
//            ev.PageBounds.Height);

//        // Draw a white background for the report
//        ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

//        // Draw the report content
//        ev.Graphics.DrawImage(pageImage, adjustedRect);

//        // Prepare for the next page. Make sure we haven't hit the end.
//        m_currentPageIndex++;
//        ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
//    }

//       private void Print()
//       {
//           if (m_streams == null || m_streams.Count == 0)
//               throw new Exception("Error: no stream to print.");
//           PrintDocument printDoc = new PrintDocument();
//           if (!printDoc.PrinterSettings.IsValid)
//           {
//               throw new Exception("Error: cannot find the default printer.");
//           }
//           else
//           {
//               printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
//               m_currentPageIndex = 0;
//               printDoc.Print();
//           }
//       }
//  // Export the given report as an EMF (Enhanced Metafile) file.
//    private void Export(LocalReport report)
//    {
//        string deviceInfo =
//          @"<DeviceInfo>
//                <OutputFormat>EMF</OutputFormat>
//                <PageWidth>8.5in</PageWidth>
//                <PageHeight>11in</PageHeight>
//                <MarginTop>0.25in</MarginTop>
//                <MarginLeft>0.25in</MarginLeft>
//                <MarginRight>0.25in</MarginRight>
//                <MarginBottom>0.25in</MarginBottom>
//            </DeviceInfo>";
//        Warning[] warnings;
//        m_streams = new List<Stream>();
//        report.Render("Image", deviceInfo, CreateStream,
//           out warnings);
//        foreach (Stream stream in m_streams)
//            stream.Position = 0;
//    }
// // Routine to provide to the report renderer, in order to
//    //    save an image for each page of the report.
//    private Stream CreateStream(string name,
//      string fileNameExtension, Encoding encoding,
//      string mimeType, bool willSeek)
//    {
//        Stream stream = new MemoryStream();
//        m_streams.Add(stream);
//        return stream;
//    }

// ---===========================

    }
}
