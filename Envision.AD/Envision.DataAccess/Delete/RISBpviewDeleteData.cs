using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class RIS_BPVIEWDeleteData : DataAccessBase 
	{
        public RIS_BPVIEW RIS_BPVIEW { get; set; }

        public RIS_BPVIEWDeleteData()
		{
            RIS_BPVIEW = new RIS_BPVIEW();
            StoredProcedureName = StoredProcedure.Prc_RIS_BPVIEW_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                     //   Parameter("@BPVIEW_ID",RIS_BPVIEW.BPVIEW_ID)
                                     };
            return parameters;
        }
	}
}

