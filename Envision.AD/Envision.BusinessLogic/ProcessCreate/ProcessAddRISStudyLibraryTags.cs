using System.Data;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISStudyLibraryTags : IBusinessLogic
	{
        public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }
        public DataSet DataResult { get; set; }
        public ProcessAddRISStudyLibraryTags()
        {
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
            DataResult = new DataSet();
        }
		public void Invoke()
		{
            RISStudyLibraryTagsInsertData _proc = new RISStudyLibraryTagsInsertData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
            DataResult = _proc.Add();
		}
	}
}

