using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISLoadmediaUpdateData : DataAccessBase 
	{
        public RIS_LOADMEDIA RIS_LOADMEDIA { get; set; }
		public  RISLoadmediaUpdateData()
		{
            RIS_LOADMEDIA = new RIS_LOADMEDIA();
			StoredProcedureName = StoredProcedure.Prc_RIS_LOADMEDIA_Update;
		}
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter LoadDT = Parameter();
            LoadDT.ParameterName = "@LOAD_DT";
            if (RIS_LOADMEDIA.LOAD_DT == null)
                LoadDT.Value = DBNull.Value;
            else
                LoadDT.Value = RIS_LOADMEDIA.LOAD_DT == DateTime.MinValue ? (object)DBNull.Value : RIS_LOADMEDIA.LOAD_DT;

            DbParameter LoadStart = Parameter();
            LoadStart.ParameterName = "@LOAD_START_TIME";
            if (RIS_LOADMEDIA.LOAD_START_TIME == null)
                LoadStart.Value = DBNull.Value;
            else
                LoadStart.Value = RIS_LOADMEDIA.LOAD_START_TIME == DateTime.MinValue ? (object)DBNull.Value : RIS_LOADMEDIA.LOAD_START_TIME;

            DbParameter REQBy = Parameter();
            REQBy.ParameterName = "@REQ_BY";
            if (RIS_LOADMEDIA.REQ_BY == null)
                REQBy.Value = DBNull.Value;
            else
                REQBy.Value = RIS_LOADMEDIA.REQ_BY == 0 ? (object)DBNull.Value : RIS_LOADMEDIA.REQ_BY;

            DbParameter MediaType = Parameter();
            MediaType.ParameterName = "@MEDIA_TYPE";
            if (RIS_LOADMEDIA.MEDIA_TYPE == null)
                MediaType.Value = DBNull.Value;
            else
                MediaType.Value = RIS_LOADMEDIA.MEDIA_TYPE == 0 ? (object)DBNull.Value : RIS_LOADMEDIA.MEDIA_TYPE;

            DbParameter Reason = Parameter();
            Reason.ParameterName = "@REASON";
            if (RIS_LOADMEDIA.REASON == null)
                Reason.Value = DBNull.Value;
            else
                Reason.Value = RIS_LOADMEDIA.REASON == 0 ? (object)DBNull.Value : RIS_LOADMEDIA.REASON;

            DbParameter createOn = Parameter();
            createOn.ParameterName = "@CREATED_ON";
            if (RIS_LOADMEDIA.CREATED_ON == null)
                createOn.Value = DBNull.Value;
            else
                createOn.Value = RIS_LOADMEDIA.CREATED_ON == DateTime.MinValue ? (object)DBNull.Value : RIS_LOADMEDIA.CREATED_ON;

            DbParameter modifyOn = Parameter();
            modifyOn.ParameterName = "@LAST_MODIFIED_ON";
            if (RIS_LOADMEDIA.LAST_MODIFIED_ON == null)
                modifyOn.Value = DBNull.Value;
            else
                modifyOn.Value = RIS_LOADMEDIA.LAST_MODIFIED_ON == DateTime.MinValue ? (object)DBNull.Value : RIS_LOADMEDIA.LAST_MODIFIED_ON;


            DbParameter[] parameters ={
Parameter("@LOAD_ID" ,RIS_LOADMEDIA.LOAD_ID)
,Parameter("@HN",RIS_LOADMEDIA.HN)
,Parameter("@VISIT_NO",RIS_LOADMEDIA.VISIT_NO)
,Parameter("@ADMISSION_NO",RIS_LOADMEDIA.ADMISSION_NO)
,LoadDT
,LoadStart
,REQBy
,Parameter("@REQ_UNIT",RIS_LOADMEDIA.REQ_UNIT)
,Parameter("@REQ_DOC",RIS_LOADMEDIA.REQ_DOC)
,MediaType
,Reason
,Parameter("@COMMENT",RIS_LOADMEDIA.COMMENT)
,Parameter("@CREATED_BY",RIS_LOADMEDIA.CREATED_BY)
,createOn
,Parameter("@LAST_MODIFIED_BY",RIS_LOADMEDIA.LAST_MODIFIED_BY)
,modifyOn
                                      };
            return parameters;
        }
	}
}

