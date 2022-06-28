using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISNursesData : IBusinessLogic
    {
        public RIS_NURSESDATA RIS_NURSESDATA { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteRISNursesData()
		{
            RIS_NURSESDATA = new RIS_NURSESDATA();
            Transaction = null;
		}
       
		public void Invoke()
		{
            RIS_NURSESDATADeleteData _proc = new RIS_NURSESDATADeleteData();
            _proc.RIS_NURSESDATA = this.RIS_NURSESDATA;
			 _proc.Delete();
		}
    }
}
