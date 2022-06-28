using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISStudyLibrarySelectData : DataAccessBase 
	{
        public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }

        public RISStudyLibrarySelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_STUDYLIBRARY_SelectNew;
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = 
                { 
                    Parameter("@MODE",RIS_STUDYLIBRARY.MODE)
                    ,Parameter("@ACCESSION_NO",RIS_STUDYLIBRARY.ACCESSION_NO)
                    ,Parameter("@RADIOLOGIST_ID",new GBLEnvVariable().UserID)
                    ,Parameter("@DateFrom",RIS_STUDYLIBRARY.DateFrom)
                    ,Parameter("@DateTo",RIS_STUDYLIBRARY.DateTo)
                    ,Parameter("@HN",RIS_STUDYLIBRARY.HN)
               };
            return parameters;
        }

        public DataSet GetDataACR()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_STUDYLIBRARYACR_Select;
            ParameterList = new DbParameter[]
            {
                Parameter("@ACCESSION_NO",RIS_STUDYLIBRARY.ACCESSION_NO),
                Parameter("@RADIOLOGIST_ID",new GBLEnvVariable().UserID)
            };

            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataBodyPart()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_STUDYLIBRARYBODYPART_Select;
            ParameterList = new DbParameter[]
            {
                Parameter("@ACCESSION_NO",RIS_STUDYLIBRARY.ACCESSION_NO),
                Parameter("@RADIOLOGIST_ID",new GBLEnvVariable().UserID)
            };

            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataCPT()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_STUDYLIBRARYCPT_Select;
            ParameterList = new DbParameter[]
            {
                Parameter("@ACCESSION_NO",RIS_STUDYLIBRARY.ACCESSION_NO),
                Parameter("@RADIOLOGIST_ID",new GBLEnvVariable().UserID)
            };

            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataICD()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_STUDYLIBRARYICD_Select;
            ParameterList = new DbParameter[]
            {
                Parameter("@ACCESSION_NO",RIS_STUDYLIBRARY.ACCESSION_NO),
                Parameter("@RADIOLOGIST_ID",new GBLEnvVariable().UserID)
            };

            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataShareWith()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_STUDYLIBRARYSHAREWITH_Select;
            ParameterList = new DbParameter[]
            {
                Parameter("@ACCESSION_NO",RIS_STUDYLIBRARY.ACCESSION_NO),
                Parameter("@RADIOLOGIST_ID",new GBLEnvVariable().UserID)
            };

            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataTags()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_STUDYLIBRARYTAGS_Select;
            ParameterList = new DbParameter[]
            {
                Parameter("@ACCESSION_NO",RIS_STUDYLIBRARY.ACCESSION_NO),
                Parameter("@RADIOLOGIST_ID",new GBLEnvVariable().UserID)
            };

            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataConference()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_STUDYLIBRARYCONFERENCE_Select;
            ParameterList = new DbParameter[]
            {
                Parameter("@ACCESSION_NO",RIS_STUDYLIBRARY.ACCESSION_NO),
                Parameter("@RADIOLOGIST_ID",new GBLEnvVariable().UserID)
            };

            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
	}
}

