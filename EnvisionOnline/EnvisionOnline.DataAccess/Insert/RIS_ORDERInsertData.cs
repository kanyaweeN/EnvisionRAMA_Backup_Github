using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class RIS_ORDERInsertData : DataAccessBase
    {
        public RIS_ORDER RIS_ORDER { get; set; }

        public RIS_ORDERInsertData()
        {
            RIS_ORDER = new RIS_ORDER();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_Insert;

        }

        public int Add()
        {
            ParameterList = buildParameter();
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            int ret = 0;
            try
            {
                ret = System.Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                RIS_ORDER.ORDER_ID = ret;
                RIS_ORDER.XRAY_NO = ds.Tables[0].Rows[0][1].ToString();
            }
            catch (Exception ex)
            {

            }
            return ret;
            //return (int)ParameterList[0].Value;
        }
        public int Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            //id,xray_no
            int ret = 0;
            try
            {
                ret = System.Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                RIS_ORDER.ORDER_ID = ret;
                RIS_ORDER.XRAY_NO = ds.Tables[0].Rows[0][1].ToString();
            }
            catch (Exception ex)
            {

            }
            return ret;
            //ExecuteNonQuery();
            //return (int)ParameterList[0].Value;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter param1 = Parameter("@ORDER_ID", RIS_ORDER.ORDER_ID);
            param1.Direction = ParameterDirection.Output;

            DbParameter param2 = Parameter("@REG_ID", RIS_ORDER.REG_ID);

            DbParameter param3 = Parameter("@HN", RIS_ORDER.HN);

            DbParameter param4 = Parameter();
            param4.ParameterName = "@VISIT_NO";
            if (string.IsNullOrEmpty(RIS_ORDER.VISIT_NO))
                param4.Value = DBNull.Value;
            else
                param4.Value = RIS_ORDER.VISIT_NO;

            DbParameter param5 = Parameter();
            param5.ParameterName = "@ADMISSION_NO";
            if (string.IsNullOrEmpty(RIS_ORDER.ADMISSION_NO))
                param5.Value = DBNull.Value;
            else
                param5.Value = RIS_ORDER.ADMISSION_NO;

            DbParameter param6 = Parameter();
            param6.ParameterName = "@ORDER_DT";
            if (RIS_ORDER.ORDER_DT == null)
                param6.Value = DBNull.Value;
            else
                param6.Value = RIS_ORDER.ORDER_DT == DateTime.MinValue ? (object)DBNull.Value : RIS_ORDER.ORDER_DT;

            DbParameter param7 = Parameter();
            param7.ParameterName = "@ORDER_START_TIME";
            if (RIS_ORDER.ORDER_START_TIME == null)
                param7.Value = DBNull.Value;
            else
                param7.Value = RIS_ORDER.ORDER_START_TIME == DateTime.MinValue ? (object)DBNull.Value : RIS_ORDER.ORDER_START_TIME;

            DbParameter param8 = Parameter();
            param8.ParameterName = "@SCHEDULE_ID";
            if (RIS_ORDER.SCHEDULE_ID == null)
                param8.Value = DBNull.Value;
            else
                param8.Value = RIS_ORDER.SCHEDULE_ID == 0 ? (object)DBNull.Value : RIS_ORDER.SCHEDULE_ID;

            DbParameter param91 = Parameter();
            param91.ParameterName = "@REF_UNIT";
            if (RIS_ORDER.REF_UNIT == null)
                param91.Value = DBNull.Value;
            else
                param91.Value = RIS_ORDER.REF_UNIT == 0 ? (object)DBNull.Value : RIS_ORDER.REF_UNIT;

            DbParameter param92 = Parameter();
            param92.ParameterName = "@REF_DOC";
            if (RIS_ORDER.REF_DOC == null)
                param92.Value = DBNull.Value;
            else
                param92.Value = RIS_ORDER.REF_DOC == 0 ? (object)DBNull.Value : RIS_ORDER.REF_DOC;

            DbParameter param10 = Parameter();
            param10.ParameterName = "@REF_DOC_INSTRUCTION";
            if (string.IsNullOrEmpty(RIS_ORDER.REF_DOC_INSTRUCTION))// == null || RIS_ORDER.REF_DOC_INSTRUCTION == string.Empty)
                param10.Value = DBNull.Value;
            else
                param10.Value = RIS_ORDER.REF_DOC_INSTRUCTION;

            DbParameter param11 = Parameter();
            param11.ParameterName = "@CLINICAL_INSTRUCTION";
            if (string.IsNullOrEmpty(RIS_ORDER.CLINICAL_INSTRUCTION))//== null || RIS_ORDER.CLINICAL_INSTRUCTION == string.Empty)
                param11.Value = DBNull.Value;
            else
                param11.Value = RIS_ORDER.CLINICAL_INSTRUCTION;

            DbParameter param12 = Parameter();
            param12.ParameterName = "@REASON";
            if (string.IsNullOrEmpty(RIS_ORDER.REASON))// == null || RIS_ORDER.REASON == string.Empty )
                param12.Value = DBNull.Value;
            else
                param12.Value = RIS_ORDER.REASON;

            DbParameter param13 = Parameter();
            param13.ParameterName = "@DIAGNOSIS";
            if (string.IsNullOrEmpty(RIS_ORDER.DIAGNOSIS))// == null || RIS_ORDER.DIAGNOSIS == string.Empty)
                param13.Value = DBNull.Value;
            else
                param13.Value = RIS_ORDER.DIAGNOSIS;

            DbParameter param14 = Parameter();
            param14.ParameterName = "@ICD_ID";
            if (RIS_ORDER.ICD_ID == null)
                param14.Value = DBNull.Value;
            else
                param14.Value = RIS_ORDER.ICD_ID == 0 ? (object)DBNull.Value : RIS_ORDER.ICD_ID;

            DbParameter param15 = Parameter();
            param15.ParameterName = "@ARRIVAL_BY";
            if (RIS_ORDER.ARRIVAL_BY == null)
                param15.Value = DBNull.Value;
            else
                param15.Value = RIS_ORDER.ARRIVAL_BY;

            DbParameter param16 = Parameter();
            param16.ParameterName = "@ARRIVAL_ON";
            if ((RIS_ORDER.ARRIVAL_ON == null) || (RIS_ORDER.ARRIVAL_ON == DateTime.MinValue))
                param16.Value = DBNull.Value;
            else
                param16.Value = RIS_ORDER.ARRIVAL_ON;

            //DbParameter param17 = Parameter();
            //param17.ParameterName = "@SELF_ARRIVAL";
            //if(string.IsNullOrEmpty(RIS_ORDER.SELF_ARRIVAL))// == null || RIS_ORDER.VISIT_NO == string.Empty )
            //    param17.Value = DBNull.Value;
            //else
            //    param17.Value = RIS_ORDER.SELF_ARRIVAL;

            DbParameter param18 = Parameter();
            param18.ParameterName = "@ORG_ID";
            if (RIS_ORDER.ORG_ID == null)
                param18.Value = DBNull.Value;
            else
                param18.Value = RIS_ORDER.ORG_ID == 0 ? (object)DBNull.Value : RIS_ORDER.ORG_ID;

            DbParameter param19 = Parameter();
            param19.ParameterName = "@CREATED_BY";
            if (RIS_ORDER.CREATED_BY == null)
                param19.Value = DBNull.Value;
            else
                param19.Value = RIS_ORDER.CREATED_BY == 0 ? (object)DBNull.Value : RIS_ORDER.CREATED_BY;

            DbParameter param20 = Parameter();
            param20.ParameterName = "@INSURANCE_TYPE_ID";
            if (RIS_ORDER.INSURANCE_TYPE_ID == null)
                param20.Value = DBNull.Value;
            else
                param20.Value = RIS_ORDER.INSURANCE_TYPE_ID == 0 ? (object)DBNull.Value : RIS_ORDER.INSURANCE_TYPE_ID;

            DbParameter pPAT_STATUS = Parameter();
            pPAT_STATUS.ParameterName = "@PAT_STATUS";
            if (RIS_ORDER.PAT_STATUS == string.Empty || RIS_ORDER.PAT_STATUS == null)
                pPAT_STATUS.Value = DBNull.Value;
            else
                pPAT_STATUS.Value = RIS_ORDER.PAT_STATUS;


            DbParameter pLMP_DT = Parameter();
            pLMP_DT.ParameterName = "@LMP_DT";
            if (RIS_ORDER.LMP_DT == null)
                pLMP_DT.Value = DBNull.Value;
            else
                pLMP_DT.Value = RIS_ORDER.LMP_DT == DateTime.MinValue ? (object)DBNull.Value : RIS_ORDER.LMP_DT;

            DbParameter pIS_REQONLINE = Parameter();
            pIS_REQONLINE.ParameterName = "@IS_REQONLINE";
            pIS_REQONLINE.Value = DBNull.Value;
            DbParameter[] parameters ={
                param1          ,param2         ,param3         ,param4
                ,param5         ,param6         ,param7         ,param8
                ,param91        ,param92        ,param10        ,param11        ,param12
                ,param13        ,param14        ,param15        ,param16        //,param17        
                ,param18        ,param19        ,param20        ,pPAT_STATUS    ,pLMP_DT
                ,pIS_REQONLINE
            };
            return parameters;
        }
    }
}
