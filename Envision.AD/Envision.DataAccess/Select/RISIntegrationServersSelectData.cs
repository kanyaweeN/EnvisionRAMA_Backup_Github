using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;

namespace Envision.DataAccess.Select
{
	public class RISIntegrationServersSelectData : DataAccessBase
	{
		public RIS_INTEGRATIONSERVERS RIS_INTEGRATIONSERVERS { get; set; }

		public RISIntegrationServersSelectData() { }

		public DataSet GetData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_INTEGRATIONSERVERS_Select;

			return ExecuteDataSet();
		}
	}
}
