using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISContrastLotInsertData : DataAccessBase
    {
        public RIS_CONTRASTLOT RIS_CONTRASTLOT { get; set; }
        public RISContrastLotInsertData()
        {
            RIS_CONTRASTLOT = new RIS_CONTRASTLOT();
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTLOT_Insert;
        }
        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {

            DbParameter[] parameters ={
Parameter("@LOT_UID",RIS_CONTRASTLOT.LOT_UID),
Parameter("@LOT_TEXT",RIS_CONTRASTLOT.LOT_TEXT),
Parameter("@IS_ACTIVE",RIS_CONTRASTLOT.IS_ACTIVE),
Parameter("@CREATED_BY",RIS_CONTRASTLOT.CREATED_BY),
            };
            return parameters;
        }

        public void AddLotMapping(int contrastId,int lotId,int createBy)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTLOTMAPPING_Insert;
            DbParameter[] parameters ={
Parameter("@CONTRAST_ID",contrastId),
Parameter("@LOT_ID",lotId),
Parameter("@CREATED_BY",createBy),
            };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
        public void deleteLotMapping(int lotmappintId)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTLOTMAPPING_Delete;
            DbParameter[] parameters ={
Parameter("@LOTMAPPING_ID",lotmappintId),
            };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
        

    }
}
