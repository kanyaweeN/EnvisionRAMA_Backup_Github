//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    04/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class RISServicetypeDeleteData : DataAccessBase 
	{
		private RISServicetypeDeleteDataParameters	_risservicetypeinsertdataparameters;
        private int serviceTypeID;

		public  RISServicetypeDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_SERVICETYPE_Delete.ToString();
		}
		public  int	ServicetypeID
		{
            get { return serviceTypeID; }
            set { serviceTypeID = value; }
		}

		public void Delete()
		{
            _risservicetypeinsertdataparameters = new RISServicetypeDeleteDataParameters(serviceTypeID);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risservicetypeinsertdataparameters.Parameters);
		}
	}
	public class RISServicetypeDeleteDataParameters 
	{
        private int serviceTypeID;
		private SqlParameter[] _parameters;
        public RISServicetypeDeleteDataParameters(int serviceTypeID)
		{
            this.serviceTypeID = serviceTypeID;
			Build();
		}

		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 
                new SqlParameter("@SERVICE_TYPE_ID",this.serviceTypeID )};
			Parameters = parameters;
		}
	}
}

