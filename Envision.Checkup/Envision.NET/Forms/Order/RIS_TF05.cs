using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.BusinessLogic;
using RIS.Common;
using RIS.Common.Common;
using System.Globalization;
using RIS.Forms.GBLMessage;

namespace RIS.Forms.Order
{
    public partial class RIS_TF05 : Form
    {
        private MyMessageBox msg;
        private GBLEnvVariable env;
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public RIS_TF05(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            Populate(1);
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            GridEditable();
        }
        #region GridEditableFalse
        public void GridEditable()
        {
            for (int i = 0; i < 8; i++)
            {
                this.UltraGrid1.DisplayLayout.Bands[0].Columns[i].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

        }
        #endregion

        #region Radiologist
        public void Radiologist()
        {
            try
            {
                string qry2 = "select ([fname]+' '+ [lname]) AS RADIOLOGIST,EMP_ID from hr_emp where JOB_TYPE='D' AND IS_RADIOLOGIST='Y' AND ISNULL(SUPPORT_USER,'N') <> 'Y'";
                ProcessGetGBLLookup lkp3 = new ProcessGetGBLLookup(qry2);
                lkp3.Invoke();
                DataTable dt3 = lkp3.ResultSet.Tables[0];

                if (this.UltraGrid1.DisplayLayout.ValueLists.Exists("Radiologist"))
                    return;


                Infragistics.Win.ValueListsCollection lists = this.UltraGrid1.DisplayLayout.ValueLists;
                Infragistics.Win.ValueList vl = lists.Add("Radiologist");

                int i = 0;
                while (i < dt3.Rows.Count)
                {
                    vl.ValueListItems.Add(dt3.Rows[i]["EMP_ID"].ToString(), dt3.Rows[i]["RADIOLOGIST"].ToString());

                    i++;
                }

                UltraGrid1.DisplayLayout.Bands[0].Columns["ASSIGNED TO"].ValueList = vl;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }
        #endregion Radiologist

        #region PopulateGrid

        public void Populate(int sp)
        {
            
            CultureInfo culture = new CultureInfo("en-US", true);
            DateTime _fromdate = Convert.ToDateTime(dateTimePicker1.Value, culture);
            DateTime _todate = Convert.ToDateTime(dateTimePicker2.Value, culture);
            try
            {
                ResultEntryWorkList channeldata = new ResultEntryWorkList();
                channeldata.SpType = sp;
                channeldata.FromDate = _fromdate;
                channeldata.ToDate = _todate;
                channeldata.OrgID = new GBLEnvVariable().OrgID;
                ProcessGetDistributionChannel prcdist = new ProcessGetDistributionChannel();
                prcdist.ResultEntryWorkList = channeldata;
                prcdist.Invoke();
                DataTable dt = prcdist.ResultSet.Tables[0];
                UltraGrid1.Refresh();


                UltraGrid1.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            
            Radiologist();
        }

        #endregion PopulateGrid

        private void gridPrintDemo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            
            //this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean;
            
            //e.Layout.Bands[0].Columns["ASSIGNED TO"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
           

            e.Layout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Free;
            e.Layout.Bands[0].AutoPreviewEnabled = true;
            e.Layout.Bands[0].Columns["Order Time"].MaskInput = "mm/dd/yyyy hh:mm";
            e.Layout.Bands[0].Columns["Order Time"].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            e.Layout.Bands[0].Columns["Order Time"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

        }

        private void UltraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            if (e.Row.Band.Index == 0)
            {
                
          
                string st = e.Row.Cells["PRIORITY"].Value.ToString();
                
                if (st == "S")
                {
                    e.Row.Cells["PRIORITY"].Value = "!";
                    e.Row.Cells["PRIORITY"].Appearance.ForeColor = Color.Red;
                    e.Row.Cells["PRIORITY"].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    e.Row.Cells["PRIORITY"].Appearance.FontData.SizeInPoints = 14;


                }

                if (st == "R")
                {
                    e.Row.Cells["PRIORITY"].Value = "";

                }

                if (st == "U")
                {
                    e.Row.Cells["PRIORITY"].Value = "!";
                    e.Row.Cells["PRIORITY"].Appearance.ForeColor = Color.Red;
                    e.Row.Cells["PRIORITY"].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    e.Row.Cells["PRIORITY"].Appearance.FontData.SizeInPoints = 14;

                }

               
            }
        }


        #region ultraGrid1_CellChange

        private void ultraGrid1_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {

            try
            {
                //if(e.Cell.ValueList.IsDroppedDown)
                if (e.Cell.DroppedDown)
                {

                    string accno = e.Cell.Row.Cells["ACCESSION NO"].Text;
                    int a = e.Cell.Column.ValueList.SelectedItemIndex;
                    if (a >= 0)
                    {
                        string aa = e.Cell.Column.ValueList.GetValue(a).ToString();

                        CheckExamResult _exresult = new CheckExamResult();
                        _exresult.SpType = 1;
                        _exresult.AccessionNo = accno;
                        _exresult.AssignedTO = Convert.ToInt32(aa.ToString().Trim());
                        _exresult.AssignedBy = new GBLEnvVariable().UserID;

                        ProcessCheckExam _procexam = new ProcessCheckExam();
                        _procexam.CheckExamResult = _exresult;
                        _procexam.Invoke();
                        DataTable dt = _procexam.ResultSet.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            string id = msg.ShowAlert("UID0049", env.CurrentLanguageID);
                            if (radioUnassigned.Checked)
                            {
                                Populate(2);
                            }
                            else
                            {
                                Populate(3);
                            }
                            return;
                        }
                        else
                        {
                            string uid0048 = msg.ShowAlert("UID0048", env.CurrentLanguageID);
                            if (uid0048 == "2")
                            {
                                _exresult.SpType = 2;
                                _exresult.AccessionNo = accno;
                                _exresult.AssignedTO = Convert.ToInt32(aa.ToString().Trim());
                                _exresult.AssignedBy = new GBLEnvVariable().UserID;
                                _procexam.CheckExamResult = _exresult;
                                _procexam.Invoke();
                                if (radioUnassigned.Checked)
                                {
                                    Populate(2);
                                }
                                else
                                {
                                    Populate(3);
                                }
                            }
                            else
                            {
                                if (radioUnassigned.Checked)
                                {
                                    Populate(2);
                                }
                                else
                                {
                                    Populate(3);
                                }
                                return;
                            }
                        }
                    }
                }

            }
            catch (Exception err) {MessageBox.Show(err.ToString()); }
            
        }

        #endregion // ultraGrid1_CellChange

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioUnassigned.Checked)
            {
                Populate(2);
            }
            else
            {
                Populate(3);
            }
        }


    }
}