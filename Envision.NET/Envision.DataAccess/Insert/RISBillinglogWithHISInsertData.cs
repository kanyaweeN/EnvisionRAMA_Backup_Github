using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISBillinglogWithHISInsertData: DataAccessBase 
	{
        public RIS_BILLINGLOG_WITH_HIS RIS_BILLINGLOG_WITH_HIS { get; set; }
        public RISBillinglogWithHISInsertData()
		{
            RIS_BILLINGLOG_WITH_HIS = new RIS_BILLINGLOG_WITH_HIS();
            StoredProcedureName = StoredProcedure.Prc_RIS_BILLINGLOG_WITH_HIS_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
    DbParameter parameffectiveenddate = Parameter();
            parameffectiveenddate.ParameterName = "@effectiveenddate";
            if (RIS_BILLINGLOG_WITH_HIS.effectiveenddate == null)
                parameffectiveenddate.Value = DBNull.Value;
            else
                parameffectiveenddate.Value = RIS_BILLINGLOG_WITH_HIS.effectiveenddate == DateTime.MinValue ? (object)DBNull.Value : RIS_BILLINGLOG_WITH_HIS.effectiveenddate;


            DbParameter parameffectivestartdate = Parameter();
            parameffectivestartdate.ParameterName = "@effectivestartdate";
            if (RIS_BILLINGLOG_WITH_HIS.effectivestartdate == null)
                parameffectivestartdate.Value = DBNull.Value;
            else
                parameffectivestartdate.Value = RIS_BILLINGLOG_WITH_HIS.effectivestartdate == DateTime.MinValue ? (object)DBNull.Value : RIS_BILLINGLOG_WITH_HIS.effectivestartdate;

            

            DbParameter[] parameters ={
Parameter("@ORDER_ID",RIS_BILLINGLOG_WITH_HIS.ORDER_ID),
Parameter("@EXAM_ID",RIS_BILLINGLOG_WITH_HIS.EXAM_ID),
Parameter("@object_id",RIS_BILLINGLOG_WITH_HIS.object_id),
Parameter("@enc_id",RIS_BILLINGLOG_WITH_HIS.enc_id),
Parameter("@enc_type",RIS_BILLINGLOG_WITH_HIS.enc_type),
Parameter("@mrn",RIS_BILLINGLOG_WITH_HIS.mrn),
Parameter("@mrn_type",RIS_BILLINGLOG_WITH_HIS.mrn_type),
Parameter("@sdloc_id",RIS_BILLINGLOG_WITH_HIS.sdloc_id),
Parameter("@period",RIS_BILLINGLOG_WITH_HIS.period),
Parameter("@attender",RIS_BILLINGLOG_WITH_HIS.attender),
Parameter("@enterer",RIS_BILLINGLOG_WITH_HIS.enterer),
Parameter("@insurance",RIS_BILLINGLOG_WITH_HIS.insurance),
Parameter("@pt_acc_id",RIS_BILLINGLOG_WITH_HIS.pt_acc_id),
parameffectivestartdate,
parameffectiveenddate,
Parameter("@statuscode",RIS_BILLINGLOG_WITH_HIS.statuscode),
Parameter("@productcode",RIS_BILLINGLOG_WITH_HIS.productcode),
Parameter("@clinictype",RIS_BILLINGLOG_WITH_HIS.clinictype),
Parameter("@pricetype",RIS_BILLINGLOG_WITH_HIS.pricetype),
Parameter("@amtprice",RIS_BILLINGLOG_WITH_HIS.amtprice),
Parameter("@CREATED_BY",RIS_BILLINGLOG_WITH_HIS.CREATED_BY)

            };
            return parameters;
        }
        public void insertLogByHIS()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_BILLINGLOGDTL_BY_HIS_Insert;
            ParameterList = buildParameterByHIS();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterByHIS()
        {
            DbParameter parameffectiveenddate = Parameter();
            parameffectiveenddate.ParameterName = "@effectiveenddate";
            if (RIS_BILLINGLOG_WITH_HIS.effectiveenddate == null)
                parameffectiveenddate.Value = DBNull.Value;
            else
                parameffectiveenddate.Value = RIS_BILLINGLOG_WITH_HIS.effectiveenddate == DateTime.MinValue ? (object)DBNull.Value : RIS_BILLINGLOG_WITH_HIS.effectiveenddate;


            DbParameter parameffectivestartdate = Parameter();
            parameffectivestartdate.ParameterName = "@effectivestartdate";
            if (RIS_BILLINGLOG_WITH_HIS.effectivestartdate == null)
                parameffectivestartdate.Value = DBNull.Value;
            else
                parameffectivestartdate.Value = RIS_BILLINGLOG_WITH_HIS.effectivestartdate == DateTime.MinValue ? (object)DBNull.Value : RIS_BILLINGLOG_WITH_HIS.effectivestartdate;



            DbParameter[] parameters ={
Parameter("@object_id",RIS_BILLINGLOG_WITH_HIS.object_id),
Parameter("@enc_id",RIS_BILLINGLOG_WITH_HIS.enc_id),
Parameter("@enc_type",RIS_BILLINGLOG_WITH_HIS.enc_type),
Parameter("@mrn",RIS_BILLINGLOG_WITH_HIS.mrn),
Parameter("@mrn_type",RIS_BILLINGLOG_WITH_HIS.mrn_type),
Parameter("@sdloc_id",RIS_BILLINGLOG_WITH_HIS.sdloc_id),
Parameter("@period",RIS_BILLINGLOG_WITH_HIS.period),
Parameter("@attender",RIS_BILLINGLOG_WITH_HIS.attender),
Parameter("@enterer",RIS_BILLINGLOG_WITH_HIS.enterer),
Parameter("@insurance",RIS_BILLINGLOG_WITH_HIS.insurance),
Parameter("@pt_acc_id",RIS_BILLINGLOG_WITH_HIS.pt_acc_id),
parameffectivestartdate,
parameffectiveenddate,
Parameter("@statuscode",RIS_BILLINGLOG_WITH_HIS.statuscode),
Parameter("@productcode",RIS_BILLINGLOG_WITH_HIS.productcode),
Parameter("@clinictype",RIS_BILLINGLOG_WITH_HIS.clinictype),
Parameter("@pricetype",RIS_BILLINGLOG_WITH_HIS.pricetype),
Parameter("@amtprice",RIS_BILLINGLOG_WITH_HIS.amtprice),
Parameter("@CREATED_BY",RIS_BILLINGLOG_WITH_HIS.CREATED_BY)

            };
            return parameters;
        }
        public void insertLogByHISErrorClinic()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_BILLINGLOG_WITH_HIS_ERRORCLINIC_Insert;
            ParameterList = buildParameterByHISErrorClinic();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterByHISErrorClinic()
        {
            DbParameter[] parameters ={
Parameter("@UNIT_UID",RIS_BILLINGLOG_WITH_HIS.UNIT_UID),
Parameter("@CLINIC_TYPE_ALIAS",RIS_BILLINGLOG_WITH_HIS.CLINIC_TYPE_ALIAS),
Parameter("@EXAM_UID",RIS_BILLINGLOG_WITH_HIS.EXAM_UID),
Parameter("@HN",RIS_BILLINGLOG_WITH_HIS.HN),

Parameter("@CREATED_BY",RIS_BILLINGLOG_WITH_HIS.CREATED_BY)

            };
            return parameters;
        }
        
	}
}
