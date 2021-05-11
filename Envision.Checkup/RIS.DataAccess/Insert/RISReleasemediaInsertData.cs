//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:27
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class RISReleasemediaInsertData : DataAccessBase
    {
        private RISReleasemedia _risreleasemedia;
        int _id = 0;
        private RISReleasemediaInsertDataParameters param;
        public RISReleasemediaInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_RELEASEMEDIA_Insert.ToString();
        }
        public RISReleasemedia RISReleasemedia
        {
            get { return _risreleasemedia; }
            set { _risreleasemedia = value; }
        }
        public void Add()
        {
            param = new RISReleasemediaInsertDataParameters(RISReleasemedia);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(base.ConnectionString, param.Parameters);
            _id = (int)param.Parameters[0].Value;
        }
        public void Add(SqlTransaction tran)
        {
            param = new RISReleasemediaInsertDataParameters(RISReleasemedia);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(tran, param.Parameters);
            _id = (int)param.Parameters[0].Value;
        }
        public int GetID()
        {
            return _id;
        }
    }
    public class RISReleasemediaInsertDataParameters
    {
        private RISReleasemedia _risreleasemedia;
        private SqlParameter[] _parameters;
        public RISReleasemediaInsertDataParameters(RISReleasemedia risreleasemedia)
        {
            RISReleasemedia = risreleasemedia;
            Build();
        }
        public RISReleasemedia RISReleasemedia
        {
            get { return _risreleasemedia; }
            set { _risreleasemedia = value; }
        }
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
        public void Build()
        {
            SqlParameter Release_Date = new SqlParameter();
            Release_Date.ParameterName = "@RELEASE_DATE";
            if (RISReleasemedia.RELEASE_DATE == DateTime.MinValue)
            {
                Release_Date.Value = DateTime.Now;
            }
            else
            {
                Release_Date.Value = RISReleasemedia.RELEASE_DATE;
            }

            SqlParameter Request_By = new SqlParameter();
            Request_By.ParameterName = "@REQUEST_BY";
            if (RISReleasemedia.REQUEST_BY == "0")
            {
                Request_By.Value = "N";
            }
            else
            {
                Request_By.Value = RISReleasemedia.REQUEST_BY;
            }
            SqlParameter MediaType = new SqlParameter();
            MediaType.ParameterName = "@MEDIA_TYPE";
            if (RISReleasemedia.MEDIA_TYPE == "0" || RISReleasemedia.MEDIA_TYPE == null)
            {
                MediaType.Value = "0";
            }
            else
            {
                MediaType.Value = RISReleasemedia.MEDIA_TYPE;
            }

            SqlParameter Reason = new SqlParameter();
            Reason.ParameterName = "@REASON";
            if (RISReleasemedia.REASON == "0" || RISReleasemedia.REASON == null)
            {
                Reason.Value = "N";
            }
            else
            {
                Reason.Value = RISReleasemedia.REASON;
            }


            SqlParameter param1 = new SqlParameter("@RELEASE_ID", RISReleasemedia.RELEASE_ID);
            param1.Direction = ParameterDirection.Output;

            SqlParameter[] parameters ={
                param1
                ,new SqlParameter("@ORDER_ID",RISReleasemedia.ORDER_ID)
                ,new SqlParameter("@EXAM_ID",RISReleasemedia.EXAM_ID)
			    ,new SqlParameter("@HN",RISReleasemedia.HN)
                ,Release_Date
                ,Request_By
                ,new SqlParameter("@REQUEST_BY_ID",RISReleasemedia.REQUEST_BY_ID)
                ,MediaType
                ,new SqlParameter("@RECEIVED_BY",RISReleasemedia.RECEIVED_BY)
                ,Reason
                ,new SqlParameter("@COMMENT",RISReleasemedia.COMMENT)
                ,new SqlParameter("@UNIT_ID",RISReleasemedia.UNIT_ID)
                ,new SqlParameter("@CREATED_BY",RISReleasemedia.CREATED_BY)
                ,new SqlParameter("@LAST_MODIFIED_BY",RISReleasemedia.LAST_MODIFIED_BY)
                ,new SqlParameter("@QTY",RISReleasemedia.QTY)
			};
            _parameters = parameters;
        }
    }
}

