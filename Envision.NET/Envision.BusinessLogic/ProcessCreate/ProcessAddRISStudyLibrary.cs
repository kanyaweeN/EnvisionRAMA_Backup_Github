using System.Data;
using Envision.Common;
using Envision.DataAccess.Insert;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISStudyLibrary : IBusinessLogic
	{
        public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }
        
        public DataSet DataResult { get; set; }
        public ProcessAddRISStudyLibrary()
        {
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
            DataResult = new DataSet();
        }
		public void Invoke()
		{
            RISStudyLibraryInsertData _proc = new RISStudyLibraryInsertData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
            DataResult = _proc.Add();
		}
	}
}

