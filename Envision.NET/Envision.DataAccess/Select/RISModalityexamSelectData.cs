using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISModalityexamSelectData : DataAccessBase 
	{
        public RIS_MODALITYEXAM RIS_MODALITYEXAM { get; set; }
        private int action;

		public RISModalityexamSelectData()
		{
            RIS_MODALITYEXAM = new RIS_MODALITYEXAM();
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_Select;
            action = 0;
		}
        public RISModalityexamSelectData(bool selectAll)
        {
            if (selectAll)
            {
                RIS_MODALITYEXAM = new RIS_MODALITYEXAM();
                StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_SelectAll;
                action = 1;
            }
            else {
                RIS_MODALITYEXAM = new RIS_MODALITYEXAM();
                StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_Select;
                action = 0;

            }
        }
        public RISModalityexamSelectData(int modalityID) {
            RIS_MODALITYEXAM = new RIS_MODALITYEXAM();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_SelectByModalityID;
            RIS_MODALITYEXAM.MODALITY_ID = modalityID;
            action = 2;
        }
        public DataSet GetDataOnline()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_ONL_SelectByModalityID;
            ParameterList = buildParameterModalityID();
            return ExecuteDataSet();
        }
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            if (action == 0)
            {
                ParameterList = buildParameter();
                ds = ExecuteDataSet();
            }
            else if (action == 1)
            {
                //ParameterList = buildParameter();
                ds = ExecuteDataSet();
            }
            else
            {
                ParameterList = buildParameterModalityID();
                ds = ExecuteDataSet();
            }
			return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@MODALITY_EXAM_ID",RIS_MODALITYEXAM.MODALITY_EXAM_ID),
                Parameter("@MODALITY_ID",RIS_MODALITYEXAM.MODALITY_ID),
                Parameter("@EXAM_ID",RIS_MODALITYEXAM.EXAM_ID),
                Parameter("@IS_ACTIVE",RIS_MODALITYEXAM.IS_ACTIVE),
                Parameter("@ORG_ID",RIS_MODALITYEXAM.ORG_ID)
			};
            return parameters;
        }
        private DbParameter[] buildParameterModalityID()
        {
            DbParameter[] parameters ={			
                Parameter("@MODALITY_ID",RIS_MODALITYEXAM.MODALITY_ID)
			};
            return parameters;
        }
        
        public DataSet GetReport_ModalityExam(int UserID)
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_Select_rptModality;
            DataSet ds = new DataSet();
            ParameterList = buildParameterModalityIDUserID(UserID);
            ds = ExecuteDataSet();
			return ds;
		}
        private DbParameter[] buildParameterModalityIDUserID(int UserID)
        {
            DbParameter[] parameters ={			
                Parameter("@MODALITY_ID",RIS_MODALITYEXAM.MODALITY_ID),
                Parameter("@USER_ID",UserID)
			};
            return parameters;
        }
        public DataSet GetReport_ModalityExam_Para()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_Select_rptModality_Para;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            
            return ds;
        }

	}
   
}

