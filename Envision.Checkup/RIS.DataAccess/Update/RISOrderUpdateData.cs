//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    11/03/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
	public class RISOrderUpdateData : DataAccessBase 
	{
		private RISOrder	_risorder;
		private RISOrderInsertDataParameters	_risorderinsertdataparameters;
        private int action = 0;
        private bool cancelOrder;
		public RISOrderUpdateData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_UpdateSelfArrivalStatus.ToString();
            action = 0;
		}
        public RISOrderUpdateData(RISOrder risOrder)
        {
            _risorder = risOrder;
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_Update.ToString();
            action = 1;
        }
        public RISOrderUpdateData(RISOrder risOrder ,bool CancelOrder)
        {
            _risorder = risOrder;
            action = 0;
            if (CancelOrder)
            {
                cancelOrder = CancelOrder;
                StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_Cancel.ToString();
                action = 2;
            }
            else 
                StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_UpdateSelfArrivalStatus.ToString();

        }

		public  RISOrder	RISOrder
		{
			get{return _risorder;}
			set{_risorder=value;}
		}
		public void Update()
		{
            _risorderinsertdataparameters = null;
            switch (action)
            { 
                case 0:
                    _risorderinsertdataparameters = new RISOrderInsertDataParameters();
                    _risorderinsertdataparameters.RISOrder = _risorder;
                    _risorderinsertdataparameters.BuildUpdateSelfArrival();
                    break;
                case 1:
                    _risorderinsertdataparameters = new RISOrderInsertDataParameters(_risorder);
                    break;
                case 2:
                    _risorderinsertdataparameters = new RISOrderInsertDataParameters(_risorder, true);
                    break;
            }
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            try
            {
                object id = dbhelper.RunScalar(base.ConnectionString, _risorderinsertdataparameters.Parameters);
            }
            catch (Exception ex) { string s = ex.Message; }
		}
        public void Update(SqlTransaction tran)
        {
            _risorderinsertdataparameters = null;
            switch (action)
            {
                case 0:
                    _risorderinsertdataparameters = new RISOrderInsertDataParameters();
                    _risorderinsertdataparameters.RISOrder = _risorder;
                    _risorderinsertdataparameters.BuildUpdateSelfArrival();
                    break;
                case 1:
                    _risorderinsertdataparameters = new RISOrderInsertDataParameters(_risorder);
                    break;
                case 2:
                    _risorderinsertdataparameters = new RISOrderInsertDataParameters(_risorder,true);
                    break;
            }
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            try
            {
                object id = dbhelper.RunScalar(tran, _risorderinsertdataparameters.Parameters);
            }
            catch (Exception ex) {
                string s = ex.Message;
            }
        }
	}
	public class RISOrderInsertDataParameters 
	{
		private RISOrder _risorder;
		private SqlParameter[] _parameters;
		public RISOrderInsertDataParameters()
		{
            _risorder = new RISOrder();
		}
        public RISOrderInsertDataParameters(RISOrder risorder)
        {
            _risorder = risorder;
            BuildUpdate();
        }
        public RISOrderInsertDataParameters(RISOrder risorder,bool flag)
        {
            _risorder = risorder;
            if (flag)
                BuildCancel();
            else
                BuildUpdate();
        }
		public  RISOrder	RISOrder
		{
			get{return _risorder;}
			set{_risorder=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
        public void BuildUpdate() {
            SqlParameter pUnit = new SqlParameter();
            pUnit.ParameterName = "@REF_UNIT";
            if (RISOrder.REF_UNIT == 0)
                pUnit.Value = DBNull.Value;
            else
                pUnit.Value = RISOrder.REF_UNIT;

            SqlParameter pDoc = new SqlParameter();
            pDoc.ParameterName = "@REF_DOC";
            if (RISOrder.REF_DOC == 0)
                pDoc.Value = DBNull.Value;
            else
                pDoc.Value = RISOrder.REF_DOC;

            SqlParameter pICD = new SqlParameter();
            pICD.ParameterName = "@REF_DOC";
            if (RISOrder.ICD_ID == 0)
                pICD.Value = DBNull.Value;
            else
                pICD.Value = RISOrder.ICD_ID;

            SqlParameter pSchedule_ID = new SqlParameter();
            pSchedule_ID.ParameterName = "@REF_DOC";
            if (RISOrder.SCHEDULE_ID == 0)
                pSchedule_ID.Value = DBNull.Value;
            else
                pSchedule_ID.Value = RISOrder.SCHEDULE_ID;

            SqlParameter pINSURANCE_TYPE_ID = new SqlParameter();
            pINSURANCE_TYPE_ID.ParameterName = "@INSURANCE_TYPE_ID";
            if (RISOrder.INSURANCE_TYPE_ID == 0)
                pINSURANCE_TYPE_ID.Value = DBNull.Value;
            else
                pINSURANCE_TYPE_ID.Value = RISOrder.INSURANCE_TYPE_ID;

            SqlParameter pPAT_STATUS = new SqlParameter();
            pPAT_STATUS.ParameterName = "@PAT_STATUS";
            if (RISOrder.PAT_STATUS == string.Empty)
                pPAT_STATUS.Value = DBNull.Value;
            else
                pPAT_STATUS.Value = RISOrder.PAT_STATUS;

            SqlParameter pARRIVAL_BY = new SqlParameter();
            pARRIVAL_BY.ParameterName = "@ARRIVAL_BY";
            if (RISOrder.ARRIVAL_BY == 0)
                pARRIVAL_BY.Value = DBNull.Value;
            else
                pARRIVAL_BY.Value = RISOrder.ARRIVAL_BY;

            SqlParameter pARRIVAL_ON = new SqlParameter();
            pARRIVAL_ON.ParameterName = "@ARRIVAL_ON";
            if (RISOrder.ARRIVAL_ON == DateTime.MinValue)
                pARRIVAL_ON.Value = DBNull.Value;
            else
                pARRIVAL_ON.Value = RISOrder.ARRIVAL_ON;

            SqlParameter pLMP_DT = new SqlParameter();
            pLMP_DT.ParameterName = "@LMP_DT";
            if (RISOrder.Lmp_DT == DateTime.MinValue)
                pLMP_DT.Value = DBNull.Value;
            else
                pLMP_DT.Value = RISOrder.Lmp_DT;

            SqlParameter pADMISSION_NO = new SqlParameter();
            pADMISSION_NO.ParameterName = "@ADMISSION_NO";
            if (RISOrder.ADMISSION_NO == null || RISOrder.ADMISSION_NO.Trim() == string.Empty)
                pADMISSION_NO.Value = DBNull.Value;
            else
                pADMISSION_NO.Value = RISOrder.ADMISSION_NO;

            SqlParameter pREASON = new SqlParameter();
            pREASON.ParameterName = "@REASON";
            if (RISOrder.REASON == null || RISOrder.REASON.Trim() == string.Empty)
                pREASON.Value = DBNull.Value;
            else
                pREASON.Value = RISOrder.REASON;

            SqlParameter pDIAGNOSIS = new SqlParameter();
            pDIAGNOSIS.ParameterName = "@DIAGNOSIS";
            if (RISOrder.DIAGNOSIS == null || RISOrder.DIAGNOSIS.Trim() == string.Empty)
                pDIAGNOSIS.Value = DBNull.Value;
            else
                pDIAGNOSIS.Value = RISOrder.DIAGNOSIS;

            SqlParameter pREF_DOC_INSTRUCTION = new SqlParameter();
            pREF_DOC_INSTRUCTION.ParameterName = "@REF_DOC_INSTRUCTION";
            if (RISOrder.REF_DOC_INSTRUCTION == null || RISOrder.REF_DOC_INSTRUCTION.Trim() == string.Empty)
                pREF_DOC_INSTRUCTION.Value = DBNull.Value;
            else
                pREF_DOC_INSTRUCTION.Value = RISOrder.REF_DOC_INSTRUCTION;

            SqlParameter pCLINICAL_INSTRUCTION = new SqlParameter();
            pCLINICAL_INSTRUCTION.ParameterName = "@CLINICAL_INSTRUCTION";
            if (RISOrder.CLINICAL_INSTRUCTION == null || RISOrder.CLINICAL_INSTRUCTION.Trim() == string.Empty)
                pCLINICAL_INSTRUCTION.Value = DBNull.Value;
            else
                pCLINICAL_INSTRUCTION.Value = RISOrder.CLINICAL_INSTRUCTION;

            SqlParameter[] parameters =
            { 
                      new SqlParameter("@ORDER_ID", RISOrder.ORDER_ID)
                    , new SqlParameter("@REG_ID", RISOrder.REG_ID)
                    , new SqlParameter("@HN", RISOrder.HN)
                    , new SqlParameter("@VISIT_NO", RISOrder.VISIT_NO)
                    //, new SqlParameter("@ADMISSION_NO", RISOrder.ADMISSION_NO)
                    ,pADMISSION_NO
                    , new SqlParameter("@ORDER_DT", RISOrder.ORDER_DT)
                    , new SqlParameter("@ORDER_START_TIME", RISOrder.ORDER_START_TIME)
                    ,pSchedule_ID
                    ,pUnit
                    ,pDoc
                   
                    //, new SqlParameter("@REF_DOC_INSTRUCTION", RISOrder.REF_DOC_INSTRUCTION)
                    //, new SqlParameter("@CLINICAL_INSTRUCTION", RISOrder.CLINICAL_INSTRUCTION)
                    //, new SqlParameter("@REASON", RISOrder.REASON)
                    //, new SqlParameter("@DIAGNOSIS", RISOrder.DIAGNOSIS)
                    ,pREF_DOC_INSTRUCTION
                    ,pCLINICAL_INSTRUCTION
                    ,pREASON
                    ,pDIAGNOSIS
                    ,pICD
                    ,pARRIVAL_BY
                    ,pARRIVAL_ON
                    //, new SqlParameter("@ARRIVAL_BY", RISOrder.ARRIVAL_BY)
                    //, new SqlParameter("@ARRIVAL_ON", RISOrder.ARRIVAL_ON)
                    , new SqlParameter("@ORG_ID", RISOrder.ORG_ID)
                    , new SqlParameter("@LAST_MODIFIED_BY", RISOrder.LAST_MODIFIED_BY)
                    ,pINSURANCE_TYPE_ID
                    ,pPAT_STATUS
                    ,pLMP_DT
            };
            Parameters = parameters;
        }
		public void BuildUpdateSelfArrival()
		{
            SqlParameter[] parameters =
            { 
                new SqlParameter("@ORDER_ID", RISOrder.ORDER_ID)
                ,new SqlParameter("@SELF_ARRIVAL", RISOrder.SELF_ARRIVAL)
                ,new SqlParameter("@UserID", RISOrder.LAST_MODIFIED_BY) 
            };
			Parameters = parameters;
		}
        public void BuildCancel() {
            SqlParameter[] parameters =
            { 
                new SqlParameter("@ORDER_ID", RISOrder.ORDER_ID)
                ,new SqlParameter("@IS_CANCELED", RISOrder.IS_CANCELED) 
                ,new SqlParameter("@LAST_MODIFIED_BY", RISOrder.LAST_MODIFIED_BY) 
            };
            Parameters = parameters;
        
        }
	}
}

