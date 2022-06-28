using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
using Envision.WebService.ReportSearch;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISSearchEngine
    {
        public DataSet Result { get; set; }
        public Envision.Common.RISSearchEngine RISSearchEngine { get; set; }

        public ProcessGetRISSearchEngine()
        {
            Result = new DataSet();
            RISSearchEngine = new Envision.Common.RISSearchEngine();
        }
 
		public void Invoke()
		{
            #region getdata from webservice
            DataSet dsReportSearch = new DataSet();

            Envision.WebService.ReportSearch.RISSearchEngine
                cm = new Envision.WebService.ReportSearch.RISSearchEngine();

            cm.ACCESSION_NO = RISSearchEngine.ACCESSION_NO;
            cm.AGE = RISSearchEngine.AGE;
            cm.EMP_ID = RISSearchEngine.EMP_ID;
            cm.EXAM_NAME = RISSearchEngine.EXAM_NAME;
            cm.EXAM_TYPE = RISSearchEngine.EXAM_TYPE;
            cm.GENDER = RISSearchEngine.GENDER;
            cm.HN = RISSearchEngine.HN;
            cm.KEY1 = RISSearchEngine.KEY1;
            cm.KEY2 = RISSearchEngine.KEY2;
            cm.KEY3 = RISSearchEngine.KEY3;
            cm.KEY4 = RISSearchEngine.KEY4;
            cm.KEY5 = RISSearchEngine.KEY5;
            cm.KEY6 = RISSearchEngine.KEY6;
            cm.KEY7 = RISSearchEngine.KEY7;
            cm.KEY8 = RISSearchEngine.KEY8;
            cm.KEY9 = RISSearchEngine.KEY9;
            cm.KEYS = RISSearchEngine.KEYS;
            cm.MODE = RISSearchEngine.MODE;
            cm.REPORTDATE_FROM = RISSearchEngine.REPORTDATE_FROM;
            cm.REPORTDATE_TO = RISSearchEngine.REPORTDATE_TO;
            cm.STUDYDATE_FROM = RISSearchEngine.STUDYDATE_FROM;
            cm.STUDYDATE_TO = RISSearchEngine.STUDYDATE_TO;

            EnvisionReportSearchWS ws = new EnvisionReportSearchWS();
            dsReportSearch = ws.WSRISSearchEngineSelectData(cm);

            Result = dsReportSearch;
            #endregion
		}
        public void InvokeDB()
        {
            #region original query
            RISSearchEngineSelectData _proc = new RISSearchEngineSelectData();
            _proc.RISSearchEngine = this.RISSearchEngine;
            Result = _proc.GetData();
            #endregion
        }
    }
}
