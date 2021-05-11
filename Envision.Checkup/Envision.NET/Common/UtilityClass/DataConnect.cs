using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;

namespace RIS.Common.UtilityClass
{
    public class DataConnect
    {
//        private string _dbcon = "";

//        private SqlConnection con = null;
//        private SqlCommand cmd = null;
//        private SqlDataReader dr = null;
//        private SqlTransaction trns;

//        public DataConnect()
//        {
//            SettingServer();
//        }


//        /// function for retrive Connection string
//        private Boolean SettingServer()
//        {
//            try
//            {
//                _dbcon = "server=" + System.Configuration.ConfigurationSettings.AppSettings["serverName"] + ";" +
//                                                       "uid=" + System.Configuration.ConfigurationSettings.AppSettings["userId"] + ";" +
//                                                       "pwd=" + System.Configuration.ConfigurationSettings.AppSettings["userPassword"] + ";" +
//                                                       "database=" + System.Configuration.ConfigurationSettings.AppSettings["dbName"] + ";";



//                con = new SqlConnection(_dbcon);

//                con.Open();
//                con.Close();
//                cmd = new SqlCommand();

//                return true;
//            }
//            catch (SqlException Ex)
//            {
//                throw Ex;
//                return false;
//            }
//        }

//        // Get Active Connection
//        public SqlConnection GetConnection()
//        {
//            //if (con.State != ConnectionState.Closed)
//            return con;
//        }

//        // Open Connection 
//        public void Open()
//        {
//            try
//            {

//                if (con.State == ConnectionState.Closed)
//                {
//                    con.Open();
//                    cmd.Connection = con;

//                }
//            }
//            catch (Exception Ex)
//            {
//                MessageBox.Show("Connection Error. " + Ex.Message);
//                Application.Exit();
//                return;
//            }

//        }

//        public void BeginTransaction()
//        {
//            trns = con.BeginTransaction();
//            cmd.Transaction = trns;
//            cmd.CommandTimeout = 0;

//        }

//        public void Commit()
//        {
//            trns.Commit();
//        }

//        // Close Connection 
//        public void Close()
//        {
//            if (con.State != ConnectionState.Closed)
//            {
//                con.Close();
//            }
//        }

//        // Execute a SQL and return a datareader 
//        public SqlDataReader Read(string strSQL)
//        {
//            try
//            {
//                //cmd = new SqlCommand(strSQL , con);
//                cmd.CommandText = strSQL;
//                dr = cmd.ExecuteReader();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {

//            }
//            return dr;
//        }

//        // Load data in DataGridView
//        public void LoadDatainGridView(string strSQL, DataGridView dgv)
//        {
//            SqlDataReader tdr = Read(strSQL);
//            if (tdr.HasRows)
//            {
//                int i = 0;
//                while (tdr.Read())
//                {

//                    dgv.Rows.Add();
//                    for (int j = 0; j < tdr.FieldCount; j++)
//                    {
//                        dgv.Rows[i].Cells[j].Value = tdr.GetValue(j);
//                    }
//                    i++;
//                }
//            }
//            tdr.Close();

//        }

//        public void LoadDataGridViewWithFormat(string strSQL, DataGridView dgv, int fmtColumn)
//        {
//            UtilityClass.utility ut = new utility();
//            SqlDataReader tdr = Read(strSQL);
//            if (tdr.HasRows)
//            {
//                int i = 0;
//                while (tdr.Read())
//                {

//                    dgv.Rows.Add();
//                    for (int j = 0; j < tdr.FieldCount; j++)
//                    {
//                        if (j == fmtColumn && (tdr.GetValue(j).ToString() != "0"))
//                        {
//                            dgv.Rows[i].Cells[j].Value = ut.getValues(tdr.GetValue(j).ToString());
//                        }
//                        else
//                            dgv.Rows[i].Cells[j].Value = tdr.GetValue(j);
//                    }
//                    i++;
//                }
//            }
//            tdr.Close();

//        }


//        public void FormatDataGridViewCellLeave(DataGridView dgv, int fmtColumn)
//        {
//            UtilityClass.utility ut = new utility();

//            for (int i = 0; i < dgv.Rows.Count; i++)
//            {
//                for (int j = 0; j < dgv.Columns.Count; j++)
//                {
//                    if (j == fmtColumn && (dgv.Rows[i].Cells[j].Value.ToString() != "0"))
//                    {
//                        dgv.Rows[i].Cells[j].Value = ut.getValues(dgv.Rows[i].Cells[j].Value.ToString());
//                    }
//                }
//            }

//        }




//        // Execute a SQL and return a datatable 
//        public DataTable Table(string strSQL)
//        {
//            DataTable dt = new DataTable();
//            SqlDataAdapter da;

//            try
//            {
//                da = new SqlDataAdapter(strSQL, con);
//                da.Fill(dt);
//                return dt;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {

//            }
//            return dt;
//        }

//        public void FillListView(string strSQL, ListView lstShow)
//        {
//            //lstShow.Clear();
//            lstShow.Items.Clear();
//            DataTable dt = Table(strSQL);
//            int x = 0;
//            while (x < dt.Rows.Count)
//            {
//                lstShow.Items.Add(dt.Rows[x][0].ToString(), x);

//                int fldCount = 1;
//                while (fldCount < dt.Columns.Count)
//                {
//                    lstShow.Items[x].SubItems.Add(dt.Rows[x][fldCount].ToString());
//                    fldCount++;
//                }
//                x++;
//            }

//        }

//        public void RemoveDuplicateNameFromListView(ListView lstShow, int colNo)
//        {
//            string tmp = null, val = null;

//            for (int i = 0; i < lstShow.Items.Count; i++)
//            {
//                val = lstShow.Items[i].SubItems[colNo].Text;
//                if (tmp != val)
//                {
//                    tmp = val;
//                }
//                else
//                    lstShow.Items[i].SubItems[colNo].Text = "";

//            }
//        }


//        //Load New Data in DropDownBox
//        public void LoadDataInCombo(string strSQL, ComboBox cmbCpoName)
//        {
//            DataTable cpoTab = Table(strSQL);
//            cmbCpoName.Items.Clear();
//            cmbCpoName.DataSource = cpoTab;
//            cmbCpoName.DisplayMember = cpoTab.Columns[1].ToString();
//            cmbCpoName.ValueMember = cpoTab.Columns[0].ToString();

//        }

//        //Load combo with a blank starting
//        public void loadComboWithBlank(string strSQL, ComboBox cmbName, string cmbValue, string cmbDisplay)
//        {
//            //Note: First ID then display member in string

//            DataTable cmbTab = new DataTable();
//            cmbTab = Table(strSQL);

//            DataRow dr = cmbTab.NewRow();
//            dr[cmbDisplay] = "";
//            dr[cmbValue] = "0";
//            cmbTab.Rows.InsertAt(dr, 0);

//            cmbName.DataSource = cmbTab;
//            cmbName.DisplayMember = cmbTab.Columns[1].ToString();
//            cmbName.ValueMember = cmbTab.Columns[0].ToString();


//            //cmbName.DataBind();

//        }

//        //Add Data in DropDownBox
//        public void AddDataInCombo(string strSQL, ComboBox dd)
//        {
//            try
//            {
//                cmd = new SqlCommand(strSQL, con);
//                dr = cmd.ExecuteReader();

//                while (dr.Read())
//                {
//                    //ListItem li = new ListItem();
//                    //li.Text = dr.GetString(1);
//                    //li.Value = dr.GetValue(0).ToString();
//                    //dd.Items.Add(li);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {
//                dr.Close();
//            }
//        }


//        //Get Maximum ID from a given table
//        public long GetNextID(string tblName, string FieldName)
//        {
//            try
//            {
//                cmd = new SqlCommand("SELECT MAX(" + FieldName + ") FROM " + tblName + " ", con);
//                long val = 0;
//                val = Convert.ToInt64(cmd.ExecuteScalar());
//                return val + 1;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//                return 1;
//            }
//        }

//        // Execute a SQL command 
//        public void Execute(string strSQL)
//        {
//            //transaction=con.BeginTransaction();
//            try
//            {
//                //cmd = new SqlCommand(strSQL , con);
//                cmd.CommandText = strSQL;
//                cmd.ExecuteNonQuery();

//            }
//            catch (Exception ex)
//            {
//                trns.Rollback();
//                throw ex;
//            }
//            finally
//            {
//                //transaction.Commit();
//            }
//        }

//        /* For every transaction there will an Entry in BM_SceurityTransectionHistory
//         * table. Current User ID, Current master ID, Input form name,
//         * what type of event(save,edit,delete), Any kind of description
//        */

//        public void UserLogEntry(string user_id, string TransectionID,
//            int menu_id, int Event, string Narration)
//        {
//            long next_id = GetNextID("Transaction_History", "HistoryID");
//            string strSQL = null;

//            strSQL = "INSERT " +
//                  "     INTO " +
//                  "Transaction_History (" +
//                  "     HistoryID, " +
//                  "     TransectionID, " +
//                  "     TransectionTime, " +
//                  "     MenuObjectid, " +
//                  "     TypeID, " +
//                  "     Narration, " +
//                  "     UserID " +
//                  ") " +
//                  "VALUES (" +
//                        next_id +
//                        ",'" + TransectionID +
//                        "','" + System.DateTime.Now +
//                        "'," + menu_id +
//                        ",'" + Event +
//                        "','" + Narration +
//                       "','" + user_id +
//                        "' )";

//            Execute(strSQL);

//        }

//        // Check whether a given value is exist in table or NOT
//        public Boolean CheckValue(string tblName, string FieldName, string Value)
//        {
//            try
//            {
//                cmd = new SqlCommand("SELECT COUNT(*)as cnt FROM " + tblName + " WHERE  " + FieldName + "='" + Value + "' ", con);

//                long val = 0;
//                val = Convert.ToInt16(cmd.ExecuteScalar());

//                if (val == 0)
//                    return false;
//                else
//                    return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//                return false;
//            }
//        }

//        // Get a value
//        public string GetValue(string tblName, string SourceFieldName, string DestinationFieldName, string Value)
//        {
//            string val = null;
//            string strSQL = "SELECT " + DestinationFieldName + " FROM " + tblName + " WHERE  " + SourceFieldName + "='" + Value + "' ";
//            try
//            {
//                cmd = new SqlCommand(strSQL, con);
//                val = cmd.ExecuteScalar().ToString();

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//                return val;
//            }
//            return val;
//        }


//        public int GetNoOfIntervention(long ClientID)
//        {
//            string strSQL = @"select isnull(COUNT(NO_OF_INTERVENTION)+1,1)
//                            from CLIENT_MONITORING_INFORMATION
//                            where client_id=" + ClientID;
//            int val = 0;
//            try
//            {
//                cmd = new SqlCommand(strSQL, con);
//                val = Convert.ToInt16(cmd.ExecuteScalar());

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//                return val;
//            }
//            return val;

//        }

    }

}
