using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Configuration;

namespace EnvisionInterface.Common.Linq
{
    [System.Data.Linq.Mapping.DatabaseAttribute(Name = "RIS_RAMA")]
    public partial class EnvisionDataContext : System.Data.Linq.DataContext
    {
        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion

        public EnvisionDataContext() :
            base(ConfigurationSettings.AppSettings["connStr"], mappingSource)
        {
            OnCreated();
        }

        public EnvisionDataContext(string connection) :
            base(connection, mappingSource)
        {
            OnCreated();
        }

        public EnvisionDataContext(System.Data.IDbConnection connection) :
            base(connection, mappingSource)
        {
            OnCreated();
        }

        public EnvisionDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            OnCreated();
        }

        public EnvisionDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            OnCreated();
        }
    }
}
