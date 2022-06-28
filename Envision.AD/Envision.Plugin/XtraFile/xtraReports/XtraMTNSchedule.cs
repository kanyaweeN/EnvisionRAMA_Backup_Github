using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class XtraMTNSchedule : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraMTNSchedule(DataSet ds)
        {
            InitializeComponent();

            this.DataSource = ds;

            this.tbCellMTN_DT.DataBindings.Add("Text", ds, "MTN_DT", "");
            this.tbCellSTART_TIME.DataBindings.Add("Text", ds, "START_TIME", "");
            this.tbCellEND_TIME.DataBindings.Add("Text", ds, "END_TIME", "");
            this.tbCellMODALITY_UID.DataBindings.Add("Text", ds, "MODALITY_UID", "");
            this.tbCellMTN_SCH_STATUS_TEXT.DataBindings.Add("Text", ds, "MTN_SCH_STATUS_TEXT", "");
            this.tbCellMTN_COST.DataBindings.Add("Text", ds, "MTN_COST", "");
            this.tbCellRESPONSIBLE_PERSON_NAME.DataBindings.Add("Text", ds, "RESPONSIBLE_PERSON_NAME", "");
            this.tbCellCOMMENTS.DataBindings.Add("Text", ds, "COMMENTS", "");
            this.tbCellMTN_TYPE_UID.DataBindings.Add("Text", ds, "MTN_TYPE_UID", "");
        }

    }
}
