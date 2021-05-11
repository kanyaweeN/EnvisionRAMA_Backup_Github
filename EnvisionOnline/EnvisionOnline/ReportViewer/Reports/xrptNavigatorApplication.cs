using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace EnvisionOnline.ReportViewer.Reports
{
    public partial class xrptNavigatorApplication : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptNavigatorApplication()
        {
            InitializeComponent();
        }
        public xrptNavigatorApplication(string printor_name, DataTable dtEnv, DataTable dt)
        {
            InitializeComponent();

            dt.DefaultView.Sort = "INS_NAV DESC ,INS_NAV_PRM DESC ,INS_NAV_AIMC DESC";
            dt = dt.DefaultView.ToTable();
            DataSource = dt;

            ImageConverter convertor = new ImageConverter();
            Bitmap _image = new Bitmap((Image)convertor.ConvertFrom(dtEnv.Rows[0]["ORG_IMG"]), new Size(40, 40));
            this.pPicLogo.Image = _image;
            this.pHeader.Text = dtEnv.Rows[0]["ENV_ADDR"].ToString();

            this.pHN.DataBindings.Add("Text", DataSource, "HN");
            this.pHNBarcode.DataBindings.Add("Text", DataSource, "HN");
            this.pThaiName.DataBindings.Add("Text", DataSource, "PAT_THAI_NAME");
            this.pEngName.DataBindings.Add("Text", DataSource, "PAT_ENG_NAME");
            this.pAge.DataBindings.Add("Text", DataSource, "AGE");
            this.pClinic.DataBindings.Add("Text", DataSource, "CLINIC_TYPE_TEXT");
            this.pExam.DataBindings.Add("Text", DataSource, "EXAM_NAME");
            this.pRate.DataBindings.Add("Text", DataSource, "RATE");

            try
            {
                if (dt.Rows[0]["EXAM_TYPE_UID"].ToString() == "CT" || dt.Rows[0]["EXAM_TYPE_UID"].ToString() == "MRI")
                {
                    if (dt.Rows[0]["CLINIC_TYPE_ID"].ToString() == "6")
                    {
                        this.pNavigatorText.Rtf = dt.Rows[0]["INS_NAV_PRM"].ToString();
                    }
                    else if (dt.Rows[0]["CLINIC_TYPE_ID"].ToString() == "1")
                    {
                        this.pNavigatorText.Rtf = dt.Rows[0]["INS_NAV_AIMC"].ToString() != "" ? dt.Rows[0]["INS_NAV_AIMC"].ToString() : dt.Rows[0]["INS_NAV"].ToString();
                    }
                }
                else
                {
                    this.pNavigatorText.Rtf = dt.Rows[0]["INS_NAV"].ToString();
                }
            }
            catch
            {
                this.pNavigatorText.Rtf = dt.Rows[0]["INS_NAV"].ToString();
            }

            this.pScheduleBy.DataBindings.Add("Text", DataSource, "CREATED_BY");
            this.pScheduleDate.Text = Convert.ToDateTime(dt.Rows[0]["CREATED_ON"]).ToString("dd/MM/yyyy HH:mm");
            this.pPrintBy.Text = printor_name;
            this.pPrintDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
        public xrptNavigatorApplication(string printor_name, DataTable dtEnv, DataTable dt, String examUid)
        {
            InitializeComponent();

            dt.DefaultView.Sort = "INS_NAV DESC ,INS_NAV_PRM DESC ,INS_NAV_AIMC DESC";
            dt = dt.DefaultView.ToTable();
            DataSource = dt;

            DataRow[] dr = dt.Select("EXAM_UID = '" + examUid + "'");

            string examName = "";
            string strInsNav = "";

            if (dr.Length == 0)
            {
                dr[0] = dt.Rows[0];
            }
            else
            {
                examName = dr[0]["EXAM_NAME"].ToString();
                try
                {
                    if (dr[0]["EXAM_TYPE_UID"].ToString() == "CT" || dr[0]["EXAM_TYPE_UID"].ToString() == "MRI")
                    {
                        if (dr[0]["CLINIC_TYPE_ID"].ToString() == "6")
                        {
                            strInsNav = dr[0]["INS_NAV_PRM"].ToString();
                        }
                        else if (dr[0]["CLINIC_TYPE_ID"].ToString() == "1")
                        {
                            strInsNav = dr[0]["INS_NAV_AIMC"].ToString() != "" ? dr[0]["INS_NAV_AIMC"].ToString() : dr[0]["INS_NAV"].ToString();
                        }
                    }
                    else
                    {
                        strInsNav = dr[0]["INS_NAV"].ToString();
                    }
                }
                catch
                {
                    if (dt.Rows[0]["EXAM_TYPE_UID"].ToString() == "CT" || dt.Rows[0]["EXAM_TYPE_UID"].ToString() == "MRI")
                    {
                        if (dt.Rows[0]["CLINIC_TYPE_ID"].ToString() == "6")
                        {
                            strInsNav = dt.Rows[0]["INS_NAV_PRM"].ToString();
                        }
                        else if (dt.Rows[0]["CLINIC_TYPE_ID"].ToString() == "1")
                        {
                            strInsNav = dt.Rows[0]["INS_NAV_AIMC"].ToString() != "" ? dt.Rows[0]["INS_NAV_AIMC"].ToString() : dt.Rows[0]["INS_NAV"].ToString();
                        }
                    }
                    else
                    {
                        strInsNav = dt.Rows[0]["INS_NAV"].ToString();
                    }
                }
            }

            if (examName == "")
                examName = dt.Rows[0]["EXAM_NAME"].ToString();
            if (strInsNav == "")
                strInsNav = dt.Rows[0]["INS_NAV"].ToString();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dr[0]["EXAM_UID"].ToString() != dt.Rows[i]["EXAM_UID"].ToString())
                    if (strInsNav == dt.Rows[i]["INS_NAV"].ToString() ||
                        strInsNav == dt.Rows[i]["INS_NAV_PRM"].ToString() ||
                        strInsNav == dt.Rows[i]["INS_NAV_AIMC"].ToString())
                        examName += ", " + dt.Rows[i]["EXAM_NAME"].ToString();
            }

            ImageConverter convertor = new ImageConverter();
            Bitmap _image = new Bitmap((Image)convertor.ConvertFrom(dtEnv.Rows[0]["ORG_IMG"]), new Size(40, 40));
            this.pPicLogo.Image = _image;
            this.pHeader.Text = dtEnv.Rows[0]["ENV_ADDR"].ToString();

            this.pHN.DataBindings.Add("Text", DataSource, "HN");
            this.pHNBarcode.DataBindings.Add("Text", DataSource, "HN");
            this.pThaiName.DataBindings.Add("Text", DataSource, "PAT_THAI_NAME");
            this.pEngName.DataBindings.Add("Text", DataSource, "PAT_ENG_NAME");
            this.pAge.DataBindings.Add("Text", DataSource, "AGE");
            this.pClinic.DataBindings.Add("Text", DataSource, "CLINIC_TYPE_TEXT");
            this.pRate.DataBindings.Add("Text", DataSource, "RATE");
            this.pExam.Text = examName;
            this.pNavigatorText.Rtf = strInsNav;
            this.pScheduleBy.DataBindings.Add("Text", DataSource, "CREATED_BY");
            this.pScheduleDate.Text = Convert.ToDateTime(dt.Rows[0]["CREATED_ON"]).ToString("dd/MM/yyyy HH:mm");
            this.pPrintBy.Text = printor_name;
            this.pPrintDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
    }
}
