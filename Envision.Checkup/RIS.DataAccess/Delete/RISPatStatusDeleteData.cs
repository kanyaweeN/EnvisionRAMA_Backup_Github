using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;


namespace RIS.DataAccess.Delete
{
    public class RISPatStatusDeleteData : DataAccessBase
    {
        private RISPatstatus	_rispatstatus;
        private RISPatStatusDeleteDataParameters param;
        public RISPatStatusDeleteData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_PATSTATUS_Delete.ToString();
		}
        public RISPatstatus RISPatstatus
		{
            get { return _rispatstatus; }
            set { _rispatstatus = value; }
		}
		public bool Delete()
		{
            param = new RISPatStatusDeleteDataParameters(RISPatstatus);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
	}
	public class RISPatStatusDeleteDataParameters 
	{
        private RISPatstatus _rispatstatus;
		private SqlParameter[] _parameters;
        public RISPatStatusDeleteDataParameters(RISPatstatus rispatstatus)
		{
            RISPatstatus = rispatstatus;
			Build();
		}
        public RISPatstatus RISPatstatus
		{
            get { return _rispatstatus; }
            set { _rispatstatus = value; }
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
new SqlParameter("@STATUS_ID",RISPatstatus.STATUS_ID)
			};
			_parameters = parameters;
		}
    }
}
