using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class SplitOrderInsertData : DataAccessBase
    {
        public SplitOrder SplitOrder { get; set; }


        public SplitOrderInsertData()
        {
            SplitOrder = new SplitOrder();
            StoredProcedureName = StoredProcedure.Prc_SplitOrder;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters =
		    {
				Parameter( "@OrdID"         ,SplitOrder.OrderID) ,
				Parameter( "@AccessionNo"   ,SplitOrder.AccessionNo) ,
				Parameter( "@NewAccession"  ,SplitOrder.NewAccession) ,
				Parameter( "@PatientHN"     ,SplitOrder.PatientHN) ,
				Parameter( "@OrgID"	        ,new GBLEnvVariable().OrgID  ) ,
				Parameter( "@CreatedBy"     ,new GBLEnvVariable().UserID ),
			};
            return parameters;
        }
       
    }
}
