using System;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using SUL.DBM.SQLHandaler;
using System.Configuration;

namespace RIS.Common.DBConnection
{
    class dbConnection
    {
        //Variavle for keep the connection string
        //private string strConString;
        //Create sqlConnection instance
        private SqlConnection sqlConn;

        //Create and open the sql connection in the constructor class
        public dbConnection()
        {
            try
            {
                //Variavle for keep the connection string
                //string strConString;
                //Build the connection string
               /*
                strConString = "server=" + System.Configuration.ConfigurationManager.AppSettings["serverName"] + ";" +
                                                   "uid=" + System.Configuration.ConfigurationManager.AppSettings["userId"] + ";" +
                                                   "pwd=" + System.Configuration.ConfigurationManager.AppSettings["userPassword"] + ";" +
                                                   "database=" + System.Configuration.ConfigurationManager.AppSettings["dbName"] + ";";
                
                sqlConn = new SqlConnection(strConString);
                * */

                sqlConn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connStr"]);  
                //Open the sql connection
                sqlConn.Open();
            }
            catch(Exception errr)
            {
                MessageBox.Show("suro= " + errr.Message);
            }
        }

        //Check the dbConnection is ok or not
        public int checkDbConnectio()
        {
            try
            {
                //string strConString;
                /*
                strConString = "server=" + System.Configuration.ConfigurationManager.AppSettings["serverName"] + ";" +
                                                   "uid=" + System.Configuration.ConfigurationManager.AppSettings["userId"] + ";" +
                                                   "pwd=" + System.Configuration.ConfigurationManager.AppSettings["userPassword"] + ";" +
                                                   "database=" + System.Configuration.ConfigurationManager.AppSettings["dbName"] + ";";

                sqlConn = new SqlConnection(strConString);
                 */
                sqlConn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connStr"]); 
                //Open the sql connection
                sqlConn.Open();
                //If connection open successfully
                return 1;
            }
            catch(Exception err)
            {
                //If problem in open the connection
                return 0;
            }
        }

        //Execute the query to select something from the database and return a datatable
        public DataTable SelectDs(string sql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlConn);
            try
            {
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ds.Tables[0];
        }

        //Execute the update/Delete query
        public int UpdateDataBase(string sql)
        {
            int i = 0;

            SqlCommand cmd = new SqlCommand(sql, sqlConn);
            try
            {
                i = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return i;
        }
        
        public SUL.DBM.SQLHandaler.SQLDBManipulation DBControl
        {
            get
            {

                return innerDBControl();
            }
        }
        #region Static Function
        public static string ConncectionString()
        {
            string strConString;
            //Build the connection string
            strConString = "server=" + System.Configuration.ConfigurationManager.AppSettings["serverName"] + ";" +
                                                   "uid=" + System.Configuration.ConfigurationManager.AppSettings["userId"] + ";" +
                                                   "pwd=" + System.Configuration.ConfigurationManager.AppSettings["userPassword"] + ";" +
                                                   "database=" + System.Configuration.ConfigurationManager.AppSettings["dbName"] + ";";
            return strConString;
        }
        private static SUL.DBM.SQLHandaler.SQLDBManipulation innerDBControl()
        {

            SUL.DBM.SQLHandaler.SQLDBManipulation dbcontrol = new SQLDBManipulation(ConncectionString());
            return dbcontrol;

        }
        #endregion
    }
}
