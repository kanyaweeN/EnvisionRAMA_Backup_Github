using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISExamSelectData : DataAccessBase
    {
        public RIS_EXAM RIS_EXAM { get; set; }

        public RISExamSelectData()
        {
            RIS_EXAM = new RIS_EXAM();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_Select;
        }
        public RISExamSelectData(bool selectAll)
        {
            RIS_EXAM = new RIS_EXAM();
            if (selectAll)
                StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_SelectAll;
            else
                StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_Select;
        }
        public DataSet GetData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_SelectOnlineAll;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataOnline()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_SelectOnline;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetConsumable()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_SelectConsumable;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetExamNonInterventConsumable()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_Select_NonInterventConsumable;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataTable GetExam_byBarcode(string barcode)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_Select_ByBarcode;
            ParameterList = new DbParameter[] {
                Parameter("@EXAM_BARCODE",barcode)
			};
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds.Tables[0];
        }
        public DataTable GetExamInvervent()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_Select_Intervent;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds.Tables[0];
        }
        public DataSet GetAllExam_IncludeUnActive()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAM_SelectAll_IncludeUnActive;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataTable GetExamPanel()
        {
            DataTable dtt = new DataTable();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMPANEL_Select;
            dtt = ExecuteDataTable();
            return dtt;
        }
        public DataTable GetExamPanelPortable(int exam_id)
        {
            DataTable dtt = new DataTable();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMPANELPORTABLE_SelectAll;
            ParameterList = new DbParameter[] {
                Parameter("@EXAM_ID",exam_id)
			};
            dtt = ExecuteDataTable();
            return dtt;
        }
        public DataTable GetExamPanelPortable(int exam_id,int clinic_type_id)
        {
            DataTable dtt = new DataTable();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMPANELPORTABLE_Select;
            ParameterList = new DbParameter[] {
                Parameter("@EXAM_ID",exam_id)
                ,Parameter("@CLINIC_TYPE_ID",clinic_type_id)
			};
            dtt = ExecuteDataTable();
            return dtt;
        }
        
    }
}

