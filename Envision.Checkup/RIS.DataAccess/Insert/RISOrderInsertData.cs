//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    24/03/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using System.Data.Sql;
using System.Data.SqlTypes;

using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class RISOrderInsertData : DataAccessBase 
	{
		private RISOrder	_risorder;
		private RISOrderInsertDataParameters	_risorderinsertdataparameters;
		public  RISOrderInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_Insert.ToString();
		}
		public  RISOrder	RISOrder
		{
			get{return _risorder;}
			set{_risorder=value;}
		}
		public int Add()
		{
			_risorderinsertdataparameters = new RISOrderInsertDataParameters(RISOrder);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //object id = dbhelper.RunScalar(base.ConnectionString,_risorderinsertdataparameters.Parameters);
            dbhelper.Run(_risorderinsertdataparameters.Parameters);
            return (int)_risorderinsertdataparameters.Parameters[0].Value;
		}
        public int Add(SqlTransaction tran) {
            _risorderinsertdataparameters = new RISOrderInsertDataParameters(RISOrder);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //object id = dbhelper.RunScalar(base.ConnectionString,_risorderinsertdataparameters.Parameters);
            dbhelper.Run(tran, _risorderinsertdataparameters.Parameters);

            return (int)_risorderinsertdataparameters.Parameters[0].Value;
        }
	}
	public class RISOrderInsertDataParameters 
	{
		private RISOrder _risorder;
		private SqlParameter[] _parameters;
		public RISOrderInsertDataParameters(RISOrder risorder)
		{
			RISOrder=risorder;
			Build();
		}
		public  RISOrder	RISOrder
		{
			get{return _risorder;}
			set{_risorder=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter param1 = new SqlParameter("@ORDER_ID", RISOrder.ORDER_ID);
            param1.Direction = ParameterDirection.Output;

            SqlParameter param2 = new SqlParameter("@REG_ID", RISOrder.REG_ID);

            SqlParameter param3 = new SqlParameter("@HN",RISOrder.HN);

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@VISIT_NO";
            if(RISOrder.VISIT_NO == null || RISOrder.VISIT_NO == string.Empty )
                param4.Value =  DBNull.Value;
            else
                param4.Value = RISOrder.VISIT_NO;
           
            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@ADMISSION_NO";
            if (RISOrder.ADMISSION_NO == null || RISOrder.ADMISSION_NO == string.Empty)
                param5.Value = DBNull.Value;
            else
                param5.Value = RISOrder.ADMISSION_NO;

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "@ORDER_DT";
            if(RISOrder.ORDER_DT==DateTime.MinValue)
                param6.Value = DBNull.Value ;
            else
                param6.Value=RISOrder.ORDER_DT;

            SqlParameter param7 = new SqlParameter();
            param7.ParameterName = "@ORDER_START_TIME";
            if (RISOrder.ORDER_START_TIME == DateTime.MinValue)
                param7.Value = DBNull.Value;
            else
                param7.Value = RISOrder.ORDER_START_TIME;

            SqlParameter param8 = new SqlParameter();
            param8.ParameterName = "@SCHEDULE_ID";
            if(RISOrder.SCHEDULE_ID==0 )
                param8.Value = DBNull.Value ;
            else
                param8.Value = RISOrder.SCHEDULE_ID;

            SqlParameter param91 = new SqlParameter();
            param91.ParameterName = "@REF_UNIT";
            if (RISOrder.REF_UNIT == 0 )
                param91.Value = DBNull.Value; 
            else
                param91.Value = RISOrder.REF_UNIT;

            SqlParameter param92 = new SqlParameter();
            param92.ParameterName = "@REF_DOC";
            if (RISOrder.REF_DOC == 0)
                param92.Value = DBNull.Value;
            else
                param92.Value = RISOrder.REF_DOC;
            
            SqlParameter param10 = new SqlParameter();
            param10.ParameterName = "@REF_DOC_INSTRUCTION";
            if(RISOrder.REF_DOC_INSTRUCTION == null || RISOrder.REF_DOC_INSTRUCTION == string.Empty)
                param10.Value = DBNull.Value;
            else
                param10.Value = RISOrder.REF_DOC_INSTRUCTION;
            
            SqlParameter param11 = new SqlParameter();
            param11.ParameterName = "@CLINICAL_INSTRUCTION";
            if (RISOrder.CLINICAL_INSTRUCTION == null || RISOrder.CLINICAL_INSTRUCTION == string.Empty)
                param11.Value = DBNull.Value;
            else
                param11.Value = RISOrder.CLINICAL_INSTRUCTION;
           
            SqlParameter param12 = new SqlParameter();
            param12.ParameterName = "@REASON";
            if(RISOrder.REASON == null || RISOrder.REASON == string.Empty )
                param12.Value =  DBNull.Value ;
            else
                param12.Value = RISOrder.REASON;
            
            SqlParameter param13 = new SqlParameter();
            param13.ParameterName = "@DIAGNOSIS";
            if (RISOrder.DIAGNOSIS == null || RISOrder.DIAGNOSIS == string.Empty)
                param13.Value = DBNull.Value;
            else
                param13.Value = RISOrder.DIAGNOSIS;
           
            SqlParameter param14 = new SqlParameter();
            param14.ParameterName = "@ICD_ID";
            if(RISOrder.ICD_ID == 0 )
                param14.Value =  DBNull.Value;
            else
                param14.Value = RISOrder.ICD_ID;

            //SqlParameter param15 = new SqlParameter();
            //param15.ParameterName = "@ARRIVAL_BY";
            //if(RISOrder.ARRIVAL_BY == 0)
            //    param15.Value = DBNull.Value ;
            //else
            //    param15.Value = RISOrder.ARRIVAL_BY;

            //SqlParameter param16 = new SqlParameter();
            //param16.ParameterName = "@ARRIVAL_ON";
            //if (RISOrder.ARRIVAL_ON == DateTime.MinValue)
            //    param16.Value = DBNull.Value;
            //else
            //    param16.Value = RISOrder.ARRIVAL_ON;

            //SqlParameter param17 = new SqlParameter();
            //param17.ParameterName = "@SELF_ARRIVAL";
            //if(RISOrder.SELF_ARRIVAL == null || RISOrder.VISIT_NO == string.Empty )
            //    param17.Value = DBNull.Value;
            //else
            //    param17.Value = RISOrder.SELF_ARRIVAL;

            SqlParameter param18 = new SqlParameter();
            param18.ParameterName = "@ORG_ID";
            if (RISOrder.ORG_ID == 0)
                param18.Value = DBNull.Value;
            else
                param18.Value = RISOrder.ORG_ID;

            SqlParameter param19 = new SqlParameter();
            param19.ParameterName = "@CREATED_BY";
            if(RISOrder.CREATED_BY == 0)
                param19.Value = DBNull.Value;
            else
                param19.Value = RISOrder.CREATED_BY;

            SqlParameter param20 = new SqlParameter();
            param20.ParameterName = "@INSURANCE_TYPE_ID";
            if (RISOrder.INSURANCE_TYPE_ID == 0)
                param20.Value = DBNull.Value;
            else
                param20.Value = RISOrder.INSURANCE_TYPE_ID;

            SqlParameter pPAT_STATUS = new SqlParameter();
            pPAT_STATUS.ParameterName = "@PAT_STATUS";
            if (RISOrder.PAT_STATUS == string.Empty || RISOrder.PAT_STATUS == null)
                pPAT_STATUS.Value = DBNull.Value;
            else
                pPAT_STATUS.Value = RISOrder.PAT_STATUS;


            SqlParameter pLMP_DT = new SqlParameter();
            pLMP_DT.ParameterName = "@LMP_DT";
            if (RISOrder.Lmp_DT == DateTime.MinValue)
                pLMP_DT.Value = DBNull.Value;
            else
                pLMP_DT.Value = RISOrder.Lmp_DT;
			SqlParameter[] parameters ={
                param1          ,param2         ,param3         ,param4
                ,param5         ,param6         ,param7         ,param8
                ,param91        ,param92        ,param10        ,param11        ,param12
                ,param13        ,param14        //,param15        ,param16      ,param17        
                ,param18        ,param19        ,param20        ,pPAT_STATUS    ,pLMP_DT
            };
			Parameters = parameters;
		}
	}
}

