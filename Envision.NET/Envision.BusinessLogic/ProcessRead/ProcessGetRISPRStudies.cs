using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISPRStudies : IBusinessLogic
    {
        public RIS_PRSTUDIES RIS_PRSTUDIES { get; set; }
        private DataSet _resultset;

        public ProcessGetRISPRStudies()
        {
            RIS_PRSTUDIES = new RIS_PRSTUDIES();
        }

        public void Invoke()
        {

            RISPRStudiesSelectData prc = new RISPRStudiesSelectData();
            prc.RIS_PRSTUDIES = this.RIS_PRSTUDIES;
            ResultSet = prc.GetData();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public string getResultText(string accession_no)
        {
            RISPRStudiesSelectData prc = new RISPRStudiesSelectData();
            return prc.getResultText(accession_no);
        }
    }
}
