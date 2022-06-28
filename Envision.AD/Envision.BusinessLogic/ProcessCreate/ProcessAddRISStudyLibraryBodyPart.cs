using System.Data;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISStudyLibraryBodyPart : IBusinessLogic
	{
        public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }
        public DataSet DataResult { get; set; }
        public ProcessAddRISStudyLibraryBodyPart()
        {
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
            DataResult = new DataSet();
        }
		public void Invoke()
		{
            RISStudyLibraryBodyPartInsertData _proc = new RISStudyLibraryBodyPartInsertData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
            DataResult = _proc.Add();
		}
	}
}

