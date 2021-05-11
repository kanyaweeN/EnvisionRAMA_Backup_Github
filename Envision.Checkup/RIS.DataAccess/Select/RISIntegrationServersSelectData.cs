using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
	public class RISIntegrationServersSelectData : DataAccessBase
	{
		public RIS_INTEGRATIONSERVERS RIS_INTEGRATIONSERVERS { get; set; }

		public RISIntegrationServersSelectData() { }

		public DataSet GetData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_INTEGRATIONSERVERS_Select.ToString();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString);
			return ds;
		}
	}
}
