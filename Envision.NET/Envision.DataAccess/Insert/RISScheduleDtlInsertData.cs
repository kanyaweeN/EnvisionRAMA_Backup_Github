using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RISScheduleDtlInsertData : DataAccessBase 
    {
        public RIS_SCHEDULEDTL RIS_SCHEDULEDTL { get; set; }

        public RISScheduleDtlInsertData() {
            RIS_SCHEDULEDTL = new RIS_SCHEDULEDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULEDTL_InsertNew;
        }
        public bool Add() {
            try
            {
                ParameterList = buildParameter();
                DataSet ds = new DataSet();
                ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool AddCNMI()
        {
            try
            {
                ParameterList = buildParameter();
                DataSet ds = new DataSet();
                ExecuteNonQuery2();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        private DbParameter[] buildParameter() {
            DbParameter GEN_DTL_ID = Parameter();
            GEN_DTL_ID.ParameterName = "@GEN_DTL_ID";
            if (RIS_SCHEDULEDTL.GEN_DTL_ID == null)
                GEN_DTL_ID.Value = null;
            else if (RIS_SCHEDULEDTL.GEN_DTL_ID == 0)
                GEN_DTL_ID.Value = null;
            else
                GEN_DTL_ID.Value = RIS_SCHEDULEDTL.GEN_DTL_ID;

            DbParameter RAD_ID = Parameter();
            RAD_ID.ParameterName = "@RAD_ID";
            if (RIS_SCHEDULEDTL.RAD_ID == null)
                RAD_ID.Value = null;
            else if (RIS_SCHEDULEDTL.RAD_ID == 0)
                RAD_ID.Value = null;
            else
                RAD_ID.Value = RIS_SCHEDULEDTL.RAD_ID;

            DbParameter PREPARATION_ID = Parameter();
            PREPARATION_ID.ParameterName = "@PREPARATION_ID";
            if (RIS_SCHEDULEDTL.PREPARATION_ID == null)
                PREPARATION_ID.Value = null;
            else if (RIS_SCHEDULEDTL.PREPARATION_ID == 0)
                PREPARATION_ID.Value = null;
            else
                PREPARATION_ID.Value = RIS_SCHEDULEDTL.PREPARATION_ID;

            DbParameter BPVIEW_ID = Parameter();
            BPVIEW_ID.ParameterName = "@BPVIEW_ID";
            if (RIS_SCHEDULEDTL.BPVIEW_ID == null)
                BPVIEW_ID.Value = null;
            else if (RIS_SCHEDULEDTL.BPVIEW_ID == 0)
                BPVIEW_ID.Value = null;
            else
                BPVIEW_ID.Value = RIS_SCHEDULEDTL.BPVIEW_ID;

            DbParameter PAT_DESC = Parameter();
            PAT_DESC.ParameterName = "@PAT_DEST_ID";
            if (RIS_SCHEDULEDTL.PAT_DEST_ID == 0)
                PAT_DESC.Value = null;
            else
                PAT_DESC.Value = RIS_SCHEDULEDTL.PAT_DEST_ID;

            DbParameter[] parameters ={
				Parameter( "@SCHEDULE_ID"	    , RIS_SCHEDULEDTL.SCHEDULE_ID ) ,
				Parameter( "@EXAM_ID"           , RIS_SCHEDULEDTL.EXAM_ID ) ,
				Parameter( "@QTY"	            , RIS_SCHEDULEDTL.QTY ) ,
				Parameter( "@RATE"	            , RIS_SCHEDULEDTL.RATE ) ,
				GEN_DTL_ID ,
				RAD_ID,
                PREPARATION_ID,
				BPVIEW_ID,
				Parameter( "@AVG_REQ_MIN"	    , RIS_SCHEDULEDTL.AVG_REQ_MIN ) ,
				Parameter( "@ORG_ID"	        , RIS_SCHEDULEDTL.ORG_ID ) ,
				Parameter( "@CREATED_BY"		, RIS_SCHEDULEDTL.CREATED_BY ) ,
                PAT_DESC,
                Parameter( "@SCHEDULE_PRIORITY"		, RIS_SCHEDULEDTL.SCHEDULE_PRIORITY ) 
            };
            return parameters;
        }
    }
}
