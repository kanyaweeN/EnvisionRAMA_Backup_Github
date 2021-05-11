using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Envision.Plugin.XtrFile.xtrReports
{
    public partial class XtraRiskDetailSubReport : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraRiskDetailSubReport()
        {
            InitializeComponent();
            this.txtSubject.DataBindings.Add("Text", DataSource, "INCIDENT_SUBJ");
            this.txtRiskCategory.DataBindings.Add("Text", DataSource, "CAT_NAME");
            this.txtPriority.DataBindings.Add("Text", DataSource, "PRIORITY");
            this.txtIncident.DataBindings.Add("Text", DataSource, "INCIDENT_DESC");
            this.txtIncidentDateTime.DataBindings.Add("Text", DataSource, "INCIDENT_DT");
            this.txtInvolvement.DataBindings.Add("Text", DataSource, "INVOLVEMENT");
        }

    }
}
