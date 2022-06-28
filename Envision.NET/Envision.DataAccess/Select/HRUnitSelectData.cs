using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class HRUnitSelectData : DataAccessBase 
	{
		public  HRUnit	HRUnit{get;set;}
		public  HRUnitSelectData()
		{
            HRUnit = new HRUnit();
            StoredProcedureName = StoredProcedure.Prc_HR_UNIT_Select;
		}
		
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataSet GetDataCNMI()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet2();
            return ds;
        }
        public DataSet GetDataByID(int unit_id)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_HR_UNIT_SelectByID;
            ParameterList = new DbParameter[] 
            { 
                Parameter("@UNIT_ID",unit_id)
            };
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataByUID(string unit_uid)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_HR_UNIT_SelectByUID;
            ParameterList = new DbParameter[] 
            { 
                Parameter("@UNIT_UID",unit_uid)
            };
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetData_forAIMC()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_HR_UNIT_Select_forAIMC;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetData_forRadiologistWorklist()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_HR_UNIT_Select_forRadiologistWorklist;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetData_WithUnitType()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_HR_UNIT_Select_WithUnitType;
            ds = ExecuteDataSet();
            return ds;
        }
	}
}

