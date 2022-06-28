using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Envision.BusinessLogic
{
    public class _InputLogMultiOrder
    {
        public _InputLogMultiOrder()
        {

        }
        public static void AddLog(int order_id,string ip,string form)
        {
            string query = @"INSERT INTO [dbo].[_logMultiOrder]
                                   ([order_id]
                                   ,[IP_address]
                                   ,[form]
                                   ,[created_on_client]
                                   ,[created_on_server])
                             VALUES
                                   (@order_id
                                   ,@IP_address
                                   ,@form
                                   ,@created_on_client
                                   ,getdate())";
            //SqlConnection con = new SqlConnection("server=miracle9; database=RIS_RAMA;User ID=sa;Password=mira@@1; Persist Security Info=false;Connection Timeout=30;");
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connStr"].ToString());
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@IP_address", ip);
            cmd.Parameters.AddWithValue("@form", form);
            cmd.Parameters.AddWithValue("@created_on_client", DateTime.Now);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
