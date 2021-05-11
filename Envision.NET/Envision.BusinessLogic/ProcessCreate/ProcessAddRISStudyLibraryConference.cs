using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISStudyLibraryConference : IBusinessLogic
	{
        public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }
        public DataSet DataResult { get; set; }
        public ProcessAddRISStudyLibraryConference()
        {
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
            DataResult = new DataSet();
        }
		public void Invoke()
		{
            RISStudyLibraryConferenceInsertData _proc = new RISStudyLibraryConferenceInsertData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
            DataResult = _proc.Add();
		}
	}
}
