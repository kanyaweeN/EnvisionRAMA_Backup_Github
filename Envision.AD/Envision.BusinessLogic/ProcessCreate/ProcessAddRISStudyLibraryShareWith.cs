using System.Data;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISStudyLibraryShareWith : IBusinessLogic
	{
        public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }
        public DataSet DataResult { get; set; }
        public ProcessAddRISStudyLibraryShareWith()
        {
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
            DataResult = new DataSet();
        }
		public void Invoke()
		{
            RISStudyLibraryShareWithInsertData _proc = new RISStudyLibraryShareWithInsertData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
            DataResult = _proc.Add();
		}
	}
}

