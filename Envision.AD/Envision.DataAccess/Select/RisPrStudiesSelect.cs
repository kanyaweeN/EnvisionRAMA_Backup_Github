using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RisPrStudiesSelect : DataAccessBase
    {
        public RIS_PRSTUDIES RIS_PRSTUDIES { get; set; }

        public RisPrStudiesSelect()
        {
            RIS_PRSTUDIES = new RIS_PRSTUDIES();
        }

        public DataSet getAlgorithmDataCT()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRAlgorithm_SelectCT;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             //Parameter( "@EMP_ID"	        , RIS_COMMENTSYSTEM_GROUPDTL.EMP_ID ),
                                             Parameter( "@ORG_ID"	        , RIS_PRSTUDIES.ORG_ID ),
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
                                             Parameter( "@ORG_ID"	        , RIS_PRSTUDIES.ORG_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
    }
}
