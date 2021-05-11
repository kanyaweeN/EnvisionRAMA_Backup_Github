using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.BusinessLogic;
using RIS.DataAccess;
using RIS.Common;
using RIS.Forms.Lookup;
using RIS.Common.Common;
using RIS.Forms.GBLMessage;
using System.Globalization;

namespace RIS.Forms.ResultEntry
{
    public partial class History : Form
    {
        string hnno = "";
        public History(string hn)
        {
            hnno = hn;
            InitializeComponent();
            Histories();
            ultraFormattedTextEditor1.ReadOnly = true;
            GridEditable();
        }
        #region History
        public void Histories()
        {


            GBLEnvVariable env = new GBLEnvVariable();
            int org = env.OrgID;
            
            CultureInfo culture = new CultureInfo("en-US", true);
            DateTime dt = Convert.ToDateTime(dateTimePicker1.Value, culture);
            DateTime dt2 = Convert.ToDateTime(dateTimePicker2.Value, culture);

            ResultEntryWorkList wl = new ResultEntryWorkList();
            wl.SpType = 1;
            wl.FromDate = dt;
            wl.ToDate = dt2;
            wl.OrgID = org;
            wl.PatientID = hnno;
            ProcessGetHistory lkp = new ProcessGetHistory();
            lkp.ResultEntryWorkList = wl;
            lkp.Invoke();

            this.UltraGrid1.Refresh();
            this.UltraGrid1.Text = "";
            this.UltraGrid1.DataSource = lkp.ResultSet.Tables[0];
            GridEditable();
            
        }
        #endregion History

        #region GridEditableFalse
        public void GridEditable()
        {
            for (int i = 0; i < 8; i++)
            {
                this.UltraGrid1.DisplayLayout.Bands[0].Columns[i].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            Histories();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            Histories();
        }

        private void UltraGrid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            string finalresult = "";
            
            string _accno=UltraGrid1.Rows[e.Row.Index].Cells[2].Value.ToString().Trim();
            string qry = "select NOTE_TEXT FROM RIS_EXAMRESULTNOTE WHERE ACCESSION_NO='" + _accno + "' ORDER BY NOTE_NO DESC";
            ProcessGetGBLLookup alkp = new ProcessGetGBLLookup(qry);
            alkp.Invoke();
            DataTable dt2 = alkp.ResultSet.Tables[0];
            int i=0;
            while (i < dt2.Rows.Count)
            {
                string txts = dt2.Rows[i]["NOTE_TEXT"].ToString().Trim();
                finalresult = finalresult + txts + "<br/><br/>..................<br/>";
                i++;
            }
            ultraFormattedTextEditor1.Value = finalresult + UltraGrid1.Rows[e.Row.Index].Cells[7].Value.ToString().Trim();

        }


    }
}