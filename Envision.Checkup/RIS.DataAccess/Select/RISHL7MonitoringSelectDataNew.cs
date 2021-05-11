using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISHL7MonitoringSelectDataNew : DataAccessBase
    {
        
        		private HL7MonitoringNew	_hl7monitoringnew;
		private RISHL7MonitoringSelectDataNewParameters param;
        public RISHL7MonitoringSelectDataNew()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ResendBilling.ToString();
		}
        public HL7MonitoringNew HL7MonitoringNew
		{
            get { return _hl7monitoringnew; }
            set { _hl7monitoringnew = value; }
		}
		public DataSet GetData()
		{
            param = new RISHL7MonitoringSelectDataNewParameters(HL7MonitoringNew);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISHL7MonitoringSelectDataNewParameters 
	{
		private HL7MonitoringNew _hl7monitoringnew;
		private SqlParameter[] _parameters;
        public RISHL7MonitoringSelectDataNewParameters(HL7MonitoringNew hl7monitoringnew)
		{
            HL7MonitoringNew = hl7monitoringnew;
			Build();
		}
        public HL7MonitoringNew HL7MonitoringNew
		{
            get { return _hl7monitoringnew; }
            set { _hl7monitoringnew = value; }
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter FROM_DATE = new SqlParameter();
            FROM_DATE.ParameterName = "@FROM_DATE";
            if (HL7MonitoringNew.FROM_DATE == DateTime.MinValue)
                FROM_DATE.Value = DBNull.Value;
            else
                FROM_DATE.Value = HL7MonitoringNew.FROM_DATE;

            SqlParameter TO_DATE = new SqlParameter();
            TO_DATE.ParameterName = "@TO_DATE";
            if (HL7MonitoringNew.TO_DATE == DateTime.MinValue)
                TO_DATE.Value = DBNull.Value;
            else
                TO_DATE.Value = HL7MonitoringNew.TO_DATE;

			SqlParameter[] parameters ={			
				new SqlParameter( "@SP_Types"	, HL7MonitoringNew.SP_TYPES ),
                new SqlParameter( "@MSG_TYPE"		    , HL7MonitoringNew.MSG_TYPE ) ,
				new SqlParameter( "@ORG_ID"        , HL7MonitoringNew.ORG_ID ),
                FROM_DATE,
				TO_DATE
			};
			_parameters=parameters;
		}
    }
}
