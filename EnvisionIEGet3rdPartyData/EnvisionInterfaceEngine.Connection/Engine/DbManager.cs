using System;
using System.Data.Common;
using EnvisionInterfaceEngine.Operational;

namespace EnvisionInterfaceEngine.Connection.Engine
{
    public class DbManager
    {
        public static void SaveLog(string titleLog, string caption, string query, DbParameter[] parameters, Exception ex)
        {
            string message_log = string.Empty;

            message_log += "\r\n";
            message_log += query;
            message_log += "\r\n";
            message_log += "\r\n";

            if (Utilities.HasData(parameters))
            {
                foreach (DbParameter parameter in parameters)
                    message_log += string.Format("{0} = {1}\r\n", parameter.ParameterName, parameter.Value);

                message_log += "\r\n";
            }
            message_log += ex.ToString();

            Utilities.SaveLog(titleLog, caption, message_log, true);
        }
    }
}
