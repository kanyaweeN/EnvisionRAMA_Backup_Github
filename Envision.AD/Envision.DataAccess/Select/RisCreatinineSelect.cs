using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RisCreatinineSelect : DataAccessBase
    {
        public RIS_LABCREATININE RIS_LABCREATININE { get; set; }

        public RisCreatinineSelect()
        {
        }

        public DataTable selectLabCreatinine()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_LABCREATININE_Select;
            ParameterList = this.BuildParameterselcetLabCreatinine();
            return ExecuteDataTable();
        }
        private DbParameter[] BuildParameterselcetLabCreatinine()
        {

            DbParameter[] parameters = {
                                           Parameter("@SCHEDULE_ID", RIS_LABCREATININE.SCHEDULE_ID),
                                       };
            return parameters;
        }
        public void insertLabCreatinine()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_LABCREATININE_Insert;
            ParameterList = this.BuildParametersinsertLabCreatinine();
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = ExecuteDataSet();
        }
        private DbParameter[] BuildParametersinsertLabCreatinine()
        {
            DbParameter OBSERV_DATETIME = Parameter("@OBSERV_DATETIME", RIS_LABCREATININE.OBSERV_DATETIME);
            OBSERV_DATETIME.Value = RIS_LABCREATININE.OBSERV_DATETIME == DateTime.MinValue ? (object)DBNull.Value : RIS_LABCREATININE.OBSERV_DATETIME;
            DbParameter REPORT_DATETIME = Parameter("@REPORT_DATETIME", RIS_LABCREATININE.REPORT_DATETIME);
            OBSERV_DATETIME.Value = RIS_LABCREATININE.REPORT_DATETIME == DateTime.MinValue ? (object)DBNull.Value : RIS_LABCREATININE.REPORT_DATETIME;
            DbParameter ORDER_ID = Parameter("@ORDER_ID", RIS_LABCREATININE.ORDER_ID);
            ORDER_ID.Value = RIS_LABCREATININE.ORDER_ID == 0 ? (object)DBNull.Value : RIS_LABCREATININE.ORDER_ID;
            DbParameter SCHEDULE_ID = Parameter("@SCHEDULE_ID", RIS_LABCREATININE.SCHEDULE_ID);
            SCHEDULE_ID.Value = RIS_LABCREATININE.SCHEDULE_ID == 0 ? (object)DBNull.Value : RIS_LABCREATININE.SCHEDULE_ID;

            DbParameter[] parameters = {
                                           Parameter("@REG_ID ", RIS_LABCREATININE.REG_ID),
                                           ORDER_ID,
                                           SCHEDULE_ID,
                                           Parameter("@HIS_RQ_ID ", RIS_LABCREATININE.HIS_RQ_ID),
                                           Parameter("@MRN", RIS_LABCREATININE.MRN),
                                           Parameter("@SDLOC", RIS_LABCREATININE.SDLOC),
                                           Parameter("@PRODUCT_ID", RIS_LABCREATININE.PRODUCT_ID),
                                           Parameter("@PERFORM_UNIT", RIS_LABCREATININE.PERFORM_UNIT),
                                           Parameter("@COD_TEST", RIS_LABCREATININE.COD_TEST),
                                           Parameter("@SHORT_TEST", RIS_LABCREATININE.SHORT_TEST),
                                           Parameter("@RESULT_VALUE", RIS_LABCREATININE.RESULT_VALUE),
                                           Parameter("@UNIT", RIS_LABCREATININE.UNIT),
                                           Parameter("@RANGE", RIS_LABCREATININE.RANGE),
                                           OBSERV_DATETIME,
                                           REPORT_DATETIME ,
                                           Parameter("@ORG_ID ", RIS_LABCREATININE.ORG_ID),
                                           Parameter("@CREATED_BY ", RIS_LABCREATININE.CREATED_BY),
                                       };
            return parameters;
        }
        public void updateLabCreatinine()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_LABCREATININE_Update;
            ParameterList = this.BuildParametersupdateLabCreatinine();
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = ExecuteDataSet();
        }
        private DbParameter[] BuildParametersupdateLabCreatinine()
        {
            DbParameter OBSERV_DATETIME = Parameter("@OBSERV_DATETIME", RIS_LABCREATININE.OBSERV_DATETIME);
            OBSERV_DATETIME.Value = RIS_LABCREATININE.OBSERV_DATETIME == DateTime.MinValue ? (object)DBNull.Value : RIS_LABCREATININE.OBSERV_DATETIME;
            DbParameter REPORT_DATETIME = Parameter("@REPORT_DATETIME", RIS_LABCREATININE.REPORT_DATETIME);
            OBSERV_DATETIME.Value = RIS_LABCREATININE.REPORT_DATETIME == DateTime.MinValue ? (object)DBNull.Value : RIS_LABCREATININE.REPORT_DATETIME;
            DbParameter ORDER_ID = Parameter("@ORDER_ID", RIS_LABCREATININE.ORDER_ID);
            ORDER_ID.Value = RIS_LABCREATININE.ORDER_ID == 0 ? (object)DBNull.Value : RIS_LABCREATININE.ORDER_ID;
            DbParameter SCHEDULE_ID = Parameter("@SCHEDULE_ID", RIS_LABCREATININE.SCHEDULE_ID);
            SCHEDULE_ID.Value = RIS_LABCREATININE.SCHEDULE_ID == 0 ? (object)DBNull.Value : RIS_LABCREATININE.SCHEDULE_ID;

            DbParameter[] parameters = {
                                           Parameter("@LAB_CREATININE_ID", RIS_LABCREATININE.LAB_CREATININE_ID),
                                           Parameter("@REG_ID ", RIS_LABCREATININE.REG_ID),
                                           ORDER_ID,
                                           SCHEDULE_ID,
                                           Parameter("@HIS_RQ_ID ", RIS_LABCREATININE.HIS_RQ_ID),
                                           Parameter("@MRN", RIS_LABCREATININE.MRN),
                                           Parameter("@SDLOC", RIS_LABCREATININE.SDLOC),
                                           Parameter("@PRODUCT_ID", RIS_LABCREATININE.PRODUCT_ID),
                                           Parameter("@PERFORM_UNIT", RIS_LABCREATININE.PERFORM_UNIT),
                                           Parameter("@COD_TEST", RIS_LABCREATININE.COD_TEST),
                                           Parameter("@SHORT_TEST", RIS_LABCREATININE.SHORT_TEST),
                                           Parameter("@RESULT_VALUE", RIS_LABCREATININE.RESULT_VALUE),
                                           Parameter("@UNIT", RIS_LABCREATININE.UNIT),
                                           Parameter("@RANGE", RIS_LABCREATININE.RANGE),
                                           OBSERV_DATETIME,
                                           REPORT_DATETIME ,
                                           Parameter("@ORG_ID ", RIS_LABCREATININE.ORG_ID),
                                           Parameter("@LAST_MODIFIED_BY ", RIS_LABCREATININE.LAST_MODIFIED_BY),
                                       };
            return parameters;
        }
    }
}
