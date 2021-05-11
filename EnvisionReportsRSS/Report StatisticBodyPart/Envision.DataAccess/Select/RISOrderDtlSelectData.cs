using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Envision.Common;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Select
{
    public class RISOrderDtlSelectData : DataAccessBase
    {
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }
        public RISOrderDtlSelectData()
        {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITY_Select;
        }
        public DataSet Select()
        {
            return ExecuteDataSet();
        }
        public DataSet SelectByDateAndModality()
        {
            StoredProcedureName = StoredProcedure.Prc_Modality_Count;
            ParameterList = buildParameterBySearch();
            return ExecuteDataSet();
        }
        private DbParameter[] buildParameterBySearch()
        {
            DbParameter[] parameters ={
                                         Parameter("@date_begin",RIS_ORDERDTL.EXAM_DT),
                                         Parameter("@date_end",RIS_ORDERDTL.EXAM_DT),
                                         Parameter("@MODALITY_ID",RIS_ORDERDTL.MODALITY_ID),
                                     };
            return parameters;
        }
    }
}
