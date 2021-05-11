using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetXrayAndScheduleArrivalWorkList : IBusinessLogic
    {
        public enum SearchModes
        {
            ByHN = 1,
            ByExamDate = 2,
            NoExamDate = 3,
            OnlyOnline = 4
        }
        public string HN { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Filter { get; set; }
        public string ExamTypeFilter { get; set; }
        public int OrgId { get; set; }
        public bool isShowAll { get; set; }
        public int ShowMode { get; set; }
        private SearchModes _searchMode = SearchModes.ByHN;
        /// <summary>
        /// Get or set Search Mode
        /// </summary>
        public SearchModes SearchMode 
        {
            get { return _searchMode; }
            set { _searchMode = value; }
        }
        public DataSet Result { get; set; }

        #region IBusinessLogic Members

        public void Invoke()
        {
            XrayAndScheduleArrivalWorkListSelect processor = new XrayAndScheduleArrivalWorkListSelect();
            this.Result = processor.GetArrivalWorkList(this.HN, this.From, this.To, this.Filter, this.OrgId, (int)this.SearchMode, this.isShowAll, this.ShowMode, this.ExamTypeFilter);
        }

        #endregion
    }
}
