using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionInterfaceEngine.Connection.Engine;
using System.Data;

namespace EnvisionInterfaceEngine.Connection
{
    public class JPGConnection : MsSqlEngine
    {
        private const string title_log = "EnvisionInterfaceEngine.Connection.iMedConnection";

        public JPGConnection() : base() { }
        public JPGConnection(string connectionString) : base(connectionString) { }
        ~JPGConnection() { base.Dispose(); }

        public DataTable getData()
        {
            string query = @"
    select * from vwPatientModalities
";
            Parameters = null;

            return SelectData(query);
        }
    }
}
