using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;
namespace Envision.NET.Forms.ResultEntry.StructuredReport
{
    public partial class QuesitonnairePreview : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DataSet dsData;
        int templateId;
        public QuesitonnairePreview()
        {
            InitializeComponent();
            dsData = null;
            templateId = 0;
        }
        public QuesitonnairePreview(int TemplateId)
        {
            InitializeComponent();
            dsData = null;
            templateId = TemplateId;
        }
        public QuesitonnairePreview(DataSet Data)
        {
            InitializeComponent();
            dsData = Data;
            templateId = 0;
        }

        private void QuesitonnairePreview_Load(object sender, EventArgs e)
        {
            if (templateId == 0)
            {
                //DataTable dtt1 = dsData.Tables[0];
                //DataTable dtt2 = dsData.Tables[1];
                //DataTable dtt3 = dsData.Tables[2];
                //DataTable dtt4 = dsData.Tables[3];
                //DataTable dtt5 = dsData.Tables[4];
                questionnaireGenerator1.GenerateQuestion(dsData, this.Width);
            }
            else
                questionnaireGenerator1.GenerateQuestion(templateId, this.Width);
        }
    }
}
