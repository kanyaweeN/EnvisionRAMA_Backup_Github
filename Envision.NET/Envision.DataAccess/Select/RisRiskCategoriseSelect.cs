using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Select
{
    public class RisRiskCategoriseSelect : DataAccessBase
    {
        public RIS_RISKCATEGORISE RIS_RISKCATEGORISE { get; set; }
        public RisRiskCategoriseSelect()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_RISKCATEGORIES_SELECT;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ParameterList = BuildParameters();
            ds = ExecuteDataSet();
            return ds;
        }
        public DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = {
                                            Parameter("@ORG_ID", RIS_RISKCATEGORISE.ORG_ID)    
                                       };
            return parameters;
        }

        public DataTable getPRECAUTIONData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_RISKCATEGORIES_SELECTbyPRECAUTION;
            return ExecuteDataTable();;
        }
        public DataTable getCONTRAINDICATIONData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_RISKCATEGORIES_SELECTbyCONTRAINDICATION;
            return ExecuteDataTable(); ;
        }
        public DataTable getCTData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_RISKCATEGORIES_SELECTbyCT;
            return ExecuteDataTable(); ;
        }
        public DataTable getMRIData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_RISKCATEGORIES_SELECTbyMRI;
            return ExecuteDataTable(); ;
        }
    }
}
