using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;
using EnvisionOnline.Common.Common;
using System.Data;

namespace EnvisionOnline.DataAccess.Select
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
            else
            {
                RIS_MODALITYEXAM = new RIS_MODALITYEXAM();
                StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_Select;
                action = 0;

            }
        }
        public RISModalityexamSelectData(int modalityID)
        {
            RIS_MODALITYEXAM = new RIS_MODALITYEXAM();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_SelectByModalityID;
            RIS_MODALITYEXAM.MODALITY_ID = modalityID;
            action = 2;
        }
        public DataSet getModalityExamTop10(int unit_id, int lengthByDay)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAMTop10_SelectByModolity;
            ParameterList = buildParameterModalityIDTop10Exam(unit_id, lengthByDay);
            return ExecuteDataSet();
        }
        public DataSet getModalityExamFavorite(int emp_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAMFAVORITE_SelectByModolity;
            ParameterList = buildParameterModalityIDFavorite(emp_id);
            return ExecuteDataSet();
        }
        public DataSet getModalityExamByModalityType(int modality_type)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_SelectByModolityType;
            ParameterList = buildParameterModalityByModalityType(modality_type);
            return ExecuteDataSet();
        }
        private DbParameter[] buildParameterModalityByModalityType(int modality_type)
        {
            DbParameter[] parameters ={			
                Parameter("@MODALITYTYPE_ID",modality_type)
                ,Parameter("@ORG_ID",1)
			};
            return parameters;
        }
        private DbParameter[] buildParameterModalityIDFavorite(int emp_id)
        {
            DbParameter[] parameters ={			
                Parameter("@MODALITY_ID",RIS_MODALITYEXAM.MODALITY_ID)
                ,Parameter("@EMP_ID",emp_id)
                ,Parameter("@ORG_ID",1)
			};
            return parameters;
        }
        private DbParameter[] buildParameterModalityIDTop10Exam(int unit_id, int lengthByDay)
        {
            DbParameter[] parameters ={			
                Parameter("@UNIT_ID",unit_id)
                ,Parameter("@LENGTH",lengthByDay)
			};
            return parameters;
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

        public DataSet getModalityByPatDestID(int exam_id,int pat_dest_id,string patient_type)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_SelectByPatDestID2;
            //StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_SelectByPatDestID_test;
            ParameterList = buildParameterModalityByPatDestID(exam_id, pat_dest_id, patient_type);
            return ExecuteDataSet();
        }
        private DbParameter[] buildParameterModalityByPatDestID(int exam_id, int pat_dest_id, string patient_type)
        {
            DbParameter[] parameters ={			
                Parameter("@EXAM_ID",exam_id),
                Parameter("@PAT_DEST_ID",pat_dest_id),
                Parameter("@PATIENT_TYPE",patient_type),
                
			};
            return parameters;
        }


        public DataSet getModalityIDByPatDestID(int exam_id, int pat_dest_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_SelectByPatDestID2;
            ParameterList = buildParameterModalityIDByPatDestID(exam_id, pat_dest_id);
            return ExecuteDataSet();
        }
        private DbParameter[] buildParameterModalityIDByPatDestID(int exam_id, int pat_dest_id)
        {
            DbParameter[] parameters ={			
                Parameter("@EXAM_ID",exam_id),
                Parameter("@PAT_DEST_ID",pat_dest_id),
                
			};
            return parameters;
        }
        public DataSet getModalityCNMIByExamID(int exam_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_ONL_SelectByExamIDCNMI;
            DbParameter[] parameters ={			
                Parameter("@EXAM_ID",exam_id),
                
			};
            ParameterList = parameters;
            return ExecuteDataSet();
        }
    }

}
