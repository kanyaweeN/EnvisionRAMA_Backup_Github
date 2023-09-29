using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISModalitySelectData : DataAccessBase
    {
        public RIS_MODALITY RIS_MODALITY { get; set; }
        public RISModalitySelectData()
        {
            RIS_MODALITY = new RIS_MODALITY();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_Select;
        }
        public RISModalitySelectData(bool selectAll)
        {
            RIS_MODALITY = new RIS_MODALITY();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_SelectAll;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetDataCNMI()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSetCNMI();
            return ds;
        }
        public DataSet GetDataID(int modalityID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_SelectByID;
            DbParameter[] parameters ={			
                Parameter("@MODALITY_ID",modalityID)
			};
            ParameterList = parameters;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet getModalitysetAppintmentByPatientType(int modalityID)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_Select_forSetAppintmentByPatientType;
            DbParameter[] parameters ={			
                Parameter("@MODALITY_ID",modalityID)
			};
            ParameterList = parameters;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
    }
}

