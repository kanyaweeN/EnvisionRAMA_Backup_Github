using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISPaticdSelectData : DataAccessBase 
	{
		private RISPaticd	_rispaticd;
		private RISPaticdInsertDataParameters	_rispaticdinsertdataparameters;
        private int action = 0;

		public  RISPaticdSelectData()
		{
            _rispaticd = new RISPaticd();
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_PATICD_Select.ToString();
            action = 0;
		}
        public RISPaticdSelectData(int OrderID)
        {
            _rispaticd = new RISPaticd();
            _rispaticd.ORDER_NO = OrderID;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_PATICD_SelectByOrder.ToString();
            action = 1;
        }

		public  RISPaticd	RISPaticd
		{
			get{return _rispaticd;}
			set{_rispaticd=value;}
		}

		public DataSet GetData()
		{
            _rispaticdinsertdataparameters = null;// new RISPaticdInsertDataParameters(RISPaticd);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds=null;
            if (action == 0)
                ds = dbhelper.Run(base.ConnectionString);
            else if (action == 1)
            {
                _rispaticdinsertdataparameters = new RISPaticdInsertDataParameters(_rispaticd);
                ds = dbhelper.Run(base.ConnectionString, _rispaticdinsertdataparameters.Parameters);
            }
			return ds;
		}
	}
	public class RISPaticdInsertDataParameters 
	{
		private RISPaticd _rispaticd;
		private SqlParameter[] _parameters;
		public RISPaticdInsertDataParameters(RISPaticd rispaticd)
		{
			RISPaticd=rispaticd;
			Build();
		}
		public  RISPaticd	RISPaticd
		{
			get{return _rispaticd;}
			set{_rispaticd=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={
                //new SqlParameter("@PAT_ICD_ID",RISPaticd.PAT_ICD_ID)
                //,new SqlParameter("@ICD_ID",RISPaticd.ICD_ID)
                //,new SqlParameter("@HN",RISPaticd.HN)
                new SqlParameter("@ORDER_ID",RISPaticd.ORDER_NO)
                //,new SqlParameter("@ACCESSION_NO",RISPaticd.ACCESSION_NO)
                //,new SqlParameter("@ORDER_RESULT_FLAG",RISPaticd.ORDER_RESULT_FLAG)
                //,new SqlParameter("@ORG_ID",RISPaticd.ORG_ID)
                //,new SqlParameter("@CREATED_BY",RISPaticd.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",RISPaticd.CREATED_ON)
                //,new SqlParameter("@LAST_MODIFIED_BY",RISPaticd.LAST_MODIFIED_BY)
                //,new SqlParameter("@LAST_MODIFIED_ON",RISPaticd.LAST_MODIFIED_ON)
            };
			Parameters = parameters;
		}
	}
}

