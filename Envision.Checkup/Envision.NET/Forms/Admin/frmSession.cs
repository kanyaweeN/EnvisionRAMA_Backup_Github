using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.BusinessLogic;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using RIS.Forms.GBLMessage;

namespace RIS.Forms.Admin
{
    public partial class frmSession : Form
    {
        //private ViewMode viewMode = ViewMode.ACTIVE;
        //private enum ViewMode
        //{
        //    ACTIVE = 0, INACTIVE = 1, KILLED = 2, ALL = 3
        //}
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public ProcessGetGBLSessionViewer viewer;
        public ProcessGetGBLSessionViewer entry;
        public ProcessUpdateGBSessionView updateViwer;
        public DataSet Source;
        public frmSession(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            //UUL.ControlFrame.Controls.TabControl clsCtl
            InitializeComponent();
            CloseControl = clsCtl;
            
            Source = new DataSet();
            SetDateTime();
            DateTime st = new DateTime(dStartDate.DateTime.Year, dStartDate.DateTime.Month, dStartDate.DateTime.Day, 0, 0, 0);
            DateTime fh = new DateTime(dEndDate.DateTime.Year, dEndDate.DateTime.Month, dEndDate.DateTime.Day, 23, 59, 59);
            GetSource(5, 3, st, fh); // active session
            SetGridControl();
            
        }
        private void SetDateTime()
        {
            dStartDate.DateTime = DateTime.Now;
            dEndDate.DateTime = DateTime.Now;
        }
        private void GetSource(int mode2, int mode, DateTime st, DateTime fh)
        {
            viewer = new ProcessGetGBLSessionViewer(mode);
            viewer.Start = st;
            viewer.End = fh;
            viewer.Invoke();
            viewer.Result.Tables[0].Columns.Add("Select");
            viewer.Result.Tables[0].TableName = "Parent";

            entry = new ProcessGetGBLSessionViewer(mode2);
            entry.Start = st;
            entry.End = fh;
            entry.Invoke();

            entry.Result.Tables[0].TableName = "Entrys";
           

            Source.Tables.Add(viewer.Result.Tables[0].Copy());
            Source.Tables.Add(entry.Result.Tables[0].Copy());

            Source.Relations.Add(new DataRelation("rEntry",Source.Tables[0].Columns["SESSION_GUID"],Source.Tables[1].Columns["SESSION_GUID"]));

            gridControl1.DataSource = Source.Tables[0];
            layoutControlGroup3.Text = "Result Sessions = " + viewer.Result.Tables[0].Rows.Count + " rows";
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            gridLevelNode1.LevelTemplate = gridView1;
            gridLevelNode1.RelationName = "rEntry";
            gridControl1.LevelTree.Nodes.Add(gridLevelNode1);
            
        }
        private void RefreshGrid()
        {
            gridControl1.Refresh();
        }
        private void SetGridControl()
        {
            
            advBandedGridView1.Columns["Select"].ColVIndex = 0;
            advBandedGridView1.Columns["Select"].BestFit();

            RepositoryItemCheckEdit chkConfirm = new RepositoryItemCheckEdit();
            chkConfirm.ValueChecked = "Y";
            chkConfirm.ValueUnchecked = "N";
            chkConfirm.CheckStyle = CheckStyles.Standard;
            chkConfirm.NullStyle = StyleIndeterminate.Unchecked;
            chkConfirm.DisplayFormat.FormatType = FormatType.Custom;
            chkConfirm.CheckedChanged += new EventHandler(chkConfirm_CheckedChanged);        //view1.Columns["RoleStatus"].ColumnEdit = (RepositoryItemCheckEdit)chkConfirm;
            advBandedGridView1.Columns["Select"].ColumnEdit = chkConfirm;

            advBandedGridView1.Columns["SESSION_GUID"].Caption = "Session GUID";
            advBandedGridView1.Columns["SESSION_GUID"].BestFit();
            advBandedGridView1.Columns["EMP_ID"].Caption = "Emp ID";
            advBandedGridView1.Columns["EMP_ID"].BestFit();
            advBandedGridView1.Columns["FNAME"].Caption = "Frist Name";
            advBandedGridView1.Columns["FNAME"].BestFit();
            advBandedGridView1.Columns["LNAME"].Caption = "Last Name";
            advBandedGridView1.Columns["LNAME"].BestFit();
            advBandedGridView1.Columns["LOGON_TYPE"].Caption = "Logon Type";
            advBandedGridView1.Columns["LOGON_TYPE"].BestFit();
            advBandedGridView1.Columns["LOGON_DT"].Caption = "Logon Date";
            advBandedGridView1.Columns["LOGON_DT"].DisplayFormat.FormatType = FormatType.DateTime;
            advBandedGridView1.Columns["LOGON_DT"].DisplayFormat.FormatString = "g";
            advBandedGridView1.Columns["LOGON_DT"].BestFit();
            advBandedGridView1.Columns["LOGOUT_DT"].Caption = "Logout Date";
            advBandedGridView1.Columns["LOGOUT_DT"].DisplayFormat.FormatType = FormatType.DateTime;
            advBandedGridView1.Columns["LOGOUT_DT"].DisplayFormat.FormatString = "g";
            advBandedGridView1.Columns["LOGOUT_DT"].BestFit();
            advBandedGridView1.Columns["LOGOUT_TYPE"].Caption = "Logout Type";
            advBandedGridView1.Columns["LOGOUT_TYPE"].BestFit();
            advBandedGridView1.Columns["LOGOUT_TYPE"].DisplayFormat.FormatType = FormatType.DateTime;
            advBandedGridView1.Columns["LOGOUT_TYPE"].DisplayFormat.FormatString = "g";
            advBandedGridView1.Columns["KILLED_BY"].Caption = "Killed By";
            advBandedGridView1.Columns["KILLED_BY"].BestFit();
            advBandedGridView1.Columns["KILL_REASON"].Caption = "Kill Reason";
            advBandedGridView1.Columns["KILL_REASON"].BestFit();
            advBandedGridView1.Columns["IP_ADDR_CURR"].Caption = "IP Address";
            advBandedGridView1.Columns["IP_ADDR_CURR"].BestFit();

            //DevExpress.XtraGrid.Columns.GridColumn submenu = new DevExpress.XtraGrid.Columns.GridColumn();
           // submenu.FieldName = "SUBMENU_UID";
            //submenu.Caption = "Submenu UID";
            //gridView1.Columns.Add(submenu);
            gridView1.Columns["SUBMENU_UID"].AppearanceHeader.ForeColor = Color.Black;
            gridView1.Columns["SESSION_GUID"].AppearanceHeader.ForeColor = Color.Black;
            gridView1.Columns["SUBMENU_NAME_USER"].AppearanceHeader.ForeColor = Color.Black;
            gridView1.Columns["ACCESSED_ON"].AppearanceHeader.ForeColor = Color.Black;
            gridView1.Columns["ACCESSED_OUT"].AppearanceHeader.ForeColor = Color.Black;
            gridView1.Columns["ACTIVITY_DESC"].AppearanceHeader.ForeColor = Color.Black;
            gridView1.Columns["SESSION_GUID"].BestFit();
            gridView1.Columns["SESSION_GUID"].Visible = false;
            gridView1.Columns["SUBMENU_NAME_USER"].BestFit();
            gridView1.Columns["ACCESSED_ON"].BestFit();
            gridView1.Columns["ACCESSED_ON"].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns["ACCESSED_ON"].DisplayFormat.FormatString = "g";
            gridView1.Columns["ACCESSED_OUT"].BestFit();
            gridView1.Columns["ACCESSED_OUT"].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns["ACCESSED_OUT"].DisplayFormat.FormatString = "g";
            gridView1.Columns["ACTIVITY_DESC"].BestFit();

            advBandedGridView1.Columns[1].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns[2].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns[3].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns[4].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns[5].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns[6].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns[7].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns[8].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns[9].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns[10].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns[0].OptionsColumn.AllowEdit = false;
        }
        private void SourceClear()
        {
            //Source.Clear();
            Source = new DataSet();
        }
        void chkConfirm_CheckedChanged(object sender, EventArgs e)
        {
            //DataRow dr = Source.Tables[0].Select(" SELECT ='Y'");
            int index = advBandedGridView1.FocusedRowHandle;
            if (index >= 0)
            {
                if (Source.Tables[0].Rows[index]["Select"].ToString() == "Y")
                {
                    Source.Tables[0].Rows[index]["Select"] = "N";
                }
                else if (Source.Tables[0].Rows[index]["Select"].ToString() == "N")
                {
                    Source.Tables[0].Rows[index]["Select"] = "Y";
                }
            }
           
        }
        private void rbActiveSession_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActiveSession.Checked)
            {
                SourceClear();
                GetSource(5, 3, DateTime.Now, DateTime.Now); // active session
                SetGridControl();
                RefreshGrid();
            }
        }

        private void rbInActive_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInActive.Checked)
            {
                SourceClear();                
                GetSource(7, 2, DateTime.Now, DateTime.Now); // inactive session
                SetGridControl();
                RefreshGrid();
            }
        }

        private void rbKilled_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKilled.Checked)
            {
                SourceClear();
                GetSource(8, 4, DateTime.Now, DateTime.Now); // killed session
                SetGridControl();
                RefreshGrid();
            }
        }

        private void rbAllSession_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAllSession.Checked)
            {
                SourceClear();
                GetSource(9, 1, DateTime.Now, DateTime.Now); // all session
                SetGridControl();
                RefreshGrid();
            }
        }

        private void bKillSession_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in Source.Tables[0].Rows)
            {
               
                    if (dr["Select"].ToString() == "Y")
                    {
                        AlertSessionPopup popup = AlertSessionPopup.GetForm();
                        popup.ShowDialog();
                        if (popup.state == AlertSessionPopup.State.OK)
                        {
                            updateViwer = new ProcessUpdateGBSessionView();

                            updateViwer.UserLogin = new RIS.Common.Common.GBLEnvVariable().UserID.ToString();
                            updateViwer.SessionGUID = dr["SESSION_GUID"].ToString();
                            updateViwer.Reason = popup.ReasonText;
                            updateViwer.Invoke();

                            SourceClear();
                            GetSource(5, 3, DateTime.Now, DateTime.Now); // active session
                            SetGridControl();
                            RefreshGrid();

                            KillSession(dr["IP_ADDR_CURR"].ToString());
                        }
                        break;
                     }
                }
        }
        private void KillSession(string ip)
        {
            TcpClient tcpClient;
            NetworkStream networkStream;
            StreamReader streamReader;
            StreamWriter streamWriter;
            try
            {
                tcpClient = new TcpClient(ip, 5555);
                networkStream = tcpClient.GetStream();
                streamReader = new StreamReader(networkStream);
                streamWriter = new StreamWriter(networkStream);
                streamWriter.WriteLine("Your session has been killed...");
                streamWriter.Flush();
                streamWriter.Close();
                tcpClient.Close();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void Search_Click(object sender, EventArgs e)
        {
            DateTime dtFrom = new DateTime(dStartDate.DateTime.Year, dStartDate.DateTime.Month, dStartDate.DateTime.Day, 0, 0, 0);
            DateTime dtTo = new DateTime(dEndDate.DateTime.Year, dEndDate.DateTime.Month, dEndDate.DateTime.Day, 23, 59, 59);



            if (rbActiveSession.Checked)
            {
                SourceClear();
                //GetSource(5, 3, dStartDate.DateTime, dEndDate.DateTime); // active session
                GetSource(5, 3, dtFrom, dtTo);
                SetGridControl();
                RefreshGrid();
            }
            else if (rbInActive.Checked)
            {
                SourceClear();
                GetSource(7, 2, dStartDate.DateTime, dEndDate.DateTime); // inactive session
                SetGridControl();
                RefreshGrid();
            }
            else if (rbKilled.Checked)
            {
                SourceClear();
                GetSource(8, 4, dStartDate.DateTime, dEndDate.DateTime); // killed session
                SetGridControl();
                RefreshGrid();
            }
            else if (rbAllSession.Checked)
            {
                SourceClear();
                GetSource(9, 1, dStartDate.DateTime, dEndDate.DateTime); // all session
                SetGridControl();
                RefreshGrid();
            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            if (rbActiveSession.Checked)
            {
                SourceClear();
                GetSource(5, 3, dStartDate.DateTime, dEndDate.DateTime); // active session
                SetGridControl();
                RefreshGrid();
            }
            else if (rbInActive.Checked)
            {
                SourceClear();
                GetSource(7, 2, dStartDate.DateTime, dEndDate.DateTime); // inactive session
                SetGridControl();
                RefreshGrid();
            }
            else if (rbKilled.Checked)
            {
                SourceClear();
                GetSource(8, 4, dStartDate.DateTime, dEndDate.DateTime); // killed session
                SetGridControl();
                RefreshGrid();
            }
            else if (rbAllSession.Checked)
            {
                SourceClear();
                GetSource(9, 1, dStartDate.DateTime, dEndDate.DateTime); // all session
                SetGridControl();
                RefreshGrid();
            }
        }
    }
}
