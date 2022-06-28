//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:26
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISLoadmediaInsertData : DataAccessBase 
	{
        public RIS_LOADMEDIA RIS_LOADMEDIA { get; set; }
        int _id = 0;
		public  RISLoadmediaInsertData()
		{
            RIS_LOADMEDIA = new RIS_LOADMEDIA();
			StoredProcedureName = StoredProcedure.Prc_RIS_LOADMEDIA_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
            _id = (int)ParameterList[0].Value;
		}
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
            _id = (int)ParameterList[0].Value;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter param1 = Parameter("@LOAD_ID", RIS_LOADMEDIA.LOAD_ID);
            param1.Direction = ParameterDirection.Output;

            DbParameter LoadStart = Parameter();
            LoadStart.ParameterName = "@LOAD_START_TIME";
            if (RIS_LOADMEDIA.LOAD_START_TIME == null)
                LoadStart.Value = DBNull.Value;
            else
                LoadStart.Value = RIS_LOADMEDIA.LOAD_START_TIME == DateTime.MinValue ? (object)DBNull.Value : RIS_LOADMEDIA.LOAD_START_TIME;

            DbParameter REQBy = Parameter();
            REQBy.ParameterName = "@REQ_BY";
            if (string.IsNullOrEmpty(RIS_LOADMEDIA.REQ_BY.ToString()))
                REQBy.Value = "N";
            else
                REQBy.Value = RIS_LOADMEDIA.REQ_BY.ToString() == "0" ? "N" : RIS_LOADMEDIA.REQ_BY.ToString();

            DbParameter MediaType = Parameter();
            MediaType.ParameterName = "@MEDIA_TYPE";
            if (string.IsNullOrEmpty(RIS_LOADMEDIA.MEDIA_TYPE.ToString()))
                MediaType.Value = "N";
            else
                MediaType.Value = RIS_LOADMEDIA.MEDIA_TYPE.ToString() == "0" ? "N" : RIS_LOADMEDIA.MEDIA_TYPE.ToString();

            DbParameter Reason = Parameter();
            Reason.ParameterName = "@CREATED_ON";
            if (string.IsNullOrEmpty(RIS_LOADMEDIA.REASON.ToString()))
                Reason.Value = "N";
            else
                Reason.Value = RIS_LOADMEDIA.REASON.ToString() == "0" ? "N" : RIS_LOADMEDIA.REASON.ToString();

            DbParameter createOn = Parameter();
            createOn.ParameterName = "@LMP_DT";
            if (RIS_LOADMEDIA.CREATED_ON == null)
                createOn.Value = DBNull.Value;
            else
                createOn.Value = RIS_LOADMEDIA.CREATED_ON == DateTime.MinValue ? (object)DBNull.Value : RIS_LOADMEDIA.CREATED_ON;

            DbParameter[] parameters ={			
			    param1
            ,Parameter("@HN",RIS_LOADMEDIA.HN)
            ,Parameter("@VISIT_NO",RIS_LOADMEDIA.VISIT_NO)
            ,Parameter("@ADMISSION_NO",RIS_LOADMEDIA.ADMISSION_NO)
            ,LoadStart
            ,REQBy
            ,Parameter("@REQ_UNIT",RIS_LOADMEDIA.REQ_UNIT)
            ,Parameter("@REQ_DOC",RIS_LOADMEDIA.REQ_DOC)
            ,MediaType
            ,Reason
            ,Parameter("@COMMENT",RIS_LOADMEDIA.COMMENT)
            ,Parameter("@CREATED_BY",RIS_LOADMEDIA.CREATED_BY)
            ,Parameter("@LAST_MODIFIED_BY",RIS_LOADMEDIA.LAST_MODIFIED_BY)
			            };
            return parameters;
        }
        public int GetID()
        {
            return _id;
        }
	}
}

