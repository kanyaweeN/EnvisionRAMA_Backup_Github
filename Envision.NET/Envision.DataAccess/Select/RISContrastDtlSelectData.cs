using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class RISContrastDtlSelectData : DataAccessBase 
	{
        public RIS_CONTRASTDTL RIS_CONTRASTDTL { get; set; }
        public RISContrastDtlSelectData()
		{
            RIS_CONTRASTDTL = new RIS_CONTRASTDTL();
		}
        public DataSet GetData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTDTL_Select;
            DbParameter[] parameters ={
Parameter("@CONTRASTDTL_ID",RIS_CONTRASTDTL.CONTRASTDTL_ID),
            };
            ParameterList = parameters;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataByOrderId()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTDTL_SelectByOrderId;
            DbParameter[] parameters ={
Parameter("@ORDER_ID",RIS_CONTRASTDTL.ORDER_ID),
            };
            ParameterList = parameters;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataByScheduleId()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTDTL_SelectByScheduleId;
            DbParameter[] parameters ={
Parameter("@SCHEDULE_ID",RIS_CONTRASTDTL.SCHEDULE_ID),
            };
            ParameterList = parameters;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataByDate(DateTime dateFrom, DateTime dateTo)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTDTL_SelectByDate;
            DbParameter[] parameters ={
Parameter("@DATE_FROM",dateFrom),
Parameter("@DATE_TO",dateTo),
            };
            ParameterList = parameters;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
		public DataSet GetReactionData()
		{
            StoredProcedureName = StoredProcedure.Prc_ContrastAcuteReaction_Select;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataSet GetSymptomData()
		{
            StoredProcedureName = StoredProcedure.Prc_ContrastSymptom_Select;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataSet GetDataByRegId(int regId)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTDTL_SelectByRegId;
            DbParameter[] parameters ={
Parameter("@REG_ID",regId),
            };
            ParameterList = parameters;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataByHN(string hn)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTDTL_SelectByHn;
            DbParameter[] parameters ={
Parameter("@HN",hn),
            };
            ParameterList = parameters;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
	}
}