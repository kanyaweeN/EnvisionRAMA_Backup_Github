using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISStudyLibraryConference : IBusinessLogic
    {
        public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }

        public ProcessDeleteRISStudyLibraryConference()
		{
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
		}
		
		public void Invoke()
		{
            RISStudyLibraryConferenceDeleteData proc = new RISStudyLibraryConferenceDeleteData();
            proc.RIS_STUDYLIBRARY = RIS_STUDYLIBRARY;
            proc.Delete();
		}
    }
}
