using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
    public class RISPatstatusSeleteDataN : DataAccessBase
    {
       private RISPatstatus	_rispatstatus;
		private RISPatstatusSeleteDataNParameters param;
        public RISPatstatusSeleteDataN()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_PATSTATUSN_Select.ToString();
		}
        public RISPatstatus RISPatstatus
		{
            get { return _rispatstatus; }
            set { _rispatstatus = value; }
		}
		public DataSet GetData()
		{
            param = new RISPatstatusSeleteDataNParameters(RISPatstatus);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISPatstatusSeleteDataNParameters 
	{
		private RISPatstatus _rispatstatus;
		private SqlParameter[] _parameters;
        public RISPatstatusSeleteDataNParameters(RISPatstatus rispatstatus)
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
                new SqlParameter("@selectcase",RISPatstatus.SELECTCASE)
                ,new SqlParameter("@STATUS_UID",RISPatstatus.STATUS_UID)
			};
			_parameters=parameters;
		}
    }
}
