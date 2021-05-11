//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    09/06/2552 02:38:17
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISClinicsessionSelectData : DataAccessBase 
	{
		private RISClinicsession	_risclinicsession;
		public  RISClinicsessionSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_CLINICSESSION_Select.ToString();
		}
		public  RISClinicsession	RISClinicsession
		{
			get{return _risclinicsession;}
			set{_risclinicsession=value;}
		}
		public DataSet GetData()
		{
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString);
			return ds;
		}
        public DataSet GetScheduleSession() {
            RISClinicsessionScheduleSelectDataParameters param = new RISClinicsessionScheduleSelectDataParameters(RISClinicsession);
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_SCHEDULE_Session.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
            return ds;
        }
	}
	public class RISClinicsessionScheduleSelectDataParameters 
	{
		private RISClinicsession _risclinicsession;
		private SqlParameter[] _parameters;
        public RISClinicsessionScheduleSelectDataParameters(RISClinicsession risclinicsession)
		{
			RISClinicsession=risclinicsession;
			Build();
		}
		public  RISClinicsession	RISClinicsession
		{
			get{return _risclinicsession;}
			set{_risclinicsession=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
                new SqlParameter("@MODALITY_ID",RISClinicsession.MODALITY_ID)
                ,new SqlParameter("@WEEKDAY",RISClinicsession.WEEKDAYS)
                ,new SqlParameter("@ORG_ID",RISClinicsession.ORG_ID)
			};
			_parameters=parameters;
		}
	}
}

