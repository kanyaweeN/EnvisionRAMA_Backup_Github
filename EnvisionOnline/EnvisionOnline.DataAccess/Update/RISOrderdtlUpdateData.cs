using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Update
{
    public class RISOrderdtlUpdateData : DataAccessBase
    {
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }

        public RISOrderdtlUpdateData()
        {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_UpdateFromOnline;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void Update(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter param1 = Parameter("@ORDER_ID", RIS_ORDERDTL.ORDER_ID);
            DbParameter param2 = Parameter();
            param2.ParameterName = "@BPVIEW_ID";
            if (RIS_ORDERDTL.BPVIEW_ID == null)
                param2.Value = DBNull.Value;
            else
                param2.Value = RIS_ORDERDTL.BPVIEW_ID == 0 ? (object)DBNull.Value : RIS_ORDERDTL.BPVIEW_ID;
            DbParameter param3 = Parameter();
            param3.ParameterName = "@COMMENTS";
            if (RIS_ORDERDTL.COMMENTS == null)
                param3.Value = DBNull.Value;
            else
                param3.Value = RIS_ORDERDTL.COMMENTS == string.Empty ? (object)DBNull.Value : RIS_ORDERDTL.COMMENTS;
            DbParameter param4 = Parameter("@CLINIC_TYPE", RIS_ORDERDTL.CLINIC_TYPE);
            DbParameter param5 = Parameter();
            param5.ParameterName = "@ASSIGNED_TO";
            if (RIS_ORDERDTL.ASSIGNED_TO == null)
                param5.Value = DBNull.Value;
            else
                param5.Value = RIS_ORDERDTL.ASSIGNED_TO == 0 ? (object)DBNull.Value : RIS_ORDERDTL.ASSIGNED_TO;
            DbParameter param6 = Parameter();
            param6.ParameterName = "@MODALITY_ID";
            if (RIS_ORDERDTL.MODALITY_ID == null)
                param6.Value = DBNull.Value;
            else
                param6.Value = RIS_ORDERDTL.MODALITY_ID == 0 ? (object)DBNull.Value : RIS_ORDERDTL.MODALITY_ID;
            DbParameter param7 = Parameter();
            param7.ParameterName = "@PRIORITY";
            if (RIS_ORDERDTL.PRIORITY == null)
                param7.Value = DBNull.Value;
            else
                param7.Value = RIS_ORDERDTL.PRIORITY == 0 ? (object)DBNull.Value : RIS_ORDERDTL.PRIORITY;
            DbParameter param8 = Parameter();
            param8.ParameterName = "@RATE";
            if (RIS_ORDERDTL.RATE == null)
                param8.Value = DBNull.Value;
            else
                param8.Value = RIS_ORDERDTL.RATE <= 0 ? (object)DBNull.Value : RIS_ORDERDTL.RATE;
            DbParameter param9 = Parameter();
            param9.ParameterName = "@ORG_ID";
            if (RIS_ORDERDTL.ORG_ID == null)
                param9.Value = DBNull.Value;
            else
                param9.Value = RIS_ORDERDTL.ORG_ID == 0 ? (object)DBNull.Value : RIS_ORDERDTL.ORG_ID;
            DbParameter param10 = Parameter();
            param10.ParameterName = "@LAST_MODIFIED_BY";
            if (RIS_ORDERDTL.LAST_MODIFIED_BY == null)
                param10.Value = DBNull.Value;
            else
                param10.Value = RIS_ORDERDTL.LAST_MODIFIED_BY == 0 ? (object)DBNull.Value : RIS_ORDERDTL.LAST_MODIFIED_BY;

            DbParameter[] parameters ={
                param1      ,param2     ,param3  ,param4 
                 ,param5    ,param6     ,param7  ,param8    
                 ,param9  ,param10
                                      };
            return parameters;
        }
    }
}