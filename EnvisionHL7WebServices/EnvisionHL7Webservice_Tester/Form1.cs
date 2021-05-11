using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EnvisionWebservice;
using EnvisionHL7WebService;

namespace EnvisionHL7Webservice_Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //SendToPACSORM();
            SendToPACSORU();
        }

        private void SendToPACSORM()
        {
            Patient pt = new Patient();
            List<OrderItems> orders = new List<OrderItems>();
            string createName = "RD-0101";

            //Patient Setup
            pt.HN = "4009812";
            pt.FirstName = "Moinul";
            pt.MiddleName = "";
            pt.LastName = "ABEDIN";
            pt.FirstNameEng = "Moinul";
            pt.MiddleNameEng = "";
            pt.LastNameEng = "ABEDIN";
            pt.DOB = new DateTime(1977, 12, 1, 0, 0, 0);
            pt.Gender = "M";
            pt.Phone = "";
            pt.Address = "";
            pt.DoctorName = "000075";
            pt.DepartmentName = "1OW";

            //OrderItem Setup
            orders.Add(new OrderItems());
            orders[0].ACCESSION_NO = "EMPTY1";

            orders[0].Flag = "NW";
            //orders[0].Flag = "CA";
            //orders[0].Flag = "XO";

            orders[0].Order_ID = 0;
            orders[0].ExamCode = "XX32";
            orders[0].ExamName = "Chest Abdomen";
            orders[0].Priority = "R";

            EnvisionHL7 hl7 = new EnvisionHL7();
            ReturnOperation op = hl7.SendMessageORM(pt, orders.ToArray(), createName);
            if (op.Type == "Complete")
                MessageBox.Show(op.Message, "Complete");
            else
            {
                MessageBox.Show(op.Message, "Error");
            }
        }

        private void SendToPACSORU()
        {
            Patient pt = new Patient();
            //List<ResultItems> results = new List<ResultItems>();
            ResultItems results = new ResultItems();
            string createName = "RD-0101";
            //--------------------------------------------------------------------------------------
            //            //Patient Setup
            //            pt.HN = "4009812";
            //            pt.FirstName = "Moinul";
            //            pt.MiddleName = "";
            //            pt.LastName = "ABEDIN";
            //            pt.FirstNameEng = "Moinul";
            //            pt.MiddleNameEng = "";
            //            pt.LastNameEng = "ABEDIN";
            //            pt.DOB = new DateTime(1977, 12, 1, 0, 0, 0);
            //            pt.Gender = "M";
            //            pt.Phone = "";
            //            pt.Address = "";
            //            pt.DoctorName = "000075";
            //            pt.DepartmentName = "1OW";

            //            //ResultItems Setup
            //            results.ACCESSION_NO = "EMPTY3";
            //            results.Order_ID = 0;
            //            results.ExamCode = "XX41";
            //            results.ExamName = "CHEST CHEST";
            //            results.Status = "F";
            //            results.ResultText = @"{\rtf1\ansi\ansicpg874\deff0\deflang1054{\fonttbl{\f0\fnil\fcharset0 Calibri;}}
            //{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\f0\fs22 RASDSADSAD\line DSADDSADSAD\line DSADSADSADSDSADSADSA\par
            //\tab sad];we p,k p [pdl[ pl [d dd  ds da asd saa\par
            //}
            // ";
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            //Patient Setup
            pt.HN = "7431";
            pt.FirstName = "Simpson";
            pt.MiddleName = "";
            pt.LastName = "Homer";
            pt.FirstNameEng = "Simpson";
            pt.MiddleNameEng = "";
            pt.LastNameEng = "Homer";
            pt.DOB = new DateTime(1955, 10, 5, 0, 0, 0);
            pt.Gender = "M";
            pt.Phone = "";
            pt.Address = "";
            pt.DoctorName = "test";
            //pt.DepartmentName = "1OW";
            pt.DepartmentName = "OER101:ทั่วไป";

            //ResultItems Setup
            results.ACCESSION_NO = "7417";
            results.Order_ID = 0;
            results.ExamCode = "XX41";
            results.ExamName = "CHEST CHEST";
            results.Status = "F";
            results.ResultText = @"{\rtf1\ansi\ansicpg874\deff0\deflang1054{\fonttbl{\f0\fnil\fcharset0 Calibri;}}
{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\f0\fs22 RASDSADSAD\line DSADDSADSAD\line DSADSADSADSDSADSADSA\par
\tab sad];we p,k p [pdl[ pl [d dd  ds da asd saa\par
}
 ";
            //--------------------------------------------------------------------------------------

            EnvisionHL7 hl7 = new EnvisionHL7();
            ReturnOperation op = hl7.SendMessageORU(pt, results, createName);
            if (op.Type == "Complete")
                MessageBox.Show(op.Message, "Complete");
            else
            {
                MessageBox.Show(op.Message, "Error");
            }

        }

        private void SendORMMessage()
        {
            string accession_no = "1205271OWXA001";

            EnvisionHL7 hl7 = new EnvisionHL7();
            hl7
        }
    }
}
