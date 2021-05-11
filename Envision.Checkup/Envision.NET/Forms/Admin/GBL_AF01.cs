using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common;
using RIS.Common.Common;
using RIS.BusinessLogic;
using RIS.Operational.PACS;
using RIS.Operational;
using System.Globalization;
using Miracle.HL7.ORU;
using Miracle.Util;

namespace RIS.Forms.Admin
{
    public partial class GBL_AF01 : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public GBL_AF01(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
            PopulateGrid();
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
            string qry2 = "select ([fname]+' '+ [lname]) AS RADIOLOGIST,EMP_ID from hr_emp where JOB_TYPE='D' AND IS_RADIOLOGIST='Y'";
            ProcessGetGBLLookup lkp3 = new ProcessGetGBLLookup(qry2);
            lkp3.Invoke();
            DataTable dt3 = lkp3.ResultSet.Tables[0];
            
            if (this.ultraGrid2.DisplayLayout.ValueLists.Exists("Radiologist"))
                return;
            if (this.ultraGrid2.DisplayLayout.ValueLists.Exists("Radiologist2"))
                return;

            Infragistics.Win.ValueListsCollection lists = this.ultraGrid2.DisplayLayout.ValueLists;
            Infragistics.Win.ValueList vl = lists.Add("Radiologist");
           
            int i = 0;
            while (i<dt3.Rows.Count)
            {
                vl.ValueListItems.Add(0, dt3.Rows[i]["EMP_ID"].ToString()+"#"+dt3.Rows[i]["RADIOLOGIST"].ToString());
                
                i++;
            }
            ultraGrid2.DisplayLayout.Bands[0].Columns["REQUESTED BY"].ValueList = vl;

            for (int j = 0; j < 8; j++)
            {
                this.ultraGrid2.DisplayLayout.Bands[0].Columns[j].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
            this.ultraGrid2.DisplayLayout.Bands[0].Columns[9].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid2.DisplayLayout.Bands[0].Columns["Order TIME"].MaskInput = "mm/dd/yyyy hh:mm";
            this.ultraGrid2.DisplayLayout.Bands[0].Columns["Order Time"].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            this.ultraGrid2.DisplayLayout.Bands[0].Columns["Order Time"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
        }
        #endregion Radiologist

        #region HL7MSG
        public string getMSG(string acc, string type)
        {
            string qry="";
            string hl7msg="";
            if (type == "ORU")
            {
                qry = "SELECT HL7_TEXT from RIS_EXAMRESULT WHERE ACCESSION_NO='"+acc+"'";
            }
            else
            {
                qry = "SELECT HL7_TEXT from RIS_ORDERDTL WHERE ACCESSION_NO='" + acc + "'";
            }
            try
            {
                ProcessGetGBLLookup lkp3 = new ProcessGetGBLLookup(qry);
                lkp3.Invoke();
                DataTable dt3 = lkp3.ResultSet.Tables[0];
                if (dt3.Rows.Count > 0)
                {
                    hl7msg = dt3.Rows[0]["HL7_TEXT"].ToString();
                }
            }
            catch (Exception err) { MessageBox.Show(err.ToString());}

            return hl7msg;


        }
        #endregion

        #region PATIENTDEMOGRA
        public DataTable patientDemo(string hn)
        {
            ProcessGetPatientReg regs = new ProcessGetPatientReg(hn.ToString());
            regs.Invoke();
            DataTable dt = regs.ResultSet.Tables[0];
           
            return dt;
        }
        #endregion

        #region RefreshDataGrid
        public void refreshGrid1()
        {
            CultureInfo culture = new CultureInfo("en-US", true);
            DateTime _fromdate = Convert.ToDateTime(dateTimePicker1.Value, culture);
            DateTime _todate = Convert.ToDateTime(dateTimePicker2.Value, culture);

            HL7Monitoring hl7data = new HL7Monitoring();
            hl7data.SpType = 2;
            hl7data.FromDate = _fromdate;
            hl7data.ToDate = _todate;
            ProcessGetHL7Monitoring prchl7 = new ProcessGetHL7Monitoring();
            prchl7.HL7Monitoring = hl7data;
            prchl7.Invoke();
            DataTable dt = prchl7.ResultSet.Tables[0];
            if (dt.Rows.Count > 0)
            {
                UltraGrid1.DataSource = dt;
            }
        }
        public void refreshGrid2()
        {
            ultraGrid2.Refresh();
            CultureInfo culture = new CultureInfo("en-US", true);
            DateTime _fromdate = Convert.ToDateTime(dateTimePicker5.Value, culture);
            DateTime _todate = Convert.ToDateTime(dateTimePicker6.Value, culture);

            HL7Monitoring hl7data = new HL7Monitoring();
            hl7data.SpType = 2;
            hl7data.FromDate = _fromdate;
            hl7data.ToDate = _todate;
            ProcessGetReportStatusChange prchl7 = new ProcessGetReportStatusChange();
            prchl7.HL7Monitoring = hl7data;
            prchl7.Invoke();
            DataTable dt = prchl7.ResultSet.Tables[0];
            if (dt.Rows.Count > 0)
            {
                ultraGrid2.DataSource = dt;
            }
            else
            {
                return;
            }

            if (this.ultraGrid2.DisplayLayout.ValueLists.Exists("Change"))
                return;

            Infragistics.Win.ValueListsCollection lists = this.ultraGrid2.DisplayLayout.ValueLists;
            Infragistics.Win.ValueList vl = lists.Add("Change");
            vl.ValueListItems.Add(0, "New");
            vl.ValueListItems.Add(0, "Draft");
            ultraGrid2.DisplayLayout.Bands[0].Columns["CHANGE TO"].ValueList = vl;


            Radiologist();

        }
        #endregion
        #region PopulateGrid
        public void PopulateGrid()
        {

            try
            {
                
                DateTime dt11 = Convert.ToDateTime(dateTimePicker1.Value);
                DateTime dt22 = Convert.ToDateTime(dateTimePicker2.Value);

                this.ultraGrid2.DisplayLayout.Bands[0].Columns.Add("CheckBoxColumn", "ACTION");
                this.ultraGrid2.DisplayLayout.Bands[0].Columns["CheckBoxColumn"].DataType = typeof(bool);
                this.ultraGrid2.DisplayLayout.Bands[0].Columns["CheckBoxColumn"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;

                this.UltraGrid1.DisplayLayout.Bands[0].Columns.Add("CheckBoxColumn", "ACTION");
                this.UltraGrid1.DisplayLayout.Bands[0].Columns["CheckBoxColumn"].DataType = typeof(bool);
                this.UltraGrid1.DisplayLayout.Bands[0].Columns["CheckBoxColumn"].Style =
                Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;

                ultraExpandableGroupBox3.Visible = false;
                ultraExpandableGroupBox1.Expanded = false;
                HL7Monitoring hl7data = new HL7Monitoring();
                hl7data.SpType = 1;
                hl7data.FromDate = dt11;
                hl7data.ToDate = dt22;
                ProcessGetHL7Monitoring prchl7 = new ProcessGetHL7Monitoring();
                prchl7.HL7Monitoring = hl7data;
                prchl7.Invoke();
                this.UltraGrid1.Text = "";
                DataTable dt = prchl7.ResultSet.Tables[0];
               
                 UltraGrid1.DataSource = dt;
                




            }
            catch (Exception err) { MessageBox.Show(err.ToString()); }


        }
        #endregion
        private void GBL_AF01_Load(object sender, EventArgs e)
        {
           


        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            ultraExpandableGroupBox3.Visible = false;
            ultraExpandableGroupBox2.Visible = true;
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            
            ultraExpandableGroupBox3.Visible = true;
            ultraExpandableGroupBox2.Visible = false;
            DateTime dt11 = Convert.ToDateTime(dateTimePicker5.Value);
            DateTime dt22 = Convert.ToDateTime(dateTimePicker6.Value);
                       

            HL7Monitoring hl7data = new HL7Monitoring();
            hl7data.SpType = 1;
            hl7data.FromDate = dt11;
            hl7data.ToDate = dt22;
            ProcessGetReportStatusChange prchl7 = new ProcessGetReportStatusChange();
            prchl7.HL7Monitoring = hl7data;
            prchl7.Invoke();
            this.ultraGrid2.Text = "";
            DataTable dt = prchl7.ResultSet.Tables[0];
            if (dt.Rows.Count > 0)
            {
                ultraGrid2.DataSource = dt;
            }
            else
            {
                ultraGrid2.DataSource = dt;
                return;
            }

            if (this.ultraGrid2.DisplayLayout.ValueLists.Exists("Change"))
                return;

            Infragistics.Win.ValueListsCollection lists = this.ultraGrid2.DisplayLayout.ValueLists;
            Infragistics.Win.ValueList vl = lists.Add("Change");
            vl.ValueListItems.Add(0, "New");
            vl.ValueListItems.Add(0, "Draft");
            ultraGrid2.DisplayLayout.Bands[0].Columns["CHANGE TO"].ValueList = vl;
            

            Radiologist();


        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            string _accno = "";
            string _hl7txt = "";
            string _type = "";
            
            int count=0;
            int j = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("ACCESSION_NO");
            dt.Columns.Add("HL7_TXT");
            dt.Columns.Add("TYPE");
            

            while (j < UltraGrid1.Rows.Count)
            {
                this.UltraGrid1.Rows[j].Cells[8].Selected = true;

                if (this.UltraGrid1.Rows[j].Cells[8].Value.ToString().Trim() == "True")
                {
                    _accno = this.UltraGrid1.Rows[j].Cells["ACCESSION NO"].Value.ToString().Trim();
                    _type = this.UltraGrid1.Rows[j].Cells["MSG TYPE"].Value.ToString().Trim();

                    _hl7txt = getMSG(_accno, _type);

                    dt.Rows.Add(_accno, _hl7txt, _type);
                    

                    count++;

                }
                j++;
            }
            if(count>0)
            {
                //SendToPacs sp = new SendToPacs();
                //bool a=sp.SendMSGToPacs(dt, "HL7");
                //if (a)
                //{
                //    MessageBox.Show("Successfully sent to pacs");
                //    refreshGrid1();
                //}
                //else
                //{
                //    MessageBox.Show("Message send faild to pacs");
                //}
                
            }
            else
            {
                MessageBox.Show("You must select one row");
            }

        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            GenerateORU genoru = new GenerateORU();
            Utilities uti = new Utilities();
            HL7Monitoring hlobj = new HL7Monitoring();
            ProcessAddResultStatusChangeLog chlog = new ProcessAddResultStatusChangeLog();

            SendToPacs stpacs = new SendToPacs();

            string _hn = "";
            string _orderid="";
            string _accno="";
            string _examid="";
            string _examname="";
            string _origingalstatus="";
            string _changestatus="";
            string _reqby="";
            string _changepc="";
            string _orgid="";
            string _createdby="";
            string _hl7text = "";
            string _ordid="";
            bool flg = false;
            DataTable dtMSG = new DataTable();
            dtMSG.Columns.Add("HN");
            dtMSG.Columns.Add("FNAME");
            dtMSG.Columns.Add("MNAME");
            dtMSG.Columns.Add("LNAME");
            dtMSG.Columns.Add("THFNAME");
            dtMSG.Columns.Add("THMNAME");
            dtMSG.Columns.Add("GENDER");
            dtMSG.Columns.Add("DOB");
            dtMSG.Columns.Add("PHONE");
            dtMSG.Columns.Add("ADDRESS");
            dtMSG.Columns.Add("ACCESSION_NO");
            dtMSG.Columns.Add("STATUS");
            dtMSG.Columns.Add("EXAM_ID");
            dtMSG.Columns.Add("EXAM_NAME");
            dtMSG.Columns.Add("HL7TXT");
            dtMSG.Columns.Add("ORDNO");

            DataTable dtlog = new DataTable();

            dtlog.Columns.Add("HN");
            dtlog.Columns.Add("ACCESSION_NO");
            dtlog.Columns.Add("EXAM_ID");
            dtlog.Columns.Add("STATUS");
            dtlog.Columns.Add("CHANGE_TO");
            dtlog.Columns.Add("REQ_BY");
            dtlog.Columns.Add("PC");
            dtlog.Columns.Add("ORG_ID");
            dtlog.Columns.Add("CREATED_BY");
            dtlog.Columns.Add("HL7_TXT");
            DataTable hlmsg=new DataTable();
            ArrayList arr = new ArrayList();
            int counts = 0;
            int i = 0;
            while (i < ultraGrid2.Rows.Count)
            {
                this.ultraGrid2.Rows[i].Cells[11].Selected = true;

                if (this.ultraGrid2.Rows[i].Cells[11].Value.ToString().Trim() == "True")
                {
                    _hn = this.ultraGrid2.Rows[i].Cells["HN"].Value.ToString().Trim();
                    _accno = this.ultraGrid2.Rows[i].Cells["ACCESSION NO"].Value.ToString().Trim();
                    _examid = this.ultraGrid2.Rows[i].Cells["EXAM CODE"].Value.ToString().Trim();
                    _examname = this.ultraGrid2.Rows[i].Cells["EXAM CODE"].Value.ToString().Trim();
                    _origingalstatus = this.ultraGrid2.Rows[i].Cells["STATUS"].Value.ToString().Trim();
                    string _changto = this.ultraGrid2.Rows[i].Cells["CHANGE TO"].Value.ToString().Trim();
                    _changestatus = "D";
                    
                    _ordid = this.ultraGrid2.Rows[i].Cells["ORDER ID"].Value.ToString().Trim();
                    _reqby = this.ultraGrid2.Rows[i].Cells["REQUESTED BY"].Text.ToString().Trim();
                    
                    if (_reqby == "")
                    {
                        MessageBox.Show("Requested By cell can't be blank !");
                        return;
                    }
                    if (_changto == "")
                    {
                        MessageBox.Show("Change To cell can't be blank !");
                        return;
                    }
                    string[] a = _reqby.Split('#');
                    _reqby = a.GetValue(0).ToString().Trim();
                    
                    _changepc = uti.MachineName();
                    _orgid = new GBLEnvVariable().OrgID.ToString();
                    _createdby = new GBLEnvVariable().UserID.ToString();
                    
                    DataTable dt = patientDemo(_hn);

                    dtMSG.Rows.Add(dt.Rows[0]["HN"].ToString(),
                        dt.Rows[0]["FNAME_ENG"].ToString(),
                        dt.Rows[0]["MNAME_ENG"].ToString(),
                        dt.Rows[0]["LNAME_ENG"].ToString(),
                        dt.Rows[0]["FNAME"].ToString(),
                        //dt.Rows[0]["MNAME"].ToString(),
                        dt.Rows[0]["LNAME"].ToString(),
                        dt.Rows[0]["GENDER"].ToString(),
                        dt.Rows[0]["DOB"].ToString(),
                        dt.Rows[0]["PHONE1"].ToString(),
                        dt.Rows[0]["ADDR1"].ToString(),
                        _accno,
                        "P",
                        _examid,
                        _examname,
                        "Result temporarily witheld",
                        _orderid);

                    hlmsg = genoru.createMessage(dtMSG);

                    dtlog.Rows.Add(_hn,
                        _accno,
                        _examid,
                        _origingalstatus,
                        _changestatus,
                        _reqby,
                        _changepc,
                        _orgid,
                        _createdby,
                        hlmsg.Rows[0]["HL7_TXT"].ToString());

                    
                    //flg = stpacs.SendMSGToPacs(hlmsg, "ORU");
                    counts++;

                }
                i++;
            }
            if (counts > 0)
            {
                
                
                if (flg)
                {
                    for (int j = 0; j < dtlog.Rows.Count; j++)
                    {
                        try
                        {
                            hlobj.PatientID = dtlog.Rows[j]["HN"].ToString().Trim();
                            hlobj.AccessionNo = dtlog.Rows[j]["ACCESSION_NO"].ToString().Trim();
                           
                                string eqry = "Select EXAM_ID FROM RIS_EXAM WHERE EXAM_UID='" + dtlog.Rows[j]["EXAM_ID"].ToString().Trim()+ "'";
                                ProcessGetGBLLookup exm = new ProcessGetGBLLookup(eqry);
                                exm.Invoke();
                                DataTable dtex = exm.ResultSet.Tables[0];
                                if (dtex.Rows.Count > 0)
                                {
                                    hlobj.ExamID = Convert.ToInt32(dtex.Rows[0]["EXAM_ID"].ToString());
                                }
                            hlobj.OriginalStatus = dtlog.Rows[j]["STATUS"].ToString().Trim();
                            hlobj.ChangeStatus = dtlog.Rows[j]["CHANGE_TO"].ToString().Trim();
                            hlobj.RequestBy = Convert.ToInt32(dtlog.Rows[j]["REQ_BY"].ToString().Trim());
                            hlobj.ChangePC = dtlog.Rows[j]["PC"].ToString().Trim();
                            hlobj.OrgID =Convert.ToInt32( dtlog.Rows[j]["ORG_ID"].ToString().Trim());
                            hlobj.CreatedBy = Convert.ToInt32(dtlog.Rows[j]["CREATED_BY"].ToString().Trim());
                            hlobj.Hl7Text = dtlog.Rows[j]["HL7_TXT"].ToString().Trim();

                            chlog.HL7Monitoring = hlobj;
                            chlog.Invoke();
                        }
                        catch (Exception errr) { MessageBox.Show(errr.ToString()); }
                    }
                    refreshGrid2();
                    MessageBox.Show("msg sent");
                }
                else
                {
                    MessageBox.Show("msg not sent");
                }
            }
            else
            {
                MessageBox.Show("You must select one row");
            }


        }

        private void gridPrintDemo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            e.Layout.Bands[0].Columns["Order Time"].MaskInput = "mm/dd/yyyy hh:mm";
            e.Layout.Bands[0].Columns["Order Time"].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            e.Layout.Bands[0].Columns["Order Time"].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

        }

        private void gridPrintDemo2_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            refreshGrid1();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            refreshGrid1();

        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            refreshGrid2();
            
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            refreshGrid2();
           

        }
    }
}