using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISExamresultrads
    {
        public RIS_EXAMRESULTRADS RIS_EXAMRESULTRADS {get;set;}
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteRISExamresultrads()
		{
            RIS_EXAMRESULTRADS = new RIS_EXAMRESULTRADS();
            Transaction = null;
		}
		
		public void Invoke()
		{
            RISExamresultradsDeleteData _proc = new RISExamresultradsDeleteData();
            _proc.RIS_EXAMRESULTRADS = this.RIS_EXAMRESULTRADS;
			_proc.Delete();
		}
    }
}
