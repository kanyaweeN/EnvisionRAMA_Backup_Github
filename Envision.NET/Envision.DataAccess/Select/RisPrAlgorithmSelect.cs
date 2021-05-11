using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RisPrAlgorithmSelect : DataAccessBase
    {
        public RIS_PRALGORITHM RIS_PRALGORITHM { get; set; }

        public RisPrAlgorithmSelect()
        {
            RIS_PRALGORITHM = new RIS_PRALGORITHM();
        }

        public DataSet getAlgorithmData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRALGORITHM_Select;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             //Parameter( "@EMP_ID"	        , RIS_COMMENTSYSTEM_GROUPDTL.EMP_ID ),
                                             Parameter( "@ORG_ID"	        , RIS_PRALGORITHM.ORG_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet getAlgorithmDataByID()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRALGORITHM_SelectDataByAlgorithyID;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@ORG_ID"	        , RIS_PRALGORITHM.ORG_ID ),
                                             Parameter( "@ALGORITHM_ID"	        , RIS_PRALGORITHM.ALGORITHM_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet getAlgorithmDataCT()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRAlgorithm_SelectCT;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             //Parameter( "@EMP_ID"	        , RIS_COMMENTSYSTEM_GROUPDTL.EMP_ID ),
                                             Parameter( "@ORG_ID"	        , RIS_PRALGORITHM.ORG_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet getAlgorithmDataGeneralUltrasound()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRALGORITHM_SelectGeneralUltrasound;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             //Parameter( "@EMP_ID"	        , RIS_COMMENTSYSTEM_GROUPDTL.EMP_ID ),
                                             Parameter( "@ORG_ID"	        , RIS_PRALGORITHM.ORG_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
    }
}
