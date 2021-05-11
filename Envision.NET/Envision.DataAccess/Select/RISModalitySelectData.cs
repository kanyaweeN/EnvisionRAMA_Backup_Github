using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISModalitySelectData : DataAccessBase 
	{
        public RIS_MODALITY RIS_MODALITY { get; set; }
		public  RISModalitySelectData()
		{
            RIS_MODALITY = new RIS_MODALITY();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_Select;
		}
        public RISModalitySelectData(bool selectAll) {
            RIS_MODALITY = new RIS_MODALITY();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_SelectAll;
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
        public DataSet GetData_forAIMC()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_Select_forAIMC;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet(); 
            return ds;
        }
        public DataSet GetData_forIntervention()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_Select_forIntervention;

            ParameterList = new DbParameter[]
                                        { 
                                                Parameter("@MODALITY_ID"     ,   RIS_MODALITY.MODALITY_ID)
                                       };
            DataSet ds = new DataSet();

            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetCheckDuplicateIsDefault(int EXAM_ID, int MODALITY_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_CheckDuplicateIsDefaultSelect;
            ParameterList = new DbParameter[] 
                { 
                        Parameter("@EXAM_ID",EXAM_ID) 
                        ,Parameter("@MODALITY_ID",MODALITY_ID) 
                };

            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetModalityForExamSetup(int EXAM_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_SelectByExamSetup;
            ParameterList = new DbParameter[] 
                { 
                        Parameter("@EXAM_ID", EXAM_ID) 
                };
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
	}
}

