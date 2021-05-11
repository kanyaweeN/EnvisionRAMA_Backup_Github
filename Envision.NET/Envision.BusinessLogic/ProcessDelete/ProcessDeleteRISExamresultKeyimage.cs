using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISExamresultKeyimage : IBusinessLogic
    { 
        public RIS_EXAMRESULTKEYIMAGES RIS_EXAMRESULTKEYIMAGES {get;set;}

        public DbTransaction Transaction { get; set; }

        public ProcessDeleteRISExamresultKeyimage()
		{
            RIS_EXAMRESULTKEYIMAGES = new RIS_EXAMRESULTKEYIMAGES();
            Transaction = null;
		}
	
		public void Invoke()
		{
            RISExamresultKeyimageDeleteData _proc = new RISExamresultKeyimageDeleteData();
            _proc.RIS_EXAMRESULTKEYIMAGES = this.RIS_EXAMRESULTKEYIMAGES;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
    }
}
