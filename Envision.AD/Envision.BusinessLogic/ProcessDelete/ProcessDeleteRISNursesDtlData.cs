using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISNursesDtlData : IBusinessLogic
    {
        public RIS_NURSESDATADTL RIS_NURSESDATADTL { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteRISNursesDtlData()
		{
            RIS_NURSESDATADTL = new RIS_NURSESDATADTL();
            Transaction = null;
		}
      
		public void Invoke()
		{
            RIS_NURSESDATADTLDeleteData _proc = new RIS_NURSESDATADTLDeleteData();
            _proc.RIS_NURSESDATADTL = this.RIS_NURSESDATADTL;
			 _proc.Delete();
		}
    }
}
