using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetRISStudyLibrary
	{
        public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }
		private DataSet result;
        public ProcessGetRISStudyLibrary()
		{
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void GetData()
		{
            RISStudyLibrarySelectData _proc = new RISStudyLibrarySelectData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
			result=_proc.GetData();
		}
        public DataTable GetDataACR()
        {
            RISStudyLibrarySelectData _proc = new RISStudyLibrarySelectData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
            return _proc.GetDataACR().Tables[0];
        }
        public DataTable GetDataBodyPart()
        {
            RISStudyLibrarySelectData _proc = new RISStudyLibrarySelectData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
            return _proc.GetDataBodyPart().Tables[0];
        }
        public DataTable GetDataCPT()
        {
            RISStudyLibrarySelectData _proc = new RISStudyLibrarySelectData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
            return _proc.GetDataCPT().Tables[0];
        }
        public DataTable GetDataICD()
        {
            RISStudyLibrarySelectData _proc = new RISStudyLibrarySelectData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
            return _proc.GetDataICD().Tables[0];
        }
        public DataTable GetDataShareWith()
        {
            RISStudyLibrarySelectData _proc = new RISStudyLibrarySelectData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
            return _proc.GetDataShareWith().Tables[0];
        }
        public DataTable GetDataTags()
        {
            RISStudyLibrarySelectData _proc = new RISStudyLibrarySelectData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
            return _proc.GetDataTags().Tables[0];
        }
        public DataTable GetDataConference()
        {
            RISStudyLibrarySelectData _proc = new RISStudyLibrarySelectData();
            _proc.RIS_STUDYLIBRARY = this.RIS_STUDYLIBRARY;
            return _proc.GetDataConference().Tables[0];
        }
	}
}

